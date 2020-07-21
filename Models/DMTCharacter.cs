using SMT.EVEData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Models
{
    public class DMTCharacter
    {
        public bool WarningSystemsNeedsUpdate { get; set; }
        public List<object> ActiveRoute { get; set; }
        public string EsiAccessToken { get; set; }
        public DateTimeOffset EsiAccessTokenExpiry { get; set; }
        public string EsiAuthCode { get; set; }
        public EsiAuthData EsiAuthData { get; set; }
        public bool EsiLinked { get; set; }
        public string EsiRefreshToken { get; set; }
        public FleetInfo FleetInfo { get; set; }
        public string LocalChatFile { get; set; }
        public string Location { get; set; }
        public long NavigationMode { get; set; }
        public string Region { get; set; }
        public Dictionary<string, double> Standings { get; set; }
        public bool UseAnsiblexGates { get; set; }
        public bool DeepSearchEnabled { get; set; }
        public long WarningSystemRange { get; set; }
        public List<string> WarningSystems { get; set; }
        public List<object> Waypoints { get; set; }
        public long AllianceId { get; set; }
        public long CorporationId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public partial class EsiAuthData
    {
        public long AllianceId { get; set; }
        public long CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterOwnerHash { get; set; }
        public long CorporationId { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public long FactionId { get; set; }
        public string RefreshToken { get; set; }
        public string Scopes { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
    }

    public partial class FleetInfo
    {
        public bool IsFleetBoss { get; set; }
        public DateTimeOffset NextFleetMembershipCheck { get; set; }
        public long FleetId { get; set; }
        public string FleetMotd { get; set; }
        public List<object> Members { get; set; }
    }
}
