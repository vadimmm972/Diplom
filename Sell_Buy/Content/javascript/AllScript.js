function AddImg() {
    var homUrl = $("#hdnHomePageUrl").val();
    homUrl = homUrl ? homUrl : window.location.host + "/";
    homUrl = homUrl.concat('test/UploadImage');


    var data = new FormData();
    var files = $("#imgSource .imgsource").get(0).files;
    if (files.length > 0) {
        data.append("HelpSectionImages", files[0]);
       
    }
    else {
        alert("error");
        return;
    }
    data.append("id", 11);
    data.append("elementid", 11);
    $.ajax({
        url: 'Authorization/UploadImage',
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            // $("body").append("<img src=\"" + response + "\" >");
            $("#imgSave").val(response);
        }
    });
}

function getRegions(event)
{
   
    $.ajax({
        url: 'Authorization/GetRegions',
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
        url: 'Authorization/GetSities',
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


//$(".updateInfo").on("click", function () {
function functionInfoUpdate() {
    $(".updateInfo").css('display', 'none');
    $(".dataInfo").css('display', 'none');
    $('.SaveUpdateInfo').css('display', 'block');
    //});




}

function getInfoUser() {
    $.ajax({
        url: 'StartPage/GetInfoUser',
        type: "POST",
        //   data: { id: parseInt(event.value) },
        success: function (response) {
          
            $('.infoFirstName').text(response[0].NameFirst);
            $('.infoLastName').text(response[0].NameLast);
            $('.infoMiddleName').text(response[0].NameMiddle);
            $('.infoPhone').text(response[0].Phone);
            $('.infoMail').text(response[0].Mail);
            $('.infoCountry').text(response[0].Country);
            $('.infoRegion').text(response[0].Region);
            $('.infoSity').text(response[0].Sity);

            }


        
    });
}


$(document).ready(function () {
    $('a#go').click(function (event) {
        event.preventDefault();
        $('#overlay').fadeIn(400,
		 	function () {
		 	    $('#modal_form')
					.css('display', 'block')
					.animate({ opacity: 1, top: '15%' }, 300);
		 	});
    });

    $('#modal_close, #overlay').click(function () {
        $('#modal_form')
			.animate({ opacity: 0, top: '10%' }, 200,
				function () {
				    $(this).css('display', 'none');
				    $('#overlay').fadeOut(400);
				}
			);
    });
});
