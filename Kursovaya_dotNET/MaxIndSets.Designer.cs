namespace Kursovaya_dotNET
{
    partial class MaxIndSets
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
            this.MaximumSets = new System.Windows.Forms.ListBox();
            this.OtherSets = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // MaximumSets
            // 
            this.MaximumSets.BackColor = System.Drawing.Color.Gray;
            this.MaximumSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSets.ForeColor = System.Drawing.Color.White;
            this.MaximumSets.FormattingEnabled = true;
            this.MaximumSets.ItemHeight = 31;
            this.MaximumSets.Location = new System.Drawing.Point(13, 60);
            this.MaximumSets.Name = "MaximumSets";
            this.MaximumSets.Size = new System.Drawing.Size(375, 159);
            this.MaximumSets.TabIndex = 0;
            this.MaximumSets.SelectedIndexChanged += new System.EventHandler(this.MaximumSets_SelectedIndexChanged);
            this.MaximumSets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaximumSets_KeyDown);
            // 
            // OtherSets
            // 
            this.OtherSets.BackColor = System.Drawing.Color.Gray;
            this.OtherSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OtherSets.ForeColor = System.Drawing.Color.White;
            this.OtherSets.FormattingEnabled = true;
            this.OtherSets.ItemHeight = 31;
            this.OtherSets.Location = new System.Drawing.Point(13, 263);
            this.OtherSets.Name = "OtherSets";
            this.OtherSets.Size = new System.Drawing.Size(375, 190);
            this.OtherSets.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(124, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Максимальные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(142, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Остальные";
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Image = global::Kursovaya_dotNET.Properties.Resources.x3;
            this.ExitButton.Location = new System.Drawing.Point(379, -1);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 23);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // MaxIndSets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(400, 464);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OtherSets);
            this.Controls.Add(this.MaximumSets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaxIndSets";
            this.ShowIcon = false;
            this.Text = "Независимые множества";
            this.Load += new System.EventHandler(this.MaxIndSets_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MaxIndSets_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MaximumSets;
        private System.Windows.Forms.ListBox OtherSets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ExitButton;
    }
}