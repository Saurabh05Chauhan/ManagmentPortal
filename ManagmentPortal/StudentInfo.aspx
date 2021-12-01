<%@ Page Title="StudentInfo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="ManagmentPortal.StudentInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <%--<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=TextBox1.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%Y/%m/%d %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
  </script>--%>
  <div class="row">
    <%--<label for="Search">Student ID</label>
    <input type="text" class="form-control" id="StudentIDSearch" >
    <small id="emailHelp" class="form-text text-muted">Enter only valid ID</small>--%>
      <div class="col-lg-6">
          &nbsp;
      </div>
  </div>
    <div class="row">
        <asp:Panel runat="server" ID="btngoSearchPanel" >
        <div class="col-lg-6">
            <div class="input-group">
                <span class="input-group-btn">
                    <asp:Button  runat="server"  id="btnGo" class="btn btn-default"   Text="Go!" onclick="onSearchOfSID"/>
                </span>
                <asp:textbox runat="server" type="text" class="form-control"  id="SearchStudentID" placeholder="Search for Student ID"></asp:textbox>
            </div>
            <!-- /input-group -->
        </div>
            </asp:Panel>
        <div class="col-lg-3">
            <asp:Button class="btn btn-primary" ID="Search" runat="server" Text="Search" style="width:150px" OnClick="Search_Click" />
            <div class="row">
            <small id="searchHelp" style="margin-left:15px;" class="form-text text-muted">Search From Name and DOB</small></div>
        </div>
        <div class="col-lg-3" >
            <asp:Button class="btn btn-primary" ID="btnCreate" runat="server" Text="Create a new Student"  OnClick="btnCreate_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
    <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
    
    
    <asp:label runat="server" ID="lblError" class="label label-danger" Visible="false">error</asp:label>
    <asp:Label runat="server" ID="lblActiveChanged" class="label label-warning" Visible="false" style="font-size:inherit;">Want to make student as Active</asp:Label>
    <asp:CheckBox ID="chkActiveChanged" runat="server" OnCheckedChanged="Active_changed" AutoPostBack="true" visible="false"/>
    <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
    <asp:Panel runat="server" ID="StudentForm" Visible="false">    
    <div>
        <div class="row" style="background-color:aliceblue">
            <div class="col-sm-8">
                StudentID:
                <asp:Label runat="server" ID="lblStudentId" ></asp:Label>
            </div>
            
        </div>
        <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
        <div class="row" >
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblStudentName" Text="Student Name"></asp:Label><span style="color:red">*</span>
                <asp:TextBox runat="server" ID="txtStudentName" class="form-control" style="margin-top:10px;"></asp:TextBox>
                <small runat="server" id="lblStudentNameRequired" style="color:red" class="form-text text-muted" visible="false">Student Name is Required</small>
            </div>
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblClass" Text="Class"></asp:Label><span style="color:red">*</span>
                <asp:DropDownList runat="server" ID="drpClass" class="form-control" style="margin-top:10px;" OnSelectedIndexChanged="drpClass_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                <small runat="server" id="lblClassRequired" style="color:red" class="form-text text-muted" visible="false">Class is Required</small>
            </div>
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblSection" Text="Section"></asp:Label>
                <asp:TextBox runat="server" ID="txtSection" class="form-control" style="margin-top:10px;"></asp:TextBox>
            </div>
            
        </div>
        <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
        <div class="row">
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblStream" Text="Stream"></asp:Label>
                <asp:DropDownList runat="server" ID="drpStream" class="form-control" style="margin-top:10px;">
                    <asp:ListItem Text="--Select One--"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblFatherName" Text="Father Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtFatherName" class="form-control" style="margin-top:10px;"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblMotherName" Text="Mother Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtMotherName" class="form-control" style="margin-top:10px;"></asp:TextBox>
            </div>
            
        </div>
        <div class="row">
        <div class="col-sm-12">&nbsp</div>
            </div>
        <div class="row">
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblDateOfBirth" Text="Date Of Birth"></asp:Label><span style="color:red">*</span>
                <asp:TextBox placeHolder="dd-mm-yyyy" runat="server" ID="txtdateOfBirth" class="form-control" style="margin-top:10px;"></asp:TextBox>
                <small runat="server" id="lbldobrequired" style="color:red" class="form-text text-muted" visible="false">Date Of birth is Required</small>
               <cc1:CalendarExtender ID="cal1" PopupButtonID="txtdateOfBirth" runat="server" TargetControlID="txtdateOfBirth"  
                        Format="dd/MM/yyyy">  
               </cc1:CalendarExtender> 
                
            </div>
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblAdmissionDate" Text="AdmissionDate"></asp:Label><span style="color:red">*</span>
                <asp:textbox runat="server" ID="txtAdmissionDate" placeHolder="dd-mm-yyyy" class="form-control"  style="margin-top:10px;"></asp:textbox>
                <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="txtAdmissionDate" runat="server" TargetControlID="txtAdmissionDate"  
                        Format="dd/MM/yyyy">  
               </cc1:CalendarExtender>
               <small runat="server"  id="lbladRequired" style="color:red" class="form-text text-muted" visible="false">Admission Date is Required</small>
            </div>
            <div class="col-sm-4">
                <asp:Label runat="server" ID="lblAddress" Text="Address"></asp:Label>
                <asp:textbox runat="server" ID="txtAddress" class="form-control"  textmode="multiline" style="margin-top:10px;"></asp:textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">&nbsp</div>
        </div>
        <div class="row">
            <asp:Panel runat="server" ID="leavedatePanel" Enabled="false">
            <div class="col-sm-4" Visible="false">
                <asp:Label runat="server" ID="lblLeavingDate" Text="School Leaving Date"></asp:Label>
                <asp:textbox runat="server" placeHolder="dd-mm-yyyy" ID="txtLeaveDate"  class="form-control"  style="margin-top:10px;" ></asp:textbox>
                <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="txtLeaveDate" runat="server" TargetControlID="txtLeaveDate"  
                        Format="dd/MM/yyyy">  
               </cc1:CalendarExtender>
            </div>
                </asp:Panel>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">&nbsp</div>
    </div>
    <div class="row">
        <div class="col-lg-2" >
            <asp:Button class="btn btn-primary" ID="btnSubmit" runat="server" Text="Save" onclick="btnSave_Click" />
        </div>
        <div class="col-lg-2" >
            <asp:Button class="btn btn-primary" ID="btnCancel" runat="server" Text="Cancel"  />
        </div>
    </div>
        </asp:Panel>
    

</asp:Content>
