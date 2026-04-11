using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class StudentRegistration : Form
    {
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            // Clear items first to avoid duplicates if the form reloads
            comboboxday.Items.Clear();
            comboboxmonth.Items.Clear();
            comboboxyear.Items.Clear();
            comboboxprogram.Items.Clear();

            // Add default headers
            comboboxday.Items.Add("-Day-");
            comboboxmonth.Items.Add("-Month-");
            comboboxyear.Items.Add("-Year-");
            comboboxprogram.Items.Add("-Program-");

            // Populate Programs
            ArrayList programsList = new ArrayList {
                "Bachelor of Computer Engineering",
                "Bachelor of Computer Science",
                "Bachelor of Information System",
                "Bachelor of Information Technology"
            };
            foreach (string p in programsList) comboboxprogram.Items.Add(p);

            // Populate Months
            string[] months = { "January", "February", "March", "April", "May", "June",
                                "July", "August", "September", "October", "November", "December" };
            foreach (string m in months) comboboxmonth.Items.Add(m);

            // Populate Days (1-31)
            for (int d = 1; d <= 31; d++) comboboxday.Items.Add(d);

            // Populate Years (1950 to current)
            int currentYear = DateTime.Now.Year;
            for (int y = 1950; y <= currentYear; y++) comboboxyear.Items.Add(y);

            // Set all to index 0 (the headers)
            comboboxday.SelectedIndex = 0;
            comboboxmonth.SelectedIndex = 0;
            comboboxyear.SelectedIndex = 0;
            comboboxprogram.SelectedIndex = 0;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            // 1. Validate Textboxes
            if (string.IsNullOrWhiteSpace(lastnamebox.Text) ||
                string.IsNullOrWhiteSpace(firstnamebox.Text) ||
                string.IsNullOrWhiteSpace(middlenamebox.Text))
            {
                MessageBox.Show("Please fill out all name fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate Gender
            string gender = "";
            if (buttonmale.Checked) gender = "Male";
            else if (buttonfemale.Checked) gender = "Female";
            else
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validate ComboBoxes (Check if they are still on the header "-Day-", etc.)
            if (comboboxday.SelectedIndex <= 0 || comboboxmonth.SelectedIndex <= 0 ||
                comboboxyear.SelectedIndex <= 0 || comboboxprogram.SelectedIndex <= 0)
            {
                MessageBox.Show("Please complete the Date of Birth and Program selection.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Collect Data
            string fullName = firstnamebox.Text + " " + middlenamebox.Text + " " + lastnamebox.Text;
            string dateOfBirth = comboboxday.Text + "/" + comboboxmonth.Text + "/" + comboboxyear.Text;
            string selectedProgram = comboboxprogram.Text;

            // 5. Show Final Message (Using the fixed variables)
            string message = "Student name: " + fullName + "\n"
                           + "Gender: " + gender + "\n"
                           + "Date of birth: " + dateOfBirth + "\n"
                           + "Program: " + selectedProgram;

            MessageBox.Show(message, "Registration Successful");

            // Optional: Call your overloaded methods if required for your assignment
            ShowStudentInfo(firstnamebox.Text, lastnamebox.Text, selectedProgram, dateOfBirth);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pic.ImageLocation = openFileDialog1.FileName;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // Overloaded methods for your project requirements
        public void ShowStudentInfo(string f, string l)
        { MessageBox.Show("Student: " + f + " " + l); }

        public void ShowStudentInfo(string f, string l, string p)
        { MessageBox.Show("Student: " + f + " " + l + "\nProgram: " + p); }

        public void ShowStudentInfo(string f, string l, string p, string d)
        { MessageBox.Show("Name: " + f + " " + l + "\nProgram: " + p + "\nBirthday: " + d); }
    }
}
