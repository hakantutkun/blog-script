using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Business.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost:57175";
        public const string Audience = "https://localhost:44310";
        public const string SecurityKey = "mysecuritykey";
        public const double Expires = 40;
    }
}
