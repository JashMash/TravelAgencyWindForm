namespace TravelExpertsWindForm
{
    partial class FRMViewSuppliers
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
            DGV_Suppliers = new DataGridView();
            menuStrip1 = new MenuStrip();
            MI_packages = new ToolStripMenuItem();
            MI_product_sup = new ToolStripMenuItem();
            MI_products = new ToolStripMenuItem();
            MI_suppliers = new ToolStripMenuItem();
            BTN_AddSupplier = new Button();
            BTN_EditSupplier = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Suppliers).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGV_Suppliers
            // 
            DGV_Suppliers.AllowUserToAddRows = false;
            DGV_Suppliers.AllowUserToDeleteRows = false;
            DGV_Suppliers.AllowUserToOrderColumns = true;
            DGV_Suppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Suppliers.Location = new Point(14, 40);
            DGV_Suppliers.Margin = new Padding(5);
            DGV_Suppliers.MultiSelect = false;
            DGV_Suppliers.Name = "DGV_Suppliers";
            DGV_Suppliers.RowTemplate.Height = 25;
            DGV_Suppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Suppliers.Size = new Size(545, 457);
            DGV_Suppliers.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MI_packages, MI_product_sup, MI_products, MI_suppliers });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(843, 35);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // MI_packages
            // 
            MI_packages.Name = "MI_packages";
            MI_packages.Size = new Size(101, 29);
            MI_packages.Text = "Packages";
            MI_packages.Click += MI_packages_Click;
            // 
            // MI_product_sup
            // 
            MI_product_sup.Name = "MI_product_sup";
            MI_product_sup.Size = new Size(173, 29);
            MI_product_sup.Text = "Product Suppliers";
            MI_product_sup.Click += MI_product_sup_Click;
            // 
            // MI_products
            // 
            MI_products.Name = "MI_products";
            MI_products.Size = new Size(98, 29);
            MI_products.Text = "Products";
            MI_products.Click += MI_products_Click;
            // 
            // MI_suppliers
            // 
            MI_suppliers.Name = "MI_suppliers";
            MI_suppliers.Size = new Size(102, 29);
            MI_suppliers.Text = "Suppliers";
            MI_suppliers.Click += MI_suppliers_Click;
            // 
            // BTN_AddSupplier
            // 
            BTN_AddSupplier.Location = new Point(579, 113);
            BTN_AddSupplier.Margin = new Padding(5);
            BTN_AddSupplier.Name = "BTN_AddSupplier";
            BTN_AddSupplier.Size = new Size(250, 38);
            BTN_AddSupplier.TabIndex = 6;
            BTN_AddSupplier.Text = "Add New Supplier";
            BTN_AddSupplier.UseVisualStyleBackColor = true;
            BTN_AddSupplier.Click += BTN_AddSupplier_Click;
            // 
            // BTN_EditSupplier
            // 
            BTN_EditSupplier.Location = new Point(579, 444);
            BTN_EditSupplier.Margin = new Padding(5);
            BTN_EditSupplier.Name = "BTN_EditSupplier";
            BTN_EditSupplier.Size = new Size(250, 38);
            BTN_EditSupplier.TabIndex = 7;
            BTN_EditSupplier.Text = "Edit Existing Supplier";
            BTN_EditSupplier.UseVisualStyleBackColor = true;
            BTN_EditSupplier.Click += BTN_EditSupplier_Click;
            // 
            // FRMViewSuppliers
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 511);
            Controls.Add(BTN_EditSupplier);
            Controls.Add(BTN_AddSupplier);
            Controls.Add(menuStrip1);
            Controls.Add(DGV_Suppliers);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FRMViewSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suppliers";
            Load += FRMViewSuppliers_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Suppliers).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_Suppliers;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MI_packages;
        private ToolStripMenuItem MI_product_sup;
        private ToolStripMenuItem MI_products;
        private ToolStripMenuItem MI_suppliers;
        private Button BTN_AddSupplier;
        private Button BTN_EditSupplier;
    }
}