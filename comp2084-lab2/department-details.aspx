﻿<%@ Page Title="Department Details" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="department-details.aspx.cs" Inherits="comp2084_lab2.department_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Department Details</h1>

    <h5>All fields are required</h5>
    <div class="form-group">
        <label for="txtName" class="col-sm-2">Name: *</label>
        <asp:TextBox ID="txtName" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtBudget" class="col-sm-2">Budget: *</label>
        <asp:TextBox ID="txtBudget" runat="server" type="number" required />
        <asp:RangeValidator runat="server" ControlToValidate="txtBudget" CssClass="label label-danger" 
            MinimumValue="0" MaximumValue="9999999" Type="Double" ErrorMessage="Must be greator than 0" />
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn bg-primary" OnClick="btnSave_Click" />
    </div>

</asp:Content>
