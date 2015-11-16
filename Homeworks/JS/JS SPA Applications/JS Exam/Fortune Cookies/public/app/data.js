var data = function () {
	var LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
		LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

	/* Users */
	function login(user) {
		var reqUser = {
			username: user.username,
			passHash: CryptoJS.SHA1(user.username + user.password).toString()
		};

		var options = {
			data: reqUser
		};

		return jsonRequester.put('api/auth', options)
			.then(function (resp) {
				var user = resp.result;
				localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
				localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
				return user;
			});
	}


	function register(user) {
		var reqUser = {
			username: user.username,
			passHash: CryptoJS.SHA1(user.username + user.password).toString()
		};

		return jsonRequester.post('api/users', {
			data: reqUser
		})
			.then(function (resp) {
				var user = resp.result;
				localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
				localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
				return {
					username: resp.result.username
				};
			});
	}

	function logout(user) {
		var promise = new Promise(function (resolve, reject) {
			localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
			localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
			resolve();
		});
		return promise;
	}

	function hasUser() {
		return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
			!!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
	}

	function signOut() {
		var promise = new Promise(function (resolve, reject) {
			localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
			localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
			resolve();
		});
		return promise;
	}
	
	//cookies
	
	function getCookies() {
		return jsonRequester.get('api/cookies')
			.then(function (resCookies) {
				return resCookies
			});
	}

	function myCookie() {
		var options = {
			headers: {
				'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
			}
		};

		return jsonRequester.get('api/my-cookie', options)
			.then(function (resCookie) {
				console.log('hourly cookie ' + resCookie.result);
				return resCookie.result;
			})
	}

	function add(cookie) {
		var options = {
			data: cookie,
			headers: {
				'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
			}
		};

		return jsonRequester.post('api/cookies', options)
			.then(function (resCookie) {
				return resCookie;
			})
	}

	function rateCookie(id, type) {
		var options = {
			headers: {
				'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
			},
			data: {
				type: type
			}
		};

		jsonRequester.put('api/cookies/' + id, options)
            .then(function (res) {
				document.location.reload(true);
				return res;
            })
	}
	
	function getCookieById(id) {
		var options = {
			headers: {
				'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
			}
		};
		
		jsonRequester.get('api/cookies/' + id, options)
            .then(function (res) {
				console.log(res);
				return res;
            })
	}

	return ({
		users: {
			login: login,
			register: register,
			logout: logout,
			hasUser: hasUser,
			signOut: signOut
		},
		cookies: {
			add: add,
			getCookies: getCookies,
			myCookie: myCookie,
			rateCookie: rateCookie,
			getCookieById: getCookieById
		}
	})
} ();