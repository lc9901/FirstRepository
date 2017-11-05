using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHibernate
{
    public partial class listItem : UserControl
    {
        public listItem()
        {
            InitializeComponent();
        }

        public int ItemId 
        {
            get 
            {
                return Convert.ToInt32(this.label5.Text);
            }
            set 
            {
                this.label5.Text = value.ToString();
            }
        }
        public string ItemName 
        {
            get 
            {
                return this.label6.Text;
            }
            set
            {
                this.label6.Text = value;
            }
        }

        public string ItemTel
        {
            get
            {
                return this.label7.Text;
            }
            set
            {
                this.label7.Text = value;
            }
        }

        public string ItemEmail
        {
            get
            {
                return this.label8.Text;
            }
            set
            {
                this.label8.Text = value;
            }
        }

        public string ItemBirth
        {
            get
            {
                return this.label9.Text;
            }
            set
            {
                this.label9.Text = value;
            }
        }
    }
}
