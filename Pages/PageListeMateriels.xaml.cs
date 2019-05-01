using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Symfonax
{
    public partial class PageListeMateriels : ContentPage
    {
        public List<RecupListeUser> resultatWeb;
        public List<Materiel> listeMat;

        public PageListeMateriels()
        {
            listeMat = new List<Materiel>();
            InitializeComponent();
            
            Recuperation();
        }

        public async void Recuperation()
        {
            var ser = new ServicesWeb();
            
            List<RecupListeUser> listeUtils;

            listeUtils = await ser.GetInfosAsync(); // on ne passe pas à l'instruction suivante tant
                                                    // que la fonction GetInfosAsync() n'est pas terminée

            foreach (RecupListeUser u in listeUtils)
            {
                Debug.WriteLine("ID :  " + u.id);
                Debug.WriteLine("Catégorie : " + u.categorie);
                Debug.WriteLine("Marque : " + u.marque);
                Debug.WriteLine("Description : " + u.description);
                Debug.WriteLine("Etat : " + u.etat);
                Debug.WriteLine(" ");

                var Mat = new Materiel();
                Mat.Id = u.id;
                Mat.Categorie = u.categorie;
                Mat.Marque = u.marque;
                Mat.Description = u.description;
                Mat.Etat = u.etat;
                Mat.Provenance = u.provenance;

                listeMat.Add(Mat);
                Debug.WriteLine(listeMat.Count);
            }

            CreationFrames();

        }

        private void CreationFrames()
        {

            TapGestureRecognizer tap = new TapGestureRecognizer(); //gestion des evenements de click (Tapper)
            tap.Tapped += Tap_Tapped;

            foreach (var u in listeMat)
            {
                var NouveauObjet = new StackLayout();
                var Label1 = new Label { Text = u.Description };
                var Label2 = new Label { Text = u.Marque };

                NouveauObjet.Children.Add(Label1);
                NouveauObjet.Children.Add(Label2);


                var Content = new NouvelleFrame
                {
                    Content = NouveauObjet,
                    BorderColor = Color.Silver,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Fill,
                    Materiel = u
                };

                Content.GestureRecognizers.Add(tap);
                Layout.Children.Add(Content);
            }
        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            var uneFrame = sender as NouvelleFrame;
            Debug.WriteLine(uneFrame.Materiel.Marque);
            var Page = new PageDetailMateriel(uneFrame.Materiel);

            // On la pose sur la pille
            await Navigation.PushAsync(Page);
        }
    }
}
