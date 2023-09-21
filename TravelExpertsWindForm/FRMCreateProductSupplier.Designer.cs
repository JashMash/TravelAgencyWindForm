namespace TravelExpertsWindForm
{
    partial class FRMCreateProductSupplier
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
            BTN_SubmitPS = new Button();
            CB_Sup = new ComboBox();
            CB_Prod = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // BTN_SubmitPS
            // 
            BTN_SubmitPS.Location = new Point(318, 22);
            BTN_SubmitPS.Margin = new Padding(5);
            BTN_SubmitPS.Name = "BTN_SubmitPS";
            BTN_SubmitPS.Size = new Size(182, 81);
            BTN_SubmitPS.TabIndex = 24;
            BTN_SubmitPS.Text = "Add";
            BTN_SubmitPS.UseVisualStyleBackColor = true;
            BTN_SubmitPS.Click += BTN_SubmitPS_Click;
            // 
            // CB_Sup
            // 
            CB_Sup.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Sup.Location = new Point(14, 126);
            CB_Sup.Margin = new Padding(5);
            CB_Sup.Name = "CB_Sup";
            CB_Sup.Size = new Size(486, 33);
            CB_Sup.TabIndex = 23;
            // 
            // CB_Prod
            // 
            CB_Prod.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Prod.Location = new Point(14, 47);
            CB_Prod.Margin = new Padding(5);
            CB_Prod.Name = "CB_Prod";
            CB_Prod.Size = new Size(232, 33);
            CB_Prod.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 17);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 19;
            label5.Text = "Products";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 96);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 25;
            label1.Text = "Suppliers";
            // 
            // FRMCreateProductSupplier
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 203);
            Controls.Add(label1);
            Controls.Add(BTN_SubmitPS);
            Controls.Add(CB_Sup);
            Controls.Add(CB_Prod);
            Controls.Add(label5);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FRMCreateProductSupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FRMCreateProductSupplier";
            Load += FRMCreateProductSupplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_SubmitPS;
        private ComboBox CB_Sup;
        private ComboBox CB_Prod;
        private Label label5;
        private Label label1;
    }
}