// Copyright 2018 (c) Nutanix. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the repository root for full license information.
// Purpose: Utility source for 'Nutanix.PowerShell.SDK'
// Author: Nutanix
// Copyright: Nutanix, 2018
// Owner: PowerShell@nutanix.com
// Maintainer(s):
//   Jon Kohler  (Nutanix, JonKohler)
//   Alex Guo    (Nutanix, mallochine)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Management.Automation;

using Newtonsoft.Json;

namespace Nutanix.PowerShell.SDK
{
  public static class NtnxUtil
  {
    public static string Server { get; set; }

    public static HttpClient Client { get; set; }

    // Holds username and password.
    // TODO: might need to GC PSCreds.Password (SecureString) using Dispose
    // method.
    public static PSCredential PSCreds { get; set; }

    // Returns the JSON response a string. Responsibility of caller to parse.
    public static dynamic RestCall(
      string path,
      string requestMethod,
      string requestBody)
    {
      if (string.IsNullOrEmpty(Server) || NtnxUtil.PSCreds == null)
      {
        throw new NtnxException($"Either passed null server ({Server}) or credentials ({NtnxUtil.PSCreds})");
        //return null;
      }

      HttpResponseMessage result;
      var uri = new Uri("https://" + Server + ":9440/api/nutanix/v3/" + path);
      switch (requestMethod)
      {
        case "GET":
          result = Client.GetAsync(uri).Result;
          break;
        case "POST":
          var content = new StringContent(
            requestBody, Encoding.UTF8, "application/json");
          result = Client.PostAsync(uri, content).Result;
          content.Dispose();
          break;
        default:
          throw new NtnxException("Invalid HTTP request method: " +
              requestMethod);
      }

      if (result.IsSuccessStatusCode)
      {
        string resultContent = result.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject(resultContent);
      }
      else
        throw new NtnxException($"REST API request failed with {result.StatusCode}");
    }

    public static T[] FromJson<T>(dynamic json, Func<dynamic, T> creator)
    {
      return ((IEnumerable<T>)Enumerable.Select(json.entities, (Func<dynamic, T>)(entity => creator(entity)))).ToArray();
    }

    public static dynamic PassThroughNonNull(string nullcheck)
    {
      if (String.IsNullOrEmpty(nullcheck))
      {
        return false;
        //throw new NtnxException();
      }

      return true;
    }

    // Return HTTPS header string that will be the auth header for communicating
    // with Nutanix cluster.
    public static string GetAuthHeader()
    {
      var creds = NtnxUtil.PSCreds.GetNetworkCredential();
      string username = creds.UserName;
      string password = creds.Password;
      var encoding = System.Text.Encoding.GetEncoding("UTF-8");
      var encodedAuth = encoding.GetBytes(username + ":" + password);
      string authHeader = System.Convert.ToBase64String(encodedAuth);
      return authHeader;
    }
  }
}
