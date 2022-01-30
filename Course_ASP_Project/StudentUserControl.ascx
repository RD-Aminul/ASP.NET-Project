<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentUserControl.ascx.cs" Inherits="Course_ASP_Project.StudentUserControl" %>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 142px;
        }
        .auto-style4 {
            width: 299px;
        }
        .auto-style5 {
            width: 118px;
        }
        .auto-style6 {
            width: 299px;
            height: 74px;
        }
        .auto-style7 {
            width: 118px;
            height: 74px;
        }
        .auto-style8 {
            height: 74px;
        }
        auto-style11 {
            width: 219px;
        }
        .auto-style12 {
            width: 299px;
            height: 23px;
        }
        .auto-style13 {
            width: 118px;
            height: 23px;
        }
        .auto-style14 {
            height: 23px;
        }
        .auto-style18 {
            width: 143px;
        }
        .auto-style22 {
            width: 136px;
        }
        .auto-style24 {
            width: 129px;
        }
        .auto-style26 {
            width: 179px;
        }
        .auto-style27 {
            width: 40px;
        }
        .auto-style28 {
            width: 105px;
        }
        .auto-style29 {
            width: 299px;
            height: 30px;
        }
        .auto-style30 {
            width: 118px;
            height: 30px;
        }
        .auto-style31 {
            height: 30px;
        }
        .auto-style32 {
            margin-top: 0px;
        }
    </style>
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <table class="auto-style1">
            <tr>
                <td class="auto-style26">&nbsp;</td>
                <td class="auto-style24">Course Name :</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style27">&nbsp;</td>
                <td class="auto-style24">Faculty Name :</td>
                <td class="auto-style18">
                    <asp:TextBox ID="txtFacultyName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style27">
                    &nbsp;</td>
                <td class="auto-style28">
                    Tsp Name :</td>
                <td class="auto-style22">
                    <asp:TextBox ID="txtTspName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">&nbsp;</td>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnSaveCourse" runat="server" Text="Save Course" OnClick="btnSaveCourse_Click" CausesValidation="false" />
                </td>
                <td class="auto-style27">&nbsp;</td>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style18">
                    <asp:Button ID="btnSaveFaculty" runat="server" Text="Save Faculty" OnClick="btnSaveFaculty_Click" CausesValidation="false" />
                </td>
                <td class="auto-style27">
                    &nbsp;</td>
                <td class="auto-style28">
                    &nbsp;</td>
                <td class="auto-style22">
                    <asp:Button ID="btnSaveTsp" runat="server" Text="Save Tsp" OnClick="btnSaveTsp_Click" CausesValidation="false" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style26">&nbsp;</td>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td class="auto-style28">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        <div style="font-size:xx-large" align="center"> Student Info </div>
        <table class="auto-style1">
            <asp:HiddenField ID="HiddenImageName" runat="server" />
            <asp:HiddenField ID="HiddenImageUrl" runat="server" />

            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <asp:Label ID="lblMessage1" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
          
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30">First Name :</td>
                <td class="auto-style31">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter First Name" ControlToValidate="txtFirstName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">Last Name :</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Last Name" ControlToValidate="txtLastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">Date Of Birth :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtCalenderDate" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgCalender" runat="server" Height="15px" ImageUrl="~/Images/calender.png" Width="16px" OnClick="imgCalender_Click" CausesValidation="False" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select Date Of Birth" ControlToValidate="txtCalenderDate" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Calendar ID="Calendar" runat="server" Height="101px" Width="31px" OnSelectionChanged="Calendar_SelectionChanged" CssClass="auto-style32"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">Mobile No :</td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Mobile No" ControlToValidate="txtMobileNo" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">Email :</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Format" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <%--<tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">Gender :</td>
                <td>
                    <asp:RadioButton ID="rbtnMale" runat="server" Text="Male" GroupName="Gender"/>
                    <asp:RadioButton ID="rbtnFemale" runat="server" Text="Female" GroupName="Gender" />
                    <asp:RadioButton ID="rbtnOther" runat="server" Text="Other" GroupName="Gender" />
                </td>
            </tr>--%>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style7">Student Image :</td>
                <td class="auto-style8">
                    <asp:Image ID="imgStudent" runat="server" Height="70px" Width="70px" /><br />
                    <asp:FileUpload ID="UploadStudentImg" runat="server" onchange="if(confirm('upload'+this.value+'?'))this.form.submit()" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">Course :</td>
                <td>
                    <asp:DropDownList ID="ddlCourse" runat="server">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please Select Course" ControlToValidate="ddlCourse" Display="Dynamic" ForeColor="Red" Operator="NotEqual" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13">Faculty :</td>
                <td class="auto-style14">
                    <asp:DropDownList ID="ddlFaculty" runat="server">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Please Select Faculty" ControlToValidate="ddlFaculty" Display="Dynamic" ForeColor="Red" Operator="NotEqual" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style13">Tsp :</td>
                <td class="auto-style14">
                    <asp:DropDownList ID="ddlTsp" runat="server">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Please Select Tsp" ControlToValidate="ddlTsp" Display="Dynamic" ForeColor="Red" Operator="NotEqual" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSaveStudent" runat="server" BackColor="#FF9900" ForeColor="White" Text="Save" Width="62px" OnClick="btnSaveStudent_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
                </td>
            </tr>
        </table>
        <br />
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveStudent" />
        </Triggers>
    </asp:UpdatePanel>
