using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symfonax
{
    public class RecupListeEmpruntEnCours
    {
        [JsonProperty(PropertyName = "idMat")]
        public int idMat;

        [JsonProperty(PropertyName = "description")]
        public string description;

        [JsonProperty(PropertyName = "datePret")]
        public string datePret;

        [JsonProperty(PropertyName = "dateRetourDemander")]
        public string dateRetourDemander;
    }
}
