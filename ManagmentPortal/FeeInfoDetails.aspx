<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeeInfoDetails.aspx.cs" MasterPageFile="~/Site.Master" Inherits="ManagmentPortal.FeeInfoDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function PrintPage() {
            
            window.print();
        }
    </script>
    <div class="jumbotron">
        <h2 style="font-family: fantasy">Fee Receipt</h2>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <asp:Label runat="server" ID="lblStudentID" style="font-family: fantasy" Text="Student ID : "></asp:Label>
        
            <asp:Label runat="server" ID="txtStudentID"></asp:Label>

        </div>
        <div class="col-sm-3">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblStudentName" Text="Student Name : "></asp:Label>
        
            <asp:Label runat="server" ID="txtStudentName"></asp:Label>

        </div>
        <div class="col-sm-3">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblClass" Text="Class : "></asp:Label>
        
            <asp:Label runat="server" ID="txtClass"></asp:Label>

        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">&nbsp;</div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblSection" Text="Section : "></asp:Label>
        
            <asp:Label runat="server" ID="txtSection"></asp:Label>
        </div>

        <asp:Panel ID="StreamPanel" runat="server">


            <div class="col-sm-3">
                <asp:Label runat="server" style="font-family: fantasy" ID="lblStream" Text="Stream : "></asp:Label>
            
                <asp:Label runat="server" ID="txtStream"></asp:Label>
            </div>

        </asp:Panel>
    </div>
    <div class="row">
        <div class="col-sm-12">&nbsp;</div>
    </div>
    <%--<div class="row">
    <div class="col-sm-12">
        <asp:Label  runat="server" ID="FeeReceipt" Text="Fee Receipt"></asp:Label>
    </div>
</div>--%>
    <div class="row">

        <div class="col-sm-3">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblMonth" Text="Month : "></asp:Label>
            <asp:Label runat="server" ID="drpMonthValue"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblDateOfSubmission" Text="Submission Date : "></asp:Label>
            <asp:Label runat="server" ID="txtSubmitDate"></asp:Label>
        </div>
        <div class="row">
            <div class="col-sm-12">&nbsp;</div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblFee" Text="Fee : "></asp:Label>
            <asp:Label runat="server" ID="txtFeeValue"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblFine" Text="Fine : "></asp:Label>
            <asp:Label runat="server" ID="txtFine"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">&nbsp;</div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <asp:Label runat="server" style="font-family: fantasy" ID="lblTotal" Text="Total Fees : "></asp:Label>
            <asp:Label runat="server" ID="txtTotal"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <hr />
        </div>
    </div>
    <asp:Button ID="printBtn" runat="server" class="btn btn-primary" Text="Print"  OnClientClick="javascript:PrintPage();"/>
</asp:Content>
