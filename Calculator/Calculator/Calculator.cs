using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {

        static private bool IsOperator(string с)
        {
            if (("+-/*()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static int Priority(string symbol)
        {

            if (symbol == "*" || symbol == "/")
            {
                return 3;
            }
            else if (symbol == "+" || symbol == "-")
            {
                return 2;
            }
            else if (symbol == "(")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    
        public List<string> ShuntingYard(string expression)
        {
            //            Рассматриваем поочередно каждый символ:
            //1.Если этот символ -число(или переменная), то просто помещаем его в выходную строку 
            //2.Если символ - знак операции(+, -, *, / ), то проверяем приоритет данной операции.Операции умножения и деления имеют наивысший приоритет(допустим он равен 3).Операции сложения и вычитания имеют меньший приоритет(равен 2). Наименьший приоритет(равен 1) имеет открывающая скобка.
            //Получив один из этих символов, мы должны проверить стек:
            //а) Если стек все еще пуст, или находящиеся в нем символы(а находится в нем могут только знаки операций и открывающая скобка) имеют меньший приоритет, чем приоритет текущего символа, то помещаем текущий символ в стек.
            //б) Если символ, находящийся на вершине стека имеет приоритет, больший или равный приоритету текущего символа, то извлекаем символы из стека в выходную строку до тех пор, пока выполняется это условие; затем переходим к пункту а).
            //3.Если текущий символ -открывающая скобка, то помещаем ее в стек.
            //4.Если текущий символ -закрывающая скобка, то извлекаем символы из стека в выходную строку до тех пор, пока не встретим в стеке открывающую скобку(т.е.символ с приоритетом, равным 1), которую следует просто уничтожить. Закрывающая скобка также уничтожается.
            //Если вся входная строка разобрана, а в стеке еще остаются знаки операций, извлекаем их из стека в выходную строку. 
            //Обьяснения взято отсюда -http://www.interface.ru/home.asp?artId=1492 
            string[] tokens = expression.Split(null);
            List<string> output = new List<string>();
            Stack<char> operators = new Stack<char>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (IsNumber(tokens[i]))
                {
                    output.Add(tokens[i]);
                    continue;
                }
                switch (tokens[i])
                {
                    case "(":
                        operators.Push(Convert.ToChar(tokens[i]));
                        break;
                    case "*":
                    case "/":
                    case "+":
                    case "-":
                        while (operators.Count > 0 && Priority(tokens[i]) <= Priority(operators.Peek().ToString()))
                        {
                            output.Add(operators.Pop().ToString());
                        } 
                         operators.Push(Convert.ToChar(tokens[i])); 
                        break;
                    case ")":
                        while (operators.Peek() != '(')
                        {
                            output.Add(operators.Pop().ToString());
                        }

                        operators.Pop();
                        break;
                    default:
                        throw new InvalidOperationException("Не стоит пихать что попало в калькулятор ! Будь разумным.");
                }
            }
            while (operators.Any())
            {
                output.Add(operators.Pop().ToString());
            }

            return output;

        }
        static bool IsNumber(string n)
        {
            double retNum;
            bool isNumeric = double.TryParse(n, out retNum);
            return isNumeric;
        }
        public double ReversePolishNotation(List<string> tokens)
        {
            Stack<double> stack = new Stack<double>(); 
            foreach (var token in tokens)
            {
                if (IsNumber(token.ToString()))
                {
                    stack.Push(double.Parse(token.ToString()));
                }
                double rightOperand;
                switch (token)
                {
                    
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        rightOperand = stack.Pop();
                        stack.Push(stack.Pop() - rightOperand);
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "/": 
                        rightOperand = stack.Pop();
                        double leftOperand = stack.Pop();
                        if (Math.Round(rightOperand)==0 || Math.Round(leftOperand) == 0)
                        {
                            throw new InvalidOperationException("Не делай так");
                        }
                        stack.Push(leftOperand  / rightOperand);
                        break;
                    
                }
            }
            if (stack.Count != 1)
            {
                throw new InvalidOperationException();
            }

            return stack.Pop();
        }
        public double Calculate(string expression)
        {
            return ReversePolishNotation(ShuntingYard(expression));
        }
    }
}
