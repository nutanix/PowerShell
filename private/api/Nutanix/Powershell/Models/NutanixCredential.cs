using System;
using System.Management.Automation;
using System.Security;

namespace Nutanix.Powershell.Models
{
    public partial class NutanixCredential
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Protocol { get; set; }
        public PSCredential PSCredential { get; set; }
        protected internal string Username { get; set; }
        protected internal SecureString Password { set; get; }

        private Uri _serverUri;
        public Uri Uri
        {
            get
            {
                return this._serverUri;
            }
            set
            {
                Port = value.Port.ToString();
                Protocol = value.Scheme;
                Server = value.Host;
                this._serverUri = value;
            }
        }

        //public NutanixCredential(string server, string port, string protocol, string username, string password)
        //{
        //    Server = server ?? "localhost";
        //    Port = port ?? "9440";
        //    Protocol = protocol ?? "http";

        //    var _uri = new Uri($"{Protocol}://{Server}:{Port}");
        //    Uri = _uri;

        //    Username = username ?? "";
        //    SecureString result = new SecureString();
        //    if (password.Length > 0 ) {
        //        foreach (char c in password)
        //                result.AppendChar(c);
        //    }
        //    Password = result;
        //}

        public NutanixCredential(string server, string port, string protocol, PSCredential PSCredential)
        {
            Server = server ?? "localhost";
            Port = port ?? "9440";
            Protocol = protocol ?? "http";

            var _uri = new Uri($"{Protocol}://{Server}:{Port}");
            Uri = _uri;

            Username = PSCredential.UserName ?? "";
            SecureString result = new SecureString();
            if (PSCredential.Password.Length > 0)
            {
                foreach (char c in PSCredential.Password.ToString())
                    result.AppendChar(c);
            }
            Password = result;
        }

        //public NutanixCredential(string uri, string username, SecureString password)
        //{
        //    var _uri = new Uri(uri);
        //    Uri = _uri;
        //    Password = password;
        //    Username = username;
        //}

        public NutanixCredential(string uri, PSCredential PSCredential)
        {
            var _uri = new Uri(uri);
            Uri = _uri;
            Password = PSCredential.Password;
            Username = PSCredential.UserName;
            this.PSCredential = PSCredential;

        }

        public NutanixCredential() { }

    }
}