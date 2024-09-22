using System.Linq;
using appInfo.api.common.models;
using appInfo.API.BLL.Interfaces;
using appInfo.API.DAL.Interfaces;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace appInfo.api.BLL.Implementation
{
    public class ApplicationInfoDetailBAL : IApplicationDetailBAL
    {
        private readonly IApplicationDetailDAL ObjDal;

        public ApplicationInfoDetailBAL(IApplicationDetailDAL _objDal)
        {
            ObjDal = _objDal;
        }


        public async Task<HttpResponse<object>> AddApplicationDetails(ApplicationInfoDataSetDto detailParams)
        {
            var Result = new HttpResponse<object>();
            try
            {
                await this.ValidateApplicationInfoRequestPayload(detailParams);
                await ObjDal.AddApplicationDetails(detailParams);
                Result.IsSuccess = true;
            }
            catch (Exception Ex)
            {
                Result.IsSuccess = false;
                Result.Errors = Ex.Message;
                throw new Exception(Result.Errors);
            }
            return Result;
        }

        private async Task<bool> ValidateApplicationInfoRequestPayload(ApplicationInfoDataSetDto detailParams)
        {
            var modelState = new Dictionary<string, string[]>();
            if (string.IsNullOrEmpty(detailParams?.ApplicationName))
            {
                modelState.Add(nameof(detailParams.ApplicationName), new[] { "The value of ApplicationName is required." });
            }

            if (string.IsNullOrEmpty(detailParams?.ApplicationSMEName))
            {
                modelState.Add(nameof(detailParams.ApplicationSMEName), new[] { "The value of ApplicationSMEName is required." });
            }

            if (string.IsNullOrEmpty(detailParams?.ApplicationType))
            {
                modelState.Add(nameof(detailParams.ApplicationType), new[] { "The value of ApplicationType is required." });
            }

            if (string.IsNullOrEmpty(detailParams?.ApplicationURL) || !Uri.IsWellFormedUriString(detailParams?.ApplicationURL, UriKind.Absolute))
            {
                modelState.Add(nameof(detailParams.ApplicationURL), new[] { "The value of ApplicationURL is required/must be a valid URL." });
            }

            if (detailParams.Databases.Any())
            {
                bool hasServerNameError = false;
                bool hasDatabaseNameError = false;
                foreach (var kvp in detailParams.Databases)
                {
                    if (string.IsNullOrWhiteSpace(kvp.Key) && !hasServerNameError)
                    {
                        modelState.Add("ServerName", new[] { "At least one ServerName is required." });
                        hasServerNameError = true;
                    }

                    if (string.IsNullOrWhiteSpace(kvp.Value) && !hasDatabaseNameError)
                    {
                        modelState.Add("DataBaseName", new[] { "At least one DatabaseName is required." });
                        hasDatabaseNameError = true;
                    }
                }
            }

            if (string.IsNullOrEmpty(detailParams?.ExcelLink) || !Uri.IsWellFormedUriString(detailParams?.ExcelLink, UriKind.Absolute))
            {
                modelState.Add(nameof(detailParams.ExcelLink), new[] { "The value of ExcelLink is required/must be a valid URL." });
            }

            if (detailParams.GitRepoistoryPath != null && detailParams.GitRepoistoryPath.Any())
            {
                bool hasRepoNameError = false;
                bool hasRepoUrlError = false;

                foreach (var kvp in detailParams.GitRepoistoryPath)
                {
                    if (string.IsNullOrWhiteSpace(kvp.Key) && !hasRepoNameError)
                    {
                        modelState.Add("RepoName", new[] { "At least one RepoName is required." });
                        hasRepoNameError = true; 
                    }

                    if (string.IsNullOrWhiteSpace(kvp.Value) ||
                        !Uri.IsWellFormedUriString(kvp.Value, UriKind.Absolute) && !hasRepoUrlError)
                    {
                        modelState.Add("RepoURL", new[] { "At least one RepoURL is required and must be a valid URL." });
                        hasRepoUrlError = true; 
                    }
                }
            }

            if (string.IsNullOrEmpty(detailParams?.RolesName))
            {
                modelState.Add(nameof(detailParams.RolesName), new[] { "The value of RolesName is required." });
            }

            if (string.IsNullOrEmpty(detailParams?.SharepointLink) || !Uri.IsWellFormedUriString(detailParams?.SharepointLink, UriKind.Absolute))
            {
                modelState.Add(nameof(detailParams.SharepointLink), new[] { "The value of SharepointLink is required/must be a valid URL." });
            }

            if (modelState.Any())
            {
                var errorMessages = string.Join(Environment.NewLine, modelState.Select(kv => $"{kv.Key}: {string.Join(", ", kv.Value)}"));
                throw new Exception($"Validation failed:{Environment.NewLine}{errorMessages}");
            }

            return await (!modelState.Any() ? Task.FromResult(true) : throw new Exception(modelState.ToString()));
        }

    }
}