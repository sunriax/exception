using RaGae.ExceptionLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseExceptionLibTest
{
    public enum ErrorCode
    {
        OK,
        ERROR,
        TEST
    }

    public class DemoException : BaseException<ErrorCode>
    {
        public DemoException() { }
        public DemoException(string message) : base(message) { }
        public DemoException(ErrorCode errorCode) : base(errorCode) { }
        public DemoException(ErrorCode errorCode, string message) : base(errorCode, message) { }

        public override string ErrorMessage()
        {
            switch (base.ErrorCode)
            {
                case ErrorCode.OK:
                    return "TILT: Should not be reached!";
                case ErrorCode.ERROR:
                    return $"There was an error with {base.Message}!";
                default:
                    return string.Empty;
            }
        }
    }
}
