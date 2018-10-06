using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Share;


namespace ClientRecette
{
    class Program
    { 
        static void Main(string[] args)
        {
            ChannelFactory<IService1> factory = new ChannelFactory<IService1>("Service1");
            IService1 proxy = factory.CreateChannel();
            bool condMenu = true;


            while (condMenu) {
                Console.WriteLine("\r\n" +"Recherche par ingredient : Press <1 + Enter> ");
                Console.WriteLine("Ajout d'une recette : Press <2 +Enter> ");
                Console.WriteLine("Quitter : Press <Enter> ");



                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine("\r\n" + "Recherche par ingredient : ");

                            proxy.GetRecettes(Console.ReadLine());
                            bool cond = true;

                            while (cond)
                            {
                                Console.WriteLine("\r\n" + "Selection courante: ");
                                List<Recette> recherche =  proxy.GetRechercheCourante();
                                int i = 1;
                                foreach (Recette r in recherche)
                                {
                                    Console.WriteLine("[" + i + "] : " + r.Nom);
                                    i++;
                                }

                                Console.WriteLine("\r\n"+"Supprimer une recette de la selection : Press <1 +Enter> ");
                                Console.WriteLine("Revenir au menu : Press <Enter> ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("\r\n" + "Indiquez le numéros de la recette à supprimer : ");
                                            int indice = Int32.Parse(Console.ReadLine()) - 1;
                                            Console.WriteLine("\r\n" + "Suppression de : " + recherche[indice].Nom);
                                            proxy.SupprimeRecette(indice);

                                            break;
                                        }

                                    default:
                                        {
                                            cond = false;
                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("\r\n" + "Donnez un titre à la recette : ");
                            string titre = Console.ReadLine();
                            List<Ingredient> newIngredients = new List<Ingredient>();
                            bool cond = true;
                            while (cond)
                            {
                                Console.WriteLine("\r\n" + "Donnez un nom d'ingrédient : ");
                                string ingredient = Console.ReadLine();
                                if (!string.IsNullOrEmpty(ingredient))
                                {
                                    newIngredients.Add(new Ingredient(ingredient));
                                }
                                else
                                {
                                    cond = false;
                                }
                            }

                            proxy.SetRecette(new Recette(titre, newIngredients));

                            break;
                        }

                    default:
                        condMenu = false;
                        break;
                }
            }

        }
    }
}
