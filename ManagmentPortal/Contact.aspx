<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ManagmentPortal.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        We Dont have any Physical Address<br />
        Kindly Call<br />
        <abbr title="Phone">P:</abbr>
        8006638142
    </address>

    <address>
        <strong>Email Us On:</strong>   <a href="csaurabh660@gmail.com">csaurabh660@gmail.com</a><br />
        <%--<strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
    </address>
</asp:Content>
