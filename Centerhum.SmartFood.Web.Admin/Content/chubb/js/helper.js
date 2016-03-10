var ChubbAPI = {
    Init: function () {
        ChubbAPI.InitMethods.SetDefaults();
        //ChubbAPI.InitMethods.SetCustomSelect();
        ChubbAPI.InitMethods.SetDatePicker();
        ChubbAPI.InitMethods.SetFormsValidation();
        ChubbAPI.InitMethods.SetUniversalDateEvent();
        ChubbAPI.InitMethods.SetAutoCompleteControl();
        ChubbAPI.InitMethods.CheckStatusService();
        //ChubbAPI.InitMethods.ClickSubMenus();
        ChubbAPI.InitMethods.LoadDocumentProgress();
        ChubbAPI.InitMethods.LoadNotificationError();
        ChubbAPI.InitMethods.MenuEventClick();
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
        LoadDocumentProgress: function () {
            var urlDocumentProgress = $("#urlDocumentProgress").val();
            $.ajax({
                url: urlDocumentProgress,
                type: "GET",
                success: function (response) {
                    $("#progressObjectLoad").prepend(response);
                }
            });

        },
        LoadNotificationError: function () {
            var urlNotificationErrors = $("#urlNotificationErrors").val();
            $.ajax({
                url: urlNotificationErrors,
                type: "GET",
                success: function (response) {
                    $("#notificationErrorsLoad").html(response);
                }
            });

        },
        CheckStatusService: function () {
            var url = $("#UrlCheckStatusService").val();
            ChubbAPI.Methods.GetStatusService(url);
            setInterval(function () {
                ChubbAPI.Methods.GetStatusService(url);
            }, 30000);
        },
        ClickSubMenus: function () {
            var $subMenus = $(".subMenuClickEvent");
            if ($subMenus.length > 0) {
                $subMenus.each(function () {
                    $(this).click();
                });
            }
        },
        MenuEventClick: function () {
            var arrow_class_open = 'icon-angle-down',
			arrow_class_closed = 'icon-angle-left';


            $('#sidebar-content ul > li > a').on('click', function (e) {

                if ($(this).next().hasClass('sub-menu') == false) {
                    return;
                }

                // Toggle on small devices instead of accordion
                if ($(window).width() > 767) {
                    var parent = $(this).parent().parent();

                    parent.children('li.open').children('a').children('i.arrow').removeClass(arrow_class_open).addClass(arrow_class_closed);
                    parent.children('li.open').children('.sub-menu').slideUp(200);
                    parent.children('li.open-default').children('.sub-menu').slideUp(200);
                    parent.children('li.open').removeClass('open').removeClass('open-default');
                }

                var sub = $(this).next();
                if (sub.is(":visible")) {
                    $('i.arrow', $(this)).removeClass(arrow_class_open).addClass(arrow_class_closed);
                    $(this).parent().removeClass('open');
                    sub.slideUp(200, function () {
                        $(this).parent().removeClass('open-fixed').removeClass('open-default');
                        ChubbAPI.Methods.CalculateHeight();
                    });
                } else {
                    $('i.arrow', $(this)).removeClass(arrow_class_closed).addClass(arrow_class_open);
                    $(this).parent().addClass('open');
                    sub.slideDown(200, function () {
                        ChubbAPI.Methods.CalculateHeight();
                    });
                }

                e.preventDefault();
            });
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
                    message = ChubbAPI.Properties.DefaultMessageError;
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
                ChubbAPI.UIMethods.ShowMessage(obj.Message, obj.Status);
            }

            if (obj.UrlRedirect !== undefined && obj.UrlRedirect != "") {
                setTimeout(function () {
                    location.href = obj.UrlRedirect;
                }, timeoutCallBack);
            }
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
    ChubbAPI.Init();
});