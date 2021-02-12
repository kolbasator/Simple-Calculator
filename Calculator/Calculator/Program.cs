using System; 
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Калькулятор со скобками и операциями +-*/ .Если хочешь получить нормальный результат ,то не дели на нуль, и не дели сам нуль.А так же, Ставь пробелы после каждой скобки-числа-оператора .Например : пиши не 2*(2+2), а пиши 2 * ( 2 + 2 ).");
                Console.Write("Введите выражение: ");
                Calculator calculator = new Calculator();
                string expression = Console.ReadLine();
                Console.WriteLine(calculator.Calculate(expression));
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
