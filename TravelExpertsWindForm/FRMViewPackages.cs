using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Printing;
using TravelExpertsWindForm.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Windows.Forms;
using TravelExpertsWindForm;
using System.DirectoryServices;
using static TravelExpertsWindForm.FRMCreatePackage;

// Developer: Jashish

namespace TravelExpertsWindForm
{
    public partial class FRMViewPackages : Form
    {
        public FRMViewPackages()
        {
            InitializeComponent();
        }

        // Executes as form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            //Creating data grid view
            //TravelExpertsContext is very useful it contains all classes link
            DisplayPackages();
        }

        private void DisplayPackages()
        {
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                //Retrieving Packages, product name and supplier name
                IList<Package> all_pkg = context.Packages.ToList();
                var pkg_ProdsSups = (from pkg in context.Packages
                                     join PPS in context.PackagesProductsSuppliers on pkg.PackageId equals PPS.PackageId
                                     join PS in context.ProductsSuppliers on PPS.ProductSupplierId equals PS.ProductSupplierId
                                     join Prod in context.Products on PS.ProductId equals Prod.ProductId
                                     join Sup in context.Suppliers on PS.SupplierId equals Sup.SupplierId
                                     select new
                                     {
                                         pkg.PackageId,
                                         Prod.ProdName,
                                         Sup.SupName
                                     }).ToList();
                List<package_row> pkg_list = new List<package_row>();
                foreach (var prodsSups in pkg_ProdsSups)
                {
                    if (pkg_list.Where(e => e.PackageId == prodsSups.PackageId).Any())
                    {
                        package_row addtion = pkg_list.Where(e => e.PackageId == prodsSups.PackageId).ToList()[0];
                        pkg_list.Remove(addtion);
                        addtion.Prods_Sups += $"{prodsSups.ProdName} By {prodsSups.SupName}, ";
                        pkg_list.Add(addtion);
                    }
                    else
                    {
                        Package new_pkg = all_pkg.Where(e => e.PackageId == prodsSups.PackageId).ToList()[0];
                        package_row new_add = new package_row()
                        {
                            PackageId = new_pkg.PackageId,
                            PkgName = new_pkg.PkgName,
                            PkgStartDate = new_pkg.PkgStartDate,
                            PkgEndDate = new_pkg.PkgEndDate,
                            PkgDesc = new_pkg.PkgDesc,
                            PkgBasePrice = new_pkg.PkgBasePrice,
                            PkgAgencyCommission = new_pkg.PkgAgencyCommission,
                        };
                        new_add.Prods_Sups += $"{prodsSups.ProdName} By {prodsSups.SupName}, ";
                        pkg_list.Add(new_add);
                    }
                }

                PackagesDGV.DataSource = pkg_list;
                //Making it look nicer
                PackagesDGV.Columns[7].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                PackagesDGV.Columns[7].Width = 200;
                PackagesDGV.AutoResizeRows();
            }
        }


        //Add customer button
        private void AddPkgBtn_Click(object sender, EventArgs e)
        {
            //Create another form

            //if the dialog return OK
            // collect the Package form the second form
            // AddPkgBtn to Packages table
            FRMCreatePackage createFRM = new FRMCreatePackage();
            createFRM.isAdd = true;

            DialogResult ans = createFRM.ShowDialog();
            //Now to update the packages Table and Packages_Product_Supplier Table
            if (ans == DialogResult.OK)
            {
                Package pkg_created = createFRM._new_Pkg_Info;
                List<PS_list> _PS_list = createFRM.Pkg_ProdSups;

                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    Package? _pkg_toCreate = new Package();
                    PackagesProductsSupplier? _PPS_toCreate = new PackagesProductsSupplier();
                    _pkg_toCreate.PkgName = pkg_created.PkgName;
                    _pkg_toCreate.PkgStartDate = pkg_created.PkgStartDate;
                    _pkg_toCreate.PkgEndDate = pkg_created.PkgEndDate;
                    _pkg_toCreate.PkgDesc = pkg_created.PkgDesc;
                    _pkg_toCreate.PkgBasePrice = pkg_created.PkgBasePrice;
                    _pkg_toCreate.PkgAgencyCommission = pkg_created.PkgAgencyCommission;

                    context.Packages.Add(_pkg_toCreate);
                    context.SaveChanges();

                    //Creating Package Product Supplier entry here
                    Adding_PS(createFRM.isAdd, _pkg_toCreate.PackageId, _PS_list);
                    //context.PackagesProductsSuppliers.Update(_PPS_toCreate);
                    context.SaveChanges();
                    DisplayPackages();

                    // Showing User the ADD has been made
                    MessageBox.Show($"Created Package: {_pkg_toCreate.PkgName} with ID: {_pkg_toCreate.PackageId}.", "Package Created Successful!");
                }
            }

        }

        private void BTN_EditPkg_Click(object sender, EventArgs e)
        {
            // Checking selection is not overloaded or not done at all
            int count = PackagesDGV.SelectedRows.Count;
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

            //Finding selected Package
            int pkgID = (int)PackagesDGV.SelectedRows[0].Cells[0].Value;

            //Call form as isAdd is false since we want to update
            FRMCreatePackage editFRM = new FRMCreatePackage();
            editFRM.isAdd = false;

            //Finding and passing package information to form
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                Package? selected_pkg = context.Packages.Find(pkgID);
                if (selected_pkg == null) return;
                editFRM.curr_pkg = selected_pkg;
            }

            DialogResult ans = editFRM.ShowDialog();
            ///  After Submit of form ///
            //Now to update the packages Table and Packages_Product_Supplier Table
            if (ans == DialogResult.OK)
            {
                var pkg_updated = editFRM._new_Pkg_Info;
                var PS_list = editFRM.Pkg_ProdSups;
                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    Package? _pkg_toUpdate = context.Packages.Find(pkgID);

                    //Updating Package Information
                    if (_pkg_toUpdate != null)
                    {
                        _pkg_toUpdate.PkgName = pkg_updated.PkgName;
                        _pkg_toUpdate.PkgStartDate = pkg_updated.PkgStartDate;
                        _pkg_toUpdate.PkgEndDate = pkg_updated.PkgEndDate;
                        _pkg_toUpdate.PkgDesc = pkg_updated.PkgDesc;
                        _pkg_toUpdate.PkgBasePrice = pkg_updated.PkgBasePrice;
                        _pkg_toUpdate.PkgAgencyCommission = pkg_updated.PkgAgencyCommission;
                    }

                    // Updating all Product Suppliers
                    Adding_PS(editFRM.isAdd, pkgID, PS_list);

                    //Saving context
                    context.Packages.Update(_pkg_toUpdate);
                    context.SaveChanges();

                    // Updating DGV of Packages
                    DisplayPackages();

                    // Showing User the Update has been made
                    MessageBox.Show($"Updated Package: {_pkg_toUpdate.PkgName} with ID: {_pkg_toUpdate.PackageId}.", "Package Update Successful!");
                }
            }
        }


        private void Adding_PS(bool isAdd, int pkgID, List<PS_list> _PS_list)
        {
            // Takes All selected Product Servives and either creates new record 
            //      or updates package depending on the 'isAdd' input Argument
            using (TravelExpertsContext context = new TravelExpertsContext())
            {

                var curr_PS_ID_list = (from pkg in context.Packages
                                       join PPS in context.PackagesProductsSuppliers on pkg.PackageId equals PPS.PackageId
                                       join PS in context.ProductsSuppliers on PPS.ProductSupplierId equals PS.ProductSupplierId
                                       where pkg.PackageId == pkgID
                                       select new
                                       {
                                           PS.ProductSupplierId
                                       })
                              .ToList();
                // Adding new PS's
                foreach (var PS in _PS_list)
                {
                    if (curr_PS_ID_list.Where(c => c.ProductSupplierId == PS.ProductSupplierId).Any())
                    {

                    }
                    else
                    {
                        PackagesProductsSupplier _PPS_add = new PackagesProductsSupplier()
                        {
                            ProductSupplierId = PS.ProductSupplierId,
                            PackageId = pkgID,
                        };
                        context.PackagesProductsSuppliers.Add(_PPS_add);
                    }
                }

                // if Edit aka is isAdd is false
                if (!isAdd)
                {
                    // Removing old PS's that arent there anymore
                    foreach (var PS in curr_PS_ID_list)
                    {
                        if (_PS_list.Where(c => c.ProductSupplierId == PS.ProductSupplierId).Any())
                        {

                        }
                        else
                        {
                            var toDelete = context.PackagesProductsSuppliers.Single(
                                    c => c.ProductSupplierId == PS.ProductSupplierId &&
                                    c.PackageId == pkgID
                                    );
                            if (toDelete == null)
                            {
                                MessageBox.Show("UHM what?");
                            }
                            context.PackagesProductsSuppliers.Remove(toDelete);
                        }
                    }
                }
                context.SaveChanges();
            }

        }

        //View class
        private class package_row
        {
            //Holds all information presented in each row for DGV about the Package
            public int PackageId { get; set; }

            [StringLength(50)]
            public string PkgName { get; set; } = null!;

            public DateTime? PkgStartDate { get; set; }

            public DateTime? PkgEndDate { get; set; }

            [StringLength(50)]
            public string? PkgDesc { get; set; }

            public decimal PkgBasePrice { get; set; }

            public decimal? PkgAgencyCommission { get; set; }

            //Main addition is the ProductSuppliers
            public string Prods_Sups { get; set; } = string.Empty;
        }

        public void form_navigation(DialogResult ans, string location)
        {
            if (ans == DialogResult.Cancel)
            {
                Close();
            }
            else if (ans == DialogResult.OK)
            { // Navigate to packages
                DisplayPackages();
                Show();
            }
            else
            { // all other navigation
                if (location == "ProductSupplier")
                {
                    call_FRMViewProdSups();
                }
                else if (location == "Product")
                {
                    call_FRMViewProducts();
                }
                else if (location == "Supplier")
                {
                    call_FRMViewSuppliers();
                }
            }
        }

        private void MI_packages_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already In Packages", "Notification");
        }

        private void MI_product_sup_Click(object sender, EventArgs e)
        {
            call_FRMViewProdSups();
        }

        private void MI_products_Click(object sender, EventArgs e)
        {
            call_FRMViewProducts();
        }
        private void MI_suppliers_Click(object sender, EventArgs e)
        {
            call_FRMViewSuppliers();
        }
        private void call_FRMViewProducts()
        {
            FRMViewProducts ProdSup_form = new FRMViewProducts();
            Hide();
            DialogResult ans = ProdSup_form.ShowDialog();
            form_navigation(ans, ProdSup_form.next_form);
        }

        private void call_FRMViewProdSups()
        {
            FRMViewProductSuppliers PS_form = new FRMViewProductSuppliers();
            Hide();
            DialogResult ans = PS_form.ShowDialog();
            form_navigation(ans, PS_form.next_form);
        }
        private void call_FRMViewSuppliers()
        {
            FRMViewSuppliers Supp_form = new FRMViewSuppliers();
            Hide();
            DialogResult ans = Supp_form.ShowDialog();
            form_navigation(ans, Supp_form.next_form);
        }


    }



}