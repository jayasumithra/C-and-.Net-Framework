using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyFirstForm
{
    public class Form1 : Form
    {
        Label lblName;
        TextBox txtName;
        Button btnSubmit;
        Label lblResult;

        public Form1()
        {
            // Form properties
            Text = "Student Form";
            Width = 450;
            Height = 300;
            StartPosition = FormStartPosition.CenterScreen;

            // Name Label
            lblName = new Label();
            lblName.Text = "Enter Your Name:";
            lblName.Location = new Point(50, 50);
            lblName.AutoSize = true;

            // Name TextBox
            txtName = new TextBox();
            txtName.Location = new Point(180, 47);
            txtName.Width = 180;

            // Submit Button
            btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new Point(180, 90);
            btnSubmit.Width = 100;

            // Result Label
            lblResult = new Label();
            lblResult.Location = new Point(50, 140);
            lblResult.AutoSize = true;

            // Button Click Event
            btnSubmit.Click += BtnSubmit_Click;

            // Add controls to Form
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnSubmit);
            Controls.Add(lblResult);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            lblResult.Text = "Welcome, " + name + "!";
        }
    }
}