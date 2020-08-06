﻿using RestSharp;

namespace IqOptionApiDotNet.Http
{
    public class ChangeBalanceRequest : IqOptionRequest
    {
        public ChangeBalanceRequest(long balanceId) : base("profile/changebalance", Method.POST)
        {
            AddParameter("balance_id", balanceId, ParameterType.QueryString);
        }
    }
}