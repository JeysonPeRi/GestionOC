var BotonProveedorRut;

function EndCallbackAcpOrdenCompra(s, e) {
    if (s.cpCodigo != null && s.cpCodigo != undefined &&
        s.cpMensaje != null && s.cpMensaje != undefined) {
        mensaje(s.cpMensaje, s.cpCodigo);
        delete s.cpCodigo;
        delete s.cpMensaje;
    }
}

function CallbackErrorAcpOrdenCompra(s, e) {
    alert(e.message);
}

function EndCallbackAgvOrdenCompra(s, e) {
    if (e.command == 'UPDATEEDIT') {
        mensaje(s.cpMensaje, s.cpCodigo);
        if (s.cpCodigo >= 1) {
            window.open('././Imprimir.aspx');
        }
    }
    if (e.command == 'REFRESH' && s.cpCodigo <= -1) {
        mensaje(s.cpMensaje, s.cpCodigo);
    }
    if (e.command == 'DELETEROW') {
        mensaje(s.cpMensaje, s.cpCodigo);
    }
    delete s.cpCodigo;
    delete s.cpMensaje;
}

function CallbackErrorAgvOrdenCompra(s, e) {
    alert(e.message);
}

function ToolbarItemClickAgvOrdenCompra(s, e) {
    if (e.item.name === 'Antecedentes') {
        if (AgvOrdenCompra.cpCarpeta != null && AgvOrdenCompra.cpCarpeta != undefined) {
            AfmAntecedentes.SetCurrentFolderPath(AgvOrdenCompra.cpCarpeta);
            ApcAntecedentes.Show();
        }
    }
}

function EndCallbackAgvItemOrdenCompra() {
    CalcularTotalesAgvOrdenCompra();
}

function CallbackErrorAgvItemOrdenCompra() {
    alert(e.message);
}

function EndCallbackAcbOrdenCompra(s, e) {
    if (s.cpRut != null && s.cpRut != undefined &&
        s.cpRazonSocial != null && s.cpRazonSocial != undefined) {
        switch (BotonProveedorRut) {
            case 'AgvOrdenCompraProveedorRut':
                AgvOrdenCompraProveedorRut.SetValue(s.cpRut);
                AgvOrdenCompraProveedorRazonSocial.SetValue(s.cpRazonSocial);
                break;
            case 'BetRut':
                BetRut.SetValue(s.cpRut);
                TxtRazonSocial.SetValue(s.cpRazonSocial);
                break;
            default:
                break;
        }
        delete s.cpRutEdit;
        delete s.cpRazonSocialEdit;
    }
    if (s.cpCodigo != null && s.cpCodigo != undefined &&
        s.cpMensaje != null && s.cpMensaje != undefined) {
        mensaje(s.cpMensaje, s.cpCodigo);
        delete s.cpCodigo;
        delete s.cpMensaje;
    }
}


function CargarAgvOrdenCompra() {
    AgvOrdenCompra.Refresh();
}

function OperarSetNumero(s, e) {
    if (s.GetValue() != null && s.GetValue() >= 0) {
        CargarAgvOrdenCompra();
    } else {
        e.isValid = false;
        mensaje('Número debe ser mayor que 0.', 0);
    }
}

function OperarCbxTodoOrdenCompra(s, e) {
    SetNumero.SetEnabled(!s.GetChecked());
    SetNumero.SetValue(0);
    CargarAgvOrdenCompra();
}

function OperarBetRut(s, e) {
    if (s.GetValue() != null) {
        BotonProveedorRut = 'BetRut';
        AcbOrdenCompra.PerformCallback(['ValidaRut', s.GetValue()]);
        CargarAgvOrdenCompra();
    } else {
        e.isValid = false;
        TxtRazonSocial.SetValue('');
        mensaje('Proveedor debe ser un número de rut', 0);
    }
}

function ButtonClickBetRut() {
    BotonProveedorRut = 'BetRut';
    ApcAyudaCliente.Show();
}

