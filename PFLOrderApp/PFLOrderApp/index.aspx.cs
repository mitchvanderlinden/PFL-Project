using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PFLOrderApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ProductView view = new ProductView();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Client client = new Client();
            List<Product> products = client.GetProducts();

            foreach (Product prod in products)
            {
                ProductView view = new ProductView();
                view.product = prod;
                mainform.Controls.Add(view);
            }
        }
    }
}