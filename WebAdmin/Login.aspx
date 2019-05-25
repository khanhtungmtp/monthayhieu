<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAdmin.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng nhập</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="login-form p-5">
        <div class="title text-center">
            <h3 class="text-uppercase">Đăng Nhập</h3>
        </div>
        <div class="contne">
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fa fa-user text-success"></i>
                    </span>
                </div>
                <input runat="server" id="input_Username" type="text" name="username" value="" class="form-control" placeholder="Tài khoản" />
            </div>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fa fa-lock text-danger"></i>
                    </span>
                </div>
                <input runat="server" id="input_Password" type="password" name="password" value="" class="form-control" placeholder="Mật khẩu" />

            </div>
            <div class="item">
                <div runat="server" id="div_Message" class="alert alert-danger">
                    Nhập thông tin tài khoản
                </div>
            </div>

            <div class="item">
                <asp:Button ID="Button_Login" OnClick="Button_Login_Click" Text="Đăng nhập" runat="server" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</asp:Content>
