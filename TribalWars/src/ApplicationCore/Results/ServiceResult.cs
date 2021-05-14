using System.Collections.Generic;
using ApplicationCore.Enums;

namespace ApplicationCore.Results
{
    public class ServiceResult
    {
        public IEnumerable<string> Errors { get; }
        public ServiceResultStatus ServiceStatus { get; }

        public ServiceResult(ServiceResultStatus serviceStatus, IEnumerable<string> errors)
        {
            ServiceStatus = serviceStatus;
            Errors = errors;
        }

        public bool Succeeded => ServiceStatus == ServiceResultStatus.Success;

        public static ServiceResult Success()
        {
            return new(ServiceResultStatus.Success, new string[] { });
        }

        public static ServiceResult Failure(IEnumerable<string> errors)
        {
            return new(ServiceResultStatus.Failure, errors);
        }

        public static ServiceResult Failure(string error)
        {
            return new(ServiceResultStatus.Failure, new List<string> {error});
        }
    }
}