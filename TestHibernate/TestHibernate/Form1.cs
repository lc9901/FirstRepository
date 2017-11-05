using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TestHibernate.Business;
using TestHibernate.DataEntity;

namespace TestHibernate
{
    public partial class Main : Form
    {
        private List<Personal> personalList = null;

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

        /// <summary>
        /// Handles the click event for the insert button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            bool result = false;
            if (
                string.IsNullOrEmpty(this.txtName.Text) ||
                string.IsNullOrEmpty(this.txtEmail.Text) ||
                string.IsNullOrEmpty(this.txtBirthDay.Text) ||
                string.IsNullOrEmpty(this.txtTel.Text)
                )
            {
                MessageBox.Show("All of above propertities is required !!");
                this.btnOK.Enabled = true;
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
                this.txtName.Text = string.Empty;
                this.txtEmail.Text= string.Empty;
                this.txtBirthDay.Text= string.Empty;
                this.txtTel.Text = string.Empty;
            }
            if (result)
            {
                MessageBox.Show("Insert success!!!");
            }
            else
            {
                MessageBox.Show("Please re-try after check the field!!!");
            }
            this.btnOK.Enabled = true;
        }

        /// <summary>
        /// Event handle the view btn click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnView_Click(object sender, EventArgs e)
        {
            ActionLogic actionLigic = new ActionLogic();
            personalList = actionLigic.GetPersonalList();
            listItem viewItem = null;
            if (null != personalList && personalList.Count > 0)
            {
                int idex = 0;
                this.pnlItemBox.Controls.Clear();

                foreach (Personal item in personalList)
                {
                    viewItem = new listItem();
                    viewItem.ItemId = item.Id;
                    viewItem.ItemName = item.Name;
                    viewItem.ItemTel = item.Tel;
                    viewItem.ItemEmail = item.Email;
                    viewItem.ItemBirth = item.Birth;
                    viewItem.Location = new Point(5, viewItem.Size.Height * idex + 37);
                    idex++;
                    this.pnlItemBox.Controls.Add(viewItem);
                }
                this.pnlItemBox.Visible = true;
                this.btnView.Text = "back";
                this.btnView.Click -= DoBtnView_Click;
                this.btnView.Click += DoBtnBack_Click;
                personalList.Clear();
            }
            else
            {
                MessageBox.Show("There is no data.");
            }
        }

        /// <summary>
        /// Handles the click event for the back button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnBack_Click(object sender, EventArgs e)
        {
            this.btnView.Enabled = false;
            this.btnView.Click -= DoBtnBack_Click;
            this.btnView.Click += DoBtnView_Click;
            this.btnView.Text = "view";
            this.pnlItemBox.Visible = false;
            this.btnView.Enabled = true;
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
