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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static TravelExpertsWindForm.FRMCreateProduct;
using static TravelExpertsWindForm.FRMCreateSupplier;

// Developer: Beth

namespace TravelExpertsWindForm
{
    public partial class FRMViewSuppliers : Form
    {
        public string next_form = string.Empty;
        public FRMViewSuppliers()
        {
            InitializeComponent();
        }

        private void FRMViewSuppliers_Load(object sender, EventArgs e)
        {
            Display_Supplier_list();
        }

        public void Display_Supplier_list() // Populates data grid view from database.
        {
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                var all_Suppliers = (from Supp in context.Suppliers
                                     select new
                                     {
                                         Supp.SupplierId,
                                         Supp.SupName
                                     }).ToList();
                List<Supplier_row> Supplier_list = new List<Supplier_row>();
                foreach (var supp in all_Suppliers)
                {
                    Supplier_list.Add(
                            new Supplier_row()
                            {
                                Supplier_ID = supp.SupplierId,
                                Supplier_Name = supp.SupName,
                            });
                }
                DGV_Suppliers.DataSource = Supplier_list;
            }

            //Formatting consistency across form views.
            DGV_Suppliers.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGV_Suppliers.Columns[1].Width = 250;
            DGV_Suppliers.AutoResizeRows();
        }
        private class Supplier_row
        {
            public int Supplier_ID { get; set; }

            [StringLength(50)]
            public string Supplier_Name { get; set; } = null!;
        }

        private void BTN_AddSupplier_Click(object sender, EventArgs e)
        {
            //Create another form

            // if the dialog return OK
            // Add supplier from the submission form.

            FRMCreateSupplier createFRM = new FRMCreateSupplier();
            createFRM.isAdd = true;

            DialogResult ans = createFRM.ShowDialog();
            // Update table in DB with supplier info.
            if (ans == DialogResult.OK)
            {
                Supp_info Supp_created = createFRM._Supp_pass;

                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    Supplier? _Supp_toCreate = new Supplier();
                    _Supp_toCreate.SupName = Supp_created.SupName;

                    context.Suppliers.Add(_Supp_toCreate);

                    //Creating Product entry here
                    context.SaveChanges();
                    Display_Supplier_list();

                    // Showing User the Update has been made
                    MessageBox.Show($"Created Supplier: {_Supp_toCreate.SupName} with ID: {_Supp_toCreate.SupplierId}.", "Supplier Created Successful!");

                }
            }
        }

        private void BTN_EditSupplier_Click(object sender, EventArgs e)
        {
            // Checking selection has only one row selected, or if no rows are selected
            int count = DGV_Suppliers.SelectedRows.Count;
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
            int Supp_ID = (int)DGV_Suppliers.SelectedRows[0].Cells[0].Value;

            //Call form with boolean isAdd = false since we want to use update/edit functionality
            FRMCreateSupplier editFRM = new FRMCreateSupplier();
            editFRM.isAdd = false;


            //Finding what was selected to populate the edit form
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                Supplier? selected_Supplier = context.Suppliers.Find(Supp_ID);
                if (selected_Supplier == null) return;
                editFRM._Supp_pass = new Supp_info()
                {
                    SupplierID = selected_Supplier.SupplierId,
                    SupName = selected_Supplier.SupName,
                };
            }

            DialogResult ans = editFRM.ShowDialog();
            ///  After form submission ///
            // Update Suppliers table in DB.
            if (ans == DialogResult.OK)
            {
                Supp_info Supp_updated = editFRM._Supp_pass;
                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    Supplier? _Supp_toUpdate = context.Suppliers.Find(Supp_ID);

                    //Updating Package Information
                    if (_Supp_toUpdate != null)
                    {
                        _Supp_toUpdate.SupName = Supp_updated.SupName;
                    }

                    // Updating Supplier entry here
                    context.SaveChanges();
                    context.Suppliers.Update(_Supp_toUpdate);

                    // Updating DGV of suppliers with new supplier
                    Display_Supplier_list();

                    // Showing User the Update has been made
                    MessageBox.Show($"Updated Supplier: {_Supp_toUpdate.SupName} with ID: {_Supp_toUpdate.SupplierId}.", "Supplier Update Successful!");

                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MI_packages_Click(object sender, EventArgs e)
        {
            next_form = "Packages";
            DialogResult = DialogResult.OK;
        }

        private void MI_product_sup_Click(object sender, EventArgs e)
        {
            next_form = "ProductSupplier";
            DialogResult = DialogResult.Continue;
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
            MessageBox.Show("Already in Suppliers view.", "Notification");
        }
    }
}
