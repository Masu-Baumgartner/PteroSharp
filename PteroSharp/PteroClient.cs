using System.Collections.Generic;
using System.Collections.ObjectModel;

using PteroSharp.Utils;

namespace PteroSharp
{
    public class PteroClient
    {
        public string PterodactylUrl { get; set; }
        public PteroApiKeyPool AppPool { get; set; }
        public PteroApiKeyPool ClientPool { get; set; }

        public ReadOnlyCollection<PteroServer> Servers
        {
            get
            {
                return new List<PteroServer>().AsReadOnly();
            }
        }

        public ReadOnlyCollection<PteroUser> Users
        {
            get
            {
                return new List<PteroUser>().AsReadOnly();
            }
        }

        public ReadOnlyCollection<PteroNode> Nodes
        {
            get
            {
                return new List<PteroNode>().AsReadOnly();
            }
        }

        public long Ping()
        {
            return 0;
        }
    }
}
