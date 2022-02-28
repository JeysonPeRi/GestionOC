<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Informe.aspx.cs" Inherits="GestionOC.Web.Informe" %>

<%@ Register Assembly="DevExpress.Web.v19.2, Version=19.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function UpdateGridHeight() {
            AgvInforme.SetHeight(0);
            var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
            if (document.body.scrollHeight > containerHeight)
                containerHeight = document.body.scrollHeight;
            AgvInforme.SetHeight(containerHeight - 268);
        }

        function EndCallbackAgvInforme(s, e) {
            if (e.command == 'REFRESH' && s.cpCodigo <= -1) {
                mensaje(s.cpMensaje, s.cpCodigo);
            }
            delete s.cpCodigo;
            delete s.cpMensaje;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxCallbackPanel ID="AcpInforme" ClientInstanceName="AcpInforme" runat="server" OnCallback="AcpInforme_Callback" Width="100%">
        <ClientSideEvents CallbackError="function(s, e) {
            alert(e.message);
        }"></ClientSideEvents>
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="AflInforme" runat="server">
                    <SettingsAdaptivity>
                        <GridSettings>
                            <Breakpoints>
                                <dx:LayoutBreakpoint Name="bp0" MaxWidth="0" ColumnCount="1"></dx:LayoutBreakpoint>
                            </Breakpoints>
                        </GridSettings>
                    </SettingsAdaptivity>
                    <Items>
                        <dx:LayoutItem ColSpan="1" ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxLabel runat="server" ID="LblTitulo" Text="INFORME" CssClass="Lbl-Titulo" Font-Bold="true" Font-Underline="false"></dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutGroup ColCount="4" ColumnCount="4" ColSpan="1" GroupBoxDecoration="None">
                            <GridSettings>
                                <Breakpoints>
                                    <dx:LayoutBreakpoint Name="bp1" MaxWidth="0" ColumnCount="4"></dx:LayoutBreakpoint>
                                </Breakpoints>
                            </GridSettings>
                            <Items>
                                <%--desde--%>
                                <dx:LayoutItem ColSpan="1" Caption="Desde">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit runat="server" ID="DetInicio" ClientInstanceName="DetInicio">
                                                <ClientSideEvents ValueChanged="function(s, e) {
                                                    AgvInforme.Refresh();
                                                    }"></ClientSideEvents>
                                                <CalendarProperties>
                                                    <FastNavProperties DisplayMode="Inline" />
                                                </CalendarProperties>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--hasta--%>
                                <dx:LayoutItem ColSpan="1" Caption="Hasta">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit runat="server" ID="DetFin" ClientInstanceName="DetFin">
                                                <ClientSideEvents ValueChanged="function(s, e) {
                                                    AgvInforme.Refresh();
                                                    }"></ClientSideEvents>
                                                <CalendarProperties>
                                                    <FastNavProperties DisplayMode="Inline" />
                                                </CalendarProperties>
                                                <DateRangeSettings StartDateEditID="DetInicio"></DateRangeSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--moneda--%>
                                <dx:LayoutItem ColSpan="1" Caption="Moneda">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="CbbMoneda" ClientInstanceName="CbbMoneda" runat="server" DataSourceID="OdsMoneda" TextField="Glosa" ValueField="Codigo" ClientEnabled="false">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                    AgvInforme.Refresh();
                                                    }"></ClientSideEvents>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--todos moneda--%>
                                <dx:LayoutItem ColSpan="1" Caption="Todos">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox runat="server" CheckState="Checked" ID="CbxTodoMoneda" ClientInstanceName="CbxTodoMoneda" Checked="True">
                                                <ClientSideEvents ValueChanged="function(s, e) {
                                                    CbbMoneda.SetEnabled(!s.GetChecked());
                                                    CbbMoneda.SetSelectedIndex(-1);
                                                    AgvInforme.Refresh();
                                                    }"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--rechazada--%>
                                <dx:LayoutItem ColSpan="1" Caption="Rechazada">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxRadioButtonList ID="RblRechazada" ClientInstanceName="RblRechazada" runat="server" ValueType="System.Int32" RepeatDirection="Horizontal" Border-BorderWidth="0">
                                                <ClientSideEvents ValueChanged="function(s, e) {
	                                                AgvInforme.Refresh();
                                                }"></ClientSideEvents>
                                                <Items>
                                                    <dx:ListEditItem Text="Si" Value="1"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="No" Value="0"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="Todas" Value="-1" Selected="true"></dx:ListEditItem>
                                                </Items>
                                            </dx:ASPxRadioButtonList>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--proveedor--%>
                                <dx:LayoutItem ColSpan="1" Caption="Proveedor">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxButtonEdit runat="server" ID="BetRut" ClientInstanceName="BetRut" ClientEnabled="false" Text="0">
                                                <ClientSideEvents ButtonClick="function(s, e) {
                                                    ApcAyudaCliente.Show();
                                                }"
                                                    ValueChanged="function(s, e) {
                                                    AcpInforme.PerformCallback(['ValidaRut',s.GetValue()]);
                                                    AgvInforme.Refresh();
                                                }"></ClientSideEvents>
                                                <Buttons>
                                                    <dx:EditButton>
                                                        <Image IconID="actions_search_16x16devav"></Image>
                                                    </dx:EditButton>
                                                </Buttons>
                                            </dx:ASPxButtonEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--razón social--%>
                                <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox runat="server" ID="TxtRazonSocial" ClientInstanceName="TxtRazonSocial" ReadOnly="True"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--todos proveedor--%>
                                <dx:LayoutItem ColSpan="1" Caption="Todos">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox runat="server" CheckState="Checked" ID="CbxTodoProveedor" ClientInstanceName="CbxTodoProveedor" Checked="True">
                                                <ClientSideEvents ValueChanged="function(s, e) {
                                                    BetRut.SetEnabled(!s.GetChecked());
                                                    BetRut.SetValue(0);
                                                    TxtRazonSocial.SetValue(&quot;&quot;);
                                                    AgvInforme.Refresh();
                                                    }"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                    <Styles>
                        <LayoutGroup CssClass="Frl-Grupo-caption" />
                        <LayoutItem CssClass="Frl-Item-caption" />
                    </Styles>
                </dx:ASPxFormLayout>
                <dx:ASPxGridView ID="AgvInforme" ClientInstanceName="AgvInforme" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="OdsInforme" KeyFieldName="Numero">
                    <ClientSideEvents EndCallback="function(s, e) {
                        EndCallbackAgvInforme(s, e);
                    }" ToolbarItemClick="function(s, e) {
	                switch (e.item.name) {
                        case 'Mostrar':
                            s.ExpandAllDetailRows();
                            break;
                        case 'Ocultar':
                            s.CollapseAllDetailRows();
                            break;
                        default:
                            break;
                    }
                    }"></ClientSideEvents>

                    <Settings ShowHeaderFilterButton="true" ShowFooter="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />

                    <SettingsPager Mode="ShowAllRecords"/>

                    <SettingsDetail ShowDetailRow="True" ExportMode="Expanded" />

                    <SettingsDataSecurity AllowEdit="False" AllowDelete="false" AllowInsert="false" />

                    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="Informe Orden de Compra" />

                    <Columns>
                        <dx:GridViewDataSpinEditColumn FieldName="Numero" Caption="NÚMERO" MinWidth="45" VisibleIndex="0"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataDateColumn FieldName="Fecha" Caption="FECHA" MinWidth="50" VisibleIndex="1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Lugar" Caption="LUGAR" MinWidth="50" VisibleIndex="2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Proveedor.RutFormateado" Caption="RUT" MinWidth="60" VisibleIndex="3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Proveedor.RazonSocial" Caption="RAZÓN SOCIAL" MinWidth="200" VisibleIndex="4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Moneda.Glosa" Caption="MONEDA" MinWidth="35" VisibleIndex="5"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="TipoCambio" Caption="TIPO CAMBIO" MinWidth="60" PropertiesSpinEdit-DisplayFormatString="n2" VisibleIndex="6"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataCheckColumn FieldName="AplicaImpuesto" Caption="APLICA IMP." MinWidth="35" VisibleIndex="7"></dx:GridViewDataCheckColumn>
                        <dx:GridViewDataCheckColumn FieldName="Rechazada" Caption="RECHAZADA" MinWidth="35" VisibleIndex="8"></dx:GridViewDataCheckColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Subtotal" Caption="SUBTOTAL" MinWidth="150" PropertiesSpinEdit-DisplayFormatString="n2" VisibleIndex="9"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Impuesto" Caption="IMPUESTO" MinWidth="150" PropertiesSpinEdit-DisplayFormatString="n2" VisibleIndex="10"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Total" Caption="TOTAL" MinWidth="150" PropertiesSpinEdit-DisplayFormatString="n2" VisibleIndex="11"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="SubtotalOrigen" Caption="SUBTOTAL PESOS" MinWidth="150" PropertiesSpinEdit-DisplayFormatString="n2" VisibleIndex="12"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="ImpuestoOrigen" Caption="IMPUESTO PESOS" MinWidth="150" PropertiesSpinEdit-DisplayFormatString="n2" VisibleIndex="13"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="TotalOrigen" Caption="TOTAL PESOS" MinWidth="150" PropertiesSpinEdit-DisplayFormatString="n2" VisibleIndex="14"></dx:GridViewDataSpinEditColumn>
                    </Columns>
                    <TotalSummary>
                        <dx:ASPxSummaryItem ShowInColumn="Subtotal" SummaryType="Sum" FieldName="Subtotal"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="Impuesto" SummaryType="Sum" FieldName="Impuesto"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="Total" SummaryType="Sum" FieldName="Total"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="SubtotalOrigen" SummaryType="Sum" FieldName="SubtotalOrigen"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="ImpuestoOrigen" SummaryType="Sum" FieldName="ImpuestoOrigen"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="TotalOrigen" SummaryType="Sum" FieldName="TotalOrigen"></dx:ASPxSummaryItem>
                    </TotalSummary>
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="AgvDetalleInforme" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="OdsDetalleInforme" KeyFieldName="Codigo"
                                OnBeforePerformDataSelect="AgvDetalleInforme_BeforePerformDataSelect">

                                <Settings ShowFooter="True" ShowHeaderFilterButton="true"></Settings>

                                <Columns>
                                    <dx:GridViewDataSpinEditColumn FieldName="Codigo" Caption="CÓDIGO" VisibleIndex="0">
                                        <PropertiesSpinEdit DisplayFormatString="g">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataTextColumn FieldName="Detalle" Caption="DETALLE" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="Cantidad" Caption="CANTIDAD" VisibleIndex="2">
                                        <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="PrecioUnitario" Caption="PRECIO UNITARIO" VisibleIndex="3">
                                        <PropertiesSpinEdit DisplayFormatString="n2"></PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="Total" Caption="TOTAL" VisibleIndex="4">
                                        <PropertiesSpinEdit DisplayFormatString="n2"></PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                </Columns>
                                <TotalSummary>
                                    <dx:ASPxSummaryItem ShowInColumn="Cantidad" SummaryType="Sum" FieldName="Cantidad"></dx:ASPxSummaryItem>
                                    <dx:ASPxSummaryItem ShowInColumn="PrecioUnitario" SummaryType="Sum" FieldName="PrecioUnitario"></dx:ASPxSummaryItem>
                                    <dx:ASPxSummaryItem ShowInColumn="Total" SummaryType="Sum" FieldName="Total"></dx:ASPxSummaryItem>
                                </TotalSummary>
                                <Images>
                                    <HeaderActiveFilter IconID="filter_filter_16x16"></HeaderActiveFilter>
                                    <HeaderFilter IconID="filter_masterfilter_16x16"></HeaderFilter>
                                </Images>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Name="Imprimir" DisplayMode="ImageWithText" Text="Imprimir" ToolTip="Imprimir" NavigateUrl="./Imprimir.aspx" Target="_blank">
                                    <Image IconID="print_print_16x16"></Image>
                                </dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="ExportToXlsx" DisplayMode="ImageWithText" Text="Excel" ToolTip="Excel">
                                    <Image IconID="xaf_action_export_toxls_svg_16x16"></Image>
                                </dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="Mostrar" DisplayMode="ImageWithText" Text="Mostrar Detalles" ToolTip="Mostrar Detalles">
                                    <Image IconID="spreadsheet_showdetail_16x16"></Image>
                                </dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="Ocultar" DisplayMode="ImageWithText" Text="Ocultar Detalles" ToolTip="Ocultar Detalles">
                                    <Image IconID="spreadsheet_hidedetail_16x16"></Image>
                                </dx:GridViewToolbarItem>
                            </Items>
                        </dx:GridViewToolbar>
                    </Toolbars>
                    <Images>
                        <HeaderActiveFilter IconID="filter_filter_16x16"></HeaderActiveFilter>
                        <HeaderFilter IconID="filter_masterfilter_16x16"></HeaderFilter>
                    </Images>
                </dx:ASPxGridView>
                <script type="text/javascript">
                    ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function (s, e) {
                        UpdateGridHeight();
                    });
                    ASPxClientControl.GetControlCollection().BrowserWindowResized.AddHandler(function (s, e) {
                        UpdateGridHeight();
                    });
                </script>
                <asp:ObjectDataSource runat="server" ID="OdsInforme" SelectMethod="ListarOrdenCompra" TypeName="GestionOC.Neg.OrdenCompraNeg" OnSelected="OdsInforme_Selected">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$AflInforme$DetInicio" PropertyName="Value" Name="desde" Type="DateTime"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$AflInforme$DetFin" PropertyName="Value" Name="hasta" Type="DateTime"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$AflInforme$CbbMoneda" PropertyName="Value" Name="monedaCodigo" Type="Int32"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$AflInforme$CbxTodoMoneda" PropertyName="Value" Name="monedaCodigoTodos" Type="Boolean"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$AflInforme$RblRechazada" PropertyName="Value" Name="rechazada" Type="Int32"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$AflInforme$BetRut" PropertyName="Text" Name="proveedorRut" Type="String"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$AflInforme$CbxTodoProveedor" PropertyName="Value" Name="proveedorRutTodos" Type="Boolean"></asp:ControlParameter>
                        <asp:Parameter DefaultValue="1" Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter DefaultValue="" Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="filtro" Type="Object"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource runat="server" ID="OdsDetalleInforme" SelectMethod="ListarItem" TypeName="GestionOC.Neg.ItemNeg">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="DetalleInformeNumero" DefaultValue="0" Name="ordenCompraNumero" Type="Int32"></asp:SessionParameter>

                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <dx:ASPxPopupControl ID="ApcAyudaCliente" runat="server" ClientInstanceName="ApcAyudaCliente" CssClass="Pup-Atr-L" CloseOnEscape="True" Modal="True"
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AutoUpdatePosition="true" CloseAnimationType="Slide" ShowHeader="True"
                    AllowDragging="true" DragElement="Header" HeaderText="AYUDA PROVEEDOR">
                    <CloseButtonImage IconID="actions_close_16x16" ToolTip="Cerrar" />
                    <HeaderStyle ForeColor="White" BackColor="#455668" Font-Size="Small" />
                    <ModalBackgroundStyle BackColor="Transparent" />
                    <ContentCollection>
                        <dx:PopupControlContentControl runat="server">
                            <dx:ASPxFormLayout ID="AflAyudaCliente" runat="server">
                                <Items>
                                    <dx:LayoutItem Caption="RAZÓN SOCIAL">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox runat="server" ID="TxtAyudaCliente">
                                                    <ClientSideEvents KeyUp="function(s, e) {
	                                                    AgvAyudaProveedor.Refresh();
                                                    }"></ClientSideEvents>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Styles>
                                    <LayoutGroup CssClass="Frl-Grupo-caption" />
                                    <LayoutItem CssClass="Frl-Item-caption" />
                                </Styles>
                            </dx:ASPxFormLayout>
                            <dx:ASPxGridView ID="AgvAyudaProveedor" ClientInstanceName="AgvAyudaProveedor" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="OdsAyudaProveedor">
                                <ClientSideEvents RowDblClick="function(s, e) {
                                    function datoRut(values) {
                                    ApcAyudaCliente.Hide();
                                    AcpInforme.PerformCallback(['ValidaRut',values]);
                                }
	                                s.GetRowValues(s.GetFocusedRowIndex(), 'Rut', datoRut);
                                }"></ClientSideEvents>

                                <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
                                <Settings ShowHeaderFilterButton="true" />
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="Rut" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RutFormateado" Caption="RUT" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RazonSocial" Caption="RAZÓN SOCIAL" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                </Columns>
                                <Images>
                                    <HeaderActiveFilter IconID="filter_filter_16x16"></HeaderActiveFilter>
                                    <HeaderFilter IconID="filter_masterfilter_16x16"></HeaderFilter>
                                </Images>
                            </dx:ASPxGridView>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:ASPxPopupControl>
                <asp:ObjectDataSource runat="server" ID="OdsMoneda" SelectMethod="ListarMoneda" TypeName="GestionOC.Neg.MonedaNeg">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter DefaultValue="" Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource runat="server" ID="OdsAyudaProveedor" SelectMethod="ListarProveedor" TypeName="GestionOC.Neg.ProveedorNeg">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpInforme$ApcAyudaCliente$AflAyudaCliente$TxtAyudaCliente" PropertyName="Text" Name="provedorRazonSocial" Type="String"></asp:ControlParameter>
                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
</asp:Content>
