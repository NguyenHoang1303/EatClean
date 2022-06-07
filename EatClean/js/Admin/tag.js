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

function updateTag() {
let id = $("input[name=tagId]").val();
    let name = $("input[name=tagName]").val();
    $.ajax({
        type: "POST",
        url: "/Admin/EditTag",
        data: {
            id: id,
            name: name
        },
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

function openModal(id) {
    document.getElementById('id01').style.display = 'block';
    $("#tag-delete").attr("data-id", id);
}

function closeModal() {
    document.getElementById('id01').style.display = 'none';
}

function deleteTag() {
    let id = $("#tag-delete").attr("data-id");
    $.ajax({
        type: "POST",
        url: `/Admin/DeleteTag/${id}`,
        success: function (data) {
            if (data == "True") {
                swal("Good job!", "You clicked the button!", "success");
                document.getElementById('id01').style.display = 'none';
                setTimeout(function () {
                    location.reload();
                }, 1000)
            } else {
                swal("Oh noes!", "The AJAX request failed!", "error");
                document.getElementById('id01').style.display = 'none';
            }
        }, error: function () {
            swal("Oh noes!", "The AJAX request failed!", "error");
            document.getElementById('id01').style.display = 'none';
        }
    });

}