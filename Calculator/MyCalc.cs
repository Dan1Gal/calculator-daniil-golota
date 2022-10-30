using System.Text.RegularExpressions;

namespace Calculator
{
    public class MyCalc
    {
        public string Calc(string expression)
        {
            var values = GetValues(expression);
            if (values.Item2 == "/" && values.Item3 == "0")
            {
                return "NOT ÷ 0";
            }
            switch (values.Item2)
            {                
                case "-": return Minus(values.Item1, values.Item3) < 999999999 && Minus(values.Item1, values.Item3) > -999999999 ? Minus(values.Item1, values.Item3).ToString() : "EXCEEDED";
                case "+": return Sum(values.Item1, values.Item3) < 999999999 && Sum(values.Item1, values.Item3) > -999999999 ? Sum(values.Item1, values.Item3).ToString() : "EXCEEDED"; 
                case "*": return Multiply(values.Item1, values.Item3) < 999999999 && Multiply(values.Item1, values.Item3) > -999999999 ? Multiply(values.Item1, values.Item3).ToString() : "EXCEEDED";
                case "/": return Divide(values.Item1, values.Item3) < 999999999 && Divide(values.Item1, values.Item3) > -999999999 ? Divide(values.Item1, values.Item3).ToString() : "EXCEEDED"; ;
               
                default: return "error";
            }
        }

        public int Sum(string x, string y)
        {
            return int.Parse(x) + int.Parse(y);
        }       
        public int Minus(string x, string y)
        {
            return int.Parse(x) - int.Parse(y);
        }
        public int Multiply(string x, string y)
        {
            return int.Parse(x) * int.Parse(y);
        }
        public int Divide(string x, string y)
        {
            return int.Parse(x) / int.Parse(y);
        }

       

       

        public (string, string, string) GetValues(string expression)
        {
            Regex regex = new Regex(@"([+, -])?(\d+)(.)(\d+)");
            return (regex.Match(expression).Groups[1].Value + regex.Match(expression).Groups[2].Value, regex.Match(expression).Groups[3].Value, regex.Match(expression).Groups[4].Value);
        }
    }
}
