namespace appInfo.api.common.models
{
    public class BlobResponseDto
    {
        public string? Status {get;set;}
        public bool Error{get;set;}
        public Blob Blob{get;set;}

        public BlobResponseDto(){
            Blob = new Blob();
        }
    }
}