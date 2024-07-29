using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ApplicationSharedMemory.Model;


namespace ApplicationSharedMemory.Service
{

    public class CategorieService
    {
        /// <summary>
        /// Cette methode personne de lister tous les categories 
        /// </summary>
        /// <returns></returns>
        public List<Categorie> servGetListeCategorie()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Categorie>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApi"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("api/Categories/GetCategorie").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Categorie>>(responseData);
            }
            return services;
        }
        /// <summary>
        /// Cette methode d'enrigistrer une nouvelle categorie
        /// </summary>
        /// <param name="categorie">categorie</param>
        /// <returns>true si ok; sinon false</returns>
        public bool AddCategorie(Categorie categorie)
        {
            bool rep =false;
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
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApi"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("api/Categories/PostCategorie",content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {

                    }
                }
            }catch (Exception ex)
            {

            }
            return rep;
        }
        /// <summary>
        /// Cette Methode permet la suppression d'une categorie via son id 
        /// </summary>
        /// </summary>
        /// <param name="idCategorie">idCategorie</param>
        /// <returns> true si ok; sinon false</returns>
        public bool DeleteCategorie(int idCategorie)
        {
            bool rep = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApi"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.DeleteAsync($"api/Categories/DeleteCategorie/{idCategorie}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception si nécessaire
            }
            return rep;
        }

        /// <summary>
        /// Cette methode permet d'obtenir une categorie de par son id 
        /// </summary>
        /// <param name="idCategorie"></param>
        /// <returns></returns>
        public Categorie GetCategorieById(int idCategorie)
        {
            var services = new Categorie();
            
            try
            {
                using (var client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApi"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync($"api/Categories/GetCategorie/{idCategorie}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        services = Newtonsoft.Json.JsonConvert.DeserializeObject<Categorie>(responseData);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception si nécessaire
            }
            return services;
        }


        /// <summary>
        /// Cette methode permet de modifier une categorie
        /// </summary>
        /// <param name="categorie">categorie</param>
        /// <returns> true si ok ; sinon false</returns>
        public bool UpdateCategorie(Categorie categorie)
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
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["LienServeurApi"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PutAsync($"api/Categories/PutCategorie/{categorie.idCategorie}", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception si nécessaire
            }
            return rep;
        }

    }
}
