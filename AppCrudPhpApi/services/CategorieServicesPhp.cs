using ApplicationSharedMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationSharedMemory.Model;
using System.Net.Http.Headers;
using System.Net.Http;
using MetierSharedMemory.Utils;

namespace ApplicationSharedMemory.Service
{
    public class CategorieServicesPhp
    {
        
        /// <summary>
        /// Cette methode personne de lister tous les categories 
        /// </summary>
        /// <returns></returns>
        public List<CategorieApiPhp> servGetListeCategorie() {
            HttpClient client;
            client = new HttpClient();
            var servicesCategories = new List<CategorieApiPhp>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApiPhp"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("list.php").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                servicesCategories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategorieApiPhp>>(responseData);
            }
            return servicesCategories;
        }

        /// <summary>
        /// Cette methode d'enrigistrer une nouvelle categorie
        /// </summary>
        /// <param name="categorie">categorie</param>
        /// <returns> true si ok ; sinon false</returns>
        public bool AddCategorie(CategorieApiPhp categorie)
        {
            bool rep = false;
            String Id = categorie.idCategorie > 0 ? categorie.idCategorie.ToString() : "0";
            var values = new Dictionary<String, String>
                    {
                        {"idCategorie", Id},
                        {"CodeCategorie",categorie.CodeCategorie },
                        {"LibelleCategorie",categorie.LibelleCategorie }

                    };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApiPhp"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("Ajout.php", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogSystem("Erreur rencontrer dans l'APi lors de l'ajout "+ ex.ToString(), "CategorieServicesPhp-AddCategorie");
            }
            return rep;
        }

        /// <summary>
        /// Cette Methode permet la suppression d'une categorie via son id 
        /// </summary>
        /// <param name="idCategorie">idCategorie</param>
        /// <returns>true si ok ; sinon false</returns>
        public bool DeleteCategorie(int idCategorie)
        {
            bool rep = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApiPhp"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.DeleteAsync($"supprimer.php?idCategorie={idCategorie}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogSystem("Erreur rencontrer dans l'APi lors de l'ajout " + ex.ToString(), "CategorieServicesPhp-DeleteCategorie");
            }
            return rep;
        }

        /// <summary>
        /// Cette methode permet d'obtenir une categorie de par son id 
        /// </summary>
        /// <param name="idCategorie">idCategorie</param>
        /// <returns></returns>
        public CategorieApiPhp GetCategorieById(int idCategorie)
        {
            var services = new CategorieApiPhp();

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApiPhp"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync($"CategorieById.php?id={idCategorie}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        services = Newtonsoft.Json.JsonConvert.DeserializeObject<CategorieApiPhp>(responseData);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogSystem("Erreur rencontrer dans l'APi lors de l'ajout " + ex.ToString(), "CategorieServicesPhp-GetCategorieById");
            }
            return services;
        }

        /// <summary>
        /// Cette methode permet de modifier une categorie
        /// </summary>
        /// <param name="categorie"> categorie</param>
        /// <returns>true si ok; sinon false</returns>
        public bool UpdateCategorie(CategorieApiPhp categorie)
        {
            bool rep = false;
            String Id = categorie.idCategorie > 0 ? categorie.idCategorie.ToString() : "0";
            var values = new Dictionary<String, String>
            {
                {"idCategorie", Id},
                {"CodeCategorie", categorie.CodeCategorie},
                {"LibelleCategorie", categorie.LibelleCategorie}
            };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApiPhp"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync($"modifier.php?idCategorie={categorie.idCategorie}", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogSystem("Erreur rencontrer dans l'APi lors de l'ajout " + ex.ToString(), "CategorieServicesPhp-UpdateCategorie");

            }
            return rep;
        }

       
    }
}
