using SqlSugar;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Principal;
using WpfApp___SettingsDemo.SqlSugar.Entities;

namespace WpfApp___SettingsDemo.SqlSugar.Services;

public class SettingService : ISettingService
{
    public SettingService()
    {
        Init();
    }

    public UserSettings UserSettings { get; private set; }
    private SqlSugarClient db;

    [MemberNotNull(nameof(db))]
    [MemberNotNull(nameof(UserSettings))]
    private void Init()
    {
        var path = $"{AppDomain.CurrentDomain.BaseDirectory}UserSettings.db";
        var connectionString = Path.Combine($"Data Source={path}");

        SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = connectionString,
            DbType = DbType.Sqlite,
            IsAutoCloseConnection = true
        });

        this.db = db;
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        string sid;
        if (identity.User is null)
        {
            sid = identity.Name; // 如果未登录
        }
        else
        {
            sid = identity.User.Value;  // 获取用户 SID
        }

        if (!File.Exists(path))
        {
            db.DbMaintenance.CreateDatabase();
            db.CodeFirst.InitTables<UserSettings>();
            db.CodeFirst.InitTables<Setting1>();
            db.CodeFirst.InitTables<Setting2>();
        }

        var userSettings = db.Queryable<UserSettings>()
                                            .Where(s => s.UserSid == sid)
                                            .Includes(u => u.Setting1)
                                            .Includes(u => u.Setting2);
        if (!userSettings.Any())
        {
            var settings = new UserSettings() { UserSid = sid };
            db.InsertNav(settings)
                .Include(s => s.Setting1)
                .Include(s => s.Setting2)
                .ExecuteCommand();

            UserSettings = db.Queryable<UserSettings>()
                                            .Includes(u => u.Setting1)
                                            .Includes(u => u.Setting2)
                                            .Single(s => s.UserSid == sid);
        }
        else
        {
            UserSettings = userSettings.Single();
        }
    }

    public void Save()
    {
        db.UpdateNav(UserSettings).Include(u => u.Setting1)
                                           .Include(u => u.Setting2)
                                           .ExecuteCommand();
    }
}