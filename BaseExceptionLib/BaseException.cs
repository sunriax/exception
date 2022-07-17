using System;

namespace RaGae.ExceptionLib
{
    public abstract class BaseException<T> : Exception
    {
        public BaseException() { }

        public BaseException(string message) : base(message) { }

        public BaseException(T errorCode)
        {
            this.ErrorCode = errorCode;
        }

        public BaseException(T errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public T ErrorCode { get; set; }

        public abstract string ErrorMessage();
    }
}
