﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PardakhtYar.Shaparak.Models {
    
    /// <summary>
    /// اطلاعات شبای مشتری
    /// </summary>
    public class ShaparakCustomerIbanInfo {

        [Required, Description("شماره شبا")]
        public string Iban { get; set; }
        
        public string Description { get; set; }

        public string ToJson() => this.SerializeToString();
        
    }
}
