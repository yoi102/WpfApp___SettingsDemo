namespace WpfApp___SettingsDemo.Efcore;

public class UserSettings
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string UserSid { get; set; }

    public Setting1 Setting1 { get; set; } = null!;
    public Setting2 Setting2 { get; set; } = null!;


}
