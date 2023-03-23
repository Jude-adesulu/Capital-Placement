using CapitalPlacement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Utilities
{
    public class Result : IResult
    {
        public Result()
        {
        }

        public string message_Id { get; set; }

        public string message { get; set; }

        public bool succeeded { get; set; }

        public string errorId { get; set; }

        public static IResult Fail()
        {
            return new Result { succeeded = false };
        }

        public static IResult Fail(string message, string message_id)
        {
            return new Result { succeeded = false, message = message, message_Id = message_id };
        }

        public static Task<IResult> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResult> FailAsync(string message, string message_id)
        {
            return Task.FromResult(Fail(message, message_id));
        }

        public static IResult Success()
        {
            return new Result { succeeded = true };
        }

        public static IResult Success(string message, string message_id)
        {
            return new Result { succeeded = true, message = message, message_Id = message_id };
        }

        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResult> SuccessAsync(string message, string message_id)
        {
            return Task.FromResult(Success(message, message_id));
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result()
        {
        }

        public T data { get; set; }

        public DateTime servertime { get; set; } = DateTime.UtcNow;


        public new static Result<T> Fail()
        {
            return new Result<T> { succeeded = false };
        }

        public new static Result<T> Fail(string message, string message_id)
        {
            return new Result<T> { succeeded = false, message = message, message_Id = message_id };
        }

        public new static Task<Result<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public new static Task<Result<T>> FailAsync(string message, string message_id)
        {
            return Task.FromResult(Fail(message, message_id));
        }

        public new static Result<T> Success()
        {
            return new Result<T> { succeeded = true };
        }

        public new static Result<T> Success(string message, string message_id)
        {
            return new Result<T> { succeeded = true, message = message, message_Id = message_id };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T> { succeeded = true, data = data };
        }

        public static Result<T> Success(T data, string message, string message_id)
        {
            return new Result<T> { succeeded = true, data = data, message = message, message_Id = message_id };
        }

        public new static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<Result<T>> SuccessAsync(string message, string message_id)
        {
            return Task.FromResult(Success(message, message_id));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message, string message_id)
        {
            return Task.FromResult(Success(data, message, message_id));
        }
    }
}
