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
        public int Height = 450;
        public int Width = 1200;

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

        // Main Panel Controls
        private Panel main;
        private System.Web.UI.WebControls.Image img;
        private Label nameLabel;
        private Button orderButton;

        // Secondary Panel Controls
        private Panel secondary;
        private string[] customerLabels = {"First Name", "Last Name", "Address 1", "Address 2",
                                            "City", "State", "Country Code", "Postal Code", "Email", "Phone"};
        private TextBox fname, lname, address1, address2, city, state, country, postal, email, phone;
        private TextBox[] customerInputs;

        protected void Page_Load(object sender, EventArgs e)
        {
            customerInputs = new TextBox[] { fname, lname, address1, address2, city, state, country, postal, email, phone };

            main = CreateMainPanel(Height, Width);
            secondary = CreateSecondaryPanel(Height, Width);

            this.Controls.Add(secondary);
            this.Controls.Add(main);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        private Panel CreateMainPanel(int height, int width)
        {
            Panel p = new Panel();
            p.Height = height;
            p.Width = width;

            nameLabel = CreateNameLabel(product.name, height / 6, width / 2);
            orderButton = CreateOrderButton("Order", height / 2, width / 2);
            img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = product.imageURL;

            Table t = CreateMainTable(height, width);

            p.Controls.Add(t);

            return p;
        }

        private Label CreateNameLabel(string text, int height, int width)
        {
            Label l = new Label();
            l.Text = text;
            l.Height = height;
            l.Width = width;
            l.Font.Bold = true;
            l.Font.Size = 36;
            return l;
        }

        private Button CreateOrderButton(string text, int height, int width)
        {
            Button b = new Button();
            b.Text = text;
            b.Height = height;
            b.Width = width;
            b.Font.Bold = true;
            b.Font.Size = 48;
            b.ForeColor = Color.Blue;
            b.Click += new EventHandler(OrderButtonClick);
            return b;
        }

        private Table CreateMainTable(int height, int width)
        {
            Table t = new Table();

            t.HorizontalAlign = HorizontalAlign.Center;

            TableCell left = new TableCell();
            TableCell right = new TableCell();

            left.Width = width / 2;
            right.Width = width / 2;

            Panel tspacer = new Panel();
            Panel bspacer = new Panel();
            tspacer.Height = height / 12;
            bspacer.Height = height / 6;

            left.Controls.Add(img);
            right.Controls.Add(tspacer);
            right.Controls.Add(nameLabel);
            right.Controls.Add(bspacer);
            right.Controls.Add(orderButton);

            left.HorizontalAlign = HorizontalAlign.Center;
            right.HorizontalAlign = HorizontalAlign.Center;

            t.Rows.Add(new TableRow());
            t.Rows[0].Cells.Add(left);
            t.Rows[0].Cells.Add(right);

            return t;
        }

        private Panel CreateSecondaryPanel(int height, int width)
        {
            Panel p = new Panel();

            return p;
        }

        private Table CreateSecondaryTable(int height, int width)
        {
            Table t = new Table();
            t.Rows.Add(new TableRow());
            for (int i = 0; i < 3; i++) {
                TableCell cell = new TableCell();
                cell.Height = height;
                cell.Width = width / 3;
            }
            t.Rows[0].Cells[0].Controls.Add(CreateCustomerInfoPanel(height, width / 3));
            //t.Rows[0].Cells[1].Controls.Add(CreateItemInfoPanel(height, width / 3));
            //t.Rows[0].Cells[2].Controls.Add(CreateShippingInfoPanel(height, width / 3));
            return t;
        }

        private Panel CreateCustomerInfoPanel(int height, int width)
        {
            Panel p = new Panel();
            p.Height = height;
            p.Width = width;

            Table t = new Table();
            for(int i = 0; i < customerLabels.Length; i++)
            {
                TableRow row = new TableRow();
                row.Height = height / customerLabels.Length;
                TableCell labelCell = new TableCell();
                TableCell inputCell = new TableCell();
                labelCell.Width = width / 2;
                inputCell.Width = width / 2;
                labelCell.Controls.Add(CreateLabel(customerLabels[i]));
                customerInputs[i] = CreateTextBox();
                inputCell.Controls.Add(customerInputs[i]);
                inputCell.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(labelCell);
                row.Cells.Add(inputCell);
                t.Rows.Add(row);
            }

            p.Controls.Add(t);
            return p;
        }

        private Label CreateLabel(string text)
        {
            Label l = new Label();
            l.Height = 35;
            l.Text = text;
            return l;
        }

        private TextBox CreateTextBox()
        {
            TextBox tb = new TextBox();
            tb.Height = 35;
            tb.Width = 200;
            return tb;
        }

        public void OrderButtonClick(Object sender, EventArgs e)
        {
            main.Visible = false;
            secondary.Visible = true;
            Response.Write("Clicked");
            System.Diagnostics.Debug.WriteLine("Clicked");
        }

    }
}