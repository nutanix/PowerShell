namespace Nutanix.Powershell
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    using System.Linq;
    using System.Collections.Generic;
    /// <summary>
    /// Low-level API implementation for the Nutanix Intentful API service.
    /// </summary>
    public class NutanixIntentfulAPI
    {
        /// <summary>
        /// Together with the AcceptAllCertifications method right
        /// below this causes to bypass errors caused by SLL-Errors.
        /// </summary>
        public static void IgnoreBadCertificates() {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            System.Net.ServicePointManager.CheckCertificateRevocationList = false;
        }

        /// <summary>
        /// In Short: the Method solves the Problem of broken Certificates.
        /// Sometime when requesting Data and the sending Webserverconnection
        /// is based on a SSL Connection, an Error is caused by Servers whoes
        /// Certificate(s) have Errors. Like when the Cert is out of date
        /// and much more... So at this point when calling the method,
        /// this behaviour is prevented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns>true</returns>
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors){
         return true;
        }

        /// <summary>
        /// This operation submits a request to update a IMAGE based on the input parameters.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a image</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task UpdateImage(string uuid, Nutanix.Powershell.Models.IImageIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.UpdateImage_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref="UpdateImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>This operation gets a IMAGE.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetImage(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetImage_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// This operation gets a list of IMAGEs, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetImages(Nutanix.Powershell.Models.IImageListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetImages_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetImages" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetImages_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>This operation submits a request to delete a IMAGE.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteImage(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteImage_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
       /// <summary>This operation submits a request to delete a IMAGE.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteImage_Sync(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteImage_Call_Sync(request,onAccepted,onDefault,eventListener,sender, credential);
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteImage_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.IImageIntentResponse _imageTask = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _imageTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

                Nutanix.Powershell.Models.ITaskStatus _task = null;
                var retry = new RetryWithExponentialBackoff();
                await retry.RunAsync(async () =>
                {
                    _task = await GetTaskStatus(_imageTask.Status.ExecutionContext.TaskUuid , eventListener, sender, credential);
                     if (_task.State !=  "SUCCEEDED")
                     {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                     }
                });
            }
        }
        /// <summary>Downloads the image based on the UUID specified.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Images(string uuid, string path, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<System.IO.Stream>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3/images/"
                        + System.Uri.EscapeDataString(uuid)
                        + "/file"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                // Set the content
                var fileBytes = System.IO.File.ReadAllBytes(path);
                request.Content = new System.Net.Http.ByteArrayContent(fileBytes);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream");

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.Images_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>
        /// This operation gets a list of Tasks, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetTaskList(Nutanix.Powershell.Models.ITaskListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//tasks/list"
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // make the call
                await this.GetTaskList_Call(request, onOK, onDefault, eventListener, sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetTaskList" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetTaskList_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using (NoSynchronizationContext)
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onOK(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>This operation gets a Task.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetTask(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITask>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//tasks/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // make the call
                await this.GetTask_Call(request, onOK, onNotFound, onDefault, eventListener, sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetTask" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetTask_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITask>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using (NoSynchronizationContext)
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onOK(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.Task.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        case System.Net.HttpStatusCode.NotFound:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onNotFound(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Poll for completion of tasks</summary>
        /// <param name="body">Input for a task poll</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewPoll(Nutanix.Powershell.Models.ITaskPollInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskPollResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//tasks/poll"
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if (eventListener.Token.IsCancellationRequested) { return; }
                // make the call
                await this.NewPoll_Call(request, onOK, onDefault, eventListener, sender);
            }
        }
        /// <summary>Actual wire call for <see cref="NewPoll" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewPoll_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskPollResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using (NoSynchronizationContext)
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onOK(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskPollResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return; }
                                await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="Images" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Images_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<System.IO.Stream>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,null /* deserializeFromResponse doesn't support 'application/octet-stream' C:\Users\hugo1\Documents\repositories\autorest.incubator\dist\csharp\schema\binary.js*/);
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,null /* deserializeFromResponse doesn't support '-none-' C:\Users\hugo1\Documents\repositories\autorest.incubator\dist\csharp\schema\object.js*/);
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Images are raw ISO, QCOW2, or VMDK files that are uploaded by a user can be attached to a VM. An ISO image is attached
        /// as a virtual CD-ROM drive, and QCOW2 and VMDK files are attached as SCSI disks. An image has to be explicitly added to
        /// the self-service catalog before users can create VMs from it.
        /// </summary>
        /// <param name="body">An intentful representation of a image</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewImage(Nutanix.Powershell.Models.IImageIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NewImage_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>
        /// Images are raw ISO, QCOW2, or VMDK files that are uploaded by a user can be attached to a VM. An ISO image is attached
        /// as a virtual CD-ROM drive, and QCOW2 and VMDK files are attached as SCSI disks. An image has to be explicitly added to
        /// the self-service catalog before users can create VMs from it.
        /// </summary>
        /// <param name="body">An intentful representation of a image</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewImage_Sync(Nutanix.Powershell.Models.IImageIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault,  System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onOK,Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NewImage_Call_Sync(request,onAccepted,onDefault,onOK,eventListener,sender, credential);
            }
        }
        /// <summary>Actual wire call for <see cref="NewImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewImage_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
         /// <summary>Actual wire call for <see cref="NewImage" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewImage_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault,  System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResponse>, System.Threading.Tasks.Task> onOK,Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.IImageIntentResponse _imageTask = null;

                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _imageTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

                var retry = new RetryWithExponentialBackoff(100,200,600000);
                await retry.RunAsync(async () =>
                {
                    var _task = await GetTaskStatus(_imageTask.Status.ExecutionContext.TaskUuid, eventListener, sender, credential);
                    if (_task.State !=  "SUCCEEDED")
                    {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                    }

                });

                await this.GetImage(_imageTask.Metadata.Uuid, onOK, onDefault, eventListener, sender, credential);
            }

        }
        /// <summary>
        /// Validation method for <see cref="NewImage" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="body">An intentful representation of a image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewImage_Validate(Nutanix.Powershell.Models.IImageIntentInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>
        /// Submits a request to create a task handling image migration operation, returns a task reference. This moves ownership
        /// of images from the PE cluster to PC. Image uuids can be obtained by querying the PE instance to list images on the PE.
        /// In the case where image uuid list is provided as empty, all images on the cluster that are not currently migrated to PC
        /// will be migrated to PC.
        /// </summary>
        /// <param name="body">Specify the cluster and image(s) from the cluster to migrate to PC
        /// </param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewMigrate(Nutanix.Powershell.Models.IImageMigrateInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralErrorResponse>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images/migrate"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NewMigrate_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="NewMigrate" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewMigrate_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IProceduralErrorResponse>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ProceduralResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ProceduralErrorResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// This operation gets a list of Access Control Policies, allowing for sorting and pagination. Note: Entities that have not
        /// been created successfully are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListOperation(Nutanix.Powershell.Models.IAccessControlPolicyListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        "http://{url}/api/nutanix/v3//access_control_policies/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListOperation_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListOperation" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListOperation_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IAccessControlPolicyStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.AccessControlPolicyListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.AccessControlPolicyStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListOperation" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListOperation_Validate(Nutanix.Powershell.Models.IAccessControlPolicyListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>Displays the user currently logged in.</summary>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Users(System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        "http://{url}/api/nutanix/v3//users/me"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.Users_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>This operation submits a request to delete a VM.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteVm(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IDeleteTask>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                IgnoreBadCertificates();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteVm_Call(request,onAccepted,onNotFound,onDefault,eventListener,sender);
            }
        }

        /// <summary>This operation submits a request to delete a VM.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteVm_Sync(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IDeleteTask>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                IgnoreBadCertificates();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteVm_Call_Sync(request,onAccepted,onNotFound,onDefault,eventListener,sender, credential);
            }
        }
        /// <summary>
        /// This operation submits a request to create a VM based on the input parameters.
        /// </summary>
        /// <param name="body">An intentful representation of a vm</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewVm(Nutanix.Powershell.Models.IVmIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NewVm_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }


        /// <summary>
        /// This operation submits a request to create a VM based on the input parameters.
        /// </summary>
        /// <param name="body">An intentful representation of a vm</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NewVm_Sync(Nutanix.Powershell.Models.IVmIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOk,System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound,  Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                System.Console.WriteLine($"{credential.Username}:{CreateString(credential.Password)}");

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                // set body content
                System.Console.WriteLine(body.ToJson(null).ToString());
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                // await this.NewVm_Call(request,onAccepted,onDefault,eventListener,sender);
                await this.NewVm_Call_Sync(request, onAccepted, onOk, onDefault, onNotFound, eventListener, sender, credential);

            }
        }
        /// <summary>Actual wire call for <see cref="Users" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Users_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IUserStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.UserIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.UserStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="Users" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Users_Validate(Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteVm_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IDeleteTask>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.DeleteTask.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref="DeleteVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteVm_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IDeleteTask>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.IDeleteTask _deleteTask = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _deleteTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.DeleteTask.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );


                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

                Nutanix.Powershell.Models.ITaskStatus _task = null;
                var retry = new RetryWithExponentialBackoff();
                await retry.RunAsync(async () =>
                {
                    _task = await GetTaskStatus(_deleteTask.Status.ExecutionContext.TaskUuid , eventListener, sender, credential);
                     if (_task.State !=  "SUCCEEDED")
                     {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                     }
                });

            }
        }
        /// <summary>
        /// This operation gets a list of VMs, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Vms(Nutanix.Powershell.Models.IVmListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.Vms_Call(request,onOK,onDefault,eventListener,sender);
            }
        }

        /// <summary>This operation gets a VM.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetVm(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                IgnoreBadCertificates();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetVm_Call(request,onOK,onNotFound,onDefault,eventListener,sender);
            }
        }
        /// <summary>
        /// This operation gets a list of VMs, allowing for sorting and pagination. Note: Entities that have not been created successfully
        /// are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetVms(Nutanix.Powershell.Models.IVmListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                IgnoreBadCertificates();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");


                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");


                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetVms_Call(request,onOK,onDefault,eventListener,sender);
            }
        }

        public async System.Threading.Tasks.Task ListAllVms(Nutanix.Powershell.Models.IVmListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResource[]>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {

            // set the body to fetch the first
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//vms/list"
                        ).TrimEnd('?','&'));

                var hasNext = true;

                var _itemsPerPage = 100;
                var _totalItems = 0;
                var _offset = 0;

                body.Length = _itemsPerPage;
                body.Offset = _offset;

                List<Nutanix.Powershell.Models.IVmIntentResource> result = new List<Nutanix.Powershell.Models.IVmIntentResource>();
                while (hasNext) {

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // generate request object
                    var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // set body content
                    request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                    request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                    var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // make the call
                    System.Net.Http.HttpResponseMessage _response = null;
                    try
                    {
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                        var _contentType = _response.Content.Headers.ContentType?.MediaType;

                        switch ( _response.StatusCode )
                        {
                            case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                var f = await _response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.VmListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) );
                                result.AddRange(f.Entities);
                                _totalItems = f.Metadata.TotalMatches.Value;

                                _offset += _itemsPerPage;
                                if (_offset >= _totalItems) {
                                    hasNext = false;
                                } else {
                                    body.Offset = _offset;
                                    body.Length = _itemsPerPage;
                                }
                                break;
                            }
                            default:
                            {
                                hasNext = false;
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) ));
                                break;
                            }
                        }
                    }
                    finally
                    {
                        // finally statements
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                        _response?.Dispose();
                        request?.Dispose();
                    }

                }

                System.Func<System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResource[]>> anonfunc = async () => result.ToArray();
                await onOK(null, anonfunc());

            }
        }

        public async System.Threading.Tasks.Task ListAllImages(Nutanix.Powershell.Models.IImageListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResource[]>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {

            // set the body to fetch the first
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//images/list"
                        ).TrimEnd('?','&'));

                var hasNext = true;

                var _itemsPerPage = 100;
                var _totalItems = 0;
                var _offset = 0;

                body.Length = _itemsPerPage;
                body.Offset = _offset;

                List<Nutanix.Powershell.Models.IImageIntentResource> result = new List<Nutanix.Powershell.Models.IImageIntentResource>();
                while (hasNext) {

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // generate request object
                    var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // set body content
                    request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                    request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                    var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // make the call
                    System.Net.Http.HttpResponseMessage _response = null;
                    try
                    {
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                        var _contentType = _response.Content.Headers.ContentType?.MediaType;

                        switch ( _response.StatusCode )
                        {
                            case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                var f = await _response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.ImageListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) );
                                result.AddRange(f.Entities);
                                _totalItems = f.Metadata.TotalMatches.Value;

                                _offset += _itemsPerPage;
                                if (_offset >= _totalItems) {
                                    hasNext = false;
                                } else {
                                    body.Offset = _offset;
                                    body.Length = _itemsPerPage;
                                }
                                break;
                            }
                            default:
                            {
                                hasNext = false;
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.ImageStatus.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) ));
                                break;
                            }
                        }
                    }
                    finally
                    {
                        // finally statements
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                        _response?.Dispose();
                        request?.Dispose();
                    }

                }

                System.Func<System.Threading.Tasks.Task<Nutanix.Powershell.Models.IImageIntentResource[]>> anonfunc = async () => result.ToArray();
                await onOK(null, anonfunc());

            }
        }
        public async System.Threading.Tasks.Task ListAllSecurityRules(Nutanix.Powershell.Models.INetworkSecurityRuleListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResource[]>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {

            // set the body to fetch the first
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules/list"
                        ).TrimEnd('?','&'));

                var hasNext = true;

                var _itemsPerPage = 100;
                var _totalItems = 0;
                var _offset = 0;

                body.Length = _itemsPerPage;
                body.Offset = _offset;

                List<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResource> result = new List<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResource>();
                while (hasNext) {

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // generate request object
                    var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // set body content
                    request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                    request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                    var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // make the call
                    System.Net.Http.HttpResponseMessage _response = null;
                    try
                    {
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                        var _contentType = _response.Content.Headers.ContentType?.MediaType;

                        switch ( _response.StatusCode )
                        {
                            case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                var f = await _response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.NetworkSecurityRuleListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) );
                                result.AddRange(f.Entities);
                                _totalItems = f.Metadata.TotalMatches.Value;

                                _offset += _itemsPerPage;
                                if (_offset >= _totalItems) {
                                    hasNext = false;
                                } else {
                                    body.Offset = _offset;
                                    body.Length = _itemsPerPage;
                                }
                                break;
                            }
                            default:
                            {
                                hasNext = false;
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) ));
                                break;
                            }
                        }
                    }
                    finally
                    {
                        // finally statements
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                        _response?.Dispose();
                        request?.Dispose();
                    }

                }

                System.Func<System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResource[]>> anonfunc = async () => result.ToArray();
                await onOK(null, anonfunc());

            }
        }

        public async System.Threading.Tasks.Task ListAllSubnets(Nutanix.Powershell.Models.ISubnetListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResource[]>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {

            // set the body to fetch the first
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3/subnets/list"
                        ).TrimEnd('?','&'));

                var hasNext = true;

                var _itemsPerPage = 100;
                var _totalItems = 0;
                var _offset = 0;

                body.Length = _itemsPerPage;
                body.Offset = _offset;

                List<Nutanix.Powershell.Models.ISubnetIntentResource> result = new List<Nutanix.Powershell.Models.ISubnetIntentResource>();
                while (hasNext) {

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // generate request object
                    var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // set body content
                    request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                    request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                    var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // make the call
                    System.Net.Http.HttpResponseMessage _response = null;
                    try
                    {
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                        var _contentType = _response.Content.Headers.ContentType?.MediaType;

                        switch ( _response.StatusCode )
                        {
                            case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                var f = await _response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.SubnetListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) );
                                result.AddRange(f.Entities);
                                _totalItems = f.Metadata.TotalMatches.Value;

                                _offset += _itemsPerPage;
                                if (_offset >= _totalItems) {
                                    hasNext = false;
                                } else {
                                    body.Offset = _offset;
                                    body.Length = _itemsPerPage;
                                }
                                break;
                            }
                            default:
                            {
                                hasNext = false;
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) ));
                                break;
                            }
                        }
                    }
                    finally
                    {
                        // finally statements
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                        _response?.Dispose();
                        request?.Dispose();
                    }

                }

                System.Func<System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResource[]>> anonfunc = async () => result.ToArray();
                await onOK(null, anonfunc());

            }
        }

        public async System.Threading.Tasks.Task ListAllClusters(Nutanix.Powershell.Models.IVmListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResource[]>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {

            // set the body to fetch the first
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//clusters/list"
                        ).TrimEnd('?','&'));

                var hasNext = true;

                var _itemsPerPage = 100;
                var _totalItems = 0;
                var _offset = 0;

                body.Length = _itemsPerPage;
                body.Offset = _offset;

                List<Nutanix.Powershell.Models.IClusterIntentResource> result = new List<Nutanix.Powershell.Models.IClusterIntentResource>();
                while (hasNext) {

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // generate request object
                    var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // set body content
                    request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                    request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                    var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                    // make the call
                    System.Net.Http.HttpResponseMessage _response = null;
                    try
                    {
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                        var _contentType = _response.Content.Headers.ContentType?.MediaType;

                        switch ( _response.StatusCode )
                        {
                            case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                var f = await _response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.ClusterListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) );
                                result.AddRange(f.Entities);
                                _totalItems = f.Metadata.TotalMatches.Value;

                                _offset += _itemsPerPage;
                                if (_offset >= _totalItems) {
                                    hasNext = false;
                                } else {
                                    body.Offset = _offset;
                                    body.Length = _itemsPerPage;
                                }
                                break;
                            }
                            default:
                            {
                                hasNext = false;
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                                await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( respBody => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(respBody.Result)) ));
                                break;
                            }
                        }
                    }
                    finally
                    {
                        // finally statements
                        await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                        _response?.Dispose();
                        request?.Dispose();
                    }

                }

                System.Func<System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResource[]>> anonfunc = async () => result.ToArray();
                await onOK(null, anonfunc());

            }
        }

        /// <summary>Actual wire call for <see cref="Vms" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Vms_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="Vms" /> method. Call this like the actual call, but you will get validation events back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task Vms_Validate(Nutanix.Powershell.Models.IVmListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
                /// <summary>Actual wire call for <see cref="GetVms" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetVms_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="NewVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewVm_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="NewVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NewVm_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onAccepted,System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOk,  System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.IVmIntentResponse _vmTask = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _vmTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

                var retry = new RetryWithExponentialBackoff();
                await retry.RunAsync(async () =>
                {
                     var _task = await GetTaskStatus(_vmTask.Status.ExecutionContext.TaskUuid, eventListener, sender, credential);
                     if (_task.State !=  "SUCCEEDED")
                     {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                     }

                });
                await this.GetVm(_vmTask.Metadata.Uuid, onOk, onNotFound, onDefault, eventListener, sender, credential);
            }
        }
        /// <summary>Actual wire call for <see cref="GetVm" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetVm_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.VmStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        // System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus>, System.Threading.Tasks.Task> onNotFound,
        internal async System.Threading.Tasks.Task<Nutanix.Powershell.Models.ITaskStatus> GetTaskStatus(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential) {
                // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//tasks/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return null; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return null; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return null; }
                // make the call
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return null; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                return await _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)));
                            }
                        case System.Net.HttpStatusCode.NotFound:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                // await onNotFound(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                // await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                               break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

            }
            return null;
        }


        internal async System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse> GetSubnet(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential) {
                // Constant Parameters
            using (NoSynchronizationContext)
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//subnets/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?', '&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if (eventListener.Token.IsCancellationRequested) { return null; }

                // generate request object
                var request = new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if (eventListener.Token.IsCancellationRequested) { return null; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if (eventListener.Token.IsCancellationRequested) { return null; }
                // make the call
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if (eventListener.Token.IsCancellationRequested) { return null; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch (_response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                return await _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.SubnetIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)));
                            }
                        case System.Net.HttpStatusCode.NotFound:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                // await onNotFound(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                                break;
                            }
                        default:
                            {
                                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if (eventListener.Token.IsCancellationRequested) { return null; }
                                // await onDefault(_response, _response.Content.ReadAsStringAsync().ContinueWith(body => Nutanix.Powershell.Models.TaskStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result))));
                               break;
                            }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

            }
            return null;
        }


        /// <summary>
        /// This operation submits a request to create a subnet based on the input parameters.
        /// A subnet is a block of IP addresses.
        /// </summary>
        /// <param name="body">An intentful representation of a subnet</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task CreateSubnet(Nutanix.Powershell.Models.ISubnetIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString() +
                        "/api/nutanix/v3/subnets"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.CreateSubnet_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }/// <summary>
        /// This operation submits a request to create a subnet based on the input parameters.
        /// A subnet is a block of IP addresses.
        /// </summary>
        /// <param name="body">An intentful representation of a subnet</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task CreateSubnet_Sync(Nutanix.Powershell.Models.ISubnetIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString() +
                        "/api/nutanix/v3/subnets"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.CreateSubnet_Call_Sync(request, onAccepted, onDefault, onOK, onNotFound, eventListener, sender, credential);
            }
        }
        /// <summary>Actual wire call for <see cref="CreateSubnet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateSubnet_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="CreateSubnet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateSubnet_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.ISubnetIntentResponse _subnetTask = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _subnetTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }


                var retry = new RetryWithExponentialBackoff();
                await retry.RunAsync(async () =>
                {
                     var _task = await GetTaskStatus(_subnetTask.Status.ExecutionContext.TaskUuid, eventListener, sender, credential);
                     if(_task.State == "FAILED")
                     {
                        var _subnet = await GetSubnet(_subnetTask.Metadata.Uuid, eventListener, sender, credential);
                        throw new System.InvalidOperationException($"Task failed {_subnet.Status.MessageList}");
                     } else
                     {
                        if (_task.State !=  "SUCCEEDED")
                        {
                            throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                        }
                     }


                });
                await this.GetSubnet(_subnetTask.Metadata.Uuid, onOK, onNotFound, onDefault, eventListener, sender, credential);

            }
        }
         /// <summary>
        /// Validation method for <see cref="CreateSubnet" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">An intentful representation of a subnet</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateSubnet_Validate(Nutanix.Powershell.Models.ISubnetIntentInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>This operation submits a request to delete a subnet.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteSubnet(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//subnets/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteSubnet_Call(request,onAccepted,onNotFound,onDefault,eventListener,sender);
            }
        }
        /// <summary>This operation submits a request to delete a subnet.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteSubnet_Sync(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//subnets/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));
                

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteSubnet_Call_Sync(request,onAccepted,onNotFound,onDefault,eventListener,sender, credential);
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteSubnet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteSubnet_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteSubnet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteSubnet_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.ISubnetIntentResponse _subnetTask = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }


                Nutanix.Powershell.Models.ITaskStatus _task = null;
                var retry = new RetryWithExponentialBackoff();
                await retry.RunAsync(async () =>
                {
                    _task = await GetTaskStatus(_subnetTask.Status.ExecutionContext.TaskUuid , eventListener, sender, credential);
                     if (_task.State !=  "SUCCEEDED")
                     {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                     }
                });


            }
        }
        /// <summary>
        /// Validation method for <see cref="DeleteSubnet" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteSubnet_Validate(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
            }
        }
        /// <summary>This operation gets a subnet.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetSubnet(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        $"{credential.Uri.ToString()}/api/nutanix/v3//subnets/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);

                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetSubnet_Call(request,onOK,onNotFound,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetSubnet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetSubnet_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="GetSubnet" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetSubnet_Validate(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
            }
        }
        /// <summary>
        /// This operation gets a list of subnets, allowing for sorting and pagination. Note: Entities that have not been created
        /// successfully are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListSubnets(Nutanix.Powershell.Models.ISubnetListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3/subnets/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListSubnets_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListSubnets" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListSubnets_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListSubnets" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListSubnets_Validate(Nutanix.Powershell.Models.ISubnetListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>
        /// This operation submits a request to update a subnet based on the input parameters.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a subnet</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task UpdateSubnet(string uuid, Nutanix.Powershell.Models.ISubnetIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.UpdateSubnet_Call(request,onAccepted,onNotFound,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="UpdateSubnet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onNotFound">a delegate that is called when the remote service returns 404 (NotFound).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateSubnet_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onNotFound, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ISubnetStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.NotFound:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNotFound(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.SubnetStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="UpdateSubnet" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a subnet</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateSubnet_Validate(string uuid, Nutanix.Powershell.Models.ISubnetIntentInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }

         /// <summary>Create or Update a category Key.</summary>
        /// <param name="name"></param>
        /// <param name="body">Category key definition.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onCreated">a delegate that is called when the remote service returns 201 (Created).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task CreateCategoryKey(string name, Nutanix.Powershell.Models.ICategoryKey body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyStatus>, System.Threading.Tasks.Task> onCreated, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/"
                        + System.Uri.EscapeDataString(name)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                System.Console.WriteLine(body.ToJson(null).ToString());
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.CreateCategoryKey_Call(request,onOK,onCreated,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="CreateCategoryKey" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onCreated">a delegate that is called when the remote service returns 201 (Created).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateCategoryKey_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyStatus>, System.Threading.Tasks.Task> onCreated, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryKeyStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.Created:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onCreated(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryKeyStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="CreateCategoryKey" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="body">Category key definition.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateCategoryKey_Validate(string name, Nutanix.Powershell.Models.ICategoryKey body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertMaximumLength(nameof(name),name,64);
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>
        /// Create or Update a category value. Creates when value doesn't exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="body">Category value definition.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onCreated">a delegate that is called when the remote service returns 201 (Created).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task CreateCategoryValue(string name, string value, Nutanix.Powershell.Models.ICategoryValue body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueStatus>, System.Threading.Tasks.Task> onCreated, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/"
                        + System.Uri.EscapeDataString(name)
                        + "/"
                        + System.Uri.EscapeDataString(value)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.CreateCategoryValue_Call(request,onOK,onCreated,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="CreateCategoryValue" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onCreated">a delegate that is called when the remote service returns 201 (Created).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateCategoryValue_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueStatus>, System.Threading.Tasks.Task> onCreated, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryValueStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        case System.Net.HttpStatusCode.Created:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onCreated(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryValueStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="CreateCategoryValue" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="body">Category value definition.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateCategoryValue_Validate(string name, string value, Nutanix.Powershell.Models.ICategoryValue body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertMaximumLength(nameof(name),name,64);
                await eventListener.AssertNotNull(nameof(value),value);
                await eventListener.AssertMaximumLength(nameof(value),value,64);
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>Delete a category Key.</summary>
        /// <param name="name"></param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteCategoryKey(string name, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/"
                        + System.Uri.EscapeDataString(name)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteCategoryKey_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteCategoryKey" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteCategoryKey_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response);
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="DeleteCategoryKey" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteCategoryKey_Validate(string name, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertMaximumLength(nameof(name),name,64);
            }
        }
        /// <summary>Delete a category value.</summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteCategoryValue(string name, string value, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/"
                        + System.Uri.EscapeDataString(name)
                        + "/"
                        + System.Uri.EscapeDataString(value)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteCategoryValue_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteCategoryValue" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteCategoryValue_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response);
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="DeleteCategoryValue" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteCategoryValue_Validate(string name, string value, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertMaximumLength(nameof(name),name,64);
                await eventListener.AssertNotNull(nameof(value),value);
                await eventListener.AssertMaximumLength(nameof(value),value,64);
            }
        }
        /// <summary>Get a category key.</summary>
        /// <param name="name"></param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetCategoryKey(string name, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/"
                        + System.Uri.EscapeDataString(name)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetCategoryKey_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetCategoryKey" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetCategoryKey_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryKeyStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="GetCategoryKey" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetCategoryKey_Validate(string name, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertMaximumLength(nameof(name),name,64);
            }
        }
        /// <summary>Get a category value.</summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetCategoryValue(string name, string value, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/"
                        + System.Uri.EscapeDataString(name)
                        + "/"
                        + System.Uri.EscapeDataString(value)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetCategoryValue_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetCategoryValue" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetCategoryValue_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueStatus>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryValueStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="GetCategoryValue" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetCategoryValue_Validate(string name, string value, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertMaximumLength(nameof(name),name,64);
                await eventListener.AssertNotNull(nameof(value),value);
                await eventListener.AssertMaximumLength(nameof(value),value,64);
            }
        }
        /// <summary>
        /// List the category keys.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListCategoryKeys(Nutanix.Powershell.Models.ICategoryListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyListResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListCategoryKeys_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListCategoryKeys" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListCategoryKeys_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryKeyListResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryKeyListResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListCategoryKeys" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListCategoryKeys_Validate(Nutanix.Powershell.Models.ICategoryListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>
        /// List the values for a specified key.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListCategoryValues(string name, Nutanix.Powershell.Models.ICategoryListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueListResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//categories/"
                        + System.Uri.EscapeDataString(name)
                        + "/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListCategoryValues_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListCategoryValues" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListCategoryValues_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryValueListResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryValueListResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListCategoryValues" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListCategoryValues_Validate(string name, Nutanix.Powershell.Models.ICategoryListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertMaximumLength(nameof(name),name,64);
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>
        /// Get list of entities attached to categories or policies in which categories are used as defined by the filter criteria.
        /// </summary>
        /// <param name="body">Categories query input object.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListEntitiesByCategory(Nutanix.Powershell.Models.ICategoryQueryInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryQueryResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//category/query"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListEntitiesByCategory_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListEntitiesByCategory" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListEntitiesByCategory_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryQueryResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.ICategoryStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryQueryResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.CategoryStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListEntitiesByCategory" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">Categories query input object.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListEntitiesByCategory_Validate(Nutanix.Powershell.Models.ICategoryQueryInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }

        /// <summary>
        /// This operation submits a request to create a Network security rule based on the input parameters.
        /// </summary>
        /// <param name="body">An intentful representation of a network_security_rule</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task CreateSecurityRule(Nutanix.Powershell.Models.INetworkSecurityRuleIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.CreateSecurityRule_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        public async System.Threading.Tasks.Task CreateSecurityRule_Sync(Nutanix.Powershell.Models.INetworkSecurityRuleIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onOK, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.CreateSecurityRule_Call_Sync(request,onAccepted,onDefault,onOK,eventListener,sender,credential);
            }
        }
        /// <summary>Actual wire call for <see cref="CreateSecurityRule" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateSecurityRule_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref="CreateSecurityRule" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateSecurityRule_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onOK,Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse _ruleTask = null;

                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _ruleTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

                var retry = new RetryWithExponentialBackoff(100,200,600000);
                await retry.RunAsync(async () =>
                {
                    var _task = await GetTaskStatus(_ruleTask.Status.ExecutionContext.TaskUuid, eventListener, sender, credential);
                    if (_task.State !=  "SUCCEEDED")
                    {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                    }

                });

                await this.GetSecurityRule(_ruleTask.Metadata.Uuid, onOK, onDefault, eventListener, sender, credential);
            }
        }
        /// <summary>
        /// Validation method for <see cref="CreateSecurityRule" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">An intentful representation of a network_security_rule</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task CreateSecurityRule_Validate(Nutanix.Powershell.Models.INetworkSecurityRuleIntentInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>This operation submits a request to delete a Network security rule.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task DeleteSecurityRule(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Delete, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DeleteSecurityRule_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="DeleteSecurityRule" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteSecurityRule_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="DeleteSecurityRule" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task DeleteSecurityRule_Validate(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
            }
        }
        /// <summary>
        /// This operation gets a list of Network security rules, allowing for sorting and pagination. Note: Entities that have not
        /// been created successfully are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListSecurityRules(Nutanix.Powershell.Models.INetworkSecurityRuleListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListSecurityRules_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListSecurityRules" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListSecurityRules_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListSecurityRules" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListSecurityRules_Validate(Nutanix.Powershell.Models.INetworkSecurityRuleListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>This operation gets a Network security rule.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task NetworkSecurityRules(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.NetworkSecurityRules_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="NetworkSecurityRules" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NetworkSecurityRules_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="NetworkSecurityRules" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task NetworkSecurityRules_Validate(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
            }
        }
        /// <summary>
        /// This operation submits a request to update a Network security rule based on the input parameters.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a network_security_rule</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task UpdateSecurityRule(string uuid, Nutanix.Powershell.Models.INetworkSecurityRuleIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.UpdateSecurityRule_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="UpdateSecurityRule" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateSecurityRule_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="UpdateSecurityRule" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a network_security_rule</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateSecurityRule_Validate(string uuid, Nutanix.Powershell.Models.INetworkSecurityRuleIntentInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }

         /// <summary>This operation gets a Network security rule.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetSecurityRule(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//network_security_rules/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetSecurityRule_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetSecurityRule" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetSecurityRule_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.INetworkSecurityRuleStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.NetworkSecurityRuleStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>This operation gets a cluster.</summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task GetCluster(string uuid, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//clusters/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Get, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.GetCluster_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="GetCluster" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetCluster_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="GetCluster" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task GetCluster_Validate(string uuid, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
            }
        }
        /// <summary>
        /// This operation gets a list of clusters, allowing for sorting and pagination. Note: Entities that have not been created
        /// successfully are not listed.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task ListClusters(Nutanix.Powershell.Models.IClusterListMetadata body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//clusters/list"
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Post, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ListClusters_Call(request,onOK,onDefault,eventListener,sender);
            }
        }
        /// <summary>Actual wire call for <see cref="ListClusters" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOK">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListClusters_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterListIntentResponse>, System.Threading.Tasks.Task> onOK, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOK(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterListIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>
        /// Validation method for <see cref="ListClusters" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="body">All api calls that return a list will have this metadata block as input
        /// </param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task ListClusters_Validate(Nutanix.Powershell.Models.IClusterListMetadata body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
        /// <summary>
        /// This operation submits a request to update a cluster based on the input parameters.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a cluster</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task UpdateCluster(string uuid, Nutanix.Powershell.Models.IClusterIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//clusters/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.UpdateCluster_Call(request,onAccepted,onDefault,eventListener,sender);
            }
        }
        /// <summary>
        /// This operation submits a request to update a cluster based on the input parameters.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a cluster</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async System.Threading.Tasks.Task UpdateCluster_Sync(string uuid, Nutanix.Powershell.Models.IClusterIntentInput body, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onOK,Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var _url = new System.Uri((
                        credential.Uri.ToString()
                        + "/api/nutanix/v3//clusters/"
                        + System.Uri.EscapeDataString(uuid)
                        + ""
                        ).TrimEnd('?','&'));

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.URLCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var request =  new System.Net.Http.HttpRequestMessage(Microsoft.Rest.ClientRuntime.Method.Put, _url);
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{credential.Username}:{CreateString(credential.Password)}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray));
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.RequestCreated, _url); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.HeaderParametersAdded, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new System.Net.Http.StringContent(null != body ? body.ToJson(null).ToString() : @"{}", System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BodyContentSet, _url); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.UpdateCluster_Call_Sync(request,onAccepted,onDefault,onOK,eventListener,sender, credential);
            }
        }
        /// <summary>Actual wire call for <see cref="UpdateCluster" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateCluster_Call(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onAccepted(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }
        /// <summary>Actual wire call for <see cref="UpdateCluster" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onAccepted">a delegate that is called when the remote service returns 202 (Accepted).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Rest.ClientRuntime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateCluster_Call_Sync(System.Net.Http.HttpRequestMessage request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onAccepted, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterStatus>, System.Threading.Tasks.Task> onDefault, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IClusterIntentResponse>, System.Threading.Tasks.Task> onOK ,Microsoft.Rest.ClientRuntime.IEventListener eventListener, Microsoft.Rest.ClientRuntime.ISendAsync sender, Nutanix.Powershell.Models.NutanixCredential credential)
        {
            using( NoSynchronizationContext )
            {
                System.Net.Http.HttpResponseMessage _response = null;
                Nutanix.Powershell.Models.IClusterIntentResponse _clusterTask = null;

                try
                {
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;
                    switch ( _response.StatusCode )
                    {
                        case System.Net.HttpStatusCode.Accepted:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            _clusterTask = await _response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterIntentResponse.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) );
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Nutanix.Powershell.Models.ClusterStatus.FromJson(Carbon.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Rest.ClientRuntime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }

                var retry = new RetryWithExponentialBackoff(100,200,600000);
                await retry.RunAsync(async () =>
                {
                    var _task = await GetTaskStatus(_clusterTask.Status.ExecutionContext.TaskUuid, eventListener, sender, credential);
                    if (_task.State !=  "SUCCEEDED")
                    {
                        throw new System.ApplicationException("Status is not completed", new System.Exception($"Status is {_task.State}"));
                    }

                });

                await this.GetCluster(_clusterTask.Metadata.Uuid, onOK, onDefault, eventListener, sender, credential);
            }
        }
        /// <summary>
        /// Validation method for <see cref="UpdateCluster" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="uuid">The UUID of the entity.</param>
        /// <param name="body">An intentful representation of a cluster</param>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async System.Threading.Tasks.Task UpdateCluster_Validate(string uuid, Nutanix.Powershell.Models.IClusterIntentInput body, Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(uuid),uuid);
                await eventListener.AssertRegEx(nameof(uuid),uuid,@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }

        private static string CreateString(System.Security.SecureString secureString)
        {
            System.IntPtr intPtr = System.IntPtr.Zero;
            if (secureString == null || secureString.Length == 0)
            {
                return string.Empty;
            }
            string result;
            try
            {
                intPtr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
                result = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(intPtr);
            }
            finally
            {
                if (intPtr != System.IntPtr.Zero)
                {
                    System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(intPtr);
                }
            }
            return result;
        }
    }


    internal sealed class RetryWithExponentialBackoff
    {
        public readonly int maxRetries, delayMilliseconds, maxDelayMilliseconds;

        public RetryWithExponentialBackoff(int maxRetries = 50,
            int delayMilliseconds = 200,
            int maxDelayMilliseconds = 2000)
        {
            this.maxRetries = maxRetries;
            this.delayMilliseconds = delayMilliseconds;
            this.maxDelayMilliseconds = maxDelayMilliseconds;
        }

        public async System.Threading.Tasks.Task RunAsync(System.Func<System.Threading.Tasks.Task> func)
        {
            ExponentialBackoff backoff = new ExponentialBackoff(this.maxRetries,
                this.delayMilliseconds,
                this.maxDelayMilliseconds);
            retry:
            try
            {
                await func();
            }
            catch (System.Exception ex) when (ex is System.TimeoutException ||
                ex is System.Net.Http.HttpRequestException || ex is System.ApplicationException)
            {
                await backoff.Delay();
                goto retry;
            }
        }
    }

    internal struct ExponentialBackoff
    {
        private readonly int m_maxRetries, m_delayMilliseconds, m_maxDelayMilliseconds;
        private int m_retries, m_pow;

        public ExponentialBackoff(int maxRetries, int delayMilliseconds,
            int maxDelayMilliseconds)
        {
            m_maxRetries = maxRetries;
            m_delayMilliseconds = delayMilliseconds;
            m_maxDelayMilliseconds = maxDelayMilliseconds;
            m_retries = 0;
            m_pow = 1;
        }

        public System.Threading.Tasks.Task Delay()
        {
            if (m_retries == m_maxRetries)
            {
                throw new System.TimeoutException("Max retry attempts exceeded.");
            }
            ++m_retries;
            if (m_retries < 31)
            {
                m_pow = m_pow << 1; // m_pow = Pow(2, m_retries - 1)
            }
            int delay = System.Math.Min(m_delayMilliseconds * (m_pow - 1) / 2,
                m_maxDelayMilliseconds);
            return System.Threading.Tasks.Task.Delay(delay);
        }
    }
}