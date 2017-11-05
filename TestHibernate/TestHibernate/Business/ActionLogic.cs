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

        public List<Personal> GetPersonalList()
        {
            List<Personal> result = new List<Personal>();
            Personal personal = null;
            ISession session = null;
            ITransaction transaction = null;
            ICriteria crit = null;
            try
            {
                session = NHibernateHelper.GetSession();
                transaction = session.BeginTransaction();
                transaction.Begin();
                crit = session.CreateCriteria(typeof(Personal));
                foreach(var item in crit.List())
                {
                    personal = item as Personal;
                    result.Add(personal);
                }
                transaction.Commit();
            }
            finally
            {
                NHibernateHelper.CloseSession(session);
            }
            return result;
        }
    }
}
