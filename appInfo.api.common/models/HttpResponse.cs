using System.Diagnostics.CodeAnalysis;

namespace appInfo.api.common.models
{
    /// <summary>
    /// Purpose: ResponseMdl for Response message - Wrapper class for all Response Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResponse<T>
    {
        T? _results;

        public bool IsSuccess { get; set; } = true;
        public bool IsException
        {
            get
            {
                return !IsSuccess;
            }
        }
        public string Errors { get; set; } = string.Empty;

        public T? Result
        {
            get
            {
                _results = IsSuccess && _results == null ? Activator.CreateInstance<T>() : _results;
                return _results;
            }

            set { _results = value; }
        }

    }
}