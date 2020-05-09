using System.Threading.Tasks;
using Blog;
using Grpc.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using static Blog.BlogService;

namespace server
{
    public class BlogServiceImpl : BlogServiceBase
    {
        //insert mongodb password
        private static readonly MongoClient MongoClient = new MongoClient(
            "mongodb+srv://at:<password>@at-sandbox-8ie1r.mongodb.net");
        private static readonly IMongoDatabase MongoDatabase = MongoClient.GetDatabase("grpc-master-class");
        private static IMongoCollection<BsonDocument> _mongoCollection =
            MongoDatabase.GetCollection<BsonDocument>("blog"); 
        
        public override Task<CreateBlogResponse> CreateBlog(CreateBlogRequest request, ServerCallContext context)
        {
            var blog = request.Blog;
            
            var blogDocument = new BsonDocument()
                .Add("author_id", blog.AuthorId)
                .Add("title", blog.Title)
                .Add("content", blog.Content);

            _mongoCollection.InsertOne(blogDocument);

            var blogId = blogDocument.GetValue("_id").ToString();

            blog.Id = blogId;
            
            return Task.FromResult(new CreateBlogResponse { Blog = blog });
        }

        public override async Task<ReadBlogResponse> ReadBlog(ReadBlogRequest request, ServerCallContext context)
        {
            var blogId = request.BlogId;
            
            var filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id", new ObjectId(blogId));

            var result = await _mongoCollection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"The blog with id {blogId} wasn't found"));
            }
            
            var blog = new Blog.Blog
            {
                Id = blogId,
                AuthorId = result.GetValue("author_id").AsString,
                Title = result.GetValue("title").AsString,
                Content = result.GetValue("content").AsString,
            };
            
            return new ReadBlogResponse { Blog = blog };
        }

        public override async Task<UpdateBlogResponse> UpdateBlog(UpdateBlogRequest request, ServerCallContext context)
        {
            var blogId = request.Blog.Id;
            
            var filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id", new ObjectId(blogId));

            var result = await _mongoCollection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"The blog with id {blogId} wasn't found"));
            }
            
            var blogDocument = new BsonDocument()
                .Add("author_id", request.Blog.AuthorId)
                .Add("title", request.Blog.Title)
                .Add("content", request.Blog.Content);

            await _mongoCollection.ReplaceOneAsync(filter, blogDocument);
            
            var blog = new Blog.Blog
            {
                Id = blogId,
                AuthorId = blogDocument.GetValue("author_id").AsString,
                Title = blogDocument.GetValue("title").AsString,
                Content = blogDocument.GetValue("content").AsString
            };

            return new UpdateBlogResponse { Blog = blog};
        }

        public override async Task<DeleteBlogResponse> DeleteBlog(DeleteBlogRequest request, ServerCallContext context)
        {
            var blogId = request.BlogId;
            
            var filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id", new ObjectId(blogId));

            var result = await _mongoCollection.DeleteOneAsync(filter);
            
            if (result.DeletedCount == 0)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"The blog with id {blogId} wasn't found"));
            }
            
            return new DeleteBlogResponse { BlogId = blogId };
        }

        public override async Task ListBlog(ListBlogRequest request, IServerStreamWriter<ListBlogResponse> responseStream, ServerCallContext context)
        {
            var filter = new FilterDefinitionBuilder<BsonDocument>().Empty;

            var result = await _mongoCollection.FindAsync(filter);

            foreach (var blogItem in result.ToList())
            {
                await responseStream.WriteAsync(new ListBlogResponse
                {
                    Blog = new Blog.Blog
                    {
                        Id = blogItem.GetValue("_id").ToString(),
                        AuthorId = blogItem.GetValue("author_id").AsString,
                        Title = blogItem.GetValue("title").AsString,
                        Content = blogItem.GetValue("content").AsString
                    }
                });
            }
        }
    }
}