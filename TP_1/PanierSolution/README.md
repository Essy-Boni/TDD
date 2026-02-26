# TP TDD C# Console — Gestion d’un Panier de Courses (MSTest)

## Objectif

Développer une application console C# en appliquant strictement la démarche **TDD (Test Driven Development)** :

1. Écrire les tests unitaires.
2. Lancer les tests (ils échouent, notamment via `NotImplementedException`).
3. Implémenter le minimum pour faire passer les tests.
4. Refactoriser si nécessaire.
5. Vérifier que tous les tests restent verts.


## Structure du projet

La solution contient 3 projets :

- `Panier.Core`  
  Contient la logique métier (classe `ShoppingCart` fournie en starter).

- `Panier.ConsoleApp`  
  Application console utilisant `ShoppingCart` (déjà branchée).

- `Panier.Tests`  
  Projet MSTest : tous les tests sont à écrire.

Aucune logique métier ne doit être implémentée dans `Panier.ConsoleApp`.


## Starter fourni

Le projet `Panier.Core` contient déjà la classe :

- `ShoppingCart`

Cette classe compile, mais **toutes ses méthodes jettent `NotImplementedException`**.

Votre travail consiste à :

* écrire les tests (dans `Panier.Tests`)
* remplacer progressivement les `NotImplementedException` par la vraie implémentation, en suivant le TDD


## Contexte métier

Vous développez un outil interne permettant de simuler un panier de courses.

Le panier doit permettre :

* d’ajouter des articles
* de calculer le total
* d’appliquer une remise
* de contrôler des règles métier strictes

## Spécifications métier

### 1) Ajout d’article

Méthode :

* `AddItem(string name, decimal price, int quantity)`

Règles :

* `name` ne peut pas être null, vide ou uniquement des espaces.
* `price` doit être strictement > 0.
* `quantity` doit être strictement > 0.
* En cas de violation : lever une exception appropriée.

---

### 2) Nombre d’articles

Méthode :

* `GetItemCount()`

Règles :

* Retourne le nombre d’articles distincts ajoutés au panier.
* Un panier nouvellement créé contient 0 article.

---

### 3) Calcul du total

Méthode :

* `GetTotal()`

Règles :

* Total = somme de `price × quantity` sur tous les articles.
* Panier vide → total = 0.

---

### 4) Application d’une remise

Méthode :

* `ApplyDiscount(decimal percentage)`

Règles :

* Le panier ne doit pas être vide.
* Le pourcentage doit être compris entre 0 et 100 inclus.
* La remise ne peut être appliquée qu’une seule fois.
* Une fois la remise appliquée, le total retourné par `GetTotal()` doit être réduit en conséquence.
* Toute violation doit déclencher une exception adaptée.

Exemples :

* Total 10, remise 10% → 9
* Remise 0% → total inchangé
* Remise 100% → total = 0


## Travail demandé (TDD)

### Étape 1 — Tests du panier vide

Écrire les tests suivants :

* Un panier neuf contient 0 article.
* Un panier vide a un total égal à 0.
* Appliquer une remise sur un panier vide déclenche une exception.

---

### Étape 2 — Tests d’ajout (validation)

Écrire les tests suivants :

* Ajouter un article valide augmente le nombre d’articles.
* Ajouter un article avec nom invalide déclenche une exception.
* Ajouter un article avec prix ≤ 0 déclenche une exception.
* Ajouter un article avec quantité ≤ 0 déclenche une exception.

---

### Étape 3 — Tests de calcul

Écrire les tests suivants :

* Un article → total = price × quantity.
* Plusieurs articles → total = somme correcte.

---

### Étape 4 — Tests de remise

Écrire les tests suivants :

* Appliquer 10% réduit correctement le total.
* Appliquer 0% ne change rien.
* Appliquer 100% donne 0.
* Remise négative → exception.
* Remise > 100 → exception.
* Appliquer une remise deux fois → exception.



## Règles importantes

* Tant que les méthodes jettent `NotImplementedException`, les tests échoueront : c’est normal au début.
* Vous devez remplacer les `NotImplementedException` progressivement, au rythme des tests.
* Aucun code métier ne doit être ajouté dans la console : tout doit être dans `Panier.Core`.



## Résultat attendu

À la fin :

* `ShoppingCart` est entièrement implémentée.
* Tous les tests passent.
* La console fonctionne (ajout, total, remise, count).

Bon développement.

