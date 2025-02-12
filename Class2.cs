using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП
{
    public class ChessboardCellArray
    {
        private ChessboardCell[] arr; //Одномерный массив элементов типа ChessboardCell
        private static int collectionCount = 0; //Счетчик созданных коллекций

        //Конструктор без параметров
        public ChessboardCellArray()
        {
            arr = new ChessboardCell[0];
            collectionCount++;
        }

        //Конструктор с параметрами, заполняющий элементы случайными значениями
        public ChessboardCellArray(int size)
        {
            arr = new ChessboardCell[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = new ChessboardCell(rand.Next(1, 9), rand.Next(1, 9), ChessboardCell.Color.black);
            }
            collectionCount++;
        }

        //Конструктор копирования (глубокое копирование)
        public ChessboardCellArray(ChessboardCellArray other)
        {
            arr = new ChessboardCell[other.arr.Length];
            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i] = new ChessboardCell(other.arr[i].Horizontal, other.arr[i].Vertical, other.arr[i].color);
            }
            collectionCount++;
        }

        public int Length
        {
            get { return arr.Length; }
        }

        //Метод для просмотра элементов массива
        public void Print()
        {
            foreach (var cell in arr)
            {
                Console.WriteLine(cell.Show());
            }
        }

        //Индексатор для доступа к элементам коллекции
        public ChessboardCell this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
                }
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
                }
                arr[index] = value;
            }
        }

        //Свойство для получения количества созданных коллекций
        public static int CollectionCount => collectionCount;
    }
}
