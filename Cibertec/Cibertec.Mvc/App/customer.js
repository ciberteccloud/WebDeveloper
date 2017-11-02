(function (customer) {
    customer.success = successReload;

    return customer;

    function successReload(option) {
        cibertec.closeModal(option);
    }

})(window.customer = window.customer || {});