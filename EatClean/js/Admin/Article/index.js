$(".status-article").on("change", function () {
    var id = $(this).attr("data-articleId");
    var status = $(this).val();
    $.ajax({
        type: "POST",
        url: "/Articles/UpdateStatus",
        data: data,
        success: function (data) {
            if (data == "True") {
                swal("Good job!", "You clicked the button!", "success");
            } else {
                swal("Oh noes!", "The AJAX request failed!", "error");
            }
        }, error: function () {
            swal("Oh noes!", "The AJAX request failed!", "error");
        }
    });
})
