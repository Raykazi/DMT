namespace SMTPlugin
{
    public interface ISMTPlugin
    {
        int Version { get; }
        int MinimumSMTVersion { get; } 
        string Name { get; }    
        string Description { get; }
        string Author { get; } 
        string GitHubLink { get; }
        List<PluginSetting> Settings { get; }
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
