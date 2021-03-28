$(document).ready(function () {

    $("#goButton").on("click", function () {
        console.log("get-user-repositories/" + $("#user").val() + "/" + $("#token").val() + "/" + encodeURIComponent($("#uri").val()))
        $.ajax({
            type: "GET",
            url: "get-user-repositories/" + $("#user").val() + "/" + $("#token").val() + "/" + encodeURIComponent($("#uri").val()),
            //data: JSON.stringify({ uri: "'" + $('#uri').val() + "'" }),
            success: function (data) {
                $("#grid").html(data);
            }
            
        });
    });
   
});