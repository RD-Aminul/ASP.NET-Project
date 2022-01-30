<%@ Page Title="" Language="C#" MasterPageFile="~/Reg/Login.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Course_ASP_Project.Reg.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
		.Space label{
			margin-left: 5px;
			text-align:center;
		}
		.Space{
			margin-left: 20px;
		}
		.msg {
		margin-left: 35px;
		}
	</style>
    <section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">Student Registration</h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-12 col-lg-10">
					<div class="wrap d-md-flex">
						<div class="text-wrap p-4 p-lg-5 text-center d-flex align-items-center order-md-last">
							<div class="text w-100">
								<h2>Welcome to Registration</h2>
								<p>Already have an account?</p>
								<a href="../login" class="btn btn-white btn-outline-white">Sign In</a>
							</div>
			      </div>
						<div class="login-wrap p-4 p-lg-5">
			      	<div class="d-flex">
			      		<div class="w-100">
			      			<h3 class="mb-4">Register In</h3>
							<asp:Label ID="lblMessage" runat="server" ForeColor="#d62929" CssClass="msg"></asp:Label>
			      		</div>
			      	</div>
							<form action="#" class="signin-form">
			      		<div class="form-group mb-3">
			      			<label class="label" for="name">Username</label>
							<asp:TextBox ID="txtUserName" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter username" ControlToValidate="txtUserName" ForeColor="#CC0000"></asp:RequiredFieldValidator>

			      		</div>
						<div class="form-group mb-3">
			      			<label class="label" for="mail">Email</label>
							<asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Format" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
			      			
			      		</div>
						<div class="form-group mb-3" style="line-snap:baseline">
			      			<label class="label" for="gender">Gender</label><br />
							<asp:RadioButton ID="rbtnMale" runat="server" CssClass="Space" Text="Male" GroupName="gender" />
							<asp:RadioButton ID="rbtnFemale" runat="server" CssClass="Space" Text="Female" GroupName="gender" />
							<asp:RadioButton ID="rbtnOther" runat="server" CssClass="Space" Text="Other" GroupName="gender" />
							
							
			      		</div>
		            <div class="form-group mb-3">
		            	<label class="label" for="password">Password</label>
						<asp:TextBox ID="txtPassword" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
							  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter password" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
		              
		                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtCfrmPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password not match" ForeColor="Red"></asp:CompareValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password should be in 4 character" ForeColor="#CC0000" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
		              
		            </div>
					<div class="form-group mb-3">
		            	<label class="label" for="Cfrmpassword">Confirm Password</label>
						<asp:TextBox ID="txtCfrmPassword" class="form-control" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pleser enter confirm password" ControlToValidate="txtCfrmPassword" Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
		              
		                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtCfrmPassword" Display="Dynamic" ErrorMessage="Password should be in 4 character" ForeColor="#CC0000" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
		              
		            </div>
		            <div class="form-group">
						<asp:Button ID="btnRegister" class="form-control btn btn-primary submit px-3" runat="server" Text="Register" OnClick="btnRegister_Click" />
		            </div>
		            
		          </form>
		        </div>
		      </div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>
