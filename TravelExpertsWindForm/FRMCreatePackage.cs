using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsWindForm.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;


// Developer: Jashish


namespace TravelExpertsWindForm
{
    public partial class FRMCreatePackage : Form
    {

        public List<PS_list> Pkg_ProdSups = new List<PS_list>();


        public Package? _new_Pkg_Info;

        //Info being passed from FRMViewPackages:
        //Checking if its Create or Edit
        public bool isAdd;
        public Package? curr_pkg;

        public FRMCreatePackage()
        {
            InitializeComponent();
        }

        private void FRMCreatePackage_Load(object sender, EventArgs e)
        {
            //Retrieving Product and Supplier names that are linked from db
            using (TravelExpertsContext context = new TravelExpertsContext())
            {

                //Assigning to Product Combo box
                var prods_list = (from Prod in context.Products
                                  select new
                                  {
                                      Prod.ProdName,
                                  }).ToList();
                IList<string> prod_names = new List<string>();
                foreach (var prod in prods_list) { prod_names.Add(prod.ProdName); }
                CB_Prod.DataSource = prod_names;
                CB_Prod.SelectedIndex = 0;

                //Here the CB_Sup will change by calling the Supplier to get populated
                //CB_Prod_SelectedIndexChanged();
            };


            //Checking if Add or Edit
            if (isAdd)
            {
                Text = "Create Package";
                BTN_SubmitPkg.Text = "Create Package";
            }
            else
            {
                Text = "Edit Package";

                BTN_SubmitPkg.Text = "Update Package";


                DisplayEditPkg();
            }
        }

        private void BTN_SubmitPkg_Click(object sender, EventArgs e)
        {

            if (Validator.IsPresent(TB_PkgName) &&
                    Validator.IsPresent(Start_DateTimePicker) &&
                    Validator.IsPresent(End_DateTimePicker) &&
                    Validator.IsPresent(TB_PkgDesc) &&
                    Validator.IsPresent(TB_BasePrice) &&
                    Validator.IsPresent(TB_AgencyCom))
            {
                //Form Validation
                if (FormValidation_onSubmit())
                {
                    return;
                }

                // Assigning to Class Variable that'll be accessible from FRMViewPackage.cs
                var temp = Start_DateTimePicker.Value.Date.ToString("d");
                _new_Pkg_Info = new Package()
                {
                    PkgName = TB_PkgName.Text,
                    PkgStartDate = Start_DateTimePicker.Value.Date,
                    PkgEndDate = End_DateTimePicker.Value.Date,
                    PkgDesc = TB_PkgDesc.Text,
                    PkgBasePrice = decimal.Parse(TB_BasePrice.Text),
                    PkgAgencyCommission = decimal.Parse(TB_AgencyCom.Text),
                };
                DialogResult = DialogResult.OK;
            }
        }

        public bool FormValidation_onSubmit()
        {
            //Returns True if error found

            // Validating Selected Start and End Dates
            // Currently doesnt care if dates are in the past
            if (Start_DateTimePicker.Value > End_DateTimePicker.Value)
            {
                MessageBox.Show("Please select End date that is ahead of Start date", "Error : End and Start time");
                return true;
            }

            //Validates Price and commission
            if (decimal.Parse(TB_BasePrice.Text) < 0)
            {
                MessageBox.Show("Please enter a Base Price greater than 0.", "Error : Base Price");
                return true;
            }

            if (decimal.Parse(TB_AgencyCom.Text) < 0)
            {
                MessageBox.Show("Please enter a Agency Commission greater than or equal to 0.", "Error : Agency Commission");
                return true;
            }

            if (decimal.Parse(TB_BasePrice.Text) < decimal.Parse(TB_AgencyCom.Text))
            {
                MessageBox.Show("Agency Commission can NOT be greater than Base Price.", "Error : Agency Commission");
                return true;
            }

            //Must have atleast 1 Product supplier selected
            if (Pkg_ProdSups.Count == 0)
            {
                MessageBox.Show("Please select atleast 1 Product Supplier.", "Error : No Product Supplier choosen.");
                return true;
            }
            return false;
        }

