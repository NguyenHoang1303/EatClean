function createBook() {
  var name = $("input[name=Name]").val();
   var authorName $("input[name=AuthorName]").val();
  var price =  $("input[name=Price]").val();
   var status = $("select[name=Status]").val();
    var thumbnail = $('#img-article').val();
    let data = {
        name: name,
        price: price,
        authorName: authorName,
        status: status,
        thumbnail: thumbnail
    }
    $.ajax({
        type: "POST",
        url: "/Admin/StoreBook",
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

}