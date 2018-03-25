using Newtonsoft.Json;

namespace FinancesApi.Security {
    public class FirebaseUserInfo {

        [JsonProperty(PropertyName = "identities")]
        public FirebaseIdentities Identities { get; set; }

        [JsonProperty(PropertyName = "sign_in_provider")]
        public string SignInProvider { get; set; }
    }

    public class FirebaseIdentities {
        [JsonProperty(PropertyName = "facebook.com")]
        public string[] FacebookDotCom { get; set; }

        [JsonProperty(PropertyName = "google.com")]
        public string[] GoogleDotCom { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string[] Email { get; set; }
    }
}