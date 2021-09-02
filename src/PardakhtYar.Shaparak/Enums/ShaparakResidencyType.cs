using System.ComponentModel;

namespace PardakhtYar.Shaparak {

    /// <summary>
    /// نوع ملیت
    /// </summary>
    public enum ShaparakResidencyType {
        
        [Description("ایرانی")]
        Iranian = 0,
        
        [Description("غیرایرانی")]
        Foreign = 1
        
    }
}
