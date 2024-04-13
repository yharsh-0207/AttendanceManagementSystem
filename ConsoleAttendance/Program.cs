using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAttendance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "EmployeePipe", PipeDirection.Out))
                {
                    pipeClient.Connect();
                    Console.WriteLine("Enter The Employee Id: ");
                    int Id;
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out Id))
                    {
                        // Conversion succeeded, Id variable now holds the integer value
                        Console.WriteLine("Input successfully converted to int: " + Id);
                    }
                    else
                    {
                        // Conversion failed, handle invalid input
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }

                    // Create an instance of the Employee object
                    EmployeeAttendance employee = new EmployeeAttendance
                    {
                        EmployeeId = Id,
                        AttendanceDate = DateTime.Now,

                    };


                    // Serialize Employee object to JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                     
                    // Write JSON data to the named pipe
                    using (StreamWriter writer = new StreamWriter(pipeClient))
                    {
                        writer.Write(jsonData);
                        writer.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
