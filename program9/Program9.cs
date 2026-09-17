using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class MDIForm : Form
{
    private List<string> students = new List<string>();

    public MDIForm()
    {
        Text = "College Management System";
        Size = new Size(800, 500);
        IsMdiContainer = true;

        MenuStrip menu = new MenuStrip();

        // FILE MENU
        ToolStripMenuItem file = new ToolStripMenuItem("File");

        ToolStripMenuItem newWindow =
            new ToolStripMenuItem("New Window");

        ToolStripMenuItem addStudent =
            new ToolStripMenuItem("Add Student");

        ToolStripMenuItem exit =
            new ToolStripMenuItem("Exit");

        file.DropDownItems.Add(newWindow);
        file.DropDownItems.Add(addStudent);
        file.DropDownItems.Add(exit);


        // DEPARTMENT MENU
        ToolStripMenuItem department =
            new ToolStripMenuItem("Department");

        ToolStripMenuItem cse =
            new ToolStripMenuItem("CSE");

        ToolStripMenuItem ece =
            new ToolStripMenuItem("ECE");

        ToolStripMenuItem eee =
            new ToolStripMenuItem("EEE");

        ToolStripMenuItem mech =
            new ToolStripMenuItem("Mechanical");

        department.DropDownItems.Add(cse);
        department.DropDownItems.Add(ece);
        department.DropDownItems.Add(eee);
        department.DropDownItems.Add(mech);


        // STUDENT MENU
        ToolStripMenuItem student =
            new ToolStripMenuItem("Student");

        ToolStripMenuItem details =
            new ToolStripMenuItem("Student Details");

        student.DropDownItems.Add(details);


        // WINDOW MENU
        ToolStripMenuItem window =
            new ToolStripMenuItem("Window");


        // ADD MENUS
        menu.Items.Add(file);
        menu.Items.Add(department);
        menu.Items.Add(student);
        menu.Items.Add(window);

        Controls.Add(menu);
        MainMenuStrip = menu;


        // NEW WINDOW
        newWindow.Click += NewWindow_Click;


        // ADD STUDENT / CUSTOM DIALOG
        addStudent.Click += AddStudent_Click;


        // EXIT
        exit.Click += Exit_Click;


        // DEPARTMENTS
        cse.Click += (sender, e) =>
        {
            ShowDepartment("Computer Science and Engineering");
        };

        ece.Click += (sender, e) =>
        {
            ShowDepartment("Electronics and Communication Engineering");
        };

        eee.Click += (sender, e) =>
        {
            ShowDepartment("Electrical and Electronics Engineering");
        };

        mech.Click += (sender, e) =>
        {
            ShowDepartment("Mechanical Engineering");
        };


        // STUDENT DETAILS
        details.Click += Details_Click;
    }


    // NEW MDI CHILD WINDOW
    private void NewWindow_Click(object sender, EventArgs e)
    {
        ChildForm child = new ChildForm();

        child.MdiParent = this;
        child.Text = "Student Window";

        child.Show();
    }


    // CUSTOM DIALOG BOX
    private void AddStudent_Click(object sender, EventArgs e)
    {
        Form dialog = new Form();

        dialog.Text = "Add Student";
        dialog.Size = new Size(400, 250);
        dialog.StartPosition = FormStartPosition.CenterParent;

        Label nameLabel = new Label();
        nameLabel.Text = "Enter Student Name:";
        nameLabel.Location = new Point(30, 30);
        nameLabel.AutoSize = true;

        TextBox nameBox = new TextBox();
        nameBox.Location = new Point(30, 60);
        nameBox.Width = 250;

        Label deptLabel = new Label();
        deptLabel.Text = "Select Department:";
        deptLabel.Location = new Point(30, 95);
        deptLabel.AutoSize = true;

        ComboBox deptBox = new ComboBox();
        deptBox.Location = new Point(30, 120);
        deptBox.Width = 250;

        deptBox.Items.Add("CSE");
        deptBox.Items.Add("ECE");
        deptBox.Items.Add("EEE");
        deptBox.Items.Add("Mechanical");

        Button saveButton = new Button();
        saveButton.Text = "Save";
        saveButton.Location = new Point(30, 160);

        saveButton.Click += (sender2, e2) =>
        {
            if (nameBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter student name.");
                return;
            }

            if (deptBox.Text == "")
            {
                MessageBox.Show("Please select department.");
                return;
            }

            string studentInfo =
                nameBox.Text + " - " + deptBox.Text;

            students.Add(studentInfo);

            MessageBox.Show(
                "Student saved successfully!",
                "Success");

            dialog.Close();
        };

        dialog.Controls.Add(nameLabel);
        dialog.Controls.Add(nameBox);
        dialog.Controls.Add(deptLabel);
        dialog.Controls.Add(deptBox);
        dialog.Controls.Add(saveButton);

        dialog.ShowDialog();
    }


    // SHOW STUDENTS
    private void Details_Click(object sender, EventArgs e)
    {
        if (students.Count == 0)
        {
            MessageBox.Show(
                "No students added.",
                "Student Details");

            return;
        }

        string result = "Student Details\n\n";

        for (int i = 0; i < students.Count; i++)
        {
            result += (i + 1) + ". " +
                      students[i] + "\n";
        }

        MessageBox.Show(
            result,
            "Student Details");
    }


    // SHOW DEPARTMENT
    private void ShowDepartment(string department)
    {
        ChildForm child = new ChildForm();

        child.MdiParent = this;
        child.Text = department;

        child.SetText(department);

        child.Show();
    }


    // EXIT
    private void Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }


    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new MDIForm());
    }
}


// CHILD FORM
public class ChildForm : Form
{
    private Label label;

    public ChildForm()
    {
        Text = "Child Form";
        Size = new Size(450, 300);

        label = new Label();

        label.Text = "This is a Child Form";
        label.Font = new Font("Arial", 16);
        label.AutoSize = true;
        label.Location = new Point(80, 100);

        Controls.Add(label);
    }

    public void SetText(string text)
    {
        label.Text = text;
    }
}