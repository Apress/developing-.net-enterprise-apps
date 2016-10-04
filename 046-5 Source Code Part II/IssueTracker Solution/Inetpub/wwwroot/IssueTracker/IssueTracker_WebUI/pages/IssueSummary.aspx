<%@ Register TagPrefix="uc1" TagName="AppFooter" Src="../controls/AppFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AppMenu" Src="../controls/AppMenu.ascx" %>
<%@ Page language="c#" Codebehind="IssueSummary.aspx.cs" AutoEventWireup="false" Inherits="WebUI.pages.IssueSummary" %>
<%@ Register TagPrefix="uc1" TagName="AppHeader" Src="../controls/AppHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="ProgId" content="VisualStudio.HTML">
		<meta name="Originator" content="Microsoft Visual Studio .NET 7.1">
		<LINK href="../styles/issuetracker.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form runat="server" ID="Form1">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="#006699">
						<uc1:AppHeader id="AppHeader1" runat="server"></uc1:AppHeader></TD>
				</TR>
				<TR>
					<TD bgColor="gainsboro" style="HEIGHT: 19px" colSpan="1" rowSpan="1">
						<uc1:AppMenu id="AppMenu1" runat="server"></uc1:AppMenu></TD>
				</TR>
				<TR>
					<TD>&nbsp;<BR>
						<asp:Label id="Label3" runat="server" CssClass="HeaderText">Summary of Issues</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<P><BR>
							<asp:Label id="lblGreeting" runat="server" CssClass="GreetingText">Label</asp:Label><BR>
							<BR>
							<asp:DataGrid id="gridIssues" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="PlainText"
								BorderColor="#669999" BorderWidth="1px" GridLines="Horizontal">
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#006699"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="IssueID" HeaderText="IssueID">
										<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PriorityID" HeaderText="Priority">
										<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:HyperLinkColumn Target="_self" DataNavigateUrlField="IssueID" DataNavigateUrlFormatString="IssueDetails.aspx?IssueID={0}"
										DataTextField="Summary" HeaderText="Summary"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="EntryDate" HeaderText="Date">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
						</P>
						&nbsp;<BR>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<uc1:AppFooter id="AppFooter1" runat="server"></uc1:AppFooter></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