        public void DisplayEditPkg()
        {
            //Populates all the fields including the Product Suppliers 

            if (curr_pkg != null)
            {
                //string ProdSup_str = string.Empty;
                // Finding all Product Supplier IDs and mapping it to combo box
                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    var ProdSup = (from pkg in context.Packages
                                   join PPS in context.PackagesProductsSuppliers on pkg.PackageId equals PPS.PackageId
                                   join PS in context.ProductsSuppliers on PPS.ProductSupplierId equals PS.ProductSupplierId
                                   join Prod in context.Products on PS.ProductId equals Prod.ProductId
                                   join Sup in context.Suppliers on PS.SupplierId equals Sup.SupplierId
                                   where pkg.PackageId == curr_pkg.PackageId
                                   select new
                                   {
                                       PS.ProductSupplierId,
                                       Prod.ProdName,
                                       Sup.SupName,
                                   })
                                      .ToList();

                    //Assigning to Class Variable to track in other functions
                    foreach (var i in ProdSup)
                    {
                        Pkg_ProdSups.Add(new PS_list()
                        {
                            ProductSupplierId = i.ProductSupplierId,
                            ProdName = i.ProdName,
                            SupName = i.SupName,
                        });
                    }
                    // Updating DataGridView that hold current Product Services
                    Update_PS_Selected();
                }

                // Assigning Package Data to fields in form.
                TB_PkgName.Text = curr_pkg.PkgName;
                Start_DateTimePicker.Value = curr_pkg.PkgStartDate.Value;
                End_DateTimePicker.Value = curr_pkg.PkgEndDate.Value;
                TB_PkgDesc.Text = curr_pkg.PkgDesc;
                TB_BasePrice.Text = curr_pkg.PkgBasePrice.ToString();
                TB_AgencyCom.Text = curr_pkg.PkgAgencyCommission.ToString();
                //CB_Prod.SelectedItem = ProdSup_str;
            }
        }

        private void CB_Prod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Updates Supplier list based on selected Product
            // This on on change op product selected

            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                var sups_list = (from PS in context.ProductsSuppliers
                                 join Prod in context.Products on PS.ProductId equals Prod.ProductId
                                 join Sup in context.Suppliers on PS.SupplierId equals Sup.SupplierId
                                 where Prod.ProdName == CB_Prod.SelectedItem.ToString()
                                 select new
                                 {
                                     Sup.SupName,
                                 }).ToList();

                IList<string> sup_names = new List<string>();
                foreach (var sup in sups_list) { sup_names.Add(sup.SupName); }
                CB_Sup.DataSource = sup_names;
            }
        }



        private void BTN_AddPS_Click(object sender, EventArgs e)
        {
            //Updates class variable storing Product Services and Datagrid view


            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                //Finding the Product Service selected and its PS_ID
                var sups_list = (from PS in context.ProductsSuppliers
                                 join Prod in context.Products on PS.ProductId equals Prod.ProductId
                                 join Sup in context.Suppliers on PS.SupplierId equals Sup.SupplierId
                                 where Prod.ProdName == CB_Prod.SelectedItem.ToString() &&
                                        Sup.SupName == CB_Sup.SelectedItem.ToString()
                                 select new
                                 {
                                     PS.ProductSupplierId,
                                     Prod.ProdName,
                                     Sup.SupName,
                                 }).ToList();


                // Checking if the PS is already in list
                if (Pkg_ProdSups.Where(c => c.ProductSupplierId == sups_list[0].ProductSupplierId).Any())
                {
                    MessageBox.Show("This has already been added please select a different option", "Error : Add Product and Supplier");
                    return;
                }

                // Updating class variable that holds currently selected PS'
                Pkg_ProdSups.Add(new PS_list()
                {
                    ProductSupplierId = sups_list[0].ProductSupplierId,
                    ProdName = sups_list[0].ProdName,
                    SupName = sups_list[0].SupName
                });

                // Updating DGV
                Update_PS_Selected();
            }
        }



        public class PS_list
        {
            //  Class used to store the Product Services with their Product supplier ID
            //      in same area
            public int ProductSupplierId { get; set; }

            [StringLength(50)]
            public string ProdName { get; set; }

            [StringLength(255)]
            public string SupName { get; set; }
        }

        public void BT_RemoveProdSup_Click(object sender, EventArgs e)
        {
            // Removes selected PS from DGV and class variable

            //  Nothing to remove check
            if (DGV_SelectedPS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nothing to remove", "Error on Remove Product Supplier");
                return;
            }

            //  Finding the selected item in class variable
            for (int index = 0; index < DGV_SelectedPS.SelectedRows.Count; index += 1)
            {
                Pkg_ProdSups.Remove(Pkg_ProdSups.Where(
                    c => c.ProdName == DGV_SelectedPS.SelectedRows[index].Cells[0].Value &&
                    c.SupName == DGV_SelectedPS.SelectedRows[index].Cells[1].Value
                    ).FirstOrDefault());
            }

            // Updating DGV
            Update_PS_Selected();
        }

        public void Update_PS_Selected()
        {
            // Updates DGV that displays Selected Product Services
            DGV_SelectedPS.DataSource = null;
            DGV_SelectedPS.DataSource = Pkg_ProdSups.Select(c => new { c.ProdName, c.SupName }).ToList();
            DGV_SelectedPS.Columns[1].Width = 200;
        }
    }
}
