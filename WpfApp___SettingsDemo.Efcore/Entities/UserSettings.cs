namespace WpfApp___SettingsDemo.Efcore.Entities;

public class UserSettings
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string UserSid { get; set; }

    public Setting1 Setting1 { get;private set; } = new();
    public Setting2 Setting2 { get; private set; } = new();


}
