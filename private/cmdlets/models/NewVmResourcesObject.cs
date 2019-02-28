namespace Nutanix.Powershell.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="VmResources" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"VmResourcesObject")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.IVmResources))]
    public class NewVmResourcesObject : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="VmResources" /></summary>
        private Nutanix.Powershell.Models.IVmResources _vmResources = new Nutanix.Powershell.Models.VmResources();
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string DiskAddressAdapterType
        {
            set
            {
                _vmResources.BootConfig = _vmResources.BootConfig ?? new Nutanix.Powershell.Models.VmBootConfig();
                _vmResources.BootConfig.BootDevice = _vmResources.BootConfig.BootDevice ?? new Nutanix.Powershell.Models.VmBootDevice();
                _vmResources.BootConfig.BootDevice.DiskAddress = _vmResources.BootConfig.BootDevice.DiskAddress ?? new Nutanix.Powershell.Models.DiskAddress();
                _vmResources.BootConfig.BootDevice.DiskAddress.AdapterType = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public int DiskAddressDeviceIndex
        {
            set
            {
                _vmResources.BootConfig = _vmResources.BootConfig ?? new Nutanix.Powershell.Models.VmBootConfig();
                _vmResources.BootConfig.BootDevice = _vmResources.BootConfig.BootDevice ?? new Nutanix.Powershell.Models.VmBootDevice();
                _vmResources.BootConfig.BootDevice.DiskAddress = _vmResources.BootConfig.BootDevice.DiskAddress ?? new Nutanix.Powershell.Models.DiskAddress();
                _vmResources.BootConfig.BootDevice.DiskAddress.DeviceIndex = value;
            }
        }
        /// <summary>Disks attached to the VM.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Disks attached to the VM.")]
        public Nutanix.Powershell.Models.IVmDisk[] DiskList
        {
            set
            {
                _vmResources.DiskList = value;
            }
        }
        /// <summary>GPUs attached to the VM.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "GPUs attached to the VM.")]
        public Nutanix.Powershell.Models.IVmGpu[] GpuList
        {
            set
            {
                _vmResources.GpuList = value;
            }
        }
        /// <summary>
        /// VM guests may be customized at boot time using one of several different methods. Currently, cloud-init w/ ConfigDriveV2
        /// (for Linux VMs) and Sysprep (for Windows VMs) are supported. Only ONE OF sysprep or cloud_init should be provided. Note
        /// that guest customization can currently only be set during VM creation. Attempting to change it after creation will result
        /// in an error. Additional properties can be specified. For example - in the context of VM template creation if "override_script"
        /// is set to "True" then the deployer can upload their own custom script.
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "VM guests may be customized at boot time using one of several different methods. Currently, cloud-init w/ ConfigDriveV2 (for Linux VMs) and Sysprep (for Windows VMs) are supported. Only ONE OF sysprep or cloud_init should be provided. Note that guest customization can currently only be set during VM creation. Attempting to change it after creation will result in an error. Additional properties can be specified. For example - in the context of VM template creation if \"override_script\" is set to \"True\" then the deployer can upload their own custom script.")]
        public Nutanix.Powershell.Models.IGuestCustomization GuestCustomization
        {
            set
            {
                _vmResources.GuestCustomization = value;
            }
        }
        /// <summary>
        /// Guest OS Identifier. For ESX, refer to VMware documentation link (https://www.vmware.com/support/developer/converter-sdk/conv43_apireference/vim.vm.GuestOsDescriptor.GuestOsIdentifier.html)
        /// for the list of guest OS identifiers.
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Guest OS Identifier. For ESX, refer to VMware documentation link (https://www.vmware.com/support/developer/converter-sdk/conv43_apireference/vim.vm.GuestOsDescriptor.GuestOsIdentifier.html) for the list of guest OS identifiers.")]
        public string GuestOsId
        {
            set
            {
                _vmResources.GuestOsId = value;
            }
        }
        /// <summary>VM's hardware clock timezone in IANA TZDB format (America/Los_Angeles).</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "VM's hardware clock timezone in IANA TZDB format (America/Los_Angeles).")]
        public string HardwareClockTimezone
        {
            set
            {
                _vmResources.HardwareClockTimezone = value;
            }
        }
        /// <summary>Memory size in MiB.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Memory size in MiB.")]
        public int MemorySizeMib
        {
            set
            {
                _vmResources.MemorySizeMib = value;
            }
        }
        /// <summary>NICs attached to the VM.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "NICs attached to the VM.")]
        public Nutanix.Powershell.Models.IVmNic[] NicList
        {
            set
            {
                _vmResources.NicList = value;
            }
        }
        /// <summary>Number of vCPU sockets.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Number of vCPU sockets.")]
        public int NumSockets
        {
            set
            {
                _vmResources.NumSockets = value;
            }
        }
        /// <summary>Number of vCPUs per socket.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Number of vCPUs per socket.")]
        public int NumVcpusPerSocket
        {
            set
            {
                _vmResources.NumVcpusPerSocket = value;
            }
        }
        /// <summary>Application names that are enabled.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Application names that are enabled.")]
        public string[] NutanixGuestToolsSpecEnabledCapabilityList
        {
            set
            {
                _vmResources.GuestTools = _vmResources.GuestTools ?? new Nutanix.Powershell.Models.GuestToolsSpec();
                _vmResources.GuestTools.NutanixGuestTools = _vmResources.GuestTools.NutanixGuestTools ?? new Nutanix.Powershell.Models.NutanixGuestToolsSpec();
                _vmResources.GuestTools.NutanixGuestTools.EnabledCapabilityList = value;
            }
        }
        /// <summary>Desired mount state of Nutanix Guest Tools ISO.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Desired mount state of Nutanix Guest Tools ISO.")]
        public string NutanixGuestToolsSpecIsoMountState
        {
            set
            {
                _vmResources.GuestTools = _vmResources.GuestTools ?? new Nutanix.Powershell.Models.GuestToolsSpec();
                _vmResources.GuestTools.NutanixGuestTools = _vmResources.GuestTools.NutanixGuestTools ?? new Nutanix.Powershell.Models.NutanixGuestToolsSpec();
                _vmResources.GuestTools.NutanixGuestTools.IsoMountState = value;
            }
        }
        /// <summary>Nutanix Guest Tools is enabled or not.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Nutanix Guest Tools is enabled or not.")]
        public string NutanixGuestToolsSpecState
        {
            set
            {
                _vmResources.GuestTools = _vmResources.GuestTools ?? new Nutanix.Powershell.Models.GuestToolsSpec();
                _vmResources.GuestTools.NutanixGuestTools = _vmResources.GuestTools.NutanixGuestTools ?? new Nutanix.Powershell.Models.NutanixGuestToolsSpec();
                _vmResources.GuestTools.NutanixGuestTools.State = value;
            }
        }
        /// <summary>The current or desired power state of the VM.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The current or desired power state of the VM.")]
        public string PowerState
        {
            set
            {
                _vmResources.PowerState = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string ReferenceName
        {
            set
            {
                _vmResources.ParentReference = _vmResources.ParentReference ?? new Nutanix.Powershell.Models.Reference();
                _vmResources.ParentReference.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string ReferenceUuid
        {
            set
            {
                _vmResources.ParentReference = _vmResources.ParentReference ?? new Nutanix.Powershell.Models.Reference();
                _vmResources.ParentReference.Uuid = value;
            }
        }
        /// <summary>Indicates whether VGA console should be enabled or not.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates whether VGA console should be enabled or not.")]
        public System.Management.Automation.SwitchParameter VgaConsoleEnabled
        {
            set
            {
                _vmResources.VgaConsoleEnabled = value.ToBool();
            }
        }
        /// <summary>
        /// Indicates the order of device types in which VM should try to boot from. If boot device order is not provided the system
        /// will decide appropriate boot device order.
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates the order of device types in which VM should try to boot from. If boot device order is not provided the system will decide appropriate boot device order.")]
        public string[] VmBootConfigBootDeviceOrderList
        {
            set
            {
                _vmResources.BootConfig = _vmResources.BootConfig ?? new Nutanix.Powershell.Models.VmBootConfig();
                _vmResources.BootConfig.BootDeviceOrderList = value;
            }
        }
        /// <summary>MAC address of nic to boot from.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "MAC address of nic to boot from.")]
        public string VmBootDeviceMacAddress
        {
            set
            {
                _vmResources.BootConfig = _vmResources.BootConfig ?? new Nutanix.Powershell.Models.VmBootConfig();
                _vmResources.BootConfig.BootDevice = _vmResources.BootConfig.BootDevice ?? new Nutanix.Powershell.Models.VmBootDevice();
                _vmResources.BootConfig.BootDevice.MacAddress = value;
            }
        }
        /// <summary>Indicates whether to execute set script before ngt shutdown/reboot.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates whether to execute set script before ngt shutdown/reboot.")]
        public System.Management.Automation.SwitchParameter VmGuestPowerStateTransitionConfigEnableScriptExec
        {
            set
            {
                _vmResources.PowerStateMechanism = _vmResources.PowerStateMechanism ?? new Nutanix.Powershell.Models.VmPowerStateMechanism();
                _vmResources.PowerStateMechanism.GuestTransitionConfig = _vmResources.PowerStateMechanism.GuestTransitionConfig ?? new Nutanix.Powershell.Models.VmGuestPowerStateTransitionConfig();
                _vmResources.PowerStateMechanism.GuestTransitionConfig.EnableScriptExec = value.ToBool();
            }
        }
        /// <summary>Indicates whether to abort ngt shutdown/reboot if script fails.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates whether to abort ngt shutdown/reboot if script fails.")]
        public System.Management.Automation.SwitchParameter VmGuestPowerStateTransitionConfigShouldFailOnScriptFailure
        {
            set
            {
                _vmResources.PowerStateMechanism = _vmResources.PowerStateMechanism ?? new Nutanix.Powershell.Models.VmPowerStateMechanism();
                _vmResources.PowerStateMechanism.GuestTransitionConfig = _vmResources.PowerStateMechanism.GuestTransitionConfig ?? new Nutanix.Powershell.Models.VmGuestPowerStateTransitionConfig();
                _vmResources.PowerStateMechanism.GuestTransitionConfig.ShouldFailOnScriptFailure = value.ToBool();
            }
        }
        /// <summary>Power state mechanism (ACPI/GUEST/HARD).</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Power state mechanism (ACPI/GUEST/HARD).")]
        public string VmPowerStateMechanismMechanism
        {
            set
            {
                _vmResources.PowerStateMechanism = _vmResources.PowerStateMechanism ?? new Nutanix.Powershell.Models.VmPowerStateMechanism();
                _vmResources.PowerStateMechanism.Mechanism = value;
            }
        }
        /// <summary>Number of vNUMA nodes. 0 means vNUMA is disabled.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Number of vNUMA nodes. 0 means vNUMA is disabled.")]
        public long VmVnumaConfigNumVnumaNodes
        {
            set
            {
                _vmResources.VnumaConfig = _vmResources.VnumaConfig ?? new Nutanix.Powershell.Models.VmVnumaConfig();
                _vmResources.VnumaConfig.NumVnumaNodes = value;
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            WriteObject(_vmResources);
        }
    }
}