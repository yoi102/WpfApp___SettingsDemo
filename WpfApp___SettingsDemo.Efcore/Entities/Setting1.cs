using System.Reflection.Metadata;

namespace WpfApp___SettingsDemo.Efcore.Entities;

public class Setting1
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public int Setting1_Property { get; set; } = 88;
}
