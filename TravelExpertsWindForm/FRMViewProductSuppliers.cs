using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsWindForm.Models;
using static TravelExpertsWindForm.FRMCreateProductSupplier;

// Developer: Hoora

namespace TravelExpertsWindForm
{
    public partial class FRMViewProductSuppliers : Form
    {
        //Linking and editting links Form for the Product and Supplier

        public string next_form = string.Empty;
        public FRMViewProductSuppliers()
        {
            InitializeComponent();
        }

        private void FRMViewProductSuppliers_Load(object sender, EventArgs e)
        {
            Display_PS_list();
        }

        public void Display_PS_list()
        {
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                //Retrieving All PS_IDs, product names and supplier names
                var all_ProdsSups = (from PS in context.ProductsSuppliers
                                     join Prod in context.Products on PS.ProductId equals Prod.ProductId
                                     join Sup in context.Suppliers on PS.SupplierId equals Sup.SupplierId
                                     select new
                                     {
                                         PS.ProductSupplierId,
                                         Prod.ProdName,
                                         Sup.SupName
                                     }).ToList();
                List<PS_row> PS_list = new List<PS_row>();
                foreach (var prodsSups in all_ProdsSups)
                {
                    PS_list.Add(
                            new PS_row()
                            {
                                ProductSupplierId = prodsSups.ProductSupplierId,
                                Product = prodsSups.ProdName,
                                Supplier = prodsSups.SupName,
                            });
                }

                DGV_ProdSup.DataSource = PS_list;
                //Making it look nicer
                DGV_ProdSup.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGV_ProdSup.Columns[2].Width = 250;
                DGV_ProdSup.AutoResizeRows();
            }
        }

        private class PS_row
        {
            public int ProductSupplierId { get; set; }

            [StringLength(50)]
            public string Product { get; set; } = null!;

            [StringLength(255)]
            public string? Supplier { get; set; }
        }




        //NAVIGATION
        private void MI_product_sup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already in Product Supplier", "Notification");
        }

        private void MI_packages_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void MI_products_Click(object sender, EventArgs e)
        {
            next_form = "Product";

            DialogResult = DialogResult.Continue;
            Close();
        }

        private void MI_suppliers_Click(object sender, EventArgs e)
        {
            next_form = "Supplier";
            DialogResult = DialogResult.Continue;
            Close();
        }


        // BUTTONS TO ADD AND EDIT
        private void BTN_addPS_Click(object sender, EventArgs e)
        {
            //Create another form

            //if the dialog return OK
            // collect the Product and supplier link for the second form

            FRMCreateProductSupplier createFRM = new FRMCreateProductSupplier();
            createFRM.isAdd = true;

            DialogResult ans = createFRM.ShowDialog();
            //Now to update the ProductSupplier Table
            if (ans == DialogResult.OK)
            {
                PS_ids PS_created = createFRM._PS_pass;

                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    ProductsSupplier? _PS_toCreate = new ProductsSupplier();
                    _PS_toCreate.SupplierId = PS_created.SupplierId;
                    _PS_toCreate.ProductId = PS_created.ProductId;

                    context.ProductsSuppliers.Add(_PS_toCreate);
                    context.SaveChanges();

                    //Creating Product Supplier entry here
                    context.SaveChanges();
                    Display_PS_list();

                    // Showing User the Add has been made
                    var prod = context.Products.Find(_PS_toCreate.ProductId);
                    var sup = context.Suppliers.Find(_PS_toCreate.SupplierId);
                    MessageBox.Show($"Created Product Supplier Link between: {prod.ProdName} and {sup.SupName}. With Product Supplier ID: {_PS_toCreate.ProductSupplierId}.", "Product Supplier link created Successfully!");

                }
            }
        }

        private void BTN_EditPS_Click(object sender, EventArgs e)
        {
            // Checking selection is not overloaded or not done at all
            int count = DGV_ProdSup.SelectedRows.Count;
            if (count == 0)
            {
                MessageBox.Show("You need to select a row from list.", "Edit Error");
                return;
            }
            else if (count > 1)
            {
                MessageBox.Show("You can ONLY select ONE row from list.", "Edit Error");
                return;
            }

            //Finding selected Product Supplier
            int PS_ID = (int)DGV_ProdSup.SelectedRows[0].Cells[0].Value;

            //Call form as isAdd is false since we want to update
            FRMCreateProductSupplier editFRM = new FRMCreateProductSupplier();
            editFRM.isAdd = false;


            //Finding and passing package information to form
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                ProductsSupplier? selected_PS = context.ProductsSuppliers.Find(PS_ID);
                if (selected_PS == null) return;
                editFRM._PS_pass = new PS_ids()
                {
                    ProductSupplierId = selected_PS.ProductSupplierId,
                    ProductId = selected_PS.ProductId,
                    SupplierId = selected_PS.SupplierId,
                };
            }

            DialogResult ans = editFRM.ShowDialog();
            ///  After Submit of form ///
            //Now to update the packages Table and Packages_Product_Supplier Table
            if (ans == DialogResult.OK)
            {
                PS_ids PS_updated = editFRM._PS_pass;
                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    ProductsSupplier? _PS_toUpdate = context.ProductsSuppliers.Find(PS_ID);

                    //Updating Package Information
                    if (_PS_toUpdate != null)
                    {
                        _PS_toUpdate.SupplierId = PS_updated.SupplierId;
                        _PS_toUpdate.ProductId = PS_updated.ProductId;
                    }

                    //Saving context
                    context.ProductsSuppliers.Update(_PS_toUpdate);
                    context.SaveChanges();

                    // Updating DGV of Packages
                    Display_PS_list();

                    // Showing User the Add has been made
                    var prod = context.Products.Find(_PS_toUpdate.ProductId);
                    var sup = context.Suppliers.Find(_PS_toUpdate.SupplierId);
                    MessageBox.Show($"Updated Product Supplier Link between: {prod.ProdName} and {sup.SupName}. With Product Supplier ID: {_PS_toUpdate.ProductSupplierId}.", "Product Supplier link updated Successfully!");
                }
            }
        }


    }
}
