using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationForm_MichaelBermio_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboboxday.Items.Add("-Day-");
            comboboxmonth.Items.Add("-Month-");
            comboboxyear.Items.Add("-Year-");



            for (int day = 1; day <= 31; day++)
            {
                comboboxday.Items.Add(day);
            }


            for (int month = 1; month <= 12; month++)
            {
                comboboxmonth.Items.Add(month);
            }


            int currentYear = DateTime.Now.Year;
            for (int year = 1900; year <= currentYear; year++)
            {
                comboboxyear.Items.Add(year);
            }


            comboboxday.SelectedIndex = 0;
            comboboxmonth.SelectedIndex = 0;
            comboboxyear.SelectedIndex = 0;
        }


        private void Register_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(lastnamebox.Text))
            {
                MessageBox.Show("Please enter the last name.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lastnamebox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(firstnamebox.Text))
            {
                MessageBox.Show("Please enter the first name.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firstnamebox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(middlenamebox.Text))
            {
                MessageBox.Show("Please enter the middle name.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                middlenamebox.Focus();
                return;
            }

            if (!buttonmale.Checked && !buttonmale.Checked)
            {
                MessageBox.Show("Please select a gender.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboboxday.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a day.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboboxmonth.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a month.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboboxyear.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a year.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string day = comboboxday.SelectedItem.ToString();
            string month = comboboxmonth.SelectedItem.ToString();
            string year = comboboxyear.SelectedItem.ToString();

            string gender = "";
            if (buttonmale.Checked)
            {
                gender = "Male";
            }
            else if (buttonfemale.Checked)
            {
                gender = "Female";
            }

            string fullName = firstnamebox.Text + " " + middlenamebox.Text + " " + lastnamebox.Text;


            string dateOfBirth = day + "/" + month + "/" + year;


            string message = "Student name: " + fullName + "\n"
                           + "Gender: " + gender + "\n"
                           + "Date of birth: " + dateOfBirth;

            MessageBox.Show(message);
        }
    }
}