<%@ Register TagPrefix="uc1" TagName="AppHeader" Src="../controls/AppHeader.ascx" %>
<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="WebUI.pages.Login" %>
<%@ Register TagPrefix="uc1" TagName="AppFooter" Src="../controls/AppFooter.ascx" %>
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
		<form runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="#006699">
						<uc1:AppHeader id="AppHeader1" runat="server"></uc1:AppHeader></TD>
				</TR>
  <TR>
    <TD>&nbsp;</TD></TR>
				<TR>
					<TD>
						<asp:Label id="Label3" runat="server" CssClass="HeaderText">Application Login Page</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<P>
							<BR>
							<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="500" align="center" border="0">
								<TR>
									<TD width="50%">
										<P align="right">
											<asp:Label id="Label1" runat="server" CssClass="PlainText">Email Address:</asp:Label></P>
									</TD>
									<TD>
										<asp:TextBox id="txtEmailAddress" runat="server" CssClass="PlainText">TestUser</asp:TextBox></TD>
								</TR>
								<TR>
									<TD width="50%">
										<P align="right">
											<asp:Label id="Label2" runat="server" CssClass="PlainText">Password:</asp:Label></P>
									</TD>
									<TD>
										<asp:TextBox id="txtPassword" runat="server" ReadOnly="True" CssClass="PlainText" TextMode="Password">TestPassword</asp:TextBox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<asp:Button id="btnOK" runat="server" Text="Click to Login"></asp:Button></TD>
								</TR>
							</TABLE>
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
		</form>
	</body>
</HTML>
