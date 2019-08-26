using System.Management.Automation;

namespace Nutanix.Powershell.Models
{
    public partial class NutanixCredential
    {
        //working copy
        public string Server { get; set; }
        public string Port { get; set; }
        public string Protocol { get; set ;}
        protected internal string Username { get; set; }

        public PSCredential PSCredential { get; set; }


        private System.Uri _serverUri;
        public System.Uri Uri {
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

        protected internal System.Security.SecureString Password { set; get; }

        public NutanixCredential(string server, string port, string protocol, string username, string password)
        {
            Server = server ?? "localhost";
            Port = port ?? "9440";
            Protocol = protocol ?? "http";

            var _uri = new System.Uri($"{Protocol}://{Server}:{Port}");
            Uri = _uri;




            Username = username ?? "";
            System.Security.SecureString result = new System.Security.SecureString();
            if (password.Length > 0 ) {
                foreach (char c in password)
                        result.AppendChar(c);
            }
            Password = result;
        }

        public NutanixCredential(string uri, string username, System.Security.SecureString password)
        {
            var _uri = new System.Uri(uri);
            Uri = _uri;// these lines break the code
            Password = password;
            Username = username;
        }

        public NutanixCredential(string uri, PSCredential PSCredential)
        {
            var _uri = new System.Uri(uri);
            Uri = _uri;
            this.PSCredential = PSCredential; 
            Password = PSCredential.Password;
            Username = PSCredential.UserName;
        }

        public NutanixCredential(){}

    }
}