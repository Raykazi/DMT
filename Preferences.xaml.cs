using SMT.EVEData;
using System.Windows;

namespace SMT
{
    /// <summary>
    /// Interaction logic for PreferencesWindow.xaml
    /// </summary>
    public partial class PreferencesWindow : Window
    {
        public MapConfig MapConf;

        public PreferencesWindow()
        {
            InitializeComponent();
        }

        private void Prefs_OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Prefs_Default_Click(object sender, RoutedEventArgs e)
        {
            if (MapConf != null)
            {
                MapConf.SetDefaults();
            }
        }
        /// <summary>
        /// so you can exit without alt-f4 if you don't have a DMT token, etc.
        /// </summary>
        private void Prefs_Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void syncESIPositionChk_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void zkilltime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            EveManager.Instance.ZKillFeed.KillExpireTimeMinutes = MapConf.ZkillExpireTimeMinutes;

        }
    }
}
