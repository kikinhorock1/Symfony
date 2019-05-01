using System;
using Newtonsoft.Json;

namespace Symfonax
{

    public class RecupListeHistoriqueUser
    {
        [JsonProperty(PropertyName = "idMat")]
        public int idMat;

        [JsonProperty(PropertyName = "description")]
        public string description;

        [JsonProperty(PropertyName = "datePret")]
        public string datePret;

        [JsonProperty(PropertyName = "dateRetourDemander")]
        public string dateRetourDemander;

        [JsonProperty(PropertyName = "dateRetourEffectif")]
        public string dateRetourEffectif;

        [JsonProperty(PropertyName = "incident")]
        public string incident;
    }
}