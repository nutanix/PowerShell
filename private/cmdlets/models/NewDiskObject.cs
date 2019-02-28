namespace Nutanix.Powershell.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="Disk" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"DiskObject")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.IVmDisk))]
    public class NewDiskObject : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="VmDisk" /></summary>
        private Nutanix.Powershell.Models.IVmDisk _disk = new Nutanix.Powershell.Models.VmDisk();
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string DataSourceReferenceName
        {
            set
            {
                _disk.DataSourceReference = _disk.DataSourceReference ?? new Nutanix.Powershell.Models.Reference();
                _disk.DataSourceReference.Name = value;
            }
        }

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string DataSourceReferenceUuid
        {
            set
            {
                _disk.DataSourceReference = _disk.DataSourceReference ?? new Nutanix.Powershell.Models.Reference();
                _disk.DataSourceReference.Uuid = value;
            }
        }

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string DeviceType
        {
            set
            {
                _disk.DeviceProperties = _disk.DeviceProperties ?? new Nutanix.Powershell.Models.VmDiskDeviceProperties();
                _disk.DeviceProperties.DeviceType = value;
            }
        }

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string AdapterType
        {
            set
            {
                _disk.DeviceProperties = _disk.DeviceProperties ?? new Nutanix.Powershell.Models.VmDiskDeviceProperties();
                _disk.DeviceProperties.DiskAddress.AdapterType = value;
            }
        }

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public int DeviceIndex
        {
            set
            {
                _disk.DeviceProperties = _disk.DeviceProperties ?? new Nutanix.Powershell.Models.VmDiskDeviceProperties();
                _disk.DeviceProperties.DiskAddress.DeviceIndex = value;
            }
        }

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public long DiskSizeBytes
        {
            set
            {
                _disk.DiskSizeBytes = value;
            }
        }

        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public int DiskSizeMib
        {
            set
            {
                _disk.DiskSizeMib = value;
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            WriteObject(_disk);
        }
    }
}