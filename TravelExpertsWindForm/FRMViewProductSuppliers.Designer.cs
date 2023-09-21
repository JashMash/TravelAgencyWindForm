namespace TravelExpertsWindForm
{
    partial class FRMViewProductSuppliers
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
            menuStrip1 = new MenuStrip();
            MI_packages = new ToolStripMenuItem();
            MI_product_sup = new ToolStripMenuItem();
            MI_products = new ToolStripMenuItem();
            MI_suppliers = new ToolStripMenuItem();
            BTN_EditPS = new Button();
            DGV_ProdSup = new DataGridView();
            BTN_addPS = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_ProdSup).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MI_packages, MI_product_sup, MI_products, MI_suppliers });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(907, 35);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
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
            // BTN_EditPS
            // 
            BTN_EditPS.Location = new Point(585, 435);
            BTN_EditPS.Margin = new Padding(5);
            BTN_EditPS.Name = "BTN_EditPS";
            BTN_EditPS.Size = new Size(308, 70);
            BTN_EditPS.TabIndex = 8;
            BTN_EditPS.Text = "Edit Selected Product Supplier";
            BTN_EditPS.UseVisualStyleBackColor = true;
            BTN_EditPS.Click += BTN_EditPS_Click;
            // 
            // DGV_ProdSup
            // 
            DGV_ProdSup.AllowUserToAddRows = false;
            DGV_ProdSup.AllowUserToDeleteRows = false;
            DGV_ProdSup.AllowUserToOrderColumns = true;
            DGV_ProdSup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_ProdSup.Location = new Point(19, 48);
            DGV_ProdSup.Margin = new Padding(5);
            DGV_ProdSup.MultiSelect = false;
            DGV_ProdSup.Name = "DGV_ProdSup";
            DGV_ProdSup.RowTemplate.Height = 25;
            DGV_ProdSup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_ProdSup.Size = new Size(545, 457);
            DGV_ProdSup.TabIndex = 7;
            // 
            // BTN_addPS
            // 
            BTN_addPS.Location = new Point(585, 48);
            BTN_addPS.Margin = new Padding(5);
            BTN_addPS.Name = "BTN_addPS";
            BTN_addPS.Size = new Size(308, 72);
            BTN_addPS.TabIndex = 6;
            BTN_addPS.Text = "Add New Product Supplier";
            BTN_addPS.UseVisualStyleBackColor = true;
            BTN_addPS.Click += BTN_addPS_Click;
            // 
            // FRMViewProductSuppliers
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 522);
            Controls.Add(BTN_EditPS);
            Controls.Add(DGV_ProdSup);
            Controls.Add(BTN_addPS);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FRMViewProductSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Supplier Linking";
            Load += FRMViewProductSuppliers_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_ProdSup).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem MI_packages;
        private ToolStripMenuItem MI_product_sup;
        private ToolStripMenuItem MI_products;
        private ToolStripMenuItem MI_suppliers;
        private Button BTN_EditPS;
        private DataGridView DGV_ProdSup;
        private Button BTN_addPS;
    }
}