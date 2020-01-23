var Teams = (function() {

    //var connection = new signalR.HubConnectionBuilder()
    //    .withUrl("/teamHub", {
    //        skipNegotiation: true,
    //        transport: signalR.HttpTransportType.WebSockets
    //    })
    //    .build();
    //connection.on("UpdateTeams", function() {
    //    updateDataTable();
    //});

    //connection.start();

    function setCreateScript() {
        $('#team-create-submit').on('click', function (e) {
            e.preventDefault();
            var form = $('#team-create-form');
            $('#popup-container').empty();
            $('.modal-backdrop').remove();
            $.ajax({
                url: '../Teams/Create',	
                type: 'POST',
                data: form.serialize(),
                success: function() {
                    updateDataTable();
                },
                Error: function (err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
        });
    }

    function setUpdateScript() {
        $('#team-update-submit').on('click', function(e) {
            e.preventDefault();
            var form = $("#update-team-form");
            $('#popup-container').empty();
            $('.modal-backdrop').remove();
            $.ajax({
                url: '../Teams/Update',
                type: 'POST',
                data: form.serialize(),
                success: function() {
                    updateDataTable();
                },
                Error: function(err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
        });
    }

    function updateTeam(id) {
        $.ajax(
            {
                url: '../Teams/Update',
                type: 'GET',
                data: { id: id },
                success: function(data) {
                    $('#popup-container').html(data);
                    setUpdateScript();
                    $('#team-update-modal').modal('show');
                },
                Error: function(err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
    }

    function deleteTeam(teamId) {
        $.ajax(
            {
                url: '../Teams/Delete',
                type: 'GET',
                data: { id: teamId },
                success: function(data) {
                    $('#popup-container').html(data);
                    setDeleteScript();
                    $('#team-delete-modal').modal('show');
                },
                error: function(err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
    }

    function createTeam() {
            $.ajax({
                url: '../Teams/Create',
                type: 'GET',
                success: function(data) {
                    $('#popup-container').html(data);
                    Teams.setCreateScript();
                    $('#team-create-modal').modal('show');
                },
                error: function(err) {
                    ErrorHandle.showErrorPopup(err);
                }
            });
    }

    function setDeleteScript() {
        $('#team-delete-submit').on('click',
            function(e) {
                e.preventDefault();
                var deleteForm = $('#delete-team-form');
                $('#popup-container').empty();
                $('.modal-backdrop').remove();

                $.ajax({
                    url: '../Teams/Delete/',
                    type: 'POST',
                    data:  deleteForm.serialize() ,
                    success: function() {
                        updateDataTable();
                    },
                    error: function (err) {
                        ErrorHandle.showErrorPopup(err);
                    }
                });
            });
    }

    function updateDataTable() {
                $.ajax({
                    url: '../Teams/UpdateDataTable/',
                    type: 'GET',
                    success: function(data) {
                        var dataTableContainer = $('#teams-table-container');
                        dataTableContainer.empty();
                        dataTableContainer.html(data);
                    },
                    error: function (err) {
                        ErrorHandle.showErrorPopup(err);
                    }
                });
    }

    return {
        setCreateScript: function() {
            return setCreateScript();
        },
        updateTeam: function(teamId) {
            return updateTeam(teamId);
        },
        deleteTeam: function(teamId) {
            return deleteTeam(teamId);
        },
        createTeam: function() {
            return createTeam();
        },
        updateDataTable: function() { return updateDataTable() }
    }
})();