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
            Console.WriteLine($"Mot à deviner (DEBUG) : {motADeviner}"); // À retirer plus tard
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
    }
}

