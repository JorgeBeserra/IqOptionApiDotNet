using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    public class TraderRoom
    {
        public string name { get; set; }
        public int version { get; set; }
    }
    
    internal class UserSettingsModel
    {
        [JsonProperty("configs")] public List<TraderRoom> Configs { get; set; }
    }

    internal sealed class GetUserSettingsRequestMessage : WsSendMessageBase<UserSettingsModel>
    {
        public GetUserSettingsRequestMessage()
        {
            TraderRoom t1 = new TraderRoom() { name = "traderoom_gl", version = 2};
            TraderRoom t2 = new TraderRoom() { name = "traderoom_gl_welcome", version = 1 };
            TraderRoom t3 = new TraderRoom() { name = "traderoom_gl_common", version = 4 };
            TraderRoom t4 = new TraderRoom() { name = "traderoom_gl_trading", version = 4 };
            TraderRoom t5 = new TraderRoom() { name = "traderoom_gl_grid", version = 2 };
            TraderRoom t6 = new TraderRoom() { name = "traderoom_gl_commissions", version = 1 };
            TraderRoom t7 = new TraderRoom() { name = "traderoom_gl_fav_assets", version = 1 };
            TraderRoom t8 = new TraderRoom() { name = "privacy-settings", version = 1 };
            TraderRoom t9 = new TraderRoom() { name = "traderoom_gl_shortcuts", version = 1 };
            TraderRoom t10 = new TraderRoom() { name = "yearly_fee", version = 1 };
            TraderRoom t11 = new TraderRoom() { name = "leaderboard", version = 1 };

            List<TraderRoom> traderRooms = new List<TraderRoom>();
            traderRooms.Add(t1);
            traderRooms.Add(t2);
            traderRooms.Add(t3);
            traderRooms.Add(t4);
            traderRooms.Add(t5);
            traderRooms.Add(t6);
            traderRooms.Add(t7);
            traderRooms.Add(t8);
            traderRooms.Add(t9);
            traderRooms.Add(t10);
            traderRooms.Add(t11);

            Message = new RequestBody<UserSettingsModel>
            {
                RequestBodyType = RequestMessageBodyType.GetUserSettings,
                Version = "2.0",
                Body = new UserSettingsModel
                {
                    Configs = traderRooms        
                }
            };
        }
    }
}