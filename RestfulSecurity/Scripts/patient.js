var tokenKey = 'bearerToken';

$(document).ready(function () {
    // Assign event handlers for the click event of the buttons
    $('#cancelBtn').click(function () {
        resetInputFields();
    });

    $('#addBtn').click(function () {
        createPatient();
    });

    $('#updateBtn').click(function () {
        updatePatient();
    });

    $('#searchBtn').click(function () {
        searchPatients();
    });

    // Assign event handlers for the dynamically generated rows
    $('#patientTableBody').on("click", "tr", function () {
        var firstname = $(this).data("firstname");
        var lastname = $(this).data("lastname");
        $('#selectedPatientLabel').text(" for " + firstname + " " + lastname);

        var patientId = $(this).attr("id");
        getImages(patientId);
    });

    $('#imageTableBody').on("click", "tr", function () {
        var imageFileName = $(this).data("filename");
        imageRowClick(imageFileName);
    });
});

function getHeaders() {
    var headers = {};
    var token = sessionStorage.getItem(tokenKey);
    if (token != 'undefined') {
        headers.Authorization = 'Bearer ' + token;
    }

    return headers;
}

function createPatient() {
    var patient = {
        Id: 0,
        Title: $('#title').val(),
        FirstName: $('#firstName').val(),
        LastName: $('#lastName').val(),
        Age: $('#age').val(),
        NumberOfEmbryos: $('#numberOfEmbryos').val()
    };

    $.ajax({
        url: '/api/patients',
        type: 'POST',
        data: JSON.stringify(patient),
        contentType: 'application/json; charset=utf-8',
        headers: getHeaders(),
        success: function (result) {
            resetInputFields();
            getPatients();
        },
        error: function () {
            alert("Error when adding a new patient!");
        }
    });
}

function updatePatient() {
    var patientId = $('#patientIdHidden').val();

    var patient = {
        Id: patientId,
        Title: $('#title').val(),
        FirstName: $('#firstName').val(),
        LastName: $('#lastName').val(),
        Age: $('#age').val(),
        NumberOfEmbryos: $('#numberOfEmbryos').val()
    };

    $.ajax({
        url: '/api/patients/' + patientId,
        type: 'PUT',
        data: JSON.stringify(patient),
        contentType: 'application/json; charset=utf-8',
        headers: getHeaders(),
        success: function (result) {
            resetInputFields();
            getPatients();
        },
        error: function () {
            alert("Error when adding a new patient!");
        }
    });
}

function getPatients() {
    $("#selectedPatientLabel").text("");

    $.ajax({
        url: '/api/patients',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        headers: getHeaders(),
        success: function (result) {
            createPatientTable(result);
        },
        error: function () {
            alert("Error when loading patients!");
        }
    });
}

function searchPatients() {
    var searchTerm = $('#searchPatient').val();

    $.ajax({
        url: '/api/patients/search?keyword=' + searchTerm,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        headers: getHeaders(),
        success: function (result) {
            createPatientTable(result);
        },
        error: function () {
            alert("Error when loading patients!");
        }
    });
}

function getImages(patientId) {
    $('#imageContainer').find("img").remove();

    $.ajax({
        url: '/api/patients/' + patientId + '/files',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        headers: getHeaders(),
        success: function (result) {
            createImageTable(result);
        },
        error: function () {
            alert("Error when loading images for patient!");
        }
    });
}

function createImageTable(images) {
    var tableRow = '';
    // Create the table rows dynamicly based on the JSON result
    $.each(images, function (index, image) {
        tableRow += '<tr data-filename="' + image.FileName + '"><td>' + (index + 1) +
                    '</td><td>' + image.FileName +
                    '</td></tr>';
    });

    $('#imageTableBody').html(tableRow);
}

function imageRowClick(imageName) {
    $('#imageContainer').find("img").remove();

    var filename = '/images/' + imageName;
    var img = $('<img />', {
        src: filename
    }).addClass("img-responsive");

    $('#imageContainer').html(img);
}

function resetInputFields() {
    $('#editForm').find("input[type=text], input[type=hidden]").val("");
    $('#addBtn').show();
    $('#updateBtn').hide();
    $('#cancelBtn').hide();
}

