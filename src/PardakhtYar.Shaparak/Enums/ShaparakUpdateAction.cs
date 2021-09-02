﻿using System.ComponentModel;

namespace PardakhtYar.Shaparak {
    
    /// <summary>
    /// انواع اصلاح در متدها
    /// </summary>
    public enum ShaparakUpdateAction {
        
        [Description("اصلاح")]
        Update = 0,
        
        /// <summary>
        /// این مورد در حال حاضر استفاده نشده و کاربرد آتی دارد.
        /// </summary>
        [Description("حذف یا غیرفعال سازی")]
        Remove = 1,
        
        [Description("بدون تغییر")]
        NoChange = 2
        
    }
}
