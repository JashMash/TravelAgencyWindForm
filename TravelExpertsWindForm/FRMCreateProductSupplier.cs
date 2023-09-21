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

// Developer: Hoora

namespace TravelExpertsWindForm
{
    public partial class FRMCreateProductSupplier : Form
    {
        public bool isAdd;

        public PS_ids _PS_pass;

        //public PS_ids _PS_output;


        public FRMCreateProductSupplier()
        {
            InitializeComponent();
        }

        private void FRMCreateProductSupplier_Load(object sender, EventArgs e)
        {
            load_comboboxes();
            if (isAdd)
            {// For creating new
                BTN_SubmitPS.Text = "Add Product Supplier";
                CB_Prod.SelectedText = "Please Select a Product";
                CB_Sup.SelectedText = "Please Select a Supplier";
            }
            else
            { // For editting/Updating
                BTN_SubmitPS.Text = "Update Product Supplier";
                //Load selected Product and Supplier
                load_EditPS_Data();
            }
        }

        public void load_EditPS_Data()
        {
            //Loads passed PD_ids data into combo boxes

            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                var Prod_Sup = (from PS in context.ProductsSuppliers
                                where PS.ProductSupplierId == _PS_pass.ProductSupplierId
                                join Prod in context.Products on PS.ProductId equals Prod.ProductId
                                join Sup in context.Suppliers on PS.SupplierId equals Sup.SupplierId
                                select new
                                {
                                    PS.ProductSupplierId,
                                    Prod.ProdName,
                                    Sup.SupName
                                }).ToList();
                CB_Prod.SelectedItem = Prod_Sup[0].ProdName;
                CB_Sup.SelectedItem = Prod_Sup[0].SupName;
            }

        }

        private void load_comboboxes()
        {
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                var Products = (from Prod in context.Products
                                select new
                                {
                                    Prod.ProdName,
                                }).ToList();
                IList<string> prod_names = new List<string>();
                foreach (var prod in Products) { prod_names.Add(prod.ProdName); }
                CB_Prod.DataSource = prod_names;


                var Suppliers = (from Sup in context.Suppliers
                                 select new
                                 {
                                     Sup.SupName
                                 }).ToList();
                IList<string> sup_names = new List<string>();
                foreach (var sup in Suppliers) { sup_names.Add(sup.SupName); }
                CB_Sup.DataSource = sup_names;
            }
        }

        private void BTN_SubmitPS_Click(object sender, EventArgs e)
        {

            // Validate if it already exists
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                var temp = CB_Prod.SelectedItem;
                var check = (from PS in context.ProductsSuppliers
                             join prod in context.Products on PS.ProductId equals prod.ProductId
                             join sup in context.Suppliers on PS.SupplierId equals sup.SupplierId
                             where prod.ProdName == CB_Prod.SelectedItem &&
                                    sup.SupName == CB_Sup.SelectedItem
                             select new
                             {
                                 PS.ProductSupplierId
                             }).ToList();
                if (check.Count != 0)
                {
                    MessageBox.Show("Product and Supplier link already exists.", "ERROR : Link Exists");
                    return;
                }
                else
                {
                    // if not Add to PS list
                    var finding_prod = (from prod in context.Products
                                        where
                                        prod.ProdName == CB_Prod.SelectedItem
                                        select new
                                        {
                                            prod.ProductId
                                        }).ToList();
                    //_PS_output.ProductId = finding_prod[0].ProductId;


                    var finding_sup = (from sup in context.Suppliers
                                       where
                                       sup.SupName == CB_Sup.SelectedItem
                                       select new
                                       {
                                           sup.SupplierId
                                       }).ToList();
                    //_PS_output.SupplierId = finding_sup[0].SupplierId;
                    if (isAdd)
                    {
                        _PS_pass = new PS_ids()
                        {
                            ProductId = finding_prod[0].ProductId,
                            SupplierId = finding_sup[0].SupplierId,
                        };
                    }
                    else
                    {
                        _PS_pass = new PS_ids()
                        {
                            ProductSupplierId = _PS_pass.ProductSupplierId,
                            ProductId = finding_prod[0].ProductId,
                            SupplierId = finding_sup[0].SupplierId,
                        };
                    }
                    DialogResult = DialogResult.OK;
                }
            }



        }

        public class PS_ids
        {
            public int ProductSupplierId { get; set; }


            public int? ProductId { get; set; }


            public int? SupplierId { get; set; }
        }
    }
}
