function createTag() {

    $.ajax({
        type: "POST",
        url: "CreateTag",
        data: {
            tag_name: $("input[name=tag]").val(),
        }, // serializes the form's elements.
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
}