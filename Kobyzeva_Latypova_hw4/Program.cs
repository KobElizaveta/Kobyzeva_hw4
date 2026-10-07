using System.Threading;
using Kobyzeva_Latypova_hw4.Enum;
using Kobyzeva_Latypova_hw4.Struct;

namespace Kobyzeva_Latypova_hw4
{
    internal class Program
    {
        /// <summary>
        /// Меняет два символа из списка местами
        /// </summary>
        /// <param name="arrayRandom">Произвольный массив целых чисел</param>
        public static void ChangeOfElements(int[] arrayRandom)
        {
            foreach (int num in arrayRandom)
            {
                Console.Write(num + "  ");
            }
            Console.WriteLine();

            bool isInputValid = true;
            while(isInputValid)
            {
                Console.WriteLine("Введите первое число из списка:");
                string num1ToChangeStr = Console.ReadLine();
                Console.WriteLine("Введите первое число из списка:");
                string num2ToChangeStr = Console.ReadLine();
                if (!int.TryParse(num1ToChangeStr, out int num1ToChange) || !int.TryParse(num2ToChangeStr, out int num2ToChange))
                {
                    Console.WriteLine("Введены не числа, попробуйте заново");
                }
                else if (!arrayRandom.Contains(num1ToChange) || !arrayRandom.Contains(num2ToChange))
                {
                    Console.WriteLine("Введены числа, которых нет в списке, попробуйте заново");
                }
                else
                {
                    byte indexNum1 = (byte)Array.IndexOf(arrayRandom, num1ToChange);
                    byte indexNum2 = (byte)Array.IndexOf(arrayRandom, num2ToChange);
                    arrayRandom[indexNum1] = num2ToChange;
                    arrayRandom[indexNum2] = num1ToChange;
                    isInputValid = false;
                }
            }

            foreach (int num in arrayRandom)
            {
                Console.Write(num + "  ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит произведение и сумму элементов, среднее арифметическое в массиве данных чисел
        /// </summary>
        /// <param name="multiplication">ПРоизведение элементов</param>
        /// <param name="meanArithmetic">Среднее арифметическое</param>
        /// <param name="array">Массив целочисленных значений</param>
        /// <returns>Сумма значений массива</returns>
        public static int InfoAboutArray(ref int multiplication, out float meanArithmetic, params byte[] array)
        {
            multiplication = 1;
            meanArithmetic = 0;
            int sum = 0;
            foreach(byte element in array)
            {
                multiplication *= element;
                sum += element;
                meanArithmetic += (float)element;
            }
            if(array.Count() != 0)
            {
                meanArithmetic /= array.Count();
            }

            Console.Write("Массив:  ");
            foreach(byte element in array)
            {
                Console.Write(element + "  ");
            }
            Console.WriteLine($"\nПроизведение элементов: {multiplication}\nСреднее арифметическое: {meanArithmetic}\nСумма: {sum}");

            return sum;
        }

        /// <summary>
        /// Рисует символом # исло в диапазоне от 0 до 9
        /// </summary>
        /// <param name="num">Число 0-9</param>
        public static void DrawNum(int num)
        {
            switch(num)
            {
                case 0:
                    Console.WriteLine("# # #\n#   #\n#   #\n#   #\n# # #");
                    break;
                case 1:
                    Console.WriteLine("  #  \n  #  \n  #  \n  #  \n  #  ");
                    break;
                case 2:
                    Console.WriteLine("# # #\n    #\n# # #\n#   \n# # #");
                    break;
                case 3:
                    Console.WriteLine("# # #\n    #\n# # #\n    #\n# # #");
                    break;
                case 4:
                    Console.WriteLine("#   #\n#   #\n# # #\n    #\n    #");
                    break;
                case 5:
                    Console.WriteLine("# # #\n#    \n# # #\n    #\n# # #");
                    break;
                case 6:
                    Console.WriteLine("# # #\n#    \n# # #\n#   #\n# # #");
                    break;
                case 7:
                    Console.WriteLine("# # #\n    #\n    #\n    #\n    #");
                    break;
                case 8:
                    Console.WriteLine("# # #\n#   #\n# # #\n#   #\n# # #");
                    break;
                case 9:
                    Console.WriteLine("# # #\n#   #\n# # #\n    #\n# # #");
                    break;
                default:
                    Console.WriteLine("Ошибка, число должно быть в диапазоне от 0 до 9");
                    break;
            }
        }

        /// <summary>
        ///Перенаправляет на DrawNum (рисование цифры 0-9 #) или выводит ошибку при неверном вводе. Красный экран - число вне диапазоне, вылетает - если не число
        /// </summary>
        public static void DrawNumOrPrintError()
        {

            bool isInputValid = true;
            Console.WriteLine("Для окончания работы программы введите 'закрыть' или 'exit'");
            while(isInputValid)
            {
                bool isProgramRunning = true;
                while(isProgramRunning)
                {
                    Console.WriteLine("Введите число от 0 до 9");
                    string messageInput = Console.ReadLine();

                    if (messageInput == "exit" || messageInput == "закрыть")
                    {
                        return;
                    }
                    bool isReverse = (int.TryParse(messageInput, out int numInput));
                    if (!isReverse)
                    {
                        throw new Exception($"'{messageInput}' — это не число! Программа завершена.");
                    }
                    else if(numInput < 0 || numInput > 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Thread.Sleep(3000);
                        Console.ResetColor();
                        Console.Clear();
                        Console.WriteLine("Число должно быть в диапазоне от 0 до 9, повторите попытку");
                    }
                    else
                    {
                        DrawNum(numInput);
                        isProgramRunning = false;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Random rnd = new Random();
            int[] arrayRandom = new int[20];
            for (int i = 0; i < 20; i++)
            {
                arrayRandom[i] = rnd.Next(1, 100);
            }

            ChangeOfElements(arrayRandom);

            Console.WriteLine("Задание 2");
            int multiplicatElementInArray = 1;
            InfoAboutArray(ref multiplicatElementInArray, out float meanArithmetic, 1, 4, 6, 9, 3, 10, 14, 19, 11, 2);
            
            Console.WriteLine("Задание 3");
            DrawNumOrPrintError();

            Console.WriteLine("Задание 4");
            Grandfather granfather1 = new Grandfather("Иван Петрович", GrumpinessLevel.ModeraterlyGrumpy, ["Бестолочь", "Оболтус", "Балабол", "Блядь", "Сучий сын", "Выебистый", "Хам"], default);
            Grandfather granfather2 = new Grandfather("Степаныч", GrumpinessLevel.SlightlyGrumpy, ["Недоросль", "Свинтус", "Сопляк", "Выскочка"], default);
            Grandfather granfather3 = new Grandfather("Василич", GrumpinessLevel.Grumpy, ["Баламут", "Обжора", "Хам", "Идиот", "Доебчивый", "Долбоеб", "Уебан", "Пиздабол", "Сука"], default);
            Grandfather granfather4 = new Grandfather("Тихон", GrumpinessLevel.NotGrumpy, ["Подлец", "Грубиян", "Бесстыдник"], default);
            Grandfather granfather5 = new Grandfather("Володя Трубочист", GrumpinessLevel.SlightlyGrumpy, ["Дармоед", "Мямля", "Лоботряс", "Ебанутый", "Ебанько"], default);
            string[] listBadWords = { "Блядь", "Сучий сын", "Выебистый", "Доебчивый", "Долбоеб", "Уебан", "Ебанько", "Ебанутый", "Сука", "Пиздабол" };

            Grandfather.BruisesForUsingFoulLanguage(granfather1, listBadWords);
            Grandfather.BruisesForUsingFoulLanguage(granfather2, listBadWords);
            Grandfather.BruisesForUsingFoulLanguage(granfather3, listBadWords);
            Grandfather.BruisesForUsingFoulLanguage(granfather4, listBadWords);
            Grandfather.BruisesForUsingFoulLanguage(granfather5, listBadWords);

        }
    }
}
