using BlogScript.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Business.Tools.JwtTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
