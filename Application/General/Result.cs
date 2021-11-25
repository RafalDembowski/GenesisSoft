using System;
using System.Collections.Generic;
using System.Text;

namespace Application.General
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Entity { get; set; }
        public string Error { get; set; }
        public static Result<T> Success(T entity) => new Result<T> { IsSuccess = true, Entity = entity };
        public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Error = error };
    }
}
