function addToCart(bookId) {
    fetch('/Cart/Add/' + bookId, {
        headers: { 'X-Requested-With': 'XMLHttpRequest' }
    })
    .then(function(res) { return res.json(); })
    .then(function(data) {
        showToast(data.message, data.success ? 'success' : 'error');

        if (data.newStock !== undefined) {
            var stockEl = document.getElementById('stock-' + bookId);
            if (stockEl) stockEl.textContent = data.newStock;
        }
    });
}

function showToast(message, type) {
    var container = document.getElementById('toast-container');
    var toast = document.createElement('div');
    toast.className = 'toast toast-' + type;
    toast.textContent = message;
    container.appendChild(toast);

    setTimeout(function() {
        toast.classList.add('toast-hide');
        setTimeout(function() {
            if (toast.parentNode) toast.parentNode.removeChild(toast);
        }, 400);
    }, 3000);
}
