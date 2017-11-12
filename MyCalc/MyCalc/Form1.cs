using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class Form1 : Form
    {
        private StringBuilder contect = new StringBuilder();

        private int flagNeedLeft = 0;
        private bool flagIsNumber = true;

        public Form1()
        {
            InitializeComponent();
            InitEvent();
        }
    }
}
