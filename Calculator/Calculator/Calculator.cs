﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text; 

namespace Calculator
{
    public class SimpleCalculator
    {
        static int Priority(string symbol)
        {
            if(symbol=="sin" || symbol == "cos" || symbol == "ctn" || symbol == "tan" || symbol=="log")
            {
                return 5;
            }
            else if (symbol == "^")
            {
                return 4;
            }
            else if (symbol == "*" || symbol == "/")
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
            string[] tokens = expression.Split(null); 
            List<string> output = new List<string>();
            Stack<string> operators = new Stack<string>();
            //Рассматриваем поочередно каждый символ:
            for (int i = 0; i < tokens.Length; i++)
            {
                //1.Если этот символ -число(или переменная), то просто помещаем его в выходную строку  
                if (tokens[i] == "PI")
                {
                    output.Add("3.14");
                    continue;
                }
                if (IsNumber(tokens[i]) || tokens[i]==".")
                {
                    output.Add(tokens[i]);
                    continue;
                }
              
                switch (tokens[i])
                { 
                    case "(":
                        //3.Если текущий символ -открывающая скобка, то помещаем ее в стек.
                        operators.Push(tokens[i]);
                        break;
                    case "^":
                    case "*":
                    case "/":
                    case "+":
                    case "-":
                    case "sin":
                    case "tan":
                    case "ctn":
                    case "cos":
                    case "log":
                        #region Comments
                        //2.Если символ - знак операции(+, -, *, / ), то проверяем приоритет данной операции.
                        //Операции умножения и деления имеют наивысший приоритет(допустим он равен 
                        //3).Операции сложения и вычитания имеют меньший приоритет(равен 2). Наименьший приоритет(равен 1) 
                        //имеет открывающая скобка.
                        //Получив один из этих символов, мы должны проверить стек:
                        //а) Если стек все еще пуст, или находящиеся в нем символы(а находится в нем могут только знаки операций и \
                        //открывающая скобка) имеют меньший приоритет, чем приоритет текущего символа, 
                        //то помещаем текущий символ в стек.
                        //б) Если символ, находящийся на вершине стека имеет приоритет, больший или равный приоритету текущего символа, 
                        //то извлекаем символы из стека в выходную строку до тех пор, пока выполняется это условие; 
                        //затем переходим к пункту а).
                        #endregion
                        while (operators.Count > 0 && Priority(tokens[i]) <= Priority(operators.Peek().ToString()))
                        {
                            output.Add(operators.Pop().ToString());
                        }
                        operators.Push(tokens[i]);
                        break;
                    case ")":
                        #region Comments
                        //4.Если текущий символ -закрывающая скобка, то извлекаем символы из стека в выходную строку до тех пор, пока не встретим в стеке
                        //открывающую скобку(т.е.символ с приоритетом, равным 1), которую следует просто уничтожить. Закрывающая скобка также уничтожается.
                        #endregion
                        while (operators.Peek() != "(")
                        {
                            output.Add(operators.Pop().ToString());
                        }
                        operators.Pop();
                        break;
                    default:
                        throw new InvalidOperationException("Не стоит пихать что попало в калькулятор ! Будь разумным.");
                }
            }
            //Если вся входная строка разобрана, а в стеке еще остаются знаки операций, извлекаем их из стека в выходную строку.  
            while (operators.Any())
            {
                output.Add(operators.Pop().ToString());
            }
            return output;
        }
        static bool IsNumber(string n)
        {
            #region
            double retNum;
            bool isNumeric = double.TryParse(n, out retNum);
            return isNumeric;
            #endregion
        }
        public double ReversePolishNotation(List<string> tokens)
        {
            //Алгоритм высчитывания результата
            Stack<double> resultStack = new Stack<double>();
            foreach (var token in tokens)
            {
                double leftOperand;
                double rightOperand;
                //Если символ в переработанном выражении число ,то помещаем его в стек.
                if (IsNumber(token.ToString()))
                {
                    resultStack.Push(double.Parse(token.ToString()));
                }
                switch (token)
                {
                    //Если символ -оператор ,то производим операцию с последнеми двумя чисами в стеке.Затем добавляем результат в стек.
                    case "+":
                        resultStack.Push(resultStack.Pop() + resultStack.Pop());
                        break;
                    case "-":
                        rightOperand = resultStack.Pop();
                        resultStack.Push(resultStack.Pop() - rightOperand);
                        break;
                    case "*":
                        resultStack.Push(resultStack.Pop() * resultStack.Pop());
                        break;
                    case "/":
                        rightOperand = resultStack.Pop();
                        leftOperand = resultStack.Pop();
                        if (Math.Round(rightOperand) == 0 )
                        {
                            throw new InvalidOperationException("Не делай так");
                        }
                        resultStack.Push(leftOperand / rightOperand);
                        break;
                    case "^":
                        rightOperand = resultStack.Pop();
                        leftOperand = resultStack.Pop();
                        resultStack.Push(Math.Pow(leftOperand, rightOperand));
                        break;
                    case "sin":
                        double numberToSin = resultStack.Pop();
                        resultStack.Push(Math.Sin(numberToSin));
                        break;
                    case "cos":
                        double numberToCos = resultStack.Pop();
                        resultStack.Push(Math.Cos(numberToCos));
                        break;
                    case "ctn":
                        double numberToCtn = resultStack.Pop();
                        resultStack.Push(1/Math.Tan(numberToCtn));
                        break;
                    case "tan":
                        double numberToTan = resultStack.Pop();
                        resultStack.Push(Math.Tan(numberToTan));
                        break;  
                    case "log":
                        double numberToLog = resultStack.Pop();
                        resultStack.Push(Math.Log(numberToLog));
                        break;
                    case "ex":
                        double numberToEx = resultStack.Pop();
                        resultStack.Push(Math.Exp(numberToEx));
                        break;
                }
            }
            if (resultStack.Count != 1)
            {
                throw new InvalidOperationException();
            }
            return resultStack.Pop();
        }
        public double Calculate(string expression)
        {
            return ReversePolishNotation(ShuntingYard(expression));
        }
    }
}
