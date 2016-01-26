namespace EnhanceForm
{
    partial class EnhanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(1, 1);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(298, 298);
            this.MainContainer.TabIndex = 0;
            // 
            // EnhanceForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.MainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(171, 39);
            this.Name = "EnhanceForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel MainContainer;
    }
}