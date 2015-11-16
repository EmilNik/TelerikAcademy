var userController = function () {

	function register(context) {
		templates.get('register')
			.then(function (template) {
				context.$element().html(template());

				$('#btn-register').on('click', function () {
					var username = $('#tb-reg-username').val(),
						password = $('#tb-reg-pass').val(),
						user;
						
						if(typeof(username) !== 'string') {
							$('#username-err').fadeIn(500);
							return;
						}
						
						if(username.length < 6 || username.length > 30) {
							$('#username-err').fadeIn(500);
							return;
						}
						
						if(!/^[a-zA-Z_.]*$/.test(username)) {
							$('#username-err').fadeIn(500);
							return;
						}
						
						user = {
						username: username,
						password: password
					};

					data.users.register(user)
						.then(function () {
							toastr.success('User registered!');
							context.redirect('#/');
							document.location.reload(true);
						});
				});
			});
	}

	return {
		register: register
	}
} ()