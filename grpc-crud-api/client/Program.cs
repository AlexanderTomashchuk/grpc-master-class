using System;
using System.Threading.Tasks;
using Blog;
using Grpc.Core;
using Grpc.Core.Utils;
using static Blog.BlogService;

namespace client
{
    class Program
    {
        private const string Host = "localhost";
        private const int TargetPort = 50051;
        
        static async Task Main(string[] args)
        {
            var channel = new Channel(Host, TargetPort, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine($"The client connected successfully to the target: {Host}:{TargetPort}");
                }
            });
            
            var blogClient = new BlogServiceClient(channel);

            //await CreateBlog(blogClient);
            //await ReadBlog(blogClient);
            //await UpdateBlog(blogClient);
            //await DeleteBlog(blogClient);
            await ListBlog(blogClient);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task CreateBlog(BlogServiceClient blogClient)
        {
            var response = await blogClient.CreateBlogAsync(new CreateBlogRequest
            {
                Blog = new Blog.Blog
                {
                    AuthorId = "Oleksandr",
                    Title = "New blog!",
                    Content = "Hello world! This is a new blog."
                }
            });

            Console.WriteLine(response);
        }

        private static async Task ReadBlog(BlogServiceClient blogClient)
        {
            try
            {
                var response = await blogClient.ReadBlogAsync(new ReadBlogRequest
                {
                    BlogId = "5eaf5ebfd105f7705d25f7a1"
                });

                Console.WriteLine(response.Blog);
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Status.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        private static async Task UpdateBlog(BlogServiceClient blogClient)
        {
            try
            {
                var response = await blogClient.UpdateBlogAsync(new UpdateBlogRequest
                {
                    Blog = new Blog.Blog
                    {
                        Id = "5eaf5ebfd105f7705d25f7a1",
                        AuthorId = "Kate",
                        Title = "Edited blog!",
                        Content = "This is an edited blog"
                    }
                });

                Console.WriteLine(response.Blog);
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Status.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        private static async Task DeleteBlog(BlogServiceClient blogClient)
        {
            try
            {
                var response = await blogClient.DeleteBlogAsync(new DeleteBlogRequest
                {
                    BlogId = "5eb6fb972afd4f1f4fe24f95"
                });

                Console.WriteLine($"The blog with id {response.BlogId} was deleted");
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Status.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        private static async Task ListBlog(BlogServiceClient blogClient)
        {
            var responseStream = blogClient.ListBlog(new ListBlogRequest()).ResponseStream;

            await responseStream.ForEachAsync(r =>
            {
                Console.WriteLine(r.Blog);
                return Task.CompletedTask;
            });
        }
    }
}