using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LMIS.DBController;
using LMIS.DBModel;
using System.Web.UI.HtmlControls;

namespace LMIS.Admin
{
    public partial class AddEditClient : System.Web.UI.Page
    {
        private static List<ContactInfo> _contactInfo = new List<ContactInfo>();
        private static List<PointsInfo> _pointsInfo = new List<PointsInfo>();
        private static List<ContactInfo> _newContactInfo = new List<ContactInfo>();
        private static List<PointsInfo> _newPointsInfo = new List<PointsInfo>();
        static readonly DbController objDbController = new DbController();
        private CustomerInfo objCustomerInfo;
        private int _customerId;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.Request.QueryString.Count > 0 && !IsPostBack)
                {
                    objCustomerInfo = objDbController.GetCustomerInfo(Int32.Parse(Page.Request.QueryString["custId"]));
                    ClientName.Text = objCustomerInfo.CustName;
                    var splitAddress = objCustomerInfo.Address.Split('`');
                    Address1.Text = splitAddress[0];
                    if (splitAddress.Length > 1)
                        Address2.Text = splitAddress[1];
                    City.Text = objCustomerInfo.City;
                    State2.Text = objCustomerInfo.State;
                    postal.Text = objCustomerInfo.Poscode.ToString();
                    Salutation.Text = objCustomerInfo.Salutation1;
                    Name.Text = objCustomerInfo.Person1;
                    Position.Text = objCustomerInfo.Position1;
                    OfficePhone.Text = objCustomerInfo.Phone1;
                    HomePhone.Text = objCustomerInfo.HPhone1;
                    Fax.Text = objCustomerInfo.Fax1;
                    Email.Text = objCustomerInfo.Email1;
                    Country.SelectedValue = objCustomerInfo.Country;
                    _newContactInfo.Clear();
                    _newPointsInfo.Clear();
                    
                }
                else
                {
                    _contactInfo.Clear();
                    _pointsInfo.Clear();
                }
                AddContactTable();
                AddPointsTable();
            }
            catch (Exception)
            {
                ExceptionError.Visible = true;
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(ClientName.Text))
                {
                    NameError.Visible = true;
                    Page.SetFocus(ClientName);
                    ClientName.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(Address1.Text))
                {
                    AddressError.Visible = true;
                    Page.SetFocus(Address1);
                    Address1.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(City.Text))
                {
                    CityError.Visible = true;
                    Page.SetFocus(City);
                    City.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(State2.Text))
                {
                    StateError.Visible = true;
                    Page.SetFocus(State2);
                    State2.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(postal.Text))
                {
                    PostalError.Visible = true;
                    Page.SetFocus(postal);
                    postal.CssClass = "st-error-input";
                    return;
                }
                if (ContactListTable.Rows.Count == 0)
                {
                    ContactError.Visible = true;
                    Page.SetFocus(Salutation);
                    return;
                }
                if (PointsTable.Rows.Count == 0)
                {
                    PointNameError.Visible = true;
                    Page.SetFocus(PointName);
                    return;
                }
                objCustomerInfo = new CustomerInfo();
                if (!String.IsNullOrEmpty(ClientName.Text))
                    objCustomerInfo.CustName = ClientName.Text;
                if (!String.IsNullOrEmpty(Address1.Text))
                    objCustomerInfo.Address = Address1.Text + "`" + Address2.Text;
                if (!String.IsNullOrEmpty(City.Text))
                    objCustomerInfo.City = City.Text;
                if (!String.IsNullOrEmpty(State2.Text))
                    objCustomerInfo.State = State2.Text;
                if (!String.IsNullOrEmpty(postal.Text))
                    objCustomerInfo.Poscode = long.Parse(postal.Text);
                objCustomerInfo.Member_Since = DateTime.Now;
                objCustomerInfo.Country = Country.SelectedValue;
                if (Page.Request.QueryString.Count > 0)
                {
                    objCustomerInfo.CustID = Int32.Parse(Page.Request.QueryString["custId"]);
                    objDbController.UpdateCustomer(objCustomerInfo);
                }
                else
                {
                    objCustomerInfo.Reward = 200;
                    _customerId = objDbController.AddCustomer(objCustomerInfo);
                }

                if (Page.Request.QueryString.Count > 0)
                {
                    foreach (var objContactInfo in _contactInfo)
                    {
                        objContactInfo.CustID = Int32.Parse(Page.Request.QueryString["custId"]);
                        objDbController.UpdateContact(objContactInfo);
                    }
                    foreach (var objNewContactInfo in _newContactInfo)
                    {
                        objNewContactInfo.CustID = Int32.Parse(Page.Request.QueryString["custId"]);
                        objDbController.AddContact(objNewContactInfo);
                    }
                }
                else
                {
                    foreach (var objNewContactInfo in _newContactInfo)
                    {
                        objNewContactInfo.CustID = _customerId;
                        objDbController.AddContact(objNewContactInfo);
                    }
                }

                if (Page.Request.QueryString.Count > 0)
                {
                    foreach (var objPointsInfo in _pointsInfo)
                    {
                        objPointsInfo.CustID = Int32.Parse(Page.Request.QueryString["custId"]);
                        objDbController.UpdatePoints(objPointsInfo);
                    }
                    foreach (var objNewPointsInfo in _newPointsInfo)
                    {
                        objNewPointsInfo.CustID = Int32.Parse(Page.Request.QueryString["custId"]);
                        objDbController.AddPoints(objNewPointsInfo);
                    }
                }
                else
                {
                    foreach (var objNewPointsInfo in _newPointsInfo)
                    {
                        objNewPointsInfo.CustID = _customerId;
                        objDbController.AddPoints(objNewPointsInfo);
                    }
                }
                Response.Redirect("ClientList.aspx");
            }
            catch (Exception ex)
            {
                ExceptionError.Visible = true;
            }
            
        }

        protected void ButtonAddMore_Click(object sender, EventArgs e)
        {
            ClearContactFields();
            ButtonSave.Visible = true;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Name.Text))
                {
                    ClientNameError.Visible = true;
                    Page.SetFocus(Name);
                    Name.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(Position.Text))
                {
                    PositionError.Visible = true;
                    Page.SetFocus(Position);
                    Position.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(OfficePhone.Text))
                {
                    OfficePhoneError.Visible = true;
                    Page.SetFocus(OfficePhone);
                    OfficePhone.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(HomePhone.Text))
                {
                    HomePhoneError.Visible = true;
                    Page.SetFocus(HomePhone);
                    HomePhone.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(Fax.Text))
                {
                    FaxError.Visible = true;
                    Page.SetFocus(Fax);
                    Fax.CssClass = "st-error-input";
                    return;
                }
                if (String.IsNullOrEmpty(Email.Text))
                {
                    EmailError.Visible = true;
                    Page.SetFocus(Email);
                    Email.CssClass = "st-error-input";
                    return;
                }

                if (isEditContact.Value == "true")
                {
                    ContactInfo objContact = objDbController.GetContactInfoById(Int32.Parse(ContactID.Value));
                    objContact.Id = Int32.Parse(ContactID.Value);
                    objContact.Salutation = Salutation.Text;
                    objContact.Name = Name.Text;
                    objContact.Position = Position.Text;
                    objContact.Phone = OfficePhone.Text;
                    objContact.HPhone = HomePhone.Text;
                    objContact.Fax = Fax.Text;
                    objContact.Email = Email.Text;
                    objDbController.UpdateContact(objContact);
                    AddContactTable();
                    ClearContactFields();
                    ButtonSave.Visible = false;
                    return;
                }
                if (isEditNewContact.Value == "true")
                {
                    ContactInfo objContact = _newContactInfo[Int32.Parse(ContactID.Value)];
                    objContact.Id = Int32.Parse(ContactID.Value);
                    objContact.Salutation = Salutation.Text;
                    objContact.Name = Name.Text;
                    objContact.Position = Position.Text;
                    objContact.Phone = OfficePhone.Text;
                    objContact.HPhone = HomePhone.Text;
                    objContact.Fax = Fax.Text;
                    objContact.Email = Email.Text;
                    AddContactTable();
                    ClearContactFields();
                    ButtonSave.Visible = false;
                    return;
                }

                ContactInfo objContactInfo = new ContactInfo();
                objContactInfo.Salutation = Salutation.Text;
                objContactInfo.Name = Name.Text;
                objContactInfo.Position = Position.Text;
                objContactInfo.Phone = OfficePhone.Text;
                objContactInfo.HPhone = HomePhone.Text;
                objContactInfo.Fax = Fax.Text;
                objContactInfo.Email = Email.Text;
                _newContactInfo.Add(objContactInfo);
                AddContactTable();
                ButtonSave.Visible = false;
            }
            catch (Exception)
            {
                ExceptionError.Visible = true;
            }
        }

        private void AddContactTable()
        {
            try
            {

                if (Page.Request.QueryString.Count > 0)
                {
                    ContactInfo objContactInfo = new ContactInfo();
                    _contactInfo =
                        objDbController.GetCusotmerContactInfo(Int32.Parse(Page.Request.QueryString["custId"]));
                }
                if (_contactInfo.Count == 0 && _newContactInfo.Count == 0)
                {
                    ContactListTable.Rows.Clear();
                    return;
                }

                ContactListTable.Controls.Clear();
                TableRow tableRow = new TableHeaderRow
                                        {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
                tableRow.Cells.Add(new TableHeaderCell {Text = "Salutation"});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Name"});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Position"});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Office Phone"});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Home Phone"});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Fax"});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Email"});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Options", Width = 150});
                ContactListTable.Rows.Add(tableRow);
                int contactID = 0;
                foreach (var objContact in _contactInfo)
                {
                    using (var row = new TableRow())
                    {
                        row.Cells.Add(new TableCell {Text = objContact.Salutation});
                        row.Cells.Add(new TableCell {Text = objContact.Name});
                        row.Cells.Add(new TableCell {Text = objContact.Position});
                        row.Cells.Add(new TableCell {Text = objContact.Phone});
                        row.Cells.Add(new TableCell {Text = objContact.HPhone});
                        row.Cells.Add(new TableCell {Text = objContact.Fax});
                        row.Cells.Add(new TableCell {Text = objContact.Email});

                        TableCell objtableCell = new TableCell();
                        Image objeditiamge = new Image();
                        objeditiamge.ImageUrl = "../images/icons/sidemenu/file_edit.png";
                        Label objEditLabel = new Label();
                        objEditLabel.Text = " ";
                        LinkButton objEditButton = new LinkButton();
                        objEditButton.CausesValidation = false;
                        objEditButton.ID = "editContact" + contactID;
                        objEditButton.Click += LinkButton1_Click;
                        objEditButton.Text = "edit";
                        objtableCell.Controls.Add(objeditiamge);
                        objtableCell.Controls.Add(objEditButton);
                        objtableCell.Controls.Add(objEditLabel);

                        Image objdeleteimge = new Image();
                        objdeleteimge.ImageUrl = "../images/icons/sidemenu/file_delete.png";
                        LinkButton objDeleteButton = new LinkButton();
                        objDeleteButton.CausesValidation = false;
                        objDeleteButton.ID = "deleteContact" + contactID;
                        objDeleteButton.Click += LinkButton1_Click;
                        objDeleteButton.Text = "delete";
                        objtableCell.Controls.Add(objdeleteimge);
                        objtableCell.Controls.Add(objDeleteButton);

                        row.Cells.Add(objtableCell);

                        ContactListTable.Rows.Add(row);
                    }
                    contactID++;
                }
                contactID = 0;
                foreach (var objNewContact in _newContactInfo)
                {
                    using (var row = new TableRow())
                    {
                        row.Cells.Add(new TableCell {Text = objNewContact.Salutation});
                        row.Cells.Add(new TableCell {Text = objNewContact.Name});
                        row.Cells.Add(new TableCell {Text = objNewContact.Position});
                        row.Cells.Add(new TableCell {Text = objNewContact.Phone});
                        row.Cells.Add(new TableCell {Text = objNewContact.HPhone});
                        row.Cells.Add(new TableCell {Text = objNewContact.Fax});
                        row.Cells.Add(new TableCell {Text = objNewContact.Email});

                        TableCell objtableCell = new TableCell();
                        Image objeditiamge = new Image();
                        objeditiamge.ImageUrl = "../images/icons/sidemenu/file_edit.png";
                        Label objEditLabel = new Label();
                        objEditLabel.Text = " ";
                        LinkButton objEditButton = new LinkButton();
                        objEditButton.CausesValidation = false;
                        objEditButton.ID = "editNewContact" + contactID;
                        objEditButton.Click += LinkButton1_Click;
                        objEditButton.Text = "edit";
                        objtableCell.Controls.Add(objeditiamge);
                        objtableCell.Controls.Add(objEditButton);
                        objtableCell.Controls.Add(objEditLabel);

                        Image objdeleteimge = new Image();
                        objdeleteimge.ImageUrl = "../images/icons/sidemenu/file_delete.png";
                        LinkButton objDeleteButton = new LinkButton();
                        objDeleteButton.CausesValidation = false;
                        objDeleteButton.ID = "deleteNewContact" + objNewContact.Id;
                        objDeleteButton.Click += LinkButton1_Click;
                        objDeleteButton.Text = "delete";
                        objtableCell.Controls.Add(objdeleteimge);
                        objtableCell.Controls.Add(objDeleteButton);
                        row.Cells.Add(objtableCell);
                        ContactListTable.Rows.Add(row);
                    }
                    contactID++;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void AddPoints_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(PointName.Text))
                    return;

                if (isEditPoint.Value == "true")
                {
                    PointsInfo objPoint = objDbController.GetPointById(Int32.Parse(PointID.Value));
                    objPoint.Id = Int32.Parse(PointID.Value);
                    objPoint.Points = PointName.Text;
                    objDbController.UpdatePoints(objPoint);
                    AddPointsTable();
                    PointName.Text = "";
                    return;
                }
                if (isEditNewPoint.Value == "true")
                {
                    PointsInfo objPoint = _newPointsInfo[Int32.Parse(PointID.Value)];
                    objPoint.Id = Int32.Parse(PointID.Value);
                    objPoint.Points = PointName.Text;
                    AddPointsTable();
                    PointName.Text = "";
                    return;
                }

                PointsInfo objPointsInfo = new PointsInfo();
                objPointsInfo.Points = PointName.Text;
                _newPointsInfo.Add(objPointsInfo);
                AddPointsTable();
            }
            catch (Exception ex)
            {
                ExceptionError.Visible = true;
            }
            PointName.Text = "";
        }

        private void AddPointsTable()
        {
            try
            {
                if (Page.Request.QueryString.Count > 0)
                {
                    PointsInfo objPointsInfo = new PointsInfo();
                    _pointsInfo = objDbController.GetPoints(Int32.Parse(Page.Request.QueryString["custId"]));
                }
                if (_pointsInfo.Count == 0 && _newPointsInfo.Count == 0)
                {
                    PointsTable.Rows.Clear();
                    return;
                }

                TableRow tableRow = new TableHeaderRow
                                        {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
                PointsTable.Controls.Clear();
                tableRow = new TableHeaderRow {TableSection = TableRowSection.TableHeader, Height = Unit.Pixel(20)};
                tableRow.Cells.Add(new TableHeaderCell {Text = "Points", Height = Unit.Pixel(20)});
                tableRow.Cells.Add(new TableHeaderCell {Text = "Options", Width = 220});
                PointsTable.Rows.Add(tableRow);
                int pointID = 0;
                foreach (var objPoint in _pointsInfo)
                {
                    using (var row = new TableRow())
                    {
                        row.Cells.Add(new TableCell {Text = objPoint.Points.ToString()});

                        TableCell objtableCell = new TableCell();
                        Image objeditiamge = new Image();
                        objeditiamge.ImageUrl = "../images/icons/sidemenu/file_edit.png";
                        Label objEditLabel = new Label();
                        objEditLabel.Text = " ";
                        LinkButton objEditButton = new LinkButton();
                        objEditButton.CausesValidation = false;
                        objEditButton.ID = "editPoint" + pointID;
                        objEditButton.Click += LinkButton1_Click;
                        objEditButton.Text = "edit";
                        objtableCell.Controls.Add(objeditiamge);
                        objtableCell.Controls.Add(objEditButton);
                        objtableCell.Controls.Add(objEditLabel);

                        Image objdeleteimge = new Image();
                        objdeleteimge.ImageUrl = "../images/icons/sidemenu/file_delete.png";
                        LinkButton objDeleteButton = new LinkButton();
                        objDeleteButton.CausesValidation = false;
                        objDeleteButton.ID = "deletePoint" + pointID;
                        objDeleteButton.Click += LinkButton1_Click;
                        objDeleteButton.Text = "delete";
                        objtableCell.Controls.Add(objdeleteimge);
                        objtableCell.Controls.Add(objDeleteButton);

                        row.Cells.Add(objtableCell);

                        PointsTable.Rows.Add(row);
                    }
                    pointID++;
                }
                pointID = 0;
                foreach (var objNewPoint in _newPointsInfo)
                {
                    using (var row = new TableRow())
                    {
                        row.Cells.Add(new TableCell {Text = objNewPoint.Points.ToString()});
                        TableCell objtableCell = new TableCell();
                        Image objeditiamge = new Image();
                        objeditiamge.ImageUrl = "../images/icons/sidemenu/file_edit.png";
                        Label objEditLabel = new Label();
                        objEditLabel.Text = " ";
                        LinkButton objEditButton = new LinkButton();
                        objEditButton.CausesValidation = false;
                        objEditButton.ID = "editNewPoint" + pointID;
                        objEditButton.Click += LinkButton1_Click;
                        objEditButton.Text = "edit";
                        objtableCell.Controls.Add(objeditiamge);
                        objtableCell.Controls.Add(objEditButton);
                        objtableCell.Controls.Add(objEditLabel);

                        Image objdeleteimge = new Image();
                        objdeleteimge.ImageUrl = "../images/icons/sidemenu/file_delete.png";
                        LinkButton objDeleteButton = new LinkButton();
                        objDeleteButton.CausesValidation = false;
                        objDeleteButton.ID = "deleteNewPoint" + pointID;
                        objDeleteButton.Click += LinkButton1_Click;
                        objDeleteButton.Text = "delete";
                        objtableCell.Controls.Add(objdeleteimge);
                        objtableCell.Controls.Add(objDeleteButton);

                        row.Cells.Add(objtableCell);

                        PointsTable.Rows.Add(row);
                    }
                    pointID++;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton clickedButton = (LinkButton) sender;
                if (clickedButton.ID.ToLower().Contains("edit"))
                {
                    if (clickedButton.ID.ToLower().Contains("contact"))
                    {
                        if (clickedButton.ID.ToLower().Contains("new"))
                        {
                            ContactID.Value = clickedButton.ID.Remove(0, 14);
                            ContactInfo objContact = _newContactInfo[Int32.Parse(ContactID.Value)];
                            Salutation.Text = objContact.Salutation;
                            Name.Text = objContact.Name;
                            Position.Text = objContact.Position;
                            OfficePhone.Text = objContact.Phone;
                            HomePhone.Text = objContact.HPhone;
                            Fax.Text = objContact.Fax;
                            Email.Text = objContact.Email;
                            ButtonSave.Visible = true;

                            isEditNewPoint.Value = "false";
                            isEditPoint.Value = "false";
                            isEditContact.Value = "false";
                            isEditNewContact.Value = "true";
                        }
                        else
                        {
                            ContactID.Value = clickedButton.ID.Remove(0, 11);
                            ContactInfo objContact = objDbController.GetContactInfoById(Int32.Parse(ContactID.Value));
                            Salutation.Text = objContact.Salutation;
                            Name.Text = objContact.Name;
                            Position.Text = objContact.Position;
                            OfficePhone.Text = objContact.Phone;
                            HomePhone.Text = objContact.HPhone;
                            Fax.Text = objContact.Fax;
                            Email.Text = objContact.Email;
                            ButtonSave.Visible = true;

                            isEditNewPoint.Value = "false";
                            isEditPoint.Value = "false";
                            isEditContact.Value = "true";
                            isEditNewContact.Value = "false";
                        }
                    }
                    if (clickedButton.ID.ToLower().Contains("point"))
                    {
                        if (clickedButton.ID.ToLower().Contains("new"))
                        {
                            PointID.Value = clickedButton.ID.Remove(0, 12);
                            PointsInfo objPoint = _newPointsInfo[Int32.Parse(PointID.Value)];
                            PointName.Text = objPoint.Points;

                            isEditNewPoint.Value = "true";
                            isEditPoint.Value = "false";
                            isEditContact.Value = "false";
                            isEditNewContact.Value = "false";
                        }
                        else
                        {
                            PointID.Value = clickedButton.ID.Remove(0, 9);
                            PointsInfo objPoint = objDbController.GetPointById(Int32.Parse(PointID.Value));
                            PointName.Text = objPoint.Points;

                            isEditNewPoint.Value = "false";
                            isEditPoint.Value = "true";
                            isEditContact.Value = "false";
                            isEditNewContact.Value = "false";
                        }
                    }
                }
                else if (clickedButton.ID.Contains("delete"))
                {
                    if (clickedButton.ID.ToLower().Contains("contact"))
                    {
                        if (clickedButton.ID.ToLower().Contains("new"))
                        {
                            ContactID.Value = clickedButton.ID.Remove(0, 16);
                            _newContactInfo.RemoveAt(Int32.Parse(ContactID.Value));
                            ClearContactFields();
                        }
                        else
                        {
                            ContactID.Value = clickedButton.ID.Remove(0, 13);
                            objDbController.DeleteContact(Int32.Parse(ContactID.Value));
                        }
                        AddContactTable();
                    }
                    if (clickedButton.ID.ToLower().Contains("point"))
                    {
                        if (clickedButton.ID.ToLower().Contains("new"))
                        {
                            PointID.Value = clickedButton.ID.Remove(0, 14);
                            _newPointsInfo.RemoveAt(Int32.Parse(PointID.Value));
                        }
                        else
                        {
                            PointID.Value = clickedButton.ID.Remove(0, 11);
                            objDbController.DeletePoints(Int32.Parse(PointID.Value));
                        }
                        AddPointsTable();
                    }
                }
            }
            catch (Exception)
            {
                ExceptionError.Visible = true;
            }
        }

        private void ClearContactFields()
        {
            Salutation.Text = "";
            Name.Text = "";
            Position.Text = "";
            OfficePhone.Text = "";
            HomePhone.Text = "";
            Fax.Text = "";
            Email.Text = "";
        }
    }
}