namespace NotificationL3GLG2
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.NotificationG2 = new System.ServiceProcess.ServiceProcessInstaller();
            this.NotificationL3GL = new System.ServiceProcess.ServiceInstaller();
            // 
            // NotificationG2
            // 
            this.NotificationG2.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.NotificationG2.Password = null;
            this.NotificationG2.Username = null;
            this.NotificationG2.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // NotificationL3GL
            // 
            this.NotificationL3GL.ServiceName = "Service1";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.NotificationG2,
            this.NotificationL3GL});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller NotificationG2;
        private System.ServiceProcess.ServiceInstaller NotificationL3GL;
    }
}