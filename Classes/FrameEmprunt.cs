using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Symfonax
{
    class FrameEmprunt : Frame
    {
        private empruntHistorique emprunt = new empruntHistorique();

        public empruntHistorique Emprunt { get => emprunt; set => emprunt = value; }
    }
}
