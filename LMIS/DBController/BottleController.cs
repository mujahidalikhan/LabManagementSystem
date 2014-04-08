using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMIS.DBModel;
using LMIS.DBPersistence;
namespace LMIS.DBController
{
    public class BottleController
    {
        readonly PersistenceManager _mPersistenceManager = new PersistenceManager();

        public int Add(Bottle objBottle)
        {
            return (int)_mPersistenceManager.Save(objBottle);
        }

        public void Update(Bottle objBottle)
        {
            _mPersistenceManager.Update(objBottle);
        }

        public void Delete(int bottleId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<Bottle>("bottleId", bottleId);
            foreach (var objEvent in EeventList)
            {
                _mPersistenceManager.Delete(objEvent);
            }
        }

        public Bottle Get(int bottleId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<Bottle>("bottleId", bottleId);
            return EeventList.Count > 0 ? EeventList[0] : new Bottle();
        }

        public List<Bottle> Get()
        {
            var bottleList = _mPersistenceManager.RetrieveAll<Bottle>();
            return bottleList.Count > 0 ? bottleList.ToList() : new List<Bottle>();
        }
        
        
    }
}