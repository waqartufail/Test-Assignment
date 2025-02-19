using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Enums
{
    #region .json Variable Name
    public enum Login
    {
        XPATH_LOGIN_HEADING,
        XPATH_USER_NAME,
        XPATH_PASSWORD,
        XPATH_LOGIN,
        XPATH_DASHBOARD,
        XPATH_LEFT_MENU,
        XPATH_LOG_OUT,
        XPATH_ERROR
    }
    #endregion
    public static class LoginExtensions
    {
        #region IDENTIFIERS
        private static readonly Dictionary<Login, string> _pageVariables = new Dictionary<Login, string>
        {
            { Login.XPATH_LOGIN_HEADING, "(//h2)" },
            { Login.XPATH_USER_NAME, "(//input[@id='txt-username'])" },
            { Login.XPATH_PASSWORD , "(//input[@id='txt-password'])" },
            { Login.XPATH_LOGIN, "(//button[@id='btn-login'])" },
            { Login.XPATH_ERROR,"(//p[@class='lead text-danger'])"}
        };
        #endregion

        #region Method
        public static string GetValue(this Login login)
        {
            return _pageVariables[login];
        }
        public static string GetPageVariables(this Login login)
        {
            return _pageVariables[login];
        }
        #endregion
    }
}
