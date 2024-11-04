using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp___SettingsDemo.Settings
{
    [SettingFile("123/Setting2", true)]
    internal class Setting2
    {
        public int MyProperty { get; set; } = 123;

    }
}
