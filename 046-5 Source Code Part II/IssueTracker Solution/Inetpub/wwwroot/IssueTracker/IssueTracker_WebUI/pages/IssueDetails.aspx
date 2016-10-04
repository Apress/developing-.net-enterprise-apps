<%@ Register TagPrefix="uc1" TagName="AppHeader" Src="../controls/AppHeader.ascx" %>
<%@ Page language="c#" Codebehind="IssueDetails.aspx.cs" AutoEventWireup="false" Inherits="WebUI.pages.IssueDetails" %>
<%@ Register TagPrefix="uc1" TagName="AppMenu" Src="../controls/AppMenu.ascx" %>
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
					<TD bgColor="gainsboro">
						<uc1:AppMenu id="AppMenu1" runat="server"></uc1:AppMenu></TD>
				</TR>
				<TR>
					<TD>&nbsp;<BR>
						<asp:Label id="Label8" runat="server" CssClass="HeaderText">View Requirement Details</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<P><BR>
							<asp:Label id="lblError" runat="server" ForeColor="Red" CssClass="ErrorText"></asp:Label><BR>
							<BR>
							<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="400" align="center" border="0">
								<TR>
									<TD width="50%">
										<P align="left">
											<asp:Label id="Label1" runat="server" CssClass="PlainText">Entry Date:</asp:Label></P>
									</TD>
									<TD width="50%">
										<asp:TextBox id="Issue_EntryDate" runat="server" CssClass="PlainText"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>
										<P align="left">
											<asp:Label id="Label2" runat="server" CssClass="PlainText">Issue ID:</asp:Label></P>
									</TD>
									<TD>
										<asp:TextBox id="Issue_IssueID" runat="server" CssClass="PlainText"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>
										<P align="left">
											<asp:Label id="Label3" runat="server" CssClass="PlainText">Type:</asp:Label></P>
									</TD>
									<TD>
										<asp:DropDownList id="Issue_TypeID" runat="server" CssClass="PlainText"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD>
										<P align="left">
											<asp:Label id="Label4" runat="server" CssClass="PlainText">Status:</asp:Label></P>
									</TD>
									<TD>
										<asp:DropDownList id="Issue_StatusID" runat="server" CssClass="PlainText"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD>
										<P align="left">
											<asp:Label id="Label5" runat="server" CssClass="PlainText">Priority:</asp:Label></P>
									</TD>
									<TD>
										<asp:DropDownList id="Issue_PriorityID" runat="server" CssClass="PlainText"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD>
										<asp:Label id="Label6" runat="server" CssClass="PlainText">Summary:</asp:Label></TD>
									<TD>
										<asp:TextBox id="Issue_Summary" runat="server" Width="240px" CssClass="PlainText"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<asp:Label id="Label7" runat="server" CssClass="PlainText">Description:</asp:Label></TD>
									<TD>
										<asp:TextBox id="Issue_Description" runat="server" Width="240px" Height="88px" Rows="8" CssClass="PlainText"
											TextMode="MultiLine"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<asp:Button id="btnOK" runat="server" Text="  OK  "></asp:Button>&nbsp;
										<asp:Button id="btnCancel" runat="server" Text="Cancel"></asp:Button></TD>
								</TR>
							</TABLE>
							&nbsp;
							<BR>
							&nbsp;
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
