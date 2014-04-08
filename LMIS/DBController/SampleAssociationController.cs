using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMIS.DBModel;
using LMIS.DBPersistence;
namespace LMIS.DBController
{
    public class SampleAssociationController
    {
      private static  readonly PersistenceManager _mPersistenceManager = new PersistenceManager();

      public static int Add(SampleAssociation objSampleAssociation)
        {
            return (int)_mPersistenceManager.Save(objSampleAssociation);
        }

      public static void Update(SampleAssociation objSampleAssociation)
        {
            _mPersistenceManager.Update(objSampleAssociation);
        }

      public static void Delete(int sampleAssociationId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<SampleAssociation>("Id", sampleAssociationId);
            foreach (var objEvent in EeventList)
            {
                _mPersistenceManager.Delete(objEvent);
            }
        }

      public static SampleAssociation Get(int sampleAssociationId)
        {
            var EeventList = _mPersistenceManager.RetrieveEquals<SampleAssociation>("Id", sampleAssociationId);
            return EeventList.Count > 0 ? EeventList[0] : new SampleAssociation();
        }



      public static  List<SampleAssociation> Get()
        {
            var sampleAssociationList = _mPersistenceManager.RetrieveAll<SampleAssociation>();
            return sampleAssociationList.Count > 0 ? sampleAssociationList.ToList() : new List<SampleAssociation>();
        }


      public static List<SampleAssociation> GetByTestId(int testId)
      {
          var sampleAssociationList = _mPersistenceManager.RetrieveEquals<SampleAssociation>("TestId", testId);
          return sampleAssociationList.Count > 0 ? sampleAssociationList.ToList() : new List<SampleAssociation>();
      }

      public static List<SampleAssociation> GetBySamplerId(int samplerId)
      {
          var sampleAssociationList = _mPersistenceManager.RetrieveEquals<SampleAssociation>("SamplerID", samplerId);
          return sampleAssociationList.Count > 0 ? sampleAssociationList.ToList() : new List<SampleAssociation>();
      }

      public static List<SampleAssociation> GetByEventId(int eventId)
      {
          var sampleAssociationList = _mPersistenceManager.RetrieveEquals<SampleAssociation>("eventId", eventId);
          return sampleAssociationList.Count > 0 ? sampleAssociationList.ToList() : new List<SampleAssociation>();
      }

    }
}