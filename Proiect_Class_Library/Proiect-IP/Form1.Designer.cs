
namespace IP_Proiect
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sidebarMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelMenu = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.PictureBox();
            this.panelHome = new System.Windows.Forms.Panel();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonNew = new System.Windows.Forms.Button();
            this.panelH = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Panel();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.homeTimer = new System.Windows.Forms.Timer(this.components);
            this.helpTimer = new System.Windows.Forms.Timer(this.components);
            this.panelDay = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelSunday = new System.Windows.Forms.Label();
            this.labelSaturday = new System.Windows.Forms.Label();
            this.labelFriday = new System.Windows.Forms.Label();
            this.labelThursday = new System.Windows.Forms.Label();
            this.labelWednesday = new System.Windows.Forms.Label();
            this.labelTuesday = new System.Windows.Forms.Label();
            this.labelMonday = new System.Windows.Forms.Label();
            this.groupBoxCalendar = new System.Windows.Forms.GroupBox();
            this.labelLunaAn = new System.Windows.Forms.Label();
            this.labelGet = new System.Windows.Forms.Label();
            this.groupBoxNote = new System.Windows.Forms.GroupBox();
            this.labelAllNotes = new System.Windows.Forms.Label();
            this.listBoxAllNotes = new System.Windows.Forms.ListBox();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.buttonEditNote = new System.Windows.Forms.Button();
            this.labelNumberOfNotes = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonAddNote = new System.Windows.Forms.Button();
            this.dateTimePickerNote = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxNewNote = new System.Windows.Forms.RichTextBox();
            this.sidebarMenu.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).BeginInit();
            this.panelHome.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelH.SuspendLayout();
            this.panelHelp.SuspendLayout();
            this.help.SuspendLayout();
            this.groupBoxCalendar.SuspendLayout();
            this.groupBoxNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarMenu
            // 
            this.sidebarMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.sidebarMenu.Controls.Add(this.panelMenu);
            this.sidebarMenu.Controls.Add(this.panelHome);
            this.sidebarMenu.Controls.Add(this.panelHelp);
            this.sidebarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarMenu.Location = new System.Drawing.Point(0, 0);
            this.sidebarMenu.Margin = new System.Windows.Forms.Padding(2);
            this.sidebarMenu.MaximumSize = new System.Drawing.Size(169, 574);
            this.sidebarMenu.MinimumSize = new System.Drawing.Size(64, 574);
            this.sidebarMenu.Name = "sidebarMenu";
            this.sidebarMenu.Size = new System.Drawing.Size(169, 574);
            this.sidebarMenu.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.labelMenu);
            this.panelMenu.Controls.Add(this.menuButton);
            this.panelMenu.Location = new System.Drawing.Point(2, 2);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(166, 81);
            this.panelMenu.TabIndex = 0;
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenu.ForeColor = System.Drawing.Color.White;
            this.labelMenu.Location = new System.Drawing.Point(62, 32);
            this.labelMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(56, 18);
            this.labelMenu.TabIndex = 1;
            this.labelMenu.Text = "Menu";
            // 
            // menuButton
            // 
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButton.Image = ((System.Drawing.Image)(resources.GetObject("menuButton.Image")));
            this.menuButton.Location = new System.Drawing.Point(22, 32);
            this.menuButton.Margin = new System.Windows.Forms.Padding(2);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(20, 19);
            this.menuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuButton.TabIndex = 0;
            this.menuButton.TabStop = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // panelHome
            // 
            this.panelHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.panelHome.Controls.Add(this.buttonModify);
            this.panelHome.Controls.Add(this.buttonDelete);
            this.panelHome.Controls.Add(this.panel1);
            this.panelHome.Controls.Add(this.panelH);
            this.panelHome.Location = new System.Drawing.Point(2, 87);
            this.panelHome.Margin = new System.Windows.Forms.Padding(2);
            this.panelHome.MaximumSize = new System.Drawing.Size(169, 193);
            this.panelHome.MinimumSize = new System.Drawing.Size(169, 52);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(169, 52);
            this.panelHome.TabIndex = 4;
            // 
            // buttonModify
            // 
            this.buttonModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.buttonModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModify.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModify.ForeColor = System.Drawing.Color.Transparent;
            this.buttonModify.Image = global::IP_Proiect.Properties.Resources.punct;
            this.buttonModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonModify.Location = new System.Drawing.Point(-4, 100);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(2);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonModify.Size = new System.Drawing.Size(183, 48);
            this.buttonModify.TabIndex = 6;
            this.buttonModify.Text = "          Delete all";
            this.buttonModify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonModify.UseVisualStyleBackColor = false;
            this.buttonModify.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.Transparent;
            this.buttonDelete.Image = global::IP_Proiect.Properties.Resources.punct;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(-4, 145);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonDelete.Size = new System.Drawing.Size(183, 48);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "          View all";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonGetAll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.buttonNew);
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 41);
            this.panel1.TabIndex = 3;
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew.ForeColor = System.Drawing.Color.Transparent;
            this.buttonNew.Image = global::IP_Proiect.Properties.Resources.punct;
            this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNew.Location = new System.Drawing.Point(-4, 0);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonNew.Size = new System.Drawing.Size(183, 48);
            this.buttonNew.TabIndex = 2;
            this.buttonNew.Text = "          New";
            this.buttonNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // panelH
            // 
            this.panelH.Controls.Add(this.buttonHome);
            this.panelH.Location = new System.Drawing.Point(0, 0);
            this.panelH.Margin = new System.Windows.Forms.Padding(2);
            this.panelH.Name = "panelH";
            this.panelH.Size = new System.Drawing.Size(166, 54);
            this.panelH.TabIndex = 1;
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Image = global::IP_Proiect.Properties.Resources.home;
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.Location = new System.Drawing.Point(-11, -2);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonHome.Size = new System.Drawing.Size(184, 60);
            this.buttonHome.TabIndex = 2;
            this.buttonHome.Text = "          Home";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panelHelp
            // 
            this.panelHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.panelHelp.Controls.Add(this.buttonAbout);
            this.panelHelp.Controls.Add(this.buttonInfo);
            this.panelHelp.Controls.Add(this.help);
            this.panelHelp.Location = new System.Drawing.Point(2, 143);
            this.panelHelp.Margin = new System.Windows.Forms.Padding(2);
            this.panelHelp.MaximumSize = new System.Drawing.Size(169, 167);
            this.panelHelp.MinimumSize = new System.Drawing.Size(169, 52);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(169, 52);
            this.panelHelp.TabIndex = 4;
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.ForeColor = System.Drawing.Color.Transparent;
            this.buttonAbout.Image = global::IP_Proiect.Properties.Resources.punct;
            this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAbout.Location = new System.Drawing.Point(-4, 52);
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonAbout.Size = new System.Drawing.Size(183, 60);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Text = "          About";
            this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAbout.UseVisualStyleBackColor = false;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInfo.ForeColor = System.Drawing.Color.Transparent;
            this.buttonInfo.Image = global::IP_Proiect.Properties.Resources.punct;
            this.buttonInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonInfo.Location = new System.Drawing.Point(-4, 106);
            this.buttonInfo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonInfo.Size = new System.Drawing.Size(183, 60);
            this.buttonInfo.TabIndex = 6;
            this.buttonInfo.Text = "          Info";
            this.buttonInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonInfo.UseVisualStyleBackColor = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // help
            // 
            this.help.Controls.Add(this.buttonHelp);
            this.help.Location = new System.Drawing.Point(0, 0);
            this.help.Margin = new System.Windows.Forms.Padding(2);
            this.help.MaximumSize = new System.Drawing.Size(169, 162);
            this.help.MinimumSize = new System.Drawing.Size(169, 52);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(169, 52);
            this.help.TabIndex = 3;
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.ForeColor = System.Drawing.Color.White;
            this.buttonHelp.Image = global::IP_Proiect.Properties.Resources.info;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(-8, -5);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonHelp.Size = new System.Drawing.Size(184, 60);
            this.buttonHelp.TabIndex = 2;
            this.buttonHelp.Text = "          Help";
            this.buttonHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // homeTimer
            // 
            this.homeTimer.Interval = 10;
            this.homeTimer.Tick += new System.EventHandler(this.homeTimer_Tick);
            // 
            // helpTimer
            // 
            this.helpTimer.Interval = 10;
            this.helpTimer.Tick += new System.EventHandler(this.helpTimer_Tick);
            // 
            // panelDay
            // 
            this.panelDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDay.Location = new System.Drawing.Point(9, 76);
            this.panelDay.Margin = new System.Windows.Forms.Padding(2);
            this.panelDay.Name = "panelDay";
            this.panelDay.Size = new System.Drawing.Size(521, 406);
            this.panelDay.TabIndex = 1;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrev.Location = new System.Drawing.Point(392, 486);
            this.buttonPrev.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(78, 30);
            this.buttonPrev.TabIndex = 2;
            this.buttonPrev.Text = "Previous";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(474, 486);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(56, 30);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelSunday
            // 
            this.labelSunday.AutoSize = true;
            this.labelSunday.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSunday.Location = new System.Drawing.Point(27, 47);
            this.labelSunday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSunday.Name = "labelSunday";
            this.labelSunday.Size = new System.Drawing.Size(61, 17);
            this.labelSunday.TabIndex = 4;
            this.labelSunday.Text = "Sunday";
            // 
            // labelSaturday
            // 
            this.labelSaturday.AutoSize = true;
            this.labelSaturday.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaturday.Location = new System.Drawing.Point(454, 47);
            this.labelSaturday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSaturday.Name = "labelSaturday";
            this.labelSaturday.Size = new System.Drawing.Size(72, 17);
            this.labelSaturday.TabIndex = 5;
            this.labelSaturday.Text = "Saturday";
            // 
            // labelFriday
            // 
            this.labelFriday.AutoSize = true;
            this.labelFriday.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriday.Location = new System.Drawing.Point(390, 47);
            this.labelFriday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFriday.Name = "labelFriday";
            this.labelFriday.Size = new System.Drawing.Size(50, 17);
            this.labelFriday.TabIndex = 6;
            this.labelFriday.Text = "Friday";
            // 
            // labelThursday
            // 
            this.labelThursday.AutoSize = true;
            this.labelThursday.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThursday.Location = new System.Drawing.Point(310, 47);
            this.labelThursday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelThursday.Name = "labelThursday";
            this.labelThursday.Size = new System.Drawing.Size(74, 17);
            this.labelThursday.TabIndex = 7;
            this.labelThursday.Text = "Thursday";
            // 
            // labelWednesday
            // 
            this.labelWednesday.AutoSize = true;
            this.labelWednesday.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWednesday.Location = new System.Drawing.Point(224, 47);
            this.labelWednesday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWednesday.Name = "labelWednesday";
            this.labelWednesday.Size = new System.Drawing.Size(89, 17);
            this.labelWednesday.TabIndex = 8;
            this.labelWednesday.Text = "Wednesday";
            // 
            // labelTuesday
            // 
            this.labelTuesday.AutoSize = true;
            this.labelTuesday.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTuesday.Location = new System.Drawing.Point(159, 47);
            this.labelTuesday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTuesday.Name = "labelTuesday";
            this.labelTuesday.Size = new System.Drawing.Size(66, 17);
            this.labelTuesday.TabIndex = 9;
            this.labelTuesday.Text = "Tuesday";
            // 
            // labelMonday
            // 
            this.labelMonday.AutoSize = true;
            this.labelMonday.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonday.Location = new System.Drawing.Point(87, 47);
            this.labelMonday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMonday.Name = "labelMonday";
            this.labelMonday.Size = new System.Drawing.Size(62, 17);
            this.labelMonday.TabIndex = 10;
            this.labelMonday.Text = "Monday";
            // 
            // groupBoxCalendar
            // 
            this.groupBoxCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCalendar.Controls.Add(this.labelLunaAn);
            this.groupBoxCalendar.Controls.Add(this.labelMonday);
            this.groupBoxCalendar.Controls.Add(this.labelGet);
            this.groupBoxCalendar.Controls.Add(this.buttonNext);
            this.groupBoxCalendar.Controls.Add(this.labelTuesday);
            this.groupBoxCalendar.Controls.Add(this.buttonPrev);
            this.groupBoxCalendar.Controls.Add(this.labelWednesday);
            this.groupBoxCalendar.Controls.Add(this.labelThursday);
            this.groupBoxCalendar.Controls.Add(this.labelFriday);
            this.groupBoxCalendar.Controls.Add(this.labelSaturday);
            this.groupBoxCalendar.Controls.Add(this.labelSunday);
            this.groupBoxCalendar.Controls.Add(this.panelDay);
            this.groupBoxCalendar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCalendar.Location = new System.Drawing.Point(475, 2);
            this.groupBoxCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCalendar.Name = "groupBoxCalendar";
            this.groupBoxCalendar.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCalendar.Size = new System.Drawing.Size(535, 526);
            this.groupBoxCalendar.TabIndex = 11;
            this.groupBoxCalendar.TabStop = false;
            this.groupBoxCalendar.Text = "Calendar";
            // 
            // labelLunaAn
            // 
            this.labelLunaAn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLunaAn.Location = new System.Drawing.Point(169, 20);
            this.labelLunaAn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLunaAn.Name = "labelLunaAn";
            this.labelLunaAn.Size = new System.Drawing.Size(238, 20);
            this.labelLunaAn.TabIndex = 11;
            this.labelLunaAn.Text = "MONTH YEAR";
            this.labelLunaAn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelGet
            // 
            this.labelGet.AutoSize = true;
            this.labelGet.Location = new System.Drawing.Point(6, 486);
            this.labelGet.Name = "labelGet";
            this.labelGet.Size = new System.Drawing.Size(241, 34);
            this.labelGet.TabIndex = 10;
            this.labelGet.Text = "We are currently awaiting \r\nthe retrieval of weather  data.";
            this.labelGet.Visible = false;
            // 
            // groupBoxNote
            // 
            this.groupBoxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNote.Controls.Add(this.labelAllNotes);
            this.groupBoxNote.Controls.Add(this.listBoxAllNotes);
            this.groupBoxNote.Controls.Add(this.listBoxNotes);
            this.groupBoxNote.Controls.Add(this.buttonEditNote);
            this.groupBoxNote.Controls.Add(this.labelNumberOfNotes);
            this.groupBoxNote.Controls.Add(this.textBoxLocation);
            this.groupBoxNote.Controls.Add(this.textBoxTitle);
            this.groupBoxNote.Controls.Add(this.buttonAddNote);
            this.groupBoxNote.Controls.Add(this.dateTimePickerNote);
            this.groupBoxNote.Controls.Add(this.richTextBoxNewNote);
            this.groupBoxNote.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNote.Location = new System.Drawing.Point(176, 2);
            this.groupBoxNote.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxNote.Name = "groupBoxNote";
            this.groupBoxNote.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxNote.Size = new System.Drawing.Size(295, 526);
            this.groupBoxNote.TabIndex = 12;
            this.groupBoxNote.TabStop = false;
            this.groupBoxNote.Text = "Notes";
            // 
            // labelAllNotes
            // 
            this.labelAllNotes.AutoSize = true;
            this.labelAllNotes.Location = new System.Drawing.Point(17, 37);
            this.labelAllNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAllNotes.Name = "labelAllNotes";
            this.labelAllNotes.Size = new System.Drawing.Size(0, 17);
            this.labelAllNotes.TabIndex = 12;
            // 
            // listBoxAllNotes
            // 
            this.listBoxAllNotes.FormattingEnabled = true;
            this.listBoxAllNotes.ItemHeight = 17;
            this.listBoxAllNotes.Location = new System.Drawing.Point(17, 60);
            this.listBoxAllNotes.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAllNotes.Name = "listBoxAllNotes";
            this.listBoxAllNotes.Size = new System.Drawing.Size(262, 395);
            this.listBoxAllNotes.TabIndex = 11;
            this.listBoxAllNotes.Visible = false;
            this.listBoxAllNotes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxAllNotes_DrawItem);
            this.listBoxAllNotes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxAllNotes_MouseMove);
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.ItemHeight = 17;
            this.listBoxNotes.Location = new System.Drawing.Point(20, 320);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(260, 123);
            this.listBoxNotes.TabIndex = 6;
            this.listBoxNotes.Visible = false;
            this.listBoxNotes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxNotes_DrawItem);
            this.listBoxNotes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxNotes_MouseMove);
            // 
            // buttonEditNote
            // 
            this.buttonEditNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditNote.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditNote.Location = new System.Drawing.Point(197, 268);
            this.buttonEditNote.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditNote.Name = "buttonEditNote";
            this.buttonEditNote.Size = new System.Drawing.Size(79, 22);
            this.buttonEditNote.TabIndex = 8;
            this.buttonEditNote.Text = "Edit Note";
            this.buttonEditNote.UseVisualStyleBackColor = true;
            this.buttonEditNote.Visible = false;
            this.buttonEditNote.Click += new System.EventHandler(this.buttonEditNote_Click);
            // 
            // labelNumberOfNotes
            // 
            this.labelNumberOfNotes.AutoSize = true;
            this.labelNumberOfNotes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNumberOfNotes.Location = new System.Drawing.Point(17, 295);
            this.labelNumberOfNotes.Name = "labelNumberOfNotes";
            this.labelNumberOfNotes.Size = new System.Drawing.Size(0, 13);
            this.labelNumberOfNotes.TabIndex = 7;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLocation.Location = new System.Drawing.Point(17, 230);
            this.textBoxLocation.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(111, 23);
            this.textBoxLocation.TabIndex = 5;
            this.textBoxLocation.Text = "Location";
            this.textBoxLocation.Visible = false;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(17, 32);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(111, 23);
            this.textBoxTitle.TabIndex = 4;
            this.textBoxTitle.Text = "Title";
            this.textBoxTitle.Visible = false;
            // 
            // buttonAddNote
            // 
            this.buttonAddNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNote.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddNote.Location = new System.Drawing.Point(197, 268);
            this.buttonAddNote.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNote.Name = "buttonAddNote";
            this.buttonAddNote.Size = new System.Drawing.Size(79, 22);
            this.buttonAddNote.TabIndex = 3;
            this.buttonAddNote.Text = "Add Note";
            this.buttonAddNote.UseVisualStyleBackColor = true;
            this.buttonAddNote.Visible = false;
            this.buttonAddNote.Click += new System.EventHandler(this.buttonAddNote_Click);
            // 
            // dateTimePickerNote
            // 
            this.dateTimePickerNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerNote.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNote.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNote.Location = new System.Drawing.Point(149, 230);
            this.dateTimePickerNote.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNote.Name = "dateTimePickerNote";
            this.dateTimePickerNote.Size = new System.Drawing.Size(128, 23);
            this.dateTimePickerNote.TabIndex = 2;
            this.dateTimePickerNote.Visible = false;
            // 
            // richTextBoxNewNote
            // 
            this.richTextBoxNewNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxNewNote.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxNewNote.Location = new System.Drawing.Point(17, 60);
            this.richTextBoxNewNote.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxNewNote.Name = "richTextBoxNewNote";
            this.richTextBoxNewNote.Size = new System.Drawing.Size(260, 158);
            this.richTextBoxNewNote.TabIndex = 0;
            this.richTextBoxNewNote.Text = "";
            this.richTextBoxNewNote.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 536);
            this.Controls.Add(this.groupBoxNote);
            this.Controls.Add(this.groupBoxCalendar);
            this.Controls.Add(this.sidebarMenu);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notes";
            this.sidebarMenu.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).EndInit();
            this.panelHome.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelH.ResumeLayout(false);
            this.panelHelp.ResumeLayout(false);
            this.help.ResumeLayout(false);
            this.groupBoxCalendar.ResumeLayout(false);
            this.groupBoxCalendar.PerformLayout();
            this.groupBoxNote.ResumeLayout(false);
            this.groupBoxNote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel sidebarMenu;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelH;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.PictureBox menuButton;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Timer homeTimer;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Timer helpTimer;
        private System.Windows.Forms.FlowLayoutPanel panelDay;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelSunday;
        private System.Windows.Forms.Label labelSaturday;
        private System.Windows.Forms.Label labelFriday;
        private System.Windows.Forms.Label labelThursday;
        private System.Windows.Forms.Label labelWednesday;
        private System.Windows.Forms.Label labelTuesday;
        private System.Windows.Forms.Label labelMonday;
        private System.Windows.Forms.GroupBox groupBoxCalendar;
        private System.Windows.Forms.Label labelLunaAn;
        private System.Windows.Forms.GroupBox groupBoxNote;
        private System.Windows.Forms.RichTextBox richTextBoxNewNote;
        private System.Windows.Forms.DateTimePicker dateTimePickerNote;
        private System.Windows.Forms.Button buttonAddNote;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Label labelNumberOfNotes;
        private System.Windows.Forms.Button buttonEditNote;
        private System.Windows.Forms.Panel panelHelp;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Panel help;
        private System.Windows.Forms.Label labelGet;
        private System.Windows.Forms.ListBox listBoxAllNotes;
        private System.Windows.Forms.Label labelAllNotes;
        private System.Windows.Forms.Button buttonInfo;
    }
}

