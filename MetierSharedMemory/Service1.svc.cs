using MetierSharedMemory.Model;
using MetierSharedMemory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;

namespace MetierSharedMemory
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        BdSharedMemoryContext bd = new BdSharedMemoryContext();
        Logger logger = new Logger();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Cette methode permet l'enrigistrement d'un encadreur
        /// </summary>
        /// <param name="encadreur">encadreur</param>
        /// <returns> true si ok, sinon false </returns>

        public bool AjoutEncadreur(Encadreur encadreur)
        {
            try
            {
                bd.encadreur.Add(encadreur);
                bd.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service1- AjoutEncadreur", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Cette methode permet la modification d'un encadreur
        /// </summary>
        /// <param name="encadreur">encadreur</param>
        /// <returns> true si ok ; sinon false</returns>
        public bool ModifierEncadreur(Encadreur encadreur)
        {
            try
            {
                var encad = bd.encadreur.Find(encadreur.IdPersonne);
                if (encad != null)
                {
                    encad.Prenom = encadreur.Prenom;
                    encad.Nom = encadreur.Nom;
                    bd.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service1-ModifierEncadreur", ex.ToString());
                return false;
            }
            return false;
        }

        /// <summary>
        /// Cette methode permet de supprimer un encadreur via son id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns> true si ok ; sinon false</returns>
        public bool SupprimerEncadreur(int? id)
        {
            try
            {
                var encadreurById = bd.encadreur.Find(id);
                if (encadreurById != null)
                {
                    bd.encadreur.Remove(encadreurById);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service1-SupprimerEncadreur", ex.ToString());
                return false;
            }
            return false;

        }

        /// <summary>
        /// Liste des encadreur
        /// </summary>
        /// <returns>e</returns>
        public List<Encadreur> ListEncadreur()
        {
            return bd.encadreur.ToList();
        }

        /// <summary>
        /// Cette methode permet de recuperer un encadreur via son id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Encadreur encadreurById(int? id)
        {
            return bd.encadreur.Find(id);
        }

        /// <summary>
        /// Cette methode permet d'obtenir une liste d'encadreur via un text donner dont la verification vas se faire sur le prenom, le nom ou la specialite
        /// </summary>
        /// <param name="text">text</param>
        /// <returns></returns>
        public List<Encadreur> ListEncadreurs(String text)
        {
            var encadreur = bd.encadreur.ToList();
            if (!string.IsNullOrEmpty(text))
            {
                string searchText = text.ToUpper();
                encadreur = encadreur.Where(a =>
                    a.Prenom.ToUpper().Contains(searchText) ||
                    a.Nom.ToUpper().Contains(searchText) ||
                    a.Specialite.ToUpper().Contains(searchText)).ToList();
            }
            return encadreur;
        }

        /// <summary>
        /// Pour le chargement de la liste deroulante
        /// </summary>
        /// <returns></returns>
        public List<ListItems> ChargementComboBox()
        {

            {
                List<ListItems> laliste = new List<ListItems>();
                var liste = bd.encadreur.ToList();
                laliste.Add(new ListItems
                {
                    Value = null,
                    Text = "Choisissez ..."
                });
                foreach (var t in liste)
                {
                    var item = new ListItems
                    {
                        Value = t.IdPersonne.ToString(),
                        Text = t.Prenom.ToString()+" - "+t.Nom.ToString()
                    };
                    laliste.Add(item);
                }
                return laliste;
            }

        }

        //----------------------------- Pour Memoire --------------------------\\

        /// <summary>
        /// Cette methode permet l'enrigistrement une nouvelle memoire
        /// </summary>
        /// <param name="memoire">memoire</param>
        /// <returns> true si ok, sinon false </returns>

        public bool AjoutMemoire(Memoire memoire)
        {
            try
            {
               bd.memoire.Add(memoire);
                bd.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service1- AjoutMemoire", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Cette methode permet la modification d'une memoire
        /// </summary>
        /// <param name="memoire">memoire</param>
        /// <returns> true si ok ; sinon false</returns>
        public bool ModifierMemoire(Memoire memoire)
        {
            try
            {
                var memory = bd.memoire.Find(memoire.IdMemoire);
                if (memory != null)
                {
                    memory.Sujet = memoire.Sujet;
                    memory.FileName = memoire.FileName;
                    memory.Annee = memoire.Annee;
                    memory.IdEncadreur = memoire.IdEncadreur;
                    bd.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service1-ModifierMemoire", ex.ToString());
                return false;
            }
            return false;
        }


        /// <summary>
        /// Cette methode permet de supprimer une memoire via son id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns> true si ok ; sinon false</returns>
        public bool SupprimerMemoire(int? id)
        {
            try
            {
                var memoireById = bd.memoire.Find(id);
                if (memoireById != null)
                {
                    bd.memoire.Remove(memoireById);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service1-SupprimerMemoire", ex.ToString());
                return false;
            }
            return false;

        }


        /// <summary>
        /// Liste des Memoires
        /// </summary>
        /// <returns>e</returns>
        public List<Memoire> ListMemoires()
        {
            return bd.memoire.ToList();

        }

        /// <summary>
        /// Affiche des memoires
        /// </summary>
        /// <returns></returns>
        public List<MemoireViewModel> GetMemoireViewModels()
        {
            return bd.memoire.Select(m => new MemoireViewModel
            {
                IdMemoire = m.IdMemoire,
                Sujet = m.Sujet,
                FileName = m.FileName,
                Annee = m.Annee,
                IdEncadreur = m.IdEncadreur,
                Encadreur = m.encadreur != null ? $"{m.encadreur.Prenom} {m.encadreur.Nom}" : "Non attribué"
            }).ToList();
        }


        /// <summary>
        /// Cette methode permet de recuperer une memoire via son id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Memoire MemoireById(int? id)
        {
            return bd.memoire.Find(id);
        }


        /// <summary>
        /// Cette methode permet d'obtenir une liste de memoire via un text donner dont
        /// la verification vas se faire sur le prenom, le nom ode l'encadreur, soit 
        /// par le nom du fichier ou le sujet.
        /// </summary>
        /// <param name="text">text</param>
        /// <returns></returns>
        public List<Memoire> ListMemorieParCh(String text)
        {
            var memoire = bd.memoire.ToList();
            if (!string.IsNullOrEmpty(text))
            {
                string searchText = text.ToUpper();
                memoire = memoire.Where(a =>
                    a.Sujet.ToUpper().Contains(searchText) ||
                    a.FileName.ToUpper().Contains(searchText)).ToList();
            }
            return memoire;
        }
    }


}
