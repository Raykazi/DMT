using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMT.EVEData;

namespace SMT.Models
{
    public class DMTIntel
    {
        public string Channel { get; set; }
        public DateTime Time { get; set; }
        public string RawIntel { get; set; }
        public string Intel { get; set; }
        public List<string> Systems { get; set; }

        public DMTIntel(string channel, IntelData data)
        {
            Channel = channel;
            Intel = data.IntelString;
            RawIntel = data.RawIntelString;
            Time = data.IntelTime;
            Systems = data.Systems;
        }
    }
}
