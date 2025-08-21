using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    public class BaseController : ControllerBase
    {
        private protected int _loggedInUserId;
        private protected List<string>? _loggedInUserDesignations;

        protected int LoggedInUserId
        {
            get { return GetLoggedInUserId(); }
        }
        protected List<string> LoggedInUserDesignations
        {
            get { return GetLoggedInUserDesignations(); }
        }

        #region :: Get LoggedIn UserId ::
        protected int GetLoggedInUserId()
        {
            var userIdClaim = User.FindFirst("LoggedInUserId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int parsedUserId))
                return parsedUserId;

            else
                throw new Exception("UserId can not be empty");
        }
        #endregion

        #region :: Get LoggedIn User Designations ::
        protected List<string> GetLoggedInUserDesignations()
        {
            var designationClaims = User.FindAll("Designation");

            if (designationClaims != null && designationClaims.Any())
                return designationClaims.Select(c => c.Value).ToList();

            return new List<string>();
        }
        #endregion
    }
}
