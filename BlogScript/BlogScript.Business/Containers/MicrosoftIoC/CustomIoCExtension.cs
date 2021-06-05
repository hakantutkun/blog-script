using BlogScript.Business.Abstract;
using BlogScript.Business.Concrete;
using BlogScript.DataAccess.Abstract;
using BlogScript.DataAccess.Concrete.EFCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();
        }
    }
}
