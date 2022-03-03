
namespace WindowsFormsApp2
{
    partial class Form1
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
            this.btnWirte = new System.Windows.Forms.Button();
            this.btnreadAlltext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReactLinmes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWirte
            // 
            this.btnWirte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnWirte.Location = new System.Drawing.Point(106, 58);
            this.btnWirte.Name = "btnWirte";
            this.btnWirte.Size = new System.Drawing.Size(94, 30);
            this.btnWirte.TabIndex = 0;
            this.btnWirte.Text = "Wirte";
            this.btnWirte.UseVisualStyleBackColor = true;
            this.btnWirte.Click += new System.EventHandler(this.btnWirte_Click);
            // 
            // btnreadAlltext
            // 
            this.btnreadAlltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnreadAlltext.Location = new System.Drawing.Point(106, 110);
            this.btnreadAlltext.Name = "btnreadAlltext";
            this.btnreadAlltext.Size = new System.Drawing.Size(94, 30);
            this.btnreadAlltext.TabIndex = 1;
            this.btnreadAlltext.Text = "ReadAllText";
            this.btnreadAlltext.UseVisualStyleBackColor = true;
            this.btnreadAlltext.Click += new System.EventHandler(this.btnreadAlltext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(102, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnReactLinmes
            // 
            this.btnReactLinmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnReactLinmes.Location = new System.Drawing.Point(106, 159);
            this.btnReactLinmes.Name = "btnReactLinmes";
            this.btnReactLinmes.Size = new System.Drawing.Size(94, 30);
            this.btnReactLinmes.TabIndex = 3;
            this.btnReactLinmes.Text = "ReadAllLines";
            this.btnReactLinmes.UseVisualStyleBackColor = true;
            this.btnReactLinmes.Click += new System.EventHandler(this.btnReactLinmes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 625);
            this.Controls.Add(this.btnReactLinmes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnreadAlltext);
            this.Controls.Add(this.btnWirte);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWirte;
        private System.Windows.Forms.Button btnreadAlltext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReactLinmes;
    }
}

