using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symfonax
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int id;

        [JsonProperty(PropertyName = "email")]
        public String Email;

        [JsonProperty(PropertyName = "nom")]
        public String Nom;

        [JsonProperty(PropertyName = "prenom")]
        public String Prenom;

        [JsonProperty(PropertyName = "formation")]
        public String Formation;

        [JsonProperty(PropertyName = "username")]
        public String Username;

    }
}
