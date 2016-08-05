using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class PrimesCounterForm : Form
    {
        private int _minValue;
        private int _maxValue;
        private readonly PrimeNumbers _primeNumbers;
        private CancellationTokenSource _cancelTokenSource;

        public PrimesCounterForm()
        {
            InitializeComponent();
            _primeNumbers = new PrimeNumbers();
            _cancelTokenSource = new CancellationTokenSource();
        }

        private async void CalculateButtonClick(object sender, EventArgs e)
        {
            _cancelTokenSource = new CancellationTokenSource();
            calculateButton.Enabled = false;
            if (int.TryParse(startTextBox.Text, out _minValue) && int.TryParse(endTextBox.Text, out _maxValue) &&
                _minValue >= 0 && _minValue <= _maxValue)
            {
                int primesCount = await Task.Run(() => _primeNumbers.CountPrimesAsync(_minValue, _maxValue, _cancelTokenSource.Token), _cancelTokenSource.Token);
                sumOfPrimesLabel.Text = primesCount.ToString();
                string fileName = outputTextBox.Text;
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show("Invalid output name!");
                }

                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileName.Trim() + ".txt"))
                    {
                        streamWriter.WriteLine(primesCount.ToString());
                    }
                }
            }

            else
            {
                MessageBox.Show("Invalid Input!");
                sumOfPrimesLabel.Text = "Invalid Input";
            }
            calculateButton.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (_cancelTokenSource != null)
            {
                _cancelTokenSource.Cancel();
                _cancelTokenSource.Dispose();
                _cancelTokenSource = null;
                calculateButton.Enabled = true;
            }
        }
    }
}
