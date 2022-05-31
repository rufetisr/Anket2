using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Anket2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<User> users = new();
        private void add_button_Click(object sender, EventArgs e)
        {

            var user = new User()
            {
                Name = textBox1.Text,
                Surname = textBox2.Text,
                Email = textBox3.Text,
                Phone = maskedTextBox1.Text,
                Birthday = dateTimePicker1.Value,
            };
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                users.Add(user);                
            }
            if (!string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(user.Surname) && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Phone))
            {
                var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var rx = new Regex(@"^[a-zA-Z]+$");
                if (regex.IsMatch(textBox3.Text) && rx.IsMatch(textBox1.Text) && rx.IsMatch(textBox2.Text))
                {
                    listBox1.Items.Add(user.Name);
                }
                else
                {
                    MessageBox.Show("You entered incorrect information");
                }
            }
            else
            {
                MessageBox.Show("All textboxes must be filled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                var seria = JsonConvert.SerializeObject(item, Formatting.Indented);
                File.WriteAllText($"{item.Name}.json", seria);
                MessageBox.Show("File-a yazildi");
            }
            //if (listBox1.Items.Count)
            //{

            //}
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            var user = new User();
            if (File.Exists($"{textBox6.Text}.json"))
            {
                var str = File.ReadAllText($"{textBox6.Text}.json");
                user = JsonConvert.DeserializeObject<User>(str);
                textBox1.Text = user?.Name;
                textBox2.Text = user?.Surname;
                textBox3.Text = user?.Email;
                maskedTextBox1.Text = user?.Phone;
                dateTimePicker1.Value = user.Birthday;
            }
            else
            {
                MessageBox.Show($"{textBox6.Text} file name not found !");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                if (listBox1.SelectedItem == item.Name)
                {
                    textBox1.Text = item.Name;
                    textBox2.Text = item.Surname;
                    textBox3.Text = item.Email;
                    maskedTextBox1.Text = item.Phone;
                    dateTimePicker1.Value = item.Birthday;
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            textBox6.Text = "File name";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var tx = sender as TextBox;
            var rx = new Regex(@"^[a-zA-Z]+$");
            if (rx.IsMatch(tx.Text))
            {
                tx.ForeColor = Color.Green;
            }
            else
                tx.ForeColor = Color.Red;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //var regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.IsMatch(textBox3.Text))
            {
                textBox3.ForeColor = Color.Green;
            }
            else
                textBox3.ForeColor = Color.Red;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            maskedTextBox1.Text = null;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                if (File.Exists($"{item.Name}.json"))
                {
                    listBox1.Items.Add(item.Name);
                }
            }
        }
    }
}