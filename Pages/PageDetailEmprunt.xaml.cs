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
        private Emprunt UnEmprunt;

        public PageDetailEmprunt(Emprunt emprunt)
        {
            InitializeComponent();
            UnEmprunt = emprunt;
            description.Text = UnEmprunt.description;
            DatePret.Text = UnEmprunt.datePret;
            DateRetourDemander.Text = UnEmprunt.dateRetourDemander;
            DateRetourEffectif.Text = UnEmprunt.dateRetourEffectif;
            Incident.Text = UnEmprunt.incident;
        }
    }
}