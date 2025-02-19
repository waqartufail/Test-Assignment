using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Enums
{
    #region appsettings.json Variable Name
    public enum Main
    {
        XPATH_MENU,
        XPATH_LOGIN
    }
    #endregion
    public static class MainExtensions
    {
        #region IDENTIFIERS
        private static readonly Dictionary<Main, string> _pageVariables = new Dictionary<Main, string>
        {
            { Main.XPATH_MENU, "(//a[@id='menu-toggle'])" },
            { Main.XPATH_LOGIN, "(//li//a[contains(@href,'login')])" }
        };
        #endregion

        #region Methods
        public static string GetValue(this Main menu)
        {
            return _pageVariables[menu];
        }

        public static string GetPageVariables(this Main menu)
        {
            return _pageVariables[menu];
        }
        #endregion
    }
}
