namespace Kursovaya_dotNET
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PointsList = new System.Windows.Forms.ListBox();
            this.label_Points = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.editCheckBox = new System.Windows.Forms.CheckBox();
            this.label_in_point = new System.Windows.Forms.Label();
            this.addWaysCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WaysList = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.topBorder = new System.Windows.Forms.PictureBox();
            this.minimizeButton = new System.Windows.Forms.PictureBox();
            this.ChangeWinFormButton = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.MainPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.topBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeWinFormButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // PointsList
            // 
            this.PointsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PointsList.BackColor = System.Drawing.Color.Gray;
            this.PointsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointsList.ForeColor = System.Drawing.Color.White;
            this.PointsList.FormattingEnabled = true;
            this.PointsList.ItemHeight = 24;
            this.PointsList.Location = new System.Drawing.Point(630, 56);
            this.PointsList.Name = "PointsList";
            this.PointsList.Size = new System.Drawing.Size(191, 220);
            this.PointsList.TabIndex = 1;
            this.PointsList.SelectedIndexChanged += new System.EventHandler(this.PointsList_SelectedIndexChanged);
            this.PointsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PointsList_KeyDown);
            // 
            // label_Points
            // 
            this.label_Points.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Points.AutoSize = true;
            this.label_Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Points.ForeColor = System.Drawing.Color.White;
            this.label_Points.Location = new System.Drawing.Point(690, 28);
            this.label_Points.Name = "label_Points";
            this.label_Points.Size = new System.Drawing.Size(76, 25);
            this.label_Points.TabIndex = 2;
            this.label_Points.Text = "Точки";
            this.label_Points.Click += new System.EventHandler(this.label_Points_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(630, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Очистить [F5]";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.Enabled = false;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(630, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 25);
            this.button3.TabIndex = 5;
            this.button3.Text = "Удалить точку [Del]";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // editCheckBox
            // 
            this.editCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editCheckBox.AutoSize = true;
            this.editCheckBox.Location = new System.Drawing.Point(306, 37);
            this.editCheckBox.Name = "editCheckBox";
            this.editCheckBox.Size = new System.Drawing.Size(89, 17);
            this.editCheckBox.TabIndex = 6;
            this.editCheckBox.Text = "Поиск точки";
            this.editCheckBox.UseVisualStyleBackColor = true;
            this.editCheckBox.Visible = false;
            this.editCheckBox.CheckedChanged += new System.EventHandler(this.editCheckBox_CheckedChanged);
            // 
            // label_in_point
            // 
            this.label_in_point.AutoSize = true;
            this.label_in_point.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_in_point.ForeColor = System.Drawing.Color.White;
            this.label_in_point.Location = new System.Drawing.Point(12, 34);
            this.label_in_point.Name = "label_in_point";
            this.label_in_point.Size = new System.Drawing.Size(100, 20);
            this.label_in_point.TabIndex = 7;
            this.label_in_point.Text = "Вы в точке: ";
            this.label_in_point.Click += new System.EventHandler(this.label_in_point_Click);
            // 
            // addWaysCheckBox
            // 
            this.addWaysCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addWaysCheckBox.AutoSize = true;
            this.addWaysCheckBox.Location = new System.Drawing.Point(426, 37);
            this.addWaysCheckBox.Name = "addWaysCheckBox";
            this.addWaysCheckBox.Size = new System.Drawing.Size(109, 17);
            this.addWaysCheckBox.TabIndex = 8;
            this.addWaysCheckBox.Text = "Добавить связи";
            this.addWaysCheckBox.UseVisualStyleBackColor = true;
            this.addWaysCheckBox.Visible = false;
            this.addWaysCheckBox.CheckedChanged += new System.EventHandler(this.addWaysCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(687, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ребра";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // WaysList
            // 
            this.WaysList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WaysList.BackColor = System.Drawing.Color.Gray;
            this.WaysList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WaysList.ForeColor = System.Drawing.Color.White;
            this.WaysList.FormattingEnabled = true;
            this.WaysList.ItemHeight = 24;
            this.WaysList.Location = new System.Drawing.Point(630, 347);
            this.WaysList.Name = "WaysList";
            this.WaysList.Size = new System.Drawing.Size(191, 220);
            this.WaysList.TabIndex = 10;
            this.WaysList.SelectedIndexChanged += new System.EventHandler(this.WaysList_SelectedIndexChanged);
            this.WaysList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WaysList_KeyDown);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.Gray;
            this.button5.Enabled = false;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(630, 578);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 25);
            this.button5.TabIndex = 12;
            this.button5.Text = "Удалить ребро [Del]";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 609);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(602, 46);
            this.button2.TabIndex = 13;
            this.button2.Text = "Поиск максимального незавсимого множества [Enter]";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(229, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "ЛКМ - Создать вершину    ПКМ - построить ребро";
            // 
            // topBorder
            // 
            this.topBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBorder.BackColor = System.Drawing.Color.Transparent;
            this.topBorder.Location = new System.Drawing.Point(1, 1);
            this.topBorder.Name = "topBorder";
            this.topBorder.Size = new System.Drawing.Size(744, 22);
            this.topBorder.TabIndex = 18;
            this.topBorder.TabStop = false;
            this.topBorder.DoubleClick += new System.EventHandler(this.topBorder_DoubleClick);
            this.topBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBorder_MouseMove);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.Image = global::Kursovaya_dotNET.Properties.Resources.minimaze1;
            this.minimizeButton.Location = new System.Drawing.Point(751, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(22, 22);
            this.minimizeButton.TabIndex = 17;
            this.minimizeButton.TabStop = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            this.minimizeButton.MouseEnter += new System.EventHandler(this.minimizeButton_MouseEnter);
            this.minimizeButton.MouseLeave += new System.EventHandler(this.minimizeButton_MouseLeave);
            // 
            // ChangeWinFormButton
            // 
            this.ChangeWinFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeWinFormButton.BackColor = System.Drawing.Color.Transparent;
            this.ChangeWinFormButton.Image = global::Kursovaya_dotNET.Properties.Resources.full_or_min1;
            this.ChangeWinFormButton.Location = new System.Drawing.Point(779, 0);
            this.ChangeWinFormButton.Name = "ChangeWinFormButton";
            this.ChangeWinFormButton.Size = new System.Drawing.Size(22, 22);
            this.ChangeWinFormButton.TabIndex = 16;
            this.ChangeWinFormButton.TabStop = false;
            this.ChangeWinFormButton.Click += new System.EventHandler(this.ChangeWinFormButton_Click);
            this.ChangeWinFormButton.MouseEnter += new System.EventHandler(this.ChangeWinFormButton_MouseEnter);
            this.ChangeWinFormButton.MouseLeave += new System.EventHandler(this.ChangeWinFormButton_MouseLeave);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Image = global::Kursovaya_dotNET.Properties.Resources.x3;
            this.ExitButton.Location = new System.Drawing.Point(807, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 23);
            this.ExitButton.TabIndex = 15;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // MainPicture
            // 
            this.MainPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPicture.BackColor = System.Drawing.Color.Gray;
            this.MainPicture.Location = new System.Drawing.Point(12, 57);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(602, 546);
            this.MainPicture.TabIndex = 0;
            this.MainPicture.TabStop = false;
            this.MainPicture.SizeChanged += new System.EventHandler(this.MainPicture_SizeChanged);
            this.MainPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            this.MainPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.MainPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(828, 667);
            this.ControlBox = false;
            this.Controls.Add(this.topBorder);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.ChangeWinFormButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WaysList);
            this.Controls.Add(this.addWaysCheckBox);
            this.Controls.Add(this.label_in_point);
            this.Controls.Add(this.editCheckBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_Points);
            this.Controls.Add(this.PointsList);
            this.Controls.Add(this.MainPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "ChGraph";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.topBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeWinFormButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPicture;
        private System.Windows.Forms.ListBox PointsList;
        private System.Windows.Forms.Label label_Points;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox editCheckBox;
        private System.Windows.Forms.Label label_in_point;
        private System.Windows.Forms.CheckBox addWaysCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox WaysList;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.PictureBox ChangeWinFormButton;
        private System.Windows.Forms.PictureBox minimizeButton;
        private System.Windows.Forms.PictureBox topBorder;
    }
}

