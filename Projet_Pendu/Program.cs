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
            List<char> lettresJouees = new List<char> { 'E', 'A', 'R' };
            int erreurs = 2;

            AfficherPotence(erreurs);
            Console.WriteLine("\n" + ObtenirMotCache(motADeviner, lettresJouees));
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
        /// Affiche la potence selon le nombre d'erreurs.
        /// </summary>
        static void AfficherPotence(int erreurs)
        {
            string[] potence = new string[]
            {
        "+--+---\n|     \n|     \n|     \n|     \n|     \n+-------",
        "+--+---\n|  |  \n|     \n|     \n|     \n|     \n+-------",
        "+--+---\n|  |  \n|  O  \n|     \n|     \n|     \n+-------",
        "+--+---\n|  |  \n|  O  \n|  |  \n|     \n|     \n+-------",
        "+--+---\n|  |  \n|  O  \n| /|  \n|     \n|     \n+-------",
        "+--+---\n|  |  \n|  O  \n| /|\\ \n|     \n|     \n+-------",
        "+--+---\n|  |  \n|  O  \n| /|\\ \n| /   \n|     \n+-------",
        "+--+---\n|  |  \n|  O  \n| /|\\ \n| / \\ \n|     \n+-------"
            };

            Console.WriteLine(potence[Math.Min(erreurs, potence.Length - 1)]);
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
    }
}

