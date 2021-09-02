﻿using System.ComponentModel;

namespace PardakhtYar.Shaparak {
    
    /// <summary>
    /// نوع فروشگاه در سیستم شاپرک
    /// </summary>
    public enum ShaparakShopType {

        [Description("فروشگاه صرفا فیزیکی")]
        Physical = 0,
        
        [Description("فروشگاه فیزیکی و مجازی")]
        PhysicalAndVirtual = 1,

        [Description("فروشگاه صرفا مجازی")]
        Virtual = 2
        
    }
}
