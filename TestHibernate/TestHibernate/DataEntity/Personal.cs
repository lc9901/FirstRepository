using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHibernate.DataEntity
{
    public class Personal
    {
        private int id;
        private string name;
        private string tel;
        private string email;
        private string birth;

        public virtual int Id
        {
            get 
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public virtual string Name
        {
            get 
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public virtual string Tel 
        {
            get 
            {
                return this.tel;
            }
            set 
            {
                this.tel = value;
            }
        }

        public virtual string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public virtual string Birth
        {
            get
            {
                return this.birth;
            }
            set 
            {
                this.birth = value;
            }
        }
    }
}
