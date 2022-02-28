<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Parametro.Impuesto.aspx.cs" Inherits="GestionOC.Web.Parametro_Impuesto" %>

<%@ Register Assembly="DevExpress.Web.v19.2, Version=19.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function EndCallbackAgvImpuesto(s, e) {
            if (e.command == 'REFRESH' && s.cpCodigo <= -1) {
                mensaje(s.cpMensaje, s.cpCodigo);
            }
            if (e.command != 'REFRESH' && s.cpCodigo != undefined) {
                mensaje(s.cpMensaje, s.cpCodigo);
            }
            delete s.cpCodigo;
            delete s.cpMensaje;
        }

        function EndCallbackAcpImpuesto(s, e) {
            if (s.cpCodigo != undefined && s.cpMensaje != undefined) {
                mensaje(s.cpMensaje, s.cpCodigo);
            }
            delete s.cpCodigo;
            delete s.cpMensaje;
        }
        function UpdateGridHeight() {
            AgvImpuesto.SetHeight(0);
            var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
            if (document.body.scrollHeight > containerHeight)
                containerHeight = document.body.scrollHeight;
            AgvImpuesto.SetHeight(containerHeight - 191);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxCallbackPanel ID="AcpImpuesto" ClientInstanceName="AcpImpuesto" runat="server" Width="100%">
        <ClientSideEvents EndCallback="function(s, e) {
            EndCallbackAcpImpuesto(s, e);
        }"
            CallbackError="function(s, e) {
            alert(e.message);
        }"></ClientSideEvents>
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="AflImpuesto" runat="server">
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
                                    <dx:ASPxLabel runat="server" ID="LblTitulo" Text="IMPUESTO" CssClass="Lbl-Titulo" Font-Bold="true" Font-Underline="false"></dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <Styles>
                        <LayoutGroup CssClass="Frl-Grupo-caption" />
                        <LayoutItem CssClass="Frl-Item-caption" />
                    </Styles>
                </dx:ASPxFormLayout>
                <dx:ASPxGridView ID="AgvImpuesto" ClientInstanceName="AgvImpuesto" runat="server" AutoGenerateColumns="False" DataSourceID="OdsImpuesto" KeyFieldName="Codigo" Width="100%"
                    OnRowValidating="AgvImpuesto_RowValidating">
                    <ClientSideEvents EndCallback="function(s, e) {
                        EndCallbackAgvImpuesto(s, e);
                    }"
                        CallbackError="function(s, e) {
                        alert(e.message);
                    }"></ClientSideEvents>

                    <Settings ShowHeaderFilterButton="true" VerticalScrollBarMode="Auto" />

                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="true" />

                    <SettingsDataSecurity AllowEdit="False" />

                    <EditFormLayoutProperties ColCount="4" ColumnCount="4">
                        <Items>
                            <dx:GridViewColumnLayoutItem ColumnName="PorcentajeCompleto" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Fecha" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnSpan="1" HorizontalAlign="Right" ShowCaption="False">
                                <Template>
                                    <dx:ASPxButton ID="BtnAgvImpuestoActualizar" runat="server" Text="Guardar" AutoPostBack="false" UseSubmitBehavior="false" CssClass="Btn-Aceptar-Atr">
                                        <ClientSideEvents Click="function(s, e) {
                                        if(confirm('Se dispone a guardar el registro. ¿Está seguro?')){
                                            AgvImpuesto.UpdateEdit();}
                                        }"></ClientSideEvents>
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="BtnAgvImpuestoCancelar" runat="server" Text="Cancelar" AutoPostBack="false" UseSubmitBehavior="false" CssClass="Btn-Cancelar-Atr">
                                        <ClientSideEvents Click="function(s, e) {
                                        if(confirm('Se dispone a cancelar cambios del registro. ¿Está seguro?')){
                                            AgvImpuesto.CancelEdit();}
                                        }"></ClientSideEvents>
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
                        <dx:GridViewDataSpinEditColumn FieldName="Codigo" Caption="CÓDIGO" VisibleIndex="0"></dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="PorcentajeCompleto" Caption="PORCENTAJE" VisibleIndex="1">
                            <PropertiesSpinEdit DisplayFormatString="g" NumberType="Integer" MaxLength="2">
                                <SpinButtons ClientVisible="False"></SpinButtons>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataDateColumn FieldName="Fecha" Caption="FECHA" VisibleIndex="2"></dx:GridViewDataDateColumn>
                    </Columns>
                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Command="New" Visible="false"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="Delete" Visible="false"></dx:GridViewToolbarItem>
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
                <asp:ObjectDataSource runat="server" ID="OdsImpuesto" SelectMethod="ListarImpuesto" TypeName="GestionOC.Neg.ImpuestoNeg" OnSelected="OdsImpuesto_Selected" OnInserted="OdsImpuesto_Inserted" OnDeleted="OdsImpuesto_Deleted" InsertMethod="GuardarImpuesto" DeleteMethod="EliminarImpuesto">
                    <DeleteParameters>
                        <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="codigoSalida" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="porcentajeCompleto" Type="Single"></asp:Parameter>
                        <asp:Parameter Name="fecha" Type="DateTime"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="codigoSalida" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter DefaultValue="" Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
</asp:Content>
