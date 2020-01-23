var ErrorHandle = (function() {
    init();

	function init() {
        $('#error-modal-close').on('click', function () {
            $('#layout-error-container').empty();
            $('.modal-backdrop').remove();
        });
    }

	function showErrorPopup(err) {
		var error = $('#layout-error-container');
		error.html(err.responseText);
		$('#error-modal').modal('show');
	}

	return {
		showErrorPopup(err) {
			return showErrorPopup(err);
		}
	}
})();