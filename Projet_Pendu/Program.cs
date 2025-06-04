namespace Projet_Pendu
{
    internal class Program
    {
            static void Main()
            {
                string cheminFichier = "EST-M3Prog-ED12_JeuDuPendu_ListeMots.txt";
                List<string> listeMots;

                try
                {
                    listeMots = ChargerListeMots(cheminFichier);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Le fichier {Path.GetFullPath(cheminFichier)} est introuvable.");
                    return;
                }

                string motADeviner = ObtenirMotADeviner(listeMots);
                List<char> lettresJouees = new List<char>();

                while (true)
                {
                    char lettre = SaisirLettreAZ(lettresJouees);
                    lettresJouees.Add(lettre);
                    Console.WriteLine($"Lettre jouée : {lettre}");
                }
            }

        /// <summary>
        /// Charge tous les mots depuis un fichier texte.
        /// </summary>
        static List<string> ChargerListeMots(string nomFichier)
        {
            return File.ReadLines(nomFichier).ToList();
        }

        /// <summary>
        /// Sélectionne un mot aléatoirement dans une liste.
        /// </summary>
        static string ObtenirMotADeviner(List<string> mots)
        {
            Random random = new Random();
            int index = random.Next(mots.Count);
            return mots[index];
        }

        /// <summary>
        /// Affiche la potence selon le nombre d'erreurs (0 à 6).
        /// </summary>
        static void AfficherPotence(int erreurs)
        {
            Console.WriteLine("+--+---");

            switch (erreurs)
            {
                case 0:
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    break;
                case 1:
                    Console.WriteLine("|  |  ");
                    Console.WriteLine("|  O  ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    break;
                case 2:
                    Console.WriteLine("|  |  ");
                    Console.WriteLine("|  O  ");
                    Console.WriteLine("|  |  ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    break;
                case 3:
                    Console.WriteLine("|  |  ");
                    Console.WriteLine("|  O  ");
                    Console.WriteLine("| /|  ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    break;
                case 4:
                    Console.WriteLine("|  |  ");
                    Console.WriteLine("|  O  ");
                    Console.WriteLine("| /|\\ ");
                    Console.WriteLine("|     ");
                    Console.WriteLine("|     ");
                    break;
                case 5:
                    Console.WriteLine("|  |  ");
                    Console.WriteLine("|  O  ");
                    Console.WriteLine("| /|\\ ");
                    Console.WriteLine("| /   ");
                    Console.WriteLine("|     ");
                    break;
                default: // erreurs == 6 ou plus
                    Console.WriteLine("|  |  ");
                    Console.WriteLine("|  O  ");
                    Console.WriteLine("| /|\\ ");
                    Console.WriteLine("| / \\ ");
                    Console.WriteLine("|     ");
                    break;
            }

            Console.WriteLine("+-------");
        }


        /// <summary>
        /// Retourne le mot avec les lettres trouvées visibles, les autres en _.
        /// </summary>
        static string ObtenirMotCache(string mot, List<char> lettresJouees)
        {
            string resultat = "";
            foreach (char c in mot)
            {
                if (lettresJouees.Contains(c))
                    resultat += c + " ";
                else
                    resultat += "_ ";
            }
            return resultat.TrimEnd();
        }

        /// <summary>
        /// Demande à l'utilisateur de saisir une lettre de l'alphabet.
        /// Vérifie que la lettre est valide (A-Z) et non déjà jouée.
        /// </summary>
        static char SaisirLettreAZ(List<char> lettresJouees)
        {
            while (true)
            {
                Console.Write("\nQuelle lettre voulez-vous jouer ? ");
                string saisie = Console.ReadLine()?.Trim().ToUpper();

                if (string.IsNullOrEmpty(saisie) || saisie.Length != 1 || !char.IsLetter(saisie[0]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Votre saisie est invalide.");
                    Console.ResetColor();
                    continue;
                }

                char lettre = saisie[0];

                if (lettresJouees.Contains(lettre))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vous avez déjà joué cette lettre.");
                    Console.ResetColor();
                    Console.Write("Appuyez sur une touche pour continuer...");
                    Console.ReadKey(true);
                    continue;
                }

                return lettre;
            }
        }

    }
}

