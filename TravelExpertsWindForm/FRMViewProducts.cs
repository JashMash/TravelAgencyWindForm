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
using static TravelExpertsWindForm.FRMCreateProduct;

// Developer: Beth

namespace TravelExpertsWindForm
{
    public partial class FRMViewProducts : Form
    {
        public string next_form = string.Empty;
        public FRMViewProducts()
        {
            InitializeComponent();
        }

        private void FRMViewProducts_Load(object sender, EventArgs e)
        {
            Display_Product_list();

        }

        public void Display_Product_list()
        {
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                //Retrieving All PS_IDs, product names and supplier names
                var all_Prods = (from Prod in context.Products
                                 select new
                                 {
                                     Prod.ProductId,
                                     Prod.ProdName,
                                 }).ToList();
                List<Prod_row> Prod_list = new List<Prod_row>();
                foreach (var prodsSups in all_Prods)
                {
                    Prod_list.Add(
                            new Prod_row()
                            {
                                Product_Id = prodsSups.ProductId,
                                Product_Name = prodsSups.ProdName,
                            });
                }

                DGV_Products.DataSource = Prod_list;
                //Making it look nicer
                DGV_Products.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGV_Products.Columns[1].Width = 250;
                DGV_Products.AutoResizeRows();
            }
        }

        private class Prod_row
        {
            public int Product_Id { get; set; }

            [StringLength(50)]
            public string Product_Name { get; set; } = null!;
        }

        private void BTN_addProd_Click(object sender, EventArgs e)
        {
            //Create another form

            //if the dialog return OK
            // collect the Package form the second form
            // AddProdBtn to Product table
            FRMCreateProduct createFRM = new FRMCreateProduct();
            createFRM.isAdd = true;

            DialogResult ans = createFRM.ShowDialog();
            //Now to update the products Table
            if (ans == DialogResult.OK)
            {
                Prod_info Prod_created = createFRM._Prod_pass;

                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    Product? _Prod_toCreate = new Product();
                    _Prod_toCreate.ProdName = Prod_created.ProdName;

                    context.Products.Add(_Prod_toCreate);

                    //Creating Product entry here
                    context.SaveChanges();
                    Display_Product_list();

                    // Showing User the Add has been made
                    MessageBox.Show($"Created Product: {_Prod_toCreate.ProdName} with ID: {_Prod_toCreate.ProductId}.", "Product Created Successfully!");

                }
            }
        }

        private void BTN_EditProd_Click(object sender, EventArgs e)
        {
            // Checking selection is not overloaded or not done at all
            int count = DGV_Products.SelectedRows.Count;
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

            //Finding selected Product 
            int Prod_ID = (int)DGV_Products.SelectedRows[0].Cells[0].Value;

            //Call form as isAdd is false since we want to update
            FRMCreateProduct editFRM = new FRMCreateProduct();
            editFRM.isAdd = false;


            //Finding and passing Product information to form
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                Product? selected_PS = context.Products.Find(Prod_ID);
                if (selected_PS == null) return;
                editFRM._Prod_pass = new Prod_info()
                {
                    ProductId = selected_PS.ProductId,
                    ProdName = selected_PS.ProdName,
                };
            }

            DialogResult ans = editFRM.ShowDialog();
            ///  After Submit of form ///
            //Now to update the Products table
            if (ans == DialogResult.OK)
            {
                Prod_info Prod_updated = editFRM._Prod_pass;
                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    Product? _Prod_toUpdate = context.Products.Find(Prod_ID);

                    //Updating Product Information
                    if (_Prod_toUpdate != null)
                    {
                        _Prod_toUpdate.ProdName = Prod_updated.ProdName;
                    }

                    //Updating Product entry here
                    context.SaveChanges();
                    context.Products.Update(_Prod_toUpdate);

                    // Updating DGV of Products
                    Display_Product_list();

                    // Showing User the Update has been made
                    MessageBox.Show($"Updated Product: {_Prod_toUpdate.ProdName} with ID: {_Prod_toUpdate.ProductId}.", "Product Updated Successfully!");

                }
            }

        }



        // Navigation
        private void MI_packages_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void MI_products_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already in Products", "Notification");
        }

        private void MI_product_sup_Click(object sender, EventArgs e)
        {
            next_form = "ProductSupplier";
            DialogResult = DialogResult.Continue;
            Close();
        }

        private void MI_suppliers_Click(object sender, EventArgs e)
        {
            next_form = "Supplier";
            DialogResult = DialogResult.Continue;
            Close();
        }
    }
}
