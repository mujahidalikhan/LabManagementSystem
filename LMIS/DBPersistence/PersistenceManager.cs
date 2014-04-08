using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LMIS.DBModel;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace LMIS.DBPersistence
{
    public class PersistenceManager : IDisposable
    {
        #region Declarations

        // Member variables
        private ISessionFactory _mSessionFactory;
        private ISession _mSession;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PersistenceManager()
        {
            ConfigureNHibernate();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _mSessionFactory.Dispose();

        }

        #endregion

        #region Public Methods



        /// <summary>
        /// Close this Persistence Manager and release all resources (connection pools, etc). It is the responsibility of the application to ensure that there are no open Sessions before calling Close().
        /// </summary>
        public void Close()
        {
            _mSessionFactory.Close();
        }

        /// <summary>
        /// Deletes an object of a specified type.
        /// </summary>
        /// <typeparam name="T">The type of objects to delete.</typeparam>
        public void Delete<T>(T item)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Delete(item);
                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Deletes objects of a specified type.
        /// </summary>
        /// <param name="itemsToDelete">The items to delete.</param>
        /// <typeparam name="T">The type of objects to delete.</typeparam>
        public void Delete<T>(IList<T> itemsToDelete)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                foreach (T item in itemsToDelete)
                {
                    using (session.BeginTransaction())
                    {
                        session.Delete(item);
                        session.Transaction.Commit();
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves all objects of a given type.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <returns>A list of all objects of the specified type.</returns>
        public IList<T> RetrieveAll<T>(SessionAction sessionAction)
        {
            /* Note that NHibernate guarantees that two object references will point to the
             * same object only if the references are set in the same session. For example,
             * Order #123 under the Customer object Able Inc and Order #123 in the Orders
             * list will point to the same object only if we load Customers and Orders in 
             * the same session. If we load them in different sessions, then changes that
             * we make to Able Inc's Order #123 will not be reflected in Order #123 in the
             * Orders list, since the references point to different objects. That's why we
             * maintain a session as a member variable, instead of as a local variable. */

            // Open a new session if specified
            if ((sessionAction == SessionAction.Begin) || (sessionAction == SessionAction.BeginAndEnd))
            {
                _mSession = _mSessionFactory.OpenSession();
            }

            // Retrieve all objects of the type passed in
            ICriteria targetObjects = _mSession.CreateCriteria(typeof(T));
            IList<T> itemList = targetObjects.List<T>();

            // Close the session if specified
            if ((sessionAction == SessionAction.End) || (sessionAction == SessionAction.BeginAndEnd))
            {
                _mSession.Close();
                _mSession.Dispose();
            }

            // Set return value
            return itemList;
        }


        public IList<T> RetrieveAll<T>()
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(T));
                IList<T> itemList = targetObjects.List<T>();
                // Set return value
                return itemList;
            }
        }


        public IList<T> RetrieveDistinct<T>(string propertyName)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                var projections =
                    Projections.Distinct(Projections.ProjectionList()
                                                    .Add(Projections.Property(propertyName), propertyName));
                var companyDto = session.QueryOver<Specification>()

                                        .Select(projections)
                                        .TransformUsing(Transformers.AliasToBean<T>())
                                        .List<T>();



                // Set return value
                return companyDto;
            }
        }



        public IList<T> RetrieveAllBetween<T>(string propertyName, object propertyLowValue, object propertyHeigValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Between(propertyName, propertyLowValue, propertyHeigValue));
                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }




        /// <summary>
        /// Retrieves objects of a specified type where a specified property equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <param name="propertyName">The name of the property to be tested.</param>
        /// <param name="propertyValue">The value that the named property must hold.</param>
        /// <returns>A list of all objects meeting the specified criteria.</returns>
        public IList<T> RetrieveEquals<T>(string propertyName, object propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Eq(propertyName, propertyValue));

                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }

        /// <summary>
        /// Retrieves objects of a specified type where a specified property equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <param name="propertyName">The name of the property to be tested.</param>
        /// <param name="propertyValue">The value that the named property must hold.</param>
        /// <returns>A list of all objects meeting the specified criteria.</returns>
        public IList<T> RetrieveDistinctEquals<T>(string propertyName, object propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Eq(propertyName, propertyValue));
                criteria.SetResultTransformer(new DistinctRootEntityResultTransformer());
                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }


        /// <summary>
        /// Retrieves objects of a specified type where a specified property equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <param name="propertyName">The name of the property to be tested.</param>
        /// <param name="propertyValue">The value that the named property must hold.</param>
        /// <returns>A list of all objects meeting the specified criteria.</returns>
        public IList<T> RetrieveLike<T>(string propertyName, object propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Like(propertyName, string.Format("%{0}%", propertyValue)));
                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }


        public IList<T> RetrieveLike<T>(string[] propertyName, object[] propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Eq(propertyName[0], propertyValue[0]));
                criteria.Add(Restrictions.Like(propertyName[1], string.Format("%{0}%", propertyValue[1])));

                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }


        public IList<T> RetrieveEqualAndNotNull<T>(string[] propertyName, object[] propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Eq(propertyName[0], propertyValue[0]));
                criteria.Add(Restrictions.IsNotNull(propertyName[1]));

                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }


        public IList<T> RetrieveDateBetween<T>(string[] propertyName, object[] propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Eq(propertyName[0], propertyValue[0]));
                criteria.Add(Restrictions.Between(propertyName[1], propertyValue[1], propertyValue[2]));


                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }
        public IList<T> RetrieveLessThen<T>(string propertyName, object propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.Add(Restrictions.Le(propertyName, propertyValue));

                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }

        /// <summary>
        /// Retrieves objects of a specified type where a specified property equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <param name="propertyName">The name of the property to be tested.</param>
        /// <param name="propertyValue">The value that the named property must hold.</param>
        /// <returns>A list of all objects meeting the specified criteria.</returns>
        public IList<T> RetrieveEquals<T>(string[] propertyName, object[] propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));
                for (int i = 0; i < propertyName.Length; i++)
                {
                    criteria.Add(Restrictions.Eq(propertyName[i], propertyValue[i]));
                }



                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }


        /// <summary>
        /// Retrieves objects of a specified type where a specified property equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <param name="propertyName">The name of the property to be tested.</param>
        /// <param name="propertyValue">The value that the named property must hold.</param>
        /// <returns>A list of all objects meeting the specified criteria.</returns>
        public IList<T> RetrieveEqualLike<T>(string propertyName, object propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));


                criteria.Add(Restrictions.Like(propertyName, string.Format("%{0}%", propertyValue)));



                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }


        /// <summary>
        /// Retrieves objects of a specified type where a specified property equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <param name="propertyName">The name of the property to be tested.</param>
        /// <param name="propertyValue">The value that the named property must hold.</param>
        /// <returns>A list of all objects meeting the specified criteria.</returns>
        public IList<T> RetrieveEqualGrater<T>(string[] propertyName, object[] propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));

                criteria.Add(Restrictions.Eq(propertyName[0], propertyValue[0]));
                criteria.Add(Restrictions.Gt(propertyName[1], propertyValue[1]));
                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }


        /// <summary>
        /// Retrieves objects of a specified type where a specified property equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be retrieved.</typeparam>
        /// <param name="propertyName">The name of the property to be tested.</param>
        /// <param name="propertyValue">The value that the named property must hold.</param>
        /// <returns>A list of all objects meeting the specified criteria.</returns>
        public IList<T> RetrieveEqualLike<T>(string[] propertyName, object[] propertyValue)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                // Create a criteria object with the specified criteria
                ICriteria criteria = session.CreateCriteria(typeof(T));

                criteria.Add(Restrictions.Eq(propertyName[0], propertyValue[0]));
                criteria.Add(Restrictions.Like(propertyName[1], string.Format("%{0}%", propertyValue[1])));



                // Get the matching objects
                IList<T> matchingObjects = criteria.List<T>();

                // Set return value
                return matchingObjects;
            }
        }

        /// <summary>
        /// Saves an object and its persistent children.
        /// </summary>
        public object Save<T>(T item)
        {
            object key;
            using (ISession session = _mSessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    key = session.Save(item);
                    session.Transaction.Commit();
                }
            }
            return key;
        }



        /// <summary>
        /// Saves an object and its persistent children.
        /// </summary>
        public void Update<T>(T item)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    session.Transaction.Commit();
                }
            }

        }

        /// <summary>
        /// Saves an object and its persistent children.
        /// </summary>
        public void Save<T>(T item, object id)
        {
            using (ISession session = _mSessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Save(item, id);
                    session.Transaction.Commit();
                }
            }

        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Configures NHibernate and creates a member-level session factory.
        /// </summary>
        private void ConfigureNHibernate()
        {
            // Initialize
            var cfg = new Configuration();
            cfg.Configure();

            /* Note: The AddAssembly() method requires that mappings be 
             * contained in hbm.xml files whose BuildAction properties 
             * are set to ‘Embedded Resource’. */

            Assembly thisAssembly = typeof(SystemUsers).Assembly;
            cfg.AddAssembly(thisAssembly);

            // Create session factory from configuration object
            _mSessionFactory = cfg.BuildSessionFactory();
        }

        #endregion
    }
}
