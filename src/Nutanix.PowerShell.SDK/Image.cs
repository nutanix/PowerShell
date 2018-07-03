// Copyright 2018 (c) Nutanix. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the repository root for full license information.
// Purpose: Images (image service) source for 'Nutanix.PowerShell.SDK'
// Author: Nutanix
// Copyright: Nutanix, 2018
// Owner: PowerShell@nutanix.com
// Maintainer(s):
//   Jon Kohler  (Nutanix, JonKohler)
//   Alex Guo    (Nutanix, mallochine)

using System;
using System.Management.Automation;

using Newtonsoft.Json;

namespace Nutanix.PowerShell.SDK
{
  public class Image
  {
    public string Name { get; set; }

    public string Id { get; set; }

    // 'Uid' is VMware's equivalent field for Nutanix's Uuid.
    public string Uid { get; set; }

    public string Uuid { get; set; }

    public dynamic Json { get; set; }

    // TODO Mtu, NumPorts, ExtensionData, NumPortsAvailable, Key, Nic, VMHostId,
    // VMHost, VMHostUid, Nic
    public Image(dynamic json)
    {
      // Special property 'json' stores the original json.
      this.Json = json;
      this.Json.Property("status").Remove();
      this.Json.api_version = "3.1";

      this.Name = json.spec.name;
      this.Uuid = json.metadata.uuid;
      this.Uid = this.Uuid;
    }
  }

  [CmdletAttribute(VerbsCommon.New, "Image")]
  public class NewImageCmdlet : Cmdlet
  {
    private bool runAsync;

    [Parameter]
    public string Name { get; set; }

    [Parameter]
    public Uri URL { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public SwitchParameter RunAsync
    {
      get { return this.runAsync; }
      set { this.runAsync = value; }
    }

    protected override void ProcessRecord()
    {
      var url = "images";
      var method = "POST";
      var str = @"{
      ""api_version"": ""3.1"",
      ""metadata"": {
        ""kind"": ""image"",
        ""name"": """ + this.Name + @"""
      },
      ""spec"": {
        ""description"": """ + this.Description + @""",
        ""name"": """ + this.Name + @""",
        ""resources"": {
          ""image_type"": ""DISK_IMAGE"",
          ""source_uri"": """ + this.URL + @"""
        }
      }
    }";

      var task = Task.FromUuidInJson(NtnxUtil.RestCall(url, method, str));
      if (this.runAsync)
      {
        WriteObject(task);
      }
      else
      {
        WriteObject(task.Wait());
      }
    }
  }

  [CmdletAttribute(VerbsCommon.Get, "Image")]
  public class GetImageCmdlet : Cmdlet
  {
    [Parameter]
    public string Uuid { get; set; }

    [Parameter]
    public string Name { get; set; }

    [Parameter]
    public int? Max { get; set; }

    protected override void ProcessRecord()
    {
      if (NtnxUtil.PassThroughNonNull(Uuid))
      {
        WriteObject(GetImageByUuid(Uuid));
        return;
      }

      var images = GetAllImages(BuildRequestBody());
      WriteObject(images);
    }

    // Given the parameters, build request body for '/images/list'.
    public dynamic BuildRequestBody()
    {
      dynamic json = JsonConvert.DeserializeObject("{}");
      if (Max != null)
      {
        json.length = Max;
      }

      if (NtnxUtil.PassThroughNonNull(Name))
      {
        json.filter = "name==" + Name;
      }

      return json;
    }

    private static Image GetImageByUuid(string uuid)
    {
      // TODO: validate using UUID regexes that 'uuid' is in correct format.
      var json = NtnxUtil.RestCall("images/" + uuid, "GET", string.Empty /* requestBody */);
      return new Image(json);
    }

    public static Image[] GetImagesByName(string name)
    {
      return GetAllImages("{\"filter\": \"name==" + name + "\"}");
    }

    public static Image[] GetAllImages(dynamic jsonReqBody)
    {
      return GetAllImages(jsonReqBody.ToString());
    }

    public static Image[] GetAllImages(string reqBody)
    {
      return NtnxUtil.FromJson<Image>(NtnxUtil.RestCall("images/list", "POST", reqBody), (Func<dynamic, Image>)(j => new Image(j)));
    }
  }

  [CmdletAttribute(VerbsCommon.Remove, "Image")]
  public class DeleteImageCmdlet : Cmdlet
  {
    [Parameter]
    public string Uuid { get; set; }

    protected override void ProcessRecord()
    {
      if (NtnxUtil.PassThroughNonNull(Uuid))
      {
        // TODO: WriteObject Task
        DeleteImageByUuid(Uuid);
      }
    }

    public static void DeleteImageByUuid(string uuid)
    {
      // TODO: validate using UUID regexes that 'uuid' is in correct format.
      NtnxUtil.RestCall("images/" + uuid, "DELETE", string.Empty /* requestBody */);
    }
  }

  [CmdletAttribute(VerbsCommon.Set, "Image")]
  public class SetImageCmdlet : Cmdlet
  {
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Image Image { get; set; }

    [Parameter]
    public string Name { get; set; }

    [Parameter]
    public SwitchParameter RunAsync
    {
      get { return runAsync; }
      set { runAsync = value; }
    }

    private bool runAsync;

    protected override void ProcessRecord()
    {
      if (Name != null)
      {
        Image.Json.spec.name = Name;
      }

      Image.Json.api_version = "3.1";
      var task = Task.FromUuidInJson(
        NtnxUtil.RestCall("images/" + Image.Uuid, "PUT", Image.Json.ToString()));
      if (runAsync)
      {
        WriteObject(task);
      }
      else
      {
        WriteObject(task.Wait());
      }
    }
  }
}
