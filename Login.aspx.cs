using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamAxity
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usr = txtUser.Text.Trim();
            string psw = TxtPassword.Text.Trim();
            string responseAPI = string.Empty;
            int response = 0;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string port = url.Split(':').Last().Split('/').First();
            Uri address = null;

            address = new Uri("https://localhost:"+ port + "/api/Users/Login/" + usr + "/" + psw);
            responseAPI = (string)CallAPI(address);
            response = responseAPI.Split(',').Length;

            if (response == 5)
            {
                Response.Redirect("Products.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Usuario o Password Incorecto";
            }
        }

        private static object CallAPI(Uri address)
        {
            string responseAPI = string.Empty;
            try
            {
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    responseAPI = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return responseAPI;
        }
    }
}