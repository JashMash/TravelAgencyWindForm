namespace TravelExpertsWindForm
{
    partial class FRMViewPackages
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddPkgBtn = new Button();
            PackagesDGV = new DataGridView();
            BTN_EditPkg = new Button();
            menuStrip1 = new MenuStrip();
            MI_packages = new ToolStripMenuItem();
            MI_product_sup = new ToolStripMenuItem();
            MI_products = new ToolStripMenuItem();
            MI_suppliers = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)PackagesDGV).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // AddPkgBtn
            // 
            AddPkgBtn.Location = new Point(190, 429);
            AddPkgBtn.Margin = new Padding(5);
            AddPkgBtn.Name = "AddPkgBtn";
            AddPkgBtn.Size = new Size(179, 38);
            AddPkgBtn.TabIndex = 1;
            AddPkgBtn.Text = "Add New Package";
            AddPkgBtn.UseVisualStyleBackColor = true;
            AddPkgBtn.Click += AddPkgBtn_Click;
            // 
            // PackagesDGV
            // 
            PackagesDGV.AllowUserToAddRows = false;
            PackagesDGV.AllowUserToDeleteRows = false;
            PackagesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PackagesDGV.Location = new Point(19, 58);
            PackagesDGV.Margin = new Padding(5);
            PackagesDGV.MultiSelect = false;
            PackagesDGV.Name = "PackagesDGV";
            PackagesDGV.RowTemplate.Height = 25;
            PackagesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PackagesDGV.Size = new Size(1043, 361);
            PackagesDGV.TabIndex = 2;
            // 
            // BTN_EditPkg
            // 
            BTN_EditPkg.Location = new Point(770, 429);
            BTN_EditPkg.Margin = new Padding(5);
            BTN_EditPkg.Name = "BTN_EditPkg";
            BTN_EditPkg.Size = new Size(278, 38);
            BTN_EditPkg.TabIndex = 3;
            BTN_EditPkg.Text = "Edit Selected Package";
            BTN_EditPkg.UseVisualStyleBackColor = true;
            BTN_EditPkg.Click += BTN_EditPkg_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MI_packages, MI_product_sup, MI_products, MI_suppliers });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1077, 35);
            menuStrip1.TabIndex = 4;
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
            // FRMViewPackages
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 476);
            Controls.Add(BTN_EditPkg);
            Controls.Add(PackagesDGV);
            Controls.Add(AddPkgBtn);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            Name = "FRMViewPackages";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Packages";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PackagesDGV).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button AddPkgBtn;
        private DataGridView PackagesDGV;
        private Button BTN_EditPkg;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MI_packages;
        private ToolStripMenuItem MI_product_sup;
        private ToolStripMenuItem MI_products;
        private ToolStripMenuItem MI_suppliers;
    }
}