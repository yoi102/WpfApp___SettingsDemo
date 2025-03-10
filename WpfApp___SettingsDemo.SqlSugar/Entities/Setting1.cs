using SqlSugar;

namespace WpfApp___SettingsDemo.SqlSugar.Entities;

public class Setting1
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    public int Setting1_Property { get; set; } = 88;
}
