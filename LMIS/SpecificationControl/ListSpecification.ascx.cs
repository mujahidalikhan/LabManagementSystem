using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;
namespace LMIS.SpecificationControl
{
    public partial class ListSpecification : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddSpecificationTable();
            if (IsPostBack)
                return;
            testParameterBox.Items.Clear();
            List<TestParameterInfo> listTestParameterInfo = Global.ObjDbController.GetTestInfo();

            foreach (TestParameterInfo objTestParameterInfo in listTestParameterInfo)
            {
                testParameterBox.Items.Add(new ListItem(objTestParameterInfo.AccreditedTestParameter, objTestParameterInfo.TestParameterId.ToString()));
            }
            testParameterBox.SelectedIndex = 0;
            ViewState.Value = "New";
            SpecID.Value = "0";
        }

        private void AddSpecificationTable()
        {
            SpecificationListTable.Controls.Clear();
            TableRow tablHeadereRow = new TableHeaderRow { TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20) };
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Specification", Height = Unit.Pixel(20) });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Test Parameter", Height = Unit.Pixel(20) });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "StdA" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "StdB" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Others" });
            tablHeadereRow.Cells.Add(new TableHeaderCell { Text = "Options", Width = 125 });
            SpecificationListTable.Rows.Add(tablHeadereRow);

            if (Page.Request.QueryString["spn"] == null)
                return;
            List<Specification> SpecificationList = SpecificationController.GetSpecification1();


           
            if (SpecificationList.Count > 0)
            {
                foreach (var objSpecification in SpecificationList)
                {
                    using (var tableBodyRow = new TableRow { TableSection = TableRowSection.TableBody })
                    {
                        tableBodyRow.Cells.Add(new TableCell { Text = objSpecification.SpecificationName });
                        tableBodyRow.Cells.Add(new TableCell { Text = objSpecification.TestId.AccreditedTestParameter });
                        tableBodyRow.Cells.Add(new TableCell { Text = objSpecification.StdA });
                        tableBodyRow.Cells.Add(new TableCell { Text = objSpecification.StdB });
                        tableBodyRow.Cells.Add(new TableCell { Text = objSpecification.Others });


                        TableCell objtableCell = new TableCell();
                        Image objeditiamge = new Image();
                        objeditiamge.ImageUrl = "../images/icons/sidemenu/file_edit.png";
                        Label objEditLabel = new Label();
                        objEditLabel.Text = " ";
                        LinkButton objEditButton = new LinkButton();
                        objEditButton.ID = "edit" + objSpecification.SpecificationId;
                        objEditButton.Click += LinkButton1_Click;
                        objEditButton.Text = "edit";
                        objtableCell.Controls.Add(objeditiamge);
                        objtableCell.Controls.Add(objEditButton);
                        objtableCell.Controls.Add(objEditLabel);

                        Image objdeleteimge = new Image();
                        objdeleteimge.ImageUrl = "../images/icons/sidemenu/file_delete.png";
                        LinkButton objDeleteButton = new LinkButton();
                        objDeleteButton.ID = "delete" + objSpecification.SpecificationId;
                        objDeleteButton.Click += LinkButton1_Click;
                        objDeleteButton.Text = "delete";
                        objtableCell.Controls.Add(objdeleteimge);
                        objtableCell.Controls.Add(objDeleteButton);

                        tableBodyRow.Cells.Add(objtableCell);
                        SpecificationListTable.Rows.Add(tableBodyRow);
                    }

                }
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            ErrorMessage.Visible =false;
            if (ViewState.Value == "Edit")
            {
                Specification objSpecification = SpecificationController.GetSpecification1(Int32.Parse(SpecID.Value));
                objSpecification.SpecificationId = objSpecification.SpecificationId;
                objSpecification.SpecificationName = SpecificationName.Text;
                objSpecification.StdA = stdA.Text;
                objSpecification.StdB = stdB.Text;
                objSpecification.Others = others.Text;
                objSpecification.TestId =
                    Global.ObjDbController.GetTestParameterInfo(Int32.Parse(testParameterBox.SelectedValue));
                SpecificationName.Text = "";
                stdA.Text = "";
                stdB.Text = "";
                others.Text = "";
                Add.Text = "Add";
                testParameterBox.SelectedIndex = 0;
                SpecificationController.UpdateSpecification1(objSpecification);
              
                ViewState.Value = "New";
            }
            else
            {
                Specification objSpecification = new Specification()
                    {
                        SpecificationName = SpecificationName.Text,
                        TestId = Global.ObjDbController.GetTestParameterInfo(Int32.Parse(testParameterBox.SelectedValue)),
                        StdA = stdA.Text ,
                        StdB = stdB.Text,
                        Others = others.Text, 
                    };

                if (SpecificationController.IsSpecificationExist(objSpecification.SpecificationName,
                                                                 objSpecification.TestId.TestParameterId))
                {
                    ErrorMessage.Visible = true;
                    return;
                }
                SpecificationController.AddSpecification1(objSpecification);
              

            }
            AddSpecificationTable();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

        }

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;

            Specification objSpecification;
            if (clickedButton.ID.Contains("edit"))
            {
                ViewState.Value = "Edit";
                SpecID.Value = clickedButton.ID.Remove(0, 4);
                objSpecification = SpecificationController.GetSpecification1(Int32.Parse(SpecID.Value));
                SpecificationName.Text = objSpecification.SpecificationName.ToString();
                testParameterBox.SelectedValue = objSpecification.TestId.TestParameterId.ToString();
                stdA.Text = objSpecification.StdA;
                stdB.Text = objSpecification.StdB;
                others.Text = objSpecification.Others;
                Add.Text = "Save";
            }
            else if (clickedButton.ID.Contains("delete"))
            {
                ViewState.Value = "Delete";
                SpecID.Value = clickedButton.ID.Remove(0, 6);
                objSpecification = SpecificationController.GetSpecification1(Int32.Parse(SpecID.Value));
                SpecificationController.DeleteSpecification1(objSpecification.SpecificationId);
                AddSpecificationTable();
            }

        }
    }
}