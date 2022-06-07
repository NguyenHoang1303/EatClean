
let arr = [];
$("#btnCreateAticle").on("click", function () {
    var userId = $("input[name=userId]").val();
    var imgArray = [];
    var stepArray = [];
    var ingredientArray = [];
    var title = $("#titleArticle").val();
    var description = $("textarea[name=description]").val();
    var category = $("select[name=category]").val();
    var tag = $("select[name=unit]").val();
    var steps = $(".step-articles");
    var thumbnail = $('#img-article').val();
    var ingredients = $('.ig-content');
    steps.each(function () {
        stepArray.push($(this).val())
    })
    ingredients.each(function () {
        ingredientArray.push($(this).val());
    })

    let content = {
        steps: stepArray,
        recipe: ingredientArray,
    }
    let data = {
        title: title,
        description: description,
        tagId: tag,
        categoryId: category,
        contents: JSON.stringify(content),
        thumbnail: thumbnail
    }
    $.ajax({
        type: "POST",
        url: "/Kocina/CreateArticle/" + userId,
        data: data,
        success: function (data) {
            if (data == "True") {
                swal("Good job!", "You clicked the button!", "success");
            } else {
                swal("Oh no!", "The AJAX request failed!", "error");
            }
        }, error: function () {
            swal("Oh no!", "The AJAX request failed!", "error");
        }
    });

})

function removeIamge() {
    $(".uk-padding-remove").click(function () {
        var parent = $(this).parent(".p-2");
        var delete_token = $(this).prev().attr("data-delete");
        $.ajax({
            type: "POST",
            url: "https://api.cloudinary.com/v1_1/binht2012e/delete_by_token",
            cache: false,
            data: { token: delete_token },// serializes the form's elements.
            success: function (data) {
                console.log(data.result);
                parent.remove();
            }
        }, parent);

    });
}

let number_ingrendient = $(".ingrendient-number").length + 1;
function createStep(number) {
    return `<div id="step-${number}">
                            <div class="uk-width-auto">
                                
                            </div>
                            <div class="uk-width-expand">
                                <div class="d-flex justify-content-between">
                                    <div class="d-flex">
                                        <a href="#" class="uk-step-icon" data-uk-icon="icon: check; ratio: 0.8"
                                            data-uk-toggle="target: #step-1; cls: uk-step-active"></a>
                                        <h5 class="ms-2 uk-step-title uk-text-500 uk-text-uppercase uk-text-primary" data-uk-leader="fill:—"> <div class="uk-element">${number}. Step</div></h5>
                                    </div>
                                    <input class="uk-button btn-warning uk-padding-remove" style="height:30px; width:75px" onclick="remove(${number})" type="button" value="Remove">
                                </div>
                                <div class="uk-step-content col-12">
                                    <textarea name="steps" class="uk-input border border-secondary step-articles" rows="10" cols="50" style="height: 150px"></textarea>
                                </div>
                            </div>
                        </div>
            <br/>
        `
}
$("#add-step").on("click", function () {
    let num = $(".uk-width-auto").length;
    console.log(num);
    let html_step = createStep(num + 1);
    let div = document.createElement("div")
    div.innerHTML = html_step;
    $("#uk-article-add").append(div);

})
function addIngrendient() {
    var volume = $("input[name=volume]").val();
    var ingrendient_name = $("input[name=ingrendient-name]").val();
    var unit = $("select[name=unit-incre]").val();
    if (volume <= 0 && ingrendient_name.length == 0) {
        $("#msg-error").text("Vui lòng nhập thông tin");
        return;
    }
    number_ingrendient = $(".ingrendient-number").length + 1;
    $(".ingrendients").html(function (index, currentcontent) {
        return currentcontent + `
                        <li id="step-ig-`+ number_ingrendient + `" class="ingrendient-number">
                            <div class="d-flex justify-content-between">
                                <p > `+ volume + ` ` + unit + `   ` + ingrendient_name + `</p>
                                    <input class="ig-content" type="hidden" value="`+ volume + ` ` + unit + ` ` + ingrendient_name + `"/>
                                <input class="uk-button btn-warning uk-padding-remove" onclick="removeIngrendient(`+ number_ingrendient + `)" style="height:30px; width: 75px" type="button" value="Remove">
                            </div>
                        </li>
`
    });
}
function removeIngrendient(number) {
    $("#step-ig-" + number).remove();
}
function remove(number) {
    $("#step-" + number).remove();
    $.each($(".uk-element"), function (index, element) {
        index++;
        console.log(element.replaceWith(index + ".Step"), index);
    });

}
function removeTag(item) {
    arr.pop(item.dataset["tag"]);
    item.remove();
}

function addTag(value) {
    let flag = false;
    arr.forEach(
        function (item) {
            if (item == value) {

                flag = true;
            }

        });

    if (flag == false) {
        $(".tags").html(function (index, text) {
            return text + ` <a class="uk-display-inline-block tag-this" data-tag="` + value + `" onclick="removeTag(this)" ><span class="uk-label uk-label-light">` + value + `</span></a>`
        })
    }
    arr.push(value);
    let check = {}
    arr = arr.filter(item => {
        if (!check[item]) {
            check[item] = true
            return true;
        }
    })

}

$("#btnThumbnailLink").click(
    function () {
        myWidget_thumbnail.open();
    }
);
var myWidget_thumbnail = cloudinary.createUploadWidget(
    {
        cloudName: "binht2012e",
        uploadPreset: "cndcrp9y",
    },
    (error, result) => {
        if (!error && result && result.event === "success") {
            $(".upload_button_holder").html(function () {
                return `
                    <div class="p-2" style="position: relative;width:200px">
                        <input type="hidden" value="${result.info.secure_url}" id="img-article"/>
                        <img data-delete="${result.info.delete_token}" class="border border-primary" style="margin:5px;padding:5px;height:150px;object-fit:cover;width:200px;" src="${result.info.secure_url}" />
                        <input onclick="removeIamge()" class="btn btn-warning uk-padding-remove" style="position:absolute;top:0;left:90%;height:30px;" type="button" value="Remove">
                    </div>`;
            })

        }
    }
);

