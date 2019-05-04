using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Symfonax
{
    public struct Emprunt
    {
        public int idMat { get; set; }
        public string description { get; set; }
        public string datePret { get; set; }
        public string dateRetourDemander { get; set; }
        public string dateRetourEffectif { get; set; }
        public string incident { get; set; }

        public Emprunt(int IdMat, string Description, string DatePret, string DateRetourDemander, string DateRetourEffectif, string Incident)
        {
            idMat = IdMat;
            description = Description;
            datePret = DatePret;
            dateRetourDemander = DateRetourDemander;
            dateRetourEffectif = DateRetourEffectif;
            incident = Incident;
        }

    }

    public class FrameEmprunt : Frame
    {
        private Emprunt emprunt;

        public Emprunt Emprunt { get => emprunt; set => emprunt = value; }
    }
}
