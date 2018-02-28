using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Results
{
    public class DomainResult
    {
        public bool HasResult { get; protected set; } = true;
        public bool HasError { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public Exception Exception { get; protected set; }

        protected DomainResult() { }

        public DomainResult(string errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
        }

        public DomainResult(Exception ex)
        {
            HasError = true;
            ErrorMessage = ex.Message;
            Exception = ex;
        }

        public DomainResult(bool hasError, Exception ex, string errorMessage)
        {
            HasError = hasError;
            Exception = ex;
            ErrorMessage = errorMessage;
        }

        public static DomainResult Ok = new DomainResult
        {
            HasError = false
        };

        public static DomainResult UnknownError = new DomainResult
        {
            HasError = true,
            ErrorMessage = "Unknown error"
        };

        public static DomainResult Skipped = new DomainResult
        {
            HasError = false,
            HasResult = false,
            ErrorMessage = "Action has been skipped"
        };
    }
}
