using System.Collections.Generic;
using System.Collections.ObjectModel;

using PteroSharp.ApiModels.Node;
using PteroSharp.ApiModels.User;
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
                var result = new List<PteroUser>();

                var apiResult = PterodactylApiHelper.Get<ListUsersResponse>(
                    AppPool,
                    PterodactylUrl,
                    "api/application/users",
                    null,
                    out _);

                foreach (var user in apiResult.Data)
                {
                    result.Add(PteroUser.FromUserAttributes(user.Attributes, this));
                }

                if (apiResult.Meta.Pagination.CurrentPage != apiResult.Meta.Pagination.TotalPages)
                {
                    for (int i = 2; i <= apiResult.Meta.Pagination.TotalPages; i++)
                    {
                        var apiResult2 = PterodactylApiHelper.Get<ListUsersResponse>(
                            AppPool,
                            PterodactylUrl,
                            $"api/application/users?page={i}",
                            null,
                            out _);

                        foreach (var user in apiResult2.Data)
                        {
                            result.Add(PteroUser.FromUserAttributes(user.Attributes, this));
                        }
                    }
                }

                return result.AsReadOnly();
            }
        }

        public PteroUser FindUserById(int id)
        {

        }

        public ReadOnlyCollection<PteroNode> Nodes
        {
            get
            {
                var result = new List<PteroNode>();

                var apiResult = PterodactylApiHelper.Get<ListNodesResponse>(
                    AppPool,
                    PterodactylUrl,
                    "api/application/nodes",
                    null,
                    out _);

                foreach (var node in apiResult.Data)
                {
                    result.Add(PteroNode.FromNodeAttributes(node.Attributes, this));
                }

                if (apiResult.Meta.Pagination.CurrentPage != apiResult.Meta.Pagination.TotalPages)
                {
                    for (int i = 2; i <= apiResult.Meta.Pagination.TotalPages; i++)
                    {
                        var apiResult2 = PterodactylApiHelper.Get<ListNodesResponse>(
                            AppPool,
                            PterodactylUrl,
                            $"api/application/nodes?page={i}",
                            null,
                            out _);

                        foreach (var node in apiResult2.Data)
                        {
                            result.Add(PteroNode.FromNodeAttributes(node.Attributes, this));
                        }
                    }
                }

                return result.AsReadOnly();
            }
        }

        public long Ping()
        {
            return 0;
        }

        public PteroClient()
        {
            AppPool = new PteroApiKeyPool();
            ClientPool = new PteroApiKeyPool();
        }
    }
}
