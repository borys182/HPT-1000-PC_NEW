namespace HPT1000.GUI
{
    partial class MainForm
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
            System.Windows.Forms.RadioButton radioButton1;
            System.Windows.Forms.RadioButton radioButton2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Subprograms", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Program 1", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node11");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Subprograms", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Program 2", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Programs list", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode15});
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Pump",
            "Working"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Gas",
            "Wait"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Plasma");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Purge");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Vent");
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtBoxMsg = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxAddr = new System.Windows.Forms.TextBox();
            this.txtBoxValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.rBtnClose = new System.Windows.Forms.RadioButton();
            this.rBtnOpen = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnGetState = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label68 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label61 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.prDescription = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label127 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label83 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label82 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hScrollBar3 = new System.Windows.Forms.HScrollBar();
            this.label97 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.label96 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label105 = new System.Windows.Forms.Label();
            this.hScrollBar6 = new System.Windows.Forms.HScrollBar();
            this.label103 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.hScrollBar5 = new System.Windows.Forms.HScrollBar();
            this.label101 = new System.Windows.Forms.Label();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.hScrollBar4 = new System.Windows.Forms.HScrollBar();
            this.label98 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.label130 = new System.Windows.Forms.Label();
            this.hScrollBar14 = new System.Windows.Forms.HScrollBar();
            this.label131 = new System.Windows.Forms.Label();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.label132 = new System.Windows.Forms.Label();
            this.hScrollBar15 = new System.Windows.Forms.HScrollBar();
            this.label133 = new System.Windows.Forms.Label();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.hScrollBar16 = new System.Windows.Forms.HScrollBar();
            this.label135 = new System.Windows.Forms.Label();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.label136 = new System.Windows.Forms.Label();
            this.hScrollBar17 = new System.Windows.Forms.HScrollBar();
            this.label137 = new System.Windows.Forms.Label();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.label138 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label116 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.hScrollBar10 = new System.Windows.Forms.HScrollBar();
            this.label119 = new System.Windows.Forms.Label();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.hScrollBar11 = new System.Windows.Forms.HScrollBar();
            this.label121 = new System.Windows.Forms.Label();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.label122 = new System.Windows.Forms.Label();
            this.hScrollBar12 = new System.Windows.Forms.HScrollBar();
            this.label123 = new System.Windows.Forms.Label();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.label124 = new System.Windows.Forms.Label();
            this.hScrollBar13 = new System.Windows.Forms.HScrollBar();
            this.label125 = new System.Windows.Forms.Label();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.hScrollBar9 = new System.Windows.Forms.HScrollBar();
            this.label112 = new System.Windows.Forms.Label();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.hScrollBar8 = new System.Windows.Forms.HScrollBar();
            this.label110 = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.label107 = new System.Windows.Forms.Label();
            this.hScrollBar7 = new System.Windows.Forms.HScrollBar();
            this.label108 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label92 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label88 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label85 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label146 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.hScrollBar19 = new System.Windows.Forms.HScrollBar();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.hScrollBar18 = new System.Windows.Forms.HScrollBar();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.label144 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label142 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label141 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.label147 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label149 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label152 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnRemoveSubprogram = new System.Windows.Forms.Button();
            this.btnAddNewSubprogram = new System.Windows.Forms.Button();
            this.btnRemoveProgram = new System.Windows.Forms.Button();
            this.cBoxVent = new System.Windows.Forms.CheckBox();
            this.cBoxPurge = new System.Windows.Forms.CheckBox();
            this.cBoxPower = new System.Windows.Forms.CheckBox();
            this.cBoxGas = new System.Windows.Forms.CheckBox();
            this.cBoxPump = new System.Windows.Forms.CheckBox();
            this.label153 = new System.Windows.Forms.Label();
            this.btnAddNewProgram = new System.Windows.Forms.Button();
            this.tBoxNameSubprogram = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.tBoxDescProgram = new System.Windows.Forms.TextBox();
            this.tBoxNameProgram = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.treeViewProgram = new System.Windows.Forms.TreeView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label78 = new System.Windows.Forms.Label();
            this.tBoxDescSubprgoram = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.programsConfigPanel = new HPT_1000.GUI.ProgramsConfig();
            radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton2 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.panel17.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            radioButton1.Location = new System.Drawing.Point(32, 8);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(118, 21);
            radioButton1.TabIndex = 26;
            radioButton1.TabStop = true;
            radioButton1.Text = "AUTOMATIC";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            radioButton2.Location = new System.Drawing.Point(286, 8);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(92, 21);
            radioButton2.TabIndex = 27;
            radioButton2.TabStop = true;
            radioButton2.Text = "MANUAL";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(353, 74);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(82, 52);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxMsg
            // 
            this.txtBoxMsg.Location = new System.Drawing.Point(139, 164);
            this.txtBoxMsg.Name = "txtBoxMsg";
            this.txtBoxMsg.Size = new System.Drawing.Size(278, 22);
            this.txtBoxMsg.TabIndex = 5;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(228, 105);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(82, 26);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(229, 74);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(82, 25);
            this.btnWrite.TabIndex = 7;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Address";
            // 
            // txtBoxAddr
            // 
            this.txtBoxAddr.Location = new System.Drawing.Point(64, 89);
            this.txtBoxAddr.Name = "txtBoxAddr";
            this.txtBoxAddr.Size = new System.Drawing.Size(109, 22);
            this.txtBoxAddr.TabIndex = 9;
            // 
            // txtBoxValue
            // 
            this.txtBoxValue.Location = new System.Drawing.Point(64, 134);
            this.txtBoxValue.Name = "txtBoxValue";
            this.txtBoxValue.Size = new System.Drawing.Size(109, 22);
            this.txtBoxValue.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Message";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(131, 228);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 27);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Set State";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // rBtnClose
            // 
            this.rBtnClose.AutoSize = true;
            this.rBtnClose.Location = new System.Drawing.Point(63, 207);
            this.rBtnClose.Name = "rBtnClose";
            this.rBtnClose.Size = new System.Drawing.Size(64, 21);
            this.rBtnClose.TabIndex = 14;
            this.rBtnClose.TabStop = true;
            this.rBtnClose.Text = "Close";
            this.rBtnClose.UseVisualStyleBackColor = true;
            // 
            // rBtnOpen
            // 
            this.rBtnOpen.AutoSize = true;
            this.rBtnOpen.Location = new System.Drawing.Point(62, 229);
            this.rBtnOpen.Name = "rBtnOpen";
            this.rBtnOpen.Size = new System.Drawing.Size(64, 21);
            this.rBtnOpen.TabIndex = 15;
            this.rBtnOpen.TabStop = true;
            this.rBtnOpen.Text = "Open";
            this.rBtnOpen.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(353, 192);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(76, 25);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnGetState
            // 
            this.btnGetState.Location = new System.Drawing.Point(354, 225);
            this.btnGetState.Name = "btnGetState";
            this.btnGetState.Size = new System.Drawing.Size(75, 26);
            this.btnGetState.TabIndex = 17;
            this.btnGetState.Text = "Get State";
            this.btnGetState.UseVisualStyleBackColor = true;
            this.btnGetState.Click += new System.EventHandler(this.btnGetState_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 38);
            this.button1.TabIndex = 20;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 24);
            this.comboBox1.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(566, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "OPERATING MODE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Program.png");
            this.imageList1.Images.SetKeyName(1, "Subprogram.png");
            this.imageList1.Images.SetKeyName(2, "Pump.jpg");
            this.imageList1.Images.SetKeyName(3, "Gas.png");
            this.imageList1.Images.SetKeyName(4, "Plasma.jpg");
            this.imageList1.Images.SetKeyName(5, "Purge.jpg");
            this.imageList1.Images.SetKeyName(6, "Vent.png");
            this.imageList1.Images.SetKeyName(7, "Valve.png");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 38);
            this.button2.TabIndex = 23;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 771);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1706, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1706, 771);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1698, 742);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main screen";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.comboBox4);
            this.panel9.Controls.Add(this.comboBox3);
            this.panel9.Controls.Add(this.comboBox2);
            this.panel9.Controls.Add(this.panel16);
            this.panel9.Controls.Add(this.panel15);
            this.panel9.Controls.Add(this.panel14);
            this.panel9.Controls.Add(this.panel13);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.pictureBox8);
            this.panel9.Controls.Add(this.pictureBox7);
            this.panel9.Controls.Add(this.pictureBox6);
            this.panel9.Controls.Add(this.pictureBox5);
            this.panel9.Controls.Add(this.pictureBox4);
            this.panel9.Controls.Add(this.pictureBox3);
            this.panel9.Controls.Add(this.label37);
            this.panel9.Controls.Add(this.label36);
            this.panel9.Controls.Add(this.pictureBox2);
            this.panel9.Controls.Add(this.pictureBox1);
            this.panel9.Location = new System.Drawing.Point(610, 75);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1057, 640);
            this.panel9.TabIndex = 24;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(957, 408);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(47, 24);
            this.comboBox4.TabIndex = 68;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(957, 291);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(47, 24);
            this.comboBox3.TabIndex = 67;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(957, 136);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(47, 24);
            this.comboBox2.TabIndex = 66;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.button12);
            this.panel16.Controls.Add(this.button13);
            this.panel16.Controls.Add(this.label68);
            this.panel16.Location = new System.Drawing.Point(623, 18);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(324, 67);
            this.panel16.TabIndex = 65;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(169, 28);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(118, 32);
            this.button12.TabIndex = 47;
            this.button12.Text = "Stop";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(36, 29);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(113, 32);
            this.button13.TabIndex = 46;
            this.button13.Text = "Start";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.Silver;
            this.label68.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label68.Dock = System.Windows.Forms.DockStyle.Top;
            this.label68.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label68.Location = new System.Drawing.Point(0, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(324, 25);
            this.label68.TabIndex = 45;
            this.label68.Text = "ROTATORY DRIVE";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.button11);
            this.panel15.Controls.Add(this.label70);
            this.panel15.Controls.Add(this.label71);
            this.panel15.Controls.Add(this.button10);
            this.panel15.Controls.Add(this.textBox19);
            this.panel15.Controls.Add(this.label72);
            this.panel15.Controls.Add(this.label73);
            this.panel15.Controls.Add(this.textBox20);
            this.panel15.Controls.Add(this.label74);
            this.panel15.Location = new System.Drawing.Point(625, 486);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(326, 122);
            this.panel15.TabIndex = 64;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(262, 73);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(39, 23);
            this.button11.TabIndex = 59;
            this.button11.Text = "Set";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(220, 68);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(28, 17);
            this.label70.TabIndex = 58;
            this.label70.Text = "[%]";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(218, 42);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(38, 17);
            this.label71.TabIndex = 57;
            this.label71.Text = "[sec]";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(262, 36);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(39, 23);
            this.button10.TabIndex = 52;
            this.button10.Text = "Set";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(113, 66);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 22);
            this.textBox19.TabIndex = 51;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label72.Location = new System.Drawing.Point(9, 71);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(71, 17);
            this.label72.TabIndex = 50;
            this.label72.Text = "ON time:";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label73.Location = new System.Drawing.Point(11, 44);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(87, 17);
            this.label73.TabIndex = 49;
            this.label73.Text = "Cycle time:";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(114, 39);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(100, 22);
            this.textBox20.TabIndex = 46;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Silver;
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label74.Dock = System.Windows.Forms.DockStyle.Top;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label74.Location = new System.Drawing.Point(0, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(326, 25);
            this.label74.TabIndex = 44;
            this.label74.Text = "VAPORISER";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label61);
            this.panel14.Controls.Add(this.textBox13);
            this.panel14.Controls.Add(this.label62);
            this.panel14.Controls.Add(this.textBox14);
            this.panel14.Controls.Add(this.label63);
            this.panel14.Controls.Add(this.label64);
            this.panel14.Controls.Add(this.button9);
            this.panel14.Controls.Add(this.textBox15);
            this.panel14.Controls.Add(this.label65);
            this.panel14.Controls.Add(this.label66);
            this.panel14.Controls.Add(this.textBox16);
            this.panel14.Controls.Add(this.label67);
            this.panel14.Location = new System.Drawing.Point(625, 353);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(326, 122);
            this.panel14.TabIndex = 63;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(286, 66);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(28, 17);
            this.label61.TabIndex = 62;
            this.label61.Text = "[%]";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(236, 65);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(48, 22);
            this.textBox13.TabIndex = 61;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(286, 42);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(28, 17);
            this.label62.TabIndex = 60;
            this.label62.Text = "[%]";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(236, 41);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(48, 22);
            this.textBox14.TabIndex = 59;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(191, 68);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(48, 17);
            this.label63.TabIndex = 58;
            this.label63.Text = "[sccm]";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(189, 42);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(48, 17);
            this.label64.TabIndex = 57;
            this.label64.Text = "[sccm]";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(239, 91);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(39, 23);
            this.button9.TabIndex = 52;
            this.button9.Text = "Set";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(84, 66);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(100, 22);
            this.textBox15.TabIndex = 51;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label65.Location = new System.Drawing.Point(9, 71);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(58, 17);
            this.label65.TabIndex = 50;
            this.label65.Text = "Actual:";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label66.Location = new System.Drawing.Point(11, 44);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(37, 17);
            this.label66.TabIndex = 49;
            this.label66.Text = "Set:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(85, 39);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 22);
            this.textBox16.TabIndex = 46;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Silver;
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label67.Dock = System.Windows.Forms.DockStyle.Top;
            this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label67.Location = new System.Drawing.Point(0, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(326, 25);
            this.label67.TabIndex = 44;
            this.label67.Text = "MFC 3";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label54);
            this.panel13.Controls.Add(this.textBox9);
            this.panel13.Controls.Add(this.label55);
            this.panel13.Controls.Add(this.textBox10);
            this.panel13.Controls.Add(this.label56);
            this.panel13.Controls.Add(this.label57);
            this.panel13.Controls.Add(this.button8);
            this.panel13.Controls.Add(this.textBox11);
            this.panel13.Controls.Add(this.label58);
            this.panel13.Controls.Add(this.label59);
            this.panel13.Controls.Add(this.textBox12);
            this.panel13.Controls.Add(this.label60);
            this.panel13.Location = new System.Drawing.Point(625, 223);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(326, 122);
            this.panel13.TabIndex = 41;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(286, 66);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(28, 17);
            this.label54.TabIndex = 62;
            this.label54.Text = "[%]";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(236, 65);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(48, 22);
            this.textBox9.TabIndex = 61;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(286, 42);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(28, 17);
            this.label55.TabIndex = 60;
            this.label55.Text = "[%]";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(236, 41);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(48, 22);
            this.textBox10.TabIndex = 59;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(191, 68);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(48, 17);
            this.label56.TabIndex = 58;
            this.label56.Text = "[sccm]";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(189, 42);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(48, 17);
            this.label57.TabIndex = 57;
            this.label57.Text = "[sccm]";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(239, 91);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(39, 23);
            this.button8.TabIndex = 52;
            this.button8.Text = "Set";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(84, 66);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(100, 22);
            this.textBox11.TabIndex = 51;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label58.Location = new System.Drawing.Point(9, 71);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(58, 17);
            this.label58.TabIndex = 50;
            this.label58.Text = "Actual:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label59.Location = new System.Drawing.Point(11, 44);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(37, 17);
            this.label59.TabIndex = 49;
            this.label59.Text = "Set:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(85, 39);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 22);
            this.textBox12.TabIndex = 46;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Silver;
            this.label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label60.Dock = System.Windows.Forms.DockStyle.Top;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label60.Location = new System.Drawing.Point(0, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(326, 25);
            this.label60.TabIndex = 44;
            this.label60.Text = "MFC 2";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label53);
            this.panel12.Controls.Add(this.textBox8);
            this.panel12.Controls.Add(this.label52);
            this.panel12.Controls.Add(this.textBox7);
            this.panel12.Controls.Add(this.label51);
            this.panel12.Controls.Add(this.label50);
            this.panel12.Controls.Add(this.button7);
            this.panel12.Controls.Add(this.textBox5);
            this.panel12.Controls.Add(this.label47);
            this.panel12.Controls.Add(this.label48);
            this.panel12.Controls.Add(this.textBox6);
            this.panel12.Controls.Add(this.label49);
            this.panel12.Location = new System.Drawing.Point(625, 95);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(326, 122);
            this.panel12.TabIndex = 40;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(286, 66);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(28, 17);
            this.label53.TabIndex = 62;
            this.label53.Text = "[%]";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(236, 65);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(48, 22);
            this.textBox8.TabIndex = 61;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(286, 42);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(28, 17);
            this.label52.TabIndex = 60;
            this.label52.Text = "[%]";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(236, 41);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(48, 22);
            this.textBox7.TabIndex = 59;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(191, 68);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(48, 17);
            this.label51.TabIndex = 58;
            this.label51.Text = "[sccm]";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(189, 42);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(48, 17);
            this.label50.TabIndex = 57;
            this.label50.Text = "[sccm]";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(239, 91);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(39, 23);
            this.button7.TabIndex = 52;
            this.button7.Text = "Set";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(84, 66);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 51;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label47.Location = new System.Drawing.Point(9, 71);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(58, 17);
            this.label47.TabIndex = 50;
            this.label47.Text = "Actual:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label48.Location = new System.Drawing.Point(11, 44);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(37, 17);
            this.label48.TabIndex = 49;
            this.label48.Text = "Set:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(85, 39);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 46;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Silver;
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label49.Dock = System.Windows.Forms.DockStyle.Top;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label49.Location = new System.Drawing.Point(0, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(326, 25);
            this.label49.TabIndex = 44;
            this.label49.Text = "MFC 1";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.button6);
            this.panel11.Controls.Add(this.label46);
            this.panel11.Controls.Add(this.label45);
            this.panel11.Controls.Add(this.textBox3);
            this.panel11.Controls.Add(this.textBox4);
            this.panel11.Controls.Add(this.label44);
            this.panel11.Controls.Add(this.label43);
            this.panel11.Controls.Add(this.checkBox2);
            this.panel11.Controls.Add(this.label42);
            this.panel11.Controls.Add(this.checkBox1);
            this.panel11.Controls.Add(this.label41);
            this.panel11.Location = new System.Drawing.Point(314, 17);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(275, 173);
            this.panel11.TabIndex = 39;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(224, 75);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 23);
            this.button6.TabIndex = 58;
            this.button6.Text = "Set";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(221, 134);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(49, 17);
            this.label46.TabIndex = 57;
            this.label46.Text = "[mBar]";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(224, 106);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(49, 17);
            this.label45.TabIndex = 56;
            this.label45.Text = "[mBar]";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 132);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 55;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(123, 105);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 54;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label44.Location = new System.Drawing.Point(15, 134);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(102, 17);
            this.label44.TabIndex = 53;
            this.label44.Text = "Actual value:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label43.Location = new System.Drawing.Point(15, 106);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(73, 17);
            this.label43.TabIndex = 52;
            this.label43.Text = "Setpoint:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(111, 79);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 21);
            this.checkBox2.TabIndex = 51;
            this.checkBox2.Text = "VAPOR";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label42.Location = new System.Drawing.Point(15, 42);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(160, 17);
            this.label42.TabIndex = 50;
            this.label42.Text = "Control pressure via:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(77, 21);
            this.checkBox1.TabIndex = 46;
            this.checkBox1.Text = "GASES";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Silver;
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label41.Dock = System.Windows.Forms.DockStyle.Top;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label41.Location = new System.Drawing.Point(0, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(275, 25);
            this.label41.TabIndex = 45;
            this.label41.Text = "PRESSURE";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.button5);
            this.panel10.Controls.Add(this.textBox2);
            this.panel10.Controls.Add(this.label40);
            this.panel10.Controls.Add(this.label39);
            this.panel10.Controls.Add(this.radioButton5);
            this.panel10.Controls.Add(this.radioButton4);
            this.panel10.Controls.Add(this.textBox1);
            this.panel10.Controls.Add(this.radioButton3);
            this.panel10.Controls.Add(this.label38);
            this.panel10.Location = new System.Drawing.Point(17, 18);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(288, 135);
            this.panel10.TabIndex = 38;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(237, 68);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 23);
            this.button5.TabIndex = 52;
            this.button5.Text = "Set";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 51;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label40.Location = new System.Drawing.Point(10, 96);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(102, 17);
            this.label40.TabIndex = 50;
            this.label40.Text = "Actual value:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label39.Location = new System.Drawing.Point(12, 69);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(73, 17);
            this.label39.TabIndex = 49;
            this.label39.Text = "Setpoint:";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(171, 40);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(71, 21);
            this.radioButton5.TabIndex = 48;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Curent";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(90, 40);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(77, 21);
            this.radioButton4.TabIndex = 47;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Voltage";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 46;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(14, 40);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(68, 21);
            this.radioButton3.TabIndex = 45;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Power";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Silver;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label38.Dock = System.Windows.Forms.DockStyle.Top;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label38.Location = new System.Drawing.Point(0, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(288, 25);
            this.label38.TabIndex = 44;
            this.label38.Text = "GENERATOR";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label37.Location = new System.Drawing.Point(136, 577);
            this.label37.Name = "label37";
            this.label37.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label37.Size = new System.Drawing.Size(63, 17);
            this.label37.TabIndex = 30;
            this.label37.Text = "Venting";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label36.Location = new System.Drawing.Point(56, 577);
            this.label36.Name = "label36";
            this.label36.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label36.Size = new System.Drawing.Size(64, 17);
            this.label36.TabIndex = 29;
            this.label36.Text = "Purging";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel8);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 673);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel5);
            this.panel8.Controls.Add(this.panel1);
            this.panel8.Controls.Add(this.panel4);
            this.panel8.Controls.Add(this.panel2);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.panel3);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 294);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(566, 375);
            this.panel8.TabIndex = 46;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.label30);
            this.panel5.Controls.Add(this.label29);
            this.panel5.Controls.Add(this.label28);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.label25);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Location = new System.Drawing.Point(5, 229);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(550, 140);
            this.panel5.TabIndex = 35;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(135, 97);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(283, 17);
            this.label31.TabIndex = 9;
            this.label31.Text = "Vaporaitor: Cycle - 1000 [ms] Open - 25 [%]";
            // 
            // label30
            // 
            this.label30.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(412, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(138, 17);
            this.label30.TabIndex = 8;
            this.label30.Text = "MFC 3 Share: 25 [%]";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Cursor = System.Windows.Forms.Cursors.No;
            this.label29.Location = new System.Drawing.Point(273, 68);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(138, 17);
            this.label29.TabIndex = 7;
            this.label29.Text = "MFC 2 Share: 25 [%]";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(135, 68);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(138, 17);
            this.label28.TabIndex = 6;
            this.label28.Text = "MFC 1 Share: 50 [%]";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(374, 39);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 17);
            this.label27.TabIndex = 5;
            this.label27.Text = "Setpoint: 0.01 [mBar]";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(135, 39);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(213, 17);
            this.label23.TabIndex = 4;
            this.label23.Text = "Mode: Control presure via gases";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(232, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 17);
            this.label24.TabIndex = 3;
            this.label24.Text = "00:30:00";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(132, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 17);
            this.label25.TabIndex = 2;
            this.label25.Text = "00:01:35";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label26.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label26.Location = new System.Drawing.Point(16, 13);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(98, 17);
            this.label26.TabIndex = 0;
            this.label26.Text = "Gas supplay";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel1.Location = new System.Drawing.Point(3, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 41);
            this.panel1.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(232, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 3;
            this.label11.Text = "00:30:00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "00:01:35";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Setpoint: 0.5 [mBar]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(16, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pump down";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Location = new System.Drawing.Point(3, 180);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(554, 41);
            this.panel4.TabIndex = 34;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(312, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 17);
            this.label22.TabIndex = 4;
            this.label22.Text = "Setpoint: 3.5 [A]";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(232, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 17);
            this.label19.TabIndex = 3;
            this.label19.Text = "00:30:00";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(132, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 17);
            this.label20.TabIndex = 2;
            this.label20.Text = "00:01:35";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label21.Location = new System.Drawing.Point(16, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 17);
            this.label21.TabIndex = 0;
            this.label21.Text = "Plasma proces";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(3, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 41);
            this.panel2.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(232, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "00:30:00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(132, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "00:01:35";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(16, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Vent";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(343, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "Parameters";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Location = new System.Drawing.Point(3, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 41);
            this.panel3.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(232, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "00:30:00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(132, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 17);
            this.label17.TabIndex = 2;
            this.label17.Text = "00:01:35";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(16, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "Flush";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(140, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Stage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(235, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Target";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Silver;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label35.Dock = System.Windows.Forms.DockStyle.Top;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label35.Location = new System.Drawing.Point(3, 269);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(566, 25);
            this.label35.TabIndex = 45;
            this.label35.Text = "PROCESS STAGE";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.listView1);
            this.panel7.Controls.Add(this.comboBox1);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.label32);
            this.panel7.Controls.Add(this.button3);
            this.panel7.Controls.Add(this.prDescription);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 104);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(566, 165);
            this.panel7.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Program:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(466, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 80);
            this.button4.TabIndex = 37;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label32.Location = new System.Drawing.Point(296, 13);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(95, 17);
            this.label32.TabIndex = 38;
            this.label32.Text = "Description:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(466, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 56);
            this.button3.TabIndex = 36;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // prDescription
            // 
            this.prDescription.Enabled = false;
            this.prDescription.Location = new System.Drawing.Point(303, 36);
            this.prDescription.Multiline = true;
            this.prDescription.Name = "prDescription";
            this.prDescription.ReadOnly = true;
            this.prDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.prDescription.Size = new System.Drawing.Size(157, 117);
            this.prDescription.TabIndex = 30;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Silver;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label34.Dock = System.Windows.Forms.DockStyle.Top;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label34.Location = new System.Drawing.Point(3, 79);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(566, 25);
            this.label34.TabIndex = 43;
            this.label34.Text = "AUTOMATIC";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(radioButton2);
            this.panel6.Controls.Add(radioButton1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 43);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(566, 36);
            this.panel6.TabIndex = 42;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label127);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.panel17);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1698, 742);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Program";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label127
            // 
            this.label127.BackColor = System.Drawing.Color.Silver;
            this.label127.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label127.Dock = System.Windows.Forms.DockStyle.Top;
            this.label127.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label127.Location = new System.Drawing.Point(575, 3);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(1120, 25);
            this.label127.TabIndex = 24;
            this.label127.Text = "STAGE INFORMATION";
            this.label127.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Controls.Add(this.tabPage11);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl2.Location = new System.Drawing.Point(575, 31);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1120, 708);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label83);
            this.tabPage7.Controls.Add(this.dateTimePicker1);
            this.tabPage7.Controls.Add(this.label82);
            this.tabPage7.Controls.Add(this.label81);
            this.tabPage7.Controls.Add(this.textBox22);
            this.tabPage7.Controls.Add(this.label80);
            this.tabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1091, 700);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Pumping down";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(430, 127);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(76, 17);
            this.label83.TabIndex = 6;
            this.label83.Text = "[hh:mm:ss]";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(305, 122);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(430, 76);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(49, 17);
            this.label82.TabIndex = 4;
            this.label82.Text = "[mBar]";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(103, 127);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(162, 17);
            this.label81.TabIndex = 2;
            this.label81.Text = "Max pumping down time:";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(305, 73);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 22);
            this.textBox22.TabIndex = 1;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(103, 78);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(164, 17);
            this.label80.TabIndex = 0;
            this.label80.Text = "Pumping down pressure:";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox4);
            this.tabPage8.Controls.Add(this.groupBox2);
            this.tabPage8.Controls.Add(this.label86);
            this.tabPage8.Controls.Add(this.label84);
            this.tabPage8.Controls.Add(this.dateTimePicker2);
            this.tabPage8.Controls.Add(this.label85);
            this.tabPage8.Location = new System.Drawing.Point(4, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1091, 700);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Gas supplay";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hScrollBar3);
            this.groupBox4.Controls.Add(this.label97);
            this.groupBox4.Controls.Add(this.textBox25);
            this.groupBox4.Controls.Add(this.hScrollBar2);
            this.groupBox4.Controls.Add(this.label96);
            this.groupBox4.Controls.Add(this.textBox24);
            this.groupBox4.Controls.Add(this.label95);
            this.groupBox4.Controls.Add(this.label94);
            this.groupBox4.Controls.Add(this.label93);
            this.groupBox4.Location = new System.Drawing.Point(433, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 121);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.Location = new System.Drawing.Point(149, 100);
            this.hScrollBar3.Maximum = 1000;
            this.hScrollBar3.Minimum = 10;
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(115, 22);
            this.hScrollBar3.TabIndex = 30;
            this.hScrollBar3.Value = 10;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(352, 103);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(41, 17);
            this.label97.TabIndex = 29;
            this.label97.Text = "mBar";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(282, 98);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(64, 22);
            this.textBox25.TabIndex = 28;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(149, 64);
            this.hScrollBar2.Maximum = 1000;
            this.hScrollBar2.Minimum = 10;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(115, 22);
            this.hScrollBar2.TabIndex = 27;
            this.hScrollBar2.Value = 10;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(352, 67);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(41, 17);
            this.label96.TabIndex = 26;
            this.label96.Text = "mBar";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(282, 62);
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(64, 22);
            this.textBox24.TabIndex = 25;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(31, 99);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(98, 17);
            this.label95.TabIndex = 2;
            this.label95.Text = "Max deviation:";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(31, 67);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(64, 17);
            this.label94.TabIndex = 1;
            this.label94.Text = "Setpoint:";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(22, 27);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(73, 17);
            this.label93.TabIndex = 0;
            this.label93.Text = "Vaporiser:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox7);
            this.groupBox6.Controls.Add(this.checkBox6);
            this.groupBox6.Controls.Add(this.label105);
            this.groupBox6.Controls.Add(this.hScrollBar6);
            this.groupBox6.Controls.Add(this.label103);
            this.groupBox6.Controls.Add(this.textBox28);
            this.groupBox6.Controls.Add(this.label104);
            this.groupBox6.Controls.Add(this.hScrollBar5);
            this.groupBox6.Controls.Add(this.label101);
            this.groupBox6.Controls.Add(this.textBox27);
            this.groupBox6.Controls.Add(this.label102);
            this.groupBox6.Controls.Add(this.hScrollBar4);
            this.groupBox6.Controls.Add(this.label98);
            this.groupBox6.Controls.Add(this.textBox26);
            this.groupBox6.Controls.Add(this.label99);
            this.groupBox6.Controls.Add(this.label100);
            this.groupBox6.Location = new System.Drawing.Point(373, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(430, 229);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(33, 193);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(197, 21);
            this.checkBox7.TabIndex = 43;
            this.checkBox7.Text = "Control pressure via vapor";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(31, 166);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(199, 21);
            this.checkBox6.TabIndex = 42;
            this.checkBox6.Text = "Control pressure via gases";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(138, 122);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(13, 17);
            this.label105.TabIndex = 41;
            this.label105.Text = "-";
            // 
            // hScrollBar6
            // 
            this.hScrollBar6.Location = new System.Drawing.Point(160, 117);
            this.hScrollBar6.Maximum = 1000;
            this.hScrollBar6.Minimum = 10;
            this.hScrollBar6.Name = "hScrollBar6";
            this.hScrollBar6.Size = new System.Drawing.Size(115, 22);
            this.hScrollBar6.TabIndex = 40;
            this.hScrollBar6.Value = 10;
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(376, 124);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(41, 17);
            this.label103.TabIndex = 39;
            this.label103.Text = "mBar";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(293, 119);
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(64, 22);
            this.textBox28.TabIndex = 38;
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(138, 92);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(16, 17);
            this.label104.TabIndex = 37;
            this.label104.Text = "+";
            // 
            // hScrollBar5
            // 
            this.hScrollBar5.Location = new System.Drawing.Point(160, 87);
            this.hScrollBar5.Maximum = 1000;
            this.hScrollBar5.Minimum = 10;
            this.hScrollBar5.Name = "hScrollBar5";
            this.hScrollBar5.Size = new System.Drawing.Size(115, 22);
            this.hScrollBar5.TabIndex = 36;
            this.hScrollBar5.Value = 10;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(376, 92);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(41, 17);
            this.label101.TabIndex = 35;
            this.label101.Text = "mBar";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(295, 82);
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(64, 22);
            this.textBox27.TabIndex = 34;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(26, 87);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(98, 17);
            this.label102.TabIndex = 33;
            this.label102.Text = "Max deviation:";
            // 
            // hScrollBar4
            // 
            this.hScrollBar4.Location = new System.Drawing.Point(160, 53);
            this.hScrollBar4.Maximum = 1000;
            this.hScrollBar4.Minimum = 10;
            this.hScrollBar4.Name = "hScrollBar4";
            this.hScrollBar4.Size = new System.Drawing.Size(115, 22);
            this.hScrollBar4.TabIndex = 32;
            this.hScrollBar4.Value = 10;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(376, 60);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(41, 17);
            this.label98.TabIndex = 31;
            this.label98.Text = "mBar";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(296, 55);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(64, 22);
            this.textBox26.TabIndex = 30;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(26, 58);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(64, 17);
            this.label99.TabIndex = 29;
            this.label99.Text = "Setpoint:";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(13, 21);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(123, 17);
            this.label100.TabIndex = 28;
            this.label100.Text = "Process pressure:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label114);
            this.groupBox2.Controls.Add(this.checkBox8);
            this.groupBox2.Controls.Add(this.comboBox7);
            this.groupBox2.Controls.Add(this.label90);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.comboBox6);
            this.groupBox2.Controls.Add(this.label89);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.comboBox5);
            this.groupBox2.Controls.Add(this.label88);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.label87);
            this.groupBox2.Location = new System.Drawing.Point(6, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(838, 618);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label128);
            this.groupBox7.Controls.Add(this.label129);
            this.groupBox7.Controls.Add(this.textBox38);
            this.groupBox7.Controls.Add(this.label130);
            this.groupBox7.Controls.Add(this.hScrollBar14);
            this.groupBox7.Controls.Add(this.label131);
            this.groupBox7.Controls.Add(this.textBox39);
            this.groupBox7.Controls.Add(this.label132);
            this.groupBox7.Controls.Add(this.hScrollBar15);
            this.groupBox7.Controls.Add(this.label133);
            this.groupBox7.Controls.Add(this.textBox40);
            this.groupBox7.Controls.Add(this.label134);
            this.groupBox7.Controls.Add(this.hScrollBar16);
            this.groupBox7.Controls.Add(this.label135);
            this.groupBox7.Controls.Add(this.textBox41);
            this.groupBox7.Controls.Add(this.label136);
            this.groupBox7.Controls.Add(this.hScrollBar17);
            this.groupBox7.Controls.Add(this.label137);
            this.groupBox7.Controls.Add(this.textBox42);
            this.groupBox7.Controls.Add(this.label138);
            this.groupBox7.Location = new System.Drawing.Point(573, 250);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(274, 338);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(236, 250);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(20, 17);
            this.label128.TabIndex = 40;
            this.label128.Text = "%";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(22, 277);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(78, 17);
            this.label129.TabIndex = 39;
            this.label129.Text = "Gas share:";
            // 
            // textBox38
            // 
            this.textBox38.Location = new System.Drawing.Point(25, 297);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(41, 22);
            this.textBox38.TabIndex = 38;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(28, 225);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(98, 17);
            this.label130.TabIndex = 37;
            this.label130.Text = "Max deviation:";
            // 
            // hScrollBar14
            // 
            this.hScrollBar14.Location = new System.Drawing.Point(19, 247);
            this.hScrollBar14.Maximum = 1000;
            this.hScrollBar14.Minimum = 10;
            this.hScrollBar14.Name = "hScrollBar14";
            this.hScrollBar14.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar14.TabIndex = 36;
            this.hScrollBar14.Value = 10;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(80, 302);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(20, 17);
            this.label131.TabIndex = 35;
            this.label131.Text = "%";
            // 
            // textBox39
            // 
            this.textBox39.Location = new System.Drawing.Point(192, 247);
            this.textBox39.Name = "textBox39";
            this.textBox39.ReadOnly = true;
            this.textBox39.Size = new System.Drawing.Size(38, 22);
            this.textBox39.TabIndex = 34;
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(17, 101);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(92, 17);
            this.label132.TabIndex = 33;
            this.label132.Text = "Gas flow min:";
            // 
            // hScrollBar15
            // 
            this.hScrollBar15.Location = new System.Drawing.Point(20, 123);
            this.hScrollBar15.Maximum = 1000;
            this.hScrollBar15.Minimum = 10;
            this.hScrollBar15.Name = "hScrollBar15";
            this.hScrollBar15.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar15.TabIndex = 32;
            this.hScrollBar15.Value = 10;
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(203, 206);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(40, 17);
            this.label133.TabIndex = 31;
            this.label133.Text = "sccm";
            // 
            // textBox40
            // 
            this.textBox40.Location = new System.Drawing.Point(192, 124);
            this.textBox40.Name = "textBox40";
            this.textBox40.ReadOnly = true;
            this.textBox40.Size = new System.Drawing.Size(64, 22);
            this.textBox40.TabIndex = 30;
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(11, 159);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(95, 17);
            this.label134.TabIndex = 29;
            this.label134.Text = "Gas flow max:";
            // 
            // hScrollBar16
            // 
            this.hScrollBar16.Location = new System.Drawing.Point(20, 181);
            this.hScrollBar16.Maximum = 1000;
            this.hScrollBar16.Minimum = 10;
            this.hScrollBar16.Name = "hScrollBar16";
            this.hScrollBar16.Size = new System.Drawing.Size(148, 22);
            this.hScrollBar16.TabIndex = 28;
            this.hScrollBar16.Value = 10;
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(203, 149);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(40, 17);
            this.label135.TabIndex = 27;
            this.label135.Text = "sccm";
            // 
            // textBox41
            // 
            this.textBox41.Location = new System.Drawing.Point(192, 181);
            this.textBox41.Name = "textBox41";
            this.textBox41.ReadOnly = true;
            this.textBox41.Size = new System.Drawing.Size(58, 22);
            this.textBox41.TabIndex = 26;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(17, 43);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(66, 17);
            this.label136.TabIndex = 25;
            this.label136.Text = "Gas flow:";
            // 
            // hScrollBar17
            // 
            this.hScrollBar17.Location = new System.Drawing.Point(20, 65);
            this.hScrollBar17.Maximum = 1000;
            this.hScrollBar17.Minimum = 10;
            this.hScrollBar17.Name = "hScrollBar17";
            this.hScrollBar17.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar17.TabIndex = 24;
            this.hScrollBar17.Value = 10;
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(203, 90);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(40, 17);
            this.label137.TabIndex = 23;
            this.label137.Text = "sccm";
            // 
            // textBox42
            // 
            this.textBox42.Location = new System.Drawing.Point(192, 65);
            this.textBox42.Name = "textBox42";
            this.textBox42.ReadOnly = true;
            this.textBox42.Size = new System.Drawing.Size(64, 22);
            this.textBox42.TabIndex = 22;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(16, 18);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(102, 17);
            this.label138.TabIndex = 12;
            this.label138.Text = "Gas 3: Oxygen";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label116);
            this.groupBox3.Controls.Add(this.label117);
            this.groupBox3.Controls.Add(this.textBox33);
            this.groupBox3.Controls.Add(this.label118);
            this.groupBox3.Controls.Add(this.hScrollBar10);
            this.groupBox3.Controls.Add(this.label119);
            this.groupBox3.Controls.Add(this.textBox34);
            this.groupBox3.Controls.Add(this.label120);
            this.groupBox3.Controls.Add(this.hScrollBar11);
            this.groupBox3.Controls.Add(this.label121);
            this.groupBox3.Controls.Add(this.textBox35);
            this.groupBox3.Controls.Add(this.label122);
            this.groupBox3.Controls.Add(this.hScrollBar12);
            this.groupBox3.Controls.Add(this.label123);
            this.groupBox3.Controls.Add(this.textBox36);
            this.groupBox3.Controls.Add(this.label124);
            this.groupBox3.Controls.Add(this.hScrollBar13);
            this.groupBox3.Controls.Add(this.label125);
            this.groupBox3.Controls.Add(this.textBox37);
            this.groupBox3.Controls.Add(this.label126);
            this.groupBox3.Location = new System.Drawing.Point(295, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 338);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(236, 250);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(20, 17);
            this.label116.TabIndex = 40;
            this.label116.Text = "%";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(22, 277);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(78, 17);
            this.label117.TabIndex = 39;
            this.label117.Text = "Gas share:";
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(25, 297);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(41, 22);
            this.textBox33.TabIndex = 38;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(28, 225);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(98, 17);
            this.label118.TabIndex = 37;
            this.label118.Text = "Max deviation:";
            // 
            // hScrollBar10
            // 
            this.hScrollBar10.Location = new System.Drawing.Point(19, 247);
            this.hScrollBar10.Maximum = 1000;
            this.hScrollBar10.Minimum = 10;
            this.hScrollBar10.Name = "hScrollBar10";
            this.hScrollBar10.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar10.TabIndex = 36;
            this.hScrollBar10.Value = 10;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(80, 302);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(20, 17);
            this.label119.TabIndex = 35;
            this.label119.Text = "%";
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(192, 247);
            this.textBox34.Name = "textBox34";
            this.textBox34.ReadOnly = true;
            this.textBox34.Size = new System.Drawing.Size(38, 22);
            this.textBox34.TabIndex = 34;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(17, 101);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(92, 17);
            this.label120.TabIndex = 33;
            this.label120.Text = "Gas flow min:";
            // 
            // hScrollBar11
            // 
            this.hScrollBar11.Location = new System.Drawing.Point(20, 123);
            this.hScrollBar11.Maximum = 1000;
            this.hScrollBar11.Minimum = 10;
            this.hScrollBar11.Name = "hScrollBar11";
            this.hScrollBar11.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar11.TabIndex = 32;
            this.hScrollBar11.Value = 10;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(203, 206);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(40, 17);
            this.label121.TabIndex = 31;
            this.label121.Text = "sccm";
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(192, 124);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(64, 22);
            this.textBox35.TabIndex = 30;
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(11, 159);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(95, 17);
            this.label122.TabIndex = 29;
            this.label122.Text = "Gas flow max:";
            // 
            // hScrollBar12
            // 
            this.hScrollBar12.Location = new System.Drawing.Point(20, 181);
            this.hScrollBar12.Maximum = 1000;
            this.hScrollBar12.Minimum = 10;
            this.hScrollBar12.Name = "hScrollBar12";
            this.hScrollBar12.Size = new System.Drawing.Size(148, 22);
            this.hScrollBar12.TabIndex = 28;
            this.hScrollBar12.Value = 10;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(203, 149);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(40, 17);
            this.label123.TabIndex = 27;
            this.label123.Text = "sccm";
            // 
            // textBox36
            // 
            this.textBox36.Location = new System.Drawing.Point(192, 181);
            this.textBox36.Name = "textBox36";
            this.textBox36.ReadOnly = true;
            this.textBox36.Size = new System.Drawing.Size(58, 22);
            this.textBox36.TabIndex = 26;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(17, 43);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(66, 17);
            this.label124.TabIndex = 25;
            this.label124.Text = "Gas flow:";
            // 
            // hScrollBar13
            // 
            this.hScrollBar13.Location = new System.Drawing.Point(20, 65);
            this.hScrollBar13.Maximum = 1000;
            this.hScrollBar13.Minimum = 10;
            this.hScrollBar13.Name = "hScrollBar13";
            this.hScrollBar13.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar13.TabIndex = 24;
            this.hScrollBar13.Value = 10;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(203, 90);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(40, 17);
            this.label125.TabIndex = 23;
            this.label125.Text = "sccm";
            // 
            // textBox37
            // 
            this.textBox37.Location = new System.Drawing.Point(192, 65);
            this.textBox37.Name = "textBox37";
            this.textBox37.ReadOnly = true;
            this.textBox37.Size = new System.Drawing.Size(64, 22);
            this.textBox37.TabIndex = 22;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(16, 18);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(102, 17);
            this.label126.TabIndex = 12;
            this.label126.Text = "Gas 2: Oxygen";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(137, 198);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(69, 17);
            this.label114.TabIndex = 22;
            this.label114.Text = "Vaporiser";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(60, 193);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(18, 17);
            this.checkBox8.TabIndex = 21;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(140, 157);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(135, 24);
            this.comboBox7.TabIndex = 20;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(102, 162);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(20, 17);
            this.label90.TabIndex = 19;
            this.label90.Text = "3.";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label115);
            this.groupBox5.Controls.Add(this.label113);
            this.groupBox5.Controls.Add(this.textBox32);
            this.groupBox5.Controls.Add(this.label111);
            this.groupBox5.Controls.Add(this.hScrollBar9);
            this.groupBox5.Controls.Add(this.label112);
            this.groupBox5.Controls.Add(this.textBox31);
            this.groupBox5.Controls.Add(this.label109);
            this.groupBox5.Controls.Add(this.hScrollBar8);
            this.groupBox5.Controls.Add(this.label110);
            this.groupBox5.Controls.Add(this.textBox30);
            this.groupBox5.Controls.Add(this.label107);
            this.groupBox5.Controls.Add(this.hScrollBar7);
            this.groupBox5.Controls.Add(this.label108);
            this.groupBox5.Controls.Add(this.textBox29);
            this.groupBox5.Controls.Add(this.label106);
            this.groupBox5.Controls.Add(this.hScrollBar1);
            this.groupBox5.Controls.Add(this.label92);
            this.groupBox5.Controls.Add(this.textBox23);
            this.groupBox5.Controls.Add(this.label91);
            this.groupBox5.Location = new System.Drawing.Point(15, 250);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(274, 338);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(236, 250);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(20, 17);
            this.label115.TabIndex = 40;
            this.label115.Text = "%";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(22, 277);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(78, 17);
            this.label113.TabIndex = 39;
            this.label113.Text = "Gas share:";
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(25, 297);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(41, 22);
            this.textBox32.TabIndex = 38;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(28, 225);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(98, 17);
            this.label111.TabIndex = 37;
            this.label111.Text = "Max deviation:";
            // 
            // hScrollBar9
            // 
            this.hScrollBar9.Location = new System.Drawing.Point(19, 247);
            this.hScrollBar9.Maximum = 1000;
            this.hScrollBar9.Minimum = 10;
            this.hScrollBar9.Name = "hScrollBar9";
            this.hScrollBar9.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar9.TabIndex = 36;
            this.hScrollBar9.Value = 10;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(80, 302);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(20, 17);
            this.label112.TabIndex = 35;
            this.label112.Text = "%";
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(192, 247);
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(38, 22);
            this.textBox31.TabIndex = 34;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(17, 101);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(92, 17);
            this.label109.TabIndex = 33;
            this.label109.Text = "Gas flow min:";
            // 
            // hScrollBar8
            // 
            this.hScrollBar8.Location = new System.Drawing.Point(20, 123);
            this.hScrollBar8.Maximum = 1000;
            this.hScrollBar8.Minimum = 10;
            this.hScrollBar8.Name = "hScrollBar8";
            this.hScrollBar8.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar8.TabIndex = 32;
            this.hScrollBar8.Value = 10;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(203, 206);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(40, 17);
            this.label110.TabIndex = 31;
            this.label110.Text = "sccm";
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(192, 124);
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(64, 22);
            this.textBox30.TabIndex = 30;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(11, 159);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(95, 17);
            this.label107.TabIndex = 29;
            this.label107.Text = "Gas flow max:";
            // 
            // hScrollBar7
            // 
            this.hScrollBar7.Location = new System.Drawing.Point(20, 181);
            this.hScrollBar7.Maximum = 1000;
            this.hScrollBar7.Minimum = 10;
            this.hScrollBar7.Name = "hScrollBar7";
            this.hScrollBar7.Size = new System.Drawing.Size(148, 22);
            this.hScrollBar7.TabIndex = 28;
            this.hScrollBar7.Value = 10;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(203, 149);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(40, 17);
            this.label108.TabIndex = 27;
            this.label108.Text = "sccm";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(192, 181);
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(58, 22);
            this.textBox29.TabIndex = 26;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(17, 43);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(66, 17);
            this.label106.TabIndex = 25;
            this.label106.Text = "Gas flow:";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(20, 65);
            this.hScrollBar1.Maximum = 1000;
            this.hScrollBar1.Minimum = 10;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar1.TabIndex = 24;
            this.hScrollBar1.Value = 10;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(203, 90);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(40, 17);
            this.label92.TabIndex = 23;
            this.label92.Text = "sccm";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(192, 65);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(64, 22);
            this.textBox23.TabIndex = 22;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(16, 18);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(102, 17);
            this.label91.TabIndex = 12;
            this.label91.Text = "Gas 1: Oxygen";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(60, 161);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(18, 17);
            this.checkBox5.TabIndex = 18;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(140, 127);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(135, 24);
            this.comboBox6.TabIndex = 17;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(102, 132);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(20, 17);
            this.label89.TabIndex = 16;
            this.label89.Text = "2.";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(60, 131);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 17);
            this.checkBox4.TabIndex = 15;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(140, 97);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(135, 24);
            this.comboBox5.TabIndex = 14;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(102, 102);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(20, 17);
            this.label88.TabIndex = 13;
            this.label88.Text = "1.";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(60, 101);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(29, 35);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(108, 17);
            this.label87.TabIndex = 11;
            this.label87.Text = "Process gasess";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(22, 24);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(66, 17);
            this.label86.TabIndex = 10;
            this.label86.Text = "Duration:";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(267, 24);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(76, 17);
            this.label84.TabIndex = 9;
            this.label84.Text = "[hh:mm:ss]";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(130, 24);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(88, 41);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(0, 17);
            this.label85.TabIndex = 7;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label146);
            this.tabPage9.Controls.Add(this.label145);
            this.tabPage9.Controls.Add(this.hScrollBar19);
            this.tabPage9.Controls.Add(this.textBox44);
            this.tabPage9.Controls.Add(this.hScrollBar18);
            this.tabPage9.Controls.Add(this.textBox43);
            this.tabPage9.Controls.Add(this.label144);
            this.tabPage9.Controls.Add(this.label143);
            this.tabPage9.Controls.Add(this.radioButton8);
            this.tabPage9.Controls.Add(this.radioButton7);
            this.tabPage9.Controls.Add(this.radioButton6);
            this.tabPage9.Controls.Add(this.label142);
            this.tabPage9.Controls.Add(this.label139);
            this.tabPage9.Controls.Add(this.label140);
            this.tabPage9.Controls.Add(this.dateTimePicker3);
            this.tabPage9.Controls.Add(this.label141);
            this.tabPage9.Location = new System.Drawing.Point(4, 4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1091, 700);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "Plasma proces";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(613, 404);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(20, 17);
            this.label146.TabIndex = 36;
            this.label146.Text = "%";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(613, 359);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(20, 17);
            this.label145.TabIndex = 35;
            this.label145.Text = "%";
            // 
            // hScrollBar19
            // 
            this.hScrollBar19.Location = new System.Drawing.Point(356, 404);
            this.hScrollBar19.Maximum = 1000;
            this.hScrollBar19.Minimum = 10;
            this.hScrollBar19.Name = "hScrollBar19";
            this.hScrollBar19.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar19.TabIndex = 34;
            this.hScrollBar19.Value = 10;
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(528, 404);
            this.textBox44.Name = "textBox44";
            this.textBox44.ReadOnly = true;
            this.textBox44.Size = new System.Drawing.Size(64, 22);
            this.textBox44.TabIndex = 33;
            // 
            // hScrollBar18
            // 
            this.hScrollBar18.Location = new System.Drawing.Point(356, 359);
            this.hScrollBar18.Maximum = 1000;
            this.hScrollBar18.Minimum = 10;
            this.hScrollBar18.Name = "hScrollBar18";
            this.hScrollBar18.Size = new System.Drawing.Size(155, 22);
            this.hScrollBar18.TabIndex = 32;
            this.hScrollBar18.Value = 10;
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(528, 359);
            this.textBox43.Name = "textBox43";
            this.textBox43.ReadOnly = true;
            this.textBox43.Size = new System.Drawing.Size(64, 22);
            this.textBox43.TabIndex = 31;
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(230, 404);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(98, 17);
            this.label144.TabIndex = 30;
            this.label144.Text = "Max deviation:";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(146, 203);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(43, 17);
            this.label143.TabIndex = 19;
            this.label143.Text = "Mode";
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(163, 265);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(77, 21);
            this.radioButton8.TabIndex = 18;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Voltage";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(172, 301);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(71, 21);
            this.radioButton7.TabIndex = 17;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Curent";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(163, 238);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(68, 21);
            this.radioButton6.TabIndex = 16;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Power";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Location = new System.Drawing.Point(230, 364);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(60, 17);
            this.label142.TabIndex = 15;
            this.label142.Text = "Setpoint";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(175, 80);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(66, 17);
            this.label139.TabIndex = 14;
            this.label139.Text = "Duration:";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(496, 80);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(76, 17);
            this.label140.TabIndex = 13;
            this.label140.Text = "[hh:mm:ss]";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker3.Location = new System.Drawing.Point(371, 75);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker3.TabIndex = 12;
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(169, 80);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(0, 17);
            this.label141.TabIndex = 11;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.label147);
            this.tabPage10.Controls.Add(this.label148);
            this.tabPage10.Controls.Add(this.dateTimePicker4);
            this.tabPage10.Controls.Add(this.label149);
            this.tabPage10.Location = new System.Drawing.Point(4, 4);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1091, 700);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "Flushing";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(153, 97);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(95, 17);
            this.label147.TabIndex = 18;
            this.label147.Text = "Flushing time:";
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Location = new System.Drawing.Point(474, 97);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(76, 17);
            this.label148.TabIndex = 17;
            this.label148.Text = "[hh:mm:ss]";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker4.Location = new System.Drawing.Point(349, 92);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker4.TabIndex = 16;
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Location = new System.Drawing.Point(147, 97);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(0, 17);
            this.label149.TabIndex = 15;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.label150);
            this.tabPage11.Controls.Add(this.label151);
            this.tabPage11.Controls.Add(this.dateTimePicker5);
            this.tabPage11.Controls.Add(this.label152);
            this.tabPage11.Location = new System.Drawing.Point(4, 4);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1091, 700);
            this.tabPage11.TabIndex = 4;
            this.tabPage11.Text = "Venting";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(192, 82);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(90, 17);
            this.label150.TabIndex = 22;
            this.label150.Text = "Venting time:";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Location = new System.Drawing.Point(513, 82);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(76, 17);
            this.label151.TabIndex = 21;
            this.label151.Text = "[hh:mm:ss]";
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker5.Location = new System.Drawing.Point(388, 77);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker5.TabIndex = 20;
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(186, 82);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(0, 17);
            this.label152.TabIndex = 19;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.groupBox10);
            this.panel17.Controls.Add(this.label69);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(3, 3);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(572, 736);
            this.panel17.TabIndex = 0;
            this.panel17.Paint += new System.Windows.Forms.PaintEventHandler(this.panel17_Paint);
            // 
            // btnRemoveSubprogram
            // 
            this.btnRemoveSubprogram.Location = new System.Drawing.Point(6, 678);
            this.btnRemoveSubprogram.Name = "btnRemoveSubprogram";
            this.btnRemoveSubprogram.Size = new System.Drawing.Size(247, 27);
            this.btnRemoveSubprogram.TabIndex = 43;
            this.btnRemoveSubprogram.Text = "Remove Subprogram";
            this.btnRemoveSubprogram.UseVisualStyleBackColor = true;
            // 
            // btnAddNewSubprogram
            // 
            this.btnAddNewSubprogram.Location = new System.Drawing.Point(6, 642);
            this.btnAddNewSubprogram.Name = "btnAddNewSubprogram";
            this.btnAddNewSubprogram.Size = new System.Drawing.Size(247, 27);
            this.btnAddNewSubprogram.TabIndex = 42;
            this.btnAddNewSubprogram.Text = "Add New Subprogram";
            this.btnAddNewSubprogram.UseVisualStyleBackColor = true;
            // 
            // btnRemoveProgram
            // 
            this.btnRemoveProgram.Location = new System.Drawing.Point(127, 600);
            this.btnRemoveProgram.Name = "btnRemoveProgram";
            this.btnRemoveProgram.Size = new System.Drawing.Size(126, 27);
            this.btnRemoveProgram.TabIndex = 41;
            this.btnRemoveProgram.Text = "Remove Program";
            this.btnRemoveProgram.UseVisualStyleBackColor = true;
            // 
            // cBoxVent
            // 
            this.cBoxVent.AutoSize = true;
            this.cBoxVent.Location = new System.Drawing.Point(49, 405);
            this.cBoxVent.Name = "cBoxVent";
            this.cBoxVent.Size = new System.Drawing.Size(78, 21);
            this.cBoxVent.TabIndex = 40;
            this.cBoxVent.Text = "Venting";
            this.cBoxVent.UseVisualStyleBackColor = true;
            // 
            // cBoxPurge
            // 
            this.cBoxPurge.AutoSize = true;
            this.cBoxPurge.Location = new System.Drawing.Point(49, 377);
            this.cBoxPurge.Name = "cBoxPurge";
            this.cBoxPurge.Size = new System.Drawing.Size(68, 21);
            this.cBoxPurge.TabIndex = 39;
            this.cBoxPurge.Text = "Purge";
            this.cBoxPurge.UseVisualStyleBackColor = true;
            // 
            // cBoxPower
            // 
            this.cBoxPower.AutoSize = true;
            this.cBoxPower.Location = new System.Drawing.Point(49, 350);
            this.cBoxPower.Name = "cBoxPower";
            this.cBoxPower.Size = new System.Drawing.Size(122, 21);
            this.cBoxPower.TabIndex = 38;
            this.cBoxPower.Text = "Power supplay";
            this.cBoxPower.UseVisualStyleBackColor = true;
            // 
            // cBoxGas
            // 
            this.cBoxGas.AutoSize = true;
            this.cBoxGas.Location = new System.Drawing.Point(49, 323);
            this.cBoxGas.Name = "cBoxGas";
            this.cBoxGas.Size = new System.Drawing.Size(109, 21);
            this.cBoxGas.TabIndex = 37;
            this.cBoxGas.Text = "Gas supplay";
            this.cBoxGas.UseVisualStyleBackColor = true;
            // 
            // cBoxPump
            // 
            this.cBoxPump.AutoSize = true;
            this.cBoxPump.Location = new System.Drawing.Point(49, 294);
            this.cBoxPump.Name = "cBoxPump";
            this.cBoxPump.Size = new System.Drawing.Size(122, 21);
            this.cBoxPump.TabIndex = 36;
            this.cBoxPump.Text = "Pumping down";
            this.cBoxPump.UseVisualStyleBackColor = true;
            // 
            // label153
            // 
            this.label153.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label153.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label153.Location = new System.Drawing.Point(14, 259);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(284, 17);
            this.label153.TabIndex = 35;
            this.label153.Text = "Sub-program consists stages:";
            // 
            // btnAddNewProgram
            // 
            this.btnAddNewProgram.Location = new System.Drawing.Point(6, 600);
            this.btnAddNewProgram.Name = "btnAddNewProgram";
            this.btnAddNewProgram.Size = new System.Drawing.Size(119, 27);
            this.btnAddNewProgram.TabIndex = 34;
            this.btnAddNewProgram.Text = "New Program";
            this.btnAddNewProgram.UseVisualStyleBackColor = true;
            this.btnAddNewProgram.Click += new System.EventHandler(this.btnAddNewProgram_Click);
            // 
            // tBoxNameSubprogram
            // 
            this.tBoxNameSubprogram.Location = new System.Drawing.Point(28, 67);
            this.tBoxNameSubprogram.Name = "tBoxNameSubprogram";
            this.tBoxNameSubprogram.Size = new System.Drawing.Size(270, 22);
            this.tBoxNameSubprogram.TabIndex = 33;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label79.Location = new System.Drawing.Point(14, 39);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(284, 17);
            this.label79.TabIndex = 32;
            this.label79.Text = "Name:";
            // 
            // tBoxDescProgram
            // 
            this.tBoxDescProgram.Location = new System.Drawing.Point(30, 125);
            this.tBoxDescProgram.Multiline = true;
            this.tBoxDescProgram.Name = "tBoxDescProgram";
            this.tBoxDescProgram.Size = new System.Drawing.Size(270, 94);
            this.tBoxDescProgram.TabIndex = 29;
            // 
            // tBoxNameProgram
            // 
            this.tBoxNameProgram.Location = new System.Drawing.Point(30, 57);
            this.tBoxNameProgram.Name = "tBoxNameProgram";
            this.tBoxNameProgram.Size = new System.Drawing.Size(270, 22);
            this.tBoxNameProgram.TabIndex = 28;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label77.Location = new System.Drawing.Point(16, 93);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(284, 17);
            this.label77.TabIndex = 27;
            this.label77.Text = "Description:";
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label76.Location = new System.Drawing.Point(16, 27);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(284, 17);
            this.label76.TabIndex = 26;
            this.label76.Text = "Name:";
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Silver;
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label69.Dock = System.Windows.Forms.DockStyle.Top;
            this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label69.Location = new System.Drawing.Point(0, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(572, 25);
            this.label69.TabIndex = 23;
            this.label69.Text = "PROGRAM INFORMATION";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.programsConfigPanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1698, 742);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Alerts";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1698, 742);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Archive";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnWrite);
            this.tabPage5.Controls.Add(this.btnConnect);
            this.tabPage5.Controls.Add(this.txtBoxMsg);
            this.tabPage5.Controls.Add(this.btnRead);
            this.tabPage5.Controls.Add(this.btnGetState);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.btnUpdate);
            this.tabPage5.Controls.Add(this.txtBoxAddr);
            this.tabPage5.Controls.Add(this.rBtnOpen);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.rBtnClose);
            this.tabPage5.Controls.Add(this.txtBoxValue);
            this.tabPage5.Controls.Add(this.btnTest);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1698, 742);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Settings";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1698, 742);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Mainteances";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // treeViewProgram
            // 
            this.treeViewProgram.ImageIndex = 7;
            this.treeViewProgram.ImageList = this.imageList1;
            this.treeViewProgram.Location = new System.Drawing.Point(6, 22);
            this.treeViewProgram.Name = "treeViewProgram";
            treeNode9.ImageIndex = 3;
            treeNode9.Name = "Node1";
            treeNode9.Text = "Node1";
            treeNode10.ImageIndex = 4;
            treeNode10.Name = "Node4";
            treeNode10.Text = "Node4";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "Node3";
            treeNode11.Text = "Subprograms";
            treeNode12.Name = "Node0";
            treeNode12.Text = "Program 1";
            treeNode13.Name = "Node11";
            treeNode13.Text = "Node11";
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "Node10";
            treeNode14.Text = "Subprograms";
            treeNode15.Name = "Node9";
            treeNode15.Text = "Program 2";
            treeNode16.Name = "Node2";
            treeNode16.Text = "Programs list";
            this.treeViewProgram.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16});
            this.treeViewProgram.SelectedImageIndex = 7;
            this.treeViewProgram.Size = new System.Drawing.Size(246, 568);
            this.treeViewProgram.TabIndex = 45;
            this.treeViewProgram.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewProgram_AfterSelect);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label76);
            this.groupBox8.Controls.Add(this.label77);
            this.groupBox8.Controls.Add(this.tBoxNameProgram);
            this.groupBox8.Controls.Add(this.tBoxDescProgram);
            this.groupBox8.Location = new System.Drawing.Point(260, 22);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(306, 229);
            this.groupBox8.TabIndex = 46;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Program";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label78);
            this.groupBox9.Controls.Add(this.tBoxDescSubprgoram);
            this.groupBox9.Controls.Add(this.label79);
            this.groupBox9.Controls.Add(this.tBoxNameSubprogram);
            this.groupBox9.Controls.Add(this.label153);
            this.groupBox9.Controls.Add(this.cBoxPump);
            this.groupBox9.Controls.Add(this.cBoxGas);
            this.groupBox9.Controls.Add(this.cBoxPower);
            this.groupBox9.Controls.Add(this.cBoxVent);
            this.groupBox9.Controls.Add(this.cBoxPurge);
            this.groupBox9.Location = new System.Drawing.Point(262, 255);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(304, 447);
            this.groupBox9.TabIndex = 47;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Sub-program";
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label78.Location = new System.Drawing.Point(14, 98);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(284, 17);
            this.label78.TabIndex = 41;
            this.label78.Text = "Description:";
            // 
            // tBoxDescSubprgoram
            // 
            this.tBoxDescSubprgoram.Location = new System.Drawing.Point(28, 128);
            this.tBoxDescSubprgoram.Multiline = true;
            this.tBoxDescSubprgoram.Name = "tBoxDescSubprgoram";
            this.tBoxDescSubprgoram.Size = new System.Drawing.Size(270, 116);
            this.tBoxDescSubprgoram.TabIndex = 42;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.treeViewProgram);
            this.groupBox10.Controls.Add(this.groupBox9);
            this.groupBox10.Controls.Add(this.btnRemoveSubprogram);
            this.groupBox10.Controls.Add(this.groupBox8);
            this.groupBox10.Controls.Add(this.btnAddNewProgram);
            this.groupBox10.Controls.Add(this.btnRemoveProgram);
            this.groupBox10.Controls.Add(this.btnAddNewSubprogram);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(0, 25);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(572, 711);
            this.groupBox10.TabIndex = 48;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Programs";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.listView1.Location = new System.Drawing.Point(5, 40);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(273, 117);
            this.listView1.TabIndex = 42;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sub program name";
            this.columnHeader1.Width = 154;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 88;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::HPT_100.Properties.Resources.Line;
            this.pictureBox8.Location = new System.Drawing.Point(167, 441);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(8, 120);
            this.pictureBox8.TabIndex = 37;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::HPT_100.Properties.Resources.Line;
            this.pictureBox7.Location = new System.Drawing.Point(64, 441);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(9, 120);
            this.pictureBox7.TabIndex = 36;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::HPT_100.Properties.Resources.ForePump;
            this.pictureBox6.Location = new System.Drawing.Point(234, 500);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(84, 70);
            this.pictureBox6.TabIndex = 35;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(447, 398);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 50);
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(261, 395);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 50);
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(158, 393);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 50);
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(167, 197);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(310, 170);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 393);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // programsConfigPanel
            // 
            this.programsConfigPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programsConfigPanel.HPT1000 = null;
            this.programsConfigPanel.Location = new System.Drawing.Point(3, 3);
            this.programsConfigPanel.Name = "programsConfigPanel";
            this.programsConfigPanel.Size = new System.Drawing.Size(1692, 736);
            this.programsConfigPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1706, 793);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "HPT 1000";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtBoxMsg;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxAddr;
        private System.Windows.Forms.TextBox txtBoxValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.RadioButton rBtnClose;
        private System.Windows.Forms.RadioButton rBtnOpen;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGetState;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox prDescription;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TextBox tBoxNameSubprogram;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox tBoxDescProgram;
        private System.Windows.Forms.TextBox tBoxNameProgram;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.HScrollBar hScrollBar3;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.HScrollBar hScrollBar6;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.HScrollBar hScrollBar5;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.HScrollBar hScrollBar4;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.HScrollBar hScrollBar9;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.HScrollBar hScrollBar8;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.HScrollBar hScrollBar7;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.HScrollBar hScrollBar10;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.HScrollBar hScrollBar11;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.HScrollBar hScrollBar12;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.HScrollBar hScrollBar13;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.HScrollBar hScrollBar14;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.HScrollBar hScrollBar15;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.HScrollBar hScrollBar16;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.HScrollBar hScrollBar17;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.HScrollBar hScrollBar19;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.HScrollBar hScrollBar18;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label149;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.Label label151;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.Button btnRemoveSubprogram;
        private System.Windows.Forms.Button btnAddNewSubprogram;
        private System.Windows.Forms.Button btnRemoveProgram;
        private System.Windows.Forms.CheckBox cBoxVent;
        private System.Windows.Forms.CheckBox cBoxPurge;
        private System.Windows.Forms.CheckBox cBoxPower;
        private System.Windows.Forms.CheckBox cBoxGas;
        private System.Windows.Forms.CheckBox cBoxPump;
        private System.Windows.Forms.Label label153;
        private System.Windows.Forms.Button btnAddNewProgram;
        private System.Windows.Forms.TreeView treeViewProgram;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox tBoxDescSubprgoram;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private HPT_1000.GUI.ProgramsConfig programsConfigPanel;
    }
}

