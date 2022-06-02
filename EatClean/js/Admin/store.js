let arr = [];
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
                                    <textarea class="form-control border border-secondary step" rows="10" cols="50">

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
                                <p> `+ volume + ` ` + unit + ` ` + ingrendient_name + `</p>
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
  
