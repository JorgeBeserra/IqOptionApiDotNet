﻿using RestSharp;

namespace IqOptionApiDotNet.Http
{
    public class ChangeBalanceRequest : IqOptionRequest
    {
        public ChangeBalanceRequest(long balanceId) : base("profile/changebalance", Method.Post)
        {
            var body = new
            {
                balance_id = balanceId
            };
            
            this.AddJsonBody(body);
        }
    }
}