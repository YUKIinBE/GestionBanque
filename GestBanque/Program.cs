using GestionBanque.Models;
using Tools.Models;

#region Création de personnes

Personne p1 = new Personne()
{
    Nom = "Mouse", Prenom = "Mickey", DateNaiss = new DateTime(1928, 11, 18)
};
Personne p2 = new Personne() 
{ 
    Nom = "Duck", Prenom = "Donald", DateNaiss = new DateTime(1934, 6, 9) 
};

#endregion

#region Création de comptes

// Mickey Mouse
Courant c1 = new Courant();
c1.Numero = "123";
c1.Titulaire = p1;
c1.Depot(100);
c1.LigneDeCredit = 50;

// Donald Duck
Courant c2 = new Courant();
c2.Numero = "456";
c2.Titulaire = p2;
c2.Depot(200);
c2.LigneDeCredit = 100;

// Donald Duck 2e compte
Courant c3 = new Courant();
c3.Numero = "789";
c3.Titulaire = p2;
c3.Depot(150);
c3.LigneDeCredit = 75;

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

Tool.AddTitle("COMPTE");

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

#endregion

Tool.AddTitle("BANQUE");

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

Tool.AddLine();

#endregion