using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataMiningTeam.BLL;
using DataMiningTeam.Dto;

namespace DataMiningTeam.WindowsForms
{
    public partial class DMForm : Form
    {
        //Properties/Variables ************************************************
        List<ItemSetDto> results = new List<ItemSetDto>();

        //Constructors ********************************************************
        public DMForm()
        {
            InitializeComponent();
            cmbSource.Items.Add("AdventureWorks");
        }//DMForm

        //Methods *************************************************************
        //Events **************************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbSource.SelectedItem == null)
            {
                MessageBox.Show("Please select a data source");
                return;
            }//if

            if (txtMinSupport.Text.Equals(""))
            {
                MessageBox.Show("Please enter a Minimum Support");
                return;
            }//if

            if (txtMinConfidence.Text.Equals(""))
            {
                MessageBox.Show("Please enter a Minimum Confidence");
                return;
            }//if

            double minSupport = Convert.ToDouble(txtMinSupport.Text);
            double minConfidence = Convert.ToDouble(txtMinConfidence.Text);
            string datasource = cmbSource.SelectedItem.ToString();

            DataSourceBLL dsBLL = new DataSourceBLL();
            Apriori ap = new Apriori();

            List<TransactionDto> transactions = dsBLL.process(datasource);

            results = ap.Process(transactions, null, minSupport, minConfidence);
        }//button1_Click
    }//class
}//namespace
