
        $(document).ready(function () {
            $("#createArrow").click(function () {
                $("#loginSection").animate({ width: 'toggle' }, 600);
                setTimeout(function () {
                    $("#createSection").animate({ width: 'toggle' }, 600);
                }, 600);
            });
            $("#returnArrow").click(function () {
                $("#createSection").animate({ width: 'toggle' }, 600);
                setTimeout(function () {
                    $("#loginSection").animate({ width: 'toggle' }, 600);
                }, 600);
            });
            $("#Type").change(function () {
                $("#Type option:selected").each(function () {
                    var value = $(this).val();
                    if ($.trim(value) === "employee") {
                        $("#CompanyID").show(600);
                    }
                    else if ($.trim(value) === "client") {
                        $("#CompanyID").hide(600);
                    }
                });
            }).change();
        });