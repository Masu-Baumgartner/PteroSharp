using System;

using PteroSharp.ApiModels.User;
using PteroSharp.Utils;

namespace PteroSharp
{
    public class PteroUser
    {
        #region Backlink to client
        public PteroClient Client { get; private set; }
        #endregion

        public long Id { get; private set; }
        public string ExternalId { get; private set; }
        public Guid Uuid { get; private set; }
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;

                UpdateData();
            }
        }
        private string _Username { get; set; }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;

                UpdateData();
            }
        }
        private string _Email { get; set; }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;

                UpdateData();
            }
        }
        private string _FirstName { get; set; }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;

                UpdateData();
            }
        }
        private string _LastName { get; set; }
        public string Language
        {
            get
            {
                return _Language;
            }
            set
            {
                _Language = value;

                UpdateData();
            }
        }
        private string _Language { get; set; }
        public bool IsAdmin
        {
            get
            {
                return _IsAdmin;
            }
            set
            {
                _IsAdmin = value;

                UpdateData();
            }
        }
        private bool _IsAdmin { get; set; }
        public bool TwoFactor { get; private set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Password
        {
            set
            {
                _Password = value;

                UpdateData();

                _Password = null;
            }
        }
        private string _Password { get; set; } = null;

        public static PteroUser FromUserAttributes(UserAttributes attributes, PteroClient client)
        {
            var result = new PteroUser();

            result.Id = attributes.Id;

            result.CreatedAt = attributes.CreatedAt;
            result._Email = attributes.Email;
            result.ExternalId = attributes.ExternalId;
            result._FirstName = attributes.FirstName;
            result._IsAdmin = attributes.RootAdmin;
            result._Language = attributes.Language;
            result._LastName = attributes.LastName;
            result.TwoFactor = attributes.The2Fa;
            result.UpdatedAt = attributes.UpdatedAt;
            result._Username = attributes.Username;
            result.Uuid = attributes.Uuid;

            result.Client = client;

            return result;
        }

        public void UpdateData()
        {
            var request = new UpdateUserRequest();

            request.Email = _Email;
            request.FirstName = _FirstName;
            request.Language = _Language;
            request.LastName = _LastName;
            request.Password = _Password;
            request.Username = _Username;

            PterodactylApiHelper.Patch<string>(
                    Client.AppPool,
                    Client.PterodactylUrl,
                    "api/application/users/" + Id,
                    request,
                    out _
                );
        }
    }
}
