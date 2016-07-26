using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        private int _minValue;
        private int _maxValue;
        private readonly PrimeNumbers _primeNumbers;

        public Form1()
        {
            InitializeComponent();
            label3.Text = "From:";
            label2.Text = "To:";
            label1.Text = "Primes Calculator";
            button1.Text = "Calculate";
            _primeNumbers = new PrimeNumbers();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out _minValue) && int.TryParse(textBox1.Text,out _maxValue) && _minValue >= 2 && _minValue <= _maxValue)
            {
                if (listBox1.Items.Count != 0)
                {
                    listBox1.Items.Clear();
                }

                List<string> primesList = await Task.Run(() => _primeNumbers.CalcPrimes(_minValue, _maxValue));
                listBox1.BeginUpdate();
                foreach (var prime in primesList)
                {
                    listBox1.Items.Add(prime);
                }
                listBox1.EndUpdate();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
