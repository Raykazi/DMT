using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace SMT
{
    public class JumpCharacterItemsSource : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection sizes = new ItemCollection();
            sizes.Add("");

            foreach (EVEData.LocalCharacter c in EVEData.EveManager.Instance.LocalCharacters)
            {
                sizes.Add(c.Name);
            }
            return sizes;
        }
    }

    public class MapConfig : INotifyPropertyChanged
    {
        [Browsable(false)]
        public MapColours ActiveColourScheme;

        [Category("Navigation")]
        public ObservableCollection<StaticJumpOverlay> StaticJumpPoints;

        private bool m_AlwaysOnTop;
        
        private string m_DefaultRegion;

        private double m_IntelTextSize = 10;

        private bool m_JumpRangeInAsOutline;

        private int m_MaxIntelSeconds;

        private bool m_ShowCoalition;

        private bool m_ShowDangerZone = true;

        private bool m_ShowIhubVunerabilities;

        private bool m_ShowNegativeRattingDelta;

        private bool m_ShowRattingDataAsDelta;

        private bool m_ShowSimpleSecurityView;

        private bool m_ShowRegionStandings;

        private bool m_ShowTCUVunerabilities;

        private bool m_ShowToolBox = true;

        private bool m_ShowTrueSec;

        private bool m_ShowUniverseKills;

        private bool m_ShowUniversePods;

        private bool m_ShowUniverseRats;

        private bool m_ShowZKillData;

        private bool m_SOVBasedonTCU;

        private bool m_SOVShowConflicts;

        private bool m_ShowJoveObservatories;

        private double m_UniverseDataScale = 1.0f;

        private float m_UniverseMaxZoomDisplaySystems;

        private float m_UniverseMaxZoomDisplaySystemsText;

        private int m_UpcomingSovMinutes;

        private int m_WarningRange = 4;

        private int m_FleetMaxMembersPerSystem = 5;

        private bool m_ShowCharacterNamesOnMap = true;

        private bool m_FleetShowOnMap = true;

        private bool m_FleetShowShipType = false;

        private bool m_SubscribeAllIntell = false;
        private bool m_ShowDMTCharactersOnMap = true;
        private bool m_DisableJumpBridgesPathAnimation;
        private bool m_DisableRoutePathAnimation;
        private bool m_SubscribeToAllaince;
        private bool m_SubscribeToCorp;
        private string m_IntelChannels;
        private bool m_SyncActiveCharacterBasedOnActiveEVEClient;
        private string DMTToken;
        private string DMTUrl;
        private bool m_ShowOnlinePlayers { get; set; }
        private bool m_AutoSyncJB;

        public MapConfig()
        {
            SetDefaults();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [Category("General")]
        [DisplayName("Always on top")]
        public bool AlwaysOnTop
        {
            get => m_AlwaysOnTop;
            set
            {
                m_AlwaysOnTop = value;
                OnPropertyChanged("AlwaysOnTop");
            }
        }


        [Browsable(false)]
        public string DefaultColourSchemeName { get; set; }

        [Browsable(false)]
        public string DefaultRegion
        {
            get => m_DefaultRegion;
            set
            {
                m_DefaultRegion = value;
                OnPropertyChanged("DefaultRegion");
            }
        }

        [Category("Intel")]
        [DisplayName("Text Size")]
        public double IntelTextSize
        {
            get => m_IntelTextSize;
            set
            {
                if (value > 20)
                {
                    m_IntelTextSize = 20;
                }
                else
                {
                    m_IntelTextSize = value;
                }

                if (value < 8)
                {
                    m_IntelTextSize = 8;
                }
                else
                {
                    m_IntelTextSize = value;
                }

                OnPropertyChanged("IntelTextSize");
            }
        }

        [Category("Navigation")]
        [DisplayName("Jump Range as Outline")]
        public bool JumpRangeInAsOutline
        {
            get => m_JumpRangeInAsOutline;
            set
            {
                m_JumpRangeInAsOutline = value;
                OnPropertyChanged("JumpRangeInAsOutline");
            }
        }

        [Category("Navigation")]
        [DisplayName("Ship Type")]
        public EVEData.EveManager.JumpShip JumpShipType { get; set; }

        [Category("Intel")]
        [DisplayName("Max Intel Time (s)")]
        public int MaxIntelSeconds
        {
            get => m_MaxIntelSeconds;
            set
            {
                // clamp to 30s miniumum
                if (value > 30)
                {
                    m_MaxIntelSeconds = value;
                }
                else
                {
                    m_MaxIntelSeconds = 30;
                }
            }
        }

        [Category("Intel")]
        [DisplayName("Warning Sound")]
        public bool PlayIntelSound { get; set; }

        [Category("Intel")]
        [DisplayName("Warning On Unknown")]
        public bool PlayIntelSoundOnUnknown { get; set; }

        [Category("Intel")]
        [DisplayName("Limit Sound to Dangerzone")]
        public bool PlaySoundOnlyInDangerZone { get; set; }

        [Category("Intel")]
        [DisplayName("Subscribe To All Intel Channels")]
        public bool SubscribeToAllIntel
        {
            get => m_SubscribeAllIntell;
            set
            {
                m_SubscribeAllIntell = value;
                OnPropertyChanged("SubscribeToAllIntel");

            }
        }

        [Category("Intel")]
        [DisplayName("Subscribe To Corp")]
        public bool SubscribeToCorp
        {
            get => m_SubscribeToCorp;
            set
            {
                m_SubscribeToCorp = value;
                OnPropertyChanged("SubscribeToCorp");
            }
        }

        [Category("Intel")]
        [DisplayName("Subscribe To Alliance")]
        public bool SubscribeToAlliance
        {
            get => m_SubscribeToAllaince;
            set
            {
                m_SubscribeToAllaince = value;
                OnPropertyChanged("SubscribeToAlliance");
            }
        }
        [Category("Intel")]
        [DisplayName("Intel Channels")]
        public string IntelChannels
        {
            get => m_IntelChannels;
            set => m_IntelChannels = value;
        }
        [Category("DMT")]
        [DisplayName("DMT URL")]
        public string Url
        {
            get => DMTUrl;
            set => DMTUrl = value;
        }
        [Category("DMT")]
        [DisplayName("DMT Token")]
        public string Token
        {
            get => DMTToken;
            set => DMTToken = value;
        }
        [Category("DMT")]
        [DisplayName("Show Online Players")]
        public bool ShowOnlinePlayers
        {
            get => m_ShowOnlinePlayers;
            set => m_ShowOnlinePlayers = value;
        }

        [Category("Incursions")]
        [DisplayName("Show Active Incursions")]
        public bool ShowActiveIncursions { get; set; }


        [Category("SOV")]
        [DisplayName("Show Coalition")]
        public bool ShowCoalition
        {
            get => m_ShowCoalition;

            set
            {
                m_ShowCoalition = value;
                OnPropertyChanged("ShowCoalition");
            }
        }

        [Category("Navigation")]
        [DisplayName("Show Cyno Beacons")]
        public bool ShowCynoBeacons { get; set; }

        [Category("Intel")]
        [DisplayName("Show DangerZone")]
        public bool ShowDangerZone
        {
            get => m_ShowDangerZone;
            set
            {
                m_ShowDangerZone = value;
                OnPropertyChanged("ShowDangerZone");
            }
        }
        [Category("SOV")]
        [DisplayName("Auto Sync JBs")]
        public bool AutoSyncJB
        {
            get => m_AutoSyncJB;
            set
            {
                m_AutoSyncJB = value;
                OnPropertyChanged("AutoSyncJBs");
            }
        }

        [Category("SOV")]
        [DisplayName("Show IHUB Timers")]
        public bool ShowIhubVunerabilities
        {
            get => m_ShowIhubVunerabilities;

            set
            {
                m_ShowIhubVunerabilities = value;
                m_ShowTCUVunerabilities = !m_ShowIhubVunerabilities;

                OnPropertyChanged("ShowIhubVunerabilities");
                OnPropertyChanged("ShowTCUVunerabilities");
            }
        }

        [Category("Jove")]
        [DisplayName("Show Observatories")]
        public bool ShowJoveObservatories
        {
            get => m_ShowJoveObservatories;
            set
            {
                m_ShowJoveObservatories = value;
                OnPropertyChanged("ShowJoveObservatories");
            }
        }

        [Category("Misc")]
        [DisplayName("Show Negative Ratting Delta")]
        public bool ShowNegativeRattingDelta
        {
            get => m_ShowNegativeRattingDelta;
            set
            {
                m_ShowNegativeRattingDelta = value;
                OnPropertyChanged("ShowNegativeRattingDelta");
            }
        }

        [Category("Misc")]
        [DisplayName("Show Ratting Data as Delta")]
        public bool ShowRattingDataAsDelta
        {
            get => m_ShowRattingDataAsDelta;
            set
            {
                m_ShowRattingDataAsDelta = value;
                OnPropertyChanged("ShowRattingDataAsDelta");
            }
        }

        [Category("Misc")]
        [DisplayName("Simple Security View")]
        public bool ShowSimpleSecurityView
        {
            get => m_ShowSimpleSecurityView;
            set
            {
                m_ShowSimpleSecurityView = value;
                OnPropertyChanged("ShowSimpleSecurityView");
            }
        }


        [Category("Regions")]
        [DisplayName("Show RegionStandings")]
        public bool ShowRegionStandings
        {
            get => m_ShowRegionStandings;

            set
            {
                m_ShowRegionStandings = value;

                if (m_ShowRegionStandings)
                {
                    ShowUniverseRats = false;
                    ShowUniversePods = false;
                    ShowUniverseKills = false;
                }

                OnPropertyChanged("ShowRegionStandings");
            }
        }

        [Category("General")]
        [DisplayName("System Popup")]
        public bool ShowSystemPopup { get; set; }

        [Category("SOV")]
        [DisplayName("Show TCU Timers")]
        public bool ShowTCUVunerabilities
        {
            get => m_ShowTCUVunerabilities;

            set
            {

                m_ShowTCUVunerabilities = value;
                m_ShowIhubVunerabilities = !m_ShowTCUVunerabilities;

                OnPropertyChanged("ShowIhubVunerabilities");
                OnPropertyChanged("ShowTCUVunerabilities");
            }
        }

        [Category("General")]
        [DisplayName("Show Toolbox")]
        public bool ShowToolBox
        {
            get => m_ShowToolBox;
            set
            {
                m_ShowToolBox = value;
                OnPropertyChanged("ShowToolBox");
            }
        }

        [Category("General")]
        [DisplayName("Show TrueSec")]
        public bool ShowTrueSec
        {
            get => m_ShowTrueSec;
            set
            {
                m_ShowTrueSec = value;
                OnPropertyChanged("ShowTrueSec");
            }
        }

        [XmlIgnore]
        [Category("Regions")]
        [DisplayName("Show Ship kill Stats")]
        public bool ShowUniverseKills
        {
            get => m_ShowUniverseKills;

            set
            {
                m_ShowUniverseKills = value;

                if (m_ShowUniverseKills)
                {
                    ShowRegionStandings = false;
                    ShowUniverseRats = false;
                    ShowUniversePods = false;
                }

                OnPropertyChanged("ShowUniverseKills");
            }
        }

        [XmlIgnore]
        [Category("Regions")]
        [DisplayName("Show Pod kill Stats")]
        public bool ShowUniversePods
        {
            get => m_ShowUniversePods;

            set
            {
                m_ShowUniversePods = value;
                if (ShowUniversePods)
                {
                    ShowRegionStandings = false;
                    ShowUniverseRats = false;
                    ShowUniverseKills = false;
                }

                OnPropertyChanged("ShowUniversePods");
            }
        }

        [XmlIgnore]
        [Category("Regions")]
        [DisplayName("Show Ratting Stats")]
        public bool ShowUniverseRats
        {
            get => m_ShowUniverseRats;

            set
            {
                m_ShowUniverseRats = value;
                if (m_ShowUniverseRats)
                {
                    ShowRegionStandings = false;
                    ShowUniversePods = false;
                    ShowUniverseKills = false;
                }

                OnPropertyChanged("ShowUniverseRats");
            }
        }

        [Category("General")]
        [DisplayName("Show ZKillData")]
        public bool ShowZKillData
        {
            get => m_ShowZKillData;
            set
            {
                m_ShowZKillData = value;
                OnPropertyChanged("ShowZKillData");
            }
        }

        [Category("SOV")]
        [DisplayName("Show Sov Based on TCU")]
        public bool SOVBasedITCU
        {
            get => m_SOVBasedonTCU;
            set
            {
                m_SOVBasedonTCU = value;
                OnPropertyChanged("SOVBasedITCU");
            }
        }

        [Category("SOV")]
        [DisplayName("Show Sov Conflicts")]
        public bool SOVShowConflicts
        {
            get => m_SOVShowConflicts;
            set
            {
                m_SOVShowConflicts = value;
                OnPropertyChanged("SOVShowConflicts");
            }
        }

        [XmlIgnore]
        [Category("Regions")]
        [DisplayName("Universe Data Scale")]
        public double UniverseDataScale
        {
            get => m_UniverseDataScale;

            set
            {
                m_UniverseDataScale = value;

                if (m_UniverseDataScale < 0.01)
                {
                    m_UniverseDataScale = 0.01;
                }

                OnPropertyChanged("UniverseDataScale");
            }
        }

        [Category("Universe View")]
        [DisplayName("Systems Max Zoom")]
        public float UniverseMaxZoomDisplaySystems
        {
            get => m_UniverseMaxZoomDisplaySystems;

            set
            {
                m_UniverseMaxZoomDisplaySystems = Math.Min(Math.Max(value, 0.5f), 10.0f);
                OnPropertyChanged("UniverseMaxZoomDisplaySystems");
            }
        }

        [Category("Universe View")]
        [DisplayName("Systems Text Max Zoom")]
        public float UniverseMaxZoomDisplaySystemsText
        {
            get => m_UniverseMaxZoomDisplaySystemsText;

            set
            {
                m_UniverseMaxZoomDisplaySystemsText = Math.Min(Math.Max(value, 0.5f), 10.0f);
                OnPropertyChanged("UniverseMaxZoomDisplaySystemsText");
            }
        }

        [Category("SOV")]
        [DisplayName("Upcoming Period (Mins)")]
        public int UpcomingSovMinutes
        {
            get => m_UpcomingSovMinutes;

            set
            {
                m_UpcomingSovMinutes = value;
                if (m_UpcomingSovMinutes < 5)
                {
                    m_UpcomingSovMinutes = 5;
                }

                OnPropertyChanged("UpcomingSovMinutes");
            }
        }

        [Category("Intel")]
        [DisplayName("Warning Range")]
        public int WarningRange
        {
            get => m_WarningRange;
            set
            {
                // clamp to 1 miniumum
                if (value > 0)
                {
                    m_WarningRange = value;
                }
                else
                {
                    m_WarningRange = 1;
                }

                if (value < 10)
                {
                    m_WarningRange = value;
                }
                else
                {
                    m_WarningRange = 9;
                }

                OnPropertyChanged("WarningRange");
            }
        }

        [Category("Fleet")]
        [DisplayName("Show On Map")]
        public bool FleetShowOnMap
        {
            get => m_FleetShowOnMap;
            set
            {
                m_FleetShowOnMap = value;
                OnPropertyChanged("FleetShowOnMap");
            }
        }

        [Category("Fleet")]
        [DisplayName("Show Ship Type")]
        public bool FleetShowShipType
        {
            get => m_FleetShowShipType;
            set
            {
                m_FleetShowShipType = value;
                OnPropertyChanged("FleetShowShipType");
            }
        }

        [Category("Fleet")]
        [DisplayName("Max Fleet Per System")]
        public int FleetMaxMembersPerSystem
        {
            get => m_FleetMaxMembersPerSystem;
            set
            {
                // clamp to 1 miniumum
                if (value > 0)
                {
                    m_FleetMaxMembersPerSystem = value;
                }
                else
                {
                    m_FleetMaxMembersPerSystem = 1;
                }



                OnPropertyChanged("FleetMaxMembersPerSystem");
            }
        }



        public bool UseESIForCharacterPositions { get; set; }

        public bool ShowCharacterNamesOnMap 
        { 
            get => m_ShowCharacterNamesOnMap;
            set
            {
                m_ShowCharacterNamesOnMap = value;
                OnPropertyChanged("ShowCharacterNamesOnMap");
            }

        }
        public bool ShowDMTCharactersOnMap
        {
            get => m_ShowDMTCharactersOnMap;
            set
            {
                m_ShowDMTCharactersOnMap = value;
                OnPropertyChanged("ShowDMTCharactersOnMap");
            }

        }
        
        public bool SyncActiveCharacterBasedOnActiveEVEClient
        {
            get => m_SyncActiveCharacterBasedOnActiveEVEClient;
            set
            {
                m_SyncActiveCharacterBasedOnActiveEVEClient = value;
                OnPropertyChanged("SyncActiveCharacterBasedOnActiveEVEClient");
            }
        }

        public bool DisableJumpBridgesPathAnimation
        {
            get => m_DisableJumpBridgesPathAnimation;
            set
            {
                m_DisableJumpBridgesPathAnimation = value;
                OnPropertyChanged("DisableJumpBridgesPathAnimation");
            }
        }
        
        public bool DisableRoutePathAnimation
        {
            get => m_DisableRoutePathAnimation;
            set
            {
                m_DisableRoutePathAnimation = value;
                OnPropertyChanged("DisableRoutePathAnimation");
            }
        }


        public void SetDefaultColours()
        {
            MapColours defaultColours = new MapColours
            {
                Name = "Default",
                UserEditable = false,
                FriendlyJumpBridgeColour = Colors.Gray,
                DisabledJumpBridgeColour = Color.FromRgb(205, 55, 50),
                SystemOutlineColour = Color.FromRgb(0, 0, 0),
                InRegionSystemColour = Color.FromRgb(255, 239, 213),
                InRegionSystemTextColour = Color.FromRgb(0, 0, 0),
                OutRegionSystemColour = Color.FromRgb(218, 165, 32),
                OutRegionSystemTextColour = Color.FromRgb(0, 0, 0),

                PopupText = Color.FromRgb(0, 0, 0),
                PopupBackground = (Color)ColorConverter.ConvertFromString("#FF959595"),

                MapBackgroundColour = (Color)ColorConverter.ConvertFromString("#FF4E5B68"),
                RegionMarkerTextColour = (Color)ColorConverter.ConvertFromString("#6E716E"),
                RegionMarkerTextColourFull = Color.FromRgb(0, 0, 0),
                ESIOverlayColour = Color.FromRgb(188, 143, 143),
                IntelOverlayColour = Color.FromRgb(178, 34, 34),
                IntelClearOverlayColour = Colors.Orange,

                NormalGateColour = Color.FromRgb(255, 248, 220),
                ConstellationGateColour = Color.FromRgb(128, 128, 128),
                SelectedSystemColour = Color.FromRgb(255, 255, 255),
                CharacterHighlightColour = Color.FromRgb(170, 130, 180),
                CharacterTextColour = Color.FromRgb(240, 190, 10),
                CharacterTextSize = 11,
                SystemTextSize = 12,

                FleetMemberTextColour = Colors.White,

                JumpRangeInColour = Color.FromRgb(255, 165, 0),
                JumpRangeInColourHighlight = Color.FromArgb(156, 82, 135, 155),
                JumpRangeOverlapHighlight = Colors.DarkBlue,

                ActiveIncursionColour = Color.FromRgb(110, 82, 77),

                SOVStructureVunerableColour = Color.FromRgb(64, 64, 64),
                SOVStructureVunerableSoonColour = Color.FromRgb(178, 178, 178),


                ConstellationHighlightColour = Color.FromRgb(147, 131, 131),

                TheraEntranceRegion = Colors.YellowGreen,
                TheraEntranceSystem = Colors.YellowGreen,

                ZKillDataOverlay = Colors.Purple
            };

            ActiveColourScheme = defaultColours;
        }

        public void SetDefaults()
        {
            DefaultRegion = "Impass";
            ShowSystemPopup = true;
            MaxIntelSeconds = 200;
            UpcomingSovMinutes = 30;
            AlwaysOnTop = false;
            ShowToolBox = true;
            ShowZKillData = true;
            ShowTrueSec = true;
            JumpRangeInAsOutline = true;
            ShowActiveIncursions = true;
            StaticJumpPoints = new ObservableCollection<StaticJumpOverlay>();
            SOVShowConflicts = true;
            SOVBasedITCU = true;
            UseESIForCharacterPositions = true;
            ShowCharacterNamesOnMap = true;
            ShowDMTCharactersOnMap = true;
            ShowIhubVunerabilities = true;
            PlaySoundOnlyInDangerZone = true;
            PlayIntelSoundOnUnknown = false;
            PlayIntelSound = true;

            ShowJoveObservatories = true;

            UniverseMaxZoomDisplaySystems = 1.3f;
            UniverseMaxZoomDisplaySystemsText = 2.0f;

            WarningRange = 4;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
