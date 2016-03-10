var myTable = "";
var ChubbFormList = {
    Init: function () {
        ChubbFormList.InitMethods.AjaxFormListSubmit();
        ChubbFormList.InitMethods.SelectClickEvent();
        ChubbFormList.InitMethods.LoadGrid();
    },
    InitMethods: {
        AjaxFormListSubmit: function () {
            var $form = $(".form-list-ajax");
            $form.submit(function (event) {
                event.preventDefault();
                if ($form.valid()) {
                    NProgress.start();
                    var urlGet = $form.attr("action");                    
                    $("#grid").load(urlGet, $form.serialize(), function (response, status, xhr) {
                        if (status == "error") {
                            NProgress.done();
                            ChubbAPI.UIMethods.ShowMessage("Ocorreu o seguinte erro: " + xhr.status + " " + xhr.statusText, 4);
                            console.log(response);
                            return;
                        }
                        
                        App.init();
                        Plugins.init();
                        $("#btn-widget-collapse-filter").click();
                        ChubbFormList.InitMethods.DrawGridEvent();
                        ChubbFormList.UIMethods.SetSelectRow();
                        ChubbFormList.Methods.ShowDelConfirmDialogEvent();
                        ChubbFormList.Methods.ShowCustomButtonsEvent();


                        if ($("#UrlDeleteSelecteds").val() != "") {
                            var $tableHeader = $(".DTTT_container").parent();
                            $tableHeader.prepend("<div class='remove-button-table'><a class='btn' id='btnDeleteSelecteds'><i class='icon-trash'></i><span>&nbsp;Remover Selecionados</span></a></div>");
                            ChubbFormList.Methods.DeleteSelectedsEvent();
                        }
                        $("#header-filter").click();

                        // Last Line Ever!
                        NProgress.done();
                    });
                }
            });
        },
        DrawGridEvent: function () {
            $('#table-grid_wrapper').on('draw.dt', function () {
                ChubbFormList.UIMethods.SetSelectRow();
                ChubbFormList.Methods.ShowDelConfirmDialogEvent();
                ChubbFormList.Methods.ShowCustomButtonsEvent();
            });
        },
        SelectClickEvent: function () {
            $('#table-grid tbody').on('click', 'tr', function () {
                $(this).toggleClass('selected');
            });
        },
        LoadGrid: function () {
            ChubbFormList.UIMethods.SetSelectRow();
            ChubbFormList.Methods.ShowDelConfirmDialogEvent();
            ChubbFormList.Methods.ShowCustomButtonsEvent();


            if ($("#UrlDeleteSelecteds").val() != "") {
                var $tableHeader = $(".DTTT_container").parent();
                $tableHeader.prepend("<div class='remove-button-table'><a class='btn' id='btnDeleteSelecteds'><i class='icon-trash'></i><span>&nbsp;Remover Selecionados</span></a></div>");
                ChubbFormList.Methods.DeleteSelectedsEvent();
            }
        }
    },
    UIMethods: {
        RemoveCurrentRow: function ($tdOrInnerTd) {
            $tdOrInnerTd.children("tr").remove();
        },
        SetSelectRow: function () {
            $(".cbSelect").on("change", function () {
                var $currentSelect = $(this);
                var isChecked = $currentSelect.is(':checked');
                if (isChecked) {
                    $currentSelect.parents("tr").addClass('checked');
                }
                else {
                    $currentSelect.parents("tr").removeClass('checked');
                }
            });
        }
    },
    Methods: {
        ShowDelConfirmDialogEvent: function () {
            $(".btnDel").on("click", function () {
                var $currentBtnDel = $(this);
                var pkValue = $currentBtnDel.attr("data-value");
                var url = $currentBtnDel.attr("data-url");
                bootbox.confirm("Deseja excluir o registro '" + pkValue + "'?", function (confirmed) {
                    if (confirmed) {
                        ChubbFormList.Methods.DeleteRegister(url, pkValue, $currentBtnDel);
                    }
                });
            });
        },
        ShowCustomButtonsEvent: function () {
            $(".btnCustomConfirm").unbind("click");

            $(".btnCustomConfirm").on("click", function () {
                var $currentButton = $(this);
                var pkValue = $currentButton.attr("data-value");
                var url = $currentButton.attr("data-url");
                var messageConfirm = $currentButton.attr("data-message-confirm");
                messageConfirm = messageConfirm.replace("{0}", pkValue);

                bootbox.confirm(messageConfirm, function (confirmed) {
                    if (confirmed) {
                        $.ajax({
                            type: "POST",
                            url: url,
                            data: { id: pkValue },
                            success: function (response) {
                                ChubbAPI.UIMethods.DefaultCallBack(response);
                            }
                        });
                    }
                });
            });
        },
        DeleteSelectedsEvent: function () {
            $("#btnDeleteSelecteds").on("click", function () {
                var arrValues = new Array();
                var arrRows = [];
                var tableGrid = $("#table-grid").DataTable();
                $(".cbSelect:checked").each(function () {
                    var $currentCb = $(this);
                    arrValues.push($currentCb.val());
                    arrRows.push($currentCb.closest("tr").get(0));
                });

                if (arrValues.length <= 0) {
                    return;
                }


                bootbox.confirm("Deseja excluir " + arrValues.length + " registro(s)?", function (confirmed) {
                    if (confirmed) {
                        var dataPost = { Ids: arrValues };
                        var urlPost = $("#UrlDeleteSelecteds").val();

                        $.ajax({
                            type: "POST",
                            url: urlPost,
                            contentType: 'application/json',
                            data: JSON.stringify(dataPost),
                            success: function (response) {
                                ChubbAPI.UIMethods.DefaultCallBack(response);
                                if (response.Status == 1) {
                                    for (var i = 0; i < arrRows.length; i++) {
                                        var currentRow = tableGrid.fnGetPosition(arrRows[i]);
                                        tableGrid.fnDeleteRow(currentRow);
                                    }
                                }
                            }
                        });
                    }
                });
            });
        },
        DeleteRegister: function (url, value, $btnDel) {
            $.ajax({
                type: "POST",
                url: url,
                data: { Id: value },
                success: function (response) {
                    ChubbAPI.UIMethods.ShowMessage(response.Message, response.Status);
                    if (response.Status == 1) {
                        var tableGrid = $("#table-grid").DataTable();
                        var rowDtElement = tableGrid.fnGetPosition($btnDel.closest("tr").get(0));
                        tableGrid.fnDeleteRow(rowDtElement);
                    }
                }
            });
        }
    }
}


$(document).ready(function () {
    ChubbFormList.Init();
});