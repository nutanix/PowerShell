namespace Nutanix.Powershell.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="NutanixCredential" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.Set, @"NutanixCredential_Credential")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.NutanixCredential))]
    public class SetNutanixCredential_Credential : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="NutanixCredential" /></summary>
        private Nutanix.Powershell.Models.NutanixCredential _credential = new Nutanix.Powershell.Models.NutanixCredential();

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public Nutanix.Powershell.Models.NutanixCredential Credential
        {
            set
            {
                _credential = value;
            }
        }

        private bool _skip_ssl;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Skip the ssl validation")]
        public System.Management.Automation.SwitchParameter SkipSSL { get; set; }

        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {

            if (_credential.PSCredential != null)
            {
                System.Environment.SetEnvironmentVariable("NutanixUsername", _credential.PSCredential.UserName);
                System.IntPtr intPtr = System.IntPtr.Zero;
                string result;
                try
                {
                    intPtr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(_credential.PSCredential.Password);
                    result = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(intPtr);
                }
                finally
                {
                    if (intPtr != System.IntPtr.Zero)
                    {
                        System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(intPtr);
                    }
                }
                System.Environment.SetEnvironmentVariable("NutanixPassword", result);
            }
            //if (_credential.Username != null) {
            //    System.Environment.SetEnvironmentVariable("NutanixUsername", _credential.Username);
            //}

            //if (_credential.Password != null) {

            //    System.IntPtr intPtr = System.IntPtr.Zero; 
            //    string result;
            //    try
            //    {
            //        intPtr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR( _credential.Password);
            //        result = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(intPtr);
            //     }
            //    finally
            //    {       
            //        if (intPtr != System.IntPtr.Zero)
            //        {
            //            System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(intPtr);
            //        }   
            //    }  
            //    System.Environment.SetEnvironmentVariable("NutanixPassword", result);
            //}

            System.Environment.SetEnvironmentVariable("NutanixPort", _credential.Port.ToString());
            System.Environment.SetEnvironmentVariable("NutanixServer", _credential.Server);
            System.Environment.SetEnvironmentVariable("NutanixProtocol", _credential.Protocol);
            if (SkipSSL.ToBool())
            {
                System.Environment.SetEnvironmentVariable("NutanixSkipSSL", "true");
            }
            else
            {
                System.Environment.SetEnvironmentVariable("NutanixSkipSSL", "");
            }
            // WriteObject(_credential);
        }
    }
}