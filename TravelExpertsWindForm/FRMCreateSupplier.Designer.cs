namespace TravelExpertsWindForm
{
    partial class FRMCreateSupplier
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
            BTN_SubmitSupp = new Button();
            label1 = new Label();
            TB_SuppName = new TextBox();
            SuspendLayout();
            // 
            // BTN_SubmitSupp
            // 
            BTN_SubmitSupp.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            BTN_SubmitSupp.Location = new Point(334, 106);
            BTN_SubmitSupp.Margin = new Padding(5);
            BTN_SubmitSupp.Name = "BTN_SubmitSupp";
            BTN_SubmitSupp.Size = new Size(116, 33);
            BTN_SubmitSupp.TabIndex = 0;
            BTN_SubmitSupp.Text = "button1";
            BTN_SubmitSupp.UseVisualStyleBackColor = true;
            BTN_SubmitSupp.Click += BTN_SubmitSupp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(72, 62);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 1;
            label1.Text = "Supplier Name";
            // 
            // TB_SuppName
            // 
            TB_SuppName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TB_SuppName.Location = new Point(72, 107);
            TB_SuppName.Margin = new Padding(5);
            TB_SuppName.Name = "TB_SuppName";
            TB_SuppName.Size = new Size(238, 33);
            TB_SuppName.TabIndex = 2;
            // 
            // FRMCreateSupplier
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 218);
            Controls.Add(TB_SuppName);
            Controls.Add(label1);
            Controls.Add(BTN_SubmitSupp);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FRMCreateSupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FRMCreateSupplier";
            Load += FRMCreateSupplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_SubmitSupp;
        private Label label1;
        private TextBox TB_SuppName;
    }
}