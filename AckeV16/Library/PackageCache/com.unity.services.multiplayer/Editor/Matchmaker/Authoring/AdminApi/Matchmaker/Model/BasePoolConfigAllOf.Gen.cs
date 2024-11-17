#if UNITY_EDITOR || ENABLE_RUNTIME_ADMIN_APIS
//-----------------------------------------------------------------------------
// <auto-generated>
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Multiplayer.Editor.Matchmaker.Authoring.AdminApi.Matchmaker.Model
{
    /// <summary>
    /// BasePoolConfigAllOf
    /// </summary>
    [DataContract(Name = "BasePoolConfig_allOf")]
    [Preserve]
    partial class BasePoolConfigAllOf
    {
        /// <summary>
        /// Gets or Sets Variants
        /// </summary>
        [DataMember(Name = "variants", EmitDefaultValue = false)]
        [Preserve]
        public List<PoolConfig> Variants { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePoolConfigAllOf" /> class.
        /// </summary>
        /// <param name="variants">variants.</param>
        [Preserve]
        public BasePoolConfigAllOf(List<PoolConfig> variants = default(List<PoolConfig>))
        {
            this.Variants = variants;
        }
    }

}
#endif