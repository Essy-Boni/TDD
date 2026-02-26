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
            //INITIAL
            throw new NotImplementedException();

            // Green 1 : Si le texte de la recherche contient moins de 2 caractères, ***Une exception est levée de type NotFoundException***.
            //if (mot.Length < 2)
            //    throw new NotFoundException("Le texte doit contenir au moins 2 caractères.");

            // Green 2 : Si le texte de recherche est égal ou supérieur à 2 caractères, il doit renvoyer tous les noms de ville commençant par le texte de recherche exact.
            //return _villes
            //.Where(v => v.StartsWith(mot))
            //.ToList();

            //Green 3 : La fonctionnalité de recherche doit être insensible à la casse
            //return _villes
            //.Where(v => v.StartsWith(mot, StringComparison.OrdinalIgnoreCase))
            //.ToList();

            //Green 4 : La fonctionnalité de recherche devrait également fonctionner lorsque le texte de recherche n'est qu'une partie d'un nom de ville
            //return _villes
            //.Where(v => v.StartsWith(mot, StringComparison.OrdinalIgnoreCase)|| v.IndexOf(mot, StringComparison.OrdinalIgnoreCase) >= 0)
            //.ToList();

            //Green 5 : Si le texte de recherche est un « * » (astérisque), il doit renvoyer tous les noms de ville.
            //if (mot == "*")
            //    return new List<string>(_villes);



        }

    }
}



