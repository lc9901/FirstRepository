using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFTestClient.BLL;

namespace WCFTestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeEvent();
        }

        private void InitializeEvent()
        {
            this.buttonAdd.Click += buttonClac_Click;
            this.buttonSub.Click += buttonClac_Click;
            this.buttonTimes.Click += buttonClac_Click;
            this.buttonNegetive.Click += buttonClac_Click;

        }

        void buttonClac_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            
            if(!string.IsNullOrEmpty(this.textBox1.Text) && !string.IsNullOrEmpty(this.textBox2.Text))
            {

                try 
                {
                    CalcLogic c = new CalcLogic();
                    int result = c.getresult(Convert.ToInt32(this.textBox1.Text), Convert.ToInt32(this.textBox2.Text), b.Tag.ToString().ToCharArray()[0]);
                    this.labelResult.Text = result.ToString();
                }
                catch (Exception ) 
                {
                    
                }
            }
            
        }
    }
}
