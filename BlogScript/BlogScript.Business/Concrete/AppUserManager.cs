using BlogScript.Business.Abstract;
using BlogScript.DataAccess.Abstract;
using BlogScript.DTOs.DTOs.AppUserDTOs;
using BlogScript.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogScript.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;

        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            return await _genericDal.GetAsync(i => i.UserName == appUserLoginDto.UserName && i.Password == appUserLoginDto.Password);
        }
    }
}
