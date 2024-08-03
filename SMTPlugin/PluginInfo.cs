using System.ComponentModel;

namespace SMTPlugin
{
    public class PluginInfo : INotifyPropertyChanged
    {
        private bool _enabled;
        private string _version;
        private string _minimumSMTVersion;
        private string _name;
        private string _description;
        private string _author;
        private Uri _gitHubLink;
        private List<PluginSetting> _settings;


        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public string MinimumSMTVersion
        {
            get { return _minimumSMTVersion; }
            set { _minimumSMTVersion = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value;  }
        }

        public Uri GitHubLink
        {
            get { return _gitHubLink; }
            set { _gitHubLink = value; }
        }

        public List<PluginSetting> Settings
        {
            get { return _settings; }
            set { _settings = value; OnPropertyChanged(nameof(Settings)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}