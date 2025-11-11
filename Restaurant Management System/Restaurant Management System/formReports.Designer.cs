namespace Restaurant_Management_System
{
    partial class formReports
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
            this.btnprod = new System.Windows.Forms.Button();
            this.btnstaff = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnprod
            // 
            this.btnprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprod.Location = new System.Drawing.Point(14, 15);
            this.btnprod.Name = "btnprod";
            this.btnprod.Size = new System.Drawing.Size(142, 36);
            this.btnprod.TabIndex = 1;
            this.btnprod.Text = "Product Report";
            this.btnprod.UseVisualStyleBackColor = true;
            this.btnprod.Click += new System.EventHandler(this.btnprod_Click);
            // 
            // btnstaff
            // 
            this.btnstaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstaff.Location = new System.Drawing.Point(177, 15);
            this.btnstaff.Name = "btnstaff";
            this.btnstaff.Size = new System.Drawing.Size(125, 36);
            this.btnstaff.TabIndex = 2;
            this.btnstaff.Text = "Staff Report";
            this.btnstaff.UseVisualStyleBackColor = true;
            this.btnstaff.Click += new System.EventHandler(this.btnstaff_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(20, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 389);
            this.panel1.TabIndex = 0;
            // 
            // formReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Restaurant_Management_System.Properties.Resources.WhatsApp_Image_2025_01_16_at_13_35_07_ecd9e38d;
            this.ClientSize = new System.Drawing.Size(718, 463);
            this.Controls.Add(this.btnstaff);
            this.Controls.Add(this.btnprod);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formReports";
            this.Text = "formReports";
            this.Load += new System.EventHandler(this.formReports_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnprod;
        private System.Windows.Forms.Button btnstaff;
        private System.Windows.Forms.Panel panel1;
    }
}