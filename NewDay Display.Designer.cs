namespace Life_Without_Water__PBL_
{
    partial class NewDay_Display
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
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.LBL_DaysLeft = new System.Windows.Forms.Label();
            this.LBL_DaysLABEL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 75;
            this.bunifuElipse1.TargetControl = this;
            // 
            // LBL_DaysLeft
            // 
            this.LBL_DaysLeft.AutoSize = true;
            this.LBL_DaysLeft.BackColor = System.Drawing.Color.Transparent;
            this.LBL_DaysLeft.Font = new System.Drawing.Font("Century Gothic", 200F);
            this.LBL_DaysLeft.ForeColor = System.Drawing.Color.White;
            this.LBL_DaysLeft.Location = new System.Drawing.Point(1018, 246);
            this.LBL_DaysLeft.Name = "LBL_DaysLeft";
            this.LBL_DaysLeft.Size = new System.Drawing.Size(281, 318);
            this.LBL_DaysLeft.TabIndex = 0;
            this.LBL_DaysLeft.Text = "5";
            // 
            // LBL_DaysLABEL
            // 
            this.LBL_DaysLABEL.AutoSize = true;
            this.LBL_DaysLABEL.BackColor = System.Drawing.Color.Transparent;
            this.LBL_DaysLABEL.Font = new System.Drawing.Font("Century Gothic", 200F);
            this.LBL_DaysLABEL.ForeColor = System.Drawing.Color.White;
            this.LBL_DaysLABEL.Location = new System.Drawing.Point(333, 246);
            this.LBL_DaysLABEL.Name = "LBL_DaysLABEL";
            this.LBL_DaysLABEL.Size = new System.Drawing.Size(688, 318);
            this.LBL_DaysLABEL.TabIndex = 1;
            this.LBL_DaysLABEL.Text = "DAY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(697, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Press Enter To Continue";
            // 
            // NewDay_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1536, 920);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_DaysLABEL);
            this.Controls.Add(this.LBL_DaysLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewDay_Display";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewDay_Display";
            this.Load += new System.EventHandler(this.NewDay_Display_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewDay_Display_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label LBL_DaysLABEL;
        private System.Windows.Forms.Label LBL_DaysLeft;
        private System.Windows.Forms.Label label1;
    }
}