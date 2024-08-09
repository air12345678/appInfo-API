namespace appInfo.api.common.models
{
    public class Blob
    {
        public Uri? Uri {get;set;}
        public string? Name {get;set;}
        public string? ContentType {get;set;}
        public Stream? Content{get;set;}
    }
}