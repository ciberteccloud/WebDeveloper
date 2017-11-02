(function (cibertec) {

    cibertec.getModal = getModalContent;
    cibertec.closeModal = closeModal;

    return cibertec;

    function getModalContent(url) {
        $.get(url, function (data) {
            $('.modal-body').html(data);
        })
    }

    function closeModal() {        
        $("button[data-dismiss='modal']").click();
        $('.modal-body').html("");    
    }

})(window.cibertec = window.cibertec || {});