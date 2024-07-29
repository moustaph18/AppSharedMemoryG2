using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NotificationL3GLG2
{
    public partial class Service1 : ServiceBase
    {
        private static Timer aTimer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new System.Timers.Timer(1000);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Interval = 1000;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            WriteLogSystem("Demarage du service Notification GL3G2 ", String.Format("Le service a demarrer a {0}", DateTime.Now));

        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                ProcessData().Wait();
            }
            catch(Exception ex) {

            }
            aTimer.Start();
        }
        private static async Task ProcessData()
        {
            try
            {
                WriteLogSystem("Execution du service de notification ", String.Format(" a {0}", DateTime.Now));

            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
            WriteLogSystem("Arret du service Notification GL3G2 ", String.Format("Le service a demarrer a {0}", DateTime.Now));

        }
        /// <summary>
        /// Cette methode permet de logger dans le systeme
        /// </summary>
        /// <param name="libelle">titre de l'erreur</param>
        /// <param name="erreur">Message d'erreur</param>
        public static void WriteLogSystem(string libelle, string erreur)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "NotificationL3GLG2 - ";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }
    }
}
