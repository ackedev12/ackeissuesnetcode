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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Servers.Http;



namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Servers.Models
{
    /// <summary>
    /// A machine specification.
    /// </summary>
    [Preserve]
    [DataContract(Name = "Machine_Spec")]
    internal class MachineSpec
    {
        /// <summary>
        /// A machine specification.
        /// </summary>
        /// <param name="cpuShortname">Shortname of the CPU.</param>
        /// <param name="cpuSpeed">CPU Speed (MHz) of the machine hosting the server.</param>
        /// <param name="memory">RAM (MiB) of the machine hosting the server.</param>
        /// <param name="contractStartDate">Start date of the server&#39;s machine contract.</param>
        /// <param name="contractEndDate">End date of the server&#39;s machine contract.</param>
        /// <param name="cpuCores">CPU number of cores.</param>
        /// <param name="cpuName">Name of the CPU.</param>
        /// <param name="cpuDetail">Additional detail on the CPU.</param>
        [Preserve]
        public MachineSpec(string cpuShortname, long cpuSpeed, long memory, DateTime contractStartDate, DateTime contractEndDate, long cpuCores, string cpuName, string cpuDetail = default)
        {
            CpuShortname = cpuShortname;
            CpuSpeed = cpuSpeed;
            Memory = memory;
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            CpuCores = cpuCores;
            CpuName = cpuName;
            CpuDetail = cpuDetail;
        }

        /// <summary>
        /// Shortname of the CPU.
        /// </summary>
        [Preserve]
        [DataMember(Name = "cpuShortname", IsRequired = true, EmitDefaultValue = true)]
        public string CpuShortname{ get; }

        /// <summary>
        /// CPU Speed (MHz) of the machine hosting the server.
        /// </summary>
        [Preserve]
        [DataMember(Name = "cpuSpeed", IsRequired = true, EmitDefaultValue = true)]
        public long CpuSpeed{ get; }

        /// <summary>
        /// RAM (MiB) of the machine hosting the server.
        /// </summary>
        [Preserve]
        [DataMember(Name = "memory", IsRequired = true, EmitDefaultValue = true)]
        public long Memory{ get; }

        /// <summary>
        /// Start date of the server&#39;s machine contract.
        /// </summary>
        [Preserve]
        [DataMember(Name = "contractStartDate", IsRequired = true, EmitDefaultValue = true)]
        public DateTime ContractStartDate{ get; }

        /// <summary>
        /// End date of the server&#39;s machine contract.
        /// </summary>
        [Preserve]
        [DataMember(Name = "contractEndDate", IsRequired = true, EmitDefaultValue = true)]
        public DateTime ContractEndDate{ get; }

        /// <summary>
        /// CPU number of cores.
        /// </summary>
        [Preserve]
        [DataMember(Name = "cpuCores", IsRequired = true, EmitDefaultValue = true)]
        public long CpuCores{ get; }

        /// <summary>
        /// Name of the CPU.
        /// </summary>
        [Preserve]
        [DataMember(Name = "cpuName", IsRequired = true, EmitDefaultValue = true)]
        public string CpuName{ get; }

        /// <summary>
        /// Additional detail on the CPU.
        /// </summary>
        [Preserve]
        [DataMember(Name = "cpuDetail", EmitDefaultValue = false)]
        public string CpuDetail{ get; }

        /// <summary>
        /// Formats a MachineSpec into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (CpuShortname != null)
            {
                serializedModel += "cpuShortname," + CpuShortname + ",";
            }
            serializedModel += "cpuSpeed," + CpuSpeed.ToString() + ",";
            serializedModel += "memory," + Memory.ToString() + ",";
            if (ContractStartDate != null)
            {
                serializedModel += "contractStartDate," + ContractStartDate.ToString() + ",";
            }
            if (ContractEndDate != null)
            {
                serializedModel += "contractEndDate," + ContractEndDate.ToString() + ",";
            }
            serializedModel += "cpuCores," + CpuCores.ToString() + ",";
            if (CpuName != null)
            {
                serializedModel += "cpuName," + CpuName + ",";
            }
            if (CpuDetail != null)
            {
                serializedModel += "cpuDetail," + CpuDetail;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a MachineSpec as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (CpuShortname != null)
            {
                var cpuShortnameStringValue = CpuShortname.ToString();
                dictionary.Add("cpuShortname", cpuShortnameStringValue);
            }

            var cpuSpeedStringValue = CpuSpeed.ToString();
            dictionary.Add("cpuSpeed", cpuSpeedStringValue);

            var memoryStringValue = Memory.ToString();
            dictionary.Add("memory", memoryStringValue);

            if (ContractStartDate != null)
            {
                var contractStartDateStringValue = ContractStartDate.ToString();
                dictionary.Add("contractStartDate", contractStartDateStringValue);
            }

            if (ContractEndDate != null)
            {
                var contractEndDateStringValue = ContractEndDate.ToString();
                dictionary.Add("contractEndDate", contractEndDateStringValue);
            }

            var cpuCoresStringValue = CpuCores.ToString();
            dictionary.Add("cpuCores", cpuCoresStringValue);

            if (CpuName != null)
            {
                var cpuNameStringValue = CpuName.ToString();
                dictionary.Add("cpuName", cpuNameStringValue);
            }

            if (CpuDetail != null)
            {
                var cpuDetailStringValue = CpuDetail.ToString();
                dictionary.Add("cpuDetail", cpuDetailStringValue);
            }

            return dictionary;
        }
    }
}
