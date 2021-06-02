using BlogScript.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.Title).HasMaxLength(100).IsRequired();
            builder.Property(i => i.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(i => i.Description).HasColumnType("ntext");
            builder.Property(i => i.ImagePath).HasMaxLength(300);

            // Bire cok iliski -> one to many 
            // Bir blog postun birden fazla commenti olmali
            builder.HasMany(i => i.Comments).WithOne(i => i.Blog).HasForeignKey(i => i.BlogId);

            // Bire cok iliski -> one to many 
            // Bir blog postun birden fazla categoryBlog u olmalı
            // Bu islemi kategori ve bloglar arasinda many to many iliski kurmak icin yapıyoruz.
            builder.HasMany(i => i.CategoryBlogs).WithOne(i => i.Blog).HasForeignKey(i => i.BlogId);
        }
    }
}
