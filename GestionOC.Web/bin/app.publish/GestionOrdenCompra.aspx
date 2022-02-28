<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionOrdenCompra.aspx.cs" Inherits="GestionOC.Web.GestionOrdenCompra" %>

<%@ Register Assembly="DevExpress.Web.v19.2, Version=19.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/GestionOrdenCompra.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxCallbackPanel ID="AcpOrdenCompra" ClientInstanceName="AcpOrdenCompra" OnCallback="AcpOrdenCompra_Callback" runat="server" Width="100%">
        <ClientSideEvents EndCallback="function(s, e) { EndCallbackAcpOrdenCompra(s, e); }"
            CallbackError="function(s, e) { CallbackErrorAcpOrdenCompra(s, e); }"></ClientSideEvents>
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="AflOrdenCompra" runat="server" Width="100%">
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
                                    <dx:ASPxLabel runat="server" ID="LblTitulo" Text="GESTIÓN ORDEN DE COMPRA" CssClass="Lbl-Titulo" Font-Bold="true" Font-Underline="false"></dx:ASPxLabel>
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
                                                <ClientSideEvents ValueChanged="function(s, e) { CargarAgvOrdenCompra(); }"></ClientSideEvents>
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
                                                <ClientSideEvents ValueChanged="function(s, e) { CargarAgvOrdenCompra(); }"></ClientSideEvents>
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
                                <%--número--%>
                                <dx:LayoutItem ColSpan="1" Caption="N&#250;mero">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit runat="server" ID="SetNumero" ClientInstanceName="SetNumero" SpinButtons-ClientVisible="false" ClientEnabled="false" NumberType="Integer" Number="0" MaxLength="9">
                                                <ClientSideEvents Validation="function(s, e) { OperarSetNumero(s, e); }"></ClientSideEvents>
                                                <ValidationSettings Display="Dynamic" ErrorDisplayMode="None" SetFocusOnError="true">
                                                </ValidationSettings>
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <SpanRules>
                                        <dx:SpanRule BreakpointName="bp1" ColumnSpan="1" RowSpan="1"></dx:SpanRule>
                                    </SpanRules>
                                </dx:LayoutItem>
                                <%--todos número--%>
                                <dx:LayoutItem ColSpan="1" Caption="Todos">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox runat="server" CheckState="Checked" ID="CbxTodoOrdenCompra" Checked="True">
                                                <ClientSideEvents ValueChanged="function(s, e) { OperarCbxTodoOrdenCompra(s, e); }"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
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
                                            <dx:ASPxButtonEdit runat="server" ID="BetRut" ClientInstanceName="BetRut" ClientEnabled="false" Text="0" MaxLength="11">
                                                <ClientSideEvents ButtonClick="function(s, e) { ButtonClickBetRut(); }"
                                                    ValueChanged="function(s, e) { OperarBetRut(s, e); }"></ClientSideEvents>
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
                                            <dx:ASPxCheckBox runat="server" CheckState="Checked" ID="CbxTodoProveedor" Checked="True">
                                                <ClientSideEvents ValueChanged="function(s, e) { OperarCbxTodoProveedor(s, e); }"></ClientSideEvents>
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
                <dx:ASPxGridView ID="AgvOrdenCompra" ClientInstanceName="AgvOrdenCompra" runat="server" Width="100%" AutoGenerateColumns="False"
                    DataSourceID="OdsOrdenCompra" KeyFieldName="Numero" OnInitNewRow="AgvOrdenCompra_InitNewRow" OnRowValidating="AgvOrdenCompra_RowValidating"
                    OnToolbarItemClick="AgvOrdenCompra_ToolbarItemClick" OnFocusedRowChanged="AgvOrdenCompra_FocusedRowChanged"
                    OnDataBound="AgvOrdenCompra_DataBound">

                    <ClientSideEvents EndCallback="function(s, e) { EndCallbackAgvOrdenCompra(s, e); }"
                        CallbackError="function(s, e) { CallbackErrorAgvOrdenCompra(s, e); }"
                        ToolbarItemClick="function(s, e) { ToolbarItemClickAgvOrdenCompra(s, e); }"></ClientSideEvents>

                    <SettingsPager Mode="ShowAllRecords" />

                    <SettingsDetail ShowDetailRow="True" />

                    <SettingsDataSecurity AllowEdit="False" />

                    <Settings ShowHeaderFilterButton="true" VerticalScrollBarMode="Auto" />

                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="true" ProcessFocusedRowChangedOnServer="true" />

                    <EditFormLayoutProperties ColCount="4" ColumnCount="4">
                        <Items>
                            <dx:GridViewColumnLayoutItem ColumnName="Proveedor.RutFormateado" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Proveedor.RazonSocial" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Fecha" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Lugar" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Moneda.Codigo" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="TipoCambio" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="AplicaImpuesto" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Antecedentes" ColSpan="1" HorizontalAlign="Right" ShowCaption="False">
                                <Template>
                                    <dx:ASPxButton ID="BtnAgvOrdenCompraAntecedentes" runat="server" Text="Antecedentes" AutoPostBack="false" UseSubmitBehavior="false" CssClass="Btn-Aceptar-Atr">
                                        <ClientSideEvents Click="function(s, e) { ClickBtnAgvOrdenCompraAntecedentes(); }"></ClientSideEvents>
                                    </dx:ASPxButton>
                                </Template>
                            </dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="item" ShowCaption="False" ColSpan="4">
                                <Template>
                                    <dx:ASPxGridView ID="AgvItemOrdenCompra" ClientInstanceName="AgvItemOrdenCompra" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataSourceID="OdsItemOrdenCompra" KeyFieldName="Codigo" OnRowValidating="AgvItemOrdenCompra_RowValidating"
                                        OnRowInserting="AgvItemOrdenCompra_RowInserting" OnRowUpdating="AgvItemOrdenCompra_RowUpdating" OnRowDeleting="AgvItemOrdenCompra_RowDeleting"
                                        OnDataBound="AgvItemOrdenCompra_DataBound">

                                        <ClientSideEvents EndCallback="function(s, e) { EndCallbackAgvItemOrdenCompra(); }"
                                            CallbackError="function(s, e) { CallbackErrorAgvItemOrdenCompra(); }"></ClientSideEvents>

                                        <SettingsBehavior AllowFocusedRow="True" />

                                        <Settings ShowFooter="True" ShowHeaderFilterButton="true" />

                                        <EditFormLayoutProperties ColCount="4" ColumnCount="4">
                                            <Items>
                                                <dx:GridViewColumnLayoutItem ColumnName="Detalle" ColSpan="1"></dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="Cantidad" ColSpan="1"></dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="PrecioUnitario" ColSpan="1"></dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="Total" ColSpan="1"></dx:GridViewColumnLayoutItem>
                                                <dx:EditModeCommandLayoutItem ColSpan="4" ColumnSpan="4" HorizontalAlign="Right"></dx:EditModeCommandLayoutItem>
                                            </Items>
                                            <Styles>
                                                <LayoutGroup CssClass="Frl-Grupo-caption" />
                                                <LayoutItem CssClass="Frl-Item-caption" />
                                            </Styles>
                                        </EditFormLayoutProperties>

                                        <Columns>
                                            <dx:GridViewDataSpinEditColumn FieldName="Codigo" Caption="CÓDIGO" VisibleIndex="0">
                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                    <SpinButtons ClientVisible="False"></SpinButtons>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataTextColumn FieldName="Detalle" Caption="DETALLE" VisibleIndex="1">
                                                <PropertiesTextEdit MaxLength="150"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Cantidad" Caption="CANTIDAD" VisibleIndex="2">
                                                <PropertiesSpinEdit DisplayFormatString="g" ClientInstanceName="AgvItemOrdenCompraCantidad" MaxLength="9">
                                                    <SpinButtons ClientVisible="False"></SpinButtons>
                                                    <ClientSideEvents ValueChanged="function(s, e) { CalcularTotalesAgvItemOrdenCompraTotal(); }"></ClientSideEvents>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="PrecioUnitario" Caption="PRECIO UNITARIO" VisibleIndex="3">
                                                <PropertiesSpinEdit DisplayFormatString="n2" ClientInstanceName="AgvItemOrdenCompraPrecioUnitario" MaxLength="9">
                                                    <SpinButtons ClientVisible="False"></SpinButtons>
                                                    <ClientSideEvents ValueChanged="function(s, e) { CalcularTotalesAgvItemOrdenCompraTotal(); }"></ClientSideEvents>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="Total" Caption="TOTAL" ReadOnly="true" VisibleIndex="4">
                                                <PropertiesSpinEdit DisplayFormatString="n2" ClientInstanceName="AgvItemOrdenCompraTotal">
                                                    <SpinButtons ClientVisible="False"></SpinButtons>
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                        </Columns>

                                        <Toolbars>
                                            <dx:GridViewToolbar>
                                                <Items>
                                                    <dx:GridViewToolbarItem Command="New"></dx:GridViewToolbarItem>
                                                    <dx:GridViewToolbarItem Command="Edit"></dx:GridViewToolbarItem>
                                                    <dx:GridViewToolbarItem Command="Delete"></dx:GridViewToolbarItem>
                                                </Items>
                                            </dx:GridViewToolbar>
                                        </Toolbars>

                                        <TotalSummary>
                                            <dx:ASPxSummaryItem ShowInColumn="Cantidad" FieldName="Cantidad" SummaryType="Sum"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem ShowInColumn="PrecioUnitario" FieldName="PrecioUnitario" SummaryType="Sum"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem ShowInColumn="Total" FieldName="Total" SummaryType="Sum"></dx:ASPxSummaryItem>
                                        </TotalSummary>

                                        <SettingsCommandButton>
                                            <UpdateButton Text=" ">
                                                <Image ToolTip="Guardar" Height="30px" Url="Img/actualizar.png"></Image>
                                            </UpdateButton>
                                            <CancelButton Text=" ">
                                                <Image ToolTip="Cancelar" Height="30px" Url="Img/eliminar.png"></Image>
                                            </CancelButton>
                                        </SettingsCommandButton>

                                        <Images>
                                            <HeaderActiveFilter IconID="filter_filter_16x16"></HeaderActiveFilter>
                                            <HeaderFilter IconID="filter_masterfilter_16x16"></HeaderFilter>
                                        </Images>
                                    </dx:ASPxGridView>
                                </Template>
                            </dx:GridViewColumnLayoutItem>
                            <dx:EmptyLayoutItem ColSpan="1"></dx:EmptyLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Subtotal" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Impuesto" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Total" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="4" ColumnSpan="4" HorizontalAlign="Right" ShowCaption="False">
                                <Template>
                                    <dx:ASPxButton ID="BtnAgvOrdenCompraActualizar" runat="server" Text="Guardar" AutoPostBack="false" UseSubmitBehavior="false" CssClass="Btn-Aceptar-Atr">
                                        <ClientSideEvents Click="function(s, e) { OperarBtnAgvOrdenCompraActualizar(); }"></ClientSideEvents>
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="BtnAgvOrdenCompraCancelar" runat="server" Text="Cancelar" AutoPostBack="false" UseSubmitBehavior="false" CssClass="Btn-Cancelar-Atr">
                                        <ClientSideEvents Click="function(s, e) { OperarBtnAgvOrdenCompraCancelar(); }"></ClientSideEvents>
                                    </dx:ASPxButton>
                                </Template>
                            </dx:GridViewColumnLayoutItem>
                        </Items>
                        <Styles>
                            <LayoutGroup CssClass="Frl-Grupo-caption" />
                            <LayoutItem CssClass="Frl-Item-caption" />
                        </Styles>
                    </EditFormLayoutProperties>

                    <Columns>
                        <dx:GridViewDataSpinEditColumn FieldName="Numero" Caption="NÚMERO" ReadOnly="true" VisibleIndex="0">
                            <PropertiesSpinEdit DisplayFormatString="g">
                                <SpinButtons ClientVisible="False"></SpinButtons>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataDateColumn FieldName="Fecha" Caption="FECHA" VisibleIndex="1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Lugar" Caption="LUGAR" VisibleIndex="2">
                            <PropertiesTextEdit MaxLength="50"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataButtonEditColumn FieldName="Proveedor.RutFormateado" Caption="RUT" VisibleIndex="3">
                            <PropertiesButtonEdit MaxLength="15" ClientInstanceName="AgvOrdenCompraProveedorRut">
                                <ClientSideEvents ButtonClick="function(s, e) { ButtonClicAgvOrdenCompraProveedorRut(); }"
                                    ValueChanged="function(s, e) { OperarAgvOrdenCompraProveedorRut(s, e); }"></ClientSideEvents>
                                <Buttons>
                                    <dx:EditButton>
                                        <Image IconID="actions_search_16x16devav"></Image>
                                    </dx:EditButton>
                                </Buttons>
                            </PropertiesButtonEdit>
                        </dx:GridViewDataButtonEditColumn>
                        <dx:GridViewDataTextColumn FieldName="Proveedor.RazonSocial" Caption="RAZÓN SOCIAL" ReadOnly="true" VisibleIndex="4">
                            <PropertiesTextEdit ClientInstanceName="AgvOrdenCompraProveedorRazonSocial">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="Moneda.Codigo" Caption="MONEDA" VisibleIndex="5">
                            <PropertiesComboBox DataSourceID="OdsMoneda" TextField="Glosa" ValueField="Codigo"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="TipoCambio" Caption="TIPO CAMBIO" VisibleIndex="6">
                            <PropertiesSpinEdit DisplayFormatString="n2" MaxLength="9">
                                <SpinButtons ClientVisible="False"></SpinButtons>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataCheckColumn FieldName="AplicaImpuesto" Caption="APLICA IMPUESTO" VisibleIndex="7">
                            <PropertiesCheckEdit ClientInstanceName="AgvOrdenCompraAplicaImpuesto">
                                <ClientSideEvents ValueChanged="function(s, e) { CalcularTotalesAgvOrdenCompra(); }"></ClientSideEvents>
                            </PropertiesCheckEdit>
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Subtotal" Caption="SUBTOTAL" ReadOnly="true" VisibleIndex="8">
                            <PropertiesSpinEdit DisplayFormatString="n2" ClientInstanceName="AgvOrdenCompraSubtotal">
                                <SpinButtons ClientVisible="False"></SpinButtons>
                                <ClientSideEvents ValueChanged="function(s, e) { CalcularTotalesAgvOrdenCompra(); }"></ClientSideEvents>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Impuesto" Caption="IMPUESTO" ReadOnly="true" VisibleIndex="9">
                            <PropertiesSpinEdit DisplayFormatString="n2" ClientInstanceName="AgvOrdenCompraImpuesto">
                                <SpinButtons ClientVisible="False"></SpinButtons>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Total" Caption="TOTAL" ReadOnly="true" VisibleIndex="10">
                            <PropertiesSpinEdit DisplayFormatString="n2" ClientInstanceName="AgvOrdenCompraTotal">
                                <SpinButtons ClientVisible="False"></SpinButtons>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>

                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="AgvDetalleOrdenCompra" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="OdsDetalleOrdenCompra" KeyFieldName="Codigo"
                                OnBeforePerformDataSelect="AgvDetalleOrdenCompra_BeforePerformDataSelect">

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
                        <dx:GridViewToolbar Name="TbrOrdenCompra">
                            <Items>
                                <dx:GridViewToolbarItem Command="New" Name="Nuevo" Visible="false"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="Delete" Name="Eliminar" Text="Rechazar" Visible="false"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="Imprimir" DisplayMode="ImageWithText" Text="Imprimir" ToolTip="Imprimir" NavigateUrl="./Imprimir.aspx" Target="_blank" Visible="false">
                                    <Image IconID="print_print_16x16"></Image>
                                </dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="Antecedentes" DisplayMode="ImageWithText" Text="Antecedentes" ToolTip="Antecedentes" Visible="false">
                                    <Image IconID="iconbuilder_actions_folderclose_svg_16x16"></Image>
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
                                                    <ClientSideEvents KeyUp="function(s, e) { CargarAgvAyudaProveedor(); }"></ClientSideEvents>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:ASPxFormLayout>
                            <dx:ASPxGridView ID="AgvAyudaProveedor" ClientInstanceName="AgvAyudaProveedor" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="OdsAyudaProveedor">
                                <ClientSideEvents RowDblClick="function(s, e) { RowDblClickAgvAyudaProveedor(s, e); }"></ClientSideEvents>

                                <SettingsBehavior AllowFocusedRow="True" />

                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="Rut" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RutFormateado" Caption="RUT" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RazonSocial" Caption="RAZÓN SOCIAL" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:ASPxPopupControl>
                <dx:ASPxPopupControl ID="ApcAntecedentes" ClientInstanceName="ApcAntecedentes" runat="server" CssClass="Pup-Atr-L" CloseOnEscape="True" Modal="True"
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AutoUpdatePosition="true" CloseAnimationType="Slide" ShowHeader="True"
                    AllowDragging="true" DragElement="Header" HeaderText="ANTECEDENTES">
                    <CloseButtonImage IconID="actions_close_16x16" ToolTip="Cerrar" />
                    <HeaderStyle ForeColor="White" BackColor="#455668" Font-Size="Small" />
                    <ModalBackgroundStyle BackColor="Transparent" />
                    <ContentCollection>
                        <dx:PopupControlContentControl>
                            <dx:ASPxFileManager ID="AfmAntecedentes" ClientInstanceName="AfmAntecedentes" runat="server" Width="100%">
                                <SettingsFolders Visible="false" />
                                <SettingsToolbar ShowFilterBox="false" ShowPath="true" />
                                <SettingsEditing AllowDelete="false" AllowRename="false" AllowDownload="true" />
                                <Settings AllowedFileExtensions=".doc,.pdf,.jpg,.png" EnableMultiSelect="true" RootFolder="~/App_Data/Antecedentes/" ThumbnailFolder="~/Thumb/" />
                                <SettingsUpload ShowUploadPanel="false" Enabled="false">
                                    <AdvancedModeSettings EnableMultiSelect="true" ExternalDropZoneID="AfmAntecedentes" EnableDragAndDrop="true"></AdvancedModeSettings>
                                </SettingsUpload>
                            </dx:ASPxFileManager>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:ASPxPopupControl>
                <asp:ObjectDataSource runat="server" ID="OdsOrdenCompra" SelectMethod="ListarOrdenCompra" TypeName="GestionOC.Neg.OrdenCompraNeg" InsertMethod="GuardarOrdenCompra" OnSelected="OdsOrdenCompra_Selected" OnInserted="OdsOrdenCompra_Inserted" OnDeleted="OdsOrdenCompra_Deleted" DeleteMethod="RechazarOrdenCompra">
                    <DeleteParameters>
                        <asp:Parameter Name="numero" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="numero" DefaultValue="0" Type="Int32"></asp:Parameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor6" PropertyName="Value" Name="tipoCambio" Type="Double"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor7" PropertyName="Value" Name="aplicaImpuesto" Type="Boolean"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor1" PropertyName="Value" Name="fecha" Type="DateTime"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor2" PropertyName="Value" Name="lugar" Type="String"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor8" PropertyName="Value" Name="subtotal" Type="Double"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor9" PropertyName="Value" Name="impuesto" Type="Double"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor10" PropertyName="Value" Name="total" Type="Double"></asp:ControlParameter>
                        <asp:Parameter Name="rechazada" DefaultValue="false" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="empresaCodigo" DefaultValue="1" Type="Int32"></asp:Parameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor5" PropertyName="Value" Name="monedaCodigo" Type="Int32"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$AgvOrdenCompra$DXEFL$DXEditor3" PropertyName="Value" Name="proveedorRut" Type="String"></asp:ControlParameter>
                        <asp:SessionParameter SessionField="ItemsOrdenCompra" DefaultValue="" Name="items" Type="Object"></asp:SessionParameter>

                        <asp:Parameter Direction="Output" Name="ordenCompraNumeroActualizado" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ContentPlaceHolder1$AcpOrdenCompra$AflOrdenCompra$DetInicio" PropertyName="Value" Name="desde" Type="DateTime"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ContentPlaceHolder1$AcpOrdenCompra$AflOrdenCompra$DetFin" PropertyName="Value" DefaultValue="" Name="hasta" Type="DateTime"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ContentPlaceHolder1$AcpOrdenCompra$AflOrdenCompra$SetNumero" PropertyName="Number" DefaultValue="0" Name="ordenCompraNumero" Type="Int32"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ContentPlaceHolder1$AcpOrdenCompra$AflOrdenCompra$CbxTodoOrdenCompra" PropertyName="Value" DefaultValue="true" Name="ordenCompraNumeroTodos" Type="Boolean"></asp:ControlParameter>
                        <asp:Parameter Name="rechazada" DefaultValue="false" Type="Boolean"></asp:Parameter>
                        <asp:ControlParameter ControlID="ContentPlaceHolder1$AcpOrdenCompra$AflOrdenCompra$BetRut" PropertyName="Text" DefaultValue="0" Name="proveedorRut" Type="String"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="ContentPlaceHolder1$AcpOrdenCompra$AflOrdenCompra$CbxTodoProveedor" PropertyName="Value" DefaultValue="true" Name="proveedorRutTodos" Type="Boolean"></asp:ControlParameter>

                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource runat="server" ID="OdsDetalleOrdenCompra" SelectMethod="ListarItem" TypeName="GestionOC.Neg.ItemNeg">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="DetalleOrdenNumero" DefaultValue="0" Name="ordenCompraNumero" Type="Int32"></asp:SessionParameter>

                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource runat="server" ID="OdsItemOrdenCompra" SelectMethod="ItemsOrdenCompra" TypeName="GestionOC.Web.GestionOrdenCompra"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="OdsMoneda" runat="server" SelectMethod="ListarMoneda" TypeName="GestionOC.Neg.MonedaNeg">
                    <SelectParameters>
                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource runat="server" ID="OdsAyudaProveedor" SelectMethod="ListarProveedor" TypeName="GestionOC.Neg.ProveedorNeg">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ctl00$ASPxPanelPrincipal$ContentPlaceHolder1$AcpOrdenCompra$ApcAyudaCliente$AflAyudaCliente$TxtAyudaCliente" PropertyName="Text" Name="provedorRazonSocial" Type="String"></asp:ControlParameter>
                        <asp:Parameter Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <dx:ASPxCallback ID="AcbOrdenCompra" ClientInstanceName="AcbOrdenCompra" OnCallback="AcbOrdenCompra_Callback" runat="server">
        <ClientSideEvents EndCallback="function(s, e) { EndCallbackAcbOrdenCompra(s, e) }"></ClientSideEvents>
    </dx:ASPxCallback>
</asp:Content>
