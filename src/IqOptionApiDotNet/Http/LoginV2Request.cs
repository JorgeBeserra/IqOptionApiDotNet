﻿using IqOptionApiDotNet.Models;
using RestSharp;

namespace IqOptionApiDotNet.Http
{
    public class LoginV2Request : IqOptionRequest
    {
        public LoginV2Request(LoginModel loginModel) : base("login", Method.POST)
        {
            AddParameter("email", loginModel.Email);
            AddParameter("password", loginModel.Password);
        }
    }
}