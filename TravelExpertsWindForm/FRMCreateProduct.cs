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

// Developer: Beth

namespace TravelExpertsWindForm
{
    public partial class FRMCreateProduct : Form
    {
        public bool isAdd;

        public Prod_info _Prod_pass;

        public FRMCreateProduct()
        {
            InitializeComponent();
        }

        private void FRMCreateProduct_Load(object sender, EventArgs e)
        {
            if (isAdd)
            { // Create New Product
                BTN_SubmitProd.Text = "Add";
            }
            else
            {// Edit
                //Load data
                load_edit_prod();

                // changing button name
                BTN_SubmitProd.Text = "Update";
            }
        }

        private void load_edit_prod()
        {
            if (_Prod_pass != null)
            {
                TB_ProdName.Text = _Prod_pass.ProdName;
            }
        }

        private void BTN_SubmitProd_Click(object sender, EventArgs e)
        {
            if (prod_validator())
            {
                return;
            }

            _Prod_pass = new Prod_info()
            {
                ProdName = TB_ProdName.Text,
            };
            DialogResult = DialogResult.OK;

        }

        private bool prod_validator()
        {
            //IF Returns true error occured

            //Empty check
            if (TB_ProdName.Text == string.Empty)
            {
                MessageBox.Show("Product Name cannot be empty.", "ERROR: No Product name");
                return true;
            }
            // Checking if product name already exists
            using (TravelExpertsContext context = new TravelExpertsContext())
            {

                string input_prod = TB_ProdName.Text.ToLower();

                var finding_Prod = (from Prod in context.Products
                                    where Prod.ProdName.ToLower() == input_prod
                                    select new
                                    {
                                        Prod.ProductId,
                                        Prod.ProdName,
                                    }).ToList();
                if (finding_Prod.Count != 0)
                {
                    MessageBox.Show("Product Name already exists.", "ERROR: Product Name exists");
                    return true;
                }
            }
            return false;
        }

        public class Prod_info
        {
            public int ProductId { get; set; }

            [StringLength(50)]
            public string ProdName { get; set; }
        }
    }
}
