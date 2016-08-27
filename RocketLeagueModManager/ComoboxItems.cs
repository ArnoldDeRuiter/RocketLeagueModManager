using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueModManager
{
    public class ModComboboxItems
    {
        public string DirectoryName { get; set; }
        public string DirectoryLocation { get; set; }

        public override string ToString()
        {
            return DirectoryName;
        }
    }
}
