using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiUserRealtimeApp
{
    public partial class FrmMultiUserApp : Form
    {
        string apiUrl = "http://localhost:9000/api/Message"; 

        private HttpClient _httpClient;

        public FrmMultiUserApp()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _httpClient = new HttpClient();

            // Create a timestamp string
            string timestamp = DateTime.Now.ToString("HHmmss");

            // Combine them to form a unique username,
            // Relaunch multiple instances on pc to simulate a multiuser LOB app
            LblUsername.Text = GenName(timestamp);
        }

        private async void BtnWriteData_Click(object sender, EventArgs e)
        {
            string message = $"{LblUsername.Text} {DateTime.Now:HH:mm:ss} : {txtMessage.Text}";




            // should be e,g    WEBAPI.Write(message);

            // This is what I am trying to avoid.. front end loaded code 
            //MOVE INTO WebApi layer so can do TDD without Ui


            // Ensure _httpClient is initialized
            if (_httpClient == null)
            {
                MessageBox.Show("HttpClient is not initialized.");
                return;
            }

            using (var content = new StringContent(message, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = null;

                try
                {
                    response = await _httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // If the response is successful, read the response body
                        string responseBody = await response.Content.ReadAsStringAsync();
                        LblEvents.Text += $"\r\n{responseBody}";
                    }
                    else
                    {
                        // If the response is not successful, read the error message
                        var errorMessage = await response.Content.ReadAsStringAsync();

                        switch (response.StatusCode)
                        {
                            case System.Net.HttpStatusCode.BadRequest: // 400
                                MessageBox.Show($"Bad request: {errorMessage}");
                                break;
                            case System.Net.HttpStatusCode.Unauthorized: // 401
                            case System.Net.HttpStatusCode.Forbidden: // 403
                                MessageBox.Show("You are not authorized to perform this action.");
                                break;
                            case System.Net.HttpStatusCode.NotFound: // 404
                                MessageBox.Show("The requested resource was not found.");
                                break;
                            // Handle other statuses as needed
                            default:
                                MessageBox.Show($"Error: {errorMessage}");
                                break;
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    response?.Dispose();
                }
            }
        }


        private async void BtnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Display the response body in the textbox or any other control
                LblEvents.Text += responseBody;
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions here
                LblEvents.Text += $"Error: {ex.Message}";
            }
        }

        private static readonly string[] names =
        {
            "Maria", "David", "Linda", "Kevin", "Julie", "Brian", "Diane", "Jason", "Giner", "Scott", "Holly", "Colin", "Robin",
            "Tracy", "Simon", "Leahh", "Craig", "Liana", "Oscar", "April", "Keith", "Jenna", "Grace", "Marco", "Ellen", "Haley",
            "Roman", "Avery", "Nadia", "Miles", "Carla", "Perry", "Saman", "Hanna", "Elena", "Nolan", "Sofia", "Carly", "Mario",
            "Sonia", "Derek", "Lorna", "Jesse", "Megan", "Daryl", "Lydia", "Zohie", "Owhen", "Gwhen", "Lilly", "Eddie", "Iris",
            "Lance", "Vicky", "Nikki", "Ethan", "Shawn", "Nadia", "Kiera", "Noah", "Tammy", "Bryan", "Bridg", "Lizzy", "Hanna",
            "Mikay", "Clint", "Stacy", "Lloyd", "Ariel", "Jared", "Celia", "Lynda", "Caleb", "Ralph", "Wanda", "Piper", "Lamar",
            "Bryce", "Lynne", "Ellie", "Erick", "Cindy", "Shane", "Misty", "Jules", "Wendi", "Devin", "Crist", "Reece", "Lacey",
            "Siena", "Ryder", "Katie", "Jamar", "Lenny", "Ivyer", "Jaxon", "Myrna"
        };

        public static string GenName(string seed)
        {
            int sum = 0;
            foreach (char c in seed)
            {
                sum += c;
            }
            // Use the length of the names array to avoid hardcoding the size
            string name = names[sum % names.Length];

            return name;
        }
    }
}
