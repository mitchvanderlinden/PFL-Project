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
            
        }

        // Initialize the main page
        protected void Page_Init(object sender, EventArgs e)
        {
            // For debugging purposes, print when the page posts back
            System.Diagnostics.Debug.WriteLine("Page Load");

            // Get the Client instance and initialize the main page table
            Client client = Client.GetInstance();
            List<Product> products = client.GetProducts();
            Table mainTable = new Table();
            mainTable.HorizontalAlign = HorizontalAlign.Center;
            mainTable.BorderWidth = 5;

            // Create a new ProductView control for each available product
            foreach (Product prod in products)
            {
                ProductView view = new ProductView();
                view.product = prod;
                view.Visible = true;

                TableCell cell = new TableCell();
                int bw = 5;
                cell.BorderWidth = bw;
                cell.Height = view.Height + bw * 2;
                cell.Width = view.Width + bw * 2;
                cell.Controls.Add(view);

                TableRow row = new TableRow();
                row.Cells.Add(cell);
                mainTable.Rows.Add(row);
            }
            // Add the table to the page
            mainform.Controls.Add(mainTable);
        }
    }
}