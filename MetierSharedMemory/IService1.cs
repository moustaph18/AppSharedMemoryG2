using MetierSharedMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierSharedMemory
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici

        [OperationContract]
        bool AjoutEncadreur(Encadreur encadreur);
        [OperationContract]
        Encadreur encadreurById(int? id);
        [OperationContract]
        bool ModifierEncadreur(Encadreur encadreur);
        [OperationContract]
        bool SupprimerEncadreur(int? id);
        [OperationContract]
        List<Encadreur> ListEncadreur();
        [OperationContract]
        List<Encadreur> ListEncadreurs(String text);
        [OperationContract]
        List<ListItems> ChargementComboBox();

        /////////////////////////////// Pour Memoire \\\\\\\\\\\\\\\\\\\\\\\\\\\
        [OperationContract]
        bool AjoutMemoire(Memoire memoire);
        [OperationContract]
        bool ModifierMemoire(Memoire memoire);
        [OperationContract]
        bool SupprimerMemoire(int? id);
        [OperationContract]
        List<Memoire> ListMemoires();
        [OperationContract]
        Memoire MemoireById(int? id);
        [OperationContract]
        List<Memoire> ListMemorieParCh(String text);
        [OperationContract]
        List<MemoireViewModel> GetMemoireViewModels();
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
