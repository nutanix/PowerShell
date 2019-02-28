namespace Nutanix.Powershell.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Cmdlet to create an in-memory instance of the <see cref="Vm" /> object.</summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"VmObject")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.IVm))]
    public class NewVmObject : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="Vm" /></summary>
        private Nutanix.Powershell.Models.IVm _vm = new Nutanix.Powershell.Models.Vm();
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string AvailabilityZoneReferenceName
        {
            set
            {
                _vm.AvailabilityZoneReference = _vm.AvailabilityZoneReference ?? new Nutanix.Powershell.Models.AvailabilityZoneReference();
                _vm.AvailabilityZoneReference.Name = value;
                _vm.AvailabilityZoneReference.Kind = "availability_zone";
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string AvailabilityZoneReferenceUuid
        {
            set
            {
                _vm.AvailabilityZoneReference = _vm.AvailabilityZoneReference ?? new Nutanix.Powershell.Models.AvailabilityZoneReference();
                _vm.AvailabilityZoneReference.Uuid = value;
                _vm.AvailabilityZoneReference.Kind = "availability_zone";
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string ClusterReferenceName
        {
            set
            {
                _vm.ClusterReference = _vm.ClusterReference ?? new Nutanix.Powershell.Models.ClusterReference();
                _vm.ClusterReference.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public string ClusterReferenceUuid
        {
            set
            {
                _vm.ClusterReference = _vm.ClusterReference ?? new Nutanix.Powershell.Models.ClusterReference();
                _vm.ClusterReference.Uuid = value;
            }
        }
        /// <summary>A description for vm.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A description for vm.")]
        public string Description
        {
            set
            {
                _vm.Description = value;
            }
        }
        /// <summary>vm Name.</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "vm Name.")]
        public string Name
        {
            set
            {
                _vm.Name = value;
            }
        }
        /// <summary>VM Resources Definition.</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "VM Resources Definition.")]
        public Nutanix.Powershell.Models.IVmResources Resources
        {
            set
            {
                _vm.Resources = value;
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            _vm.ClusterReference.Kind = "cluster";
            // _vm.AvailabilityZoneReference = _vm.AvailabilityZoneReference ?? new Nutanix.Powershell.Models.AvailabilityZoneReference();
            // _vm.AvailabilityZoneReference.Kind = "availability_zone";
            // _vm.ClusterReference = _vm.ClusterReference ?? new Nutanix.Powershell.Models.ClusterReference();
            // _vm.ClusterReference.Kind = "cluster";
            WriteObject(_vm);
        }
    }
}