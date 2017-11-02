(function (customer) {
    customer.success = successReload;

    return customer;

    function successReload() {
        cibertec.closeModal();        
    }

})(window.customer = window.customer || {});