using System.Runtime.Serialization;

namespace IqOptionApiDotNet.Models
{
    public enum OrderDirection
    {
        [EnumMember(Value = "put")] Put = 1,

        [EnumMember(Value = "call")] Call = 2
    }
}