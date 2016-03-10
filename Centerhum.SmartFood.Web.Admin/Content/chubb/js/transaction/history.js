var ChubbDocumentHistory = {
    Init: function () {
        ChubbDocumentHistory.InitMethods.FormSearchHistoryEvent();
        ChubbDocumentHistory.InitMethods.InitializeValidation();
        
    },
    InitMethods: {
        InitializeValidation: function () {
            var $renderContent = $("#renderTimeLine");
            if ($renderContent.length > 0) {
                var postNow = $renderContent.attr("data-post-now");
                if (postNow == "True") {
                    $("#form-list-history").submit();
                }
            }
        },
        FormSearchHistoryEvent: function () {
            var $form = $("#form-list-history");
            $form.submit(function (event) {
                event.preventDefault();
                if ($form.valid()) {
                    NProgress.start();
                    var urlGet = $form.attr("action");
                    $("#renderTimeLine").load(urlGet, $form.serialize(), function () {
                        Plugins.init();
                        $("#btn-widget-collapse-filter").click();
                        $("#header-filter").click();

                        // Last Line Ever!
                        NProgress.done();
                    });
                }
            });
        }
    }
}

$(document).ready(function () {
    ChubbDocumentHistory.Init();
});

