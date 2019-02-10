using System;

namespace MidnightLizard.Commons.Domain.Results
{
    public enum DomainProblemLevel
    {
        None,
        Unknown,
        Domain,
        Infrastructure,
        Application
    }

    public class DomainResult
    {
        public DomainProblemLevel ProblemLevel { get; protected set; } = DomainProblemLevel.None;
        public bool HasResult { get; protected set; } = true;
        public bool HasError { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public Exception Exception { get; protected set; }

        protected DomainResult() { }

        public DomainResult(string errorMessage, DomainProblemLevel level = DomainProblemLevel.Unknown)
        {
            this.ProblemLevel = level;
            this.HasError = true;
            this.ErrorMessage = errorMessage;
        }

        public DomainResult(Exception ex, DomainProblemLevel level = DomainProblemLevel.Unknown)
        {
            this.ProblemLevel = level;
            this.HasError = true;
            this.ErrorMessage = ex.Message;
            this.Exception = ex;
        }

        public DomainResult(bool hasError, Exception ex, string errorMessage, DomainProblemLevel level = DomainProblemLevel.Unknown)
        {
            this.ProblemLevel = level;
            this.HasError = hasError;
            this.Exception = ex;
            this.ErrorMessage = errorMessage;
        }

        public static DomainResult Ok = new DomainResult
        {
            HasError = false
        };

        public static DomainResult UnknownError = new DomainResult
        {
            HasError = true,
            ProblemLevel = DomainProblemLevel.Unknown,
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
