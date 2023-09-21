namespace TravelExpertsWindForm
{
    partial class FRMCreatePackage
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
            LBFirstName = new Label();
            LBLastname = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TB_PkgName = new TextBox();
            Start_DateTimePicker = new DateTimePicker();
            End_DateTimePicker = new DateTimePicker();
            TB_PkgDesc = new TextBox();
            TB_BasePrice = new TextBox();
            TB_AgencyCom = new TextBox();
            BTN_SubmitPkg = new Button();
            label5 = new Label();
            CB_Prod = new ComboBox();
            DGV_SelectedPS = new DataGridView();
            BT_RemoveProdSup = new Button();
            CB_Sup = new ComboBox();
            BTN_AddPS = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_SelectedPS).BeginInit();
            SuspendLayout();
            // 
            // LBFirstName
            // 
            LBFirstName.AutoSize = true;
            LBFirstName.Location = new Point(12, 18);
            LBFirstName.Name = "LBFirstName";
            LBFirstName.Size = new Size(136, 25);
            LBFirstName.TabIndex = 0;
            LBFirstName.Text = "Package Name";
            // 
            // LBLastname
            // 
            LBLastname.AutoSize = true;
            LBLastname.Location = new Point(12, 65);
            LBLastname.Name = "LBLastname";
            LBLastname.Size = new Size(168, 25);
            LBLastname.TabIndex = 1;
            LBLastname.Text = "Package Start Date";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 114);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 2;
            label1.Text = "Package End Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 164);
            label2.Name = "label2";
            label2.Size = new Size(182, 25);
            label2.TabIndex = 3;
            label2.Text = "Package Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 451);
            label3.Name = "label3";
            label3.Size = new Size(236, 25);
            label3.TabIndex = 4;
            label3.Text = "Package Base Price (CAD$)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 498);
            label4.Name = "label4";
            label4.Size = new Size(238, 25);
            label4.TabIndex = 5;
            label4.Text = "Agency Commision (CAD$)";
            // 
            // TB_PkgName
            // 
            TB_PkgName.Location = new Point(217, 18);
            TB_PkgName.MaxLength = 50;
            TB_PkgName.Name = "TB_PkgName";
            TB_PkgName.Size = new Size(532, 33);
            TB_PkgName.TabIndex = 6;
            // 
            // Start_DateTimePicker
            // 
            Start_DateTimePicker.Location = new Point(217, 59);
            Start_DateTimePicker.Name = "Start_DateTimePicker";
            Start_DateTimePicker.Size = new Size(532, 33);
            Start_DateTimePicker.TabIndex = 7;
            // 
            // End_DateTimePicker
            // 
            End_DateTimePicker.Location = new Point(217, 108);
            End_DateTimePicker.Name = "End_DateTimePicker";
            End_DateTimePicker.Size = new Size(532, 33);
            End_DateTimePicker.TabIndex = 8;
            // 
            // TB_PkgDesc
            // 
            TB_PkgDesc.Location = new Point(217, 161);
            TB_PkgDesc.MaxLength = 50;
            TB_PkgDesc.Multiline = true;
            TB_PkgDesc.Name = "TB_PkgDesc";
            TB_PkgDesc.Size = new Size(532, 91);
            TB_PkgDesc.TabIndex = 9;
            // 
            // TB_BasePrice
            // 
            TB_BasePrice.Location = new Point(267, 448);
            TB_BasePrice.Name = "TB_BasePrice";
            TB_BasePrice.Size = new Size(158, 33);
            TB_BasePrice.TabIndex = 10;
            // 
            // TB_AgencyCom
            // 
            TB_AgencyCom.Location = new Point(267, 495);
            TB_AgencyCom.Name = "TB_AgencyCom";
            TB_AgencyCom.Size = new Size(158, 33);
            TB_AgencyCom.TabIndex = 11;
            // 
            // BTN_SubmitPkg
            // 
            BTN_SubmitPkg.Location = new Point(457, 466);
            BTN_SubmitPkg.Name = "BTN_SubmitPkg";
            BTN_SubmitPkg.Size = new Size(200, 42);
            BTN_SubmitPkg.TabIndex = 12;
            BTN_SubmitPkg.Text = "Create Package";
            BTN_SubmitPkg.UseVisualStyleBackColor = true;
            BTN_SubmitPkg.Click += BTN_SubmitPkg_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 273);
            label5.Name = "label5";
            label5.Size = new Size(161, 25);
            label5.TabIndex = 13;
            label5.Text = "Product Suppliers";
            // 
            // CB_Prod
            // 
            CB_Prod.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Prod.Location = new Point(217, 386);
            CB_Prod.Name = "CB_Prod";
            CB_Prod.Size = new Size(148, 33);
            CB_Prod.TabIndex = 14;
            CB_Prod.SelectedIndexChanged += CB_Prod_SelectedIndexChanged;
            // 
            // DGV_SelectedPS
            // 
            DGV_SelectedPS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_SelectedPS.Location = new Point(217, 273);
            DGV_SelectedPS.Name = "DGV_SelectedPS";
            DGV_SelectedPS.RowTemplate.Height = 25;
            DGV_SelectedPS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_SelectedPS.Size = new Size(396, 107);
            DGV_SelectedPS.TabIndex = 15;
            // 
            // BT_RemoveProdSup
            // 
            BT_RemoveProdSup.Location = new Point(633, 299);
            BT_RemoveProdSup.Name = "BT_RemoveProdSup";
            BT_RemoveProdSup.Size = new Size(116, 58);
            BT_RemoveProdSup.TabIndex = 16;
            BT_RemoveProdSup.Text = "Remove Selected";
            BT_RemoveProdSup.UseVisualStyleBackColor = true;
            BT_RemoveProdSup.Click += BT_RemoveProdSup_Click;
            // 
            // CB_Sup
            // 
            CB_Sup.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Sup.Location = new Point(371, 386);
            CB_Sup.Name = "CB_Sup";
            CB_Sup.Size = new Size(242, 33);
            CB_Sup.TabIndex = 17;
            // 
            // BTN_AddPS
            // 
            BTN_AddPS.Location = new Point(633, 386);
            BTN_AddPS.Name = "BTN_AddPS";
            BTN_AddPS.Size = new Size(116, 33);
            BTN_AddPS.TabIndex = 18;
            BTN_AddPS.Text = "Add";
            BTN_AddPS.UseVisualStyleBackColor = true;
            BTN_AddPS.Click += BTN_AddPS_Click;
            // 
            // FRMCreatePackage
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 547);
            Controls.Add(BTN_AddPS);
            Controls.Add(CB_Sup);
            Controls.Add(BT_RemoveProdSup);
            Controls.Add(DGV_SelectedPS);
            Controls.Add(CB_Prod);
            Controls.Add(label5);
            Controls.Add(BTN_SubmitPkg);
            Controls.Add(TB_AgencyCom);
            Controls.Add(TB_BasePrice);
            Controls.Add(TB_PkgDesc);
            Controls.Add(End_DateTimePicker);
            Controls.Add(Start_DateTimePicker);
            Controls.Add(TB_PkgName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LBLastname);
            Controls.Add(LBFirstName);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FRMCreatePackage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Package";
            Load += FRMCreatePackage_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_SelectedPS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LBFirstName;
        private Label LBLastname;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TB_PkgName;
        private DateTimePicker Start_DateTimePicker;
        private DateTimePicker End_DateTimePicker;
        private TextBox TB_PkgDesc;
        private TextBox TB_BasePrice;
        private TextBox TB_AgencyCom;
        private Button BTN_SubmitPkg;
        private Label label5;
        private ComboBox CB_Prod;
        private DataGridView DGV_SelectedPS;
        private Button BT_RemoveProdSup;
        private ComboBox CB_Sup;
        private Button BTN_AddPS;
    }
}