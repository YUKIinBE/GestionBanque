using GestionBanque.Models;

Personne p1 = new Personne();
p1.Nom = "Marchal";
p1.Prenom = "Yuki";
p1.DateNaiss = new DateTime(1993, 12, 16);

Courant c1 = new Courant();
c1.Titulaire = p1;
c1.Depot(100);
c1.LigneDeCredit = 50;
c1.Retrait(200);

Banque b1 = new Banque();
b1.Ajouter(c1);