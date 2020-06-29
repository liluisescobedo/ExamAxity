using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ExamAxity.Models.Response;
using Newtonsoft.Json;

namespace ExamAxity
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string responseAPI = string.Empty;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string port = url.Split(':').Last().Split('/').First();
            Uri address = null;
            address = new Uri("https://localhost:"+ port + "/api/Products/GetAllProducts");
            responseAPI = (string)CallAPI(address);

            ProductResponse[] products = JsonConvert.DeserializeObject<ProductResponse[]>(responseAPI);

            HtmlTable table = new HtmlTable();
            HtmlTableRow header = new HtmlTableRow();

            HtmlTableCell headerCell = new HtmlTableCell("th");
            headerCell.InnerText = "IdProduct";
            header.Cells.Add(headerCell);

            headerCell = new HtmlTableCell("th");
            headerCell.InnerText = "Nombre";
            header.Cells.Add(headerCell);

            headerCell = new HtmlTableCell("th");
            headerCell.InnerText = "Costo";
            header.Cells.Add(headerCell);

            headerCell = new HtmlTableCell("th");
            headerCell.InnerText = "CantidadInventario";
            header.Cells.Add(headerCell);

            table.Rows.Add(header);

            foreach (var product in products)
            {
                table.Rows.Add(AddRow(product));
            }

            phTest.Controls.Add(table);
        }

        public HtmlTableRow AddRow(ProductResponse item)
        {
            HtmlTableRow result = new HtmlTableRow();

            result.Cells.Add(new HtmlTableCell() { InnerText = item.IdProduct.ToString() });
            result.Cells.Add(new HtmlTableCell() { InnerText = item.Nombre });
            result.Cells.Add(new HtmlTableCell() { InnerText = item.Costo });
            result.Cells.Add(new HtmlTableCell() { InnerText = item.CantidadInventario });

            return result;
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