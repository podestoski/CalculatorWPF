using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currentNumber, firstNumber, secondNumber;
        private Operations currentOperation;
        private bool isNewOperation = false;

        public MainWindow()
        {
            InitializeComponent();

            negativeButton.Click += NegativeButtonOnClick;
            acButton.Click += AcButtonOnClick;
            percentageButton.Click += PercentageButtonOnClick;

            plusButton.Click += OperationOnClick;
            minusButton.Click += OperationOnClick;
            timesButton.Click += OperationOnClick;
            divisionButton.Click += OperationOnClick;

            equalsButton.Click += EqualsButtonOnClick;
        }

        private void EqualsButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (isNewOperation)
            {
                secondNumber = currentNumber;
                isNewOperation = false;
            }
            else
            {
                firstNumber = currentNumber;
            }

            switch (currentOperation)
            {
                case Operations.Addition:
                    UpdateLabelValue(firstNumber + secondNumber);
                    break;
                case Operations.Sustraction:
                    UpdateLabelValue(firstNumber - secondNumber);
                    break;
                case Operations.Multiplication:
                    UpdateLabelValue(firstNumber * secondNumber);
                    break;
                case Operations.Division:
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Cannot divide by 0");
                    }
                    else
                        UpdateLabelValue(firstNumber / secondNumber);
                    break;
                default:
                    break;
            }
        }

        private void OperationOnClick(object sender, RoutedEventArgs e)
        {
            isNewOperation = true;
            firstNumber = currentNumber;
            UpdateLabelValue(0);
            Button operationButton = (Button) sender;
            switch (operationButton.Name)
            {
                case "plusButton":
                    currentOperation = Operations.Addition;
                    break;
                case "minusButton":
                    currentOperation = Operations.Sustraction;
                    break;
                case "timesButton":
                    currentOperation = Operations.Multiplication;
                    break;
                case "divisionButton":
                    currentOperation = Operations.Division;
                    break;
                default:
                    break;
            }
        }


        private void PercentageButtonOnClick(object sender, RoutedEventArgs e)
        {
            if(currentNumber != 0)
                UpdateLabelValue(currentNumber / 100);
        }

        private void AcButtonOnClick(object sender, RoutedEventArgs e)
        {
            UpdateLabelValue(0);
            firstNumber = 0;
            secondNumber = 0;
            currentOperation = Operations.Empty;
            isNewOperation = false;
        }

        private void NegativeButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (currentNumber != 0)
            {
                UpdateLabelValue(currentNumber * -1);
            }
        }

        private void numberButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button buttonSender = (Button) sender;
            switch (buttonSender.Name)
            {
                case "zeroButton":
                case "oneButton":
                case "twoButton":
                case "threeButton":
                case "fourButton":
                case "fiveButton":
                case "sixButton":
                case "sevenButton":
                case "eightButton":
                case "nineButton":
                    if (ResultLabel.Content.ToString() == "0")
                    {
                        UpdateLabelValue(buttonSender.Content.ToString());
                    }
                    else
                    {
                        UpdateLabelValue(ResultLabel.Content.ToString() + buttonSender.Content.ToString());
                    }

                    break;
                
            }


        }

        private void UpdateLabelValue(double number)
        {
            ResultLabel.Content = number.ToString();
            currentNumber = number;
        }

        private void UpdateLabelValue(string number)
        {
            ResultLabel.Content = number;
            double.TryParse(number, out currentNumber);
        }

        private enum Operations
        {
            Addition,
            Sustraction,
            Multiplication,
            Division,
            Empty
        }
    }
}
