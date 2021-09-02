using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PardakhtYar.Shaparak.Models
{
    public class ShaparakRelatedMerchant: ShaparakMerchant {

        /// <summary>
        /// نوع رابطه مشتریان
        /// </summary>
        [Required, Description("نوع رابطه مشتریان")]
        [JsonProperty("relationType")]
        public ShaparakBusinessRelationshipType RelationType { get; set; }

    }
}
