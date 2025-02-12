using System.Formats.Asn1;
using System.Dynamic;
using System;

namespace ООП
{
    class Program
    {
        #region 1часть

        static public void FirstStage()
        {
            try
            {
                ChessboardCell a0 = new ChessboardCell(); //Конструктор по умолчанию
                ChessboardCell a1 = new ChessboardCell(a0); //Конструктор с параметром
                ChessboardCell a2 = new ChessboardCell(5, 5, ChessboardCell.Color.black); //Конструктор с параметрами
                Console.WriteLine(a1.Show());
                Console.WriteLine(a2.Show());
                Console.WriteLine($"Количество объектов: {ChessboardCell.GetCount()}"); //Вывод количества объектов
                Console.WriteLine("Цвета клеток одинаковы?: " + ChessboardCell.ColorComparison1(a1, a2)); //Цвет клеток #1
                Console.WriteLine("Цвета клеток одинаковы?: " + a1.ColorComparison2(a1, a2)); //Цвет клеток #2
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region 2 часть
        static public void SecondStage()
        {
            int answer2; //Переменная для второго меню
            ChessboardCellArray? array = null; //Коллекция для демонстрации

            Console.WriteLine("==========================");
            do
            {
                //Проверка числа на ввод
                bool isChecked;
                do
                {
                    Console.WriteLine("Введите число");
                    Console.WriteLine("1. Перегрузка унарной операции (инкремент)");
                    Console.WriteLine("2. Перегрузка операции (смена клеток)");
                    Console.WriteLine("3. Явное преобразование (сумма координат клетки)");
                    Console.WriteLine("4. Неявное преобразование (цвет клетки)");
                    Console.WriteLine("5. Бинарные операции (сравнение)#1");
                    Console.WriteLine("6. Бинарные операции (сравнение)#2");
                    Console.WriteLine("7. Функция сравнения объектов (Equals)");
                    Console.WriteLine("8. Создать массив ChessboardCellArray");
                    Console.WriteLine("9. Вывести элементы массива");
                    Console.WriteLine("10. Скопировать массив (глубокое копирование)");
                    Console.WriteLine("11. Работа с индексатором");
                    Console.WriteLine("12. Найти ближайшую клетку к левому нижнему углу");
                    Console.WriteLine("13. Завершение работы");

                    isChecked = int.TryParse(Console.ReadLine(), out answer2);
                    if (answer2 < 1 || answer2 > 13)
                    {
                        Console.WriteLine("Неверный пункт меню!");
                        isChecked = false;
                    }
                    else if (!isChecked)
                    {
                        Console.WriteLine("Ошибка ввода");
                    }
                } while (!isChecked);

                //Вторая часть программы
                switch (answer2)
                {
                    //Перегрузка унарной операции (инкремент)
                    case 1:
                        ChessboardCell a0 = new ChessboardCell();
                        ChessboardCell a3 = new ChessboardCell(a0);
                        ChessboardCell a4 = new ChessboardCell(5, 5, ChessboardCell.Color.black);
                        a3++;
                        a4++;
                        Console.WriteLine("Первая фигура: " + a3.Show());
                        Console.WriteLine("Вторая фигура: " + a4.Show());
                        Console.WriteLine("==========================");
                        break;

                    //Перегрузка операции (смена клеток)
                    case 2:
                        ChessboardCell a5 = new ChessboardCell();
                        ChessboardCell a6 = new ChessboardCell(5, 8, ChessboardCell.Color.black);
                        ChessboardCell a7 = !a5;
                        ChessboardCell a8 = !a6;
                        Console.WriteLine(a7.Show());
                        Console.WriteLine(a8.Show());
                        Console.WriteLine("==========================");
                        break;

                    //Явное преобразование (сумма координат клетки)
                    case 3:
                        ChessboardCell a9 = new ChessboardCell();
                        ChessboardCell a10 = new ChessboardCell(5, 5, ChessboardCell.Color.black);
                        Console.WriteLine("Явное преобразование первого объекта = " + (int)a9);
                        Console.WriteLine("Явное преобразование второго объекта = " + (int)a10);
                        Console.WriteLine("==========================");
                        break;

                    //Неявное преобразование (цвет клетки)
                    case 4:
                        ChessboardCell a11 = new ChessboardCell();
                        ChessboardCell a12 = new ChessboardCell(5, 5, ChessboardCell.Color.black);
                        Console.WriteLine("Цвет клетки: " + a11);
                        Console.WriteLine("Цвет клетки: " + a12);
                        Console.WriteLine("==========================");
                        break;

                    //Бинарные операции (сравнение)#1
                    case 5:
                        ChessboardCell a13 = new ChessboardCell();
                        ChessboardCell a14 = new ChessboardCell(5, 5, ChessboardCell.Color.black);
                        Console.WriteLine($"Перемещение коня: {a13 == a14}");
                        Console.WriteLine("==========================");
                        break;

                    //Бинарные операции (сравнение)#2
                    case 6:
                        ChessboardCell a15 = new ChessboardCell();
                        ChessboardCell a16 = new ChessboardCell(5, 5, ChessboardCell.Color.black);
                        Console.WriteLine($"Фигуры находятся на разных вертикалях доски? {a15 != a16}");
                        Console.WriteLine("==========================");
                        break;

                    //Функция сравнения объектов (Equals)
                    case 7:
                        ChessboardCell a17 = new ChessboardCell();
                        ChessboardCell a18 = new ChessboardCell(5, 5, ChessboardCell.Color.black);
                        Console.WriteLine(a17.Equals(a18));
                        break;

                    // Создать массив ChessboardCellArray
                    case 8:
                        Console.WriteLine("Выберите способ создания массива:");
                        Console.WriteLine("1. Ручной ввод значений");
                        Console.WriteLine("2. Генерация случайных значений");

                        if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
                        {
                            Console.WriteLine("Введите размер массива:");
                            if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
                            {
                                array = new ChessboardCellArray(size);

                                switch (choice)
                                {
                                    case 1: // Ручной ввод
                                        for (int i = 0; i < size; i++)
                                        {
                                            Console.WriteLine($"Введите данные для клетки {i + 1}:");

                                            Console.Write("Горизонтальная координата: ");
                                            int h = int.Parse(Console.ReadLine());

                                            Console.Write("Вертикальная координата: ");
                                            int v = int.Parse(Console.ReadLine());

                                            Console.Write("Цвет клетки (white/black): ");
                                            Enum.TryParse(Console.ReadLine(), out ChessboardCell.Color color);

                                            array[i] = new ChessboardCell(h, v, color);
                                        }

                                        Console.WriteLine("Массив заполнен вручную:");
                                        array.Print();
                                        break;

                                    case 2: // Случайная генерация
                                        Random rand = new Random();
                                        for (int i = 0; i < size; i++)
                                        {
                                            int h = rand.Next(1, 9);  // Горизонтальная координата от 1 до 8
                                            int v = rand.Next(1, 9);  // Вертикальная координата от 1 до 8
                                            ChessboardCell.Color color = (rand.Next(2) == 0) ? ChessboardCell.Color.white : ChessboardCell.Color.black;

                                            array[i] = new ChessboardCell(h, v, color);
                                        }

                                        Console.WriteLine("Массив заполнен случайными значениями:");
                                        array.Print();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректное значение размера массива.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор.");
                        }
                        break;

                    // Вывести элементы массива
                    case 9:
                        if (array == null)
                        {
                            Console.WriteLine("Массив не создан.");
                        }
                        else
                        {
                            Console.WriteLine("Элементы массива:");
                            array.Print();
                        }
                        break;

                    // Скопировать массив (глубокое копирование)
                    case 10:
                        if (array == null)
                        {
                            Console.WriteLine("Массив не создан.");
                        }
                        else
                        {
                            ChessboardCellArray copiedArray = new ChessboardCellArray(array);
                            Console.WriteLine("Массив скопирован (глубокое копирование).");
                            Console.WriteLine("Элементы скопированного массива:");
                            copiedArray.Print();
                        }
                        break;

                    // Работа с индексатором
                    case 11:
                        if (array == null)
                        {
                            Console.WriteLine("Массив не создан.");
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine("Введите индекс для доступа:");
                                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < array.Length)
                                {
                                    Console.WriteLine($"Элемент с индексом {index}: {array[index].Show()}");

                                    Console.WriteLine("Введите новые координаты и цвет для записи (горизонталь, вертикаль, цвет):");

                                    if (int.TryParse(Console.ReadLine(), out int h) &&
                                        int.TryParse(Console.ReadLine(), out int v) &&
                                        Enum.TryParse<ChessboardCell.Color>(Console.ReadLine(), out ChessboardCell.Color color))
                                    {
                                        array[index] = new ChessboardCell(h, v, color);
                                        Console.WriteLine("Элемент изменен.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Неверный индекс.");
                                }
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    // Найти ближайшую клетку к левому нижнему углу
                    case 12:
                        if (array == null)
                        {
                            Console.WriteLine("Массив не создан.");
                        }
                        else
                        {
                            ChessboardCell closestCell = FindClosestCell(array);
                            Console.WriteLine("Самая близкая клетка к левому нижнему углу:");
                            Console.WriteLine(closestCell.Show());
                        }
                        break;

                    // Завершение работы
                    case 13:
                        Console.WriteLine("Завершение работы");
                        break;
                }

            } while (answer2 != 13);
        }
        #endregion

        // Функция для поиска самой близкой клетки к левому нижнему углу
        static ChessboardCell FindClosestCell(ChessboardCellArray array)
        {
            ChessboardCell closestCell = array[0];
            int minDistance = closestCell.Horizontal + closestCell.Vertical;

            for (int i = 1; i < array.Length; i++)
            {
                int distance = array[i].Horizontal + array[i].Vertical;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCell = array[i];
                }
            }

            return closestCell;
        }

        static void Main(string[] args)
        {
            FirstStage();
            SecondStage();
        }
    }
}
