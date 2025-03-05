using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Threading.Tasks;
using WpfApp___SettingsDemo.Efcore.Services;

namespace WpfApp___SettingsDemo.Efcore;

public class SettingService : ISettingService
{
    private readonly AppDbContext appDbContext;

    public SettingService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;

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

        UserSettings = appDbContext.UserSettings
            .Include(u => u.Setting1)
            .Include(u => u.Setting2)
            .Single(u => u.UserSid == sid);
    }



    public UserSettings UserSettings { get; }

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }




}
