using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStudy.Folder
{
    public class HuffmanUtil
    {

        //public Dictionary<char,WeightEntity> GetWeightArry(string messageString)
        //{
            
        //}
        private HuffmanTree[] huffmanTree;
        private HuffmanCode[] huffmanCode;
        private int charCount;
        public HuffmanTree[] HuffmanTrees
        {
            get
            {
                return this.huffmanTree;
            }
        }
        public HuffmanCode[] HuffmanCodes
        {
            get
            {
                return this.huffmanCode;
            }
        }
        public HuffmanUtil(int charCount)
        {
            this.charCount = charCount;
            huffmanTree = new HuffmanTree[charCount * 2 - 1];
            huffmanCode = new HuffmanCode[charCount + 1];
            InitializeTree();
        }

        private void InitializeTree()
        {
            // 生成赫夫曼树

            int i = 1;
            for (; i <= charCount; i++)
            {
                huffmanTree[i].Weight = i;
            }
            huffmanTree[0].Weight = int.MaxValue;
            
            for (; i < huffmanTree.Length; i++) 
            {
                huffmanTree[i].Weight = 0;
                huffmanTree[i].Parent=0;
                huffmanTree[i].LChild=0;
                huffmanTree[i].Rchild=0;
            }

            for (int j = charCount + 1; j <= huffmanTree.Length; ++j )
            {
                int s1, s2;
                Select(huffmanTree, j - 1, out s1, out s2);

                huffmanTree[s1].Parent = j; huffmanTree[s2].Parent = j;
                huffmanTree[j].LChild = s1; huffmanTree[j].Rchild = s2;

                huffmanTree[j].Weight = huffmanTree[s1].Weight + huffmanTree[s2].Weight;
            }

            // 生成每一个字符的赫夫曼编码

            char[] workArea = new char[charCount];

            workArea[charCount - 1] = '\n';

            for (int j = 1; j <= charCount; ++j)
            {
                int start = charCount - 1;
                for (int c = j, pare = huffmanTree[j].Parent; pare != 0; c = pare, pare = huffmanTree[pare].Parent )
                {
                    if (huffmanTree[pare].LChild == j) workArea[--start] = '0';
                    else workArea[--start] = '1';
                    huffmanCode[j] = new HuffmanCode(charCount - start);

                    for (int k = 0; k < huffmanCode[j].code.Length; k++)
                    {
                        huffmanCode[j].code[k] = workArea[start + k];
                    }

                }
            }

        }

        private void Select(HuffmanTree[] huffmanTree, int p, out int s1, out int s2)
        {
            s1 = 0;
            
            for (int i = 2; i <= p; i++)
            {
                if (huffmanTree[i].Parent == 0 && huffmanTree[s1].Weight > huffmanTree[i].Weight)
                {
                    s1 = i;
                }
            }
            s2 = 0;
            for (int i = 2; i <= p; i++)
            {
                if (huffmanTree[i].Parent == 0 && huffmanTree[s2].Weight > huffmanTree[i].Weight && huffmanTree[i].Weight > huffmanTree[s1].Weight)
                {
                    s2 = i;
                }
            }

        }

    }
}
