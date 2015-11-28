'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");

function initializePage() {

    $(document).ready(function () {
        getAllUsers();
        $('#addBtn').click(saveUser);
    });


    function saveUser() {
        //write the code to save a user to the sharepoint list here
    }

    function getAllUsers() {
        //Write the code to get all users from the sharepoint list here
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
    //write the code to delete a user from the sharepoint list here
}