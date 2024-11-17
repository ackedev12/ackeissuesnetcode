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
    /// A build configuration associated with the fleet.
    /// </summary>
    [Preserve]
    [DataContract(Name = "multiplay.fleetBuildConfiguration")]
    internal class MultiplayFleetBuildConfiguration
    {
        /// <summary>
        /// A build configuration associated with the fleet.
        /// </summary>
        /// <param name="id">ID of the build configuration.</param>
        /// <param name="name">Name of the build configuration.</param>
        /// <param name="buildID">ID of the build associated with the build configuration.</param>
        /// <param name="buildName">Name of the build associated with the build configuration.</param>
        [Preserve]
        public MultiplayFleetBuildConfiguration(long id, string name, long buildID, string buildName)
        {
            Id = id;
            Name = name;
            BuildID = buildID;
            BuildName = buildName;
        }

        /// <summary>
        /// ID of the build configuration.
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public long Id{ get; }

        /// <summary>
        /// Name of the build configuration.
        /// </summary>
        [Preserve]
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name{ get; }

        /// <summary>
        /// ID of the build associated with the build configuration.
        /// </summary>
        [Preserve]
        [DataMember(Name = "buildID", IsRequired = true, EmitDefaultValue = true)]
        public long BuildID{ get; }

        /// <summary>
        /// Name of the build associated with the build configuration.
        /// </summary>
        [Preserve]
        [DataMember(Name = "buildName", IsRequired = true, EmitDefaultValue = true)]
        public string BuildName{ get; }

        /// <summary>
        /// Formats a MultiplayFleetBuildConfiguration into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            serializedModel += "id," + Id.ToString() + ",";
            if (Name != null)
            {
                serializedModel += "name," + Name + ",";
            }
            serializedModel += "buildID," + BuildID.ToString() + ",";
            if (BuildName != null)
            {
                serializedModel += "buildName," + BuildName;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a MultiplayFleetBuildConfiguration as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            var idStringValue = Id.ToString();
            dictionary.Add("id", idStringValue);

            if (Name != null)
            {
                var nameStringValue = Name.ToString();
                dictionary.Add("name", nameStringValue);
            }

            var buildIDStringValue = BuildID.ToString();
            dictionary.Add("buildID", buildIDStringValue);

            if (BuildName != null)
            {
                var buildNameStringValue = BuildName.ToString();
                dictionary.Add("buildName", buildNameStringValue);
            }

            return dictionary;
        }
    }
}
