namespace TravelExpertsWindForm
{
    partial class FRMViewProducts
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
            BTN_EditProd = new Button();
            DGV_Products = new DataGridView();
            BTN_addProd = new Button();
            menuStrip1 = new MenuStrip();
            MI_packages = new ToolStripMenuItem();
            MI_product_sup = new ToolStripMenuItem();
            MI_products = new ToolStripMenuItem();
            MI_suppliers = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)DGV_Products).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BTN_EditProd
            // 
            BTN_EditProd.Location = new Point(589, 377);
            BTN_EditProd.Margin = new Padding(5);
            BTN_EditProd.Name = "BTN_EditProd";
            BTN_EditProd.Size = new Size(262, 57);
            BTN_EditProd.TabIndex = 12;
            BTN_EditProd.Text = "Edit Selected Product";
            BTN_EditProd.UseVisualStyleBackColor = true;
            BTN_EditProd.Click += BTN_EditProd_Click;
            // 
            // DGV_Products
            // 
            DGV_Products.AllowUserToAddRows = false;
            DGV_Products.AllowUserToDeleteRows = false;
            DGV_Products.AllowUserToOrderColumns = true;
            DGV_Products.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Products.Location = new Point(14, 40);
            DGV_Products.Margin = new Padding(5);
            DGV_Products.MultiSelect = false;
            DGV_Products.Name = "DGV_Products";
            DGV_Products.RowTemplate.Height = 25;
            DGV_Products.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Products.Size = new Size(537, 393);
            DGV_Products.TabIndex = 11;
            // 
            // BTN_addProd
            // 
            BTN_addProd.Location = new Point(589, 40);
            BTN_addProd.Margin = new Padding(5);
            BTN_addProd.Name = "BTN_addProd";
            BTN_addProd.Size = new Size(262, 58);
            BTN_addProd.TabIndex = 10;
            BTN_addProd.Text = "Add New Products";
            BTN_addProd.UseVisualStyleBackColor = true;
            BTN_addProd.Click += BTN_addProd_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MI_packages, MI_product_sup, MI_products, MI_suppliers });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(869, 35);
            menuStrip1.TabIndex = 9;
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
            // FRMViewProducts
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 444);
            Controls.Add(BTN_EditProd);
            Controls.Add(DGV_Products);
            Controls.Add(BTN_addProd);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FRMViewProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Products";
            Load += FRMViewProducts_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Products).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_EditProd;
        private DataGridView DGV_Products;
        private Button BTN_addProd;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MI_packages;
        private ToolStripMenuItem MI_product_sup;
        private ToolStripMenuItem MI_products;
        private ToolStripMenuItem MI_suppliers;
    }
}