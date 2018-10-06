using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Text;

namespace Share
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void SetRecette(Recette recette);

        [OperationContract]
        void GetRecettes(string nom);

        [OperationContract]
        List<Recette> GetRechercheCourante();
    
        [OperationContract]
        void SupprimeRecette(int indice);

        // TODO: ajoutez vos opérations de service ici
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "ServiceRecettesWCF.ContractType".

    [DataContract]
    public class Recette
    {
        string nom;
        List<Ingredient> ingredients;

        private Recette() { }

        public Recette(string nom, List<Ingredient> ingredients)
        {
            this.Ingredients = ingredients;
            this.nom = nom;
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        [DataMember]
        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
    }

    [DataContract]
    public class Ingredient
    {
        string nom;

        private Ingredient() { }

        public Ingredient(string nom)
        {
            this.nom = nom;
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}
