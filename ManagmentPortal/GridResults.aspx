<%@ Page Title="GridResults" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridResults.aspx.cs" Inherits="ManagmentPortal.GridResults" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
    <div class="row" >
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblStudentName" Text="Student Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtStudentName" class="form-control" style="margin-top:10px;" ></asp:TextBox>
                
            </div>
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblClass" Text="Class"></asp:Label>
                <asp:DropDownList runat="server" ID="drpClass" class="form-control" style="margin-top:10px;" AutoPostBack="true" OnSelectedIndexChanged="drpClass_SelectedIndexChanged"></asp:DropDownList>
                
            </div>
            <div class="col-sm-4">
                <asp:Button runat="server" Text="Search Now!" CssClass="btn btn-primary" ID="SearchNow" OnClick="SearchNow_Click" style="margin-top: 24px;" />
            </div>
            
    </div>
    <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
    <asp:Panel ID="GridViews" runat="server">
      <asp:GridView ID="searchResults" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="10" BackColor="#CCFFFF" BorderColor="#99CCFF" BorderStyle="Solid" OnSelectedIndexChanged="searchResults_SelectedIndexChanged"  >
          <AlternatingRowStyle BackColor="White" />
    <Columns >
        
        <asp:BoundField ItemStyle-Width="250px" DataField="StudentID" HeaderText="StudentID" visible="true" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:HyperLinkField ItemStyle-Width="250px" HeaderText="View" DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="StudentInfo.aspx?ID={0}" 
                Text="View Data" >
        <ItemStyle Width="250px" />
        </asp:HyperLinkField>
        <asp:BoundField ItemStyle-Width="250px" DataField="StudentName" HeaderText="Student Name"  >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="250px" DataField="FathersName" HeaderText="Father Name" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="250px" DataField="MothersName" HeaderText="Mother Name" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
    </Columns>
          <FooterStyle BackColor="#CCCCFF" />
          <HeaderStyle BackColor="#99CCFF" Font-Bold="True" />
          <PagerSettings FirstPageText="&amp;lt;&amp;lt;," />
          <PagerStyle BackColor="#CCCCFF" Font-Bold="True" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="True" Wrap="True" />
          <SelectedRowStyle BackColor="#FF3300" />
</asp:GridView>
        </asp:Panel>
</asp:Content>
