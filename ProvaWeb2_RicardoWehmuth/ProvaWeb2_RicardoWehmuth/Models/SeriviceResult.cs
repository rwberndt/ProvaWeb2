namespace ProvaWeb2_RicardoWehmuth.Models
{
    
    public record ServiceResult
    {
        protected ServiceResult()
        {
        }

        protected ServiceResult(object? id, bool succeeded)
        {
            Id = id;
            Succeeded = succeeded;
        }
        protected ServiceResult(object? id, bool succeeded,string description)
        {
            Id = id;
            Succeeded = succeeded;
            Description = description;
        }

        protected ServiceResult(Exception? exception)
        {
            Succeeded = false;
            Exception = exception;
        }

        public object? Id { get; init; }
        public bool Succeeded { get; init; }
        public Exception? Exception { get; init; }

        public string Description { get; init; }

        public static ServiceResult Success() => new(null, true);
        public static ServiceResult Success(object? id) => new(id, true);
        public static ServiceResult Success(object? id,string description) => new(id, true, description);

        public static ServiceResult Failure() => new(null, false);
        public static ServiceResult Failure(Exception ex) => new(ex);
    }

    public record ServiceResult<T> : ServiceResult
    {
        protected ServiceResult(T? data) : base()
        {
            Data = data;
            Succeeded = true;
        }


        public T? Data { get; init; }

        public static ServiceResult<T> Success(T data) => new(data);
    }

}
