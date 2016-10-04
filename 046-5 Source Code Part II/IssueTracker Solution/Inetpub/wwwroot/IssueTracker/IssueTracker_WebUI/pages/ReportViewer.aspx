<%@ Page language="c#" Codebehind="ReportViewer.aspx.cs" AutoEventWireup="false" Inherits="WebUI.pages.ReportViewer" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReportViewer</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CR:CrystalReportViewer id="reportViewer1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 16px"
				runat="server"></CR:CrystalReportViewer>
		</form>
	</body>
</HTML>
