using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EmployeeManagementProject.BAL_Class
{
    public class General
    {
        public void ShowMessage(Page page, string message)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + message + "');", true);
        }

        public void ShowMessageAndRedirect(Page page, string message, string url)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "redirect", "alert('" + message + "'); window.location='" + url + "';", true);
        }

    }
}