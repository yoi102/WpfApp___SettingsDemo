namespace WpfApp___SettingsDemo
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    internal sealed class SettingFileAttribute : Attribute
    {
        public SettingFileAttribute(string path, bool isRelativePath)
        {
            Path = path;
            IsRelativePath = isRelativePath;
        }

        public bool IsRelativePath { get; }
        public string Path { get; }
    }
}