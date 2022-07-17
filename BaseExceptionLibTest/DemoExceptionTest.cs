using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using RaGae.ExceptionLib;
using System;
using System.Collections.Generic;
using Xunit;

namespace BaseExceptionLibTest
{
    public class DemoExceptionTest
    {
        private static string testMessage = "TestMessage";

        public static IEnumerable<object[]> GetExceptionType(bool message)
        {
            yield return message ? new object[] {
                ErrorCode.OK,
                testMessage,
                "TILT: Should not be reached!"
            } : new object[]
            {
                ErrorCode.OK,
                "Exception of type 'BaseExceptionLibTest.DemoException' was thrown.",
                "TILT: Should not be reached!"
            };

            yield return message ? new object[] {
                ErrorCode.ERROR,
                testMessage,
                $"There was an error with {testMessage}!"
            } : new object[]
            {
                ErrorCode.ERROR,
                "Exception of type 'BaseExceptionLibTest.DemoException' was thrown.",
                "There was an error with Exception of type 'BaseExceptionLibTest.DemoException' was thrown.!"
            };

            yield return message ? new object[] {
                ErrorCode.TEST,
                testMessage,
                string.Empty
            } : new object[]
            {
                ErrorCode.TEST,
                "Exception of type 'BaseExceptionLibTest.DemoException' was thrown.",
                string.Empty
            };
        }

        [Theory]
        [MemberData(nameof(GetExceptionType), false)]
        public void CreateExceptionWithEmptyConstructor_Passing(ErrorCode code, string message, string errorMessage)
        {
            DemoException ex = new DemoException();

            if (code != ErrorCode.OK)
                ex.ErrorCode = code;

            Assert.Equal(code, ex.ErrorCode);
            Assert.Equal(message, ex.Message);
            Assert.Equal(errorMessage, ex.ErrorMessage());
        }

        [Theory]
        [MemberData(nameof(GetExceptionType), true)]
        public void CreateExceptionWithMessageConstructor_Passing(ErrorCode code, string message, string errorMessage)
        {
            DemoException ex = new DemoException(message);

            if (code != ErrorCode.OK)
                ex.ErrorCode = code;

            Assert.Equal(code, ex.ErrorCode);
            Assert.Equal(message, ex.Message);
            Assert.Equal(errorMessage, ex.ErrorMessage());
        }

        [Theory]
        [MemberData(nameof(GetExceptionType), false)]
        public void CreateExceptionWithErrorCodeConstructor_Passing(ErrorCode code, string message, string errorMessage)
        {
            DemoException ex = new DemoException(code);

            Assert.Equal(code, ex.ErrorCode);
            Assert.Equal(message, ex.Message);
            Assert.Equal(errorMessage, ex.ErrorMessage());
        }

        [Theory]
        [MemberData(nameof(GetExceptionType), true)]
        public void CreateExceptionWithErrorCodeAndMessageConstructor_Passing(ErrorCode code, string message, string errorMessage)
        {
            DemoException ex = new DemoException(code, testMessage);

            Assert.Equal(code, ex.ErrorCode);
            Assert.Equal(message, ex.Message);
            Assert.Equal(errorMessage, ex.ErrorMessage());
        }
    }
}
