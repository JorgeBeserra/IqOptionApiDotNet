﻿using RestSharp;

namespace IqOptionApiDotNet.Http
{
    public abstract class IqOptionRequest : RestRequest
    {
        protected IqOptionRequest(string action, Method method = Method.GET) : base(action, method)
        {
            AddHeader("Accept", "application/json");
        }
    }
}