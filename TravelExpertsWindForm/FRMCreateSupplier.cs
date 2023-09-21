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
    public partial class FRMCreateSupplier : Form
    {
        public bool isAdd;
        public Supp_info _Supp_pass;

        public FRMCreateSupplier()
        {
            InitializeComponent();
        }
        private void FRMCreateSupplier_Load(object sender, EventArgs e)
        {
            if (isAdd)
            { // Create new supplier button.
                BTN_SubmitSupp.Text = "Add";
            }
            else
            {// Edit
                //Load data
                load_edit_supp();

                // Changes button name for update/edit.
                BTN_SubmitSupp.Text = "Update";
            }
        }

        private void load_edit_supp()
        {
            if (_Supp_pass != null)
            {
                TB_SuppName.Text = _Supp_pass.SupName;
            }
        }
        private void BTN_SubmitSupp_Click(object sender, EventArgs e)
        {
            if (supp_validator())
            {
                return;
            }

            _Supp_pass = new Supp_info()
            {
                SupName = TB_SuppName.Text,
            };
            DialogResult = DialogResult.OK;
        }

        private bool supp_validator()
        {
            // Check for textbox contents, check for unique supplier name before emptying.
            if (TB_SuppName.Text == string.Empty)
            {
                MessageBox.Show("Supplier name is required.", "ERROR: No supplier name.");
                return true;
            }
            // Checking if product name already exists
            using (TravelExpertsContext context = new TravelExpertsContext())
            {

                string input_supp = TB_SuppName.Text.ToLower();

                var finding_supp = (from Supp in context.Suppliers
                                    where Supp.SupName.ToLower() == input_supp
                                    select new
                                    {
                                        Supp.SupplierId,
                                        Supp.SupName,
                                    }).ToList();
                if (finding_supp.Count != 0)
                {
                    MessageBox.Show("Supplier already in database.", "ERROR: Supplier already exists.");
                    return true;
                }
            }
            return false;
        }


        public class Supp_info
        {
            public int SupplierID { get; set; }

            [StringLength(50)]
            public string SupName { get; set; } = null!;
        }
    }
}
