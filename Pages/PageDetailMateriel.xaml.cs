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
    public partial class PageDetailMateriel : ContentPage
    {
        private Materiel UnMat;

        public PageDetailMateriel(Materiel materiel)
        {
            InitializeComponent();
            UnMat = materiel;
            Categorie.Text = UnMat.Categorie;
            Marque.Text = UnMat.Marque;
            Description.Text = UnMat.Description;
            Provenance.Text = UnMat.Provenance;
            Etat.Text = UnMat.Etat;
        }

       

        private void BoutonTest_Clicked(object sender, EventArgs e)
        {
            var Service = new ServicesWeb();
            Service.PostNouvelEmprunt(UnMat.Id);
        }
    }
}