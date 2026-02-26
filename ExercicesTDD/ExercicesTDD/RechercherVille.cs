using System;
using System.Collections.Generic;
using System.Text;

namespace Exercices
{
    public class RechercherVille
    {
        private List<String> _villes = new List<string>
        {
            "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver",
            "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok",
            "Hong Kong", "Dubaï", "Rome", "Istanbul"
        };

        public class NotFoundException : Exception
        {
            public NotFoundException(string message) : base(message) { }
        }

        public List<String> Rechercher(String mot)

        {
            // Si le texte de la recherche contient moins de 2 caractères, ***Une exception est levée de type NotFoundException***.
            if (mot.Length < 2)
                throw new NotFoundException("Le texte doit contenir au moins 2 caractères.");

            //INITIAL
            throw new NotImplementedException();

        }


    }
}
