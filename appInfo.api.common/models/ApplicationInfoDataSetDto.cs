using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace appInfo.api.common.models
{
    public class ApplicationInfoDataSetDto
    {
        public string ApplicationName { get; set; } = string.Empty;
        public string RolesName { get; set; } = string.Empty;
        public string ApplicationSMEName { get; set; } = string.Empty;
        public string ApplicationType { get; set; } = string.Empty;
        public DatabaseDetail? Databases {get;set;}
        public string[]? TechStack {get;set;}
        public RepoistoryDetails? GitRepoistoryPath {get;set;}
        public string ApplicationURL {get;set;} = string.Empty;
        public string SharepointLink {get;set;} = string.Empty;
        public string ExcelLink {get;set;} = string.Empty;
    }
}