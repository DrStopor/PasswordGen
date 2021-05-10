namespace PasswordGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.setLengthString = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.setAutoSave = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.allInClusiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engBothCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.engLargeCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.engSmallCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cyrillicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rusBothCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.rusLargeCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.rusSmallCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.digitCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длина пароля:";
            // 
            // setLengthString
            // 
            this.setLengthString.Location = new System.Drawing.Point(139, 60);
            this.setLengthString.MaxLength = 5;
            this.setLengthString.Name = "setLengthString";
            this.setLengthString.Size = new System.Drawing.Size(55, 20);
            this.setLengthString.TabIndex = 1;
            this.setLengthString.Text = "14";
            this.setLengthString.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.setLengthString.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(16, 99);
            this.richTextBox1.MaxLength = 10000;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(259, 141);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(16, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "копировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(200, 250);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "сохранить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Сохранить в файл:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(17, 328);
            this.textBox2.MaxLength = 32;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(138, 20);
            this.textBox2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(160, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = ".txt";
            // 
            // setAutoSave
            // 
            this.setAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setAutoSave.Location = new System.Drawing.Point(16, 354);
            this.setAutoSave.Name = "setAutoSave";
            this.setAutoSave.Size = new System.Drawing.Size(158, 17);
            this.setAutoSave.TabIndex = 0;
            this.setAutoSave.Text = "автоматически сохранять";
            this.setAutoSave.UseVisualStyleBackColor = true;
            this.setAutoSave.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(182, 373);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(101, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "dmitriy.rudov@list.ru";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allInClusiveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(295, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // allInClusiveToolStripMenuItem
            // 
            this.allInClusiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullCheckMenu,
            this.englishToolStripMenuItem,
            this.cyrillicToolStripMenuItem,
            this.digitCheckMenu,
            this.symbolCheckMenu});
            this.allInClusiveToolStripMenuItem.Name = "allInClusiveToolStripMenuItem";
            this.allInClusiveToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.allInClusiveToolStripMenuItem.Text = "Наборы";
            // 
            // fullCheckMenu
            // 
            this.fullCheckMenu.CheckOnClick = true;
            this.fullCheckMenu.Name = "fullCheckMenu";
            this.fullCheckMenu.Size = new System.Drawing.Size(180, 22);
            this.fullCheckMenu.Text = "Все";
            this.fullCheckMenu.Click += new System.EventHandler(this.bothToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.engBothCheckMenu,
            this.engLargeCheckMenu,
            this.engSmallCheckMenu});
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // engBothCheckMenu
            // 
            this.engBothCheckMenu.Checked = true;
            this.engBothCheckMenu.CheckOnClick = true;
            this.engBothCheckMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.engBothCheckMenu.Name = "engBothCheckMenu";
            this.engBothCheckMenu.Size = new System.Drawing.Size(180, 22);
            this.engBothCheckMenu.Text = "Все";
            this.engBothCheckMenu.Click += new System.EventHandler(this.engBothCheckMenu_Click);
            // 
            // engLargeCheckMenu
            // 
            this.engLargeCheckMenu.CheckOnClick = true;
            this.engLargeCheckMenu.Name = "engLargeCheckMenu";
            this.engLargeCheckMenu.Size = new System.Drawing.Size(180, 22);
            this.engLargeCheckMenu.Text = "Заглавные";
            this.engLargeCheckMenu.Click += new System.EventHandler(this.upperCaseToolStripMenuItem_Click);
            // 
            // engSmallCheckMenu
            // 
            this.engSmallCheckMenu.CheckOnClick = true;
            this.engSmallCheckMenu.Name = "engSmallCheckMenu";
            this.engSmallCheckMenu.Size = new System.Drawing.Size(180, 22);
            this.engSmallCheckMenu.Text = "Прописные";
            this.engSmallCheckMenu.Click += new System.EventHandler(this.lowerCaseToolStripMenuItem_Click);
            // 
            // cyrillicToolStripMenuItem
            // 
            this.cyrillicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rusBothCheckMenu,
            this.rusLargeCheckMenu,
            this.rusSmallCheckMenu});
            this.cyrillicToolStripMenuItem.Name = "cyrillicToolStripMenuItem";
            this.cyrillicToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cyrillicToolStripMenuItem.Text = "Кирилица";
            // 
            // rusBothCheckMenu
            // 
            this.rusBothCheckMenu.CheckOnClick = true;
            this.rusBothCheckMenu.Name = "rusBothCheckMenu";
            this.rusBothCheckMenu.Size = new System.Drawing.Size(139, 22);
            this.rusBothCheckMenu.Text = "Все";
            this.rusBothCheckMenu.Click += new System.EventHandler(this.bothToolStripMenuItem2_Click);
            // 
            // rusLargeCheckMenu
            // 
            this.rusLargeCheckMenu.CheckOnClick = true;
            this.rusLargeCheckMenu.Name = "rusLargeCheckMenu";
            this.rusLargeCheckMenu.Size = new System.Drawing.Size(139, 22);
            this.rusLargeCheckMenu.Text = "Заглавные";
            this.rusLargeCheckMenu.Click += new System.EventHandler(this.upperCaseToolStripMenuItem1_Click);
            // 
            // rusSmallCheckMenu
            // 
            this.rusSmallCheckMenu.CheckOnClick = true;
            this.rusSmallCheckMenu.Name = "rusSmallCheckMenu";
            this.rusSmallCheckMenu.Size = new System.Drawing.Size(139, 22);
            this.rusSmallCheckMenu.Text = "Прописные";
            this.rusSmallCheckMenu.Click += new System.EventHandler(this.lowerCaseToolStripMenuItem1_Click);
            // 
            // digitCheckMenu
            // 
            this.digitCheckMenu.Checked = true;
            this.digitCheckMenu.CheckOnClick = true;
            this.digitCheckMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.digitCheckMenu.Name = "digitCheckMenu";
            this.digitCheckMenu.Size = new System.Drawing.Size(180, 22);
            this.digitCheckMenu.Text = "Цифры";
            this.digitCheckMenu.Click += new System.EventHandler(this.digitToolStripMenuItem_Click);
            // 
            // symbolCheckMenu
            // 
            this.symbolCheckMenu.Checked = true;
            this.symbolCheckMenu.CheckOnClick = true;
            this.symbolCheckMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.symbolCheckMenu.Name = "symbolCheckMenu";
            this.symbolCheckMenu.Size = new System.Drawing.Size(180, 22);
            this.symbolCheckMenu.Text = "Символы";
            this.symbolCheckMenu.Click += new System.EventHandler(this.symbolToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 395);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.setAutoSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.setLengthString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(310, 320);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox setLengthString;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox setAutoSave;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem allInClusiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cyrillicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digitCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem symbolCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem engBothCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem engLargeCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem engSmallCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem rusBothCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem rusLargeCheckMenu;
        private System.Windows.Forms.ToolStripMenuItem rusSmallCheckMenu;
    }
}

