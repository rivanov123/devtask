var Matches = (function() {
    function createMatch() {
        $.ajax({
            url: '../Matches/Create',
            type: 'GET',
            success: function(data) {
                $('#popup-container').html(data);
                Matches.setCreateScript();
                $('#match-create-modal').modal('show');
            },
            error: function(err) {
                ErrorHandle.showErrorPopup(err);
            }
        });
    }

    function setCreateScript() {
        $('#match-create-submit').on('click', function (e) {
            e.preventDefault();
            var form = $('#match-create-form');
            $('#popup-container').empty();
            $('.modal-backdrop').remove();
            $.ajax({
                url: '../Matches/Create',	
                type: 'POST',
                data: form.serialize(),
                success: function() {
                    updateDataTable();
                },
                error: function (err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
        });

        $.ajax({
            url: '../Teams/GetTeams',	
            type: 'GET',
            success: function(data) {
                $.each(data, function(index, item) {
                    $("#teamA-selector").append($('<option></option>').text(item));
                    $("#teamB-selector").append($('<option></option>').text(item));
                });
                    
            },
            error: function (err) {
                ErrorHandle.showErrorPopup(err);
            }
        });
    }

    function setDeleteScript() {
        $('#match-delete-submit').on('click',
            function(e) {
                e.preventDefault();
                var deleteForm = $('#delete-match-form');
                $('#popup-container').empty();
                $('.modal-backdrop').remove();

                $.ajax({
                    url: '../Matches/Delete/',
                    type: 'POST',
                    data: deleteForm.serialize(),
                    success: function() {
                        updateDataTable();
                    },
                    error: function(err) {
                        ErrorHandle.showErrorPopup(err);
                    }
                });
            });
    }

    function deleteMatch(matchId) {
            $.ajax(
                {
                    url: '../Matches/Delete',
                    type: 'GET',
                    data: { id: matchId },
                    success: function(data) {
                        $('#popup-container').html(data);
                        setDeleteScript();
                        $('#match-delete-modal').modal('show');
                    },
                    error: function(err) {
                        ErrorHandle.showErrorPopup(err);
                    }
                });
        }

    function updateMatch(id) {
        $.ajax(
            {
                url: '../Matches/Update',
                type: 'GET',
                data: { id: id },
                success: function(data) {
                    $('#popup-container').html(data);
                    setUpdateScript();
                    $('#match-update-modal').modal('show');
                },
                error: function(err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
    }

    function setUpdateScript() {
        $('#match-update-submit').on('click', function(e) {
            e.preventDefault();
            var form = $("#update-match-form");
            $('#popup-container').empty();
            $('.modal-backdrop').remove();
            $.ajax({
                url: '../Matches/Update',
                type: 'POST',
                data: form.serialize(),
                success: function() {
                    updateDataTable();
                },
                error: function(err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
        });

        $.ajax({
            url: '../Teams/GetTeams',	
            type: 'GET',
            success: function(data) {
                $.each(data, function(index, item) {
                    $("#teamA-selector").append($('<option></option>').text(item));
                    $("#teamB-selector").append($('<option></option>').text(item));
                });
                    
            },
            error: function (err) {
                ErrorHandle.showErrorPopup(err);
            }
        });
    }

    function updateDataTable() {
        $.ajax({
            url: '../Matches/UpdateDataTable/',
            type: 'GET',
            success: function(data) {
                var dataTableContainer = $('#match-table-container');
                dataTableContainer.empty();
                dataTableContainer.html(data);
            },
            error: function(err) {
                ErrorHandle.showErrorPopup(err);
            }
        });
    }

    return {
        createMatch: function() {
            return createMatch();
        },
        setCreateScript: function() {
            return setCreateScript();
        },
        deleteMatch: function(matchId) {
            return deleteMatch(matchId);
        },
        updateMatch: function(matchId) {
            return updateMatch(matchId);
        }
    }
})();