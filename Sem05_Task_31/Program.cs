﻿//Задача 31.
/* Задайте массив из (elements- элемент) элементов, заполненный случайными числами из промежутка
   [beginning-начало, end- конец]. Найдите сумму отрицательных и положительных элементов массива.
   Например, в массиве [3,9,-8,1,0,-7,2,-1,8,-3,-1,6] сумма положительных чисел равна 29, 
   сумма отрицательных равна -20.*/

int sumnegative = 0; /* Вводим переменную (sumnegative). В неё будем складывать сумму
                        отрицательных чисел массива.*/

int sumpositive = 0; /* Вводим переменную (sumpositive). В неё будем складывать сумму                      
                        положительных чисел массива.*/

/* Создаем массив (он сейчас на 80 строке) и сверху пишем методы. */
// Метод 1
void FillArray(int[] collection) /*void-оператор, который ни чего не возвращает и значит, 
                                   что с ним не нужно использовать оператор return, который делает возврат.
                                   FillArray (перевод-заполняющий массив)- наименование метода .
                                   collection (перевод коллекция)- аргумент (любое слово). */
{
    Console.WriteLine("Введите целое число начала диапозона требуемого массива.");

    int beginning = Convert.ToInt32(Console.ReadLine()); /* beginning- начало.*/

    Console.WriteLine("Введите целое число конца диапозона требуемого массива.");

    int end = Convert.ToInt32(Console.ReadLine()); /* end- конец.*/

    Console.WriteLine(); /* Пустая строка для отделения от ответа при чтении на экране.*/

    if (beginning > end) (beginning, end) = (end, beginning); /* Если число начала диапозона больше
    числа окончания диапозона, то поменяем их местами.*/

    end = end + 1; /* Увеличиваем переменную конца диапозона случайных чисел на (1) так как, далее,
                      Random().Next(beginning,end) не включает последнюю цифру в диапозон.*/

    for (int index = 0; index < collection.Length; index++) /* Вводим переменную (index)- 
    это позиция первого элемента массива. До тех пор, пока позиция элемента массива меньше 
    длины массива, увеличиваем значение позиции элемента на (1) при каждой итерации. */
    {
        collection[index] = new Random().Next(beginning, end); /* Заполняем наш массив случайными числами
                                                             от (beginning) до (end), не включая (end).*/

        /* Если число из массива меньше нуля, то суммируем его с переменной sumnegative
           и присваиваем ей новое значение при каждой итерации, пока идёт цикл.*/
        if (collection[index] < 0) sumnegative = sumnegative + collection[index];

        else sumpositive = sumpositive + collection[index]; /* Иначе суммируем положительные числа с
        переменной sumpositive и присваиваем ей новое значение при каждой итерации, пока идёт цикл.*/
    }
}

// Метод печати массива на экран.
void PrintArray(int[] col)  /* PrintArray-печать массива. col- это какая-то другая переменная. */
{
    for (int index = 0; index < col.Length; index++) /* Вводим переменную (index)- это позиция первого
     элемента массива. До тех пор, пока позиция элемента массива меньше длины массива,
     увеличиваем значение позиции элемента на (1) при каждой итерации. */
    {
        if (index == 0) Console.Write($"["); /* Если индекс элемента раве нулю, 
        т.е. (первый элемент массива), то на экран, сначала, выводим левую квадратную скобку.*/

        Console.Write($"{col[index]} "); /* Выводим на экран, в одну строку, через пробел,
                                            все элементы массива.*/

        if (index < col.Length - 1) Console.Write($", "); /* Если индекс элемента меньше длины 
        массива минус один, т.е. (последнего элемента массива), то ставим запятую.*/

        if (index == col.Length - 1) Console.Write($"]"); /* Если индекс элемента равен длине 
        массива минус один, т.е. (последнему элементу массива), то ставим правую квадратную скобку.*/
    }

}

try /* Блок обработки исключений.*/
{
    Console.WriteLine("Введите число количества элементов требуемого массива.");
    Console.WriteLine("Число должно быть целым и положительным.");
    int number = Convert.ToInt32(Console.ReadLine());

    int[] array = new int[number];/*Создаем массив и укажем, что в нем (number) элементов.*/

    if (number == 0)
    {
        Console.WriteLine("В массиве нет элементов"); /* Если количество элементов массива
        равно нулю, то выводим на экран "В массиве нет элементов".*/
        return; /* Возвращаемся на исходную точку.*/
    }

    FillArray(array); /*Вызываем метод заполнения массива,который мы описали выше 
                    с наименованием созданного массива (array). */

    PrintArray(array); /*Вызываем метод вывода на печать, который мы описали выше 
                         с наименованием созданного массива (array) */

    Console.WriteLine(); /* Пустая строка для перехода на новую строку после вывода массива на экран.*/
    Console.WriteLine(); /* Пустая строка для отделения от ответа при чтении на экране.*/
    Console.WriteLine($"Сумма отрицательных чисел массива равна: {sumnegative}"); /* Вывод на экран 
    суммы отрицательных чисел массива.*/
    Console.WriteLine(); /* Пустая строка для отделения от ответа при чтении на экране.*/
    Console.WriteLine($"Сумма положительных чисел массива равна: {sumpositive}"); /* Вывод на экран 
    суммы положительных чисел массива.*/

}
catch /* Окончание блока обработки исключений.*/
{
    Console.WriteLine("Некорректный ввод данных.");
}