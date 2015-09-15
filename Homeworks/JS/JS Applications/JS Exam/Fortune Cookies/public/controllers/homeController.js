var homeController = function () {

  function all(context) {
    var cookies,
        returnCookies = [],
        category = this.params.category;
    
    data.cookies.getCookies()
      .then(function (resCookies) {
        cookies = resCookies.result;
        cookies.forEach(function (cookie) {
          
          if(category != undefined) {
            if(cookie.category === category) {
              returnCookies.push(cookie);
            }
          } else {
            returnCookies = cookies;
          }
          
          cookie.ago = moment(cookie.shareDate).fromNow();
        }, this);
        return templates.get('home')
      })
      .then(function (template) {
        context.$element().html(template(returnCookies));
        
        if (!data.users.hasUser()) {
          $('#add-cookie-btn').addClass('hidden');
          $('.users-can-see-this').addClass('hidden');
        }
        
        $('#category-search-btn').on('click', function() {
          var input = $('#category-search-val').val();
          
          if(input == "") {
            location.hash = '#/home'
            return;
          }
          
          location.hash = '#/home?category=' + input;
          document.location.reload(true);
        })

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
            
            data.cookies.add(cookie);
            return;
          }

          data.cookies.rateCookie(id, type);
      });
  }
      )}

  return {
    all: all
  };
} ();
