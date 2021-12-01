<%@ Page Title="FeeInfo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeeInfo.aspx.cs" Inherits="ManagmentPortal.FeeInfo" %>
<%@ Register Src="~/StudentFeeGrid.ascx" TagName="studentFeeGrid" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Student Fee Details</h2>
    <div class="row">
        <div class="col-sm-12">
            &nbsp;
        </div>
    </div>
    <div class="row">
        <uc1:studentFeeGrid id="studentFeeGrid" runat="server" />
    </div>
    <div class="row">
        <div class="col-sm-12">
            &nbsp;
        </div>
    </div>
    <div class="row">
        
        <div class="col-sm-4">
            <asp:Button runat="server" Text="Add Fee Record" CssClass="btn btn-primary" ID="btnAddFee"  OnClick="btnAddFee_Click" />
        </div>
    </div>
   <%-- <asp:panel ID="studentinfo" runat="server" Enabled="false" Visible="false">
    <div class="row">
        <div class="col-sm-4">
                <asp:Label runat="server" ID="lblStudentName" Text="Student Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtStudentName" class="form-control" style="margin-top:10px;"></asp:TextBox>
        </div>
        <div class="col-sm-4">
            <asp:Label runat="server" ID="lblClass" Text="Class"></asp:Label>
            <asp:TextBox runat="server" ID="drpClass" class="form-control" style="margin-top:10px;"></asp:TextBox>
                
        </div>
        <div class="col-sm-4">
            <asp:Label runat="server" ID="lblSection" Text="Section"></asp:Label>
            <asp:TextBox runat="server" ID="txtSection" class="form-control" style="margin-top:10px;"></asp:TextBox>
        </div>
    </div>
    </asp:panel>--%>
    <div class="row">
        <div class="col-sm-12">
            &nbsp;
        </div>
    </div>
    <asp:Panel runat="server" ID="feeFormPanel" Style="display:none;">
        <div class="Row" style="background-color: gray;">
            <div class="col-sm-12" style="background-color: gray;">
                <asp:LinkButton runat="server" Text="X" OnClick="Close_Click"  style="margin-left: 97%;color:black;"></asp:LinkButton>
            </div>
        </div>
        <div class="jumbotron">
        <h2 style="font-family:fantasy">Fee Receipt</h2>
    </div>
<div class="row">
    <div class="col-sm-4">
            <asp:TextBox runat="server" id="txtStudentID" class="form-control" placeholder="Enter Student ID" type="text" ></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="chckStudentID" runat="server" AutoPostBack="true" OnCheckedChanged="chckStudentID_CheckedChanged"/><span>Get Details Of Student</span>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">&nbsp;</div>
</div>
    <div class="row" >
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblStudentName" Text="Student Name:" style="font-family:fantasy"></asp:Label>
        <asp:Label runat="server" ID="txtStudentName"></asp:Label>
               
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblClass" Text="Class:" style="font-family:fantasy"></asp:Label>
        <asp:Label runat="server" ID="txtClass" ></asp:Label>
                
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblSection" Text="Section:" style="font-family:fantasy"></asp:Label>
        <asp:Label runat="server" ID="txtSection" ></asp:Label>
    </div>
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
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblFee" Text="Fee:"></asp:Label>
        <asp:TextBox runat="server" ID="txtFee" class="form-control" style="margin-top:10px;"></asp:TextBox>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblMonth" Text="Month:"></asp:Label>
        <asp:DropDownList runat="server" ID="drpMonth" class="form-control" style="margin-top:10px;" AutoPostBack="true" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblYear" Text="Year:"></asp:Label>
        <asp:TextBox runat="server" ID="txtYear" class="form-control" style="margin-top:10px;"></asp:TextBox>
    </div>
</div>
        <div class="row">
    <div class="col-sm-12">&nbsp;</div>
</div>
<div class="row">
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblFine" Text="Fine:" ></asp:Label>
        <asp:Label runat="server" ID="txtFine" ></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-sm-4">
        <asp:Label runat="server" ID="lblTotal" Text="Total:" ></asp:Label>
        <asp:Label runat="server" ID="txtTotal" ></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">&nbsp;</div>
</div>
<div class="row">
    <div class="col-sm-4">
        <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" ID="btnSubmit" onClick="btnSubmit_Click"  />
    </div>
    <div class="col-sm-4">
        <asp:Button runat="server" Text="Cancel" CssClass="btn btn-danger" ID="btnCancel" onClick="btnCancel_Click" />
    </div>
</div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="modalPopUp" runat="server" TargetControlID="btnAddFee" PopupControlID="feeFormPanel" BackgroundCssClass="modalBackground"  />
    
</asp:Content>
