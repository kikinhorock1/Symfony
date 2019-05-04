using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Symfonax
{
	
	public partial class PageListeEmprunts : ContentPage
	{

        public RecupListeHistorique listeHistorique;

        public PageListeEmprunts ()
		{
            InitializeComponent();

            RecuperationHistorique();

		}

        public async void RecuperationHistorique()
        {
            var service = new ServicesWeb();

            //recuperer les données aupres du serveur avec la classe service
            string Donnees = await service.GetHistoriqueUser();       
            Debug.WriteLine("ALOO " + Donnees);

            //deserialisation du json en format classe 
            listeHistorique = JsonConvert.DeserializeObject<RecupListeHistorique>(Donnees);

            CreationFrames();
        }

        private void CreationFrames()
        {

            TapGestureRecognizer tap = new TapGestureRecognizer(); //gestion des evenements de click (Tapper)
            tap.Tapped += Tap_Tapped;

            foreach (var u in listeHistorique.EmpruntTermines)
            {
                var NouveauObjet = new StackLayout();
                var Label1 = new Label { Text = ""+u.description };
                var Label2 = new Label { Text = u.datePret };

                NouveauObjet.Children.Add(Label1);
                NouveauObjet.Children.Add(Label2);
      
                var Content = new FrameEmprunt
                {
                    Content = NouveauObjet,
                    BorderColor = Color.Silver,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Fill,
                    Emprunt = new Emprunt(u.idMat, u.description, u.datePret, u.dateRetourDemander, u.dateRetourEffectif,u.incident)
                };

                Content.GestureRecognizers.Add(tap);
                LayoutEmprunt.Children.Add(Content);
            }

            foreach (var u in listeHistorique.EmpruntEnCours)
            {
                var NouveauObjet = new StackLayout();
                var Label1 = new Label { Text = "" + u.description };
                var Label2 = new Label { Text = u.datePret };

                NouveauObjet.Children.Add(Label1);
                NouveauObjet.Children.Add(Label2);

                var Content = new FrameEmprunt
                {
                    Content = NouveauObjet,
                    BorderColor = Color.Silver,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Fill,
                    Emprunt = new Emprunt(u.idMat,u.description,u.datePret,u.dateRetourDemander,null,null)
                };

                Content.GestureRecognizers.Add(tap);
                Layout2.Children.Add(Content);
            }

        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            var uneFrame = sender as FrameEmprunt;
            Debug.WriteLine(uneFrame.Emprunt);
            var Page = new PageDetailEmprunt(uneFrame.Emprunt);

            // On la pose sur la pille
            await Navigation.PushAsync(Page);
        }



    }
}