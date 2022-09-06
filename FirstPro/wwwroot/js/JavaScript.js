


function showlistOfPerson() {

    $.ajax({
        type: "GET",
        url: "Ajax/Peopole",
        success: function (output) {
            console.log(output);
            document.getElementById("show").innerHTML = output;

        }
    })
}


function deletePerson() {
        var id = document.getElementById("Id").value
        $.ajax({
            type: "POST",
            url: `Ajax/Delete/${id}`,
            success: function (output) {
                console.log(output);
                document.getElementById("show").innerHTML = output;
            }
        })
    }


function personDetails() {
    var id = document.getElementById("Id").value;
    
  
        $.ajax({
            type: "POST",
            url: `Ajax/Details/${id}`,
            success: function (output) {
                document.getElementById("show").innerHTML = output;

            }
        })
    }
