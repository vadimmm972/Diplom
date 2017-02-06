function AddImg(option) {
    var op;
    if (option == "magImg")
    {
        op = "1";
    }
    if (option == "usimg")
    {
        op = "2";
    }

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
    data.append("operation", op);
    $.ajax({
        url: 'Authorization/UploadImage',
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            // $("body").append("<img src=\"" + response + "\" >");
            if (op == "1") {
                $("#imgSaveMag").val(response);
            }
            if (op == "2") {
                $("#imgSave").val(response);
            }
           
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
        data: { id: parseInt(event.value) , Name: "none" },
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


// Update Info to users
function infoFirstNameUser(event) {

    $(".infoFirstName").css('display', 'none');
    $(".frName").css('display', 'none');
    $(".updFirstName").val(event.innerText);
    $(".updFirstName").css('display', 'block');
   
}


function infoLasttNameUser(event) {

   
    $(".lsName").css('display', 'none');
    $(".infoLastName").css('display', 'none');
    $(".updLastName").val(event.innerText);
    $(".updLastName").css('display', 'block');
    
    
}

function infoMiddleNameUser(event) {


    $(".mdlName").css('display', 'none');
    $(".infoMiddleName").css('display', 'none');
    $(".udMiddleName").val(event.innerText);
    $(".udMiddleName").css('display', 'block');


}

function infoPhoneUser(event) {


    $(".usPhone").css('display', 'none');
    $(".infoPhone").css('display', 'none');
    $(".updPhone").val(event.innerText);
    $(".updPhone").css('display', 'block');
}

function infoMailUser(event) {


    $(".usMail").css('display', 'none');
    $(".infoMail").css('display', 'none');
    $(".updMail").val(event.innerText);
    $(".updMail").css('display', 'block');
}

function infoCountryUser(event) {


   


    $.ajax({
        url: 'Authorization/GetCountries',
        type: "POST",
        //  processData: false,
        // contentType: false,
        //  data: { Name: event.value },
        success: function (response) {

            var regSelect = document.getElementById("pullCountry");
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameCountry;
                option.value = response[i].id;
                regSelect.add(option);
            }

            $(".usCountry").css('display', 'none');
            $(".infoCountry").css('display', 'none');
            // $(".updCountry").val(event.innerText);
            //   document.getElementById("test").value = "test";
            //for (var j = 0; j < regSelect.childElementCount;j++)
            //{

            //}

            //document.getElementById('test').options[0].selected = true;

            $(".updCountry").css('display', 'block');
        }
    });

           
}

function infoRegionUser(event) {

    var nameCountry = $('.infoCountry');
    $.ajax({
        url: 'Authorization/GetRegions',
        type: "POST",
        //  processData: false,
        // contentType: false,
        data: { Name: nameCountry[0].innerText },
        success: function (response) {

            var regSelect = document.getElementById("pullRegions");
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameRegion;
                option.value = response[i].id;
                regSelect.add(option);
            }

            $(".usRegion").css('display', 'none');
            $(".infoRegion").css('display', 'none');
            $(".updRegion").val(event.innerText);
            $(".updRegion").css('display', 'block');
        }
    });


}

function infoSityUser(event) {


    var nameCountry = $('.infoRegion');
    $.ajax({
        url: 'Authorization/GetSities',
        type: "POST",
        //  processData: false,
        // contentType: false,
        data: {id:0, Name: nameCountry[0].innerText },
        success: function (response) {

            var regSelect = document.getElementById("pullSites");
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameSity;
                option.value = response[i].id;
                regSelect.add(option);
            }

            $(".usSity").css('display', 'none');
            $(".infoSity").css('display', 'none');
            $(".updSity").val(event.innerText);
            $(".updSity").css('display', 'block');
        }
    });

    
}


function CategoryMagazine(event) {
    $("#idcategoryToMagazine").val(event.value);
}


function CreateMagazine()
{
    
    var name = $('#nameMagazine').val();
    var photo = $('#imgSaveMag').val();
    var idCategory = $('#idcategoryToMagazine');
    if (name.length <= 0 || photo.length <= 0 || idCategory == null)
    {
        alert("не все поля заполнены");
        return null;
    }
    $.ajax({
        url: 'CreateMagazine/CreateMagazine',
        type: "POST",
        //  processData: false,
        // contentType: false,
        data: { nameMagazine: name, photo: photo, idCategory: idCategory[0].value },
        success: function (response) {

            var regSelect = document.getElementById("pullSites");
            for (var i = 0; i < response.length; i++) {
                var option = document.createElement("option");
                option.text = response[i].NameSity;
                option.value = response[i].id;
                regSelect.add(option);
            }
        }
    });
}

