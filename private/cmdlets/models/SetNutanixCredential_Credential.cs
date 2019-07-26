using System;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace Nutanix.Powershell.ModelCmdlets
{
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="NutanixCredential" /> object.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, @"NutanixCredential_Credential")]
    [OutputType(typeof(Nutanix.Powershell.Models.NutanixCredential))]
    public class SetNutanixCredential_Credential : PSCmdlet
    {
        /// <summary>Backing field for <see cref="NutanixCredential" /></summary>
        private Nutanix.Powershell.Models.NutanixCredential _credential = new Nutanix.Powershell.Models.NutanixCredential();

        /// <summary>HELP MESSAGE MISSING</summary>
        [Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public Nutanix.Powershell.Models.NutanixCredential Credential
        {
            set
            {
                _credential = value;
            }
        }

        private bool _skip_ssl;
        /// <summary>HELP MESSAGE MISSING</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "Skip the ssl validation")]
        public SwitchParameter SkipSSL { get; set; }
        
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            

            if (_credential.Username != null) {
                System.Environment.SetEnvironmentVariable("NutanixUsername", _credential.Username);
            }

            if (_credential.Password != null) {

                IntPtr intPtr = IntPtr.Zero;
                string result;
                try
                {
                    intPtr = Marshal.SecureStringToBSTR( _credential.Password);
                    result = Marshal.PtrToStringBSTR(intPtr);
                 }
                finally
                {       
                    if (intPtr != IntPtr.Zero)
                    {
                        Marshal.ZeroFreeBSTR(intPtr);
                    }   
                }
                Environment.SetEnvironmentVariable("NutanixPassword", result);
            }

            Environment.SetEnvironmentVariable("NutanixPort", _credential.Port.ToString());
            Environment.SetEnvironmentVariable("NutanixServer", _credential.Server);
            Environment.SetEnvironmentVariable("NutanixProtocol", _credential.Protocol);
            if (SkipSSL.ToBool()){
                Environment.SetEnvironmentVariable("NutanixSkipSSL", "true");
            }
            else {
                Environment.SetEnvironmentVariable("NutanixSkipSSL", "");
            }
            // WriteObject(_credential);
        }
    }
}