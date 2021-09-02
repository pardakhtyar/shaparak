using Newtonsoft.Json;

namespace PardakhtYar.Shaparak {

    public static class Extensions {

        public static string SerializeToString(this object model) 
            => JsonConvert.SerializeObject(model, Formatting.Indented);
        
    }
}
