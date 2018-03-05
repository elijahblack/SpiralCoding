using System;

namespace SpiralCoding
{
    class Program
    {
        /// <summary>
        /// Класс точки на плоскости
        /// </summary>
        internal class Point
        {
            private int x;
            private int y;

            /// <summary>
            /// Конструктор класса точки на плоскости
            /// </summary>
            /// <param name="x"> Координата X </param>
            /// <param name="y"> Координата Y </param>
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            /// <summary>
            /// Метод итерации выбранной переменной на выбранный коэффициент
            /// </summary>
            /// <param name="coord"> Переменная оси </param>
            /// <param name="d"> Коэффициент итерации </param>
            public void Add(char coord, int d)
            {
                if (coord == 'x')
                    x += d;
                else
                if (coord == 'y')
                    y += d;
            }

            /// <summary>
            /// Координата X
            /// </summary>
            public int X { get => x; set => x = value; }

            /// <summary>
            /// Координата Y
            /// </summary>
            public int Y { get => y; set => y = value; }
        }

        /// <summary>
        /// Класс, который мне захотелось сделать, он удобный
        /// </summary>
        internal class Code
        {
            /// <summary>
            /// Массив строковых представлений методов шифрования
            /// </summary>
            internal static string[] codes = new string[8]
            {
                "y+ x-",
                "y+ x+",
                "y- x+",
                "y- x-",
                "x+ y-",
                "x+ y+",
                "x- y+",
                "x- y-"
            };

            /// <summary>
            /// Возвращает символьное значение переменной первой операции
            /// </summary>
            /// <param name="c"> Строковое представление кода </param>
            /// <returns> Возвращает символьное значение переменной первой операции </returns>
            internal static char GetFirstOperator(string c)
            {
                return c.ToCharArray()[0];
            }

            /// <summary>
            /// Возвращает массив отклонений первых двух операций шифрования
            /// </summary>
            /// <param name="code"> Строковое представление кода </param>
            /// <returns> Возвращает массив отклонений первых двух операций шифрования </returns>
            internal static int[] GetDeviation(string code)
            {
                int[] d = new int[2];

                // парсинг строчной записи "способов шифрования"
                d[0] = code.ToCharArray()[1] == '+' ? 1 : -1;
                d[1] = code.ToCharArray()[4] == '+' ? 1 : -1;

                firstD = d; // запись первых отклонений, для последуйщего дешифрования

                return d;
            }

            /// <summary>
            /// Обращает значения отклонений
            /// </summary>
            /// <param name="d"> Массив отклонений </param>
            internal static void Reverse(int[] d)
            {
                d[0] = d[0] < 0 ? 1 : -1;
                d[1] = d[1] < 0 ? 1 : -1;
            }
        }

        /// <summary>
        /// Класс инициализации массива
        /// </summary>
        internal class Init
        {
            /// <summary>
            /// Запуск инициализации
            /// </summary>
            internal static void Start()
            {
                array = new string[N, N];
                originalText = "";
                switch (initType)
                {
                    case "index":
                        Init.Index();
                        break;
                    case "simbols":
                        Init.Simbols();
                        break;
                    case "text":
                        Init.Text();
                        break;
                    default: break;
                }
            }

