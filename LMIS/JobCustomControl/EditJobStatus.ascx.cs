using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.JobCustomControl
{
    public partial class EditJobStatus : System.Web.UI.UserControl
    {
        private  JobInfo objJobInfo;
        private  List<JobDetail> listJobDetail;
        private  decimal JobTotal;
        private  decimal rewarDiscount;
        private  decimal finalTotal;
        private  decimal MicItemsCostval;
        private  int appliedRewardPoints;
        private  decimal rewardRate;
        private  readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    FillTestDeatilTable();
                }
                catch (Exception)
                {


                }
                return;

            }
            objJobInfo = Global.ObjJobController.GetJobInfo(Int32.Parse(Page.Request.QueryString["qid"]));
            if (objJobInfo.JobId != 0)
            {
                JobNumber.Text = objJobInfo.JobNumber;
                ClientName.Text = objJobInfo.Customer.CustName;
                customerAddress.Text = objJobInfo.Customer.Address;


                switch (objJobInfo.Attention)
                {
                    case 1:
                        dllAttention.Text = objJobInfo.Customer.Person1;
                        TelNo.Text = objJobInfo.Customer.Phone1;
                        FaxNo.Text = objJobInfo.Customer.Fax1;
                        Email.Text = objJobInfo.Customer.Email1;
                        break;
                    case 2:
                        dllAttention.Text = objJobInfo.Customer.Person2;
                        TelNo.Text = objJobInfo.Customer.Phone2;
                        FaxNo.Text = objJobInfo.Customer.Fax2;
                        Email.Text = objJobInfo.Customer.Email2;
                        break;
                    case 3:
                        dllAttention.Text = objJobInfo.Customer.Person3;
                        TelNo.Text = objJobInfo.Customer.Phone3;
                        FaxNo.Text = objJobInfo.Customer.Fax3;
                        Email.Text = objJobInfo.Customer.Email3;
                        break;
                }
                JobDate.Text = objJobInfo.CreateDate.ToShortDateString();
                Validity.Text = (objJobInfo.Validatily - objJobInfo.CreateDate).Days.ToString();
                paymentDate.Text = (objJobInfo.TermOfPayment - objJobInfo.CreateDate).Days.ToString();
                RewardPoints.Text = objJobInfo.Customer.Reward.ToString();
                TextBox1.Text = objJobInfo.Reward.ToString();
                listJobDetail = Global.ObjJobController.CurrentJobDetail(Int32.Parse(Page.Request.QueryString["qid"]));
               
                FillTestDeatilTable();
                JobTotal = objJobInfo.TotalAmount;
                finalTotal = JobTotal - rewarDiscount;
                if (rewardRate <= 0)
                    rewardRate = 100000000;
            }

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

                row.Cells.Add(new HtmlTableCell { InnerHtml = "&nbsp;", ColSpan = 6 });
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
                        row.Cells.Add(new HtmlTableCell
                        {
                            InnerHtml = String.Format(
                                "<a href=\"AddEditJobTestInfo.aspx?qid={0}&qdid={1}&actionType=ED\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a> " +
                                " <a href=\"DeleteQDetail.aspx?qid={0}&qdid={1}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>" +
                                " <a href=\"AddEditJobTestInfo.aspx?qid={0}&qdid={1}&actionType=AT\" title=\"Add New Tests\" class=\"icon-3 info-tooltip\"><img src='../images/icons/sidemenu/file_add.png' width='16' height='16' alt='icon' />Add</a>",
                                objJobInfo.JobId, objJobDetail.JobDetailId)
                        });
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
                       
                        row.Cells.Add(new HtmlTableCell { InnerHtml = objJobDetail.Quantity + " samples", VAlign = "Top", Align = "center" });
                      

                        row.Cells.Add(new HtmlTableCell
                        {
                            InnerHtml = String.Format(
                                "<a href=\"AddEditJobTestInfo.aspx?qid={0}&qdid={1}&actionType=ET\" title=\"Edit\" class=\"icon-1 info-tooltip\"><img src='../images/icons/sidemenu/file_edit.png' width='16' height='16' alt='icon' />Edit </a> " +
                                " <a href=\"DeleteQDetail.aspx?qid={0}&qdid={1}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                                objJobInfo.JobId, objJobDetail.JobDetailId),
                            VAlign = "top"
                        });


                    }

                    tblTestDeatil.Controls.Add(row);


                }


            }

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session["ActionType"] = "Print";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", string.Format("<script language=javascript>window.open('PrintJob.aspx?qid={0}','PrintMe','height=300px,width=300px,scrollbars=1');</script>", Page.Request.QueryString["qid"]));
     
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobList.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var reward = Int32.Parse(TextBox1.Text);
            RewardPoints.Text = (Int32.Parse(RewardPoints.Text) - reward).ToString();
            objJobInfo.Reward = reward;
            objJobInfo.Payable = finalTotal;
            objJobInfo.RewardValue = rewarDiscount;
            objJobInfo.RewardPoint = appliedRewardPoints;
            objJobInfo.TotalAmount = JobTotal;
            objJobInfo.MicItemsCost = MicItemsCostval;
            objJobInfo.Customer.Reward -= appliedRewardPoints;
            objDbController.UpdateCustomer(objJobInfo.Customer);
           
            Global.ObjJobController.UpdateJobInfo(objJobInfo);
            Response.Redirect("JobList.aspx");
        }



        protected void MicItemsCost_TextChanged(object sender, EventArgs e)
        {
            while (true)
            {
                try
                {
                   
                    rewarDiscount = (decimal.Parse(TextBox1.Text) / rewardRate);
                    finalTotal = (JobTotal + MicItemsCostval) - rewarDiscount;
                    appliedRewardPoints = Int32.Parse(TextBox1.Text);
                 
                    return;
                }
                catch (Exception)
                {
                   

                }
            }
        }
    }
}