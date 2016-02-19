namespace JustAsk.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using JustAsk.Common;
    using JustAsk.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
