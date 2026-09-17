using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsConsole
{
    public class MainForm : Form
    {
        TextBox name = new();
        TextBox email = new();
        TextBox phone = new();
        TextBox password = new();
        TextBox age = new();
        TextBox address = new();

        ComboBox gender = new();
        ComboBox country = new();

        CheckBox terms = new();
        Label status = new();

        public MainForm()
        {
            Text = "User Registration";
            Size = new Size(700, 720);
            BackColor = Color.FromArgb(30, 41, 59);
            ForeColor = Color.White;

            Add("Full Name", name, 130);
            Add("Email", email, 180);
            Add("Phone", phone, 230);
            Add("Password", password, 280);

            password.UseSystemPasswordChar = true;

            Add("Age", age, 330);

            Add("Gender", gender, 380);
            gender.Items.AddRange(new[]
            {
                "Male",
                "Female",
                "Other"
            });

            Add("Country", country, 430);
            country.Items.AddRange(new[]
            {
                "India",
                "United States",
                "United Kingdom",
                "Canada",
                "Australia",
                "Germany",
                "Japan"
            });

            Add("Address", address, 480);
            address.Multiline = true;
            address.Height = 60;

            terms.Text = "I agree to the terms and conditions";
            terms.Location = new Point(200, 550);
            terms.Width = 350;

            Controls.Add(terms);

            Button register = Button("Register", 200, 600);
            register.Click += Register;

            Button clear = Button("Clear", 360, 600);
            clear.Click += Clear;

            status.Location = new Point(50, 650);
            status.Size = new Size(600, 30);
            status.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(status);
        }

        void Add(string text, Control c, int y)
        {
            Controls.Add(new Label
            {
                Text = text,
                Location = new Point(60, y + 5),
                Size = new Size(120, 30)
            });

            c.Location = new Point(200, y);
            c.Size = new Size(400, 32);

            Controls.Add(c);
        }

        Button Button(string text, int x, int y)
        {
            var b = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(140, 40)
            };

            Controls.Add(b);

            return b;
        }

        void Register(object? s, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(phone.Text) ||
                string.IsNullOrWhiteSpace(password.Text) ||
                string.IsNullOrWhiteSpace(address.Text))
            {
                Error("Please fill all fields.");
                return;
            }

            if (!int.TryParse(age.Text, out int a) || a < 1 || a > 120)
            {
                Error("Enter a valid age.");
                return;
            }

            if (gender.SelectedIndex < 0 || country.SelectedIndex < 0)
            {
                Error("Please select gender and country.");
                return;
            }

            if (!terms.Checked)
            {
                Error("Please accept the terms and conditions.");
                return;
            }

            status.ForeColor = Color.LightGreen;
            status.Text = $"Registration successful! Welcome, {name.Text}.";

            MessageBox.Show(
                $"Welcome, {name.Text}!\n\nRegistration successful.",
                "Registration Complete");
        }

        void Clear(object? s, EventArgs e)
        {
            foreach (var c in new Control[]
            {
                name,
                email,
                phone,
                password,
                age,
                address
            })
            {
                c.Text = "";
            }

            gender.SelectedIndex = -1;
            country.SelectedIndex = -1;

            terms.Checked = false;
            status.Text = "";

            name.Focus();
        }

        void Error(string msg)
        {
            status.ForeColor = Color.LightCoral;
            status.Text = msg;

            MessageBox.Show(msg, "Validation Error");
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}