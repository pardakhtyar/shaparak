﻿using System.ComponentModel;

namespace PardakhtYar.Shaparak {

    /// <summary>
    /// نوع پذیرنده در سیستم شاپرک
    /// حقیقی = 0
    /// حقوقی = 1
    /// </summary>
    public enum ShaparakMerchantIdentityType {
        
        [Description("حقیقی")]
        Real = 0,

        [Description("حقوقی")]
        Legal = 1
    }
}
