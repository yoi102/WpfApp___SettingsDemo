using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;

namespace WpfApp___SettingsDemo.Services
{
    internal class SettingService : ISettingService
    {
        private readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
            DateParseHandling = DateParseHandling.DateTime
        };

        private Dictionary<Type, object> settings = new Dictionary<Type, object>();

        public TSettingType GetSetting<TSettingType>() where TSettingType : class
        {
            if (!settings.ContainsKey(typeof(TSettingType)))
            {
                throw new InvalidOperationException("没有注册这个喂！！！！");
            }
            return (TSettingType)settings[typeof(TSettingType)];
        }

        public void ReadSettingFileOrCreate<TSettingType>(string path) where TSettingType : class, new()
        {
            if (!Path.IsPathFullyQualified(path))
            {
                throw new FileNotFoundException("Path不正确欸！！！！！！！！");
            }
            if (!File.Exists(path))
            {
                var instance = Activator.CreateInstance(typeof(TSettingType));
                if (instance == null)
                    throw new FileNotFoundException("创建失败了！！");

                settings[typeof(TSettingType)] = instance;
                return;
            }

            var setting = FileToInstanceOrCreate(path, typeof(TSettingType));

            settings[typeof(TSettingType)] = setting;
        }

        public void ReadSettingFileOrCreate(string path, Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new InvalidOperationException("类型必须要有无参构造器欸~！~");
            }

            if (!Path.IsPathFullyQualified(path))
            {
                throw new FileNotFoundException("Path不正确欸！！！！！！！！");
            }
            if (!File.Exists(path))
            {
                var instance = Activator.CreateInstance(type);
                if (instance == null)
                    throw new FileNotFoundException("创建失败了！！");

                settings[type] = instance;
                return;
            }

            var setting = FileToInstanceOrCreate(path, type);

            if (setting?.GetType() != type)
            {
                throw new ArgumentException("吊毛、反序列化失败了喂！！！");
            }
            settings[type] = setting;
        }

        public void SaveAllSetting()
        {
            foreach (var item in settings.Values)
            {
                SaveToFile(item);
            }
        }

        public void SaveSettings<TSettingType>() where TSettingType : class
        {
            if (!settings.ContainsKey(typeof(TSettingType)))
            {
                throw new ArgumentException("没注册这个啊！！！！");
            }
            var setting = settings[typeof(TSettingType)];

            SaveToFile(setting);
        }

        private object FileToInstanceOrCreate(string path, Type type)
        {
            var serializer = JsonSerializer.Create(jsonSerializerSettings);

            using var reader = new JsonTextReader(new StringReader(File.ReadAllText(path)));

            var setting = serializer.Deserialize(reader, type);

            if (setting == null)
            {
                throw new ArgumentException("吊毛、反序列化失败了喂！！！");
            }

            return setting;
        }

        private void SaveSetting(string path, object instance)
        {
            var serializer = JsonSerializer.Create(jsonSerializerSettings);

            using (StreamWriter sw = new StreamWriter(path))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, instance);
                }
            }
        }

        private void SaveToFile(object item)
        {
            var settingFileAttribute = item.GetType().GetCustomAttributes(typeof(SettingFileAttribute), true).FirstOrDefault();
            if (settingFileAttribute is not SettingFileAttribute setting)
                throw new ArgumentException("没注册这个啊！！！！");
            string path;
            if (setting.IsRelativePath)
            {
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, setting.Path);
            }
            else
            {
                path = setting.Path;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            SaveSetting(path, item);
        }
    }
}