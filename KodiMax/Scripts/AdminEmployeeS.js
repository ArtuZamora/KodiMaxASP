$(document).ready(function () {
    $(".pdiv").click(function () {
        $(this).next().slideToggle("fast");
    });
    $(".MovieID").change(function () {
        $(".MovieID option:selected").each(function () {
            var id = $(this).val();
            $.ajax({
                type: "GET",
                url: "https://localhost:44387/api/MovieAPI/" + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#MovieName").val(response.Name);
                    $("#MovieDuration").val(response.Duration);
                    $("#MovieType").val($.trim(response.Type));
                    $("#MovieImage").val(response.Image);
                },
                failure: function (response) {
                    alert(response.responseText);
                    alert("Failure");
                },
                error: function (response) {
                    alert(response);
                    alert("Error");
                }
            });
        });
    }).change();
    $(".CandyID").change(function () {
        $(".CandyID option:selected").each(function () {
            var id = $(this).val();
            $.ajax({
                type: "GET",
                url: "https://localhost:44387/api/CandyAPI/" + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#CandyName").val(response.Name);
                    $("#CandyPrice").val(response.Price);
                    $("#CandyType").val($.trim(response.Type));
                    $("#CandyImage").val(response.Image);
                },
                failure: function (response) {
                    alert(response.responseText);
                    alert("Failure");
                },
                error: function (response) {
                    alert(response);
                    alert("Error");
                }
            });
        });
    }).change();
});