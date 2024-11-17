#if UNITY_EDITOR || ENABLE_RUNTIME_ADMIN_APIS
//-----------------------------------------------------------------------------
// <auto-generated>
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Multiplayer.Editor.Matchmaker.Authoring.AdminApi.Shared;
using UnityEngine.Scripting;

namespace Unity.Services.Multiplayer.Editor.Matchmaker.Authoring.AdminApi.Matchmaker.Model
{
    /// <summary>
    /// Rule
    /// </summary>
    [DataContract(Name = "Rule")]
    [Preserve]
    partial class Rule
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum LessThan for value: LessThan
            /// </summary>
            [EnumMember(Value = "LessThan")]
            LessThan = 1,

            /// <summary>
            /// Enum LessThanEqual for value: LessThanEqual
            /// </summary>
            [EnumMember(Value = "LessThanEqual")]
            LessThanEqual = 2,

            /// <summary>
            /// Enum GreaterThan for value: GreaterThan
            /// </summary>
            [EnumMember(Value = "GreaterThan")]
            GreaterThan = 3,

            /// <summary>
            /// Enum GreaterThanEqual for value: GreaterThanEqual
            /// </summary>
            [EnumMember(Value = "GreaterThanEqual")]
            GreaterThanEqual = 4,

            /// <summary>
            /// Enum Difference for value: Difference
            /// </summary>
            [EnumMember(Value = "Difference")]
            Difference = 5,

            /// <summary>
            /// Enum Equality for value: Equality
            /// </summary>
            [EnumMember(Value = "Equality")]
            Equality = 6,

            /// <summary>
            /// Enum DoubleDifference for value: DoubleDifference
            /// </summary>
            [EnumMember(Value = "DoubleDifference")]
            DoubleDifference = 7,

            /// <summary>
            /// Enum InList for value: InList
            /// </summary>
            [EnumMember(Value = "InList")]
            InList = 8,

            /// <summary>
            /// Enum Intersection for value: Intersection
            /// </summary>
            [EnumMember(Value = "Intersection")]
            Intersection = 9

        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        [Preserve]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name = "source", IsRequired = true, EmitDefaultValue = true)]
        [Preserve]
        public string Source { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [Preserve]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Reference
        /// </summary>
        [DataMember(Name = "reference", EmitDefaultValue = true)]
        [Preserve]
        public ApiObject Reference { get; set; }

        /// <summary>
        /// Gets or Sets Overlap
        /// </summary>
        [DataMember(Name = "overlap", EmitDefaultValue = false)]
        [Preserve]
        public decimal Overlap { get; set; }

        /// <summary>
        /// Gets or Sets EnableRule
        /// </summary>
        [DataMember(Name = "enableRule", EmitDefaultValue = true)]
        [Preserve]
        public bool EnableRule { get; set; }

        /// <summary>
        /// Gets or Sets Not
        /// </summary>
        [DataMember(Name = "not", EmitDefaultValue = true)]
        [Preserve]
        public bool Not { get; set; }

        /// <summary>
        /// Gets or Sets Relaxations
        /// </summary>
        [DataMember(Name = "relaxations", EmitDefaultValue = false)]
        [Preserve]
        public List<RuleRelaxation> Relaxations { get; set; }

        /// <summary>
        /// Gets or Sets ExternalData
        /// </summary>
        [DataMember(Name = "externalData", EmitDefaultValue = false)]
        [Preserve]
        public RuleExternalData ExternalData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rule" /> class.
        /// </summary>
        /// <param name="source">source (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="type">type (required).</param>
        /// <param name="reference">reference.</param>
        /// <param name="overlap">overlap.</param>
        /// <param name="enableRule">enableRule.</param>
        /// <param name="not">not.</param>
        /// <param name="relaxations">relaxations.</param>
        /// <param name="externalData">externalData.</param>
        [Preserve]
        public Rule(string source = default(string), string name = default(string), TypeEnum type = default(TypeEnum), ApiObject reference = default(ApiObject), decimal overlap = default(decimal), bool enableRule = default(bool), bool not = default(bool), List<RuleRelaxation> relaxations = default(List<RuleRelaxation>), RuleExternalData externalData = default(RuleExternalData))
        {
            if (source == null)
            {
                throw new ArgumentNullException("source is a required property for Rule and cannot be null");
            }
            this.Source = source;
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for Rule and cannot be null");
            }
            this.Name = name;
            this.Type = type;
            this.Reference = reference;
            this.Overlap = overlap;
            this.EnableRule = enableRule;
            this.Not = not;
            this.Relaxations = relaxations;
            this.ExternalData = externalData;
        }
    }

}
#endif
