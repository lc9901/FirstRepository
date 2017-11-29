using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Entities
{
    class SearchBrinaryTree
    {
        TreeNode treeTitle;
        private int count = 0;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public SearchBrinaryTree()
        {
            treeTitle = new TreeNode();
        }

        public void InserNode(int data)
        {
            if (count == 0)
            {
                treeTitle.data = data;
                count++;
                return;
            }
            treeTitle.Add(data);
            count++;
        }

        public Collection<int> TravelTree()
        {
            Collection<int> resultArr = new Collection<int>();
            treeTitle.View(resultArr);
            return resultArr;
        }
    }
}
