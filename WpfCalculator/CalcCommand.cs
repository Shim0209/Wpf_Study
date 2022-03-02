using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfCalculator
{
    class Append : ICommand
    {
        private CalcViewModel c;

        public event EventHandler CanExecuteChanged;

        public Append(CalcViewModel c)
        {
            this.c = c;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            c.InputString += parameter;
        }
    }

    class Backspace : ICommand
    {
        private CalcViewModel c;
        
        public Backspace(CalcViewModel c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return c.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            int length = c.InputString.Length - 1;
            if(length > 0)
            {
                c.InputString = c.InputString.Substring(0, length);
            }
            else
            {
                c.InputString = c.DisplayText = "";
            }
        }
    }

    class Clear : ICommand
    {
        private CalcViewModel c;

        public Clear(CalcViewModel c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return c.DisplayText.Length > 0;
        }

        public void Execute(object parameter)
        {
            c.InputString = c.DisplayText = "";
            c.Op1 = null;
        }
    }

    class Operator : ICommand
    {
        private CalcViewModel c;

        public Operator(CalcViewModel c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return c.InputString.Length > 0;
        }

        public void Execute(object parameter)
        {
            string op = parameter.ToString();
            double op1;
            if(double.TryParse(c.InputString, out op1))
            {
                c.Op1 = op1;
                c.Op = op;
                c.InputString = ""; 
            }
            // 이거 도대체 뭐임 ??????????????
            else if(c.InputString == "" && op == "-")
            {
                c.InputString = "-";
            }
        }
    }

    class Calculate : ICommand
    {
        private CalcViewModel c;

        public Calculate(CalcViewModel c)
        {
            this.c = c;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            double op2;
            return c.Op1 != null && double.TryParse(c.InputString, out op2);
        }

        public void Execute(object parameter)
        {
            double op2 = double.Parse(c.InputString);
            c.InputString = calculate(c.Op, (double)c.Op1, op2).ToString();
            c.Op1 = null;
        }

        private static double calculate(string op, double op1, double op2)
        {
            switch (op)
            {
                case "+": 
                    return op1 + op2;              
                case "-": 
                    return op1 - op2;             
                case "*": 
                    return op1 * op2;              
                case "/": 
                    return op1 / op2;            
            }
            return 0;
        }
    }

    class CalcCommand
    {

    }
}
