﻿using BlogScript.Business.Abstract;
using BlogScript.DataAccess.Abstract;
using BlogScript.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;

        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
