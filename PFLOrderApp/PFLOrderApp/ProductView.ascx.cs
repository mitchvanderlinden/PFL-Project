using PFLOrderApp.Data.Order;
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

        private Panel current;

        // Main Panel Controls
        private Panel main;
        private System.Web.UI.WebControls.Image img;
        private Label nameLabel;
        private Button orderButton;
        
        // Order Form Panel Controls
        private Panel secondary;
        // Customer Info
        private string[] customerLabels = {"First Name", "Last Name", "Address 1", "Address 2",
                                            "City", "State", "Country Code", "Postal Code", "Email", "Phone"};
        private TextBox cfname, clname, caddress1, caddress2, ccity, cstate, ccountry, cpostal, cemail, cphone;
        private TextBox[] customerInputs;
        // Shipping Info
        private string[] shippingLabels = {"First Name", "Last Name", "Address 1", "Address 2",
                                            "City", "State", "Country Code", "Postal Code", "Phone"};
        private TextBox sfname, slname, saddress1, saddress2, scity, sstate, scountry, spostal, sphone;
        private TextBox[] shippingInputs;
        // Item Info
        private const string quantityLabel = "Quantity";
        private TextBox quantityTextBox;
        private Button submitButton;
        private Button cancelButton;

        // Confirmation Panel Controls
        private Panel confirmation;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            main = CreateMainPanel(Height, Width);
            secondary = CreateSecondaryPanel(Height, Width);
            confirmation = CreateConfirmationPanel(Height, Width);
            if((string)ViewState["current"] == "secondary")
            {
                current = secondary;
            } else if((string)ViewState["current"] == "confirmation")
            {
                current = confirmation;
                ViewState["current"] = "main";
            } else
            {
                current = main;
            }
            this.Controls.Clear();
            this.Controls.Add(current);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
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

            Table t = CreateSecondaryTable(height, width);

            p.Controls.Add(t);

            return p;
        }

        private Table CreateSecondaryTable(int height, int width)
        {

            submitButton = new Button();
            cancelButton = new Button();
            submitButton.Click += new EventHandler(SubmitClick);
            cancelButton.Click += new EventHandler(CancelClick);
            InitTextBoxes();
            customerInputs = new TextBox[] { cfname, clname, caddress1, caddress2, ccity, cstate, ccountry, cpostal, cemail, cphone };
            shippingInputs = new TextBox[] { sfname, slname, saddress1, saddress2, scity, sstate, scountry, spostal, sphone };

            Table t = new Table();
            t.Rows.Add(new TableRow());
            for (int i = 0; i < 3; i++) {
                TableCell cell = new TableCell();
                cell.Height = height;
                cell.Width = width / 3;
                cell.BorderWidth = 1;
                t.Rows[0].Cells.Add(cell);
            }
            t.Rows[0].Cells[0].Controls.Add(CreateCustomerInfoPanel(height, width / 3));
            t.Rows[0].Cells[1].Controls.Add(CreateShippingInfoPanel(height, width / 3));
            t.Rows[0].Cells[2].Controls.Add(CreateItemInfoPanel(height, width / 3));
            return t;
        }

        private Panel CreateCustomerInfoPanel(int height, int width)
        {
            Panel p = new Panel();
            p.Height = height;
            p.Width = width;

            Table t = new Table();
            t.Rows.Add(new TableRow());
            t.Rows.Add(new TableRow());

            Label name = CreateNameLabel("Customer Info", 75, width - 10);
            name.Font.Size = 24;

            TableCell top = new TableCell();
            top.Height = 75;
            top.HorizontalAlign = HorizontalAlign.Center;
            top.Controls.Add(name);
            t.Rows[0].Cells.Add(top);

            Table lower = new Table();
            for(int i = 0; i < customerLabels.Length; i++)
            {
                TableRow row = new TableRow();
                row.Height = 35;
                TableCell labelCell = new TableCell();
                TableCell inputCell = new TableCell();
                labelCell.Width = width / 2;
                inputCell.Width = width / 2;
                labelCell.Controls.Add(CreateLabel(customerLabels[i]));
                inputCell.Controls.Add(customerInputs[i]);
                inputCell.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(labelCell);
                row.Cells.Add(inputCell);
                lower.Rows.Add(row);
            }

            TableCell cell = new TableCell();
            cell.Controls.Add(lower);
            t.Rows[1].Cells.Add(cell);

            p.Controls.Add(t);
            return p;
        }

        private Panel CreateShippingInfoPanel(int height, int width)
        {
            Panel p = new Panel();
            p.Height = height;
            p.Width = width;

            Table t = new Table();
            t.Rows.Add(new TableRow());
            t.Rows.Add(new TableRow());

            Label name = CreateNameLabel("Shipping Info", 75, width - 10);
            name.Font.Size = 24;

            TableCell top = new TableCell();
            top.Height = 75;
            top.HorizontalAlign = HorizontalAlign.Center;
            top.Controls.Add(name);
            t.Rows[0].Cells.Add(top);

            Table lower = new Table();
            for (int i = 0; i < shippingLabels.Length; i++)
            {
                TableRow row = new TableRow();
                row.Height = 35;
                TableCell labelCell = new TableCell();
                TableCell inputCell = new TableCell();
                labelCell.Width = width / 2;
                inputCell.Width = width / 2;
                labelCell.Controls.Add(CreateLabel(shippingLabels[i]));
                inputCell.Controls.Add(shippingInputs[i]);
                inputCell.HorizontalAlign = HorizontalAlign.Right;
                row.Cells.Add(labelCell);
                row.Cells.Add(inputCell);
                lower.Rows.Add(row);
            }

            TableCell cell = new TableCell();
            cell.Controls.Add(lower);
            t.Rows[1].Cells.Add(cell);

            p.Controls.Add(t);
            return p;
        }

        private Panel CreateItemInfoPanel(int height, int width)
        {
            Panel p = new Panel();
            p.Height = height;
            p.Width = width;

            Table t = new Table();
            t.Rows.Add(new TableRow());
            t.Rows.Add(new TableRow());

            Table inner = new Table();
            inner.Rows.Add(new TableRow());
            inner.Rows.Add(new TableRow());

            // Create the Top cell to hold item name
            Label name = CreateNameLabel(product.name, height / 5 * 2, width);
            name.Font.Size = 24;

            TableCell top = new TableCell();
            top.Height = height / 5 * 2;
            top.HorizontalAlign = HorizontalAlign.Center;
            top.Controls.Add(name);
            t.Rows[0].Cells.Add(top);

            // Create the middle cells to get quantity input
            TableCell midLeft = new TableCell();
            TableCell midRight = new TableCell();
            midLeft.Height = height / 5 * 2;
            midLeft.Width = width / 2;
            midLeft.HorizontalAlign = HorizontalAlign.Right;
            midRight.Height = height / 5 * 2;
            midRight.Width = width / 2;
            midRight.HorizontalAlign = HorizontalAlign.Left;

            Label l = new Label();
            l.Text = quantityLabel;
            l.Font.Size = 18;
            midLeft.Controls.Add(l);

            quantityTextBox = new TextBox();
            quantityTextBox.Width = 75;
            quantityTextBox.Font.Size = 14;
            midRight.Controls.Add(quantityTextBox);

            inner.Rows[0].Cells.Add(midLeft);
            inner.Rows[0].Cells.Add(midRight);

            // Create the bottom cells to hold action buttons
            TableCell bottomLeft = new TableCell();
            TableCell bottomRight = new TableCell();
            bottomLeft.Width = width / 2;
            bottomRight.Width = width / 2;
            bottomLeft.HorizontalAlign = HorizontalAlign.Left;
            bottomRight.HorizontalAlign = HorizontalAlign.Right;

            submitButton.Height = height / 5 - 10;
            submitButton.Width = width / 3;
            submitButton.Text = "Submit";
            submitButton.Font.Size = 18;
            bottomLeft.Controls.Add(submitButton);

            cancelButton.Height = height / 5 - 10;
            cancelButton.Width = width / 3;
            cancelButton.Text = "Cancel";
            cancelButton.Font.Size = 18;
            bottomRight.Controls.Add(cancelButton);

            inner.Rows[1].Cells.Add(bottomLeft);
            inner.Rows[1].Cells.Add(bottomRight);

            TableCell cell = new TableCell();
            cell.Controls.Add(inner);

            t.Rows[1].Cells.Add(cell);

            p.Controls.Add(t);
            return p;
        }   
        
        private Panel CreateConfirmationPanel(int height, int width)
        {
            Panel p = new Panel();
            p.Height = height;
            p.Width = width;

            if((string)ViewState["confirmationNumber"] == null)
            {
                Label l = CreateNameLabel("Could not process order", 100, 500);
                p.Controls.Add(l);
                return p;
            }

            Table t = new Table();
            for(int i = 0; i < 4; i++)
            {
                t.Rows.Add(new TableRow());
                t.Rows[i].Cells.Add(new TableCell());
                t.Rows[i].Cells[0].Width = width;
                t.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            t.Rows[0].Cells[0].Height = height / 3;
            t.Rows[1].Cells[0].Height = height / 6;
            t.Rows[2].Cells[0].Height = height / 6;

            Label success = CreateLabel("Order Received");
            success.Font.Size = 24;
            Label confirmation = CreateLabel("Confirmation Number: " + (string)ViewState["confirmationNumber"]);
            confirmation.Font.Size = 18;
            ViewState["confirmationNumber"] = null;
            Button okButton = new Button();
            okButton.Height = 50;
            okButton.Width = 100;
            okButton.Text = "OK";
            okButton.Font.Size = 18;
            okButton.Click += new EventHandler(OkClick);

            t.Rows[1].Cells[0].Controls.Add(success);
            t.Rows[2].Cells[0].Controls.Add(confirmation);
            t.Rows[3].Cells[0].Controls.Add(okButton);

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
            tb.Height = 25;
            tb.Width = 200;
            return tb;
        }

        public void OrderButtonClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Order");
            ViewState["current"] = "secondary";
            OnLoad(EventArgs.Empty);
        }

        public void SubmitClick(object sender, EventArgs e)
        {
            ViewState["current"] = "confirmation";
            System.Diagnostics.Debug.WriteLine("Submit");
            SubmitOrder();
            OnLoad(EventArgs.Empty);
        }

        public void CancelClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Cancel");
            ViewState["current"] = "main";
            OnLoad(EventArgs.Empty);
        }

        public void OkClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ok");
            ViewState["current"] = "main";
            OnLoad(EventArgs.Empty);
        }

        private void InitTextBoxes()
        {
            cfname = CreateTextBox();
            clname = CreateTextBox();
            caddress1 = CreateTextBox();
            caddress2 = CreateTextBox();
            ccity = CreateTextBox();
            cstate = CreateTextBox();
            ccountry = CreateTextBox();
            cpostal = CreateTextBox();
            cemail = CreateTextBox();
            cphone = CreateTextBox();

            sfname = CreateTextBox();
            slname = CreateTextBox();
            saddress1 = CreateTextBox();
            saddress2 = CreateTextBox();
            scity = CreateTextBox();
            sstate = CreateTextBox();
            scountry = CreateTextBox();
            spostal = CreateTextBox();
            sphone = CreateTextBox();
        }

        private void SubmitOrder()
        {
            System.Diagnostics.Debug.WriteLine("Clicked");

            var orderCustomer = new OrderCustomer()
            {
                FirstName = cfname.Text,
                LastName = clname.Text,
                Address1 = caddress1.Text,
                Address2 = caddress2.Text,
                City = ccity.Text,
                State = cstate.Text,
                PostalCode = cpostal.Text,
                CountryCode = ccountry.Text,
                Email = cemail.Text,
                Phone = cphone.Text
            };

            var item = new OrderItem()
            {
                ItemSequenceNumber = 1,
                ProductID = product.productID,
                Quantity = Convert.ToInt32(quantityTextBox.Text),
                ItemID = product.id
            };

            var orderShipping = new OrderShipment()
            {
                ShipmentSequenceNumber = 1,
                FirstName = sfname.Text,
                LastName = slname.Text,
                Address1 = saddress1.Text,
                Address2 = saddress2.Text,
                City = scity.Text,
                State = sstate.Text,
                PostalCode = spostal.Text,
                CountryCode = scountry.Text,
                Phone = sphone.Text
            };

            var order = new Order();
            order.OrderCustomer = orderCustomer;
            order.Items = new List<OrderItem>();
            order.Items.Add(item);
            order.Shipments = new List<OrderShipment>();
            order.Shipments.Add(orderShipping);
            var rnd = new Random();
            order.PartnerOrderReference = String.Format("P{0}", rnd.Next(999999).ToString());

            ViewState["confirmationNumber"] = order.PartnerOrderReference;

            System.Diagnostics.Debug.WriteLine(order.PartnerOrderReference);

            Client client = Client.GetInstance();
            client.CreateOrder(order);
        }

    }
}