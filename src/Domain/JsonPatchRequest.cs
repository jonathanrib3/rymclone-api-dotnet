namespace RymCloneApi.src.Domain
{
  public enum JsonPatchOperation
  {
    REPLACE,
    REMOVE,
    ADD,
    TEST,
    UNKNOWN
  }
  public class JsonPatchRequest<T> where T : class
  {
    //public JsonPatchOperation Op 
    //{
    //  get;
      
    //  set
    //  {
    //    // opArr = ['1', '2', '3,'] 
    //    // 
    //    return 
    //  }
    //}
    public String Path { get; set; }
    public object Value { get; set; }

    public JsonPatchOperation OperationMapper(String op)
    {
      switch(op)
      {
        case "add":
          return JsonPatchOperation.ADD;
        case "replace":
          return JsonPatchOperation.REPLACE;
        case "remove":
          return JsonPatchOperation.REMOVE;
        case "test":
          return JsonPatchOperation.TEST;
        default:
          return JsonPatchOperation.UNKNOWN;
      }
    }
  }
}
