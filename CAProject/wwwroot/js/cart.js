window.onload = function() {
    AddToCart();
}

function AddToCart() {
    let product_list = document.getElementsByClassName("product_list");

    for(let i = 0; i < product_list.length; i++)
    {
        let product = product_list[i];
        product.addEventListener("click", on_click_add_to_cart);
    }
}

function on_click_add_to_cart() {

    let id = event.target.id; 
    let productid = parseInt(id);
   let xhr = new XMLHttpRequest();
    xhr.open("POST", "/Home/AddToCart");
    xhr.setRequestHeader("Content-Type",
        "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function() {
        if (this.readyState == XMLHttpRequest.DONE)
        {
            let data = JSON.parse(this.responseText);
            document.getElementById("cartQty").innerHTML = data.quantity;
        }
    }

    xhr.send("productId=" + productid);


}


