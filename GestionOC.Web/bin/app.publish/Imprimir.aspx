<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imprimir.aspx.cs" Inherits="GestionOC.Web.Imprimir" %>

<%@ Register Assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxWebDocumentViewer runat="server" ID="WdvOrdenCompra"></dx:ASPxWebDocumentViewer>
    </form>
</body>
</html>
