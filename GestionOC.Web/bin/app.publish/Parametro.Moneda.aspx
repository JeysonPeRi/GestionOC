<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Parametro.Moneda.aspx.cs" Inherits="GestionOC.Web.Parametro_Moneda" %>

<%@ Register Assembly="DevExpress.Web.v19.2, Version=19.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/Parametro.Moneda.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxCallbackPanel ID="AcpMoneda" ClientInstanceName="AcpMoneda" runat="server" Width="100%">
        <ClientSideEvents EndCallback="function(s, e) {
            EndCallbackAcpMoneda(s, e);
        }"
            CallbackError="function(s, e) {
            alert(e.message);
        }"></ClientSideEvents>
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="AflMoneda" runat="server">
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
                                    <dx:ASPxLabel runat="server" ID="LblTitulo" Text="MONEDA" CssClass="Lbl-Titulo" Font-Bold="true" Font-Underline="false"></dx:ASPxLabel>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <Styles>
                        <LayoutGroup CssClass="Frl-Grupo-caption" />
                        <LayoutItem CssClass="Frl-Item-caption" />
                    </Styles>
                </dx:ASPxFormLayout>
                <dx:ASPxGridView ID="AgvMoneda" ClientInstanceName="AgvMoneda" runat="server" AutoGenerateColumns="False" DataSourceID="OdsMoneda" Width="100%" KeyFieldName="Codigo"
                    OnRowValidating="AgvMoneda_RowValidating">
                    <ClientSideEvents EndCallback="function(s, e) {
                        EndCallbackAgvMoneda(s, e);
                    }"
                        CallbackError="function(s, e) {
                        alert(e.message);
                    }"></ClientSideEvents>

                    <Settings ShowHeaderFilterButton="true" VerticalScrollBarMode="Auto" />

                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="true" />

                    <EditFormLayoutProperties ColCount="4" ColumnCount="4">
                        <Items>
                            <dx:GridViewColumnLayoutItem ColumnName="Codigo" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Glosa" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Simbolo" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnSpan="1" HorizontalAlign="Right" ShowCaption="False">
                                <Template>
                                    <dx:ASPxButton ID="BtnAgvMonedaActualizar" runat="server" Text="Guardar" AutoPostBack="false" UseSubmitBehavior="false" CssClass="Btn-Aceptar-Atr">
                                        <ClientSideEvents Click="function(s, e) {
                                        if(confirm('Se dispone a guardar el registro. ¿Está seguro?')){
                                            AgvMoneda.UpdateEdit();}
                                        }"></ClientSideEvents>
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="BtnAgvMonedaCancelar" runat="server" Text="Cancelar" AutoPostBack="false" UseSubmitBehavior="false" CssClass="Btn-Cancelar-Atr">
                                        <ClientSideEvents Click="function(s, e) {
                                        if(confirm('Se dispone a cancelar cambios del registro. ¿Está seguro?')){
                                            AgvMoneda.CancelEdit();}
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
                        <dx:GridViewDataSpinEditColumn VisibleIndex="0" FieldName="Codigo" Caption="CÓDIGO">
                            <PropertiesSpinEdit DisplayFormatString="g" NumberType="Integer" MaxLength="9">
                                <SpinButtons ClientVisible="False"></SpinButtons>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataTextColumn FieldName="Glosa" Caption="GLOSA" VisibleIndex="1">
                            <PropertiesTextEdit MaxLength="50"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Simbolo" Caption="SÍMBOLO" VisibleIndex="2">
                            <PropertiesTextEdit MaxLength="5"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Command="New" Visible="false"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="Edit" Visible="false"></dx:GridViewToolbarItem>
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
                <asp:ObjectDataSource runat="server" ID="OdsMoneda" SelectMethod="ListarMoneda" TypeName="GestionOC.Neg.MonedaNeg" OnSelected="OdsMoneda_Selected" OnInserted="OdsMoneda_Inserted" OnUpdated="OdsMoneda_Updated" OnDeleted="OdsMoneda_Deleted" UpdateMethod="GuardarActualizarMoneda" InsertMethod="GuardarActualizarMoneda" DeleteMethod="EliminarMoneda">
                    <DeleteParameters>
                        <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="codigoSalida" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="glosa" Type="String"></asp:Parameter>
                        <asp:Parameter Name="simbolo" Type="String"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="codigoSalida" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Direction="Output" Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter DefaultValue="" Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="glosa" Type="String"></asp:Parameter>
                        <asp:Parameter Name="simbolo" Type="String"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="codigoSalida" Type="Int32"></asp:Parameter>
                        <asp:Parameter Direction="Output" Name="mensaje" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
</asp:Content>
