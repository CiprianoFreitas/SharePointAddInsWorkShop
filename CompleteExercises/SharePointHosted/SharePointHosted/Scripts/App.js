'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");
var appweburl = decodeURIComponent(getQueryStringParameter('SPAppWebUrl'));

function initializePage() {

    var context = SP.ClientContext.get_current();

    $(document).ready(function () {
        getAllUsers();
        $('#addBtn').click(saveUser);
    });



    function saveUser() {
        var newUser = {
            '__metadata': { 'type': 'SP.Data.UsersListItem' },
            'Title': $('#username').val(),
            'Age': $('#age').val()
        };

        addUserToUsersContainer(newUser);
        $.ajax({
            url: appweburl + "/_api/lists/getbytitle('Users')/items",
            type: "POST",
            data: JSON.stringify(newUser),
            headers: {
                "X-RequestDigest": $('#__REQUESTDIGEST').val(),
                "IF-MATCH": "*",
                accept: "application/json;odata=verbose",
                "Content-Type": "application/json;odata=verbose"
            },
            success: function () {
                location.reload()
            }
        });
    }

    function getAllUsers() {
        $.ajax({
            url: appweburl + "/_api/lists/getbytitle('Users')/items",
            type: "GET",
            headers: {
                accept: "application/json;odata=verbose",
                "Content-Type": "application/json;odata=verbose"
            },
            success: function (data) {
                var results = data.d.results;
                for (var i = 0; i < results.length; i++) {
                    addUserToUsersContainer(results[i]);
                }
            }
        });
    }

    function addUserToUsersContainer(user) {
        $('<li>' + user.Title + ' - ' + user.Age + ' (<a href="#" onclick="deleteUser(' + user.Id + ')">Delete User</a>)</li>').appendTo($('#results'));
    }

}

function getQueryStringParameter(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function deleteUser(userId) {
    $.ajax({
        url: appweburl + "/_api/lists/getbytitle('Users')/items(" + userId + ")",
        type: "POST",
        headers: {
            "X-RequestDigest": $('#__REQUESTDIGEST').val(),
            "IF-MATCH": "*",
            "X-HTTP-Method": "DELETE"
        },
        success: function(){
            location.reload();
        }
    });
    return false;
}