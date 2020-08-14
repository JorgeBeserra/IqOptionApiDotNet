﻿namespace IqOptionApiDotNet.Http
{
    public class GetProfileRequest : IqOptionRequest
    {
        public GetProfileRequest(string requestId) : base("getprofile")
        {
        }
    }
}