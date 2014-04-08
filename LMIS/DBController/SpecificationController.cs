using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LMIS.DBPersistence;
using LMIS.DBModel;
using System;
namespace LMIS.DBController
{
    public class SpecificationController
    {
        private static  readonly PersistenceManager _mPersistenceManager = new PersistenceManager();

        #region Specification1

        public static void AddSpecification1(Specification objSpecification)
        {

            _mPersistenceManager.Save(objSpecification);
        }

        public static void UpdateSpecification1(Specification objSpecification1)
        {
            _mPersistenceManager.Update(objSpecification1);
        }



        public static Specification GetSpecification1(int specificationId)
        {
            IList<Specification> objSpecification1 =
                _mPersistenceManager.RetrieveEquals<Specification>("SpecificationId", specificationId);
         if(objSpecification1.Count >0)
            return objSpecification1[0];
         else
         {
             return new Specification();
         }
        }

        public static Specification GetSpecbyTestId(int TestId)
        {
            var objList = _mPersistenceManager.RetrieveEquals<Specification>("TestId", TestId);
            return objList.Count > 0 ? objList[0] : new Specification();
        }

        public  static List<Specification> GetSpecification1()
        {
            IList<Specification> objSpecification1 =
                _mPersistenceManager.RetrieveAll<Specification>();
            if(objSpecification1.Count>0)
            return objSpecification1.ToList();
            else
            {
                return new List<Specification>();
            }
        }

        public static List<Specification> GetSpecification1byParameter(string SpecificationName, int TestId)
        {
            String[] Col = new string[] { "SpecificationName", "TestId.TestParameterId" };
            object[] val = new object[] { SpecificationName, TestId };
            IList<Specification> objSpecification1 =_mPersistenceManager.RetrieveEquals<Specification>(Col, val);
           if(objSpecification1.Count>0)
            return objSpecification1.ToList();
           else
           {
               return new List<Specification>();
           }
        }


        public  static void DeleteSpecification1(int objSpecificationId)
        {
            IList<Specification> objSpecification =
              _mPersistenceManager.RetrieveEquals<Specification>("SpecificationId", objSpecificationId);

            _mPersistenceManager.Delete(objSpecification);
        }

        public static bool IsSpecificationExist(string specificationName , int testId)
        {

            String[] sepName = new string[] { "SpecificationName", "TestId.TestParameterId" };
            object[] sepDate = new object[] { specificationName, testId };
            IList<Specification> objSpecification =
                _mPersistenceManager.RetrieveEquals<Specification>(sepName, sepDate);

            return objSpecification.Count > 0;
        }



        public  static string GetSpecification1ParameterValue(string testParameter)
        {
            IList<Specification> objSpecification =
                _mPersistenceManager.RetrieveEquals<Specification>("TestParameter", testParameter);
            return objSpecification.Count > 0 ? objSpecification[0].StdA : "-";
        }

        #endregion



        public  static string GetSpecificationValue(string type, string ParameterName)
        {
            var returnVal = "-";
            if (type != null)
                switch (type)
                {
                    case "Default":
                        break;
                    case "Specification 1":
                        returnVal = GetSpecification1ParameterValue(ParameterName);
                        break;
                  
                }
            return returnVal;
        }


        public static List<Specification> GetSpecification1List()
        {
            var SpecificationList =_mPersistenceManager.RetrieveAll<Specification>();
            return SpecificationList.Select(specificationVal => new Specification
                                                                    {
                                                                        Others = specificationVal.Others,
                                                                        SpecificationId = specificationVal.SpecificationId,
                                                                        StdA = specificationVal.StdA,
                                                                        StdB = specificationVal.StdB,
                                                                        TestId = specificationVal.TestId,
                                                                    }).ToList();
        }
        

        


        public static void SetSpecificationValueInTable(TestResult result, TableRow row,
                                                    String specification,int activeTestId,
                                                    TestParameterInfo objTestParameterInfo,String stander)
        {

            List<Specification> objSpec1 = SpecificationController.GetSpecification1byParameter(specification, activeTestId);
                    if (objSpec1.Count > 0)
                    {
                        if (stander == "StdA")
                        {
                            var stdA = new Label {ID = "stdA" + result.TestResultId, Text = "Standard A " + objSpec1[0].StdA};
                            var tablestdACell = new TableCell();
                            tablestdACell.Controls.Add(stdA);
                            row.Cells.Add(tablestdACell);
                        }
                        else if (stander == "StdB")
                        {
                            var stdB = new Label { ID = "stdA" + result.TestResultId, Text = "Standard B " + objSpec1[0].StdB };
                            var tablestdBCell = new TableCell();
                            tablestdBCell.Controls.Add(stdB);
                            row.Cells.Add(tablestdBCell);
                        }
                        else if (stander == "Others")
                        {
                            var Customize = new Label { ID = "stdA" + result.TestResultId, Text = "Standard Others " + objSpec1[0].Others };
                            var tableCustomizeCell = new TableCell();
                            tableCustomizeCell.Controls.Add(Customize);
                            row.Cells.Add(tableCustomizeCell);
                        }
                    }
                    else
                    {
                        row.Cells.Add(new TableCell { Text = "-" });
                       
                    }
                  
                   
        }


        public static List<Specification> GetDistanceSpecification()
        {
            var returnVal = _mPersistenceManager.RetrieveDistinct<Specification>("SpecificationName");
            return returnVal.Count == 0 ? new List<Specification>() : returnVal.ToList();
        }

        public static List<Specification> GetSpecificationByName(string specificationName)
        {
            IList<Specification> objSpecification =
              _mPersistenceManager.RetrieveEquals<Specification>("SpecificationName", specificationName);

            if (objSpecification.Count > 0)
                return objSpecification.ToList();
            else
                return new List<Specification>();
        }


    }
}