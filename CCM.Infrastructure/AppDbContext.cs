// Infrastructure/AppDbContext.cs
using CCM.Models;
using Microsoft.EntityFrameworkCore;

namespace CCM.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysOrganization> SysOrganization { get; set; }

        public DbSet<SysRole> SysRole { get; set; }

        public DbSet<SysUserRole> SysUserRole { get; set; }

        public DbSet<SysPermission> SysPermission { get; set; }

        public DbSet<SysMenu> SysMenu { get; set; }

        public DbSet<SysRolePermission> SysRolePermission { get; set; }

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

                entity.Property(e => e.OrgId)
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

            modelBuilder.Entity<SysOrganization>(entity =>
            {
                entity.ToTable("sys_user"); // 正確使用 ToTable

                entity.HasKey(e => e.Uuid); // 設定主鍵
                entity.Property(e => e.Uuid)
                      .HasColumnName("uuid")
                      .IsRequired();

                entity.Property(e => e.OrgName)
                      .HasColumnName("orgname")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.Tel)
                      .HasColumnName("Tel")
                      .IsRequired();

                entity.Property(e => e.Ext)
                      .HasColumnName("ext");

                entity.Property(e => e.GuiNumber).HasColumnName("guinumber")
                      .HasMaxLength(9)
                      .IsRequired();

                entity.Property(e => e.AdminUuid).HasColumnName("admin_uuid");

                entity.Property(e => e.TechUuid).HasColumnName("tech_uuid");

                entity.Property(e => e.AccUuid).HasColumnName("acc_uuid");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.ToTable("sys_role");
                entity.HasKey(e => e.Uuid);
                entity.Property(e => e.Uuid)
                      .HasColumnName("uuid")
                      .IsRequired();
                entity.Property(e => e.RoleName)
                      .HasColumnName("rolename")
                      .HasMaxLength(20)
                      .IsRequired();
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.ToTable("sys_user_role");
                entity.HasKey(e => e.Uuid);
                entity.Property(e => e.Uuid)
                      .HasColumnName("uuid")
                      .IsRequired();
                entity.Property(e => e.UserUuid)
                      .HasColumnName("user_uuid")
                      .IsRequired();
                entity.Property(e => e.RoleUuid)
                      .HasColumnName("role_uuid")
                      .IsRequired();
            });

            modelBuilder.Entity<SysPermission>(entity =>
            {
                entity.ToTable("sys_permission");
                entity.HasKey(e => e.Uuid);
                entity.Property(e => e.Uuid)
                      .HasColumnName("uuid")
                      .IsRequired();
                entity.Property(e => e.PermissionName)
                      .HasColumnName("permission_name")
                      .IsRequired();
                entity.Property(e => e.Description)
                      .HasColumnName("description")
                      .HasMaxLength(20);                      
                entity.Property(e => e.Menu_Uuid)
                      .HasColumnName("menu_uuid")
                      .HasMaxLength(20)
                      .IsRequired();
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("sys_menu");
                entity.HasKey(e => e.Uuid);
                entity.Property(e => e.Uuid)
                      .HasColumnName("uuid")
                      .IsRequired();
                entity.Property(e => e.Name)
                      .HasColumnName("name")
                      .HasMaxLength(20)
                      .IsRequired();
                entity.Property(e => e.Path)
                     .HasColumnName("path")
                     .HasMaxLength(20)
                     .IsRequired();
                entity.Property(e => e.Icon)
                     .HasColumnName("icon")
                     .HasMaxLength(20)
                     .IsRequired();
                entity.Property(e => e.ParentUuid)
                      .HasColumnName("parent_uuid")
                      .IsRequired();
                entity.Property(e => e.Order)
                      .HasColumnName("order_num")
                      .HasMaxLength(20)
                      .IsRequired();
                entity.Property(e => e.Visible)
                      .HasColumnName("visible")
                      .HasMaxLength(20)
                      .IsRequired();
            });

            modelBuilder.Entity<SysRolePermission>(entity =>
            {
                entity.ToTable("sys_role_permission");
                entity.HasKey(e => e.Uuid);
                entity.Property(e => e.Uuid)
                      .HasColumnName("uuid")
                      .IsRequired();
                entity.Property(e => e.RoleUuid)
                      .HasColumnName("role_uuid")
                      .IsRequired();
                entity.Property(e => e.PermissionUuid)
                      .HasColumnName("permission_uuid")
                      .IsRequired();
            });
        }


    }
}
