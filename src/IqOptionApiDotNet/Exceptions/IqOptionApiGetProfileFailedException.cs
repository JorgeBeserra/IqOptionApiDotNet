﻿using System;

namespace IqOptionApiDotNet.Exceptions
{
    public class IqOptionApiGetProfileFailedException : Exception
    {
        public IqOptionApiGetProfileFailedException(object receivedContent) : base(
            $"received incorrect content : {receivedContent}")
        {
        }
    }
}