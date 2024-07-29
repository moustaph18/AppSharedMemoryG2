using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Utils
{
    public class Logger
    {

        /// <summary>
        /// cette methode enregistre les logs au niveau du systeme dùexploitation
        /// </summary>
        /// <param name="libelle"></param>
        /// <param name="erreur"></param>
        public static void WriteLogSystem(string libelle, string erreur)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Groupe2SharedMemory";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }
    }
}