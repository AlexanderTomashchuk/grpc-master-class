// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: calculator.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Calculator {

  /// <summary>Holder for reflection information generated from calculator.proto</summary>
  public static partial class CalculatorReflection {

    #region Descriptor
    /// <summary>File descriptor for calculator.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CalculatorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBjYWxjdWxhdG9yLnByb3RvEgpjYWxjdWxhdG9yIiQKEkZpbmRNYXhpbXVt",
            "UmVxdWVzdBIOCgZudW1iZXIYASABKBEiKAoTRmluZE1heGltdW1SZXNwb25z",
            "ZRIRCgltYXhOdW1iZXIYASABKBEyaQoRQ2FsY3VsYXRvclNlcnZpY2USVAoL",
            "RmluZE1heGltdW0SHi5jYWxjdWxhdG9yLkZpbmRNYXhpbXVtUmVxdWVzdBof",
            "LmNhbGN1bGF0b3IuRmluZE1heGltdW1SZXNwb25zZSIAKAEwAWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Calculator.FindMaximumRequest), global::Calculator.FindMaximumRequest.Parser, new[]{ "Number" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Calculator.FindMaximumResponse), global::Calculator.FindMaximumResponse.Parser, new[]{ "MaxNumber" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class FindMaximumRequest : pb::IMessage<FindMaximumRequest> {
    private static readonly pb::MessageParser<FindMaximumRequest> _parser = new pb::MessageParser<FindMaximumRequest>(() => new FindMaximumRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FindMaximumRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Calculator.CalculatorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FindMaximumRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FindMaximumRequest(FindMaximumRequest other) : this() {
      number_ = other.number_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FindMaximumRequest Clone() {
      return new FindMaximumRequest(this);
    }

    /// <summary>Field number for the "number" field.</summary>
    public const int NumberFieldNumber = 1;
    private int number_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Number {
      get { return number_; }
      set {
        number_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FindMaximumRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FindMaximumRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Number != other.Number) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Number != 0) hash ^= Number.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Number != 0) {
        output.WriteRawTag(8);
        output.WriteSInt32(Number);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Number != 0) {
        size += 1 + pb::CodedOutputStream.ComputeSInt32Size(Number);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FindMaximumRequest other) {
      if (other == null) {
        return;
      }
      if (other.Number != 0) {
        Number = other.Number;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Number = input.ReadSInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class FindMaximumResponse : pb::IMessage<FindMaximumResponse> {
    private static readonly pb::MessageParser<FindMaximumResponse> _parser = new pb::MessageParser<FindMaximumResponse>(() => new FindMaximumResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FindMaximumResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Calculator.CalculatorReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FindMaximumResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FindMaximumResponse(FindMaximumResponse other) : this() {
      maxNumber_ = other.maxNumber_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FindMaximumResponse Clone() {
      return new FindMaximumResponse(this);
    }

    /// <summary>Field number for the "maxNumber" field.</summary>
    public const int MaxNumberFieldNumber = 1;
    private int maxNumber_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int MaxNumber {
      get { return maxNumber_; }
      set {
        maxNumber_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FindMaximumResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FindMaximumResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MaxNumber != other.MaxNumber) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MaxNumber != 0) hash ^= MaxNumber.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (MaxNumber != 0) {
        output.WriteRawTag(8);
        output.WriteSInt32(MaxNumber);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MaxNumber != 0) {
        size += 1 + pb::CodedOutputStream.ComputeSInt32Size(MaxNumber);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FindMaximumResponse other) {
      if (other == null) {
        return;
      }
      if (other.MaxNumber != 0) {
        MaxNumber = other.MaxNumber;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            MaxNumber = input.ReadSInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
