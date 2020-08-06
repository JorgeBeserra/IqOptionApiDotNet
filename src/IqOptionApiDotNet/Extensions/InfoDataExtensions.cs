﻿using System.Collections.Generic;
using System.Linq;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.extensions
{
    public static class InfoDataExtensions
    {
        public static IEnumerable<InfoData> OnlyOpenedInfoData(this IEnumerable<InfoData> This)
        {
            return This.Where(x => x.Win.Equals("equal"));
        }
    }
}