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
            // $("body").append("<img src=\"" + response + "\" >");
        }
    });
}
