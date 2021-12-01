<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentFeeGrid.ascx.cs" Inherits="ManagmentPortal.StudentFeeGrid" %>

    <div class="row">
        <div class="col-sm-4">
                <asp:Label runat="server" ID="lblStudentID" Text="StudentID"></asp:Label>
                <asp:textbox runat="server" ID="txtStudentID" class="form-control" ></asp:textbox>
        </div>
        <div class="col-sm-4">
                <asp:Label runat="server" ID="lblMonth" Text="Month:"></asp:Label>
                <asp:DropDownList runat="server" ID="drpMonth" class="form-control"  AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <asp:Button runat="server" Text="Search Now!" CssClass="btn btn-primary" ID="SearchNow"  style="margin-top: 24px;" OnClick="SearchNow_Click" />
        </div>
    </div>
<div class="row">
    <div class="col-sm-12">&nbsp;</div>
</div>
<asp:Panel runat="server" ID="feeErrorlabel" Visible="false">
<div class="row">
        <div class="col-sm-8">
                <asp:Label runat="server" ID="Error" Text="No Result Found" style="color:red;" ></asp:Label>
                
        </div>
        
 </div>
 </asp:Panel>
<asp:Panel ID="GridViews" runat="server">
      <asp:GridView ID="searchResults" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="10" BackColor="#CCFFFF" BorderColor="#99CCFF" BorderStyle="Solid" OnSelectedIndexChanged="searchResults_SelectedIndexChanged"  >
          <AlternatingRowStyle BackColor="White" />
    <Columns >
        
        <asp:BoundField ItemStyle-Width="250px" DataField="StudentID" HeaderText="StudentID" visible="false" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:HyperLinkField ItemStyle-Width="250px"  HeaderText="View" DataNavigateUrlFields="StudentID"  DataNavigateUrlFormatString="FeeInfoDetails.aspx?ID={0}" 
                Text="View Data" target="_blank">
        <ItemStyle Width="250px" />
        </asp:HyperLinkField>
        <asp:BoundField ItemStyle-Width="250px" DataField="StudentName" HeaderText="Student Name"  >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="250px" DataField="Class" HeaderText="Class" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="250px" DataField="Section" HeaderText="Section" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="250px" DataField="Fees" HeaderText="Fees" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="250px" DataField="Fine" HeaderText="Fine" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <%--<asp:BoundField ItemStyle-Width="250px" DataField="FeeSubmissionDate" HeaderText="Fee Submitted" >
        <ItemStyle Width="250px" />
        </asp:BoundField>--%>
        <asp:BoundField ItemStyle-Width="250px" DataField="ForMonth" HeaderText="Month" >
        <ItemStyle Width="250px" />
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="250px" DataField="Total" HeaderText="Total Fee Submitted" >
        <ItemStyle Width="350px" />
        </asp:BoundField>
    </Columns>
          <FooterStyle BackColor="#CCCCFF" />
          <HeaderStyle BackColor="#99CCFF" Font-Bold="True" />
          <PagerSettings FirstPageText="&amp;lt;&amp;lt;," />
          <PagerStyle BackColor="#CCCCFF" Font-Bold="True" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="True" Wrap="True" />
          <SelectedRowStyle BackColor="#FF3300" />
</asp:GridView>
</asp:Panel>
   