function createPatientTable(patients) {
    var tableRow = '';
    // Create the table rows dynamicly based on the JSON result
    $.each(patients, function (index, patient) {
        tableRow += '<tr data-firstName="'+ patient.FirstName + '" data-lastName="' + patient.LastName + '" id="' + patient.Id + '"><td>' + (index + 1) +
                    '</td><td>' + patient.Title +
                    '</td><td>' + patient.FirstName +
                    '</td><td>' + patient.LastName +
                    '</td><td>' + patient.Age +
                    '</td><td>' + patient.NumberOfEmbryos + '</td><td>' +
                    '<input type="button" onclick="editBtnClick(' + patient.Id + ')" class="btn btn-link" value="Edit" />' +
                    '<input type="button" onclick="deleteBtnClick(' + patient.Id + ')" class="btn btn-link" value="Delete" />' +
                    '</td></tr>';
    });

    $('#patientTableBody').html(tableRow);
}

function deleteBtnClick(patientId) {
    event.stopPropagation();
    
    // Create a dialogue box to confirm deletion of the selected patient
    $("#dialog-confirm-delete").dialog({
        resizable: false,
        height: 200,
        modal: true,
        buttons: {
            "Delete": function () {
                $.ajax({
                    url: '/api/patients/' + patientId,
                    type: 'DELETE',
                    headers: getHeaders(),
                    success: function () {
                        $("#selectedPatientLabel").text("");
                        getPatients();
                        resetInputFields();
                        $('#imageContainer').find("img").remove();
                        $('#imageTableBody').find("tr").remove();
                        
                    },
                    error: function () {
                        alert("Error when deleting patient!")
                    }
                });
                $(this).dialog("close");
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });
}

function editBtnClick(patientId) {
    $('#addBtn').hide();
    $('#updateBtn').show();
    $('#cancelBtn').show();

    $('#patientIdHidden').val(patientId);

    // Get the row in the table with the patient id
    var $row = document.getElementById(patientId);

    // Assign each value of the selected patient to the relevant text field in the create or update a patient area
    $.each($row.children, function (index, $element) {
        if (index == 1)
            $('#title').val($element.innerText);
        else if (index == 2)
            $('#firstName').val($element.innerText);
        else if (index == 3)
            $('#lastName').val($element.innerText);
        else if (index == 4)
            $('#age').val($element.innerText);
        else if (index == 5)
            $('#numberOfEmbryos').val($element.innerText);
    });
}

// Knockout JS View Model
function ViewModel() {
    var self = this;

    self.user = ko.observable();
    self.registerEmail = ko.observable();
    self.registerPassword = ko.observable();
    self.registerPassword2 = ko.observable();
    self.loginEmail = ko.observable();
    self.loginPassword = ko.observable();
    self.isAuthorised = ko.observable(false);

    self.register = function () {
        var registerData = {
            Email: self.registerEmail(),
            Password: self.registerPassword(),
            ConfirmPassword: self.registerPassword2()
        };

        $.ajax({
            type: 'POST',
            url: '/api/Account/Register',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(registerData),
            success: function (data) {
                alert("Registration successful! Now you are able to login using your new credentials.");
                self.loginEmail(self.registerEmail());
                self.registerEmail('');
                self.registerPassword('');
                self.registerPassword2('');
            },
            error: function (data) {
                alert("Error when registering! Please provide a valid email and a password of at least six characters long including one uppercase letter and one number.")
            }
        });
    }

    self.login = function () {
        var loginData = {
            grant_type: 'password',
            username: self.loginEmail(),
            password: self.loginPassword()
        };

        $.ajax({
            type: 'POST',
            url: '/Token',
            data: loginData,
            success: function (data) {
                self.user(data.userName);
                self.isAuthorised(true);

                // Add the bearer token in the session storage.
                sessionStorage.setItem(tokenKey, data.access_token);

                //load the patient data
                getPatients();
            },
            error: function (data) {
                alert("Error when logging in! Please check that your email and password are correct.");
            }
        });
    }

    self.logout = function () {
        $.ajax({
            type: 'POST',
            url: '/api/Account/Logout',
            headers: getHeaders(),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                self.user('');
                self.isAuthorised(false);
                self.loginPassword('');
                self.loginEmail('');

                // Remove the token from the session storage
                sessionStorage.removeItem(tokenKey);                
            },
            error: function () {
                alert("Error when logging out");
            }
        });
    }
}

var app = new ViewModel();
ko.applyBindings(app);