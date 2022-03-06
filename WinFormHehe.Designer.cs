namespace Life_Without_Water__PBL_
{
    partial class WinFormHehe
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
            this.LBL_Details = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBL_Details
            // 
            this.LBL_Details.AutoSize = true;
            this.LBL_Details.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.LBL_Details.Location = new System.Drawing.Point(533, 276);
            this.LBL_Details.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Details.Name = "LBL_Details";
            this.LBL_Details.Size = new System.Drawing.Size(1049, 40);
            this.LBL_Details.TabIndex = 0;
            this.LBL_Details.Text = "You managed to survive the water shortage, but at what cost?";
            // 
            // WinFormHehe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.LBL_Details);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WinFormHehe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinFormHehe";
            this.Load += new System.EventHandler(this.WinFormHehe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WinFormHehe_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Details;
    }
}