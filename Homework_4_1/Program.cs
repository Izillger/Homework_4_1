using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuProgram();
            Console.ReadKey();
        }
     
    // Главное меню программы
    static void MenuProgram()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------------- Задание 1 ----------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Показать таблицу прибыли по месяцам >>\n");
            Console.WriteLine("2. Показать все месяцы с положительной прибылью >>\n");
            Console.WriteLine("3. Показать месяцы с худшим показателем прибыли >>\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------------- Задание 2 ----------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("4. Построить треугольник Паскаля >>\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------------- Задание 3 ----------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("5. Умножение математической матрицы на число >>\n");
            Console.WriteLine("6. Сложение и вычитание математических матриц >>\n");
            Console.WriteLine("7. Перемножение математических матриц >>\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите номер интересующего вас пункта и нажмите Enter >>");
            Console.ForegroundColor = ConsoleColor.White;

            int num = 0;
            num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    AllTable();
                    break;

                case 2:
                    ProfitUp();
                    break;

                case 3:
                    ProfitDown();
                    break;

                case 4:
                    Piramida();
                    break;

                case 5:
                    Matrix1();
                    break;

                case 6:
                    Matrix2();
                    break;

                case 7:
                    Matrix3();
                    break;

                default: break;
            }  // Навигация по меню

        }
    // Возврат в меню
    static void ReturnMenu() 
    {
        Console.WriteLine("------------------------------------------------------------\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Нажмите любую кнопку для возврата в меню");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
        MenuProgram();
    }

        // --------------------------------------- Задание 1 ---------------------------------
        // Заказчик просит вас написать приложение по учёту финансов
        #region
        private static int[] arrayEntrances =
    {
        0,
        0,
        0,
        0,
        0,
        0,
        30,
        30,
        20,
        20,
        10,
        10
    }; // Массив дохода

        private static int[] arrayExpenses =
    {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
    }; // Массив расходов

        private static string[] arrayMonth =
    {
        "Январь",
        "Февраль",
        "Март",
        "Апрель",
        "Май",
        "Июнь",
        "Июль",
        "Август",
        "Сентябрь",
        "Октябрь",
        "Ноябрь",
        "Декабрь"
    }; // Массив месяцев

        private static int[] arrayProfit = new int[12]; // Массив для прибыли
        
        // Расчёт и заполнение массива прибыли
        private static void LoadArraProfit()
        {
            for (int k = 0; k < arrayEntrances.Length; k++)
            {
                arrayProfit[k] = (arrayEntrances[k] - arrayExpenses[k]);
            }
        }

        // Вывод всей таблици на экран
        private static void AllTable()
        {
            Console.Clear();
            LoadArraProfit();
            Console.WriteLine("                                 Таблица прибыли по месяцам:");
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"Месяц:",10} {"Доход:",14} {"Расход:",17} {"Прибыль:",16}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------");

            // Вывод данных на экран
            for (int i = 0; i < arrayEntrances.Length; i++)
            {
                Console.WriteLine($"{arrayMonth[i],10}" +
                                  $"{arrayEntrances[i].ToString(arrayEntrances[i] == 0 ? "### ##0" : "### ###"),15}" +
                                  $"{arrayExpenses[i].ToString(arrayExpenses[i] == 0 ? "### ##0" : "### ###"),17}" +
                                  $"{arrayProfit[i].ToString(arrayProfit[i] == 0 ? "### ##0" : "### ###"),17}");
                /* Маска вывода проверяется на равенство нулю, в противном случае вывод получится пустым,
                если не использовать '?' */
            }

            ReturnMenu();

        }

        // Вывод всех месяцев с положительной прибылью
        private static void ProfitUp()
        {
            Console.Clear();
            LoadArraProfit();
            Console.WriteLine("                        Все месяцы с положительной прибылью:");
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"Месяц:",10} {"Прибыль:",14}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------\n");
            for (int i = 0; i < arrayExpenses.Length; i++)
            {
                if (arrayProfit[i] > 0)
                {
                    Console.WriteLine($"{arrayMonth[i],10}" +
                                      $"{arrayProfit[i].ToString("### ###"),15}");
                }
            }

            ReturnMenu();
        }

        // Вывод всех месяцев с худшей прибылью
        private static void ProfitDown()
        {
            Console.Clear();
            LoadArraProfit();
            Console.WriteLine("                    Все месяцы с худшим показателем прибыли:");
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"Месяц:",10} {"Прибыль:",14}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------\n");

            int[] sortArrayProfit = new int[12]; // Новый массив для сортировки прибыли (чтобы не путать данные для других заданий)
            string[] sortArrayMounth = new string[12]; // Новый массив для сортировки прибыли

            // Заполнение новых массивов
            for (int j = 0; j < arrayProfit.Length; j++)
            {
                sortArrayProfit[j] = arrayProfit[j];
                sortArrayMounth[j] = arrayMonth[j];
            }

            // Сортировка массива c месяцами по значению массива с доходами
            Array.Sort(sortArrayProfit.ToArray(), sortArrayMounth); 
            Array.Sort(sortArrayProfit); // Сортировка массива для вывода худших месяцев по прибыли
            int count = 0;               // Счётчик для вывода месяцев с самой низкой прибылью
            
            for (int i = 0; i < sortArrayProfit.Length; i++)
            {   
                if (count == 0 || (((i + 1) < sortArrayProfit.Length) && sortArrayProfit[i + 1] >= sortArrayProfit[i])) 
                { 
                     if (count < 3)
                     {  
                           Console.WriteLine($"{sortArrayMounth[i],10}" +
                              $"{sortArrayProfit[i].ToString(sortArrayProfit[i] == 0 ? "### ##0" : "### ###"),14}");
                           // Если прибыль следующего месяца больше предыдущего то счётчик +1
                           if (((i + 1) < sortArrayProfit.Length)  && (sortArrayProfit[i + 1] > sortArrayProfit[i])) count++;     
                     }
                     // Разделитель после месяцев
                     if ((sortArrayProfit[i + 1] > sortArrayProfit[i])) Console.WriteLine("-------------------------");
                }
            }
            ReturnMenu();
        }

        #endregion

        // --------------------------------------- Задание 2 ---------------------------------
        // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
        #region

        static void Piramida()
        {
            Console.Clear();
            Console.WriteLine("                               Построить треугольник Паскаля");
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите число строк для теугольника Паскаля >>");
            Console.ForegroundColor = ConsoleColor.White;

            int n = 0; // Для ввода строк теугольника Паскаля
            n = int.Parse(Console.ReadLine()); // Получаем число n от пользователя
            Console.WriteLine();

            int[][] arrayTriangle = new int[n][];
            // первая строка
            arrayTriangle[0] = new int[1];

            for (int i = 0; i < arrayTriangle.Length; i++)    // Вычисление треугольника
            {
                arrayTriangle[i] = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        arrayTriangle[i][j] = 1;
                    else
                    {
                        arrayTriangle[i][j] = arrayTriangle[i - 1][j - 1] + arrayTriangle[i - 1][j];
                    }
                }
            }

            for (int i = 0; i < arrayTriangle.Length; i++)     // Вывод треугольника на экран
            {
                System.Console.Write("   ");
                for (int q = 0; q < n - i; q++)     // Расставляем пробелы для построения треугольника
                {
                    System.Console.Write("   ");
                }
                for (int j = 0; j < arrayTriangle[i].Length; j++)
                {
                    System.Console.Write(" ");
                    Console.Write($"{arrayTriangle[i][j],5}");
                }
                Console.WriteLine("\n");
            }
            ReturnMenu();
            Console.ReadKey();
        }

        #endregion

        // ---------------------------------------- Задание 3 ---------------------------------  
        #region
        // * Задание 3.1
        // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
        private static void Matrix1()
        {
            int matrixString, matrixColumn, numMatrix;

            Console.Clear();
            LoadArraProfit();
            Console.WriteLine("                   Умножение математической матрицы на число");
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;  

            Console.WriteLine($"{"Введите количество строк матрицы: "}");
            matrixString = int.Parse(Console.ReadLine());

            Console.WriteLine($"{"Введите количество столбцов матрицы: "}");
            matrixColumn = int.Parse(Console.ReadLine());

            Console.WriteLine($"{"Введите множитель матрицы: "}");
            numMatrix = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------\n");

            Random rand = new Random(); // Генератор случайных чисел

            int[,] matrix1 = new int[matrixString, matrixColumn];       // Для вывода входящих данных
            int[,] matrixResult1 = new int[matrixString, matrixColumn]; // Для вывода результата

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"   {numMatrix}  X  \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < matrixString; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");                       // Вывод входящих данных
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrix1[i, j] = rand.Next(10);
                    Console.Write($"{matrix1[i, j],3}");
                    
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");

                Console.Write("  =  |");                    // Вывод результата
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrixResult1[i, j] = matrix1[i, j] * numMatrix;      // Умножение матрицы на число
                    Console.Write($"{matrixResult1[i, j],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.WriteLine();
            ReturnMenu();
        }

        // ** Задание 3.2
        // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
        private static void Matrix2()
        {
            int matrixString, matrixColumn;

            Console.Clear();
            LoadArraProfit();
            Console.WriteLine("                   Сложение и вычитание математических матриц");
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"{"Введите количество строк матрицы: "}");
            matrixString = int.Parse(Console.ReadLine());

            Console.WriteLine($"{"Введите количество столбцов матрицы: "}");
            matrixColumn = int.Parse(Console.ReadLine());
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------\n");

            Random rand = new Random(); // Генератор случайных чисел

            int[,] matrix2 = new int[matrixString, matrixColumn];       // Для вывода входящих данных
            int[,] matrix22 = new int[matrixString, matrixColumn]; // Для вывода результата
            int[,] matrixResult2 = new int[matrixString, matrixColumn]; // Для вывода результата

            // Сложение матриц
            for (int i = 0; i < matrixString; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");                        // Вывод входящих данных
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrix2[i, j] = rand.Next(10);     // Заполнение матрицы рандомом
                    Console.Write($"{matrix2[i, j],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");
                
                Console.Write("  +  |");
                Console.ForegroundColor = ConsoleColor.White;// Вывод результата
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrix22[i, j] = rand.Next(10);      // Заполнение матрицы рандомом
                    Console.Write($"{matrix22[i, j],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");

                Console.Write("  =  |");                    // Вывод результата
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrixResult2[i, j] = matrix2[i, j] + matrix22[i, j] ;      // Сложение матриц
                    Console.Write($"{matrixResult2[i, j],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.WriteLine();

            // Вычитание матриц
            for (int i = 0; i < matrixString; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");                        // Вывод входящих данных
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrix2[i, j] = rand.Next(10);
                    Console.Write($"{matrix2[i, j],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");

                Console.Write("  -  |");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrix22[i, j] = rand.Next(10);      // Заполнение массива рандомом
                    Console.Write($"{matrix22[i, j],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");

                Console.Write("  =  |");                    // Вывод результата
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn; j++)
                {
                    matrixResult2[i, j] = matrix2[i, j] - matrix22[i, j];      // Вычитание матриц
                    Console.Write($"{matrixResult2[i, j],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.WriteLine();
            ReturnMenu();
        }

        // *** Задание 3.3
        // Заказчику требуется приложение позволяющщее перемножать математические матрицы
        private static void Matrix3()
        {
            int matrixString1, matrixColumn1, matrixString2, matrixColumn2;

            Console.Clear();
            LoadArraProfit();
            Console.WriteLine("                          Перемножение математических матриц");
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"{"Количество строк должно совпадать с количеством столбцов!\n"}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{"Введите количество строк для 1-ой матрицы: \n"}");
            matrixString1 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{"Введите количество столбцов для 1-ой матрицы: \n"}");
            matrixColumn1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"Введите количество строк для 2-ой матрицы: \n"}");
            matrixString2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{"Введите количество столбцов для 2-ой матрицы: \n"}");
            matrixColumn2 = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------\n");

            Random rand = new Random(); // Генератор случайных чисел

            int[,] matrixA = new int[matrixString1, matrixColumn1];       // Матрица 1 для вывода входящих данных
            int[,] matrixB = new int[matrixString2, matrixColumn2];       // Матрица 2 для вывода результата

            // Заполнеие, перемножение и вывод матриц на экран
            for (int i = 0; i < matrixString1; i++)
            {
                // Вывод входящих данных для 1-ой матрицы
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < matrixColumn1; j++)
                {
                    matrixA[i, j] = rand.Next(1, 10); // Заполнение матрицы рандомом
                    Console.Write($"{matrixA[i, j],3}");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |  X");
                Console.WriteLine();
            }
            Console.WriteLine();

            // Вывод входящих данных для 2-ой матрицы
            for (int i = 0; i < matrixString2; i++)
            {
                Console.Write("  |");
                Console.ForegroundColor = ConsoleColor.White;
                for (int k = 0; k < matrixColumn2; k++)
                {
                    matrixB[i, k] = rand.Next(1,10);      // Заполнение матрицы рандомом
                    Console.Write($"{matrixB[i, k],3}");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |");
                Console.WriteLine();
            }
            Console.WriteLine();
                
            // Проверка на возможность перемножения матриц и вывод результата на экран
            if (matrixA.GetUpperBound(1) + 1 == matrixB.GetUpperBound(0) + 1)
            {
              int[,] matrixResult = MultiplicationMatrix(matrixA, matrixB);
                  for (int i = 0; i < matrixA.GetLength(0); i++)
                  {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  =  |");
                    Console.ForegroundColor = ConsoleColor.White;

                    for (int j = 0; j < matrixB.GetLength(1); j++)
                    {
                     Console.Write($"\t{matrixResult[i, j],4}");
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  |");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");
                  }    
            } else Console.WriteLine("  Эти матрицы нельзя перемножить!");

            // Перемножения матриц
                int[,] MultiplicationMatrix(int[,] matrixa, int[,] matrixb)
                {
                int[,] r = new int[matrixa.GetUpperBound(0) + 1, matrixb.GetUpperBound(1) + 1];  // Матрица для вывода результата
                    for (int i = 0; i < matrixa.GetUpperBound(0) + 1; i++)
                    {
                        for (int j = 0; j < matrixb.GetUpperBound(1) + 1; j++)
                        {
                            r[i, j] = 0;
                            for (int k = 0; k < matrixa.GetUpperBound(1) + 1; k++)
                            {
                                r[i, j] += matrixa[i, k] * matrixb[k, j];
                            }
                        }
                    }
                    return r;
            }
            Console.WriteLine();
            ReturnMenu();
        }
    }
    #endregion
} //-------------------------------------------------------


