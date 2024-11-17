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
    /// An allocation created via a join code.
    /// </summary>
    [Preserve]
    [DataContract(Name = "JoinAllocation")]
    public class JoinAllocation
    {
        /// <summary>
        /// An allocation created via a join code.
        /// </summary>
        /// <param name="allocationId">The unique ID of the allocation.</param>
        /// <param name="serverEndpoints">Connection endpoints for the assigned Relay server. &gt; __Note:__ The order of server endpoints is not guaranteed and users should iterate over the items and look for the desired values.</param>
        /// <param name="relayServer">relayServer param</param>
        /// <param name="key">A base64-encoded key required for the HMAC signature of the &#x60;BIND&#x60; message.</param>
        /// <param name="connectionData">A base64-encoded representation of an encrypted connection data blob describing this allocation. This data is equired for establishing communication with other players.</param>
        /// <param name="allocationIdBytes">A base64-encoded form of the allocation ID. When decoded, this is the exact expected byte alignment to use when crafting Relay protocol messages that require the allocation ID. For example, &#x60;PING&#x60;, &#x60;CONNECT&#x60;, &#x60;RELAY&#x60;, and &#x60;CLOSE&#x60; message types.</param>
        /// <param name="region">The allocation region.</param>
        /// <param name="hostConnectionData">A base64-encoded representation of an encrypted connection data blob describing the allocation and Relay server of the player who created the join code. Connecting players can use this data to establish communication with the host player.</param>
        [Preserve]
        public JoinAllocation(System.Guid allocationId, List<RelayServerEndpoint> serverEndpoints, RelayServer relayServer, byte[] key, byte[] connectionData, byte[] allocationIdBytes, string region, byte[] hostConnectionData)
        {
            AllocationId = allocationId;
            ServerEndpoints = serverEndpoints;
            RelayServer = relayServer;
            Key = key;
            ConnectionData = connectionData;
            AllocationIdBytes = allocationIdBytes;
            Region = region;
            HostConnectionData = hostConnectionData;
        }

        /// <summary>
        /// The unique ID of the allocation.
        /// </summary>
        [Preserve]
        [DataMember(Name = "allocationId", IsRequired = true, EmitDefaultValue = true)]
        public System.Guid AllocationId{ get; }

        /// <summary>
        /// Connection endpoints for the assigned Relay server. &gt; __Note:__ The order of server endpoints is not guaranteed and users should iterate over the items and look for the desired values.
        /// </summary>
        [Preserve]
        [DataMember(Name = "serverEndpoints", IsRequired = true, EmitDefaultValue = true)]
        public List<RelayServerEndpoint> ServerEndpoints{ get; }

        /// <summary>
        /// Parameter relayServer of JoinAllocation
        /// </summary>
        [Preserve]
        [DataMember(Name = "relayServer", IsRequired = true, EmitDefaultValue = true)]
        public RelayServer RelayServer{ get; }

        /// <summary>
        /// A base64-encoded key required for the HMAC signature of the &#x60;BIND&#x60; message.
        /// </summary>
        [Preserve]
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        public byte[] Key{ get; }

        /// <summary>
        /// A base64-encoded representation of an encrypted connection data blob describing this allocation. This data is equired for establishing communication with other players.
        /// </summary>
        [Preserve]
        [DataMember(Name = "connectionData", IsRequired = true, EmitDefaultValue = true)]
        public byte[] ConnectionData{ get; }

        /// <summary>
        /// A base64-encoded form of the allocation ID. When decoded, this is the exact expected byte alignment to use when crafting Relay protocol messages that require the allocation ID. For example, &#x60;PING&#x60;, &#x60;CONNECT&#x60;, &#x60;RELAY&#x60;, and &#x60;CLOSE&#x60; message types.
        /// </summary>
        [Preserve]
        [DataMember(Name = "allocationIdBytes", IsRequired = true, EmitDefaultValue = true)]
        public byte[] AllocationIdBytes{ get; }

        /// <summary>
        /// The allocation region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "region", IsRequired = true, EmitDefaultValue = true)]
        public string Region{ get; }

        /// <summary>
        /// A base64-encoded representation of an encrypted connection data blob describing the allocation and Relay server of the player who created the join code. Connecting players can use this data to establish communication with the host player.
        /// </summary>
        [Preserve]
        [DataMember(Name = "hostConnectionData", IsRequired = true, EmitDefaultValue = true)]
        public byte[] HostConnectionData{ get; }

        /// <summary>
        /// Formats a JoinAllocation into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (AllocationId != null)
            {
                serializedModel += "allocationId," + AllocationId + ",";
            }
            if (ServerEndpoints != null)
            {
                serializedModel += "serverEndpoints," + ServerEndpoints.ToString() + ",";
            }
            if (RelayServer != null)
            {
                serializedModel += "relayServer," + RelayServer.ToString() + ",";
            }
            if (Key != null)
            {
                serializedModel += "key," + Key.ToString() + ",";
            }
            if (ConnectionData != null)
            {
                serializedModel += "connectionData," + ConnectionData.ToString() + ",";
            }
            if (AllocationIdBytes != null)
            {
                serializedModel += "allocationIdBytes," + AllocationIdBytes.ToString() + ",";
            }
            if (Region != null)
            {
                serializedModel += "region," + Region + ",";
            }
            if (HostConnectionData != null)
            {
                serializedModel += "hostConnectionData," + HostConnectionData.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a JoinAllocation as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (AllocationId != null)
            {
                var allocationIdStringValue = AllocationId.ToString();
                dictionary.Add("allocationId", allocationIdStringValue);
            }

            if (Key != null)
            {
                var keyStringValue = Key.ToString();
                dictionary.Add("key", keyStringValue);
            }

            if (ConnectionData != null)
            {
                var connectionDataStringValue = ConnectionData.ToString();
                dictionary.Add("connectionData", connectionDataStringValue);
            }

            if (AllocationIdBytes != null)
            {
                var allocationIdBytesStringValue = AllocationIdBytes.ToString();
                dictionary.Add("allocationIdBytes", allocationIdBytesStringValue);
            }

            if (Region != null)
            {
                var regionStringValue = Region.ToString();
                dictionary.Add("region", regionStringValue);
            }

            if (HostConnectionData != null)
            {
                var hostConnectionDataStringValue = HostConnectionData.ToString();
                dictionary.Add("hostConnectionData", hostConnectionDataStringValue);
            }

            return dictionary;
        }
    }
}
