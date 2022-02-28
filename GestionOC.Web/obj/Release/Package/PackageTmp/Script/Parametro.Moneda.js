function EndCallbackAgvMoneda(s, e) {
    if (e.command == 'REFRESH' && s.cpCodigo <= -1) {
        mensaje(s.cpMensaje, s.cpCodigo);
    }
    if (e.command != 'REFRESH' && s.cpCodigo != undefined) {
        mensaje(s.cpMensaje, s.cpCodigo);
    }
    delete s.cpCodigo;
    delete s.cpMensaje;
}

function EndCallbackAcpMoneda(s, e) {
    if (s.cpCodigo != undefined && s.cpMensaje != undefined) {
        mensaje(s.cpMensaje, s.cpCodigo);
    }
    delete s.cpCodigo;
    delete s.cpMensaje;
}

function UpdateGridHeight() {
    AgvMoneda.SetHeight(0);
    var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
    if (document.body.scrollHeight > containerHeight)
        containerHeight = document.body.scrollHeight;
    AgvMoneda.SetHeight(containerHeight - 191);
}