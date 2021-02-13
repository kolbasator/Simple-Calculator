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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Калькулятор со скобками и операциями +-*/ .Если хочешь получить нормальный результат ,то не дели на нуль.А так же, Ставь пробелы после каждой скобки-числа-оператора .Например : пиши не 2*(2+2), а пиши 2 * ( 2 + 2 ).Вы так же можете использовать константу P (записывать в верхнем регистре и на английском).");
                Console.Write("Введите выражение: ");
                SimpleCalculator calculator = new SimpleCalculator();
                string expression = Console.ReadLine();
                Console.WriteLine(calculator.Calculate(expression));
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
