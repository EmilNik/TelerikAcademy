var cookiesAddController = function () {

	function add(context) {
		templates.get('cookiesAdd')
			.then(function (template) {
				context.$element().html(template())

				$('#btn-cookies-add').on('click', function () {
					var text = $('#tb-cookies-title').val(),
						category = $('#tb-cookies-category').val(),
						img = $('#tb-cookies-image').val();

					if (typeof (text) !== 'string') {
						$('#tb-cookies-title-err').fadeIn(500);
						return;
					}

					if (text.length < 6 || text.length > 30) {
						$('#tb-cookies-title-err').fadeIn(500);
						return;
					}
					
					if (typeof (category) !== 'string') {
						$('#tb-cookies-category-err').fadeIn(500);
						return;
					}

					if (category.length < 6 || category.length > 30) {
						$('#tb-cookies-category-err').fadeIn(500);
						return;
					}
					
					if(img == '') {
						img = 'http://rack.2.mshcdn.com/media/ZgkyMDEyLzEyLzA0LzI0L2JhdG1hbndhbnRjLmJlWS5qcGcKcAl0aHVtYgk0MDB4MjMwIwplCWpwZw/94b62835/c01/batman-want-cookie-video--7897209d85.jpg'
					}
					
					if(typeof(img) !== 'string') {
						$('#tb-cookies-image-err').fadeIn(500);
						return;
					}
					
					if(!/[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?/gi.test(img)) {
						$('#tb-cookies-image-err').fadeIn(500);
						return;
					}

					var cookie = {
						text: text,
						category: category,
						img: img
					}

					data.cookies.add(cookie)
						.then(function (resCookie) {
							toastr.success('Cookie added successfully!')
							context.redirect('#/');
							document.location.reload(true);
						});
				})
			})
	}

	return {
		add: add
	}
} ();