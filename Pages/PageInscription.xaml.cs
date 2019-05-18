using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Symfonax
{
    public partial class PageInscription : ContentPage
    {
        ServicesWeb services = new ServicesWeb();
        public PageInscription()
        {
            InitializeComponent();
        }


        private async void TestConnexion(string Nom, string Prenom, string Username, string Mail, string Formation, string Passwd)
        {
            var reponse = await services.PostInscription(Nom, Prenom, Username, Mail, Formation, Passwd);

            if (reponse is null)
            {
                Debug.WriteLine("erreur de connexion");

                return;
            }

            if (reponse == "{}")
            {
                Debug.WriteLine("tout roule !");
                //gererAffichage(2);
                return;
            }
            else
            {
                Debug.WriteLine("Ca marche pas mec!");
            }

            //App.Utilisateur = JsonConvert.DeserializeObject<User>(reponse);

            //Changement de page si connexion reussie
            //var Page = new PageOnglets();
            //await Navigation.PushAsync(Page);

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




        private async void ValidationInscription_Clicked(object sender, EventArgs e)
        {
            bool verif = true;
            if (!IsValidEmail(EntryMail.Text))
            {
                EntryMail.BackgroundColor = Color.FromRgb(231, 72, 72);
                EntryMail.PlaceholderColor = Color.Black;
                verif = false;
            }

            if (EntryPassword.Text == null)
            {
                EntryPassword.BackgroundColor = Color.FromRgb(231, 72, 72);
                EntryPassword.PlaceholderColor = Color.Black;
                verif = false;
            }
            else
            {
                if (EntryPassword.Text.Length < 1)
                {
                    EntryPassword.BackgroundColor = Color.FromRgb(231, 72, 72);
                    EntryPassword.PlaceholderColor = Color.Black;
                    verif = false;
                }
            }

            if (EntryPassword2.Text == null)
            {
                EntryPassword2.BackgroundColor = Color.FromRgb(231, 72, 72);
                EntryPassword2.PlaceholderColor = Color.Black;
                verif = false;
            }
            else
            {
                if (EntryPassword2.Text.Length < 1)
                {
                    EntryPassword2.BackgroundColor = Color.FromRgb(231, 72, 72);
                    EntryPassword2.PlaceholderColor = Color.Black;
                    verif = false;
                }
            }

            if (EntryNom.Text == "" || EntryNom.Text == null)
            {
                EntryNom.BackgroundColor = Color.FromRgb(231, 72, 72);
                LabelAideConnexion.Text = "Renseigner les champs manquant";
                LabelAideConnexion.TextColor = Color.Red;
                EntryNom.PlaceholderColor = Color.Black;
                verif = false;
            }

            if (EntryPrenom.Text == "" || EntryPrenom.Text == null)
            {
                EntryPrenom.BackgroundColor = Color.FromRgb(231, 72, 72);
                LabelAideConnexion.Text = "Renseigner les champs manquant";
                LabelAideConnexion.TextColor = Color.Red;
                EntryPrenom.PlaceholderColor = Color.Black;
                verif = false;
            }

            if (EntryUser.Text == "" || EntryUser.Text == null)
            {
                EntryUser.BackgroundColor = Color.FromRgb(231, 72, 72);
                LabelAideConnexion.Text = "Renseigner les champs manquant";
                LabelAideConnexion.TextColor = Color.Red;
                EntryUser.PlaceholderColor = Color.Black;
                verif = false;
            }

            if (EntryFormation.Text == "" || EntryFormation.Text == null)
            {
                EntryFormation.BackgroundColor = Color.FromRgb(231, 72, 72);
                LabelAideConnexion.Text = "Renseigner les champs manquant";
                LabelAideConnexion.TextColor = Color.Red;
                EntryFormation.PlaceholderColor = Color.Black;
                verif = false;
            }

            if (verif)
            {
                if (EntryPassword.Text != EntryPassword2.Text)
                {
                    EntryPassword.BackgroundColor = Color.FromRgb(231, 72, 72);
                    EntryPassword2.BackgroundColor = Color.FromRgb(231, 72, 72);
                    LabelAideConnexion.Text = "les mots de passes sont différent";
                    LabelAideConnexion.TextColor = Color.Red;
                    EntryPassword.PlaceholderColor = Color.Black;
                    EntryPassword2.PlaceholderColor = Color.Black;
                    verif = false;
                }
                else
                {
                    TestConnexion(EntryNom.Text, EntryPrenom.Text, EntryUser.Text, EntryMail.Text, EntryFormation.Text, EntryPassword.Text);
                    await Navigation.PopAsync();
                }

            }

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            entry.BackgroundColor = Color.White;
        }
    }
}

