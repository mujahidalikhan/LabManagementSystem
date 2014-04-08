using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;

namespace LMIS.Admin
{
    public partial class TestParmeterList : System.Web.UI.Page
    {
        private static List<TestParameterInfo> userList;
        static readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            AddParameterTable();
            if (IsPostBack)
                return;
            ViewState.Value = "New";
            ParamID.Value = "0";
        }

        private void AddParameterTable()
        {
            userList = objDbController.GetIndustryTestInfo();
            TestParmeterTable.Controls.Clear();
            TableRow tableRow = new TableHeaderRow
                                    {
                                        TableSection = TableRowSection.TableHeader,
                                        Height = System.Web.UI.WebControls.Unit.Pixel(20)
                                    };
            tableRow.Cells.Add(new TableHeaderCell
                                   {Text = " Test Parameter", Height = System.Web.UI.WebControls.Unit.Pixel(20)});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Short Term"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "MDL"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Unit"});
            tableRow.Cells.Add(new TableHeaderCell {Text = "Options"});
            TestParmeterTable.Rows.Add(tableRow);
            if (userList.Count <= 0) return;
            foreach (TestParameterInfo objSystemUsers in userList)
            {
                tableRow = new TableRow {TableSection = TableRowSection.TableBody};
                tableRow.Cells.Add(new TableCell {Text = objSystemUsers.AccreditedTestParameter});
                tableRow.Cells.Add(new TableCell {Text = objSystemUsers.ShortTerm});
                tableRow.Cells.Add(new TableCell {Text = objSystemUsers.MDL});
                tableRow.Cells.Add(new TableCell {Text = objSystemUsers.Unit});

                TableCell objtableCell = new TableCell();
                Image objeditiamge = new Image();
                objeditiamge.ImageUrl = "../images/icons/sidemenu/file_edit.png";
                Label objEditLabel = new Label();
                objEditLabel.Text = " ";
                LinkButton objEditButton  = new LinkButton();
                objEditButton.ID = "edit" + objSystemUsers.TestParameterId;
                objEditButton.Click += LinkButton1_Click;
                objEditButton.Text = "edit";
                objtableCell.Controls.Add(objeditiamge);
                objtableCell.Controls.Add(objEditButton);
                objtableCell.Controls.Add(objEditLabel);

               
                Image objdeleteimge = new Image();
                objdeleteimge.ImageUrl = "../images/icons/sidemenu/file_delete.png";
                Label objDeleteLabel = new Label();
                objDeleteLabel.Text = " ";
                LinkButton objDeleteButton = new LinkButton();
                objDeleteButton.ID = "delete" + objSystemUsers.TestParameterId;
                objDeleteButton.Click += LinkButton1_Click;
                objDeleteButton.Text = "delete";
                objtableCell.Controls.Add(objdeleteimge);
                objtableCell.Controls.Add(objDeleteButton);
                objtableCell.Controls.Add(objDeleteLabel);

               
                Image objviewimge = new Image();
                objviewimge.ImageUrl = "../images/icons/sidemenu/file.png";
                LinkButton objViewButton = new LinkButton();
                objViewButton.ID = "view" + objSystemUsers.TestParameterId;
                objViewButton.Click += LinkButton1_Click;
                objViewButton.Text = "view";
                objtableCell.Controls.Add(objviewimge);
                objtableCell.Controls.Add(objViewButton);
                tableRow.Cells.Add(objtableCell);
                TestParmeterTable.Rows.Add(tableRow);
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            if (ViewState.Value == "Edit")
            {
                TestParameterInfo objTestParameterInfo =
                    objDbController.GetTestParameterInfo(Convert.ToInt32(ParamID.Value));
                objTestParameterInfo.AccreditedTestParameter = AccreditedTestParameter.Text;
                objTestParameterInfo.TestMethod = TestMethod.Text;
                objTestParameterInfo.ShortTerm = ShortTerm.Text;
                objTestParameterInfo.Equipment = Equipment.Text;
                objTestParameterInfo.MDL = MDL.Text;
                objTestParameterInfo.Unit = Unit.Text;
                AccreditedTestParameter.Text = "";
                TestMethod.Text = "";
                ShortTerm.Text = "";
                Equipment.Text = "";
                MDL.Text = "";
                Unit.Text = "";
                Add.Text = "Add";
                objDbController.UpdateTestParameter(objTestParameterInfo);
                AddParameterTable();
            }
            else if (ViewState.Value == "New")
            {

                var objTestParameterInfo = new TestParameterInfo
                    {
                        AccreditedTestParameter = AccreditedTestParameter.Text,
                        TestMethod = TestMethod.Text,
                        ShortTerm = ShortTerm.Text,
                        Equipment = Equipment.Text,
                        MDL = MDL.Text,
                        Unit = Unit.Text
                    };

                
                if (!objDbController.IsTestParameterInfoExist(objTestParameterInfo.AccreditedTestParameter) )
                {
                    objDbController.AddSystemTestParameter(objTestParameterInfo);
                    AddParameterTable();
                }
               
                else
                {
                    ErrorMessage.Visible = true;
                    ErrorMessage.Text = "Test already exist ";
                    return;
                }




                AccreditedTestParameter.Text = "";
                TestMethod.Text = "";
                ShortTerm.Text = "";
                Equipment.Text = "";
                MDL.Text = "";
                Unit.Text = "";
                Add.Text = "Add";
                ViewState.Value = "New";
            }
            else if (ViewState.Value == "View")
            {

                AccreditedTestParameter.Text = "";
                TestMethod.Text = "";
                ShortTerm.Text = "";
                Equipment.Text = "";
                MDL.Text = "";
                Unit.Text = "";
                Add.Text = "Add";
                ViewState.Value = "New";
            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;
            
            TestParameterInfo objTestParameterInfo;
            if(clickedButton.ID.Contains("edit"))
            {
                ViewState.Value = "Edit";
                ParamID.Value = clickedButton.ID.Remove(0, 4);
                objTestParameterInfo = objDbController.GetTestParameterInfo(Convert.ToInt32(ParamID.Value));
                AccreditedTestParameter.Text = objTestParameterInfo.AccreditedTestParameter;
                TestMethod.Text = objTestParameterInfo.TestMethod;
                ShortTerm.Text = objTestParameterInfo.ShortTerm;
                Equipment.Text = objTestParameterInfo.Equipment;
                MDL.Text = objTestParameterInfo.MDL;
                Unit.Text = objTestParameterInfo.Unit;
                Add.Text = "Save";
            }
            else if (clickedButton.ID.Contains("delete"))
            {
                ViewState.Value = "Delete";
                ParamID.Value = clickedButton.ID.Remove(0, 6);
                objTestParameterInfo = objDbController.GetTestParameterInfo(Convert.ToInt32(ParamID.Value));
                objDbController.DeleteSystemTestParameterInfo(objTestParameterInfo.TestParameterId);
                AddParameterTable();
            }
            else if (clickedButton.ID.Contains("view"))
            {
                ViewState.Value = "View";
                ParamID.Value = clickedButton.ID.Remove(0, 4);
                objTestParameterInfo = objDbController.GetTestParameterInfo(Convert.ToInt32(ParamID.Value));
                AccreditedTestParameter.Text = objTestParameterInfo.AccreditedTestParameter;
                TestMethod.Text = objTestParameterInfo.TestMethod;
                ShortTerm.Text = objTestParameterInfo.ShortTerm;
                Equipment.Text = objTestParameterInfo.Equipment;
                MDL.Text = objTestParameterInfo.MDL;
                Unit.Text = objTestParameterInfo.Unit;
                Add.Text = "Close";
            }
            
        }
    }
}