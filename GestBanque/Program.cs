using GestionBanque.Models;
using Tools.Models;

#region Création de personnes

Personne p1 = new Personne("Mouse", "Mickey", new DateTime(1928, 11, 18));
Personne p2 = new Personne("Duck", "Donaldo", new DateTime(1934, 6, 9));

#endregion

#region Création de comptes

// Mickey Mouse
Courant c1 = new Courant("123", p1, 50);
c1.Depot(100);

// Donald Duck
Courant c2 = new Courant("456", p2, 100);
c2.Depot(200);

// Donald Duck 2e compte
Courant c3 = new Courant("789", p2, 75);
c3.Depot(150);

#endregion

#region Ajout les comptes à la liste Comptes

Banque b1 = new Banque();
b1.Ajouter(c1);
b1.Ajouter(c2);
b1.Ajouter(c3);

#endregion

#region Test de Méthodes

#region Personne

// Surcharge d'opérateur « == » et « != »
Console.WriteLine("Vérifier si les deux Personnes sont les mêmes");
Console.WriteLine($"p1 and p2 are the same? : {p1 == p2}");
Console.WriteLine($"p1 and p2 are NOT the same? : {p1 != p2}");

#endregion

Tool.AddTitle("BANQUE");

#region Banque

// Indexeur de la liste Comptes
Console.WriteLine("Parcourir la liste Comptes pour trouver le compte souhaité récupérer");
Console.WriteLine($"Solde de compte « 123 » : {b1["123"].Solde}");

Tool.AddReturn();

// Supprimer un compte de la liste Comptes
Console.WriteLine($"Nombre d'éléments enregistrés dans la liste Comptes : {b1.Comptes.Count}");
b1.Supprimer("789");
Console.WriteLine($"Nombre d'éléments enregistrés dans la liste Comptes : {b1.Comptes.Count}");

Tool.AddReturn();

// Ajouter un nouveau compte à la liste Comptes
Console.WriteLine($"Nombre d'éléments enregistrés dans la liste Comptes : {b1.Comptes.Count}");
b1.Ajouter(c3);
Console.WriteLine($"Nombre d'éléments enregistrés dans la liste Comptes : {b1.Comptes.Count}");

Tool.AddReturn();

// Calculer la somme de tous les soldes de comptes possédés par le même titulaire
Console.WriteLine($"Donaldo Duck a deux comptes et les soldes sont 200€ et 150€");
Console.WriteLine($"La somme de soldes de tous les comptes possédés par Donaldo Duck : {b1.AvoirDesComptes(p2)}");

Tool.AddReturn();

// Aficher info d'un compte
Banque.AfficherInfo(c1);

#endregion

Tool.AddTitle("COMPTE");

#region Compte

// Surcharge d'opérateur « montant » + « solde » 
Console.WriteLine($"Solde de Mickey : {c1.Solde}\nSolde de Donaldo : {c2.Solde} et {c3.Solde}");
Console.WriteLine($"Total de solde de Mickey et Donaldo : {c1.Solde + c2.Solde + c3.Solde}");

Tool.AddReturn();

// Ajouter de l'argent au solde
Console.WriteLine($"Solde de Mickey : {c1.Solde}");
c1.Depot(100);
Console.WriteLine($"Depot de 100€");
Console.WriteLine($"Solde de Mickey : {c1.Solde}");

Tool.AddReturn();

// Retirer de l'argent du solde
Console.WriteLine($"Solde de Donaldo compte 1 : {c2.Solde}");
Console.WriteLine($"Retrait de 250€");
c2.Retrait(250);
Console.WriteLine($"Solde de Donaldo compte 1 : {c2.Solde}");

Tool.AddReturn();

// Cakculer l'interet et l'appliquer
// Compte courant Solde positif
Console.WriteLine($"Solde de Mickey : {c1.Solde}");
c1.AppliquerInteret();
Console.WriteLine($"Solde de Mickey : {c1.Solde}");

Tool.AddReturn();

// Compte courant Solde négatif
Console.WriteLine($"Solde de Donaldo compte 1 : {c2.Solde}");
c2.AppliquerInteret();
Console.WriteLine($"Solde de Donaldo compte 1 : {c2.Solde}");


#endregion

#region ICustomer

Tool.AddTitle("ICustomer");

// customer1 a un accès seulement au Solde, Depot, Retrait 
ICustomer customer1 = c2;
Console.WriteLine($"Votre Solde : {customer1.Solde}");

#endregion

#region IBanker

Tool.AddTitle("IBanker");

// banker1 a un accès au Titulaire, Numero, AppliquerInteret en plus de Solde, Depot, Retrait
IBanker banker1 = c1;
banker1.AppliquerInteret();

#endregion

#region IPaiement

Tool.AddTitle("IPaiement");

CarteDeCredit carte1 = new CarteDeCredit()
{
    Titulaire = p1,
    DateExpiration = DateTime.Now,
};

carte1.EffectuerPaiement(c1, c2, 50);

#endregion

#endregion