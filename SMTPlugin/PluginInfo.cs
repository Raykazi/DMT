using System.ComponentModel;

namespace SMTPlugin
{
    public class PluginInfo : INotifyPropertyChanged
    {
        private int version;
        private int minimumSMTVersion;
        private string name;
        private string description;
        private string author;
        private string gitHubLink;
        private List<PluginSetting> settings;

        public int Version
        {
            get { return version; }
            set { version = value; OnPropertyChanged(nameof(Version)); }
        }

        public int MinimumSMTVersion
        {
            get { return minimumSMTVersion; }
            set { minimumSMTVersion = value; OnPropertyChanged(nameof(MinimumSMTVersion)); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        public string Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged(nameof(Author)); }
        }

        public string GitHubLink
        {
            get { return gitHubLink; }
            set { gitHubLink = value; OnPropertyChanged(nameof(GitHubLink)); }
        }

        public List<PluginSetting> Settings
        {
            get { return settings; }
            set { settings = value; OnPropertyChanged(nameof(Settings)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}