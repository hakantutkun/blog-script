using BlogScript.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.AuthorName).HasMaxLength(100).IsRequired();
            builder.Property(i => i.AuthorEmail).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Description).HasMaxLength(400).IsRequired();

            // birden coga ornegi
            builder.HasOne(i => i.ParentComment).WithMany(i => i.SubComments).HasForeignKey(i => i.ParentCommentId);

            // Bu sekilde coktan bire de gidebilirdik.
            // builder.HasMany(i => i.SubComments).WithOne(i => i.ParentComment).HasForeignKey(i => i.ParentCommentId);
        }
    }
}
