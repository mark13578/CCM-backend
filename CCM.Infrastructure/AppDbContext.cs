// Infrastructure/AppDbContext.cs
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SysUser> SysUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("sys_user"); // 正確使用 ToTable

                entity.HasKey(e => e.Uuid); // 設定主鍵
                entity.Property(e => e.Uuid)
                      .HasColumnName("uuid")
                      .IsRequired();

                entity.Property(e => e.Username)
                      .HasColumnName("username")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.Password)
                      .HasColumnName("password")
                      .HasMaxLength(60)
                      .IsRequired();

                entity.Property(e => e.GoogleUid)
                      .HasColumnName("googleuid");

                entity.Property(e => e.RealName)
                     .HasColumnName("realname")
                     .IsRequired();

                entity.Property(e => e.NickName)
                      .HasColumnName("nickname")
                      .HasMaxLength(20);


                entity.Property(e => e.IdNumber)
                      .HasColumnName("idnumber")
                      .IsRequired();

                entity.Property(e => e.docfile1)
                      .HasColumnName("docfile1");

                entity.Property(e => e.docfile2)
                     .HasColumnName("docfile2");


                entity.Property(e => e.docfile2type)
                      .HasColumnName("docfile2type")
                      .HasMaxLength(20);


                entity.Property(e => e.Phone)
                      .HasColumnName("phone")
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(e => e.Country)
                        .HasColumnName("country");


                entity.Property(e => e.State)
                         .HasColumnName("state");


                entity.Property(e => e.District)
                      .HasColumnName("district")
                      .HasMaxLength(20);


                entity.Property(e => e.Address)
                      .HasColumnName("address")
                      .HasMaxLength(60);


                entity.Property(e => e.ZipCode)
                      .HasColumnName("zipcode");

                entity.Property(e => e.Email)
                      .HasColumnName("email")
                      .HasMaxLength(60)
                      .IsRequired();

                entity.Property(e => e.orgid)
                        .HasColumnName("orgid")
                        .IsRequired();

                entity.Property(e => e.pve_token)
                      .HasColumnName("pve_token");

                entity.Property(e => e.CreateTime)
                        .HasColumnName("create_time")
                        .IsRequired();

                entity.Property(e => e.ModifyTime)
                         .HasColumnName("modify_time")
                         .IsRequired();
                entity.Property(e => e.lastotp)
                        .HasColumnName("lastotp");
                entity.Property(e => e.verifycode)
                        .HasColumnName("verifycode");
                entity.Property(e => e.isverified)
                        .HasColumnName("isverified");
                entity.Property(e => e.verifyexp_time)
                        .HasColumnName("verifyexp_time");
            });
        }
    }
}
