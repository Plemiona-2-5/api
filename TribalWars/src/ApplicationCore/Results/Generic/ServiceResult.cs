using ApplicationCore.Enums;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Results.Generic
{
    public class ServiceResult<T> : ServiceResult
    {
        public T Content { get; }

        private ServiceResult(ServiceResultStatus serviceStatus, IEnumerable<string> errors, T content) : base(serviceStatus, errors)
        {
            Content = content;
        }

        public static ServiceResult<T> Success(T content)
        {
            return new(ServiceResultStatus.Success, null, content );
        }
    }
}
