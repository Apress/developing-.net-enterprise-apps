<%@ Page language="c#" Codebehind="Help.aspx.cs" AutoEventWireup="false" Inherits="WebUI.pages.Help" %>
<%@ Register TagPrefix="uc1" TagName="AppFooter" Src="../controls/AppFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AppHeader" Src="../controls/AppHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="ProgId" content="VisualStudio.HTML">
		<meta name="Originator" content="Microsoft Visual Studio .NET 7.1">
		<LINK href="../styles/issuetracker.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<TR>
				<TD bgColor="#006699">
					<uc1:AppHeader id="AppHeader1" runat="server"></uc1:AppHeader></TD>
			</TR>
			<TR>
				<TD><BR>
					<asp:Label id="Label1" runat="server" CssClass="HeaderText">Online Help</asp:Label><BR>
				</TD>
			</TR>
			<TR>
				<TD>
					<P align="center"><BR>
						<BR>
						<asp:Label id="Label2" runat="server" CssClass="PlainText">Place your help text and links here.</asp:Label><BR>
						<BR>
					</P>
				</TD>
			</TR>
			<TR>
				<TD>
					<P align="center">
						<uc1:AppFooter id="AppFooter1" runat="server"></uc1:AppFooter></P>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
