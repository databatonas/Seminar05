﻿// Задача 36.
/* Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, 
   стоящих на нечётных позициях.*/

try /* Блок обработки исключений.*/
{
    Console.WriteLine("Введите число количества элементов требуемого массива.");
    Console.WriteLine("Число должно быть целым и положительным.");
    int number = Convert.ToInt32(Console.ReadLine());

    decimal[] array = new decimal[number];/*Создаем массив и укажем, что в нем (number) элементов.
    Формат decimal: хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет
    значение от ±1.0*10-28 до ±7.9228*1028, может хранить 28 знаков после запятой.*/

    if (number == 0) /* Если число количества элементов требуемого массива рано нулю, то...*/
    {
        Console.WriteLine(" Массив не содержит элементов"); /* выводим на экран "В массиве нет элементов".*/
        return;                                             /* Возвращаемся на исходную точку.*/
    }

    fillArray(array);     /*Вызываем метод заполнения массива,который мы описали ниже, 
                            с наименованием созданного массива (array). */
    printArray(array);    /*Вызываем метод вывода на печать, который мы описали ниже, 
                            с наименованием созданного массива (array) */
    SumOdd(array);        /*Вызываем метод определения суммы элементов, стоящих на нечётных позициях в 
                          массиве (array), который мы описали ниже.*/

    // Метод заполнения массива.
    void fillArray(decimal[] array, int from = 0, int to = 0) /*void-оператор, который ни чего не 
    возвращает. FillArray (перевод-заполняющий массив)- наименование метода . array (перевод- массив)-
    аргумент (любое слово), from (перевод- от)- начало диапозона заполнения массива, 
    to (перевод- до)- конец диапозона заполнения массива.*/
    {
        Console.WriteLine("Введите целое число начала диапозона требуемого массива.");
        from = Convert.ToInt32(Console.ReadLine()); /* Вывод на экран переменной from.*/
        Console.WriteLine("Введите целое число конца диапозона требуемого массива.");
        to = Convert.ToInt32(Console.ReadLine()); /* Вывод на экран переменной to.*/
        Console.WriteLine(); /* Пустая строка для отделения от ответа при чтении на экране.*/

        if (from > to) (from, to) = (to, from); /* Если число начала диапозона больше числа 
                                                   окончания диапозона, то поменяем их местами.*/

        for (int i = 0; i < array.Length; i++) /*Вводим переменную (i)- это позиция первого 
        элемента массива. До тех пор, пока позиция элемента массива меньше длины массива, 
        увеличиваем значение позиции элемента на (1) при каждой итерации.  */
        {
            array[i] = new Random().Next(from, to + 1); /* Заполняем наш массив случайными числами
        от (from) до (to). Увеличиваем переменную конца диапозона случайных чисел на (1) так как, 
        Random().Next(from, to) не включает последнюю цифру в диапозон.*/
        }
    }

    // Метод печати массива на экран.
    void printArray(decimal[] array)  /* PrintArray-печать массива. */
    {
        for (int i = 0; i < array.Length; i++) /* Вводим переменную (i)- это позиция первого элемента 
        массива. До тех пор, пока позиция элемента массива меньше длины массива, увеличиваем значение 
        позиции элемента на (1) при каждой итерации. */
        {
            if (i == 0) Console.Write($"[");   /* Если индекс элемента раве нулю, т.е. 
            (первый элемент массива), то на экран, сначала, выводим левую квадратную скобку.*/

            Console.Write($"{array[i]} ");     /*Выводим на экран, в одну строку, через пробел,все элементы
                                                 массива.*/

            if (i < array.Length - 1) Console.Write($", "); /* Если индекс элемента меньше длины 
            массива минус один, т.е. (последнего элемента массива), то ставим запятую.*/

            if (i == array.Length - 1) Console.Write($"]"); /* Если индекс элемента равен длине 
        массива минус один, т.е. (последнему элементу массива), то ставим правую квадратную скобку.*/
        }
        Console.WriteLine(); /* Пустая строка для перехода на новую строку для вывода следующего ответа.*/
    }

    /* 1 Метод определения суммы  элементов, стоящих на нечётных позициях массива (array).*/
    void SumOdd(decimal[] array)
    {
        decimal sum = 0; /* Вводим переменную (sum)- это счётчик суммы элементов, стоящих на нечётных 
                            позициях, которые требуется подсчитать.*/

        for (int i = 1; i < array.Length; i = i + 2) /* Вводим переменную (i) со значением первого 
        нечётного индекса (1) элемента массива . До тех пор, пока позиция элемента массива меньше
        длины массива, увеличиваем значение позиции элемента на (2)- чтобы, снова, попасть на 
        нечётный индекс, при каждой итерации. */
        {
            sum = sum + array[i]; /* При каждой итерации суммируем очередной элемент, стоящий 
                                     на нечётной позиции с прошлым результатом суммы.*/
        }
        Console.WriteLine(); /* Пустая строка для перехода на новую строку для вывода следующего ответа.*/
        Console.WriteLine($"Сумма элементов, стоящих на нечётных позициях массива, равна {sum}.");
    }
}
catch /* Окончание блока обработки исключений.*/
{
    Console.WriteLine("Некорректный ввод данных.");
}
