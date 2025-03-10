using SqlSugar;

namespace WpfApp___SettingsDemo.SqlSugar.Entities;

public class UserSettings
{
    [SugarColumn(IsPrimaryKey = true)]
    public string UserSid { get; set; } = "";

    public int Setting1Id { get; set; }
    public int Setting2Id { get; set; }

    [Navigate(NavigateType.OneToOne, nameof(Setting1Id))]
    public Setting1 Setting1 { get; set; } = null!;

    [Navigate(NavigateType.OneToOne, nameof(Setting2Id))]
    public Setting2 Setting2 { get; set; } = null!;
}