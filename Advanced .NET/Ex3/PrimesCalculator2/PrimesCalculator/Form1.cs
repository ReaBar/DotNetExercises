using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        private uint _minValue;
        private uint _maxValue;
        private readonly PrimeNumbers _primeNumbers;
        private CancellationTokenSource _cancelTokenSource;
        public Form1()
        {
            InitializeComponent();
            label3.Text = "From:";
            label2.Text = "To:";
            label1.Text = "Primes Calculator";
            button1.Text = "Calculate";
            button2.Text = "Cancel";
            _primeNumbers = new PrimeNumbers();
            _cancelTokenSource = new CancellationTokenSource();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (uint.TryParse(textBox2.Text, out _minValue) && uint.TryParse(textBox1.Text, out _maxValue) &&
                _minValue >= 2 && _minValue <= _maxValue)
            {
                if (listBox1.Items.Count != 0)
                {
                    listBox1.Items.Clear();
                }

                List<string> primesList = await Task.Run(() => _primeNumbers.CalcPrimes(_minValue, _maxValue,_cancelTokenSource.Token), _cancelTokenSource.Token);

                if (primesList == null)
                {
                    MessageBox.Show("Proccess was canceled");
                }
                else
                {
                    listBox1.BeginUpdate();
                    foreach (var prime in primesList)
                    {
                        listBox1.Items.Add(prime);
                    }
                    listBox1.EndUpdate();
                }

                _cancelTokenSource.Dispose();
                _cancelTokenSource = new CancellationTokenSource();
            }

            else
            {
                MessageBox.Show("Invalid Input!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _cancelTokenSource.Cancel();
        }
    }
}
