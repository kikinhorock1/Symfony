using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Symfonax
{

    public partial class PageDetailEmprunt : ContentPage
    {
        private empruntHistorique UnEmprunt;

        public PageDetailEmprunt(empruntHistorique emprunt)
        {
            InitializeComponent();
            UnEmprunt = emprunt;
            description.Text = UnEmprunt.Description;
            DatePret.Text = UnEmprunt.DatePret;
            DateRetourDemander.Text = UnEmprunt.DateRetourDemander;
            DateRetourEffectif.Text = UnEmprunt.DateRetourEffectif;
            Incident.Text = UnEmprunt.Incident;
        }
    }
}