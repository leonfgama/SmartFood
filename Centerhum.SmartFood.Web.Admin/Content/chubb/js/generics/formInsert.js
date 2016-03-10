var ChubbFormInsert = {
    Init: function () {
        ChubbFormInsert.InitMethods.AjaxFormInsertSubmit();
        ChubbFormInsert.InitMethods.BindControls();
    },
    InitMethods: {
        AjaxFormInsertSubmit: function () {
            var $form = $(".form-insert-ajax");
            $form.submit(function (event) {
                event.preventDefault();
                if ($form.valid()) {
                    NProgress.start();
                    var urlPost = $form.attr("action");
                    console.log($form.serialize());
                    $.ajax({
                        type: "POST",
                        url: urlPost,
                        data: $form.serialize(),
                        success: function (response) {
                            NProgress.done();
                            ChubbAPI.UIMethods.DefaultCallBack(response);
                        },
                        error: function (response) {
                            NProgress.done();
                            ChubbAPI.UIMethods.ShowMessage(response.Message, response.Status);
                        }
                    });
                }
            });
        },
        BindControls: function(){
            var $inputSelectMultiple = $(".input-select-multiple");
            if ($inputSelectMultiple.length > 0) {
                $inputSelectMultiple.each(function () {
                    $(this).select2();
                    var vlr = $(this).attr("data-value");
                    var arrVlr = vlr.split(";");
                    $(this).val(arrVlr).trigger("change");
                });
            }

        }
    }
}


$(document).ready(function () {
    ChubbFormInsert.Init();
});