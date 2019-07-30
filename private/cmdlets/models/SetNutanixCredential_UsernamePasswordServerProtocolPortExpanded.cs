
namespace Nutanix.Powershell.ModelCmdlets
{
    using System.Management.Automation;
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="Disk" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.Set, @"NutanixCredential_UsernamePasswordServerProtocolPortExpanded")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.NutanixCredential))]
    public class SetNutanixCredential_UsernamePasswordServerProtocolPortExpanded : System.Management.Automation.PSCmdlet
    {
      
        private string _server;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string Server
        {
            set
            {
                _server = value;
            }
            get 
            {
                return _server;
            }
        }

        private string _port;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string Port
        {
            set
            {
                _port = value;
            }
            get 
            {
                return _port;
            }
        }

        private string _protocol;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string Protocol
        {
            set
            {
                _protocol = value;
            }
            get
            {
                return _protocol;
            }
        }

        //private string _username;
        ///// <summary>HELP MESSAGE MISSING</summary>
        //[System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        //public string Username
        //{
        //    set
        //    {
        //       _username = value;
        //    }
        //    get
        //    {
        //        return _username;
        //    }
        //} 

        //private string _password;
        ///// <summary>HELP MESSAGE MISSING</summary>
        //[System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        //public string Password
        //{
        //    set
        //    {
        //        _password = value;
        //    }
        //    get
        //    {
        //        return _password;
        //    }
        //}

        private PSCredential _PSCredential;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public PSCredential PSCredential
        {
            set
            {
                _PSCredential = value;
            }
            get
            {
                return _PSCredential;
            }
        }


        private bool _skip_ssl;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Skip the ssl validation")]
        public System.Management.Automation.SwitchParameter SkipSSL { get; set; }

        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {

            System.Environment.SetEnvironmentVariable("NutanixPort", Port);
            System.Environment.SetEnvironmentVariable("NutanixServer", Server);
            System.Environment.SetEnvironmentVariable("NutanixProtocol", Protocol);
            //System.Environment.SetEnvironmentVariable("NutanixUsername", Username);
            //System.Environment.SetEnvironmentVariable("NutanixPassword", Password);
            if (SkipSSL.ToBool()){
                System.Environment.SetEnvironmentVariable("NutanixSkipSSL", "true");
            }
            else {
                System.Environment.SetEnvironmentVariable("NutanixSkipSSL", "");
            }
        }
    }
}