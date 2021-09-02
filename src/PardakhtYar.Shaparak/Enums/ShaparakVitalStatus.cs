using System.ComponentModel;

namespace PardakhtYar.Shaparak {
    
    public enum ShaparakVitalStatus {
        
        [Description("در قید حیات")]
        InLife = 0,
        
        [Description("فوت شده")]
        Departed = 1
    }
}
