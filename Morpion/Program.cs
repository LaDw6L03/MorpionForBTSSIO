using System;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Morpion
{
    class Program
    {
        public static int[,] grille = new int[3, 3]; // matrice pour stocker les coups joués

        // Fonction permettant l'affichage du Morpion
        public static void AfficherMorpion(int j, int k)
        {
            Console.Clear();
            Console.WriteLine("  1 2 3");
            for (j = 0; j < 3; j++)
            {
                Console.Write(j + 1 + " ");
                for (k = 0; k < 3; k++)
                {
                    if (grille[j, k] == 10)
                        Console.Write(". ");
                    else if (grille[j, k] == 1)
                        Console.Write("X ");
                    else
                        Console.Write("O ");
                }
                Console.WriteLine();
            }
        }

        // Fonction permettant de changer
        // dans le tableau qu'elle est le 
        // joueur qui à jouer
        // Bien vérifier que le joueur ne sort
        // pas du tableau et que la position
        // n'est pas déjà jouée
        public static bool AJouer(int j, int k, int joueur)
        {
            if (j >= 0 && j < 3 && k >= 0 && k < 3 && grille[j, k] == 10)
            {
                grille[j, k] = joueur;
                return true;
            }
            return false;
        }

        // Fonction permettant de vérifier si un joueur a gagné
        public static bool Gagner(int l, int c, int joueur)
        {
            // Vérification des lignes, colonnes et diagonales
            return (grille[l, 0] == joueur && grille[l, 1] == joueur && grille[l, 2] == joueur) ||
                   (grille[0, c] == joueur && grille[1, c] == joueur && grille[2, c] == joueur) ||
                   (grille[0, 0] == joueur && grille[1, 1] == joueur && grille[2, 2] == joueur) ||
                   (grille[0, 2] == joueur && grille[1, 1] == joueur && grille[2, 0] == joueur);
        }


        // Programme principal
        static void Main(string[] args)
        {
            //--- Déclarations et initialisations --
            int LigneDébut = Console.CursorTop;     // par rapport au sommet de la fenêtre
            int ColonneDébut = Console.CursorLeft; // par rapport au sommet de la fenêtre

            int essais = 0;    // compteur d'essais
            int joueur = 1;   // 1 pour la premier joueur, 2 pour le second
            int l, c = 0;      // numéro de ligne et de colonne
            int j, k = 0;      // Parcourir le tableau en 2 dimensions
            bool gagner = false; // Permet de vérifier si un joueur à gagné 
            bool bonnePosition = false; // Permet de vérifier si la position souhaité est disponible

            //- On met chaque valeur du tableau à 10
            for (j = 0; j < grille.GetLength(0); j++)
                for (k = 0; k < grille.GetLength(1); k++)
                    grille[j, k] = 10;
            while (!gagner && essais != 9)
            {
                AfficherMorpion(j, k);
                try
                {
                    Console.WriteLine("Joueur " + joueur);
                    Console.WriteLine("Ligne   =    ");
                    Console.WriteLine("Colonne =    ");
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 9); // Permet de manipuler le curseur dans la fenêtre 
                    l = int.Parse(Console.ReadLine()) - 1;
                    // Peut changer en fonction de comment vous avez fait votre tableau.
                    Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 10); // Permet de manipuler le curseur dans la fenêtre 
                    c = int.Parse(Console.ReadLine()) - 1;

                    bonnePosition = AJouer(l, c, joueur);
                    if (bonnePosition)
                    {
                        essais++;
                        gagner = Gagner(l, c, joueur);
                        if (!gagner)
                        {
                            // Changement de joueur
                            joueur = (joueur == 1) ? 2 : 1;
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                // Changement de joueur
                // A compléter 

            }; // Fin TQ

            // Fin de la partie
            // A compléter 

            Console.ReadKey();
        }
    }
}
