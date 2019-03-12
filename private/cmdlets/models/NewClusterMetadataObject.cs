namespace Nutanix.Powershell.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="ClusterMetadata" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"ClusterMetadataObject")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.IClusterMetadata))]
    public class NewClusterMetadataObject : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="ClusterMetadata" /></summary>
        private Nutanix.Powershell.Models.IClusterMetadata _clusterMetadata = new Nutanix.Powershell.Models.ClusterMetadata();
        /// <summary>Categories for the cluster</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Categories for the cluster")]
        public System.Collections.Generic.IDictionary<string,string> Categories
        {
            set
            {
                _clusterMetadata.Categories = value;
            }
        }
        /// <summary>cluster name</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "cluster name")]
        public string Name
        {
            set
            {
                _clusterMetadata.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string ProjectReferenceName
        {
            set
            {
                _clusterMetadata.ProjectReference = _clusterMetadata.ProjectReference ?? new Nutanix.Powershell.Models.ProjectReference();
                _clusterMetadata.ProjectReference.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public string ProjectReferenceUuid
        {
            set
            {
                _clusterMetadata.ProjectReference = _clusterMetadata.ProjectReference ?? new Nutanix.Powershell.Models.ProjectReference();
                _clusterMetadata.ProjectReference.Uuid = value;
            }
        }
        /// <summary>Hash of the spec. This will be returned from server.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Hash of the spec. This will be returned from server.")]
        public string SpecHash
        {
            set
            {
                _clusterMetadata.SpecHash = value;
            }
        }
        /// <summary>Version number of the latest spec.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Version number of the latest spec.")]
        public int SpecVersion
        {
            set
            {
                _clusterMetadata.SpecVersion = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string UserReferenceName
        {
            set
            {
                _clusterMetadata.OwnerReference = _clusterMetadata.OwnerReference ?? new Nutanix.Powershell.Models.UserReference();
                _clusterMetadata.OwnerReference.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public string UserReferenceUuid
        {
            set
            {
                _clusterMetadata.OwnerReference = _clusterMetadata.OwnerReference ?? new Nutanix.Powershell.Models.UserReference();
                _clusterMetadata.OwnerReference.Uuid = value;
            }
        }
        /// <summary>cluster uuid</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "cluster uuid")]
        public string Uuid
        {
            set
            {
                _clusterMetadata.Uuid = value;
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            // _clusterMetadata.ProjectReference = _clusterMetadata.ProjectReference ?? new Nutanix.Powershell.Models.ProjectReference();
            // _clusterMetadata.OwnerReference.Kind = "owner_reference";
            // _clusterMetadata.ProjectReference = _clusterMetadata.ProjectReference ?? new Nutanix.Powershell.Models.ProjectReference();
            // _clusterMetadata.ProjectReference.Kind = "project_reference";
            // _clusterMetadata.Kind = "cluster";
            WriteObject(_clusterMetadata);
        }
    }
}