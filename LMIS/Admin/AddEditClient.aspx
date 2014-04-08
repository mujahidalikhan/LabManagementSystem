<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddEditClient.aspx.cs" Inherits="LMIS.Admin.AddEditClient" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 136px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="ContactID" Value="" runat="server" />
<asp:HiddenField ID="PointID" Value="" runat="server" />
<asp:HiddenField ID="isEditNewPoint" Value="false" runat="server" />
<asp:HiddenField ID="isEditPoint" Value="false" runat="server" />
<asp:HiddenField ID="isEditNewContact" Value="false" runat="server" />
<asp:HiddenField ID="isEditContact" Value="false" runat="server" />
    <div class="simplebox grid740" style="width: 99%;">
        <div style="z-index: 710;" class="titleh">
            <h3>
                Add/Edit Customer Information</h3>
        </div>
        <div style="z-index: 690;" class="body">
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Name:</span>
                <asp:TextBox ID="ClientName" runat="server" class="st-forminput" Width="370px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameError" runat="server" ErrorMessage="*Enter Customer Name"
                    ControlToValidate="ClientName" CssClass="st-form-error"></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <span class="st-labeltext">Address:</span>
                <asp:TextBox ID="Address1" runat="server" class="st-forminput" Width="370px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="AddressError" runat="server" ErrorMessage="*Enter Address"
                    ControlToValidate="Address1" CssClass="st-form-error"></asp:RequiredFieldValidator><br />
                <br />
                <span class="st-labeltext"></span>
                <asp:TextBox ID="Address2" runat="server" class="st-forminput" Width="370px"></asp:TextBox>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <table width="100%">
                    <tr>
                        <td>
                            <span class="st-labeltext">City:</span>
                        </td>
                        <td>
                            <asp:TextBox ID="City" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CityError" runat="server" ErrorMessage="*Enter City"
                    ControlToValidate="Address1" CssClass="st-form-error"></asp:RequiredFieldValidator><br />
                        </td>
                        <td>
                            <span class="st-labeltext">State:</span>
                        </td>
                        <td>
                            <asp:TextBox ID="State2" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="StateError" runat="server" ErrorMessage="*Enter State"
                    ControlToValidate="Address1" CssClass="st-form-error"></asp:RequiredFieldValidator><br />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="z-index: 680;" class="st-form-line">
                <table width="100%">
                    <tr>
                        <td>
                            <span class="st-labeltext">Postal Code:</span>
                        </td>
                        <td>
                            <asp:TextBox ID="postal" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="postalNumericError" runat="server" ControlToValidate="postal"
                                    Display="Dynamic" ErrorMessage="*Please enter only integer [0-9]" ValidationExpression="^[0-9]+$"
                                    CssClass="st-form-error"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="PostalError" runat="server" ErrorMessage="*Enter Postal Code"
                    ControlToValidate="Address1" CssClass="st-form-error"></asp:RequiredFieldValidator><br />
                        </td>
                        <td>
                            <span class="st-labeltext">Country:</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="Country" runat="server" Width="265px" CssClass="styled-select">
                                <asp:ListItem>Afghanistan</asp:ListItem>
                                <asp:ListItem>Albania</asp:ListItem>
                                <asp:ListItem>Algeria</asp:ListItem>
                                <asp:ListItem>American Samoa</asp:ListItem>
                                <asp:ListItem>Andorra</asp:ListItem>
                                <asp:ListItem>Angola</asp:ListItem>
                                <asp:ListItem>Anguilla</asp:ListItem>
                                <asp:ListItem>Antarctica</asp:ListItem>
                                <asp:ListItem>Antigua And Barbuda</asp:ListItem>
                                <asp:ListItem>Argentina</asp:ListItem>
                                <asp:ListItem>Armenia</asp:ListItem>
                                <asp:ListItem>Aruba</asp:ListItem>
                                <asp:ListItem>Australia</asp:ListItem>
                                <asp:ListItem>Austria</asp:ListItem>
                                <asp:ListItem>Azerbaijan</asp:ListItem>
                                <asp:ListItem>Bahamas</asp:ListItem>
                                <asp:ListItem>Bahrain</asp:ListItem>
                                <asp:ListItem>Bangladesh</asp:ListItem>
                                <asp:ListItem>Barbados</asp:ListItem>
                                <asp:ListItem>Belarus</asp:ListItem>
                                <asp:ListItem>Belgium</asp:ListItem>
                                <asp:ListItem>Belize</asp:ListItem>
                                <asp:ListItem>Benin</asp:ListItem>
                                <asp:ListItem>Bermuda</asp:ListItem>
                                <asp:ListItem>Bhutan</asp:ListItem>
                                <asp:ListItem>Bolivia</asp:ListItem>
                                <asp:ListItem>Bosnia And Herzegowina</asp:ListItem>
                                <asp:ListItem>Botswana</asp:ListItem>
                                <asp:ListItem>Bouvet Island</asp:ListItem>
                                <asp:ListItem>Brazil</asp:ListItem>
                                <asp:ListItem>British Indian Ocean Territory</asp:ListItem>
                                <asp:ListItem>Brunei Darussalam</asp:ListItem>
                                <asp:ListItem>Bulgaria</asp:ListItem>
                                <asp:ListItem>Burkina Faso</asp:ListItem>
                                <asp:ListItem>Burundi</asp:ListItem>
                                <asp:ListItem>Cambodia</asp:ListItem>
                                <asp:ListItem>Cameroon</asp:ListItem>
                                <asp:ListItem>Canada</asp:ListItem>
                                <asp:ListItem>Cape Verde</asp:ListItem>
                                <asp:ListItem>Cayman Islands</asp:ListItem>
                                <asp:ListItem>Central African Republic</asp:ListItem>
                                <asp:ListItem>Chad</asp:ListItem>
                                <asp:ListItem>Chile</asp:ListItem>
                                <asp:ListItem>China</asp:ListItem>
                                <asp:ListItem>Christmas Island</asp:ListItem>
                                <asp:ListItem>Cocos (Keeling) Islands</asp:ListItem>
                                <asp:ListItem>Colombia</asp:ListItem>
                                <asp:ListItem>Comoros</asp:ListItem>
                                <asp:ListItem>Congo</asp:ListItem>
                                <asp:ListItem>Cook Islands</asp:ListItem>
                                <asp:ListItem>Costa Rica</asp:ListItem>
                                <asp:ListItem>Cote D'Ivoire</asp:ListItem>
                                <asp:ListItem>Croatia (Local Name: Hrvatska)</asp:ListItem>
                                <asp:ListItem>Cuba</asp:ListItem>
                                <asp:ListItem>Cyprus</asp:ListItem>
                                <asp:ListItem>Czech Republic</asp:ListItem>
                                <asp:ListItem>Denmark</asp:ListItem>
                                <asp:ListItem>Djibouti</asp:ListItem>
                                <asp:ListItem>Dominica</asp:ListItem>
                                <asp:ListItem>Dominican Republic</asp:ListItem>
                                <asp:ListItem>East Timor</asp:ListItem>
                                <asp:ListItem>Ecuador</asp:ListItem>
                                <asp:ListItem>Egypt</asp:ListItem>
                                <asp:ListItem>El Salvador</asp:ListItem>
                                <asp:ListItem>Equatorial Guinea</asp:ListItem>
                                <asp:ListItem>Eritrea</asp:ListItem>
                                <asp:ListItem>Estonia</asp:ListItem>
                                <asp:ListItem>Ethiopia</asp:ListItem>
                                <asp:ListItem>Falkland Islands (Malvinas)</asp:ListItem>
                                <asp:ListItem>Faroe Islands</asp:ListItem>
                                <asp:ListItem>Fiji</asp:ListItem>
                                <asp:ListItem>Finland</asp:ListItem>
                                <asp:ListItem>France</asp:ListItem>
                                <asp:ListItem>French Guiana</asp:ListItem>
                                <asp:ListItem>French Polynesia</asp:ListItem>
                                <asp:ListItem>French Southern Territories</asp:ListItem>
                                <asp:ListItem>Gabon</asp:ListItem>
                                <asp:ListItem>Gambia</asp:ListItem>
                                <asp:ListItem>Georgia</asp:ListItem>
                                <asp:ListItem>Germany</asp:ListItem>
                                <asp:ListItem>Ghana</asp:ListItem>
                                <asp:ListItem>Gibraltar</asp:ListItem>
                                <asp:ListItem>Greece</asp:ListItem>
                                <asp:ListItem>Greenland</asp:ListItem>
                                <asp:ListItem>Grenada</asp:ListItem>
                                <asp:ListItem>Guadeloupe</asp:ListItem>
                                <asp:ListItem>Guam</asp:ListItem>
                                <asp:ListItem>Guatemala</asp:ListItem>
                                <asp:ListItem>Guinea</asp:ListItem>
                                <asp:ListItem>Guinea-Bissau</asp:ListItem>
                                <asp:ListItem>Guyana</asp:ListItem>
                                <asp:ListItem>Haiti</asp:ListItem>
                                <asp:ListItem>Heard And Mc Donald Islands</asp:ListItem>
                                <asp:ListItem>Holy See (Vatican City State)</asp:ListItem>
                                <asp:ListItem>Honduras</asp:ListItem>
                                <asp:ListItem>Hong Kong</asp:ListItem>
                                <asp:ListItem>Hungary</asp:ListItem>
                                <asp:ListItem>Icel And</asp:ListItem>
                                <asp:ListItem>India</asp:ListItem>
                                <asp:ListItem>Indonesia</asp:ListItem>
                                <asp:ListItem>Iran (Islamic Republic Of)</asp:ListItem>
                                <asp:ListItem>Iraq</asp:ListItem>
                                <asp:ListItem>Ireland</asp:ListItem>
                                <asp:ListItem>Israel</asp:ListItem>
                                <asp:ListItem>Italy</asp:ListItem>
                                <asp:ListItem>Jamaica</asp:ListItem>
                                <asp:ListItem>Japan</asp:ListItem>
                                <asp:ListItem>Jordan</asp:ListItem>
                                <asp:ListItem>Kazakhstan</asp:ListItem>
                                <asp:ListItem>Kenya</asp:ListItem>
                                <asp:ListItem>Kiribati</asp:ListItem>
                                <asp:ListItem>Korea, Dem People'S Republic</asp:ListItem>
                                <asp:ListItem>Korea, Republic Of</asp:ListItem>
                                <asp:ListItem>Kuwait</asp:ListItem>
                                <asp:ListItem>Kyrgyzstan</asp:ListItem>
                                <asp:ListItem>Lao People'S Dem Republic</asp:ListItem>
                                <asp:ListItem>Latvia</asp:ListItem>
                                <asp:ListItem>Lebanon</asp:ListItem>
                                <asp:ListItem>Lesotho</asp:ListItem>
                                <asp:ListItem>Liberia</asp:ListItem>
                                <asp:ListItem>Libyan Arab Jamahiriya</asp:ListItem>
                                <asp:ListItem>Liechtenstein</asp:ListItem>
                                <asp:ListItem>Lithuania</asp:ListItem>
                                <asp:ListItem>Luxembourg</asp:ListItem>
                                <asp:ListItem>Macau</asp:ListItem>
                                <asp:ListItem>Macedonia</asp:ListItem>
                                <asp:ListItem>Madagascar</asp:ListItem>
                                <asp:ListItem>Malawi</asp:ListItem>
                                <asp:ListItem Selected="True">Malaysia</asp:ListItem>
                                <asp:ListItem>Maldives</asp:ListItem>
                                <asp:ListItem>Mali</asp:ListItem>
                                <asp:ListItem>Malta</asp:ListItem>
                                <asp:ListItem>Marshall Islands</asp:ListItem>
                                <asp:ListItem>Martinique</asp:ListItem>
                                <asp:ListItem>Mauritania</asp:ListItem>
                                <asp:ListItem>Mauritius</asp:ListItem>
                                <asp:ListItem>Mayotte</asp:ListItem>
                                <asp:ListItem>Mexico</asp:ListItem>
                                <asp:ListItem>Micronesia, Federated States</asp:ListItem>
                                <asp:ListItem>Moldova, Republic Of</asp:ListItem>
                                <asp:ListItem>Monaco</asp:ListItem>
                                <asp:ListItem>Mongolia</asp:ListItem>
                                <asp:ListItem>Montserrat</asp:ListItem>
                                <asp:ListItem>Morocco</asp:ListItem>
                                <asp:ListItem>Mozambique</asp:ListItem>
                                <asp:ListItem>Myanmar</asp:ListItem>
                                <asp:ListItem>Namibia</asp:ListItem>
                                <asp:ListItem>Nauru</asp:ListItem>
                                <asp:ListItem>Nepal</asp:ListItem>
                                <asp:ListItem>Netherlands</asp:ListItem>
                                <asp:ListItem>Netherlands Ant Illes</asp:ListItem>
                                <asp:ListItem>New Caledonia</asp:ListItem>
                                <asp:ListItem>New Zealand</asp:ListItem>
                                <asp:ListItem>Nicaragua</asp:ListItem>
                                <asp:ListItem>Niger</asp:ListItem>
                                <asp:ListItem>Nigeria</asp:ListItem>
                                <asp:ListItem>Niue</asp:ListItem>
                                <asp:ListItem>Norfolk Island</asp:ListItem>
                                <asp:ListItem>Northern Mariana Islands</asp:ListItem>
                                <asp:ListItem>Norway</asp:ListItem>
                                <asp:ListItem>Oman</asp:ListItem>
                                <asp:ListItem>Pakistan</asp:ListItem>
                                <asp:ListItem>Palau</asp:ListItem>
                                <asp:ListItem>Panama</asp:ListItem>
                                <asp:ListItem>Papua New Guinea</asp:ListItem>
                                <asp:ListItem>Paraguay</asp:ListItem>
                                <asp:ListItem>Peru</asp:ListItem>
                                <asp:ListItem>Philippines</asp:ListItem>
                                <asp:ListItem>Pitcairn</asp:ListItem>
                                <asp:ListItem>Poland</asp:ListItem>
                                <asp:ListItem>Portugal</asp:ListItem>
                                <asp:ListItem>Puerto Rico</asp:ListItem>
                                <asp:ListItem>Qatar</asp:ListItem>
                                <asp:ListItem>Reunion</asp:ListItem>
                                <asp:ListItem>Romania</asp:ListItem>
                                <asp:ListItem>Russian Federation</asp:ListItem>
                                <asp:ListItem>Rwanda</asp:ListItem>
                                <asp:ListItem>Saint K Itts And Nevis</asp:ListItem>
                                <asp:ListItem>Saint Lucia</asp:ListItem>
                                <asp:ListItem>Saint Vincent, The Grenadines</asp:ListItem>
                                <asp:ListItem>Samoa</asp:ListItem>
                                <asp:ListItem>San Marino</asp:ListItem>
                                <asp:ListItem>Sao Tome And Principe</asp:ListItem>
                                <asp:ListItem>Saudi Arabia</asp:ListItem>
                                <asp:ListItem>Senegal</asp:ListItem>
                                <asp:ListItem>Seychelles</asp:ListItem>
                                <asp:ListItem>Sierra Leone</asp:ListItem>
                                <asp:ListItem>Singapore</asp:ListItem>
                                <asp:ListItem>Slovakia (Slovak Republic)</asp:ListItem>
                                <asp:ListItem>Slovenia</asp:ListItem>
                                <asp:ListItem>Solomon Islands</asp:ListItem>
                                <asp:ListItem>Somalia</asp:ListItem>
                                <asp:ListItem>South Africa</asp:ListItem>
                                <asp:ListItem>South Georgia , S Sandwich Is.</asp:ListItem>
                                <asp:ListItem>Spain</asp:ListItem>
                                <asp:ListItem>Sri Lanka</asp:ListItem>
                                <asp:ListItem>St. Helena</asp:ListItem>
                                <asp:ListItem>St. Pierre And Miquelon</asp:ListItem>
                                <asp:ListItem>Sudan</asp:ListItem>
                                <asp:ListItem>Suriname</asp:ListItem>
                                <asp:ListItem>Svalbard, Jan Mayen Islands</asp:ListItem>
                                <asp:ListItem>Sw Aziland</asp:ListItem>
                                <asp:ListItem>Sweden</asp:ListItem>
                                <asp:ListItem>Switzerland</asp:ListItem>
                                <asp:ListItem>Syrian Arab Republic</asp:ListItem>
                                <asp:ListItem>Taiwan</asp:ListItem>
                                <asp:ListItem>Tajikistan</asp:ListItem>
                                <asp:ListItem>Tanzania, United Republic Of</asp:ListItem>
                                <asp:ListItem>Thailand</asp:ListItem>
                                <asp:ListItem>Togo</asp:ListItem>
                                <asp:ListItem>Tokelau</asp:ListItem>
                                <asp:ListItem>Tonga</asp:ListItem>
                                <asp:ListItem>Trinidad And Tobago</asp:ListItem>
                                <asp:ListItem>Tunisia</asp:ListItem>
                                <asp:ListItem>Turkey</asp:ListItem>
                                <asp:ListItem>Turkmenistan</asp:ListItem>
                                <asp:ListItem>Turks And Caicos Islands</asp:ListItem>
                                <asp:ListItem>Tuvalu</asp:ListItem>
                                <asp:ListItem>Uganda</asp:ListItem>
                                <asp:ListItem>Ukraine</asp:ListItem>
                                <asp:ListItem>United Arab Emirates</asp:ListItem>
                                <asp:ListItem>United Kingdom</asp:ListItem>
                                <asp:ListItem>United States</asp:ListItem>
                                <asp:ListItem>United States Minor Is.</asp:ListItem>
                                <asp:ListItem>Uruguay</asp:ListItem>
                                <asp:ListItem>Uzbekistan</asp:ListItem>
                                <asp:ListItem>Vanuatu</asp:ListItem>
                                <asp:ListItem>Venezuela</asp:ListItem>
                                <asp:ListItem>Viet Nam</asp:ListItem>
                                <asp:ListItem>Virgin Islands (British)</asp:ListItem>
                                <asp:ListItem>Virgin Islands (U.S.)</asp:ListItem>
                                <asp:ListItem>Wallis And Futuna Islands</asp:ListItem>
                                <asp:ListItem>Western Sahara</asp:ListItem>
                                <asp:ListItem>Yemen</asp:ListItem>
                                <asp:ListItem>Yugoslavia</asp:ListItem>
                                <asp:ListItem>Zaire</asp:ListItem>
                                <asp:ListItem>Zambia</asp:ListItem>
                                <asp:ListItem>Zimbabwe</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <br />
        <div class="simplebox grid740" style="width: 99%;">
            <div style="z-index: 710;" class="titleh">
                <h3>
                    Contact Information</h3>
            </div>
            <div style="z-index: 690;" class="body">
                <div style="z-index: 680;" class="st-form-line">
                    <span class="st-labeltext">Salutation:</span>
                    <asp:DropDownList ID="Salutation" runat="server" Width="100px" CssClass="styled-select">
                        <asp:ListItem>Tan Sri</asp:ListItem>
                        <asp:ListItem>Dato</asp:ListItem>
                        <asp:ListItem>Datuk</asp:ListItem>
                        <asp:ListItem>Mr</asp:ListItem>
                        <asp:ListItem>Miss</asp:ListItem>
                        <asp:ListItem>Mrs</asp:ListItem>
                        <asp:ListItem>Madam</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ContactError" runat="server" ErrorMessage="*Enter Contact Inofrmation"
                    ControlToValidate="ClientName" CssClass="st-form-error"></asp:RequiredFieldValidator>
                </div>
                <div style="z-index: 680;" class="st-form-line">
                    <span class="st-labeltext">Name:</span>
                    <asp:TextBox ID="Name" runat="server" class="st-forminput" Width="370px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ClientNameError" runat="server"
                        ErrorMessage="*Enter Person value " ControlToValidate="Name" CssClass="st-form-error"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div style="z-index: 680;" class="st-form-line">
                    <span class="st-labeltext">Position:</span>
                    <asp:TextBox ID="Position" runat="server" class="st-forminput" Width="370px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PositionError" runat="server"
                        ErrorMessage="*Enter Position value " ControlToValidate="Position" CssClass="st-form-error"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div style="z-index: 680;" class="st-form-line">
                    <table width="100%">
                        <tr>
                            <td>
                                <span class="st-labeltext">Office Phone:</span>
                            </td>
                            <td>
                                <asp:TextBox ID="OfficePhone" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="OfficePhone"
                                    Display="Dynamic" ErrorMessage="*Please enter only integer [0-9]" ValidationExpression="^[0-9]+$"
                                    CssClass="st-form-error"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="OfficePhoneError" runat="server"
                                    ErrorMessage="*Enter Phone Number " ControlToValidate="OfficePhone" CssClass="st-form-error"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <span class="st-labeltext">H/P:</span>
                            </td>
                            <td>
                                <asp:TextBox ID="HomePhone" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="HomePhone"
                                    Display="Dynamic" ErrorMessage="*Please enter only integer [0-9]" ValidationExpression="^[0-9]+$"
                                    CssClass="st-form-error"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="HomePhoneError" runat="server"
                                    ErrorMessage="*Enter Phone Number " ControlToValidate="HomePhone" CssClass="st-form-error"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="z-index: 680;" class="st-form-line">
                    <table width="100%">
                        <tr>
                            <td>
                                <span class="st-labeltext">Fax:</span>
                            </td>
                            <td>
                                <asp:TextBox ID="Fax" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Fax"
                                    Display="Dynamic" ErrorMessage="*Please enter only integer [0-9]" ValidationExpression="^[0-9]+$"
                                    CssClass="st-form-error"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="FaxError" runat="server"
                                    ErrorMessage="*Enter Fax Number " ControlToValidate="Fax" CssClass="st-form-error"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <span class="st-labeltext">Email:</span>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server" class="st-forminput" Width="250px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Email"
                                    Display="Dynamic" ErrorMessage="*Please enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    CssClass="st-form-error"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="EmailError" runat="server"
                                    ErrorMessage="*Enter Email Address" ControlToValidate="Email" CssClass="st-form-error"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="z-index: 680;" class="st-form-line">
                    <table width="10%">
                        <tr>
                            <td>
                                <asp:Button ID="ButtonAddMore" runat="server" Text=" Add More" CssClass="st-button"
                                    Width="120px" OnClick="ButtonAddMore_Click" CausesValidation="False" />
                            </td>
                            <td>
                                <asp:Button ID="ButtonSave" runat="server" Text=" Save" CssClass="st-button" Width="120px"
                                    OnClick="ButtonSave_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="z-index: 680;" class="st-form-line">
                    <div style="z-index: 460;" class="titleh">
                        <h3>
                            Contact Information</h3>
                    </div>
                    <!-- Start Data Tables Initialisation code -->
                    <script type="text/javascript" charset="utf-8">
                        $(document).ready(function () {
                            oTable = $("#<%= ContactListTable.ClientID %>").dataTable({
                                "bJQueryUI": true,
                                "sPaginationType": "full_numbers"
                            });
                        });
                    </script>
                    <!-- End Data Tables Initialisation code -->
                    <asp:Table ID="ContactListTable" runat="server" class="display data-table" Width="100%"
                        CellPadding="0" CellSpacing="0" border="0" />
                </div>
            </div>
        </div>
        <div class="simplebox grid740" style="width: 99%;">
            <div style="z-index: 710;" class="titleh">
                <h3>
                    Sample Points</h3>
            </div>
            <div style="z-index: 690;" class="body">
                <div style="z-index: 680; width: 99%;" class="st-form-line">
                    <table width="100%">
                        <tr>
                            <td>
                                <span class="st-labeltext">Point Name:</span>
                            </td>
                            <td>
                                <asp:TextBox ID="PointName" runat="server" class="st-forminput" Width="370px"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="PointNameError" runat="server" ErrorMessage="*Enter Points Information"
                    ControlToValidate="ClientName" CssClass="st-form-error"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button ID="AddPoints" runat="server" Text=" AddPoints" CssClass="st-button"
                                    Width="120px" OnClick="AddPoints_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="z-index: 690;" class="body">
                <div style="z-index: 680; width: 99%;" class="st-form-line" >
                    <table>
                        <tr>
                            <td>
                                <div style="z-index: 460;" class="titleh">
                                    <h3>
                                        Points Information</h3>
                                </div>
                                <!-- Start Data Tables Initialisation code -->
                                <script type="text/javascript" charset="utf-8">
                                    $(document).ready(function () {
                                        oTable = $("#<%= PointsTable.ClientID %>").dataTable({
                                            "bJQueryUI": true,
                                            "sPaginationType": "full_numbers"
                                        });
                                    });
                                </script>
                                <!-- End Data Tables Initialisation code -->
                                <asp:Table ID="PointsTable" runat="server" class="display data-table" Width="100%"
                                    CellPadding="0" CellSpacing="0" border="0" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
            <br />
            <div style="z-index: 680;" class="st-form-line">
                <table width="100%">
                    <tr>
                        <td class="style1">
                            <asp:Button ID="Submit" runat="server" Text="Complete" OnClick="Submit_Click" CssClass="st-button"
                                Width="120px" CausesValidation="False" />
                        </td>
                         <td>
                            <asp:Label ID="ExceptionError" runat="server" 
                                Text="*Submission Failed. Error Occurred." style="color:Red;width:250px;" 
                                Visible="False" Width="250px" CssClass="st-form-error"></asp:Label>
                        <p ></p>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
