using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestHibernate.Business;
using TestHibernate.DataEntity;

namespace TestHibernate
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializeEvent();
        }

        /// <summary>
        /// Initializes the event for current form.
        /// </summary>
        private void InitializeEvent()
        {
            this.btnExit.Click += DoBtnExit_Click;
            this.btnView.Click += DoBtnView_Click;
            this.btnOK.Click += DoBtnOK_Click;
        }

        private void DoBtnOK_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (
                string.IsNullOrEmpty(this.txtName.Text) ||
                string.IsNullOrEmpty(this.txtEmail.Text) ||
                string.IsNullOrEmpty(this.txtBirthDay.Text) ||
                string.IsNullOrEmpty(this.txtTel.Text)
                )
            {
                MessageBox.Show("All of above propertities is required !!");
                return;
            }
            else 
            {
                Personal personal = new Personal();
                personal.Name = this.txtName.Text;
                personal.Email = this.txtEmail.Text;
                personal.Birth = this.txtBirthDay.Text;
                personal.Tel = this.txtTel.Text;
                ActionLogic actionLigic = new ActionLogic();
                result = actionLigic.AddPersonal(personal);
            }
            if (result)
            {
                MessageBox.Show("Insert success!!!");
            }
            else
            {
                MessageBox.Show("Please re-try after check the field!!!");
            }
        }

        /// <summary>
        /// Event handle the view btn click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnView_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event handle for the exit btn click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
