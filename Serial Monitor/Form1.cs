using System;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor
{
    public partial class Form1 : Form
    {
        private SerialPort port = new SerialPort("COM", 300, Parity.Even, 7, StopBits.One);
        public Form1()
        {
            InitializeComponent();
            foreach (string Portname in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(Portname);
                comboBox1.Text = Portname;
            }
        }

        private void debug(byte[] data, int data_len)
        {
            string dump = "";
            for (int i = 0; i < data_len; i++)
            {
                dump += data[i].ToString("X2") + " ";
            }
            Console.WriteLine("Received: " + dump);
        }

        private void write_to_port(string command)
        {
            port.ReadTimeout = 5000;
            port.WriteTimeout = 5000;
            port.Open();
            Console.WriteLine("Sent: " + command);
            byte[] data = new byte[1024];
            int count = 0;
            byte[] comm = command.Split().Select(s => Convert.ToByte(s, 16)).ToArray();
            port.Write(comm, 0, comm.Length);
            Thread.Sleep(2000);
            count = port.Read(data, 0, data.Length);
            debug(data, count);
            port.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                port.BaudRate = 300;
                await Task.Run(() => write_to_port(textBox1.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                port.BaudRate = 300;
                await Task.Run(() => write_to_port(textBox2.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                port.BaudRate = 9600;
                await Task.Run(() => write_to_port(textBox3.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                port.BaudRate = 9600;
                await Task.Run(() => write_to_port(textBox4.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                port.BaudRate = 300;
                await Task.Run(() => write_to_port(textBox5.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                port.BaudRate = 9600;
                await Task.Run(() => write_to_port(textBox6.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.PortName = comboBox1.Text;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string Portname in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(Portname);
            }
        }
    }
}
