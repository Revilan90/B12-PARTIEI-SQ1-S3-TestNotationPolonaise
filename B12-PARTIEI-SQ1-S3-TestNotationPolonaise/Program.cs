using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12_PARTIEI_SQ1_S3_TestNotationPolonaise
{
    internal class Program
    {
        static float Polonaise(string formule)
        {
            try
            {

                //initialisation des tableaux
                string[] operations = new string[] { "+", "-", "*", "/" };
                string[] liste = formule.Split(' ');
                //boucle des operations
                if (liste.Length > 1)
                {
                    while (liste[1] != "")
                    {
                        bool trouve = false;
                        int k = liste.Length - 1, signe = 0;
                        //boucle pour trouver le premier signe d'opération
                        while (!trouve && k >= 0)
                        {
                            //on part de la fin de liste et on remonte en comparant avec le contenu de operation
                            signe = Array.IndexOf(operations, liste[k]);
                            if (signe != -1)
                            {
                                trouve = true;
                            }
                            else
                            {
                                k--;
                            }
                        }
                        if (trouve)
                        {
                            //opération en fonction du signe trouvé
                            switch (signe)
                            {
                                case 0:
                                    liste[k] = (float.Parse(liste[k + 1]) + float.Parse(liste[k + 2])).ToString();
                                    break;
                                case 1:
                                    liste[k] = (float.Parse(liste[k + 1]) - float.Parse(liste[k + 2])).ToString();
                                    break;
                                case 2:
                                    liste[k] = (float.Parse(liste[k + 1]) * float.Parse(liste[k + 2])).ToString();
                                    break;
                                case 3:
                                    //condition pour eviter les divisions par zero
                                    if (float.Parse(liste[k + 2]) != 0)
                                    {
                                        liste[k] = (float.Parse(liste[k + 1]) / float.Parse(liste[k + 2])).ToString();
                                    }
                                    else
                                    {
                                        return float.NaN;
                                    }
                                    break;
                            }
                            //supression des valeurs utilisées et décalage
                            liste[k + 1] = "";
                            liste[k + 2] = "";
                            for (int i = k; i + 3 < liste.Length; i++)
                            {
                                liste[i + 1] = liste[i + 3];
                                liste[i + 3] = "";
                            }
                        }
                        else
                        {
                            return float.NaN;
                        }

                    }
                }
                
                return float.Parse(liste[0]);
            }
            catch 
            { 
                return float.NaN;
            }
        }
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
