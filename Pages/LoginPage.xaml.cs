using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Symfonax
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        string stringConnexionErreur = "Erreur de connexion, le mot de passe ou l'email sont incorrects";
        string stringErreurReseau = "Erreur de réseau, veuillez réessayer plus tard";
        string stringLabelGetHelp = "Problèmes de connexion?";

        ServicesWeb services = new ServicesWeb();
		public LoginPage()
		{
			InitializeComponent ();

            TapGestureRecognizer tap = new TapGestureRecognizer(); //gestion des evenements de click (Tapper)
            tap.Tapped += Tap_Inscription;

            InscriptionBouton.GestureRecognizers.Add(tap);
        }

        private async void Tap_Inscription(object sender, EventArgs e)
        {
            var Page = new PageInscription();
            await Navigation.PushAsync(Page);
        }

        private async void TestConnexion(string email, string password)
        {
            var reponse = await services.PostConnexion(email, password);

            if (reponse is null)
            {
                Debug.WriteLine("erreur de connexion");
                gererAffichage(1);
                return;
            }

            if(reponse == "[]")
            {
                Debug.WriteLine("pas le bon mdp ou mail");
                gererAffichage(2);
                return;
            }

            App.Utilisateur = JsonConvert.DeserializeObject<User>(reponse);

            //Changement de page si connexion reussie
            var Page = new PageOnglets();
            await Navigation.PushAsync(Page);

        }

        private void gererAffichage(int v)
        {
            LabelAideConnexion.Text = stringLabelGetHelp;
            LabelErreurConnexion.TextColor = Color.Red;
            if(v == 1)
            {
                LabelErreurConnexion.Text = stringErreurReseau;
            }
            else if(v == 2)
            {
                LabelErreurConnexion.Text = stringConnexionErreur;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ValidationCompte_Clicked(object sender, EventArgs e)
        {
            if (!IsValidEmail(EntryMail.Text))
            {
                EntryMail.BackgroundColor = Color.Red;
                return;
            }

            if (EntryPassword.Text == null)
            {
                EntryPassword.BackgroundColor = Color.Red;
                return;
            }

            if (EntryPassword.Text.Length < 1)
            {
                EntryPassword.BackgroundColor = Color.Red;
                return;
            }

            TestConnexion(EntryMail.Text, EntryPassword.Text);

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            entry.BackgroundColor = Color.White;
        }

    }

}
