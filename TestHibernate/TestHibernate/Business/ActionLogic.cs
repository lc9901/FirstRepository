using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHibernate.DataEntity;
using TestHibernate.NHibernate;

namespace TestHibernate.Business
{
    public class ActionLogic
    {
        public bool AddPersonal(Personal personal)
        {
            bool result = true;
            ISession session = null;
            ITransaction transaction = null;
            try
            {
                session = NHibernateHelper.GetSession();
                transaction = session.BeginTransaction();
                transaction.Begin();
                session.Save(personal);
                transaction.Commit();
            }
            catch (Exception e)
            {
                result = false;
                transaction.Rollback();
            }
            finally
            {
                NHibernateHelper.CloseSession(session);
            }
            return result;
        }
    }
}
