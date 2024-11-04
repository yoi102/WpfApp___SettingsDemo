using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp___SettingsDemo.Settings
{
    [SettingFile("123/Setting1",true)]
    internal class Setting1
    {
        public int MyProperty { get; set; } = 456;
    }
}
