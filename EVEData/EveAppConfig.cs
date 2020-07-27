//-----------------------------------------------------------------------
// EVE App Config
//-----------------------------------------------------------------------
using DMT.Helper;
namespace SMT.EVEData
{
    public class EveAppConfig
    {
        //DMTOauth auth = new DMTOauth();
        /// <summary>
        /// Client ID from the EVE Developer setup
        /// </summary>
        public const string ClientID = DMTOauth.ClientID;

        /// <summary>
        /// Secret Key from the EVE Developer setup
        /// </summary>
        public const string SecretKey = DMTOauth.SecretKey;

        /// <summary>
        /// Callback URL for eve
        /// </summary>
        public const string CallbackURL = DMTOauth.CallbackURL;
    }
}
