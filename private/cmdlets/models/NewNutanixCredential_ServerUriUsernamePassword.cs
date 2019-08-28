namespace Nutanix.Powershell.ModelCmdlets
{
    using System.Management.Automation;
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="Disk" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"NutanixCredential_ServerUriUsernamePassword")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.NutanixCredential))]
    public class NewNutanixCredential_ServerUriUsernamePassword : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="VmDisk" /></summary>
        private Nutanix.Powershell.Models.NutanixCredential _credential = new Nutanix.Powershell.Models.NutanixCredential();

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string ServerUri
        {
            set
            {
                var _uri = new System.Uri(value);
                _credential.Uri = _uri;
            }
        }

        ///// <summary>HELP MESSAGE MISSING</summary>
        //[System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        //public string Username
        //{
        //    set
        //    {
        //        _credential.Username = value;
        //    }
        //} 
        ///// <summary>HELP MESSAGE MISSING</summary>
        //[System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        //public string Password
        //{
        //    set
        //    {
        //        System.Security.SecureString result = new System.Security.SecureString();
        //        if (value.Length > 0 ) {
        //        foreach (char c in value)
        //                result.AppendChar(c);
        //        }  
        //        _credential.Password = result;
        //    }
        //}

            public PSCredential PSCredential
        {
            set
            {
                _credential.PSCredential = value;
            }
        }
        
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            WriteObject(_credential);
        }
    }
}