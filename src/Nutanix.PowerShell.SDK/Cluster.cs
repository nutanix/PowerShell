// Copyright 2018 (c) Nutanix. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the repository root for full license information.
// Purpose: Clusters (connection and information) source for 'Nutanix.PowerShell.SDK'
// Author: Nutanix
// Copyright: Nutanix, 2018
// Owner: PowerShell@nutanix.com
// Maintainer(s):
//   Jon Kohler  (Nutanix, JonKohler)
//   Alex Guo    (Nutanix, mallochine)

using System;
using System.Management.Automation;
using System.Net.Http;

namespace Nutanix.PowerShell.SDK
{
  public class Cluster
  {
    public string Name { get; set; }

    public string Uuid { get; set; }

    public Cluster(dynamic json)
    {
      Uuid = json.metadata.uuid;
      Name = json.spec.name;
    }
  }

  [CmdletAttribute(VerbsCommon.Get, "Cluster")]
  public class GetClusterCmdlet : Cmdlet
  {
    protected override void ProcessRecord()
    {
      WriteObject(GetAllClusters());
    }

    // Grab all VMs.
    // REST: /clusters/list
    public static Cluster[] GetAllClusters()
    {
      var json = NtnxUtil.RestCall("clusters/list", "POST", "{}");
      if (json.entities.Count == 0)
      {
        return Array.Empty<Cluster>();
      }

      Cluster[] clusters = new Cluster[json.entities.Count];
      for (int i = 0; i < json.entities.Count; ++i)
      {
        clusters[i] = new Cluster(json.entities[i]);
      }

      return clusters;
    }
  }

  [CmdletAttribute(VerbsCommunications.Connect, "Cluster")]
  public class ConnectClusterCmdlet : Cmdlet
  {
    private bool acceptInvalidSslCerts;

    [Parameter]
    public string Server { get; set; }

    [Parameter]
    public string UserName { get; set; }

    // TODO: note that 'Password' should be the result of
    // 'ConvertTo-SecureString'
    [Parameter]
    public System.Security.SecureString Password { get; set; } =
      new System.Security.SecureString();

    [Parameter]
    public SwitchParameter AcceptInvalidSslCerts
    {
      get { return this.acceptInvalidSslCerts; }
      set { this.acceptInvalidSslCerts = value; }
    }

    // Save authentication info.
    public static void Connect(
      string server,
      string username,
      System.Security.SecureString password,
      bool acceptinvalidsslcerts)
    {
      HttpClientHandler handler = null;

      // Create handle to ignore invalid SSL certificates.
      if (acceptinvalidsslcerts)
      {
        handler = new HttpClientHandler();
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.ServerCertificateCustomValidationCallback =
          (httpRequestMessage, cert, cetChain, policyErrors) =>
          {
            return true;
          };
      }

      NtnxUtil.Server = server;
      NtnxUtil.PSCreds = new System.Management.Automation.PSCredential(
        username, password);

      // Create HttpClient.
      var client = new HttpClient(handler);
      string authHeader = NtnxUtil.GetAuthHeader();
      client.BaseAddress = new Uri("https://" + server + ":9440");
      client.DefaultRequestHeaders.Add("Authorization", "Basic " + authHeader);
      client.DefaultRequestHeaders.Add("Accept", "application/json");
      client.DefaultRequestHeaders.Add(
        "X-Nutanix-Client-Type", "Nutanix.PowerShell.SDK");
      NtnxUtil.Client = client;
    }

    protected override void ProcessRecord()
    {
      Connect(Server, UserName, Password, acceptInvalidSslCerts);
    }
  }
}
