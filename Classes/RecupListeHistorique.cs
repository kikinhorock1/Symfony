using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Symfonax
{

    public class RecupListeHistorique
    {
        [JsonProperty(PropertyName = "ListeEnCours")]
        public List<RecupListeEmpruntEnCours> EmpruntEnCours;

        [JsonProperty(PropertyName = "ListeTermines")]
        public List<RecupListeEmpruntTermines> EmpruntTermines;

    }
}
