//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Relay.Http;



namespace Unity.Services.Relay.Models
{
    /// <summary>
    /// Deprecated: Use the serverEndpoints collection instead. Refer to the RelayServerEndpoint object.  The IPv4 connection details of a Relay server.  The Relay server configuration determines the network protocol (currently only UDP) required by this IP address and port combination.
    /// </summary>
    [Preserve]
    [DataContract(Name = "RelayServer")]
    public class RelayServer
    {
        /// <summary>
        /// Deprecated: Use the serverEndpoints collection instead. Refer to the RelayServerEndpoint object.  The IPv4 connection details of a Relay server.  The Relay server configuration determines the network protocol (currently only UDP) required by this IP address and port combination.
        /// </summary>
        /// <param name="ipV4">The IPv4 address of the Relay server.</param>
        /// <param name="port">The port number of the Relay server.</param>
        [Preserve]
        public RelayServer(string ipV4, int port)
        {
            IpV4 = ipV4;
            Port = port;
        }

        /// <summary>
        /// The IPv4 address of the Relay server.
        /// </summary>
        [Preserve]
        [DataMember(Name = "ipV4", IsRequired = true, EmitDefaultValue = true)]
        public string IpV4{ get; }

        /// <summary>
        /// The port number of the Relay server.
        /// </summary>
        [Preserve]
        [DataMember(Name = "port", IsRequired = true, EmitDefaultValue = true)]
        public int Port{ get; }

        /// <summary>
        /// Formats a RelayServer into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (IpV4 != null)
            {
                serializedModel += "ipV4," + IpV4 + ",";
            }
            serializedModel += "port," + Port.ToString();
            return serializedModel;
        }

        /// <summary>
        /// Returns a RelayServer as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (IpV4 != null)
            {
                var ipV4StringValue = IpV4.ToString();
                dictionary.Add("ipV4", ipV4StringValue);
            }

            var portStringValue = Port.ToString();
            dictionary.Add("port", portStringValue);

            return dictionary;
        }
    }
}
