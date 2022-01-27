using System;

using PteroSharp.ApiModels.Server;
using PteroSharp.Utils;

namespace PteroSharp
{
    public class PteroServer
    {
        #region Backlink to client
        public PteroClient Client { get; private set; }
        #endregion

        public long Id { get; private set; }
        public string ExternalId { get; private set; }
        public Guid Uuid { get; private set; }
        public string Identifier { get; private set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                UpdateDetails();
            }
        }
        private string _Name { get; set; }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                UpdateDetails();
            }
        }
        private string _Description { get; set; }
        public bool Suspended
        {
            get
            {
                return _Suspended;
            }
            set
            {
                _Suspended = value;
                UpdateSuspended();
            }
        }
        private bool _Suspended { get; set; }
        public Limits Limits
        {
            get
            {
                return _Limits;
            }
            set
            {
                _Limits = value;
                UpdateBuild();
            }
        }
        private Limits _Limits { get; set; }
        public FeatureLimits FeatureLimits
        {
            get
            {
                return _FeatureLimits;
            }
            set
            {
                _FeatureLimits = value;
                UpdateBuild();
            }
        }
        private FeatureLimits _FeatureLimits { get; set; }
        public long User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
                UpdateDetails();
            }
        }
        private long _User { get; set; }
        public long Node { get; set; }
        private long _Node { get; set; }
        public long Allocation
        {
            get
            {
                return _Allocation;
            }
            set
            {
                _Allocation = value;
                UpdateBuild();
            }
        }
        private long _Allocation { get; set; }
        public long Nest { get; set; }
        private long _Nest { get; set; }
        public long Egg { get; set; }
        private long _Egg { get; set; }


        public static PteroServer FromServerAttributes(ServerAttributes attributes, PteroClient client)
        {
            var result = new PteroServer();

            result.Id = attributes.Id;
            result.Identifier = attributes.Identifier;
            result._Limits = attributes.Limits;
            result._FeatureLimits = attributes.FeatureLimits;
            result._Name = attributes.Name;
            result._Nest = attributes.Nest;
            result._Node = attributes.Node;
            result._Suspended = attributes.Suspended;
            result._User = attributes.User;
            result.Uuid = attributes.Uuid;
            result._Allocation = attributes.Allocation;

            result.Client = client;

            return result;
        }

        private void UpdateBuild()
        {
            var request = new UpdateServerBuildRequest()
            {
                Allocation = _Allocation,
                Cpu = _Limits.Cpu,
                Disk = _Limits.Disk,
                FeatureLimits = _FeatureLimits,
                Io = _Limits.Io,
                Memory = _Limits.Memory,
                Swap = _Limits.Swap,
                Threads = _Limits.Threads
            };

            PterodactylApiHelper.Patch(
                Client.AppPool,
                Client.PterodactylUrl,
                "api/application/servers/" + Id + "/build",
                request,
                out _
                );
        }

        private void UpdateDetails()
        {
            var request = new UpdateServerDetailsRequest()
            {
                Description = _Description,
                ExternalId = ExternalId,
                Name = _Name,
                User = _User
            };

            PterodactylApiHelper.Patch(
                Client.AppPool,
                Client.PterodactylUrl,
                "api/application/servers/" + Id + "/details",
                request,
                out _
                );
        }

        private void UpdateSuspended()
        {
            if(_Suspended)
            {
                PterodactylApiHelper.Post(
                    Client.AppPool,
                    Client.PterodactylUrl,
                    "api/application/servers/" + Id + "/suspend",
                    null,
                    out _
                    );
            }
            else
            {
                PterodactylApiHelper.Post(
                    Client.AppPool,
                    Client.PterodactylUrl,
                    "api/application/servers/" + Id + "/unsuspend",
                    null,
                    out _
                    );
            }
        }
    }
}
