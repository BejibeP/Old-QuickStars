namespace QuickStars.MaViCS.Business
{

    public enum ResultType
    {
        Ok,
        Created,
        NoContent,
        BadRequest,
        Unauthorized,
        Forbidden,
        NotFound,
        ServerError
    }

    public class ServiceResult<T>
    {
        public ResultType Type { get; protected set; }
        public IList<string> Messages { get; protected set; }
        public T Value { get; protected set; }

        protected ServiceResult()
        {

        }

        public static ServiceResult<T> Success(params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.Ok,
                Messages = messages.ToList()
            };
        }

        public static ServiceResult<T> Success(T value, params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.Ok,
                Messages = messages.ToList(),
                Value = value
            };
        }

        public static ServiceResult<T> Created(T value, params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.Created,
                Messages = messages.ToList(),
                Value = value
            };
        }

        public static ServiceResult<T> NoContent(params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.NoContent,
                Messages = messages.ToList()
            };
        }

        public static ServiceResult<T> BadRequest(params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.BadRequest,
                Messages = messages.ToList()
            };
        }

        public static ServiceResult<T> Unauthorized(params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.Unauthorized,
                Messages = messages.ToList()
            };
        }

        public static ServiceResult<T> Forbidden(params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.Forbidden,
                Messages = messages.ToList()
            };
        }

        public static ServiceResult<T> NotFound(params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.NotFound,
                Messages = messages.ToList()
            };
        }

        public static ServiceResult<T> ServerError(params string[] messages)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.ServerError,
                Messages = messages.ToList()
            };
        }

    }
}
