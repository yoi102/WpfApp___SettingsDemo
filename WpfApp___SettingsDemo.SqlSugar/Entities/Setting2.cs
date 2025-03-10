using SqlSugar;

namespace WpfApp___SettingsDemo.SqlSugar.Entities;

public class Setting2
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
    public string Setting2_Property { get; set; } = "Setting2";

}
