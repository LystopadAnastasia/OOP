using System;
using System.Text;

class Program
{
    // Константи
    const int MIN_COUNT = 1;
    const int MAX_COUNT = 100;

    const int MIN_VALUE = -1000000;
    const int MAX_VALUE = 1000000;

    // Метод введення числа з перевіркою
    static int ReadInt(string message, int min, int max)
    {
        int number;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number >= min && number <= max)
                {
                    return number;
                }
            }

            Console.WriteLine("Помилка! Некоректне значення.");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        bool continueProgram = true;

        while (continueProgram)
        {
            Console.WriteLine("========== ОДНОСПРЯМОВАНИЙ СПИСОК ==========\n");

            LinkedList list = new LinkedList();

            Console.WriteLine(
                $"Допустима кількість елементів: від {MIN_COUNT} до {MAX_COUNT}"
            );

            Console.WriteLine(
                $"Допустимі значення елементів: від {MIN_VALUE} до {MAX_VALUE}"
            );

            // Введення кількості елементів
            int n = ReadInt(
                "\nВведіть кількість елементів: ",
                MIN_COUNT,
                MAX_COUNT
            );

            Console.WriteLine("\nВведіть елементи списку:");

            // Введення елементів списку
            for (int i = 0; i < n; i++)
            {
                int value = ReadInt(
                    $"Елемент {i + 1}: ",
                    MIN_VALUE,
                    MAX_VALUE
                );

                list.Add(value);
            }

            Console.WriteLine("\n========== РЕЗУЛЬТАТИ ==========");

            Console.WriteLine("\nПочатковий список:");
            list.Print();

            // Введення заданого значення
            int x = ReadInt(
                "\nВведіть задане значення: ",
                MIN_VALUE,
                MAX_VALUE
            );

            // 1
            int? firstGreater = list.FindFirstGreater(x);

            if (firstGreater != null)
            {
                Console.WriteLine(
                    "\n1. Перше значення більше за задане: " +
                    firstGreater
                );
            }
            else
            {
                Console.WriteLine(
                    "\n1. Елементів більших за задане значення немає."
                );
            }

            // 2
            int sum = list.SumLessThan(x);

            Console.WriteLine(
                "\n2. Сума елементів менших за задане: " +
                sum
            );

            // 3
            LinkedList greaterList = list.GetGreaterList(x);

            Console.WriteLine(
                "\n3. Новий список з елементів більших за задане:"
            );

            greaterList.Print();

            // 4
            list.RemoveAfterMax();

            Console.WriteLine(
                "\n4. Список після видалення елементів після максимального:"
            );

            list.Print();

            // Продовження програми
            while (true)
            {
                Console.Write("\nБажаєте продовжити? (так/ні): ");

                string answer = Console.ReadLine().ToLower();

                if (answer == "так")
                {
                    Console.WriteLine();
                    break;
                }
                else if (answer == "ні")
                {
                    continueProgram = false;

                    Console.WriteLine("\nПрограму завершено.");
                    break;
                }
                else
                {
                    Console.WriteLine(
                        "Помилка! Введіть лише 'так' або 'ні'."
                    );
                }
            }

            Console.WriteLine();
        }
    }
}