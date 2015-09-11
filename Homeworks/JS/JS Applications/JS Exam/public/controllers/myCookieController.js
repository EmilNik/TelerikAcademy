var myCookieController = function () {

	function get(context) {
		var myCookie;

		data.cookies.myCookie()
			.then(function (resCookies) {
				myCookie = resCookies;
				return templates.get('myCookie')
			})
			.then(function (template) {
				context.$element().html(template(myCookie));
				$('.like-dislike-buttons').on('click', function (ev) {
					var type,
						id;

					if (ev.target.id) {
						id = ev.target.id.trim();
					} else {
						id = ev.target.parentNode.id.trim();
					}

					if (ev.target.className.indexOf('like') > 0) {
						type = 'like';
					} else if (ev.target.className.indexOf('dis') > 0) {
						type = 'dislike';
					} else {
						var cookie = {

						}
						//reshare cookie
            
						// data.cookies.add(cookie);
						return;
					}

					data.cookies.rateCookie(id, type);
				});
			})
	}


	return {
		get: get
	}
} ()