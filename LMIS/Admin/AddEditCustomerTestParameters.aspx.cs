using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;


namespace LMIS.Admin
{

    public partial class AddEditCustomerTestParameters : System.Web.UI.Page
    {
        private static readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FillTestParameterTable();

            IndustryList.Items.Clear();
            var list = objDbController.GetIndustryInfo();
            foreach (var industryInfo in list)
            {
                var li = new ListItem { Text = industryInfo.IndustryName, Value = industryInfo.IndustryID.ToString() };
                IndustryList.Items.Add(li);
            }

            if (list.Count > 0)
            {
                IndustryList.Items[0].Selected = true;
                UpdateTestList();

            }
        }



        private void FillTestParameterTable()
        {
            List<CustomerTestParameters> listCustomerTestParameters =
                objDbController.GetCustomerTestParameters(Int32.Parse(Page.Request.QueryString["custId"]));
           
            foreach (var customerTestParameter in listCustomerTestParameters)
            {
                try{
                    using (var row = new HtmlTableRow())
                    {

                        row.Cells.Add(new HtmlTableCell
                                          {
                                              InnerHtml =
                                                  objDbController.GetIndustryInfo(
                                                      customerTestParameter.IndustyID).IndustryName

                                          });

                        row.Cells.Add(new HtmlTableCell
                                          {
                                              InnerHtml =
                                                  objDbController.GetTestParameterInfo(
                                                      customerTestParameter.TestParametersId).
                                                  AccreditedTestParameter
                                          });

                        var rb = new RadioButton
                                     {
                                         GroupName = customerTestParameter.CustomerTestParameterId.ToString(),
                                         ID = "StdA" + customerTestParameter.CustomerTestParameterId,
                                         Text = "",
                                         Checked = customerTestParameter.StdA,
                                         ToolTip = spcType.SelectedItem.Text
                                     };

                        using (var tableCell2 = new HtmlTableCell())
                        {
                            tableCell2.Controls.Add(rb);
                            row.Cells.Add(tableCell2);
                        }


                        var rb1 = new RadioButton
                                      {
                                          ID = "StdB" + customerTestParameter.CustomerTestParameterId.ToString(),
                                          Text = "",
                                          GroupName = customerTestParameter.CustomerTestParameterId.ToString(),
                                          Checked = customerTestParameter.StdB,
                                          ToolTip = spcType.SelectedItem.Text
                                      };
                        var tableCell3 = new HtmlTableCell();
                        tableCell3.Controls.Add(rb1);
                        row.Cells.Add(tableCell3);

                        RadioButton rb2 = new RadioButton
                                              {
                                                  Text = "",
                                                  GroupName = customerTestParameter.CustomerTestParameterId.ToString(),
                                                  Checked = customerTestParameter.DefaultVal,
                                                  ID = "Default" + customerTestParameter.CustomerTestParameterId,
                                                  ToolTip = spcType.SelectedItem.Text
                                              };

                        var tableCell4 = new HtmlTableCell();
                        tableCell4.Controls.Add(rb2);
                        row.Cells.Add(tableCell4);



                        row.Cells.Add(new HtmlTableCell
                                          {
                                              InnerHtml =
                                                  String.Format(
                                                      "<a href=\"DeleteCustomerTestParameters.aspx?ctpId={0}&custId={1}\" title=\"Delete\" class=\"icon-2 info-tooltip\"><img src='../images/icons/sidemenu/file_delete.png' width='16' height='16' alt='icon' />Delete</a>",
                                                      customerTestParameter.CustomerTestParameterId,
                                                      customerTestParameter.CustomerId)
                                          });


                        TestParametersTable.Rows.Add(row);
                    }
                   
                }
                catch (Exception ex)
                {

                }
            }
        }



        protected void addTestParameters_Click1(object sender, EventArgs e)
        {
            if (IndustryList.Items.Count == 0 || IndustryList.SelectedValue == "0")
            {
                lblErrorMessage.Visible = true;
                return;
            }
            if (testList.Items.Count == 0 || testList.SelectedValue == "0")
            {
                lblErrorMessage.Visible = true;
                return;
            }
             if (spcType.Items.Count == 0 || spcType.SelectedValue == "0")
             {
                 lblErrorMessage.Visible = true;
                 return;
             }
            
            objDbController.AddCustomerTestParameters(Int32.Parse(Page.Request.QueryString["custId"]), Int32.Parse(testList.SelectedItem.Value),
                                                      spcType.SelectedItem.Text, stdA.Checked, stdB.Checked, defaultVal.Checked, Int32.Parse(IndustryList.SelectedValue));
            FillTestParameterTable();

        }

        protected void testList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSpec();
            FillTestParameterTable();
        }

        private void FillSpec()
        {
            spcType.Items.Clear();

            if (testList.SelectedItem == null)
                return;
            spcType.Items.Add(new ListItem() {Text = "Default", Value = "0"});

            //if (SpecificationController.GetSpecification1byParameter(testList.SelectedItem.Text).Count > 0)
            //{
            //    spcType.Items.Add(new ListItem() {Text = "Specification 1", Value = "1"});
            //}
           
        }

        protected void IndustryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTestList();
            FillTestParameterTable();
            FillSpec();
        }

        private void UpdateTestList()
        {
            testList.Items.Clear();
            List<TestParameterInfo> objListTestParameterInfo =
                objDbController.GetIndustryTestInfo(Int32.Parse(IndustryList.SelectedItem.Value));

            if (objListTestParameterInfo.Count == 0)
            {
               HttpContext.Current.Response.Write(
                    "<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"The Specification does not have associated test\")</SCRIPT>");
                addTestParameters.Enabled = false;
                return;
            }
            addTestParameters.Enabled = true;
            foreach (var testParameterInfo in objListTestParameterInfo)
            {
                ListItem li = new ListItem();
                li.Text = testParameterInfo.AccreditedTestParameter;
                li.Value = testParameterInfo.TestParameterId.ToString();
                testList.Items.Add(li);
            }
            FillSpec();
           
        }
    }
}
