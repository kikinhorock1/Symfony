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

        public List<RecupListeHistoriqueUser> resultatWeb;

        public List<empruntHistorique> listeEmprunt;

        public PageListeEmprunts ()
		{
            listeEmprunt = new List<empruntHistorique>();
            InitializeComponent();

            RecuperationHistorique();

		}

        public async void RecuperationHistorique()
        {
            var service = new ServicesWeb();

            List<RecupListeHistoriqueUser> listeHistorique;

            listeHistorique = await service.GetHistoriqueUser(); // on ne passe pas à l'instruction suivante tant
                                                    // que la fonction GetHistoriqueUser() n'est pas terminée

            foreach (RecupListeHistoriqueUser u in listeHistorique)
            {
                Debug.WriteLine("ID mat :  " + u.idMat);
                Debug.WriteLine("Description : "+u.description);
                Debug.WriteLine("Date de pret : " + u.datePret);
                Debug.WriteLine("Date de retour demander: " + u.dateRetourDemander);
                Debug.WriteLine("Date retour effectif : " + u.dateRetourEffectif);
                Debug.WriteLine("Incident : " + u.incident);
                Debug.WriteLine(" ");

                var histo = new empruntHistorique();
                histo.IdMat = u.idMat;
                histo.Description = u.description;
                histo.DatePret = u.datePret;
                histo.DateRetourDemander = u.dateRetourDemander;
                histo.DateRetourEffectif = u.dateRetourEffectif;
                histo.Incident = u.incident;

                listeEmprunt.Add(histo);

            }
            //Debug.WriteLine(listeHistorique.Count);
            CreationFrames();
        }

        private void CreationFrames()
        {

            TapGestureRecognizer tap = new TapGestureRecognizer(); //gestion des evenements de click (Tapper)
            tap.Tapped += Tap_Tapped;

            foreach (var u in listeEmprunt)
            {
                var NouveauObjet = new StackLayout();
                var Label1 = new Label { Text = ""+u.Description };
                var Label2 = new Label { Text = u.DatePret };
                Debug.WriteLine(u.Incident);

                NouveauObjet.Children.Add(Label1);
                NouveauObjet.Children.Add(Label2);


                var Content = new FrameEmprunt
                {
                    Content = NouveauObjet,
                    BorderColor = Color.Silver,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Fill,
                    Emprunt = u
                };

                Content.GestureRecognizers.Add(tap);
                LayoutEmprunt.Children.Add(Content);
            }
        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            var uneFrame = sender as FrameEmprunt;
            Debug.WriteLine(uneFrame.Emprunt.DatePret);
            var Page = new PageDetailEmprunt(uneFrame.Emprunt);

            // On la pose sur la pille
            await Navigation.PushAsync(Page);
        }



    }
}