var SmartFoodApi = {
    Init: function () {
        SmartFoodApi.InitMethods.SetDefaults();        
        SmartFoodApi.InitMethods.SetDatePicker();
        SmartFoodApi.InitMethods.SetFormsValidation();
        SmartFoodApi.InitMethods.SetUniversalDateEvent();
        SmartFoodApi.InitMethods.SetAutoCompleteControl();        
    },
    InitMethods: {
        SetDefaults: function () {
            App.init(); // Init layout and core plugins
            Plugins.init(); // Init all plugins
            FormComponents.init(); // Init all form-specific plugins
            setInterval(function () {
                var now = new Date();
                var response = now.getHours() + ":" + (now.getMinutes() > 10 ? now.getMinutes() : "0" + now.getMinutes());
                $("#time-now").html(response);
            }, 1000);
        },
        SetCustomSelect: function () {
            var $selects = $("select");
            if ($selects.length > 0) {
                $selects.each(function () {
                    var placeholder = $(this).attr("data-placeholder");
                    if (placeholder != null || placeholder != "")
                        $(this).select2({ minimumResultsForSearch: -1, placeholder: placeholder });
                    else
                        $(this).select2({ minimumResultsForSearch: -1 });

                });
            }
        },
        SetDatePicker: function () {
            var $dtPickers = $(".date-picker");
            if ($dtPickers.length > 0) {
                $dtPickers.each(function () {
                    $(this).pickadate({ format: 'dd/mm/yyyy', formatSubmit: 'dd/mm/yyyy' });
                });
            }
        },
        SetFormsValidation: function () {
            var $forms = $(".validate-me");
            if ($forms.length > 0) {
                $forms.each(function () {
                    $(this).validate();
                });
            }
        },
        SetUniversalDateEvent: function () {
            $("#txtDay").on("change", function () {
                var urlProgressLoad = $("#UrlProgressLoad").val();
                var date = $(this).val();
                $("#progressObjectLoad").load(urlProgressLoad, { date: date }, function () {

                });
            });
        },
        SetAutoCompleteControl: function () {
            var $autoCompleteControls = $(".auto-complete-control");
            if ($autoCompleteControls.length > 0) {
                $autoCompleteControls.each(function () {
                    if ($(this).attr("data-ajax") == "False") {
                        $(this).typeahead({
                            name: $(this).attr("id"),
                            local: $(this).attr("data-value").split(";")
                        });
                    }
                    else {

                        var urlAutoComplete = $(this).attr("data-url-auto-complete");
                        $(this).typeahead({

                            name: 'resultArticle',
                            remote: {

                                url: urlAutoComplete + '%QUERY',
                                filter: function (data) {

                                    var resultList = data.map(function (item) {
                                        return item.Value;
                                    });

                                    return resultList;

                                }
                            }
                        });

                    }
                });
            }
        },
        ClickSubMenus: function () {
            var $subMenus = $(".subMenuClickEvent");
            if ($subMenus.length > 0) {
                $subMenus.each(function () {
                    $(this).click();
                });
            }
        }
    },
    Properties: {
        DefaultMessageError: "Ocorreu um erro no servidor ou o servidor não foi encontrado!",
        DefaultStatusError: 4
    },
    UIMethods: {
        ShowMessage: function (message, status) {
            var strStatus = "";
            switch (status) {
                case 1:
                    strStatus = 'success';
                    break;
                case 2:
                    strStatus = 'information';
                    break;
                case 3:
                    strStatus = 'warning';
                    break;
                case 4:
                    strStatus = 'error';
                    break;
                default:
                    strStatus = 'error'
                    message = SmartFoodApi.Properties.DefaultMessageError;
                    break;
            }


            noty({
                text: message,
                type: strStatus,
                timeout: 4500
            });
        },
        EnableModal: function () {
            $("#ModalBlackMask").addClass("in");
            $("#ModalContent").fadeIn("Slow");
        },
        DisableModal: function () {
            $("#ModalBlackMask").removeClass("in");
            $("#ModalContent").fadeOut("slow");

            setTimeout(function () {
                $("#modal").html("");
                $("#btn-widget-collapse").click();
            }, 1000);
        },
        SetToolTips: function () {
            $('.bs-tooltip').tooltip({
                container: 'body'
            });
            $('.bs-focus-tooltip').tooltip({
                trigger: 'focus',
                container: 'body'
            });
        },
        DefaultCallBack: function (obj) {
            var timeoutCallBack = 2000;
            if (obj.Message != undefined && obj.Message != "") {
                SmartFoodApi.UIMethods.ShowMessage(obj.Message, obj.Status);
            }

            if (obj.UrlRedirect !== undefined && obj.UrlRedirect != "") {
                setTimeout(function () {
                    location.href = obj.UrlRedirect;
                }, timeoutCallBack);
            }
        },
        OpenModal: function (){
            window.location = "#modal";
        },
        CloseModal: function () {
            window.localStorage = "#";
        }
    },
    Methods: {
        GetStatusService: function (url) {
            $.getJSON(url, function (response) {
                var $statusService = $("#StatusService");
                var $textStatusService = $("#TextStatusService");
                if ($statusService.length > 0 && $textStatusService.length > 0) {
                    if (response) {
                        $textStatusService.html("O serviço está em execução no servidor.");
                        $statusService.addClass("icon-spin");
                    }
                    else {
                        $textStatusService.html("O serviço está parado no servidor. Contate a equipe de Service Desk.");
                        $statusService.removeClass("icon-spin");
                    }
                }
            });
        },
        CalculateHeight: function () {
            $('body').height('100%');

            var $header = $('.header');
            var header_height = $header.outerHeight();

            var document_height = $(document).height();
            var window_height = $(window).height();

            var doc_win_diff = document_height - window_height;

            if (doc_win_diff <= header_height) {
                var new_height = document_height - doc_win_diff;
            } else {
                var new_height = document_height;
            }

            new_height = new_height - header_height;

            var document_height = $(document).height();

            $('body').height(new_height);
        }
    }
}


$(document).ready(function () {
    SmartFoodApi.Init();
});