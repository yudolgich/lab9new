namespace ООП
{
    #region 1 часть
    public class ChessboardCell
    {
        public enum Color //Используем перечисляемый тип enum для считывания цвета
        {
            black,
            white
        }

        public int horizontal; //Поля(переменные)
        public int vertical;
        static int count;
        public Color color;

        private static readonly Random rand = new Random();

        public ChessboardCell()
        {
            Horizontal = rand.Next(1, 9);
            Vertical = rand.Next(1, 9);
            count++;
        }

        public ChessboardCell(ChessboardCell cell) //Конструктор с параметром
        {
            Horizontal = cell.Horizontal;
            Vertical = cell.Vertical;
            color = (Horizontal + Vertical) % 2 == 0 ? Color.black : Color.white;
            count++;
        }

        public ChessboardCell(int horizontal, int vertical, Color color) //Конструктор с параметрами
        {
            Horizontal = horizontal;
            Vertical = vertical;
            this.color = (Horizontal + Vertical) % 2 == 0 ? Color.black : Color.white;
            count++;
        }

        public int Horizontal //Свойства для числа Horizontal
        {
            get => horizontal;
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Выход за пределы ограничений (число от 1 до 8)");
                }
                horizontal = value;
            }
        }

        public int Vertical //Свойства для числа Vertical
        {
            get => vertical;
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Выход за пределы ограничений (число от 1 до 8)");
                }
                vertical = value;
            }
        }

        public static int GetCount() => count; //Функция для подсчета количества объектов

        public string Show() //Функция для вывода на консоль
        {
            return $"Вертикаль: {Vertical}, горизонталь: {Horizontal}, цвет: {color}";
        }

        public static bool ColorComparison1(ChessboardCell cell1, ChessboardCell cell2) //Статическая функция для сравнения цвета клеток
        {
            return cell1.color == cell2.color;
        }

        public bool ColorComparison2(ChessboardCell cell1, ChessboardCell cell2) //Метод класса для сравнения цвета клеток
        {
            return cell1.color == cell2.color;
        }
        #endregion

        public static ChessboardCell operator ++(ChessboardCell cell) //Перегрузка унарной операции (инкремент)
        {
            return new ChessboardCell(cell.Horizontal ++ , cell.Vertical ++ , cell.color);
        }

        public static ChessboardCell operator !(ChessboardCell cell) //Перегрузка операции (смена клеток)
        {
            if (cell.Horizontal != cell.Vertical)
            {
                return new ChessboardCell(9 - cell.Vertical, 9 - cell.Horizontal, Color.black);
            }
            return cell;
        }

        public static explicit operator int(ChessboardCell cell) //Явное преобразование (цвет клетки)
        {
            return cell.Horizontal + cell.Vertical;
        }

        public static implicit operator string(ChessboardCell cell) //Неявное преобразование (цвет клетки)
        {
            if ((cell.Horizontal + cell.Vertical) % 2 == 0)
            {
                return Color.black.ToString();
            }
            else
            {
                return Color.white.ToString();
            }
        }

        //Бинарные операции (сравнение)#1
        public static bool operator ==(ChessboardCell cell1, ChessboardCell cell2)
        {
            int deltaX = Math.Abs(cell1.Horizontal - cell2.Horizontal);
            int deltaY = Math.Abs(cell1.Vertical - cell2.Vertical);
            return (deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2);
        }

        //Бинарные операции (сравнение)#2
        public static bool operator !=(ChessboardCell cell1, ChessboardCell cell2)
        {
            return cell1.Vertical != cell2.Vertical;
        }

        //Функция сравнения объектов (Equals)
        public override bool Equals(object obj)
        {
            // Проверка на null и тип объекта
            if (obj == null || !(obj is ChessboardCell))
            {
                return false;
            }

            ChessboardCell cell = (ChessboardCell)obj;

            // Сравнение координат и цвета клетки
            return Horizontal == cell.Horizontal && Vertical == cell.Vertical && color == cell.color;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Horizontal.GetHashCode();
            hash = hash * 23 + Vertical.GetHashCode();
            hash = hash * 23 + color.GetHashCode();
            return hash;
        }
    }
}