using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WinFormAttendance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string sourceName = "AttendanceManageMentSystem";
            if (!EventLog.SourceExists(sourceName))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(sourceName, "AttendanceLog");
            }*/
            try
            {
                // Get the employee ID from the input text
                int employeeId = int.Parse(textBox1.Text); // Assuming textBoxEmployeeId is the input TextBox

                // Create an instance of EmployeeAttendance and populate its properties
                EmployeeAttendance employee = new EmployeeAttendance
                {
                    EmployeeId = employeeId, // Use the employeeId retrieved from the input text
                    AttendanceDate = DateTime.Now.Date,
                    InTime = DateTime.Now
                    // Set other properties as needed
                };

                // Serialize the EmployeeAttendance object to JSON
                string jsonData = JsonConvert.SerializeObject(employee);

                // Write the serialized object to the Event Log
                EventLog.WriteEntry("Application", jsonData, EventLogEntryType.Information);

                MessageBox.Show("EmployeeAttendance object written to Event Log successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*string sourceName = "AttendanceManageMentSystem";
            if (!EventLog.SourceExists(sourceName))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(sourceName, "AttendanceLog");
            }*/
            try
            {
                // Get the employee ID from the input text
                int employeeId = int.Parse(textBox1.Text); // Assuming textBoxEmployeeId is the input TextBox

                // Create an instance of EmployeeAttendance and populate its properties
                EmployeeAttendance employee = new EmployeeAttendance
                {
                    EmployeeId = employeeId, // Use the employeeId retrieved from the input text
                    AttendanceDate = DateTime.Now.Date,
                    OutTime = DateTime.Now
                    // Set other properties as needed
                };

                // Serialize the EmployeeAttendance object to JSON
                string jsonData = JsonConvert.SerializeObject(employee);

                // Write the serialized object to the Event Log
                EventLog.WriteEntry("Application", jsonData, EventLogEntryType.Information);

                MessageBox.Show("EmployeeAttendance object written to Event Log successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
