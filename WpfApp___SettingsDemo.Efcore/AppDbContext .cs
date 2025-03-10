using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Security.Principal;
using WpfApp___SettingsDemo.Efcore.Entities;

namespace WpfApp___SettingsDemo.Efcore;

public class AppDbContext : DbContext
{
    public DbSet<UserSettings> UserSettings { get; set; }
    public DbSet<Setting1> Setting1s { get; set; }
    public DbSet<Setting2> Setting2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //Exe文件夹下的UserSettings.db文件
        var path = Path.Combine($"Data Source={AppDomain.CurrentDomain.BaseDirectory}UserSettings.db");
        options.UseSqlite(path);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserSettings>()
            .HasIndex(u => u.UserSid)  // 指定要唯一的列
            .IsUnique();  // 设置唯一约束

        modelBuilder.Entity<UserSettings>()
                    .HasOne(u => u.Setting1)   // UserSettings 关联一个 Setting1
                    .WithOne()
                    .HasForeignKey<Setting1>(s => s.Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserSettings>()
                    .HasOne(u => u.Setting2)   // UserSettings 关联一个 Setting1
                    .WithOne()
                    .HasForeignKey<Setting2>(s => s.Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
    }

    // ✅ 提供初始化用户的方法   这个方法也可以放在别的地方。
    public void EnsureUserSettingsExists()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        string sid = identity.User?.Value ?? identity.Name; // 获取用户 SID

        if (!UserSettings.Any(u => u.UserSid == sid))
        {
            var userSettings = new UserSettings() { UserSid = sid };

            UserSettings.Add(userSettings);
            SaveChanges();
        }
    }
}