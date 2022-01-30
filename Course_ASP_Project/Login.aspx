<%@ Page Title="" Language="C#" MasterPageFile="~/Reg/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Course_ASP_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
	    .msg {
		margin-left: 35px;
	}
	span{
		position: absolute;
		right: 115px;
		transform: translate(0,-50%);
		top: 60%;
		cursor: pointer;
	}
	.fa{
		font-size: 20px;
		color: #7a797e;
	}
	</style>
    <section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">Student LogIn</h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-12 col-lg-10">
					<div class="wrap d-md-flex">		
						<div class="text-wrap p-4 p-lg-5 text-center d-flex align-items-center order-md-last">
							<div class="text w-100">
								<h2>Welcome to Sign In</h2>
								<p>Don't have an account?</p>
								<a href="Reg/Registration" class="btn btn-white btn-outline-white">Sign Up</a>
							</div>
						</div>
						<div class="login-wrap p-4 p-lg-5">
			      		<div class="d-flex">
			      		<div class="w-10">
			      			<h3 class="mb-4">Sign In</h3>
                           <asp:Label ID="lblMessage" runat="server" ForeColor="#d62929" CssClass="msg"></asp:Label>
			      		</div>
			      		</div>
							<form action="#" class="signin-form">
			      		<div class="form-group mb-3">
			      			<label class="label" for="name">Username</label>
							<asp:TextBox ID="txtUserName" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter User Name" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
			      			
			      		</div>
						<div class="form-group mb-3">
		            		<label class="label" for="password">Password</label>
							<asp:TextBox ID="txtPassword" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter password" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
							<%--<input type="password" class="form-control" placeholder="Pass" id="password">
							<span><i class="fa fa-eye" aria-hidden="true" id="eye" onclick="toggle()"></i></span>--%>

						</div>
						<div class="form-group">
							<asp:Button ID="btnlogin" class="form-control btn btn-primary submit px-3" runat="server" Text="Sign In" OnClick="btnlogin_Click"/>
						</div>
						<div class="form-group d-md-flex">
		            	<div class="w-50 text-left">
			            	<label class="checkbox-wrap checkbox-primary mb-0">
								<asp:CheckBox ID="chkbox" runat="server" Text="Remember Me"  />
								<span class="checkmark"></span>
							
							</label>
							
						</div>
						<div class="w-50 text-md-right">
							<a href="Reg/ResetPass">Forgot Password?</a>
						</div>
		            </div>
		          </form>
		        </div>
		      </div>
				</div>
			</div>
		</div>
		<%--<script>
            var state = false;
            function toggle() {
                if (state) {
                    document.getElementById("password").setAttribute("type", "password");
                    document.getElementById("eye").style.color = '#7a797e';
                    state = false;
                }
                else {
                    document.getElementById("password").setAttribute("type", "text");
                    document.getElementById("eye").style.color = '#5887ef';
                    state = true;
                }
            }
         </script>--%>
	</section>
	
</asp:Content>
