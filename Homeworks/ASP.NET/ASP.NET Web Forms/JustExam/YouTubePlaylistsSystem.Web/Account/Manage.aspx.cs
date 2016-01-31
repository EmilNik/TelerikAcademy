using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylistsSystem.Data;

namespace YouTubePlaylistsSystem.Web.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected string ErrorMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ProfileChangesSucceed" ? "Profile settings have been updated succesfully."
                        : message == "SetPwdSuccess" ? "Password was set successfully."
                        : message == "ChangePwdSuccess" ? "Password was changed succesfully."
                        : String.Empty;
                    ErrorMessage =
                        message == "InvalidEmail" ? "Email is invalid."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                    errorMessage.Visible = !String.IsNullOrEmpty(ErrorMessage);
                }
            }
        }

        protected void Page_PreRender()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            
            this.UserFirstName.Text = user.FirstName;
            this.UserLastName.Text = user.LastName;
            this.ImageURL.Text = user.imageURL;
            this.FaceBookURL.Text = user.FacebookURL;
            this.YouTubeURL.Text = user.YouTubeURL;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Change FirstName from user
        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            // string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            
            try
            {
                using (var db = new YouTubePlaylistsSystemDbContext())
                {
                    var userToUpdate = db.Users.SingleOrDefault(u => u.Id == user.Id);
                    if (userToUpdate != null)
                    {
                        userToUpdate.FirstName = this.UserFirstName.Text;
                        userToUpdate.LastName = this.UserLastName.Text;
                        userToUpdate.imageURL = this.ImageURL.Text;
                        userToUpdate.FacebookURL = this.FaceBookURL.Text;
                        userToUpdate.YouTubeURL = this.YouTubeURL.Text;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=ProfileChangesSucceed");
            }
        }
    }
}