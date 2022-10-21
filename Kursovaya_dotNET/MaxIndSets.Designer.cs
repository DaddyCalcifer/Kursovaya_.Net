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
            this.SuspendLayout();
            // 
            // MaximumSets
            // 
            this.MaximumSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSets.FormattingEnabled = true;
            this.MaximumSets.ItemHeight = 31;
            this.MaximumSets.Location = new System.Drawing.Point(13, 38);
            this.MaximumSets.Name = "MaximumSets";
            this.MaximumSets.Size = new System.Drawing.Size(375, 159);
            this.MaximumSets.TabIndex = 0;
            // 
            // OtherSets
            // 
            this.OtherSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OtherSets.FormattingEnabled = true;
            this.OtherSets.ItemHeight = 31;
            this.OtherSets.Location = new System.Drawing.Point(13, 244);
            this.OtherSets.Name = "OtherSets";
            this.OtherSets.Size = new System.Drawing.Size(375, 190);
            this.OtherSets.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(127, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Максимальные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(142, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Остальные";
            // 
            // MaxIndSets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 452);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OtherSets);
            this.Controls.Add(this.MaximumSets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaxIndSets";
            this.ShowIcon = false;
            this.Text = "Независимые множества";
            this.Load += new System.EventHandler(this.MaxIndSets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MaximumSets;
        private System.Windows.Forms.ListBox OtherSets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}