namespace TravelExpertsWindForm
{
    partial class FRMCreateProduct
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
            TB_ProdName = new TextBox();
            label1 = new Label();
            BTN_SubmitProd = new Button();
            SuspendLayout();
            // 
            // TB_ProdName
            // 
            TB_ProdName.Location = new Point(14, 41);
            TB_ProdName.Margin = new Padding(5);
            TB_ProdName.Name = "TB_ProdName";
            TB_ProdName.Size = new Size(239, 33);
            TB_ProdName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 1;
            label1.Text = "Product Name";
            // 
            // BTN_SubmitProd
            // 
            BTN_SubmitProd.Location = new Point(274, 41);
            BTN_SubmitProd.Name = "BTN_SubmitProd";
            BTN_SubmitProd.Size = new Size(111, 33);
            BTN_SubmitProd.TabIndex = 2;
            BTN_SubmitProd.Text = "button1";
            BTN_SubmitProd.UseVisualStyleBackColor = true;
            BTN_SubmitProd.Click += BTN_SubmitProd_Click;
            // 
            // FRMCreateProduct
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 107);
            Controls.Add(BTN_SubmitProd);
            Controls.Add(label1);
            Controls.Add(TB_ProdName);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FRMCreateProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FRMCreateProduct";
            Load += FRMCreateProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_ProdName;
        private Label label1;
        private Button BTN_SubmitProd;
    }
}