<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ManagmentPortal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2 style="margin-left: 20%;">Welcome to Student Management System</h2>
    </div>

    <div class="row">
        <div class="col-sm-12">
        <div class="card text-white bg-primary mb-12" style="height: 55px;" >
            <div class="card-body" style="margin-left:180px;">
                <br />
                A Student management Portal is used to manage details of students and also to keep a track on there Fee records,
            </div>
        </div>
            </div>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Student Information Portal</h5>
                    <p class="card-text">To manage student information </p>
                    <asp:Button class="btn btn-primary" ID="btnInfoPortal" runat="server" Text="Click Here" OnClick="btnInfoPortal_Click"  href="~/StudentInfo"/>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Student Fee Portal</h5>
                    <p class="card-text">To manage student fee.</p>
                    <asp:Button class="btn btn-primary" ID="btnFeePortal" runat="server" Text="Click Here" OnClick="btnFeePortal_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
