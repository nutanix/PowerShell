namespace Nutanix.Powershell.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="AvailabilityZoneReference" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"AvailabilityZoneReferenceObject")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.IAvailabilityZoneReference))]
    public class NewAvailabilityZoneReferenceObject : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="AvailabilityZoneReference" /></summary>
        private Nutanix.Powershell.Models.IAvailabilityZoneReference _availabilityZoneReference = new Nutanix.Powershell.Models.AvailabilityZoneReference();
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string Name
        {
            set
            {
                _availabilityZoneReference.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public string Uuid
        {
            set
            {
                _availabilityZoneReference.Uuid = value;
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            WriteObject(_availabilityZoneReference);
        }
    }
}