function OperarCbxTodoProveedor(s, e) {
    BetRut.SetEnabled(!s.GetChecked());
    BetRut.SetValue(0);
    TxtRazonSocial.SetValue('');
    CargarAgvOrdenCompra();
}

function OperarBtnAgvOrdenCompraActualizar() {
    if (confirm('Se dispone a guardar el registro. ¿Está seguro?')) {
        AfmAntecedentes.SetCurrentFolderPath('Antecedentes');
        AgvOrdenCompra.UpdateEdit();
    }
}

function OperarBtnAgvOrdenCompraCancelar() {
    if (confirm('Se dispone a cancelar cambios del registro. ¿Está seguro?')) {
        AgvOrdenCompra.CancelEdit();
    }
}

function OperarAgvOrdenCompraProveedorRut(s, e) {
    if (s.GetValue() != null) {
        BotonProveedorRut = 'AgvOrdenCompraProveedorRut';
        AcbOrdenCompra.PerformCallback(['ValidaRut', s.GetValue()]);
    } else {
        e.isValid = false;
        AgvOrdenCompraProveedorRazonSocial.SetValue('');
        mensaje('Proveedor debe ser un número de rut', 0);
    }
}

function ButtonClicAgvOrdenCompraProveedorRut() {
    BotonProveedorRut = 'AgvOrdenCompraProveedorRut';
    ApcAyudaCliente.Show();
}

function ClickBtnAgvOrdenCompraAntecedentes() {
    if (AgvOrdenCompra.cpCarpeta != null && AgvOrdenCompra.cpCarpeta != undefined) {
        AfmAntecedentes.SetCurrentFolderPath(AgvOrdenCompra.cpCarpeta);
        ApcAntecedentes.Show();
    }
}

function CalcularTotalesAgvOrdenCompra() {
    var impuesto = AgvOrdenCompra.cpImpuesto;
    AgvOrdenCompraSubtotal.SetValue(AgvItemOrdenCompra.cpSummaryTotal);
    AgvOrdenCompraAplicaImpuesto.GetChecked() ? AgvOrdenCompraImpuesto.SetValue(AgvOrdenCompraSubtotal.GetValue() * impuesto) : AgvOrdenCompraImpuesto.SetValue(0);
    AgvOrdenCompraAplicaImpuesto.GetChecked() ? AgvOrdenCompraTotal.SetValue(AgvOrdenCompraSubtotal.GetValue() * (1 + impuesto)) : AgvOrdenCompraTotal.SetValue(AgvOrdenCompraSubtotal.GetValue());
}

function CalcularTotalesAgvItemOrdenCompraTotal() {
    AgvItemOrdenCompraTotal.SetValue(AgvItemOrdenCompraCantidad.GetValue() * AgvItemOrdenCompraPrecioUnitario.GetValue());
}

function CargarAgvAyudaProveedor() {
    AgvAyudaProveedor.Refresh();
}

function RowDblClickAgvAyudaProveedor(s, e) {
    function datoRut(values) {
        ApcAyudaCliente.Hide();
        switch (BotonProveedorRut) {
            case 'AgvOrdenCompraProveedorRut':
                AgvOrdenCompraProveedorRut.SetValue(values[0]);
                AgvOrdenCompraProveedorRazonSocial.SetValue(values[1]);
                break;
            case 'BetRut':
                BetRut.SetValue(values[0]);
                TxtRazonSocial.SetValue(values[1]);
                CargarAgvOrdenCompra();
                break;
            default:
                break;
        }
    }
    s.GetRowValues(s.GetFocusedRowIndex(), 'RutFormateado;RazonSocial', datoRut);
}

function UpdateGridHeight() {
    AgvOrdenCompra.SetHeight(0);
    var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
    if (document.body.scrollHeight > containerHeight)
        containerHeight = document.body.scrollHeight;
    AgvOrdenCompra.SetHeight(containerHeight - 259);
}