            /// <summary>
            /// Инициализация массива индексов
            /// </summary>
            static void Index()
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = "[" + i + " " + j + "]";
                        originalText += "[" + i + " " + j + "]";
                    }
                }
            }

            /// <summary>
            /// Инициализация массива символов
            /// </summary>
            static void Simbols()
            {
                char a = '0';
                int count = 0;

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (count % 74 == 0)
                            a = '0';
                        array[i, j] = a.ToString();
                        originalText += a.ToString();
                        a++;
                        count++;
                    }
                }
            }

            /// <summary>
            /// Инициализация массива текста
            /// </summary>
            static void Text()
            {
                string str = "Against that time, if ever that time come, " +
                                "When I shall see thee frown on my defects, " +
                                "When as thy love hath cast his utmost sum, " +
                                "Called to that audit by advis'd respects; " +
                                "" +
                                "Against that time when thou shalt strangely pass, " +
                                "And scarcely greet me with that sun, thine eye, " +
                                "When love, converted from the thing it was, " +
                                "Shall reasons find of settled gravity; " +
                                "" +
                                "Against that time do I ensconce me here, " +
                                "Within the knowledge of mine own desert, " +
                                "And this my hand, against my self uprear, " +
                                "To guard the lawful reasons on thy part: " +
                                "" +
                                "To leave poor me thou hast the strength of laws," +
                                "Since why to love I can allege no cause. ";
                int a = 0;

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = str.ToCharArray()[a].ToString();
                        originalText += str.ToCharArray()[a].ToString();
                        a++;
                    }
                }
            }
        }

        /// <summary>
        /// Класс, обеспечивающий диалог с пользователем
        /// </summary>
        internal class Dialog
        {
            /* Массив типов инициализации
            *  С массивом их проще добавлять
            *  Просто добавляешь запись в массив, остальное (большей частью) добавляется само */
            static string[] initTypeArray =
            {
                "Индексы (удобно для тестирования)",
                "Упорядоченные символы (текст для ленивых)",
                "Текст (фрагмент)"
            };

            /// <summary>
            /// Запуск диалога
            /// </summary>
            internal static void Start()
            {
                SetArrayLength();
                SetEncodeMethod();
                SetInitType();
            }

            /// <summary>
            /// Установка размерности массива
            /// </summary>
            static void SetArrayLength()
            {
                Console.Write("Введите размер матрицы: ");
                N = Int32.Parse(Console.ReadLine());

                // Этот кусок кода будет парить мозг, пока не введёшь нормальное значение
                if ((N % 2 == 0) || N < 3)
                {
                    while ((N % 2 == 0) || N < 3)
                    {
                        Console.Write("Неверный размер матрицы! \n");
                        Console.Write("Введите другое значение: ");
                        N = Int32.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();
            }

            /// <summary>
            /// Установка метода шифрования
            /// </summary>
            static void SetEncodeMethod()
            {
                int type = 0;
                Console.Write("Отлично! \nА теперь выберите способ шифрования: \n\n");
                for (int i = 0; i < Code.codes.Length; i++)
                    Console.Write("[" + (i + 1) + "]  " + "[" + Code.codes[i] + "]\n");
                Console.WriteLine();
                Console.Write("Выбранный способ шифрования определяет первые два шага формирования спирали. \n");
                Console.Write("Введите номер: ");
                type = Int32.Parse(Console.ReadLine()) - 1;

                // Этот кусок кода будет парить мозг, пока не введёшь нормальное значение
                if (type < 0 || type > 7)
                {
                    while (type < 0 || type > 7)
                    {
                        Console.Write("Неверный номер! \n");
                        Console.Write("Введите другой номер: ");
                        type = Int32.Parse(Console.ReadLine()) - 1;
                    }
                }
                Console.WriteLine();

                firstCoord = Code.GetFirstOperator(Code.codes[type]);
                d = Code.GetDeviation(Code.codes[type]);
                code = Code.codes[type];
            }

            /// <summary>
            /// Установка типа инициализации массива
            /// </summary>
            static void SetInitType()
            {
                int init = 0;
                Console.Write("Осталось совсем чуть-чуть. \n");
                Console.Write("Выберите тип массива: \n");
                Console.WriteLine();
                for (int i = 0; i < initTypeArray.GetLength(0); i++)
                    Console.Write("[" + (i + 1) + "]  " + initTypeArray[i] + "\n");
                //Console.Write("[1]  Индексы (удобно для тестирования) \n");
                //Console.Write("[2]  Упорядоченные символы (текст для ленивых) \n");
                //Console.Write("[3]  Текст (фрагмент) \n");
                Console.WriteLine();
                Console.Write("Введите номер типа массива: ");
                init = Int32.Parse(Console.ReadLine());

                // Этот кусок кода будет парить мозг, пока не введёшь нормальное значение
                if (init < 1 || init > initTypeArray.GetLength(0))
                {
                    while (init < 1 || init > initTypeArray.GetLength(0))
                    {
                        Console.Write("Неверный номер! \n");
                        Console.Write("Введите другой номер: ");
                        init = Int32.Parse(Console.ReadLine());
                    }
                }

                switch (init)
                {
                    case 1:
                        initType = "index";
                        break;
                    case 2:
                        initType = "simbols";
                        break;
                    case 3:
                        initType = "text";
                        break;
                    default: break;
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Шифрование
        /// </summary>
        internal class Encode
        {
            /// <summary>
            /// Метод шифрования
            /// </summary>
            /// <param name="array"> Шифруемый массив </param>
            /// <returns> Возвращает шифрованную строку </returns>
            internal static string Start()
            {
                char secondCoord = firstCoord == 'x' ? 'y' : 'x';
                Point c = new Point(N / 2, N / 2); // координата центра
                string str = "";

                str += array[c.X, c.Y]; // записывает центральное значение

                for (int i = 1; i <= (N - 1); i++) // магия делает бочку (спираль)
                {
                    str += MagicEncode(c, firstCoord, d[0], i) + MagicEncode(c, secondCoord, d[1], i);
                    Code.Reverse(d);

                }
                str += MagicEncode(c, firstCoord, d[0], (N - 1)); // добавляет в строку финишную прямую

                return str;
            }

            /// <summary>
            /// Магия шифрований
            /// </summary>
            /// <param name="array"> Шифруемый ассив </param>
            /// <param name="c"> Точка </param>
            /// <param name="coord"> Обрабатываемая координатная ось </param>
            /// <param name="d"> Отклонение координаты по выбранной оси </param>
            /// <param name="n"> Количество циклов магии </param>
            /// <returns> Возвращает кусок строки, познавшей магию шифрования </returns>
            static string MagicEncode(Point c, char coord, int d, int n)
            {
                string temp = "";

                for (int i = 0; i < n; i++)
                {
                    c.Add(coord, d);
                    temp += array[c.X, c.Y];
                }

                return temp;
            }
        }

        /// <summary>
        /// Дешифрование
        /// </summary>
        internal class Decode
        {
            /// <summary>
            /// Метод дешифрований
            /// </summary>
            /// <param name="text"> Дешифруемый текст </param>
            /// <returns> Дешифрованный текст </returns>
            internal static string Start(string text)
            {
                char[] encodeArray = text.ToCharArray();    // зашифрованный массив
                string[] encodeString = new string[encodeArray.Length];  // исправляет косяким с массивом индексов
                string[,] decodeArray = new string[N, N];   // расшифрованный массив
                firstCoord = Code.GetFirstOperator(code);   // заново получаем первую координатную ось спирали
                d = Code.GetDeviation(code);                //                             и первые приращения
                char secondCoord = firstCoord == 'x' ? 'y' : 'x';   // логическим ображом получаемм вторую ось
                Point c = new Point(N / 2, N / 2);          // координата центра
                string str = "";
                string temp = text;

                // тут исправляется косяк, порожденный моей ленью
                if (initType == "index")
                {
                    encodeString = new string[N * N];

                    for (int i = 0; i < (N * N); i++)
                    {
                        /* Так как я ленивый, я добавил удобный для тестирования вариант массива с элементами вида "[x y]" 
                         * Отсюда потекли проблемы. В частности, при посимвольном шифровании, 
                         *      каждый элемент шифрованной строки является элементом исходной строки (один элемент - один символ, просто). 
                         * А в случае с индексами, каждый элемент состоит минимум из 5 символов (один элемент - несколько символов, не надо так), 
                         *      где каждый элемент начинается с "[" и заканчивается на "]" 
                         */
                        encodeString[i] = temp.Substring(0, temp.IndexOf(']') + 1);     // Метод  Substring(i, j) возвращает j элементов строки, начиная с i
                                                                                        //      "[" искать нет смысла, этот символ всегда первый
                                                                                        //      А IndexOf(char) возвращает индекс первого вхождения char в строку
                        temp = temp.Remove(0, temp.IndexOf(']') + 1);                   // Метод Remove(i, j) возвращает строку, 
                                                                                        //      в которой было удалено j символов, начиная с i
                    }
                }
                else
                {
                    for (int i = 0; i < (N * N); i++)
                    {
                        // Тот же фокус, что и в IF выше, но по одному элементу
                        encodeString[i] = temp.Substring(0, 1);
                        temp = temp.Remove(0, 1);
                    }
                }



                int index = 0;

                decodeArray[c.X, c.Y] = encodeString[index];
                index++;

                Code.Reverse(d);

                for (int i = 0; i <= (N - 1); i++)
                {
                    index = MagicDecode(decodeArray, encodeString, index, c, firstCoord, d[0], i);
                    index = MagicDecode(decodeArray, encodeString, index, c, secondCoord, d[1], i);
                    Code.Reverse(d);

                }

                MagicDecode(decodeArray, encodeString, index, c, firstCoord, d[0], (N - 1));


                /////////////////////////////////////////////////////////////////////
                //Console.WriteLine();
                //Console.Write("Какой-то массив: \n");
                //for (int i = 0; i < decodeArray.GetLength(0); i++)
                //{
                //    for (int j = 0; j < decodeArray.GetLength(1); j++)
                //    {
                //        Console.Write(decodeArray[i, j] + "  ");
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine();
                /////////////////////////////////////////////////////////////////////////


                // Собирает построенный расшифрованный массив в строку
                str += ArrayToString(decodeArray);

                return str;
            }

            /// <summary>
            /// Магия дешифрования
            /// </summary>
            /// <param name="decodeArray"> Дешифрованный массив </param>
            /// <param name="encodeString"> Шифрованный массив </param>
            /// <param name="index"> Индекс элемента шифрованного массива </param>
            /// <param name="c"> Точка </param>
            /// <param name="coord"> Обрабатываемая координатная ось </param>
            /// <param name="d"> Отклонение координаты по выбранной оси </param>
            /// <param name="n"> Количество циклов магии </param>
            /// <returns> Возвращает индекс шифрованного массива, чтобы не ломать порядок </returns>
            static int MagicDecode(string[,] decodeArray, string[] encodeString, int index, Point c, char coord, int d, int n)
            {
                for (int j = 0; j < n; j++)
                {
                    c.Add(coord, d);
                    decodeArray[c.X, c.Y] = encodeString[index];
                    index++;
                }
                return index;
            }
        }


        static string initType = "null";
        static string code = "";
        static char firstCoord = 'y';
        static int[] firstD = new int[2];
        static int[] d = new int[2];

        static string originalText = "";
        static string[,] array;
        static int N = 0;


        static void Main()
        {
            Dialog.Start();
            Init.Start();


            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Ну что, погнали! \n");
            Console.WriteLine();
            Console.Write("Шифруемый текст: \n");
            Console.WriteLine();
            Console.Write(ArrayToString(array));
            Console.WriteLine();
            Console.WriteLine();

            Show();
            Console.WriteLine();

            Console.Write("Зашифрованный текст: \n");
            string text = Encode.Start();
            Console.Write(text.Replace("][", "] ["));
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Расшифрованный текст: \n");
            Console.Write(Decode.Start(text));

            Console.ReadKey();
        }

        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param name="array"> Выводимый массив </param>
        static void Show()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Преобразование массива в строку
        /// </summary>
        /// <param name="array"> Массив </param>
        /// <returns> Строка </returns>
        static string ArrayToString(string[,] array)
        {
            string temp = "";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    temp += array[i, j];
                }
            }

            return temp;
        }
    }
}
