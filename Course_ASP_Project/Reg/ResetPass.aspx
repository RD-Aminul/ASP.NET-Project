<%@ Page Title="" Language="C#" MasterPageFile="~/Reg/Login.Master" AutoEventWireup="true" CodeBehind="ResetPass.aspx.cs" Inherits="Course_ASP_Project.Reg.ResetPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
	.msg {
		margin-left: 35px;
	}
	</style>
    <section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">Reset Password</h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-12 col-lg-10">
					<div class="wrap d-md-flex">		
						<div class="text-wrap p-4 p-lg-5 text-center d-flex align-items-center order-md-last">
							<div class="text w-100">
								<h2>Welcome to Reset Password</h2>
								<p>No Need to Reset?</p>
								<a href="../login" class="btn btn-white btn-outline-white">LogIn</a>
							</div>
						</div>
						<div class="login-wrap p-4 p-lg-5">
			      		<div class="d-flex">
			      		<div class="w-100">
			      			<h3 class="mb-4">Reset In</h3>
							  <p>Please enter your email address and we'll send you a link to reset your password.</p>
			      		</div>
			      		</div>
							<form action="#" class="signin-form">
			      		<div class="form-group mb-3">
			      			<%--<label class="label" for="name">Email</label>--%>
							<asp:TextBox ID="txtEnterEmail" class="form-control" placeholder="Enter Your Email" runat="server"></asp:TextBox>
			      			
			      		</div>
						<div class="form-group">
							<asp:Button ID="btnSubmit" class="form-control btn btn-primary submit px-3" runat="server" Text="Submit"/>
						</div>
		          </form>
		        </div>
		      </div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>
