using BlogScript.DataAccess.Concrete.EFCore.Mapping;
using BlogScript.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Context
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-7IJG156;database=BlogScript; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CategoryBlogMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
        }

        /// <summary>
        /// DB AYAGA KALDIRMA ISLEMLERI
        /// DataAccess Katmani set as startup project olarak secilir.
        /// Package Manager Console uzerinden default project dataaccess secilir.
        /// add-migration InitalCreate 
        /// komutu calistirilarak migration olusturulur.
        /// update-database 
        /// komutu calistirilarak degisiklikler veritabanina yuklenir.
        /// </summary>
        /// 
        
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        

    }
}
