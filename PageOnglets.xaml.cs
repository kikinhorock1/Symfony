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
    public partial class PageOnglets : TabbedPage
    {
        public PageOnglets ()
        {
            this.Children.Add(new PageListeMateriels() { Title = "Emprunter" });
            this.Children.Add(new PageListeEmprunts() { Title = "Historique Emprunts" });
            this.Children.Add(new PageUtilisateur() { Title = "Compte" });
        }
    }
}