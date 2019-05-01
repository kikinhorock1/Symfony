using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Symfonax
{
    class ServicesWeb
    {
        private HttpClient Client;
        public string ligne;

        public ServicesWeb()
        {
            Client = new HttpClient();
            Client.MaxResponseContentBufferSize = 2000000000000000000;

        }

        // async on lance un nouveau thread 
        public async Task<List<RecupListeUser>> GetInfosAsync()
        {
            Uri uri = new Uri("https://kroko.ovh/~soares/TestSymfony/public/index.php/listeUserMobile");

            var ReponseServeur = await Client.GetAsync(uri);

            if (ReponseServeur.IsSuccessStatusCode)
            {
                var Donnees = await ReponseServeur.Content.ReadAsStringAsync();
                //Debug.WriteLine(Donnees); affiche le retour du Json 
                //return Donnees;
                List<RecupListeUser> listeUnites = JsonConvert.DeserializeObject<List<RecupListeUser>>(Donnees);
                return listeUnites;

            }
            else
            {
                Debug.WriteLine("ça marche app");
            }
            return null;
        }

        public async void PostNouvelEmprunt(int idMat)
        {
            // si on veut envoyer un objet il faut utiliser JsonConvert.SerializeObject(OBJET);

            string json = JsonConvert.SerializeObject(new
            {
                idMateriel = idMat,
                idUser = App.Utilisateur.id
            });

            Uri url = new Uri(string.Format("https://kroko.ovh/~soares/TestSymfony/public/index.php/TestUser"));

            string response = await Post(url, json);

            if (response != null)
            {
                Debug.WriteLine(response);
            }
            else
            {
                Debug.WriteLine("Nop");
            }
        }

        public async Task<string> PostConnexion(string username, string passwd)
        {
            string json = JsonConvert.SerializeObject(new
            {
                identifiant = username,
                mdp = passwd
            });

            Uri url = new Uri(string.Format("https://kroko.ovh/~soares/TestSymfony/public/index.php/connexionMobile"));

            string response = await Post(url, json);

            if (response != null)
            {
                Debug.WriteLine(response);
                return response;
            }
            else
            {
                Debug.WriteLine("Test connexion fail");
                return null;
            }
        }

        private async Task<string> Post(Uri url, string value)
        {
            var request = HttpWebRequest.Create(url);
            var byteData = Encoding.ASCII.GetBytes(value);
            request.ContentType = "application/json";
            request.Method = "POST";

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (WebException e)
            {
                return null;
            }
        }


        // async on lance la fonction pour récupérer liste historique user
        public async Task<List<RecupListeHistoriqueUser>> GetHistoriqueUser()
        {

            string json = JsonConvert.SerializeObject(new
            {
                idUser = App.Utilisateur.id
            });

            Uri url = new Uri(string.Format("https://kroko.ovh/~soares/TestSymfony/public/index.php/listeEmpruntHistoriqueMobile"));
            string response = await Post(url, json);
           
            var Reponse = await Client.GetAsync(url);

            if (Reponse != null)
            {
                Debug.WriteLine("response "+response);
                Debug.WriteLine("Test " + Reponse);


                    var Donnees = await Reponse.Content.ReadAsStringAsync();

               
                List<RecupListeHistoriqueUser> listeHisto = JsonConvert.DeserializeObject<List<RecupListeHistoriqueUser>>(response);
                Debug.WriteLine(listeHisto);
                    return listeHisto;


            }
            else
            {
                Debug.WriteLine("problème récupération historique");
            }





            return null;
        }


    }
}
