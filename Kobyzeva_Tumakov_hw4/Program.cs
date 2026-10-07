
namespace Kobyzeva_Tumakov_hw4
{
    internal class Program
    {
        /// <summary>
        /// Возвращает максимальное число из двух данных
        /// </summary>
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        /// <returns>Максимальное из первого и второго чисел</returns>
        public static int MaxNumbers(int number1, int number2)
        {
            return number1 >= number2 ? number1 : number2;
        }

        /// <summary>
        /// Возвращает минимальное число из двух данных
        /// </summary>
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        /// <returns>Минимальное из первого и второго чисел</returns>
        public static int MinNumbers(int number1, int number2)
        {
            return number1 <= number2 ? number1 : number2;
        }

        /// <summary>
        /// Меняет два данных объекта местами
        /// </summary>
        /// <param name="parameter1">Первый параметр</param>
        /// <param name="parameter2">ВТорой параметр</param>
        /// <returns>Значение параметра1 соответствует параметру2 и обртно</returns>
        public static (object, object) Reverse(ref object parameter1, ref object parameter2)
        {
            var assistant = parameter1;
            parameter1 = parameter2;
            parameter2 = assistant;
            return (parameter1,  parameter2);

        }

        /// <summary>
        /// Счет факториала, возвращает false, если достигнуто переполнение
        /// </summary>
        /// <param name="number">Число для поиска факториала</param>
        /// <param name="result">Результат вычисления факториала</param>
        /// <returns>bool значение, достигнуто ли переполнение</returns>
        public static bool Factorial(uint number, out ulong result)
        {
            result = 1;
            ulong factorial = 1;
            try 
            {
                checked
                {
                    for (int i = 1; i <= number; i++)
                    {
                        factorial *= (ulong)i;
                    }
                    result = factorial;
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }

        /// <summary>
        /// Счет факториала вложенной функцией
        /// </summary>
        /// <param name="number">Число для расчета его факториала</param>
        /// <returns>Результат расчета факториала</returns>
        public static ulong Factorial(uint number)
        {
            if (number == 0 || number == 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }

        /// <summary>
        /// Нахождение наибольшего общего делителя двух данных чисел
        /// </summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        /// <returns>Наибольший общий множитель</returns>
        public static int CalculateNod(int num1, int num2)
        {
            int numMin = MinNumbers(Math.Abs(num1), Math.Abs(num2));
            int numMax = MaxNumbers(Math.Abs(num1), Math.Abs(num2));
            if (numMin == 0)
            {
                return Math.Abs(numMax);
            }
            else if (numMax % numMin == 0)
            {
                return numMin;
            }
            else
            {
                return CalculateNod(numMax % numMin, numMin);
            }
        }

        /// <summary>
        /// Нахождение наибольшего общего делителя трех чисел, вызывает НОД для двух чисел
        /// </summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        /// <param name="num3">Третье число</param>
        /// <returns>Наибольший общий множитель</returns>
        public static int CalculateNod(int num1, int num2, int num3)
        {
            return CalculateNod(CalculateNod(num1, num2), num3);
        }

        /// <summary>
        /// Вывод n-числа ряда Фибоначчи
        /// </summary>
        /// <param name="number">Порядковый номер числа</param>
        /// <returns>Значение порядкого числа</returns>
        public static uint FibonacciSequence(uint number)
        {
            if (number <= 1)
            {
                return number;
            }
            return FibonacciSequence(number - 1) + FibonacciSequence(number - 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 5.1");
            bool isInputValid = true;
            int num1;
            int num2;

            while (isInputValid)
            {
                Console.WriteLine("Введите первое число:");
                string inputNum1 = Console.ReadLine();
                Console.WriteLine("Введите второе число:");
                string inputNum2 = Console.ReadLine();
                if (int.TryParse(inputNum1, out num1) && (int.TryParse(inputNum2, out num2)))
                {
                    int maxNumbers = MaxNumbers(num1, num2);
                    Console.WriteLine($"Наибольшее значение: {maxNumbers}");
                    isInputValid = false;
                }
                else
                {
                    Console.WriteLine("Неверно введены данные, попробуйте еще");
                }
            }
            
            Console.WriteLine("Упражнение 5.2");
            isInputValid = true;

            while (isInputValid)
            {
                Console.WriteLine("Введите первый параметр:");
                object inputParam1 = Console.ReadLine();
                Console.WriteLine("Введите второй параметр:");
                object inputParam2 = Console.ReadLine();
                try
                {
                    var resultReverse = Reverse(ref inputParam1, ref inputParam2);
                    Console.WriteLine($"Результат: {resultReverse}");
                    isInputValid = false;
                }
                catch
                {
                    Console.WriteLine("Неверно введены данные, попробуйте еще");
                }
               
            }

            Console.WriteLine("Упражнение 5.3");
            isInputValid = true;
            while(isInputValid)
            {
                Console.WriteLine("Введите число для расчета его факториала:");
                if (!uint.TryParse(Console.ReadLine(), out uint number))
                {
                    Console.WriteLine("Неверно введено число");
                }
                else
                {
                    bool canCalculateFactorial = Factorial(number, out ulong result);
                    if (canCalculateFactorial)
                    {
                        Console.WriteLine($"Метод успешно отработан. Результат: {result}");
                    }
                    else
                    {
                        Console.WriteLine($"Возникло переполнение!");
                    }
                    isInputValid = false;
                }
            }

            Console.WriteLine("Упражнение 5.4");
            isInputValid = true;
            while (isInputValid)
            {
                Console.WriteLine("Введите число для расчета его факториала:");
                if (!uint.TryParse(Console.ReadLine(), out uint number))
                {
                    Console.WriteLine("Неверно введено число");
                }
                else
                {
                    Console.WriteLine($"Метод успешно отработан. Результат: {Factorial(number)}");
                    isInputValid = false;
                }
            }

            Console.WriteLine("Домашнее задание 5.1");
            Console.WriteLine("Нахождение НОД для двух чисел.");
            isInputValid = true;
            while(isInputValid)
            {
                Console.WriteLine("Введите первое число:");
                string inputNum1 = Console.ReadLine();
                Console.WriteLine("Введите второе число:");
                string inputNum2 = Console.ReadLine();
                if (int.TryParse(inputNum1, out int number1) && int.TryParse(inputNum2, out int number2))
                {
                    Console.WriteLine($"НОД {number1} и {number2}: {CalculateNod(number1, number2)}");
                    isInputValid = false;
                }
                else
                {
                    Console.WriteLine("Неверно введены данные");
                }
            }

            Console.WriteLine("Нахождение НОД для трех чисел.");
            isInputValid = true;
            while (isInputValid)
            {
                Console.WriteLine("Введите первое число:");
                string inputNum1 = Console.ReadLine();
                Console.WriteLine("Введите второе число:");
                string inputNum2 = Console.ReadLine();
                Console.WriteLine("Введите третье число:");
                string inputNum3 = Console.ReadLine();
                if (int.TryParse(inputNum1, out int number1) && int.TryParse(inputNum2, out int number2) && int.TryParse(inputNum3, out int number3))
                {
                    Console.WriteLine($"НОД {number1}, {number2} и {number3}: {CalculateNod(number1, number2, number3)}");
                    isInputValid = false;
                }
                else
                {
                    Console.WriteLine("Неверно введены данные");
                }
            }

            Console.WriteLine("Домашнее задание 5.2");
            isInputValid = true;
            while(isInputValid)
            {
                Console.WriteLine("Введите число:");
                if (!uint.TryParse(Console.ReadLine(), out uint nNumberSequence))
                {
                    Console.WriteLine("Неверно введены данные");
                }
                else
                {
                    Console.WriteLine($"Значение {nNumberSequence} числа в ряду Фибоначчи: {FibonacciSequence(nNumberSequence)}");
                    isInputValid = false;
                }
            }
        }
    }
}
