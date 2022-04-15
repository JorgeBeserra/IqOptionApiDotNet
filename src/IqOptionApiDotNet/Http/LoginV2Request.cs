﻿using IqOptionApiDotNet.Models;
using RestSharp;

namespace IqOptionApiDotNet.Http
{
    public class LoginV2Request : IqOptionRequest
    {
        public LoginV2Request(LoginModel loginModel) : base("login", Method.Post)
        {
            this.AddStringBody("identifier" , loginModel.Email);
            this.AddStringBody("password" , loginModel.Password);
        }
    }
}