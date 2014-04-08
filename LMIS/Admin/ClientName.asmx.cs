using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LMIS.DBController;
namespace LMIS.Admin
{
    /// <summary>
    /// Summary description for ClientName
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ClientName : System.Web.Services.WebService
    {


        [System.Web.Services.WebMethod]
[System.Web.Script.Services.ScriptMethod]
public string[] GetCompletionList(string prefixText, int count)
        {
            DbController controllers=new DbController();

            return controllers.GetCustomerInfo(prefixText);
        }
    }
}
