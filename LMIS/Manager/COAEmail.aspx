<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="COAEmail.aspx.cs" Inherits="LMIS.Manager.COAEmail"
    EnableViewStateMac="false" EnableSessionState="True" EnableEventValidation="false"
    ValidateRequest="false" ViewStateEncryptionMode="Never" %>

<?xml version="1.0" encoding="utf-8" ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/2002/REC-xhtml1-20020801/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<head id="Head1" runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="pnl1" runat="server">
              <table width="1280px" style="height: 1830px">
            <tr>
                <td valign="top" align="left" style="width: 10%">
                    &nbsp;&nbsp;<br />
                    &nbsp;&nbsp;<br />
                    <br />
                    <br />
                    <img src="http://lmis.knownwire.com/Logos/1NabbirLogo.jpg" alt="Nabbir" style="width: 104px;
                        height: 39px; margin-bottom: 0.5px;" />
                    <br />
                    <label class="log-lab" style="font-size: 22px">
                        <b>&nbsp;NABBIR<br />
                        </b>
                    </label>
                    <label class="log-lab">
                        <b>LABORATORY&nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;&nbsp; </b>
                    </label>
                    <label class="log-lab" style="font-size: 13px">
                        <b>(KL) SDN, BHD</b></label><br />
                    <label class="log-lab">
                        <b>&nbsp;&nbsp;&nbsp;&nbsp;(413256-D)</b></label><br />
                    <br />
                    <img src="http://lmis.knownwire.com/Logos/21ILACMRA.jpg" alt="Nabbir" style="height: 42px; width: 41px" />
                    <img src="http://lmis.knownwire.com/Logos/22SAMMcolor.jpg" alt="Nabbir" style="width: 46px;
                        height: 36px;" />
                    <br />
                    &nbsp;<img src="http://lmis.knownwire.com/Logos/3MoodyInternational.png" alt="Nabbir" style="width: 98px;
                        height: 67px" />
                    <br />
                    &nbsp;<img src="http://lmis.knownwire.com/Logos/45MoodyInternationals2.png" alt="Nabbir" style="width: 101px;
                        height: 63px" />
                    <br />
                    &nbsp;<img src="http://lmis.knownwire.com/Logos/45MoodyInternationals2.png" alt="Nabbir" style="width: 104px;
                        height: 65px" />
                    <br />
                    <br />
                    &nbsp;<img src="http://lmis.knownwire.com/Logos/65Spractices.png" alt="Nabbir" style="height: 58px;
                        width: 92px;" />
                    <br />
                    <img src="http://lmis.knownwire.com/Logos/7GIPLogo.PNG" alt="Nabbir" style="width: 106px; height: 36px" />
                    <br />
                    <br />
                    <div style="width: 90%;" align="center">
                        <label class="log-lab" style="font-size: 20px">
                            <b>Analytical</b></label><br />
                        <label class="log-lab" style="font-size: 20px">
                            <b>Chemists</b></label><br />
                        <label class="log-lab" style="font-size: 20px">
                            <b>&</b></label><br />
                        <label class="log-lab" style="font-size: 20px">
                            <b>Industrial</b></label><br />
                        <label class="log-lab" style="font-size: 20px">
                            <b>Consultants</b></label>
                    </div>
                    <br />
                    <label class="log-lab">
                        <b>Address :</b></label><br />
                    <label class="log-lab">
                        <b>No. 263-267,</b></label><br />
                    <label class="log-lab">
                        <b>Jalan Nalai 3/21,</b></label><br />
                    <label class="log-lab">
                        <b>Kaw. Perindustrian Nilai 3,</b></label><br />
                    <label class="log-lab">
                        <b>71800 Nilai, N Sembilan</b></label><br />
                    <label class="log-lab">
                        <b>Malaysia</b></label><br />
                    <br />
                    <br />
                    <label class="log-lab">
                        <b>Toll Free :</b></label><br />
                    <label class="log-lab">
                        <b>1-300-888-003</b></label><br />
                    <br />
                    <label class="log-lab">
                        <b>Facsimile :</b></label><br />
                    <label class="log-lab">
                        <b>+6(06) 799 0688</b></label><br />
                    <br />
                    <label class="log-lab">
                        <b>Email :</b></label><br />
                    <label class="log-lab">
                        <b>careline@nabbirlab.com</b></label><br />
                    <br />
                </td>
                <td valign="top"  style="width: 90%" >
                    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
                        width: 100%">
                        <tr>
                            <td align="center" colspan="4">
                                <h1>
                                    <b>Certificate of Analysis</b></h1>
                            </td>
                        </tr>
                        <tr style="height: 0.5px;">
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" rowspan="2">
                            </td>
                            <td>
                                Lab No :
                            </td>
                            <td>
                                <asp:Label ID="LabNoAnalysis" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Report Date :
                            </td>
                            <td>
                                <asp:Label ID="ReportDateAnalysis" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                To :-
                            </td>
                            <td colspan="3">
                                <asp:Label ID="AnalysisTo1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                            </td>
                            <td colspan="3">
                                <asp:Label ID="AnalysisTo2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="mso-height-source: userset; height: 6.0pt">
                            <td colspan="3">
                                <asp:Label ID="AnalysisTo3" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="mso-height-source: userset; height: 6.0pt">
                            <td colspan="3">
                                <asp:Label ID="AnalysisTo4" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Attention :-
                            </td>
                            <td>
                                <asp:Label ID="AttentionAnalysis" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 3px;">
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <b style="text-decoration: underline">Sampling Information</b>
                            </td>
                        </tr>
                        <tr>
                            <td width="300px" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Sample Description:"></asp:Label>
                            </td>
                            <td style="width: 200px" valign="top">
                                <asp:Label ID="SampleDescriptionAnalysis" runat="server"></asp:Label>
                            </td>
                            <td style="width: 150px" valign="top">
                                Sample Packing :
                            </td>
                            <td valign="top">
                                <asp:Label ID="SamplePackingAnalysis" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Sample Received On :
                            </td>
                            <td valign="top">
                                <asp:Label ID="SampleReceivedOn" runat="server"></asp:Label>
                            </td>
                            <td valign="top">
                            </td>
                            <td valign="top">
                                <asp:Label ID="SamplePackingAnalysis2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Type of Sampling :
                            </td>
                            <td valign="top">
                                <asp:Label ID="TypeofSamplingAnalysis" runat="server"></asp:Label>
                            </td>
                            <td valign="top">
                            </td>
                            <td valign="top">
                                <asp:Label ID="SamplePackingAnalysis3" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 14.25pt">
                            <td colspan="3" valign="top">
                            </td>
                            <td valign="top">
                                <asp:Label ID="SamplePackingAnalysis4" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <b style="text-decoration: underline">Analysis Conditions</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="AnalysisConditions" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="mso-height-source: userset; height: 12.75pt">
                            <td colspan="4">
                                <asp:Label ID="AnalysisConditions2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <b style="text-decoration: underline">Result of Analysis</b>
                            </td>
                        </tr>
                        
                     
                        <tr>
                            <td colspan="4">

                                <asp:Table ID="TestInfoTable" runat="server" class="tablesorter"  CellPadding="0"
                                    CellSpacing="0" border="0" Width="100%" />
                            </td>
                        </tr>
                  
                        <tr>
                            <td>
                                <b>
                                    <br />
                                </b>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <b>Notes: 1. Fifth Schedule of Environmental Quality (Industrial Effluent) Regulations,
                                    2009 Standard B</b>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <b>2. Seventh Schedule of Environmental Quality (Industrial Effluent) Regulations, 2009
                                    Standard B for COD</b>
                                <td>
                                </td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <br />
                                </p>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <br />
                                </p>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td colspan="2" class="style54">
                                <asp:Label ID="NameAnalysis" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <br />
                                </p>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td colspan="2" class="style54">
                                <asp:Label ID="TypeAnalysis" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <p>
                                    Note: This report is issued subject to Nabbir Labortory (KL) Sdn. Bhd.'s "Terms
                                    and Conditions Governing Technical Services"</p>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <p>
                                    The terms and conditions governing the issue of this report are set out as attached
                                    within this report</p>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="LabelSpace" runat="server">&nbsp;&nbsp;&nbsp;</asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="1280px" style="height: 1830px">
            <tr style="height: 15px">
                <td valign="top" colspan="2">
                    <b style="text-decoration: underline">Analytical Methods Information</b>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                    <p>
                        1. APHA</p>
                </td>
                <td width="700px" valign="top">
                    <p>
                        Standard Methods for Examination of Water and Wastewater, 21st Edition published
                        by the American Public Health</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                </td>
                <td width="800px" valign="top">
                    <p>
                        Association, the Amercian Water Works Association and the American Environmental
                        Federation of the United States of</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                </td>
                <td width="600px" valign="top">
                    <p>
                        America</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                </td>
                <td width="600px" valign="top">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                    <p>
                        2. US EPA</p>
                </td>
                <td width="800px" valign="top">
                    <p>
                        Environmental Protection Agency of United States of America Methods. As listed on
                        CFR 40 Ch 1. SubCh D part 136,</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                </td>
                <td width="600px" valign="top">
                    <p>
                        published by the Office of the Federal Register. National Archives and Records Administration,
                        US</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                </td>
                <td width="600px" valign="top">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                    <p>
                        3. HACH</p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        HACH Published Methods, HACH Company, Loveland Colorado, U.S</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                </td>
                <td width="600px" valign="top">
                </td>
            </tr>
            <tr style="height: 15px">
                <td valign="top" colspan="2">
                    <b style="text-decoration: underline">Unit of Measurement</b>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                    <p>
                        1. ˚C</p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        degree Celcius</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                    <p>
                        2. mg/L</p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        milligram per Liter</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                    <p>
                        3. ADMI</p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        American Dye Manufacturers Institute</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="70px" valign="top">
                </td>
                <td width="600px" valign="top">
                </td>
            </tr>
            <tr style="height: 15px">
                <td valign="top" colspan="2">
                    <b style="text-decoration: underline">Analytical Intruments</b>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="150px" valign="top">
                    <p>
                        1. LIG Thermometer:
                    </p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        Liquid In Glass Mercury Immisible Thermometer with ±1˚C graduation</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="150px" valign="top">
                    <p>
                        2. Gravimetric:
                    </p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        Shimadzu AY 220 Analytical Balance with 0.0001g sensitivity. S/N: D432812700</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="150px" valign="top">
                    <p>
                        3. Spectrometer:
                    </p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        Varian Inc. Cary 50 UV-vis Spectrometer. S/N: EL01055057</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="150px" valign="top">
                    <p>
                        4. AAS:
                    </p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        Varian Inc. SpetrAA55 Atomic Absoption Spectrometer. S/N: EL01055237</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="150px" valign="top">
                    <p>
                        5. ICP-OES:
                    </p>
                </td>
                <td width="700px" valign="top">
                    <p>
                        Varian Inc. 715-ES Inductively Coupled Plasma Optical Emission Spectrometer. S/N:
                        EL07044003</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="150px" valign="top">
                    <p>
                        6. ISE:
                    </p>
                </td>
                <td width="600px" valign="top">
                    <p>
                        Cole-Palmer Cyanide Ion Selective Electrode Model: 27504-12</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="150px" valign="top">
                </td>
                <td width="600px" valign="top">
                </td>
            </tr>
            <tr style="height: 15px">
                <td valign="top" colspan="2">
                    <b style="text-decoration: underline">This Report is issued under the following conditions:</b>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1. Results of the testing in the form of a report
                        will be issued immediately after the service has been completed.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2. Unless otherwise requested, a report shall
                        contain only technical results. Analysis and interpretation of the results
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;and professional opinion
                        and recommendations expressed thereupon, if required, shall clearly indicated and
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;additional fee paid
                        for, by the Customer.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3. This report applies to the sample of the
                        specific product given at the time of its testing. The results are not used to
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indicate or imply that
                        they are applicable to other similar items. In addition, such results must not be
                        used to indicate
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;or imply that Nabbir
                        Laboratory (KL) Sdn, Bhd, approves, recommends or endorses the manufaturer, supplier
                        or
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user of such product/equipment,
                        or that Nabbir Laboratory (KL) Sdb, Bhd, in any way "guarantees" the later
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;performance of the product.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4. Additional copies of the report are available
                        to the Customer at an additional fee. No third party can obtain a copy of
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;this report through
                        Nabbir Laboratoy (KL) Sdb, Bhd., unless the Customer has authorized Nabbir Laboratoy
                        (KL)
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sdb, Bhd. In writing
                        to do so.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5. Nabbir Laboratoy (KL) Sdb, Bhd. May at its
                        sole discretion add to or amend the conditions of the report at the time
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;of issue of the report
                        and such report and such additions or amendments shall be binding on the Customer.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6. All copyright in the report shall remain
                        with Nabbir Laboratoy (KL) Sdb, Bhd. And the Customer shall, upon paying
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;of Nabbir Laboratoy
                        (KL) Sdb, Bhd.’s fees for the carrying out of the test, be granted a license to
                        use or publish
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;the report to the third
                        parties subject to the terms and conditions herein, provided always that Nabbir
                        Laboratoy (KL)
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sdb, Bhd. may at its
                        absolute discretion be entitled to impose such conditions on the license on the
                        license as it sees fit.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;7. Nothing in this report shall be interpreted
                        to mean that Nabbir Laboratoy (KL) Sdb, Bhd. has verified or ascertained
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;any endorsement or marks
                        from any other testing authority or bodies that may be found on that sample.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;8. This report shall not be interpreted wholly
                        or in parts and no reference shall be made by the Customer to Nabbir
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Laboratoy (KL) Sdb,
                        Bhd. or the reports or results furnished by Nabbir Laboratoy (KL) Sdb, Bhd. in any
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;advertisements or sales
                        promotion.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;9. Unless otherwise stated, the tests are carried
                        out in Nabbir Laboratoy (KL) Sdb, Bhd., No 265 – 267, Jalan Nilai
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td colspan="2" valign="top" width="1200px">
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3/21, Kawasan Perindustrian
                        Nilai 3, 71800 Nilai, Negeri Sembilan, Malaysia.
                    </p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2" align="right">
                    <p>
                        Page 2 of 2</p>
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1200px" valign="top" colspan="2">
                </td>
            </tr>
            <tr style="height: 15px">
                <td width="1500px" valign="top" colspan="2">
                    <b style="text-decoration: underline">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </b>

                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
