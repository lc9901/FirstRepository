using MyCalc.Logic;
using System.Windows.Forms;

namespace MyCalc
{
    partial class Form1
    {
        private void InitEvent() 
        {
            //Number click.
            this.button1.Click += DoBtnClick_Number;
            this.button2.Click += DoBtnClick_Number;
            this.button3.Click += DoBtnClick_Number;
            this.button4.Click += DoBtnClick_Number;
            this.button5.Click += DoBtnClick_Number;
            this.button6.Click += DoBtnClick_Number;
            this.button7.Click += DoBtnClick_Number;
            this.button8.Click += DoBtnClick_Number;
            this.button9.Click += DoBtnClick_Number;
            this.button0.Click += DoBtnClick_Number;

            //Operation Click
            this.buttonClear.Click += DoBtnClear;
            this.buttonBack.Click += DoBtnBack;
            this.buttonSubtraction.Click += DoBtnOperation;
            this.buttonMultiplication.Click += DoBtnOperation;
            this.buttonDivision.Click += DoBtnOperation;
            this.buttonAdd.Click += DoBtnOperation;

            this.buttonShutDown.Click += DoShutDown;
            
            //LeftorRight
            this.buttonLeft.Click += DoBtnLR;
            this.buttonRight.Click += DoBtnLR;

            //Calc
            this.buttonEnter.Click += DoBtnEnter;

            this.textBox1.TextChanged += SetBtnStatus;
        }

        private void SetBtnStatus(object sender, System.EventArgs e)
        {
            if (this.contect.Length > 0)
            {
                this.buttonBack.Enabled = true;
            }
            else
            {
                this.buttonBack.Enabled = false;
            }
        }

        /// <summary>
        /// Calcs the expression.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnEnter(object sender, System.EventArgs e)
        {
            if (flagNeedLeft == 0 && flagIsNumber && this.textBox1.Text.Length > 0)
            {
                string result = CalcLogic.Calc(contect.Append("#").ToString());
                DoBtnClear(null,null);
                this.labelResult.Text = result;
            }
            else
            {
                MessageBox.Show("Please check your input!!!");
            }
        }

        /// <summary>
        /// Appends the (.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnLR(object sender, System.EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (null != clickedButton)
            {
                string operation = clickedButton.Tag as string;
                contect.Append(operation);
                if (operation.Equals("("))
                {
                    flagNeedLeft++;
                }
                if (operation.Equals(")"))
                {
                    flagNeedLeft--;
                }
            }
            RefreashSceen();
        }

        /// <summary>
        /// Exit the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoShutDown(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handel the click event for the back button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnBack(object sender, System.EventArgs e)
        {
            if (contect[contect.Length - 1].Equals("(")) 
            {
                flagNeedLeft--;
            }
            if (contect[contect.Length - 1].Equals(")"))
            {
                flagNeedLeft++;
            }
            if (
                contect.Length > 1 &&
                contect[contect.Length - 2].Equals("+") ||
                contect[contect.Length - 2].Equals("-") ||
                contect[contect.Length - 2].Equals("/") ||
                contect[contect.Length - 2].Equals("*")
                )
            {
                flagIsNumber = false;
            }

            contect.Remove(contect.Length - 1, 1);
            RefreashSceen();
        }

        /// <summary>
        ///  Handel the click event for the clear button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBtnClear(object sender, System.EventArgs e)
        {
            flagIsNumber = true;
            flagNeedLeft = 0;
            contect.Clear();
            RefreashSceen();
        }

        private void DoBtnOperation(object sender, System.EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (null != clickedButton)
            {
                string operation = clickedButton.Tag as string;
                if (flagIsNumber)
                {
                    contect.Append(operation);
                    flagIsNumber = false;
                }
                
            }
            RefreashSceen();
        }

        void DoBtnClick_Number(object sender, System.EventArgs e)
        {
           Button clickedButton = sender as Button;
           if (null != clickedButton) 
           {
               flagIsNumber = true;
               string number = clickedButton.Tag as string;
               contect.Append(number);
           }
           RefreashSceen();
        }

        private void RefreashSceen() 
        {
            this.textBox1.Text = contect.ToString();
        }


    }
}
