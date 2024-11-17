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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Logs.Http;



namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Logs.Models
{
    /// <summary>
    /// Identifying metadata for a long entry that identifies the event&#39;s origin.
    /// </summary>
    [Preserve]
    [DataContract(Name = "Log_Entry_Metadata")]
    internal class LogEntryMetadata
    {
        /// <summary>
        /// Identifying metadata for a long entry that identifies the event&#39;s origin.
        /// </summary>
        /// <param name="fleetId">ID of the fleet where the log event originates from.</param>
        /// <param name="messageId">Unique ID of the message.</param>
        /// <param name="serverId">ID of the server where the log event originates from.</param>
        /// <param name="source">Source (most likely a path to a file) where the log event was originally written.</param>
        /// <param name="timestamp">Timestamp of log ingestion event, in ISO 8601 format.</param>
        [Preserve]
        public LogEntryMetadata(System.Guid fleetId, string messageId, string serverId, string source, DateTime timestamp)
        {
            FleetId = fleetId;
            MessageId = messageId;
            ServerId = serverId;
            Source = source;
            Timestamp = timestamp;
        }

        /// <summary>
        /// ID of the fleet where the log event originates from.
        /// </summary>
        [Preserve]
        [DataMember(Name = "fleetId", IsRequired = true, EmitDefaultValue = true)]
        public System.Guid FleetId{ get; }

        /// <summary>
        /// Unique ID of the message.
        /// </summary>
        [Preserve]
        [DataMember(Name = "messageId", IsRequired = true, EmitDefaultValue = true)]
        public string MessageId{ get; }

        /// <summary>
        /// ID of the server where the log event originates from.
        /// </summary>
        [Preserve]
        [DataMember(Name = "serverId", IsRequired = true, EmitDefaultValue = true)]
        public string ServerId{ get; }

        /// <summary>
        /// Source (most likely a path to a file) where the log event was originally written.
        /// </summary>
        [Preserve]
        [DataMember(Name = "source", IsRequired = true, EmitDefaultValue = true)]
        public string Source{ get; }

        /// <summary>
        /// Timestamp of log ingestion event, in ISO 8601 format.
        /// </summary>
        [Preserve]
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = true)]
        public DateTime Timestamp{ get; }

        /// <summary>
        /// Formats a LogEntryMetadata into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (FleetId != null)
            {
                serializedModel += "fleetId," + FleetId + ",";
            }
            if (MessageId != null)
            {
                serializedModel += "messageId," + MessageId + ",";
            }
            if (ServerId != null)
            {
                serializedModel += "serverId," + ServerId + ",";
            }
            if (Source != null)
            {
                serializedModel += "source," + Source + ",";
            }
            if (Timestamp != null)
            {
                serializedModel += "timestamp," + Timestamp.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LogEntryMetadata as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (FleetId != null)
            {
                var fleetIdStringValue = FleetId.ToString();
                dictionary.Add("fleetId", fleetIdStringValue);
            }

            if (MessageId != null)
            {
                var messageIdStringValue = MessageId.ToString();
                dictionary.Add("messageId", messageIdStringValue);
            }

            if (ServerId != null)
            {
                var serverIdStringValue = ServerId.ToString();
                dictionary.Add("serverId", serverIdStringValue);
            }

            if (Source != null)
            {
                var sourceStringValue = Source.ToString();
                dictionary.Add("source", sourceStringValue);
            }

            if (Timestamp != null)
            {
                var timestampStringValue = Timestamp.ToString();
                dictionary.Add("timestamp", timestampStringValue);
            }

            return dictionary;
        }
    }
}
