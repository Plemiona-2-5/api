using ApplicationCore.Enums;
using ApplicationCore.Results;
using System.Collections.Generic;

namespace ApplicationCore.Results.Generic
{
    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult(ServiceResultStatus serviceStatus, IEnumerable<string> errors) : base(serviceStatus, errors)
        {
        }
        public T Content { get; set; }
    }
}
