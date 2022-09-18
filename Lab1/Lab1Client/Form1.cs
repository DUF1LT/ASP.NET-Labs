using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            var x = double.Parse(XInput.Text);
            var y = double.Parse(YInput.Text);

            var result = await MultiplyAsync(x, y);
            ResultLabel.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        private async Task<double> MultiplyAsync(double x, double y)
        {
            var client = new HttpClient();
            var uri = new Uri($"http://localhost:4441/handlers/handler4?X={x}&Y={y}");

            var result = await client.PostAsync(uri, null);

            var body = await result.Content.ReadAsStringAsync();

            return double.Parse(body);
        }
    }
}