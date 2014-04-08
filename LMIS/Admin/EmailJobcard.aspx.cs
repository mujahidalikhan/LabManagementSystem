using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMIS.Admin
{
    public partial class EmailJobcard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control ctrl = (Control)Session["ctrl"];
            string emailToAddress =(string) Session["ToEmail"];
            Helper.EmailWebControl(ctrl, emailToAddress, (string)Session["emailTemplate"]);
        }
    }
}