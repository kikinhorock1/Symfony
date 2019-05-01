using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Symfonax
{
    class NouvelleFrame : Frame
    {
        private Materiel mat = new Materiel();

        public Materiel Materiel { get => mat; set => mat = value; }
    }
}
