<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StaffShifts.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server">
        </asp:EntityDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HovisDWConnectionString %>" SelectCommand="SELECT * FROM [t_PTLStaff_Details]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Recid" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Recid" HeaderText="Recid" InsertVisible="False" ReadOnly="True" SortExpression="Recid" />
                <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" SortExpression="StatusCode" />
                <asp:BoundField DataField="SiteCode" HeaderText="SiteCode" SortExpression="SiteCode" />
                <asp:BoundField DataField="PTLUserName" HeaderText="PTLUserName" SortExpression="PTLUserName" />
                <asp:BoundField DataField="PTLSAPName" HeaderText="PTLSAPName" SortExpression="PTLSAPName" />
                <asp:BoundField DataField="PTLUserID" HeaderText="PTLUserID" SortExpression="PTLUserID" />
                <asp:BoundField DataField="SchedShiftDuration" HeaderText="SchedShiftDuration" SortExpression="SchedShiftDuration" />
                <asp:BoundField DataField="RevisedShiftDuration" HeaderText="RevisedShiftDuration" SortExpression="RevisedShiftDuration" />
                <asp:BoundField DataField="ScheduledBreaks" HeaderText="ScheduledBreaks" SortExpression="ScheduledBreaks" />
                <asp:BoundField DataField="RevisedBreaks" HeaderText="RevisedBreaks" SortExpression="RevisedBreaks" />
                <asp:BoundField DataField="ReasonForChangeInShiftLength" HeaderText="ReasonForChangeInShiftLength" SortExpression="ReasonForChangeInShiftLength" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                <asp:BoundField DataField="DisiplinaryStage" HeaderText="DisiplinaryStage" SortExpression="DisiplinaryStage" />
                <asp:BoundField DataField="LastChangedBy" HeaderText="LastChangedBy" SortExpression="LastChangedBy" />
                <asp:BoundField DataField="LastChangedDate" HeaderText="LastChangedDate" SortExpression="LastChangedDate" />
                <asp:BoundField DataField="Confirmed" HeaderText="Confirmed" SortExpression="Confirmed" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
