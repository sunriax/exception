[![Version: 1.0 Release](https://img.shields.io/badge/Version-1.0%20Release-green.svg)](https://github.com/sunriax) [![NuGet](https://img.shields.io/nuget/dt/ragae.exception.svg)](https://www.nuget.org/packages/ragae.exception) [![Build Status](https://www.travis-ci.com/sunriax/exception.svg?branch=main)](https://www.travis-ci.com/sunriax/exception) [![codecov](https://codecov.io/gh/sunriax/exception/branch/main/graph/badge.svg)](https://codecov.io/gh/sunriax/exception) [![License: GPL v3](https://img.shields.io/badge/License-GPL%20v3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

# ExceptionLib

## Description:

Abstract base class for exception handling that provides a generic error code. The library will be used in whole RaGae namespace.

---

## Installation

To install ExceptionLib it is possible to download library [[zip](https://github.com/sunriax/exception/releases/latest/download/Exception.zip) | [gzip](https://github.com/sunriax/exception/releases/latest/download/Exception.tar.gz)] or install it via nuget.

```
PM> Install-Package RaGae.Exception
```

---

## Usage

After adding/installing the ExceptionLib in a project it can be used for personal exception classes. Information how to handle a project with *ExceptionLib* can be found in [Wiki](https://github.com/sunriax/exception/wiki).

``` csharp
using System;
using RaGae.ExceptionLib;

namespace Project
{
    public enum ErrorCode
    {
        OK,
        ERROR,
        TEST
    }

    public class ProjectException : BaseException<ErrorCode>
    {
        public ProjectException(ErrorCode errorCode) : base(errorCode) { }

        public ProjectException(ErrorCode errorCode, string message) : base(errorCode, message) { }

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
```

---

R. GÄCHTER
