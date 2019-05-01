using System;
namespace Symfonax
{
    public class empruntHistorique
    {
        private int idMat;
        private string description;
        private string datePret;
        private string dateRetourDemander;
        private string dateRetourEffectif;
        private string incident;

        public string DatePret { get => datePret; set => datePret = value; }
        public string DateRetourDemander { get => dateRetourDemander; set => dateRetourDemander = value; }
        public string DateRetourEffectif { get => dateRetourEffectif; set => dateRetourEffectif = value; }
        public int IdMat { get => idMat; set => idMat = value; }
        public string Incident { get => incident; set => incident = value; }
        public string Description { get => description; set => description = value; }
    }
}
