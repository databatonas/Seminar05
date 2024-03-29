﻿// Задача 37.
/*Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент,
  второй и предпоследний и т.д. Результат запишите в новом массиве. Например:
[1 2 3 4 5] -> 5 8 3
[6 7 3 6] -> 36 21*/

try /* Блок обработки исключений.*/
{
    Console.WriteLine("Введите число количества элементов требуемого массива.");
    Console.WriteLine("Число должно быть целым и положительным.");
    int number = Convert.ToInt32(Console.ReadLine());

    decimal[] array = new decimal[number];/*Создаем массив и укажем, что в нем (number) элементов.
    Формат decimal: хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет
    значение от ±1.0*10-28 до ±7.9228*1028, может хранить 28 знаков после запятой.*/
    decimal[] array2 = new decimal[array.Length];
    if (number == 0) /* Если число количества элементов требуемого массива рано нулю, то...*/
    {
        Console.WriteLine("В массиве нет элементов"); /* выводим на экран "В массиве нет элементов".*/
        return; /* Возвращаемся на исходную точку.*/
    }

    fillArray(array);     /*Вызываем метод заполнения массива,который мы описали ниже, 
                            с наименованием созданного массива (array). */
    printArray(array);    /*Вызываем метод вывода на печать, который мы описали ниже, 
                            с наименованием созданного массива (array) */
    composition(array2);  /*Вызываем метод произведения пар чисел и записи их в новый массив.*/

    // Метод заполнения массива.
    void fillArray(decimal[] array, int from = 0, int to = 0) /*void-оператор, который ни чего не возвращает.
 FillArray (перевод-заполняющий массив)- наименование метода . array (перевод- массив)- аргумент (любое слово), from (перевод- от)-
 начало диапозона заполнения массива, to (перевод- до)- конец диапозона заполнения массива.*/
    {
        Console.WriteLine("Введите целое число начала диапозона требуемого массива.");
        from = Convert.ToInt32(Console.ReadLine()); /* Вывод на экран переменной from.*/
        Console.WriteLine("Введите целое число конца диапозона требуемого массива.");
        to = Convert.ToInt32(Console.ReadLine()); /* Вывод на экран переменной to.*/
        Console.WriteLine(); /* Пустая строка для отделения от ответа при чтении на экране.*/

        if (from > to) (from, to) = (to, from); /* Если число начала диапозона больше
    числа окончания диапозона, то поменяем их местами.*/

        for (int i = 0; i < array.Length; i++) /* Вводим переменную (i)- это позиция первого элемента массива.
    До тех пор, пока позиция элемента массива меньше длины массива, увеличиваем значение позиции 
    элемента на (1) при каждой итерации.  */
        {
            array[i] = new Random().Next(from, to + 1); /* Заполняем наш массив случайными числами
        от (from) до (to). Увеличиваем переменную конца диапозона случайных чисел на (1) так как, 
        Random().Next(from, to) не включает последнюю цифру в диапозон.*/
        }
    }

    // Метод печати массива на экран.
    void printArray(decimal[] array)  /* PrintArray-печать массива. */
    {
        for (int i = 0; i < array.Length; i++) /* Вводим переменную (i)- это позиция первого элемента массива.
    До тех пор, пока позиция элемента массива меньше длины массива, увеличиваем значение позиции элемента
    на (1) при каждой итерации. */
        {
            if (i == 0) Console.Write($"["); /* Если индекс элемента раве нулю, т.е. (первый элемент массива),
        то на экран, сначала, выводим левую квадратную скобку.*/

            Console.Write($"{array[i]} ");/*Выводим на экран, в одну строку, через пробел,все элементы массива.*/

            if (i < array.Length - 1) Console.Write($", "); /* Если индекс элемента меньше длины 
        массива минус один, т.е. (последнего элемента массива), то ставим запятую.*/

            if (i == array.Length - 1) Console.Write($"]"); /* Если индекс элемента равен длине 
        массива минус один, т.е. (последнему элементу массива), то ставим правую квадратную скобку.*/
        }
        Console.WriteLine(); /* Пустая строка для перехода на новую строку для вывода следующего ответа.*/
    }

    /* Метод произведения пар чисел из одного массива и записи их в новый массив.*/
    void composition(decimal[] array2)
    {
        decimal composition = 0; /* Вводим переменную (composition)- это будет произведение пары чисел.*/

        int n = array.Length; /* Присвоим переменной (n) длину получившегося массива.*/
        /*(n - 1) Индекс последнего элемента массива.*/

        int k = (int)n / 2;   /* Примем переменную (к) равной целой части от половины длины массива.*/
        int count = 0;        /* Индекс нового массива, который получим в процессе цикла (while).*/

        for (int i = 0; i < array.Length; i++) /* Вводим переменную (i)- это позиция первого элемента,
    созданного ранее, массива. До тех пор, пока позиция элемента массива меньше длины массива, 
    увеличиваем значение позиции элемента на (1) при каждой итерации. */
        {
            while (count < k) /* До тех пор, индекс меньше целой части от половины длины массива...*/
            {
                if (n % 2 == 0) /* Если длина массива есть число чётное, то...*/
                {
                    composition = array[count] * array[n - count - 1]; /* Будем считать произведение пар 
                чисел (первого и последнего, второго и предпоследнего и т.д.), постепенно приближаясь
                к центру массива...*/
                    count++; /* путем увеличивания, после каждой итерации, индекса элемента на единицу.*/

                    array2 = array.Concat(new decimal[] { composition }).ToArray();/* Добавление чисел в 
                                                                                      новый массив массив.*/
                    Console.Write($"{composition} ");/*Вывод на экран произведения пар чисел через пробел.*/
                }
                else if (n % 2 > 0) /* Иначе, если длина массива число не чётное, то...*/
                {
                    composition = array[count] * array[n - count - 1]; /* Будем считать произведение пар 
                чисел (первого и последнего, второго и предпоследнего и т.д.), постепенно приближаясь
                к центру массива...*/
                    count++; /* путем увеличивания, после каждой итерации, индекса элемента на единицу.*/

                    array2 = array.Concat(new decimal[] { composition }).ToArray();/* Добавление чисел в 
                                                                                      новый массив массив.*/
                    Console.Write($"{composition} ");/*Вывод на экран произведения пар чисел через пробел.*/

                    if (count == k) /* Если, в процессе переборки массива, индекс элемента стал равным 
                                       целой части от половины длины массива, то...*/
                    {
                        composition = array[k];/*переменной (composition) присваиваем значение центрального
                                                 элемента массива (которому не нашлась пара).*/
                        array2 = array.Concat(new decimal[] { composition }).ToArray();/* Добавляем число 
                                                                                          в новый массив.*/
                        Console.Write($"{composition} "); /* Вывод на экран произведения пар чисел 
                                                             через пробел.*/
                    }
                }
            }
        }
    }
}
catch /* Окончание блока обработки исключений.*/
{
    Console.WriteLine("Некорректный ввод данных.");
}