﻿using RestSharp;

namespace IqOptionApiDotNet.Http
{
    public abstract class IqOptionRequest : RestRequest
    {
        protected IqOptionRequest(string action, Method method = Method.Get) : base(action, method)
        {
            this.AddHeader("Accept", "application/json");
        }
    }
}