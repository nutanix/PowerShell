namespace Nutanix.Powershell.Cmdlets
{
    using System.Management.Automation;
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Implement a variant of the cmdlet New-Image.</summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"Image_Expanded", SupportsShouldProcess = true)]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.IImageIntentResponse))]
    public class NewImage_Expanded : System.Management.Automation.PSCmdlet, Microsoft.Rest.ClientRuntime.IEventListener
    {
        /// <summary>The <see cref="System.Threading.CancellationTokenSource" /> for this operation.</summary>
        private System.Threading.CancellationTokenSource _cancellationTokenSource = new System.Threading.CancellationTokenSource();
        /// <summary>Backing field for <see cref="Body" /> property.</summary>
        private Nutanix.Powershell.Models.IImageIntentInput _body;

        /// <summary>An intentful representation of a image</summary>
        public Nutanix.Powershell.Models.IImageIntentInput Body
        {
            get
            {
                return this._body;
            }
            set
            {
                this._body = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string Name
        {
            get
            {
                return this._body.Spec.Name;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                this._body.Spec.Name = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string Description
        {
            get
            {
                return this._body.Spec.Description;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                this._body.Spec.Description = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string Architecture
        {
            get
            {
                return this._body.Spec.Resources.Architecture;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                _body.Spec.Resources = _body.Spec.Resources ?? new Nutanix.Powershell.Models.ImageResources();
                this._body.Spec.Resources.Architecture = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string ImageType
        {
            get
            {
                return this._body.Spec.Resources.ImageType;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                _body.Spec.Resources = _body.Spec.Resources ?? new Nutanix.Powershell.Models.ImageResources();
                this._body.Spec.Resources.ImageType = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string SourceUri
        {
            get
            {
                return this._body.Spec.Resources.SourceUri;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                _body.Spec.Resources = _body.Spec.Resources ?? new Nutanix.Powershell.Models.ImageResources();
                this._body.Spec.Resources.SourceUri = value;
            }
        }


        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string ChecksumAlgorithm
        {
            get
            {
                return this._body.Spec.Resources.Checksum.ChecksumAlgorithm;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                _body.Spec.Resources = _body.Spec.Resources ?? new Nutanix.Powershell.Models.ImageResources();
                _body.Spec.Resources.Checksum = _body.Spec.Resources.Checksum ?? new Nutanix.Powershell.Models.Checksum();
                this._body.Spec.Resources.Checksum.ChecksumAlgorithm = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string ChecksumValue
        {
            get
            {
                return this._body.Spec.Resources.Checksum.ChecksumValue;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                _body.Spec.Resources = _body.Spec.Resources ?? new Nutanix.Powershell.Models.ImageResources();
                _body.Spec.Resources.Checksum = _body.Spec.Resources.Checksum ?? new Nutanix.Powershell.Models.Checksum();
                this._body.Spec.Resources.Checksum.ChecksumValue = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string ProductName
        {
            get
            {
                return this._body.Spec.Resources.Version.ProductName;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                _body.Spec.Resources = _body.Spec.Resources ?? new Nutanix.Powershell.Models.ImageResources();
                _body.Spec.Resources.Version = _body.Spec.Resources.Version ?? new Nutanix.Powershell.Models.ImageVersionResources();
                this._body.Spec.Resources.Version.ProductName = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public string ProductVersion
        {
            get
            {
                return this._body.Spec.Resources.Version.ProductVersion;
            }
            set
            {
                _body.Spec = _body.Spec ?? new Nutanix.Powershell.Models.Image();
                _body.Spec.Resources = _body.Spec.Resources ?? new Nutanix.Powershell.Models.ImageResources();
                _body.Spec.Resources.Version = _body.Spec.Resources.Version ?? new Nutanix.Powershell.Models.ImageVersionResources();
                this._body.Spec.Resources.Version.ProductVersion = value;
            }
        }

        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a image", ValueFromPipeline = true)]
        public System.Collections.Generic.IDictionary<string, string> Categories
        {
            get
            {
                return this._body.Metadata.Categories;
            }
            set
            {
                _body.Metadata = _body.Metadata ?? new Nutanix.Powershell.Models.VmMetadata();
                this._body.Metadata.Categories = value;
            }
        }

        /// <summary>The reference to the client API class.</summary>
        public Nutanix.Powershell.NutanixIntentfulAPI Client => Nutanix.Powershell.Module.Instance.ClientAPI;
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

        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Skip the ssl validation")]
        public System.Management.Automation.SwitchParameter SkipSSL { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "A PSCredental with username and password")]
        [System.Management.Automation.ValidateNotNull]
        public Nutanix.Powershell.Models.NutanixCredential Credential { get; set; }

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The Username for authentication")]
        public string Server { get; set; }

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The Username for authentication")]
        public string Port { get; set; }

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The Username for authentication")]
        public string Protocol { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Run the command asynchronous")]
        public System.Management.Automation.SwitchParameter Async {get; set;}
        /// <summary>
        /// (overrides the default BeginProcessing method in System.Management.Automation.PSCmdlet)
        /// </summary>

        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
        }
        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of NewImage_Expanded</returns>
        public Nutanix.Powershell.Cmdlets.NewImage_Expanded Clone()
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
        /// <returns>an instance of NewImage_Expanded.</returns>
        public static Nutanix.Powershell.Cmdlets.NewImage_Expanded FromJson(Carbon.Json.JsonNode node)
        {
            return node is Carbon.Json.JsonObject json ? new NewImage_Expanded(json) : null;
        }
        /// <summary>
        /// Creates a new instance of this cmdlet, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this cmdlet.</param>
        /// <returns>
        /// returns a new instance of the <see cref="NewImage_Expanded" /> cmdlet
        /// </returns>
        public static Nutanix.Powershell.Cmdlets.NewImage_Expanded FromJsonString(string jsonText) => string.IsNullOrEmpty(jsonText) ? null : FromJson(Carbon.Json.JsonObject.Parse(jsonText));
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
        /// <summary>
        /// Intializes a new instance of the <see cref="NewImage_Expanded" /> cmdlet class.
        /// </summary>
        public NewImage_Expanded()
        {
        }
        /// <summary>Constructor for deserialization.</summary>
        /// <param name="json">a <see cref="Carbon.Json.JsonObject" /> to deserialize from.</param>
        internal NewImage_Expanded(Carbon.Json.JsonObject json)
        {
            // deserialize the contents
            _body = If( json?.PropertyT<Carbon.Json.JsonObject>("Body"), out var __jsonBody) ? Nutanix.Powershell.Models.ImageIntentInput.FromJson(__jsonBody) : Body;
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            try
            {
                // work
                if (ShouldProcess($"Call remote 'NewImage' operation"))
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
            _body.Metadata.Kind = "image";
            using( NoSynchronizationContext )
            {
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletGetPipeline); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                if (SkipSSL.ToBool() || System.Environment.GetEnvironmentVariable("NutanixSkipSSL") != null)
                {
                    Pipeline = Nutanix.Powershell.Module.Instance.CreatePipelineWithProxy(this.MyInvocation.BoundParameters);
                }
                else
                {
                    Pipeline = Nutanix.Powershell.Module.Instance.CreatePipeline(this.MyInvocation.BoundParameters);
                }
                Pipeline.Prepend(HttpPipelinePrepend);
                Pipeline.Append(HttpPipelineAppend);
                // get the client instance
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
                    if (PSCredential == null)
                    {
                        System.Security.SecureString s = new System.Security.SecureString();
                        if (System.Environment.GetEnvironmentVariable("NutanixPassword") != null)
                        {

                            foreach (char item in System.Environment.GetEnvironmentVariable("NutanixPassword"))
                            {
                                s.AppendChar(item);
                            }
                        }
                        PSCredential = new PSCredential(System.Environment.GetEnvironmentVariable("NutanixUsername"), s);
                    }

                    //build url
                    var url = $"{Protocol}://{Server}:{Port}";
                    Credential = new Nutanix.Powershell.Models.NutanixCredential(url, PSCredential);
                }
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletBeforeAPICall); if( ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                if (Async.ToBool())
                {
                    await this.Client.NewImage(Body, onAccepted, onDefault, this, Pipeline, Credential);
                }
                else
                {

                    await this.Client.NewImage_Sync(Body, onAccepted, onDefault, onOK, this, Pipeline, Credential);
                }
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
        /// a serialized instance of <see cref="NewImage_Expanded" /> as a <see cref="Carbon.Json.JsonNode" />.
        /// </returns>
        public Carbon.Json.JsonNode ToJson(Carbon.Json.JsonObject container, Microsoft.Rest.ClientRuntime.SerializationMode serializationMode)
        {
            // serialization method
            container = container ?? new Carbon.Json.JsonObject();
            AddIf( null != Body ? (Carbon.Json.JsonNode) Body.ToJson(null) : null, "Body" ,container.Add );
            return container;
        }
        /// <summary>a delegate that is called when the remote service returns 202 (Accepted).</summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.IImageIntentResponse" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onAccepted(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse> response)
        {
            using( NoSynchronizationContext )
            {
                // onAccepted - response for 202 / application/json
                // (await response) // should be Nutanix.Powershell.Models.IImageIntentResponse
                WriteObject(await response);
            }
        }
        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.IImageStatus" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onDefault(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus> response)
        {
            using( NoSynchronizationContext )
            {
                // Error Response : default
                 WriteError(new System.Management.Automation.ErrorRecord(new System.Exception($"The service encountered an unexpected result: {responseMessage.StatusCode}"), responseMessage.StatusCode.ToString(), System.Management.Automation.ErrorCategory.InvalidOperation, new { Body}));

            }
        }
        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="System.IO.Stream" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>

        private async System.Threading.Tasks.Task onOK(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse> response)
        {
            using( NoSynchronizationContext )
            {
                // onOK - response for 200 / application/json
                // (await response) // should be Nutanix.Powershell.Models.IImageIntentResponse
                WriteObject(await response);
            }
        }
    }
}