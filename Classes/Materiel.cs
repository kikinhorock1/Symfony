using System;
namespace Symfonax
{
    public class Materiel
    {
        private int id;
        private string categorie;
        private string marque;
        private string description;
        private string provenance;
        private string etat;
        public int Id { get => id; set => id = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Marque { get => marque; set => marque = value; }
        public string Description { get => description; set => description = value; }
        public string Etat { get => etat; set => etat = value; }
        public string Provenance { get => provenance; set => provenance = value; }
    }

}

