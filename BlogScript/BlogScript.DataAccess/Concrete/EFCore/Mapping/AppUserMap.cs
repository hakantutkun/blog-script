using BlogScript.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.UserName).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Password).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Email).HasMaxLength(100);
            builder.Property(i => i.Name).HasMaxLength(100);
            builder.Property(i => i.Surname).HasMaxLength(100);
            
            // Bire cok iliski -> one to many 
            // Bir kullanicinin birden fazla blog postu olmali
            builder.HasMany(i => i.Blogs).WithOne(i => i.AppUser).HasForeignKey(i => i.AppUserId);
        }
    }
}
