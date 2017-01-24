function AddImg() {
    var homUrl = $("#hdnHomePageUrl").val();
    homUrl = homUrl ? homUrl : window.location.host + "/";
    homUrl = homUrl.concat('test/UploadImage');


    var data = new FormData();
    var files = $("#imgSource .imgsource").get(0).files;
    if (files.length > 0) {
        data.append("HelpSectionImages", files[0]);
        $("#imgSave").val(files[0].name);
    }
    else {
        alert("error");
        return;
    }
    data.append("id", 11);
    data.append("elementid", 11);
    $.ajax({
        url: 'UploadImage',
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
           // $("body").append("<img src=\"" + response + "\" >");
        }
    });
}

function getRegions(event)
{
   
    $.ajax({
        url: 'GetRegions',
        type: "POST",
        //  processData: false,
        // contentType: false,
        data: { Name: event.value },
        success: function (response) {

            var regSelect = document.getElementById("selectIDRegion");
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameRegion;
                option.value = response[i].id;
                regSelect.add(option);
            }

            $('.classRegion').css('display','block');
        }
    });
}


function getSities(event) {
    //$('#selectIDSity').empty();
    $.ajax({
        url: 'GetSities',
        type: "POST",
        //  processData: false,
        // contentType: false,
        data: { id: parseInt(event.value) },
        success: function (response) {

            var regSelect = document.getElementById("selectIDSity");
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameSity;
                option.value = response[i].id;
                regSelect.add(option);
            }

            $('.classSity').css('display', 'block');
        }
    });
}


//$(document).ready(function () {

//    $.ajax({
//        url: 'GetAllCRS',
//        type: "POST",
//        success: function (response) {
//            for(var i = 0; i < response.countries.length; i++)
//            {
//                //$('#selectID').append('<option value="' + response[i].id + '" selected="selected">' + response[i].NameCountry + '</option>');
//            }
//        },
//        error: function (error) {
//            alert(error);
//        }

//    });
//});

