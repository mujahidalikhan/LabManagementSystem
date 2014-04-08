using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LMIS.DBModel;

namespace LMIS.Sampler
{
    public partial class PrintJob : System.Web.UI.Page
    {
        private static JobInfo objJobInfo;
        private static List<JobDetail> listJobDetail;
        private static ContactInfo objContactInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            objJobInfo = Global.ObjJobController.GetJobInfo(Int32.Parse(Page.Request.QueryString["qid"]));
            objContactInfo = Global.ObjDbController.GetContactInfo(objJobInfo.Customer.CustID);
            if (objJobInfo.JobId != 0)
            {
                JobNumber.Text = objJobInfo.JobNumber.ToString();
                ClientName.Text = objJobInfo.Customer.CustName;
                customerAddress.Text = objJobInfo.Customer.Address;

                dllAttention.Text = objContactInfo.Name;
                TelNo.Text = objContactInfo.Phone;
                FaxNo.Text = objContactInfo.Fax;
                Email.Text = objContactInfo.Email;
                HomePhone.Text = objContactInfo.HPhone;

                JobDate.Text = objJobInfo.CreateDate.ToShortDateString();
                Validity.Text = (objJobInfo.Validatily - objJobInfo.CreateDate).Days.ToString();
                paymentDate.Text = (objJobInfo.TermOfPayment - objJobInfo.CreateDate).Days.ToString();

                listJobDetail = Global.ObjJobController.CurrentJobDetail(Int32.Parse(Page.Request.QueryString["qid"]));

              
                FillTestDeatilTable();

            }
            if ((string)Session["ActionType"].ToString() == "Print")
            {
                Helper.PrintWebControl(pnl1, (string)Session["Template"]);
            }
            else
            { Helper.EmailWebControl(pnl1, Email.Text, (string)Session["Template"]); }
        }


        private void FillTestDeatilTable()
        {
            for (int i = 1; i < tblTestDeatil.Rows.Count; i++)
            {
                tblTestDeatil.Rows.RemoveAt(i);
            }
            int counter = 1;


            using (var row = new HtmlTableRow())
            {

                row.Cells.Add(new HtmlTableCell { InnerHtml = "&nbsp;", ColSpan = 5 });
                tblTestDeatil.Controls.Add(row);

            }

            foreach (JobDetail objJobDetail in listJobDetail)
            {
                using (var row = new HtmlTableRow())
                {

                    if (objJobDetail.Descriptation != null)
                    {
                        row.Cells.Add(new HtmlTableCell { InnerHtml = counter.ToString(), Align = "center" });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Descriptation });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = "&nbsp;" });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = "&nbsp;" });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = "&nbsp;" });

                        counter++;
                    }
                    else
                    {
                        row.Cells.Add(new HtmlTableCell { InnerHtml = "&nbsp;" });
                        var currentTestList = objJobDetail.TestInfo.Split(',');
                        var testDescriptation = currentTestList.Aggregate("<b><u> Parameter of Testing</u></b><br />", (current, val) => current + ("<br />" + val));
                        testDescriptation += "<br /> <br /><br /><br /><b><u>Frequency</u></b><br />";
                        if (objJobDetail.Frequency == null) objJobDetail.Frequency = "0";
                        testDescriptation += string.Format("{0}sampls/week x 4 weeks/month = {1} samples/month <br /> <br />", objJobDetail.Frequency, (Int32.Parse(objJobDetail.Frequency) * 4));


                        row.Cells.Add(new HtmlTableCell { InnerHtml = testDescriptation, VAlign = "Top" });

                        row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Quantity + " samples", VAlign = "Top", Align = "center" });

                    }

                    tblTestDeatil.Controls.Add(row);


                }


            }

        }


    
    }
}