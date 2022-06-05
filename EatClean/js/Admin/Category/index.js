function createCategory() {
    let name = $("#nameCate").val();
    let description = $("#descriptionCate").val();
    let categoryParent = $("#categoryParent").val();

    $.ajax({
        type: "POST",
        url: "/Category/Create",
        data: {
            name: name,
            description: description,
            categoryParent: categoryParent,
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

function updateCategory() {
    
    let name = $("#nameCate").val();
    let id = $("#idCate").val();
    let description = $("#descriptionCate").val();
    let categoryParent = $("#categoryParent").val();

    $.ajax({
        type: "POST",
        url: "/Category/Edit",
        data: {
            id: id,
            name: name,
            description: description,
            categoryParent: categoryParent,
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
    $("#cate-delete").attr("data-id", id);
}

function closeModal() {
    document.getElementById('id01').style.display = 'none';
}

function deleteCategory() {
    let id = $("#cate-delete").attr("data-id");
    $.ajax({
        type: "POST",
        url: `/Category/Delete/${id}`,
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