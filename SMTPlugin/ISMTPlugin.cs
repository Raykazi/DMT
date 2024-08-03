namespace SMTPlugin
{
    public interface ISMTPlugin
    {
        string Version { get; }
        string MinimumSMTVersion { get; } 
        string Name { get; }    
        string Description { get; }
        string Author { get; } 
        Uri GitHubLink { get; }
        List<PluginSetting> Settings { get; set; }
    }
    public enum SettingType
    {
        String,
        Int,
        Bool
    }

    public class PluginSetting
    {
        public string Name { get; set; }
        public SettingType Type { get; set; }
        public string Description { get; set; }
        public object Value { get; set; }
    }
}
