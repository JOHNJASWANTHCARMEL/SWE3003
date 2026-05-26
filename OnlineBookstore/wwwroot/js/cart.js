function addToCart(bookId) {
    fetch('/Cart/Add?bookId=' + bookId, {
        method: 'POST'
    })
    .then(res => res.json())
    .then(data => {
        alert("Added to cart!");
        document.getElementById("cartCount").innerText = data.count;
    });
}