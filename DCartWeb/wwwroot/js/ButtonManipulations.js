function ButtonIncrease(value) {
    event.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Cart/Increase",
        data: { id: value },

        success: function (response) {
            $(document).ready(function () {
                $('#content-post').load('/Cart/LoadPartOfView');
                toastr.success(`One ${response.name} Added To Cart`);
            });
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}

function ButtonDelete(value) {
    event.preventDefault();
    $.ajax({
        type: "GET",
        url: "/Cart/LookUp",
        data: { id: value },
        success: function (response) {
            $.ajax({
                type: "POST",
                url: "/Cart/Delete",
                data: { id: value },
                success: function (responsePost) {
                    toastr.success(`${response.name} Deleted`);
                    $('#content-post').load('/Cart/LoadPartOfView');
                }
            });
        }
    });
}


function ButtonDecrease(value) {
    event.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Cart/Decrease",
        data: { id: value },

        success: function (response) {
            $(document).ready(function () {
                $('#content-post').load('/Cart/LoadPartOfView');
                toastr.success(`One ${response.name} Removed From Cart`);
            });
        },
        error: function () {
            alert("Error occured!!")
        }
    });

}