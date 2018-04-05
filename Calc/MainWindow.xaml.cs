using Calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//12+12+12^2=38?
//Why?

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            PropertiesModel.IsCleared = true;
            InitializeComponent();
        }

        private void Button_Click_Add_Number_Or_Coma(object sender, RoutedEventArgs e)
        {
            if (!(PropertiesModel.IsCleared && (string)(sender as Button).Content == "0"))
                {
                    if (PropertiesModel.IsCleared)
                {
                    LbCalculatorDisplayDown.Content = "";
                    PropertiesModel.IsCleared = false;
                }
                if (!((string)(sender as Button).Content == "," && RuleSet.IsComaInExpression((string)LbCalculatorDisplayDown.Content)))
                {
               
                        LbCalculatorDisplayDown.Content = String.Concat((string)LbCalculatorDisplayDown.Content, (string)(sender as Button).Content);
                
                }
                LbCalculatorDisplayDown.Content = RuleSet.DoubleVerificationComaOnFirstPlace((string)LbCalculatorDisplayDown.Content);
            }
        }

        private void EqualSign_Click(object sender, RoutedEventArgs e)
        {
            LbCalculatorDisplayUp.Content += (string)LbCalculatorDisplayDown.Content;
            try
            {
                LbCalculatorDisplayDown.Content = (new NCalc.Expression((string)LbCalculatorDisplayUp.Content).Evaluate()).ToString();
                LbCalculatorDisplayUp.Content = "";
                
            }
            catch (Exception)
            {
                LbCalculatorDisplayDown.Content = "0";
                PropertiesModel.IsCleared = true;
                MessageBox.Show("Wyrażenie nie ma sensu. Wpisz ponownie.");
            }
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (((string)LbCalculatorDisplayDown.Content).Length!=1)
            {
                LbCalculatorDisplayDown.Content=((string)LbCalculatorDisplayDown.Content).Remove(((string)LbCalculatorDisplayDown.Content).Length - 1, 1);
            }
            else
            {
                LbCalculatorDisplayDown.Content = "0";
                PropertiesModel.IsCleared = true;
            }
        }

        private void Button_Click_Special_Sign(object sender, RoutedEventArgs e)
        {
            PropertiesModel.Number = (string)LbCalculatorDisplayDown.Content;
            PropertiesModel.Number = RuleSet.IsLastSymbolIsSpecial(PropertiesModel.Number);
            string tempExpression = "";
            Dictionary<string, int> sign = new Dictionary<string, int>();
            sign.Add("+",1);
            sign.Add("-", 2);
            sign.Add("*", 3);
            sign.Add(":", 4);
            sign.Add("Mod", 5);
            sign.Add("x^y", 6);
            int switchCase = 0;
            foreach (var item in sign)
            {
                if (item.Key==((string)(sender as Button).Content))
                {
                    switchCase = item.Value;
                }
            }
            switch (switchCase)
            {
                case 1:
                    tempExpression = PropertiesModel.Number + "+";
                    break;
                case 2:
                    tempExpression = PropertiesModel.Number + "-";
                    break;
                case 3:
                    tempExpression = PropertiesModel.Number + "*";
                    break;
                case 4:
                    tempExpression = PropertiesModel.Number + "/";
                    break;
                case 5:
                    tempExpression = PropertiesModel.Number + "%";
                    break;
                case 6:
                    tempExpression = PropertiesModel.Number + "^";
                    break;
                default:
                    break;
            }
            LbCalculatorDisplayUp.Content += tempExpression;
            LbCalculatorDisplayDown.Content = "0";
            PropertiesModel.IsCleared = true;
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            LbCalculatorDisplayDown.Content = "3,14159265359";
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            if (number>0)
            {
                number = Math.Log10(number);
            }
            else
            {
                MessageBox.Show("Wyrażenie nie poprawne");
                LbCalculatorDisplayDown.Content = "0";
                Models.PropertiesModel.IsCleared = true;
            }
            LbCalculatorDisplayDown.Content = number.ToString();
        }

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            LbCalculatorDisplayDown.Content = Math.Cos(number).ToString();
        }

        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            LbCalculatorDisplayDown.Content = Math.Sin(number).ToString();
        }

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            LbCalculatorDisplayDown.Content = Math.Tan(number).ToString();
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            LbCalculatorDisplayDown.Content = Math.Exp(number).ToString();
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            LbCalculatorDisplayDown.Content = Math.Sqrt(number).ToString();
        }

        private void XPow2_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            LbCalculatorDisplayDown.Content = Math.Pow(number,2).ToString();
        }

        private void TenPowX_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            LbCalculatorDisplayDown.Content = Math.Pow(10, number).ToString();
        }

        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            //There is no factorial in Math library, find solution
            //double number = Convert.ToDouble(((string)LbCalculatorDisplayDown.Content));
            //LbCalculatorDisplayDown.Content = Math.(10, number).ToString();
        }

        private void SignChange_Click(object sender, RoutedEventArgs e)
        {
            LbCalculatorDisplayDown.Content = RuleSet.NegateNumber((string)LbCalculatorDisplayDown.Content);
        }

        private void XPow3_Click(object sender, RoutedEventArgs e)
        {
            LbCalculatorDisplayDown.Content = Math.Pow(Double.Parse((string)LbCalculatorDisplayDown.Content),3).ToString();
        }
    }
}
