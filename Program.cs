using System;

namespace Clock_game
{
    class Program
    {
        static int LireLeNombre()
        {
            int nombreChoisiParJoueur;
            Console.WriteLine("Donnez votre hypothèse du nombre cible:");
            nombreChoisiParJoueur = int.Parse(Console.ReadLine());
            return nombreChoisiParJoueur;
        }
        static int CréerNombrePseudoAléatoire()
        {
            const int BORNE_MIN = 1;
            const int BORNE_MAX = 2500;
            Random générateur = new Random();
            int numéroAléatoire = générateur.Next(BORNE_MIN, BORNE_MAX + 1);
            return numéroAléatoire;
        }
        static int CalculerNombreEssai(int nombreChoisi, int nombreÀDeviner)
        {
            int cptEssai;
            for (cptEssai = 1; nombreChoisi != nombreÀDeviner; ++cptEssai)
            {
                if (nombreChoisi > nombreÀDeviner)
                {
                    Console.WriteLine("Trop grand!");
                }
                else
                {
                    Console.WriteLine("Trop petit!");
                }
                nombreChoisi = LireLeNombre();
            }
            return cptEssai;
        }
        static string DéterminerMessage(int nombreEssai)
        {
            const int MIN_EXCELLENT = 6;
            const int MIN_TRÈS_BIEN = 12;
            const int MIN_BIEN = 17;
            const int MIN_ORDINAIRE = 23;
            string mention;
            if (nombreEssai < MIN_TRÈS_BIEN)
            {
                if (nombreEssai < MIN_EXCELLENT)
                {
                    mention = "Remarquable";
                }
                else
                {
                    mention = "Excellent";
                }
            }
            else
            {
                if (nombreEssai < MIN_BIEN)
                {
                    mention = "Très bien";
                }
                else
                {
                    if (nombreEssai < MIN_ORDINAIRE)
                    {
                        mention = "Bien";
                    }
                    else
                    {
                        mention = "Ordinaire";
                    }
                }
            }
            return mention;
        }
        static void AfficherRésultat(int nombreEssai, string message)
        {
            Console.WriteLine($"Vous avez trouvé le nombre cible en {nombreEssai} essais : {message}");
        }
        static void TraiterJoueur(int nombreChoisi, int nombreÀDeviner)
        {
            int nombreEssai = CalculerNombreEssai(nombreChoisi, nombreÀDeviner);
            string message = DéterminerMessage(nombreEssai);
            AfficherRésultat(nombreEssai, message);
        }
        static void Main(string[] args)
        {
            int nombreChoisi;
            int nombreÀDeviner;
            string rejouer;
            do
            {
                nombreChoisi = LireLeNombre();
                nombreÀDeviner = CréerNombrePseudoAléatoire();
                TraiterJoueur(nombreChoisi, nombreÀDeviner);
                Console.WriteLine("Voulez vous rejouer?<o/n>:");
                rejouer = Console.ReadLine();
            } while (rejouer == "o");
        }
    }
}