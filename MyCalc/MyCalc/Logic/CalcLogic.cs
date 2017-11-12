using MyCalc.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc.Logic
{
    public class CalcLogic
    {
        public static string Calc(string text)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(text)) 
            {
                char[] charChcae = text.ToCharArray();
                StackOperation stackOperation = new StackOperation(20);
                StackCalc stackNumber = new StackCalc(20);

                // This value is the current value.
                int numberCache = 0;

                stackOperation.Push('#');
                for (int i = 0; i < charChcae.Length; i++) 
                {
                    int op;

                    if (!int.TryParse(charChcae[i].ToString(), out op))
                    {
                        // The value is non-number
                        int compareResult = CalcUtils.Compare(stackOperation.ViewTop(), charChcae[i]);

                        switch (compareResult)
                        {
                            case 1:    // The step:
                                            //      --1.Record the current operator
                                            //      --2.Pop the operator from stackOperation.
                                            //      --3.Pop two number from stackNumber.
                                            //      --4.Clac the number and push the result to the stackNumber.
                                            //      --5.Compare the record operator with the 

                                PushTheOperator(stackOperation.ViewTop(), charChcae[i], stackOperation, stackNumber);
                                break;
                            case 0: // Pop the top element from the stackOperation.
                                stackOperation.Pop();
                                break;
                            case -1: // Pust the current operator to the stackOperation.
                                stackOperation.Push(charChcae[i]);
                                break;
                            default :
                                Exception e = new Exception("Express is wrong");
                                throw e;
                        }
                    }
                    else
                    {
                        // The value is number
                        // The previous is number
                        if (int.TryParse(charChcae[i + 1].ToString(), out op))
                        {
                            numberCache += Convert.ToInt32(charChcae[i].ToString()) * 10;
                        }
                        else 
                        {
                            numberCache += Convert.ToInt32(charChcae[i].ToString());
                            stackNumber.Push(numberCache);
                            numberCache = 0;
                        }

                    }
                }
                result = stackNumber.ViewTop().ToString();
            }
            return result;
        }


        private static void PushTheOperator(char lastOneOperator, char current, StackOperation stackOp, StackCalc stackNumb) 
        {
            // The value is non-number
            int compareResult = CalcUtils.Compare(lastOneOperator, current);

            switch (compareResult)
            {
                case 1:    // The step:
                    //      --1.Record the current operator
                    //      --2.Pop the operator from stackOperation.
                    //      --3.Pop two number from stackNumber.
                    //      --4.Clac the number and push the result to the stackNumber.
                    //      --5.Compare the record operator with the 
                    int number1 = stackNumb.Pop();
                    int number2 = stackNumb.Pop();
                    char operatorTop = stackOp.Pop();

                    int resultValue = CalcUtils.ExcuteCalc(number1, number2, operatorTop);
                    stackNumb.Push(resultValue);

                    PushTheOperator(stackOp.ViewTop(), current, stackOp, stackNumb);
                    break;
                case 0: // Pop the top element from the stackOperation.
                    stackOp.Pop();
                    break;
                case -1: // Pust the current operator to the stackOperation.
                    stackOp.Push(current);
                    break;
                default:
                    Exception e = new Exception("Express is wrong");
                    throw e;
            }
        }
    }
}
