using BlogScript.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Mapping
{
    public class CategoryBlogMap : IEntityTypeConfiguration<CategoryBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryBlog> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            // Tekrar olmamasi icin her ikisini de unique olarak isaretliyoruz.
            builder.HasIndex(i => new { i.BlogId, i.CategoryId }).IsUnique();
        }
    }
}
