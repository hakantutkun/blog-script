using BlogScript.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.Name).HasMaxLength(100).IsRequired();

            // Bire cok iliski -> one to many 
            // Bir kategorinin birden fazla categoryBlog u olmalı
            // Bu islemi kategori ve bloglar arasinda many to many iliski kurmak icin yapıyoruz.
            builder.HasMany(i => i.CategoryBlogs).WithOne(i => i.Category).HasForeignKey(i => i.CategoryId);
        }
    }
}
