using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Entities
{
    public class TreeNode
    {
        public int data;
        TreeNode LChild = null;
        TreeNode RChild = null;
        //TreeNode PChild = null;


         public void Add(int data)
        {
            if (data < this.data)
            {
                if (this.LChild != null)
                {
                    this.LChild.Add(data);
                }
                else
                {
                    this.LChild = new TreeNode();
                    this.LChild.data = data;
                }
            }
            else
            {
                if (this.RChild != null)
                {
                    this.RChild.Add(data);
                }
                else
                {
                    this.RChild = new TreeNode();
                    this.RChild.data = data;
                }
            }
        }

         internal void View(Collection<int> resultArr)
         {
             if (this.LChild != null)
             {
                 this.LChild.View(resultArr);
             }
             resultArr.Add(this.data);
             if (this.RChild != null)
             {
                 this.RChild.View(resultArr);
             }
         }
    }
}
