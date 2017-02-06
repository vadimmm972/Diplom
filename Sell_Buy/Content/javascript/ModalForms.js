

function GetAllMagazineUser() {

    $.ajax({
        url: 'ManagementMagazine/GetAllMagazinesUser',
        type: "POST",
        //  processData: false,
        // contentType: false,
       // data: { nameMagazine: name, photo: photo, idCategory: idCategory[0].value },
        success: function (response) {
            if(response != null)
            {
                $(".myMagazines").empty();
                for (var i = 0; i < response.length; i++)
                {
                    var htmlText = "<div>" + response[0].nameMagazine + "</div>"
                    $(".myMagazines").append(htmlText);
                }
            }
          
        }
    });
   //
}