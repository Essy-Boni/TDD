using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        private readonly List<CartItem> _items = new(); // Un panier nouvellement créé contient 0 article.
        
        private decimal? _discountPercentage;

        public int GetItemCount() => _items.Count; 

        public void AddItem(string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name)) // `name` ne peut pas être null, vide ou uniquement des espaces.
            {
                throw new ArgumentException("Le nom de l'article ne peut être vide ou ne contenir que des espaces");
            }

            if (price <= 0) //`price` doit être strictement > 0.
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            }

            if (quantity <= 0) //`quantity` doit être strictement > 0.
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            }

            //Bonus 1 : si un article existe déjà avec ce `name` mais un autre `price`, on lève une exception (ex: `InvalidOperationException`).
            var SameName = _items.FirstOrDefault(i =>
            string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase));

            if (SameName is not null && SameName.Price != price)
            throw new InvalidOperationException("Un article avec le même nom et un prix différent n'est pas autorisé");

            // Bonus 2: plafond du total avant remise (GrossTotal) != total dans GetTotal() qui prend en compte les remises
            const decimal MaxTotal = 1000.00m;
            decimal GrossTotal = _items.Sum(i => i.Price * i.Quantity);
            decimal NewLineTotal = price * quantity; // variable qui stocke le montant total de l'article qu'on veut ajouter sert uniquement à la vérification suivante. 

            if (GrossTotal + NewLineTotal> MaxTotal)
                throw new InvalidOperationException("Le total avant remise ne peut excéder 1000");

            _items.Add(new CartItem(name, price, quantity)); //Le panier permet d'ajouter des articles

        }

        public void ApplyDiscount(decimal percentage)
        {
            if (_items.Count == 0) throw new InvalidOperationException(); // Le panier ne doit pas être vide.
            if (percentage < 0 || percentage > 100) throw new ArgumentOutOfRangeException(nameof(percentage)); // Le pourcentage doit être compris entre 0 et 100 inclus.
            if (_discountPercentage is not null) throw new InvalidOperationException(); //La remise ne peut être appliquée qu’une seule fois.

            _discountPercentage = percentage;
        }

        public decimal GetTotal()
        {
            var total = _items.Sum(i => i.Price * i.Quantity); // Total = somme de `price × quantity` sur tous les articles.
            if (_discountPercentage is null) return total; //Appliquer 0% ne change rien.

            return total * (1m - _discountPercentage.Value / 100m); //Une fois la remise appliquée, le total retourné par `GetTotal()` doit être réduit en conséquence.
        }


    }
}
