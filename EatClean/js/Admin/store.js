
let arr = [];
function createArticle() {
    var imgArray = [];
    var stepArray = [];
    var IngredientArray = [];
    var title = $("input[name=title]").val();
    var description = $("textarea[name=description]").val();
    var status = $("select[name=status]").val();
    var tag = arr;
    var steps = document.getElementsByClassName('step');
    var imgs = document.getElementsByClassName('imgs');
    var ingredients = document.getElementsByClassName('ig-content');
    for (let i = 0; i < imgs.length; i++) {
        imgArray.push(imgs[i].value.trim());
    }
    for (let i = 0; i < steps.length; i++) {
        stepArray.push(steps[i].value.trim());
    }
    for (let i = 0; i < ingredients.length; i++) {
        IngredientArray.push(ingredients[i].value.trim());
    }

}
function removeIamge() {
    $(".uk-padding-remove").click(function () {
        var parent = $(this).parent(".p-2");
        var delete_token = $(this).prev().attr("data-delete");
        $.ajax({
            type: "POST",
            url: "https://api.cloudinary.com/v1_1/binht2012e/delete_by_token",
            cache: false,
            data: { token: delete_token },// serializes the form's elements.
            success: function (data){
                console.log(data.result);
                parent.remove();
                    
            }
        }, parent);

    });
}

let number_ingrendient = $(".ingrendient-number").length + 1;
function addStep() {
    number = $(".uk-element").length + 1;
    console.log(number)
    $(".uk-article").html(function (index, currentcontent) {
        return currentcontent + `
                        <div id="step-`+ number + `" class="uk-grid-small uk-margin-medium-top" data-uk-grid>
                            <div class="uk-width-auto">
                                <a href="#" class="uk-step-icon" data-uk-icon="icon: check; ratio: 0.8"
                                   data-uk-toggle="target: #step-1; cls: uk-step-active"></a>
                            </div>
                            <div class="uk-width-expand">
                                <div class="d-flex justify-content-between">
                                    <h5 class="uk-step-title uk-text-500 uk-text-uppercase uk-text-primary" data-uk-leader="fill:—"> <div class="uk-element">`+ number + `. Step</div></h5>
                                    <input class="btn btn-warning uk-padding-remove" onclick="remove(`+ number + `)" style="height:30px;" type="button" value="Remove">
                                </div>
                                <div class="uk-step-content col-12">
                                    <textarea name="steps" class="form-control border border-secondary step" rows="10" cols="50">

                                    </textarea>
                                </div>
                            </div>
                        </div>
`
    });

}
function addIngrendient() {
    var volume = $("input[name=volume]").val();
    var ingrendient_name = $("input[name=ingrendient-name]").val();
    var unit = $("select[name=unit]").val();

    number_ingrendient = $(".ingrendient-number").length + 1;
    $(".ingrendients").html(function (index, currentcontent) {
        return currentcontent + `
                        <li id="step-ig-`+ number_ingrendient + `" class="ingrendient-number">
                            <div class="d-flex justify-content-between">
                                <p > `+ volume + ` ` + unit + ` ` + ingrendient_name + `</p>
                                    <input class="ig-content" type="hidden" value="`+ volume + ` ` + unit + ` ` + ingrendient_name + `"/>
                                <input class="btn btn-warning uk-padding-remove" onclick="removeIngrendient(`+ number_ingrendient + `)" style="height:30px;" type="button" value="Remove">
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
        console.log(element.replaceWith(index + ".Step"),index);
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
            return text + ` <a class="uk-display-inline-block tag-this" data-tag="` + value+`" onclick="removeTag(this)" ><span class="uk-label uk-label-light">` + value + `</span></a>`
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
  
            $(".upload_button_holder").html(function (index, text) {
                return text + `
                                    <div class="p-2" style="position: relative;width:200px">
                                        <input type="hidden" value="${result.info.secure_url}" class="imgs"/>
                                        <img data-delete="${result.info.delete_token}" class="border border-primary" style="margin:5px;padding:5px;height:150px;object-fit:cover;width:200px;" src="${result.info.secure_url}" />
                                        <input onclick="removeIamge()" class="btn btn-warning uk-padding-remove" style="position:absolute;top:0;left:90%;height:30px;" type="button" value="Remove">
                                    </div>`;
            })
             
        }
    }
);

