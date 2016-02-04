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