var ChubbOperationUpdate = {
    Init: function () {
        ChubbOperationUpdate.InitMethods.Initialize();
        ChubbOperationUpdate.InitMethods.SetSelectEvent();
    },
    InitMethods: {
        Initialize: function () {
            $("#formOperation").append("<input type='hidden' id='operacao_chamada_sucesso' />");
        },
        SetSelectEvent: function () {
            $("#cod_operacao_chamada").on("select2-selecting", function (e) {
                var $formOperation = $("#formOperation");
                bootbox.prompt("Digite o tempo (Minutos) de espera para essa chamada incluida!", function (result) {
                    var $operationControl = $("#operacao_chamada_sucesso");
                    var currentVal = $operationControl.val();
                    currentVal += ";";
                    currentVal += e.val();
                    currentVal += "-";
                    currentVal += result;

                    $operationControl.val("");
                });

            });
        }
    }
};

$(document).ready(function () {
    ChubbOperationUpdate.Init();
});