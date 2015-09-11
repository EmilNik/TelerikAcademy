(function () {
	var sammyApp = Sammy('#content', function () {
		this.get('#/', function () {
			this.redirect('#/home');
		});

		this.get('#/home', homeController.all);

		this.get('#/cookies-add', cookiesAddController.add);

		this.get('#/my-cookie', myCookieController.get);

		this.get('#/users/register', userController.register);

	});


	$(function () {
		sammyApp.run('#/');

		if (data.users.hasUser()) {
			$('#container-sign-in').addClass('hidden');
			$('#btn-sign-out').on('click', function () {
				data.users.logout()
					.then(function () {
						document.location = '#/';
						document.location.reload(true);
					});
			});
		} else {
			$('#container-sign-out').addClass('hidden');
			$('#btn-sign-in').on('click', function (e) {
				e.preventDefault();
				var user = {
					username: $('#tb-username').val(),
					password: $('#tb-password').val()
				};
				data.users.login(user)
					.then(function (user) {
						document.location = '#/';
						document.location.reload(true);
						toastr.success('User logged in!');
					}, function (err) {
						$('#container-sign-in').trigger("reset");
						toastr.error(err.responseText);
					});
			});
		}
	})
} ())