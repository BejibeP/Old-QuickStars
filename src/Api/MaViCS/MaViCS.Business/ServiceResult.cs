namespace QuickStars.MaViCS.Business
{
    public enum ResultType
    {
        Success,
        NotFound,
        Unauthorized,
        Error
    }

    public class ServiceResult
    {
        public ResultType Type { get; protected set; }

        public string Message { get; protected set; }

        protected ServiceResult(ResultType type, string message)
        {
            Type = type;
            Message = message;
        }

        public static ServiceResult Success()
        {
            return new ServiceResult(ResultType.Success, "");
        }

        public static ServiceResult Error(string message)
        {
            return new ServiceResult(ResultType.Error, message);
        }

        public static ServiceResult NotFound(string message)
        {
            return new ServiceResult(ResultType.NotFound, message);
        }

        public static ServiceResult Unauthorized(string message)
        {
            return new ServiceResult(ResultType.Unauthorized, message);
        }

    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Result { get; protected set; }

        protected ServiceResult(T result, ResultType type, string message) : base(type, message)
        {
            Result = result;
        }
        
        public static ServiceResult<T> Success(T result)
        {
            return new ServiceResult<T>(result, ResultType.Success, "");
        }

    }

}
