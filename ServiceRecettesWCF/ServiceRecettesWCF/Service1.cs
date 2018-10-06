using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Share;

namespace ServiceRecettesWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        private static List <Recette> listeRecettes;
        private List <Recette> rechercheCourante;

        static Service1()
        {
            //On crée une base de deux recettes.
            listeRecettes = new List<Recette> {
                new Recette(
                    "Cake aux olives",
                    new List<Ingredient>
                {
                    new Ingredient("Farine"),
                    new Ingredient("Oeuf"),
                    new Ingredient("Poivre"),
                    new Ingredient("Olive"),
                    new Ingredient("Huile"),
                    new Ingredient("Levure")
                }
                ),
                new Recette(
                    "Salade de choux",
                    new List<Ingredient>
                {
                    new Ingredient("Choux"),
                    new Ingredient("Olive"),
                    new Ingredient("Cacahuete"),
                    new Ingredient("Huile"),
                    new Ingredient("Vinaigre"),
                    new Ingredient("Fromage")
                }
                ),
                new Recette(
                    "Pizza 4 fromages ",
                    new List<Ingredient>
                {
                    new Ingredient("Farine"),
                    new Ingredient("Levure"),
                    new Ingredient("Eau"),
                    new Ingredient("Huile"),
                    new Ingredient("Fromage"),
                    new Ingredient("Tomate")
                }
                ),
                new Recette(
                    "Salade d'endives",
                    new List<Ingredient>
                {
                    new Ingredient("Endive"),
                    new Ingredient("Olive"),
                    new Ingredient("Huile"),
                    new Ingredient("Vinaigre")
                }
                )
            };
        }

        public Service1()
        {
            rechercheCourante = new List<Recette>();
        }

        public void SetRecette (Recette newRecette)
        {
            if (newRecette == null)
            {
                throw new ArgumentNullException("Recette");
            }
            else
            {
                listeRecettes.Add(newRecette);
            }
        }

        public void GetRecettes(string nom)
        {
            if (nom == null)
            {
                throw new ArgumentNullException("String");
            }
            else
            {
                List<Recette> recherche = new List<Recette>();
                foreach (Recette re in listeRecettes)
                {
                    foreach ( Ingredient ing in re.Ingredients)
                    {
                        if (ing.Nom.Equals(nom))
                        {
                            recherche.Add(re);
                        }
                    }
                }
                rechercheCourante = recherche;
            }
        }

        public void SupprimeRecette(int indice)
        {

                Console.WriteLine("Suppression de : " +  rechercheCourante[indice].Nom);

                rechercheCourante.RemoveAt(indice);

                foreach(Recette re in rechercheCourante)
                {
                    Console.WriteLine(re.Nom);
                }

        }

        public List<Recette> GetRechercheCourante()
        {

            return rechercheCourante;

        }

    }
}
