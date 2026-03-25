using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxdigits = 12;
        double arg1 = 0.0;
        double arg2 = 0.0;
        bool memory = false;
        char op = ' ';
        bool flt = false;
        bool sign = false;
        bool error = false;
        double memc = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Event_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "bClr":
                    arg1 = 0.0;
                    arg2 = 0.0;
                    op = ' ';
                    flt = false;
                    sign = false;
                    error = false;
                    SetData("0");
                    break;
                case "bBck":
                    if (error) break;
                    string? data = GetData();
                    if (data != null && ((data.Length > 1 && !sign) || (data.Length > 2 && sign)))
                    {
                        if (data[data.Length - 1] == '.')
                        {
                            flt = false;
                        }
                        SetData(data.Substring(0, data.Length - 1));
                    }
                    else if (data != null && ((data.Length == 1 && !sign) || (data.Length == 2 && sign)))
                    {
                        SetData("0");
                    }
                    break;
                case "bMRd":
                    if (error) break;
                    if (memory)
                    {
                        SetData(memc.ToString());
                    }
                    break;
                case "bMCl":
                    if (error) break;
                    memory = false;
                    memc = 0.0;
                    break;
                case "bMWr":
                    if (error) break;
                    if (GetData() != null && !memory)
                    {
                        double.TryParse(GetData(), out memc);
                        memory = true;
                    }
                    break;
                case "b0":
                case "b1":
                case "b2":
                case "b3":
                case "b4":
                case "b5":
                case "b6":
                case "b7":
                case "b8":
                case "b9":
                    if (error) break;
                    if (GetData().Length < (maxdigits + (flt ? 1 : 0)))
                    {
                        if (GetData() == "0")
                        {
                            SetData(((Button)sender).Content.ToString());
                        }
                        else
                        {
                            SetData(GetData() + ((Button)sender).Content.ToString().Substring(0,1));
                        }
                    }
                    break;
                case "bDot":
                    if (error) break;
                    if (!flt)
                    {
                        SetData(GetData() + ".");
                        flt = true;
                    }
                    break;
                case "bSgn":
                    if (error) break;
                    if (GetData() != null && GetData() != "0")
                    {
                        if (sign)
                        {
                            SetData(GetData().Substring(1));
                            sign = false;
                        }
                        else
                        {
                            SetData("-" + GetData());
                            sign = true;
                        }
                    }
                    break;
                case "bAdd":
                    if (error || op != ' ') break;
                    double.TryParse(GetData(), out arg1);
                    SetData("0");
                    op = '+';
                    flt = false;
                    sign = false;
                    break;
                case "bSub":
                    if (error || op != ' ') break;
                    double.TryParse(GetData(), out arg1);
                    SetData("0");
                    op = '-';
                    flt = false;
                    sign = false;
                    break;
                case "bMul":
                    if (error || op != ' ') break;
                    double.TryParse(GetData(), out arg1);
                    SetData("0");
                    op = '*';
                    flt = false;
                    sign = false;
                    break;
                case "bDiv":
                    if (error || op != ' ') break;
                    double.TryParse(GetData(), out arg1);
                    SetData("0");
                    op = '/';
                    flt = false;
                    sign = false;
                    break;
                case "bMod":
                    if (error || op != ' ') break;
                    double.TryParse(GetData(), out arg1);
                    SetData("0");
                    op = '%';
                    flt = false;
                    sign = false;
                    break;
                case "bSqr":
                    if (error) break;
                    double.TryParse(GetData(), out arg1);
                    if (arg1 < 0.0)
                    {
                        SetData("E:  Complex root");
                        error = true;
                    }
                    else
                    {
                        SetData(Math.Round(Math.Sqrt(arg1), 10).ToString());
                    }
                    flt = GetData().Contains(".");
                    sign = GetData().StartsWith("-");
                    break;
                case "bEqu":
                    if (error) break;
                    if (op == ' ') break;
                    double.TryParse(GetData(), out arg2);
                    switch (op)
                    {
                        case '+':
                            SetData((arg1 + arg2).ToString());
                            break;
                        case '-':
                            SetData((arg1 - arg2).ToString());
                            break;
                        case '*':
                            SetData((arg1 * arg2).ToString());
                            break;
                        case '/':
                            if (arg2 != 0.0)
                            {
                                SetData((arg1 / arg2).ToString());
                            }
                            else
                            {
                                SetData("E:  Division by 0");
                                error = true;
                            }
                            break;
                        case '%':
                            SetData((arg1 % arg2).ToString());
                            break;
                    }
                    flt = GetData().Contains(".");
                    sign = GetData().StartsWith("-");
                    op = ' ';
                    if (!error)
                    {
                        if (!flt && GetData().Length > maxdigits + ((flt) ? 1 : 0) + ((sign) ? 1 : 0))
                        {
                            SetData("E:  Result too long");
                            error = true;
                        }
                        else
                        {
                            double tmp = GetData() != null ? double.Parse(GetData()) : 0.0;
                            SetData(Math.Round(tmp, 10).ToString());
                        }
                    }
                    break;
            }
        }

        private string? GetData()
        {
            return Data.Content.ToString();
        }

        private void SetData(string? data)
        {
            Data.Content = data;
        }
    }
}