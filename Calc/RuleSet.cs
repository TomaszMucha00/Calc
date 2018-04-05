using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calc
{
    class RuleSet
    {
        public static bool IsSpecialSymbol(string symbol)
        {
            char charSymbol = (symbol.ToCharArray())[0];
            if (charSymbol == '+' || charSymbol == '-' || charSymbol == '*' || charSymbol == '/' || charSymbol == '(' || charSymbol == ')' || charSymbol == '%')
            {
                return true;
            }
            return false;
        }

        public static bool IsCypherOrComa(string symbol)
        {
            char charSymbol = (symbol.ToCharArray())[0];
            if ((charSymbol<58 && 47 < charSymbol) || charSymbol==48)
            {
                return true;
            }
            return false;
        }

        public static bool IsComaIsFirstSymbol(string expression)
        {
            char charSymbol = (expression.ToCharArray())[0];
            if (charSymbol == ',')
            {
                return true;
            }
            return false;
        }

        public static bool IsComaIsLastSymbol(string expression)
        {
            char charSymbol = (expression.ToCharArray())[expression.ToCharArray().Length-1];
            if (charSymbol == ',')
            {
                return true;
            }
            return false;
        }

        public static bool IsComaInExpression(string expression)
        {
            char[] charTab = expression.ToCharArray();
            int counter = 0;
            foreach (var item in charTab)
            {
                if (item == ',')
                {
                    counter++;
                }
            }
            if (counter==0)
            {
                return false;
            }
            return true;
        }

        public static string DoubleVerificationComaOnFirstPlace(string expression)
        {
            if (IsComaIsFirstSymbol(expression))
            {
                expression = "0" + expression;
            }
            return expression;
        }

        public static string DoubleVerificationComaOnLastPlace(string expression)
        {
                if (IsComaIsLastSymbol(expression))
                {
                    expression += "0";
                }
            return expression;
        }

        public static string NegateNumber(string expression)
        {
            if (expression[0]!='-')
            {
                expression = "-" + expression;
            }
            else
            {
                expression = expression.Remove(0, 1);
            }
            return expression;
        }
        
        public static string IsLastSymbolIsSpecial(string expression)
        {
            char temp = expression[expression.Length-1];
            if (temp == '+' || temp == '-' || temp == '*' || temp == '/' || temp == '%' )
            {
                return expression.Remove(expression.Length - 1, 1);
            }
            return expression;
        }


    }
}
