using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PFLOrderApp
{
    public partial class ProductView : System.Web.UI.UserControl
    {
        private Product prod;

        public Product product {
            get
            {
                return prod;
            }
            set
            {
                prod = value;
            }
        }

        private Panel main;
        private System.Web.UI.WebControls.Image img;
        private Label nameLabel;
        private Button orderButton;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            main = CreateMainPanel(300, 600);
            
            this.Controls.Add(main);
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {

        }

        private Panel CreateMainPanel(int height, int width)
        {
            Panel p = new Panel();
            p.Height = height;
            p.Width = width;

            nameLabel = CreateLabel(product.name, height / 2, width - height);
            orderButton = CreateButton("Order", height / 2, width - height);
            img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = product.imageURL;

            Table t = CreateTable(height, width);

            p.Controls.Add(t);

            return p;
        }

        private Label CreateLabel(string text, int height, int width)
        {
            Label l = new Label();
            l.Text = text;
            l.Height = height;
            l.Width = width;
            return l;
        }

        private Button CreateButton(string text, int height, int width)
        {
            Button b = new Button();
            b.Text = text;
            b.Height = height;
            b.Width = width;
            return b;
        }

        private Table CreateTable(int height, int width)
        {
            Table t = new Table();

            TableCell left = new TableCell();
            TableCell right = new TableCell();

            left.Width = height;
            right.Width = width - height;

            left.Controls.Add(img);
            right.Controls.Add(nameLabel);
            right.Controls.Add(orderButton);

            t.Rows.Add(new TableRow());
            t.Rows[0].Cells.Add(left);
            t.Rows[0].Cells.Add(right);

            return t;
        }
    }
}