namespace Nutanix.Powershell.Cmdlets
{
    using System.Management.Automation;
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Implement a variant of the cmdlet Get-Subnet.</summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.Get, @"Subnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder", SupportsShouldProcess = true)]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.ISubnetListIntentResponse))]
    public class GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder : System.Management.Automation.PSCmdlet, Microsoft.Rest.ClientRuntime.IEventListener
    {
        /// <summary>The <see cref="System.Threading.CancellationTokenSource" /> for this operation.</summary>
        private System.Threading.CancellationTokenSource _cancellationTokenSource = new System.Threading.CancellationTokenSource();
        /// <summary>The reference to the client API class.</summary>
        public Nutanix.Powershell.NutanixIntentfulAPI Client => Nutanix.Powershell.Module.Instance.ClientAPI;
        /// <summary>Backing field for <see cref="GetEntitiesRequest" /> property.</summary>
        private Nutanix.Powershell.Models.ISubnetListMetadata _getEntitiesRequest;

        /// <summary>
        /// All api calls that return a list will have this metadata block as input
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "All api calls that return a list will have this metadata block as input\n", ValueFromPipeline = true)]
        public Nutanix.Powershell.Models.ISubnetListMetadata GetEntitiesRequest
        {
            get
            {
                return this._getEntitiesRequest;
            }
            set
            {
                this._getEntitiesRequest = value;
            }
        }
        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [System.Management.Automation.ValidateNotNull]
        public Microsoft.Rest.ClientRuntime.SendAsyncStep[] HttpPipelineAppend {get;set;}
        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [System.Management.Automation.ValidateNotNull]
        public Microsoft.Rest.ClientRuntime.SendAsyncStep[] HttpPipelinePrepend {get;set;}
        /// <summary>
        /// <see cref="IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
         System.Action Microsoft.Rest.ClientRuntime.IEventListener.Cancel => _cancellationTokenSource.Cancel;
        /// <summary><see cref="IEventListener" /> cancellation token.</summary>
         System.Threading.CancellationToken Microsoft.Rest.ClientRuntime.IEventListener.Token => _cancellationTokenSource.Token;
        /// <summary>
        /// The instance of the <see cref="Microsoft.Rest.ClientRuntime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        private Microsoft.Rest.ClientRuntime.HttpPipeline Pipeline {get;set;}
        /// <summary>The URI for the proxy server to use</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "The URI for the proxy server to use")]
        public System.Uri Proxy {get;set;}
        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [System.Management.Automation.ValidateNotNull]
        public System.Management.Automation.PSCredential ProxyCredential {get;set;}
        /// <summary>Use the default credentials for the proxy</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Use the default credentials for the proxy")]
        public System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials {get;set;}

        /// <summary>Use credentials for login</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "PSCredential for authentication")]
        public PSCredential PSCredential { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Skip the ssl validation")]
        public System.Management.Automation.SwitchParameter SkipSSL {get; set;}

        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "The Nutanix Credential object for authentication")]
        [System.Management.Automation.ValidateNotNull]
        public Nutanix.Powershell.Models.NutanixCredential Credential {get; set;}

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Server address")]
        public string Server {get; set;}

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Server Port, defaults to 9440")]
        public string Port {get; set;}

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "The HTTP protocol, defaults to https")]
        public string Protocol {get; set;}

        /// <summary>
        /// (overrides the default BeginProcessing method in System.Management.Automation.PSCmdlet)
        /// </summary>

        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
        }
        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>
        /// a duplicate instance of GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder
        /// </returns>
        public Nutanix.Powershell.Cmdlets.GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder Clone()
        {
            var clone = FromJson(this.ToJson(null, Microsoft.Rest.ClientRuntime.SerializationMode.IncludeAll));
            clone.HttpPipelinePrepend = this.HttpPipelinePrepend;
            clone.HttpPipelineAppend = this.HttpPipelineAppend;
            return clone;
        }
        /// <summary>Performs clean-up after the command execution</summary>

        protected override void EndProcessing()
        {
        }
        /// <summary>
        /// Deserializes a <see cref="Carbon.Json.JsonNode" /> into a new instance of this class.
        /// </summary>
        /// <param name="node">a <see cref="Carbon.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder.</returns>
        public static Nutanix.Powershell.Cmdlets.GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder FromJson(Carbon.Json.JsonNode node)
        {
            return node is Carbon.Json.JsonObject json ? new GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder(json) : null;
        }
        /// <summary>
        /// Creates a new instance of this cmdlet, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this cmdlet.</param>
        /// <returns>
        /// returns a new instance of the <see cref="GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder" /> cmdlet
        /// </returns>
        public static Nutanix.Powershell.Cmdlets.GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder FromJsonString(string jsonText) => string.IsNullOrEmpty(jsonText) ? null : FromJson(Carbon.Json.JsonObject.Parse(jsonText));
        /// <summary>
        /// Intializes a new instance of the <see cref="GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder" /> cmdlet class.
        /// </summary>
        public GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder()
        {
        }
        /// <summary>Constructor for deserialization.</summary>
        /// <param name="json">a <see cref="Carbon.Json.JsonObject" /> to deserialize from.</param>
        internal GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder(Carbon.Json.JsonObject json)
        {
            // deserialize the contents
            _getEntitiesRequest = If( json?.PropertyT<Carbon.Json.JsonObject>("GetEntitiesRequest"), out var __jsonGetEntitiesRequest) ? Nutanix.Powershell.Models.SubnetListMetadata.FromJson(__jsonGetEntitiesRequest) : GetEntitiesRequest;
        }
        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
         async System.Threading.Tasks.Task Microsoft.Rest.ClientRuntime.IEventListener.Signal(string id, System.Threading.CancellationToken token, System.Func<Microsoft.Rest.ClientRuntime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                switch ( id )
                {
                    case Microsoft.Rest.ClientRuntime.Events.Verbose:
                    {
                        WriteVerbose($"{messageData().Message ?? System.String.Empty}");
                        return ;
                    }
                    case Microsoft.Rest.ClientRuntime.Events.Warning:
                    {
                        WriteWarning($"{messageData().Message ?? System.String.Empty}");
                        return ;
                    }
                    case Microsoft.Rest.ClientRuntime.Events.Information:
                    {
                        var data = messageData();
                        WriteInformation(data, new[] { data.Message });
                        return ;
                    }
                    case Microsoft.Rest.ClientRuntime.Events.Debug:
                    {
                        WriteDebug($"{messageData().Message ?? System.String.Empty}");
                        return ;
                    }
                    case Microsoft.Rest.ClientRuntime.Events.Error:
                    {
                        WriteError(new System.Management.Automation.ErrorRecord( new System.Exception(messageData().Message), string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                }
                WriteDebug($"{id}: {messageData().Message ?? System.String.Empty}");
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            try
            {
                // work
                if (ShouldProcess($"Call remote 'listSubnets' operation"))
                {
                    using( var asyncCommandRuntime = new Microsoft.Rest.ClientRuntime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token) )
                    {
                        asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Rest.ClientRuntime.IEventListener)this).Token);
                    }
                }
            }
            catch(System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new System.Management.Automation.ErrorRecord(innerException,string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch(System.Exception exception)
            {
                ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new System.Management.Automation.ErrorRecord(exception,string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
        }
        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async System.Threading.Tasks.Task ProcessRecordAsync()
        {
            using( NoSynchronizationContext )
            {
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletGetPipeline); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                if (this.SkipSSL.ToBool() || System.Environment.GetEnvironmentVariable("NutanixSkipSSL") != null) {
                    Pipeline = Nutanix.Powershell.Module.Instance.CreatePipelineWithProxy(this.MyInvocation.BoundParameters);
                } else {
                    Pipeline = Nutanix.Powershell.Module.Instance.CreatePipeline(this.MyInvocation.BoundParameters);
                }
                Pipeline.Prepend(HttpPipelinePrepend);
                Pipeline.Append(HttpPipelineAppend);

                if (Credential == null)
                {

                    if (Port == null)
                    {
                        Port = System.Environment.GetEnvironmentVariable("NutanixPort") ?? "9440";
                    }

                    if (Protocol == null)
                    {
                        Protocol = System.Environment.GetEnvironmentVariable("NutanixProtocol") ?? "https";
                    }

                    if (Server == null)
                    {
                        Server = System.Environment.GetEnvironmentVariable("NutanixServer") ?? "localhost";
                    }

                    
                    //build url 
                    var url = $"{Protocol}://{Server}:{Port}";
                    Credential = new Nutanix.Powershell.Models.NutanixCredential(url, PSCredential);
                }

                // get the client instance
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletBeforeAPICall); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                await this.Client.ListSubnets(GetEntitiesRequest, onOK, onDefault, this, Pipeline, Credential);
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletAfterAPICall); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            }
        }
        /// <summary>Interrupts currently running code within the command.</summary>

        protected override void StopProcessing()
        {
            ((Microsoft.Rest.ClientRuntime.IEventListener)this).Cancel();
            base.StopProcessing();
        }
        /// <summary>
        /// Serializes the state of this cmdlet to a <see cref="Carbon.Json.JsonNode" /> object.
        /// </summary>
        /// <param name="container">The <see cref="Carbon.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Rest.ClientRuntime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="GetSubnet_SubnetsFilterKindLengthOffsetSortAttributeSortOrder" /> as a <see cref="Carbon.Json.JsonNode"
        /// />.
        /// </returns>
        public Carbon.Json.JsonNode ToJson(Carbon.Json.JsonObject container, Microsoft.Rest.ClientRuntime.SerializationMode serializationMode)
        {
            // serialization method
            container = container ?? new Carbon.Json.JsonObject();
            AddIf( null != GetEntitiesRequest ? (Carbon.Json.JsonNode) GetEntitiesRequest.ToJson(null) : null, "GetEntitiesRequest" ,container.Add );
            return container;
        }
        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.ISubnetStatus" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onDefault(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus> response)
        {
            using( NoSynchronizationContext )
            {
                // Error Response : default
                WriteError(new System.Management.Automation.ErrorRecord(new System.Exception($"The service encountered an unexpected result: {responseMessage.StatusCode}"), responseMessage.StatusCode.ToString(), System.Management.Automation.ErrorCategory.InvalidOperation, new { GetEntitiesRequest}));
            }
        }
        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.ISubnetListIntentResponse" /> from the
        /// remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onOK(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetListIntentResponse> response)
        {
            using( NoSynchronizationContext )
            {
                // onOK - response for 200 / application/json
                // (await response) // should be Nutanix.Powershell.Models.ISubnetListIntentResponse
                WriteObject(await response);
            }
        }
    }
}