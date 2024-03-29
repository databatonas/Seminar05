﻿//Задача 35.
/* Задайте одномерный массив из 123 случайных чисел. Найдите количество элементов массива, 
   значения которых лежат в отрезке [10,99].
   Пример для массива из 5, а не 123 элементов. В своём решении сделайте для 123
   [5, 18, 123, 6, 2] -> 1
   [1, 2, 3, 6, 2] -> 0
   [10, 11, 12, 13, 14] -> 5*/

try /* Блок обработки исключений.*/
{
    decimal[] array = new decimal[123];/*Создаем массив и укажем, что в нем 123 элемента.
    Формат decimal: хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет
    значение от ±1.0*10-28 до ±7.9228*1028, может хранить 28 знаков после запятой.*/

    fillArray(array);     /*Вызываем метод заполнения массива,который мы описали ниже, 
                            с наименованием созданного массива (array). */

    numberElements(array); /*Вызываем метод определения количество элементов массива, 
                            значения которых лежат в отрезке [10,99]*/

    // Метод заполнения массива.
    void fillArray(decimal[] array) /*void-оператор, который ни чего не возвращает.
    FillArray (перевод-заполняющий массив)- наименование метода . array (перевод- массив)- 
    аргумент (любое слово).*/
    {
        for (int i = 0; i < array.Length; i++) /* Вводим переменную (i)- это позиция первого элемента
        массива. До тех пор, пока позиция элемента массива меньше длины массива, увеличиваем значение
        позиции элемента на (1) при каждой итерации.  */
        {
            array[i] = new Random().Next(-130, 130); /* Заполняем наш массив случайными числами
        от -130 до 129. Random().Next() не включает последнюю цифру в диапозон.*/
        }
    }

    /* 1 Метод определения количество элементов массива (array), значения которых лежат в отрезке [10,99].*/
    void numberElements(decimal[] array)
    {
        int count = 0; /* Вводим переменную (count)- это счётчик элементов, которые требуется подсчитать.*/

        for (int i = 0; i < array.Length; i++)/*Вводим переменную (i)- это позиция первого элемента массива.
        До тех пор, пока позиция элемента массива меньше длины массива, увеличиваем значение позиции
        элемента на (1) при каждой итерации. */
        {
            if (array[i] >= 10 && array[i] <= 99) /* Если элемент массива больше или
                                                    равен 10 и меньше или равен 99... */
            {
                count++; /* Увеличиваем счётчик на единицу после каждой итерации.*/
            }
        }
        Console.WriteLine($"Количество элементов массива (array), значения которых лежат"
                              + $" в отрезке от 10 до 99 равно {count} ."); /*Выводим на экран.*/
    }
}
catch /* Окончание блока обработки исключений.*/
{
    Console.WriteLine("Некорректный ввод данных.");
}