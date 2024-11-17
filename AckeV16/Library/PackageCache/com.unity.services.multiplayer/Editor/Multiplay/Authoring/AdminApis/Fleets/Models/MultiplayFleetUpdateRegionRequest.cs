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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Fleets.Http;



namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Fleets.Models
{
    /// <summary>
    /// Request to update the settings of a fleet region with the provided configuration.
    /// </summary>
    [Preserve]
    [DataContract(Name = "multiplay.fleetUpdateRegionRequest")]
    internal class MultiplayFleetUpdateRegionRequest
    {
        /// <summary>
        /// Request to update the settings of a fleet region with the provided configuration.
        /// </summary>
        /// <param name="scalingEnabled">Whether scaling is enabled for this fleet region.</param>
        /// <param name="minAvailableServers">Minimum number of servers to keep free for new game sessions.</param>
        /// <param name="maxServers">Maximum number of servers to host in the fleet region.</param>
        /// <param name="deleteTTL">A delete time-to-live in seconds.</param>
        /// <param name="shutdownTTL">A shutdown time-to-live in seconds.</param>
        /// <param name="disabledDeleteTTL">A disabled delete time-to-live in seconds.</param>
        [Preserve]
        public MultiplayFleetUpdateRegionRequest(bool scalingEnabled, long minAvailableServers, long maxServers, long deleteTTL = default, long shutdownTTL = default, long disabledDeleteTTL = default)
        {
            ScalingEnabled = scalingEnabled;
            MinAvailableServers = minAvailableServers;
            MaxServers = maxServers;
            DeleteTTL = deleteTTL;
            ShutdownTTL = shutdownTTL;
            DisabledDeleteTTL = disabledDeleteTTL;
        }

        /// <summary>
        /// Whether scaling is enabled for this fleet region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "scalingEnabled", IsRequired = true, EmitDefaultValue = true)]
        public bool ScalingEnabled{ get; }

        /// <summary>
        /// Minimum number of servers to keep free for new game sessions.
        /// </summary>
        [Preserve]
        [DataMember(Name = "minAvailableServers", IsRequired = true, EmitDefaultValue = true)]
        public long MinAvailableServers{ get; }

        /// <summary>
        /// Maximum number of servers to host in the fleet region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "maxServers", IsRequired = true, EmitDefaultValue = true)]
        public long MaxServers{ get; }

        /// <summary>
        /// A delete time-to-live in seconds.
        /// </summary>
        [Preserve]
        [DataMember(Name = "deleteTTL", EmitDefaultValue = false)]
        public long DeleteTTL{ get; }

        /// <summary>
        /// A shutdown time-to-live in seconds.
        /// </summary>
        [Preserve]
        [DataMember(Name = "shutdownTTL", EmitDefaultValue = false)]
        public long ShutdownTTL{ get; }

        /// <summary>
        /// A disabled delete time-to-live in seconds.
        /// </summary>
        [Preserve]
        [DataMember(Name = "disabledDeleteTTL", EmitDefaultValue = false)]
        public long DisabledDeleteTTL{ get; }

        /// <summary>
        /// Formats a MultiplayFleetUpdateRegionRequest into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            serializedModel += "scalingEnabled," + ScalingEnabled.ToString() + ",";
            serializedModel += "minAvailableServers," + MinAvailableServers.ToString() + ",";
            serializedModel += "maxServers," + MaxServers.ToString() + ",";
            serializedModel += "deleteTTL," + DeleteTTL.ToString() + ",";
            serializedModel += "shutdownTTL," + ShutdownTTL.ToString() + ",";
            serializedModel += "disabledDeleteTTL," + DisabledDeleteTTL.ToString();
            return serializedModel;
        }

        /// <summary>
        /// Returns a MultiplayFleetUpdateRegionRequest as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            var scalingEnabledStringValue = ScalingEnabled.ToString();
            dictionary.Add("scalingEnabled", scalingEnabledStringValue);

            var minAvailableServersStringValue = MinAvailableServers.ToString();
            dictionary.Add("minAvailableServers", minAvailableServersStringValue);

            var maxServersStringValue = MaxServers.ToString();
            dictionary.Add("maxServers", maxServersStringValue);

            var deleteTTLStringValue = DeleteTTL.ToString();
            dictionary.Add("deleteTTL", deleteTTLStringValue);

            var shutdownTTLStringValue = ShutdownTTL.ToString();
            dictionary.Add("shutdownTTL", shutdownTTLStringValue);

            var disabledDeleteTTLStringValue = DisabledDeleteTTL.ToString();
            dictionary.Add("disabledDeleteTTL", disabledDeleteTTLStringValue);

            return dictionary;
        }
    }
}
