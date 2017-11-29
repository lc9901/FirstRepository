using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Entities;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SearchBrinaryTree tree = new SearchBrinaryTree();
        public Form1()
        {
            InitializeComponent();
            this.buttonInsert.Click += DoBtnInsert_Click;
            this.buttonView.Click += DoBtnView_Click;
        }

        private void DoBtnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxInsert.Text.Trim()))
            {
                return;
            }

            int insertValue;

            if (int.TryParse(this.textBoxInsert.Text, out insertValue))
            {
                tree.InserNode(insertValue);
                this.textBoxInsert.Clear();
                this.buttonView.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void DoBtnView_Click(object sender, EventArgs e)
        {
            Collection<int> result = tree.TravelTree();
            StringBuilder sb = new StringBuilder();
            foreach(int item in result)
            {
                sb.Append(item);
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            this.labelResult.Text = sb.ToString();


        }
    }
}
