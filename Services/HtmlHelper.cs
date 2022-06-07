using System.Web.UI.WebControls;


namespace EmployeeServices.Services
{

        public static class HtmlHelper
        {

            public static void ShowStatusMessage(this Label label, string message)
            {
                label.Text = message;
                label.Visible = true;

            }
        }
    }


