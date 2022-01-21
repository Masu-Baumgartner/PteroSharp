using System;

using PteroSharp.ApiModels.Node;
using PteroSharp.Utils;

namespace PteroSharp
{
    public class PteroNode
    {
        #region Backlink to client
        public PteroClient Client { get; private set; }
        #endregion

        public long Id { get; private set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                UpdateData();
            }
        }
        private string _Name { get; set; }
        public Guid Uuid { get; private set; }
        public bool Public { get; private set; }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                UpdateData();
            }
        }
        private string _Description { get; set; }
        public long LocationId
        {
            get
            {
                return _LocationId;
            }
            set
            {
                _LocationId = value;
                UpdateData();
            }
        }
        private long _LocationId { get; set; }
        public string Fqdn
        {
            get
            {
                return _Fqdn;
            }
            set
            {
                _Fqdn = value;
                UpdateData();
            }
        }
        private string _Fqdn { get; set; }
        public string Scheme
        {
            get
            {
                return _Scheme;
            }
            set
            {
                _Scheme = value;
                UpdateData();
            }
        }
        private string _Scheme { get; set; }
        public bool BehindProxy
        {
            get
            {
                return _BehindProxy;
            }
            set
            {
                _BehindProxy = value;
                UpdateData();
            }
        }
        private bool _BehindProxy { get; set; }
        public bool MaintenanceMode
        {
            get
            {
                return _MaintenanceMode;
            }
            set
            {
                _MaintenanceMode = value;
                UpdateData();
            }
        }
        private bool _MaintenanceMode { get; set; }
        public long Memory
        {
            get
            {
                return _Memory;
            }
            set
            {
                _Memory = value;
                UpdateData();
            }
        }
        private long _Memory { get; set; }
        public long MemoryOverallocate
        {
            get
            {
                return _MemoryOverallocate;
            }
            set
            {
                _MemoryOverallocate = value;
                UpdateData();
            }
        }
        private long _MemoryOverallocate { get; set; }
        public long Disk
        {
            get
            {
                return _Disk;
            }
            set
            {
                _Disk = value;
                UpdateData();
            }
        }
        private long _Disk { get; set; }
        public long DiskOverallocate
        {
            get
            {
                return _DiskOverallocate;
            }
            set
            {
                _DiskOverallocate = value;
                UpdateData();
            }
        }
        private long _DiskOverallocate { get; set; }
        public long UploadSize
        {
            get
            {
                return _UploadSize;
            }
            set
            {
                _UploadSize = value;
                UpdateData();
            }
        }
        private long _UploadSize { get; set; }
        public long DaemonListen
        {
            get
            {
                return _DaemonListen;
            }
            set
            {
                _DaemonListen = value;
                UpdateData();
            }
        }
        private long _DaemonListen { get; set; }
        public long DaemonSftp
        {
            get
            {
                return _DaemonSftp;
            }
            set
            {
                _DaemonSftp = value;
                UpdateData();
            }
        }
        private long _DaemonSftp { get; set; }
        public string DaemonBase { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }

        public static PteroNode FromNodeAttributes(NodeAttributes nodeDatum, PteroClient client)
        {
            var result = new PteroNode();

            result.Id = nodeDatum.Id;
            result._Name = nodeDatum.Name;
            result._BehindProxy = nodeDatum.BehindProxy;
            result.CreatedAt = nodeDatum.CreatedAt;
            result.DaemonBase = nodeDatum.DaemonBase;
            result._DaemonListen = nodeDatum.DaemonListen;
            result._DaemonSftp = nodeDatum.DaemonSftp;
            result._Description = nodeDatum.Description;
            result._Disk = nodeDatum.Disk;
            result._DiskOverallocate = nodeDatum.DiskOverallocate;
            result._Fqdn = nodeDatum.Fqdn;
            result._LocationId = nodeDatum.LocationId;
            result._MaintenanceMode = nodeDatum.MaintenanceMode;
            result._Memory = nodeDatum.Memory;
            result._MemoryOverallocate = nodeDatum.MemoryOverallocate;
            result.Public = nodeDatum.Public;
            result._Scheme = nodeDatum.Scheme;
            result.UpdatedAt = nodeDatum.UpdatedAt;
            result._UploadSize = nodeDatum.UploadSize;
            result.Uuid = nodeDatum.Uuid;

            result.Client = client;

            return result;
        }

        private void UpdateData()
        {
            var result = new UpdateNodeRequest();

            result.BehindProxy = _BehindProxy;
            result.DaemonListen = _DaemonListen;
            result.DaemonSftp = _DaemonSftp;
            result.Description = _Description;
            result.Disk = _Disk;
            result.DiskOverallocate = _DiskOverallocate;
            result.Fqdn = _Fqdn;
            result.LocationId = _LocationId;
            result.MaintenanceMode = _MaintenanceMode;
            result.Memory = _Memory;
            result.MemoryOverallocate = _MemoryOverallocate;
            result.Name = _Name;
            result.Scheme = _Scheme;
            result.UploadSize = _UploadSize;

            PterodactylApiHelper.Patch<string>(
                Client.AppPool,
                Client.PterodactylUrl,
                "api/application/nodes/" + Id,
                result,
                out _
                );
        }
    }
}
