using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using LMIS.DBModel;

namespace LMIS.JobCustomControl
{
    public partial class ViewArchiveJob : System.Web.UI.UserControl
    {
        private  JobInfoArchive objJobInfo = new JobInfoArchive();
        private  List<JobDetailArchive> listJobDetail   = new List<JobDetailArchive>();
        public string JobStaus { set; get; }
        public bool isViewOnly = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            objJobInfo = Global.ObjJobController.GetJobInfoArchive(Int32.Parse(Page.Request.QueryString["qid"]));
            if (objJobInfo.JobId == 0) return;
            JobNumber.Text = objJobInfo.JobNumber;
            ClientName.Text = objJobInfo.Customer.CustName;
            customerAddress.Text = objJobInfo.Customer.Address;
            DeletReason.Text = objJobInfo.Comments;
            if (isViewOnly )
            switch (objJobInfo.Attention)
            {
                case 1:
                    dllAttention.Text = objJobInfo.Customer.Person1;
                    TelNo.Text = objJobInfo.Customer.Phone1;
                    FaxNo.Text = objJobInfo.Customer.Fax1;
                    Email.Text = objJobInfo.Customer.Email1;
                    HomePhone.Text = objJobInfo.Customer.HPhone1;
                    break;
                case 2:
                    dllAttention.Text = objJobInfo.Customer.Person2;
                    TelNo.Text = objJobInfo.Customer.Phone2;
                    FaxNo.Text = objJobInfo.Customer.Fax2;
                    Email.Text = objJobInfo.Customer.Email2;
                    HomePhone.Text = objJobInfo.Customer.HPhone2;
                    break;
                case 3:
                    dllAttention.Text = objJobInfo.Customer.Person3;
                    TelNo.Text = objJobInfo.Customer.Phone3;
                    FaxNo.Text = objJobInfo.Customer.Fax3;
                    Email.Text = objJobInfo.Customer.Email3;
                    HomePhone.Text = objJobInfo.Customer.HPhone3;
                    break;
            }
            JobDate.Text = objJobInfo.CreateDate.ToShortDateString();
            Validity.Text = (objJobInfo.Validatily - objJobInfo.CreateDate).Days.ToString();
            paymentDate.Text = (objJobInfo.TermOfPayment - objJobInfo.CreateDate).Days.ToString();
            RewardPoints.Text = objJobInfo.Customer.Reward.ToString();
            TextBox1.Text = objJobInfo.Reward.ToString();
            listJobDetail = Global.ObjJobController.CurrentJobDetailArchive(Int32.Parse(Page.Request.QueryString["qid"]));
          
            FillTestDeatilTable();
        }


        private void FillTestDeatilTable()
        {
            for (int i = 1; i < tblTestDeatil.Rows.Count; i++)
            {
                tblTestDeatil.Rows.RemoveAt(i);
            }
            var counter = 1;
            using (var row = new HtmlTableRow())
            {
                row.Cells.Add(new HtmlTableCell { InnerHtml = "&nbsp;", ColSpan = 5 });
                tblTestDeatil.Controls.Add(row);
            }

            foreach (JobDetailArchive objJobDetail in listJobDetail)
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
                        testDescriptation += string.Format("{0}sampls/week x 4 weeks/month = {1} samples/month <br /> <br />", objJobDetail.Frequency, (Int32.Parse(objJobDetail.Frequency) * 4));
                        row.Cells.Add(new HtmlTableCell { InnerHtml = testDescriptation, VAlign = "Top" });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.UnitPrice.ToString(), VAlign = "Top", Align = "right" });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Quantity + " samples", VAlign = "Top", Align = "center" });
                        row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.TotalAmount.ToString() + "&nbsp;&nbsp;", VAlign = "Top", Align = "Right" });
                    }
                    tblTestDeatil.Controls.Add(row);
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArchiveJobList.aspx");
        }
    }
}