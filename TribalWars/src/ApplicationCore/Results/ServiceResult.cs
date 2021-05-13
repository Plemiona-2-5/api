using System.Collections.Generic;

namespace ApplicationCore.Results
{
    public class ServiceResult
    {
        public IEnumerable<string> Errors { get; }
        public bool Succeeded { get; }

        public ServiceResult(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        public static ServiceResult Success()
        {
            return new(true, new string[] { });
        }

        public static ServiceResult Failure(IEnumerable<string> errors)
        {
            return new(false, errors);
        }

        public static ServiceResult Failure(string error)
        {
            return new(false, new List<string> {error});
        }
    }
}