var ChubbDocumentDetail = {
    Init: function () {
        ChubbDocumentDetail.InitMethods.FormatJson();
        ChubbDocumentDetail.InitMethods.ReprocessEvent();
    },
    InitMethods: {
        FormatJson: function () {
            $(".dsc_saida").each(function () {

                var htmlJson = $(this).html();

                if (htmlJson.trim() != "") {
                    
                    var node = new PrettyJSON.view.Node({
                        el: $(this),
                        data: JSON.parse(htmlJson),
                        quote: 'string'
                    });
                }

            });

            $(".string").each(function () {
                var $current = $(this);
                var currentText = $current.html();

                $current.html("'" + currentText + "'");
            });
        },
        ReprocessEvent: function () {
            $("#btnReprocessar").on("click", function () {
                NProgress.start();
                var url = $("#UrlReprocessar").val();
                var cod_chamador = $("#CodigoChamador").val();
                $.ajax({
                    method: "GET",
                    url: url,
                    data: { id: cod_chamador },
                    success: function (response) {
                        ChubbAPI.UIMethods.DefaultCallBack(response);
                        NProgress.done();
                    }
                });
                
            });
        }
    }
}

$(document).ready(function () {
    ChubbDocumentDetail.Init();
});