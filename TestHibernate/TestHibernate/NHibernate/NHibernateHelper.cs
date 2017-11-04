using NHibernate;
using NHibernate.Cfg;

namespace TestHibernate.NHibernate
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory sessionFactory;
        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetSession()
        {
            ISession currentSession;
            currentSession = sessionFactory.OpenSession();
            return currentSession;
        }

        public static void CloseSession(ISession session) 
        {
            session.Close();
        }

        public static void ColseSessionFactroy()
        {
            sessionFactory.Close();
        }
    }
}
