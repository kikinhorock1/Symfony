using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Symfonax
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageUtilisateur : ContentPage
	{
		public PageUtilisateur ()
		{
            InitializeComponent();
            Email.Text = App.Utilisateur.Email;
            Nom.Text = App.Utilisateur.Nom;
            Prenom.Text = App.Utilisateur.Prenom;
            Formation.Text = App.Utilisateur.Formation;
            Username.Text = App.Utilisateur.Username;
		}
	}
}