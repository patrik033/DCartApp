function FormSubmit() {
    event.preventDefault();


    var file = document.getElementById("files").files[0];

    var newProduct = new FormData();
    newProduct.append("Subs.ProductName", $("#productName").val());
    newProduct.append("postedFile", file);
    newProduct.append("Subs.PosterImageUrl", $("#files").val());
    newProduct.append("Subs.ProductPrice", $("#productPrice").val());
    newProduct.append("Subs.QuantityInStock", $("#quantityInStock").val());
    newProduct.append("Subs.IsFeatured", $("#featured").val());
    newProduct.append("Subs.SubCategoryId", $("#subId").val());



    $.ajax({
        type: "POST",
        url: "/Product/CreateJson",
        processData: false,
        contentType: false,
        data: newProduct,

        success: function (response) {
            $(document).ready(function () {
                $("#exampleModalPost").modal("hide");
                $('#post-method').load('/Product/PartialForm');
            });

        },
        error: function (response) {
            console.log(response);
            alert("Oops it looks like you didn't fill out the form");
            CreateProduct();
        }
    });

}


function CreateProduct() {
    $.ajax({
        type: "GET",
        url: "/Product/_PartialCreate",
        success: function (response) {
            console.log(response);
            $("#exampleModalPost").modal("show");
            $("#test1").html(response);
        }
    });
}



function View(value) {
    event.preventDefault();

    $.ajax({
        type: "GET",
        url: `/Product/_PartialView/${value}`,
        success: function (response) {
            $("#exampleModalView").modal("show");
            $("#test").html(response);

        }
    });
}

function Delete(product) {
    event.preventDefault();
    console.log(product);
    $.ajax({
        type: "GET",
        url: `/Product/_PartialDelete/${product}`,
        success: function (response) {
            $("#exampleModalDelete").modal("show");
            $("#test2").html(response);
        }
    });
}

function FormDelete(product) {
    event.preventDefault();
    console.log(product);
    $.ajax({
        type: "POST",
        url: "/Product/DeleteJson",
        data: { id: product },
        success: function (response) {
            $(document).ready(function () {

                $("#exampleModalDelete").modal("hide");
                $('#post-method').load('/Product/PartialForm');
            });
        }
    });
}

function Edit(product) {
    event.preventDefault();
    console.log(product);
    $.ajax({
        type: "GET",
        url: `Product/_PartialEdit/${product}`,
        success: function (response) {
            $("#exampleModalEdit").modal("show");
            $("#test3").html(response);
        }
    });
}

function FormEdit(some) {
    var file = document.getElementById("files").files[0];
    var newProduct = new FormData();
    var date = Date.now();
    var fileName = $("#files").val();
    if (fileName === null) {
        newProduct.append("Subs.PosterImageUrl", some.posterImageUrl);
    }
    else {

        newProduct.append("Subs.PosterImageUrl", $("#files").val());
    }
    newProduct.append("Subs.Id", some.id);
    newProduct.append("Subs.DateUpdated", date);
    newProduct.append("Subs.ProductName", $("#productName").val());
    newProduct.append("postedFile", file);



    newProduct.append("Subs.ProductPrice", $("#productPrice").val());
    newProduct.append("Subs.QuantityInStock", $("#quantityInStock").val());
    newProduct.append("Subs.IsFeatured", $("#featured").val());
    newProduct.append("Subs.SubCategoryId", $("#subId").val());



    $.ajax({
        type: "POST",
        url: "/Product/EditJson",
        processData: false,
        contentType: false,
        data: newProduct,

        success: function (response) {
            $(document).ready(function () {
                $("#exampleModalEdit").modal("hide");
                $('#post-method').load('/Product/PartialForm');
            });

        },
        error: function (response) {
            console.log(response);
            alert("Oops it looks like you didn't fill out the form");
            CreateProduct();
        }
    });
}

