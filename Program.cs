using System;
using System.IO;
public class CakeOrder
{
    public double totalPrice;
    public string selectedCake;
    public string orderInfo;

    public static int ShowSubMenu(string[] options)
    {
        return ArrowMenu.ShowMenu(options);
    }
    public CakeOrder()
    {
        totalPrice = 0;
        selectedCake = "";
        orderInfo = "";
    }
    public void POrder()
    {
        int currentChoice = 0;
        string[] options = { "Форма торта", "Размер торта", "Вкус коржей", "Количество коржей", "Глазурь", "Декор", "Завершить заказ" };
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Заказ тортов на ваш выбор!");
            Console.WriteLine("Выберите параметр торта");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Цена: " + totalPrice);
            Console.Write("Ваш торт: ");
            Console.WriteLine(selectedCake);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + options.Length) % options.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % options.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (currentChoice == 6)
                {
                    COrder();
                    break;
                }
                else
                {
                    if (!string.IsNullOrEmpty(selectedCake))
                    {
                        selectedCake += ", ";
                    }
                    if (currentChoice == 0)
                    {
                        selectedCake += CF(out double formPrice);
                        totalPrice += formPrice;
                    }
                    else if (currentChoice == 1)
                    {
                        selectedCake += Cs(out double sizePrice);
                        totalPrice += sizePrice;
                    }
                    else if (currentChoice == 2)
                    {
                        selectedCake += CT(out double tastePrice);
                        totalPrice += tastePrice;
                    }
                    else if (currentChoice == 3)
                    {
                        selectedCake += ChooseCakeQuantity(out double quantityPrice);
                        totalPrice += quantityPrice;
                    }
                    else if (currentChoice == 4)
                    {
                        selectedCake += CG(out double glazePrice);
                        totalPrice += glazePrice;
                    }
                    else if (currentChoice == 5)
                    {
                        selectedCake += CD(out double decorPrice);
                        totalPrice += decorPrice;
                    }
                }
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                currentChoice = 0;
            }
        }
    }
    public static class ArrowMenu
    {
        public static int ShowMenu(string[] options)
        {
            int currentChoice = 0;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    currentChoice = (currentChoice - 1 + options.Length) % options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentChoice = (currentChoice + 1) % options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return currentChoice;
                }
                Console.CursorVisible = false;
            }
        }
    }
    public string CF(out double formPrice)
    {
        string[] formOptions = { "Круг", "Квадрат", "Треугольник", "Сердце" };
        double[] formPrices = { 500, 450, 500, 800 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите форму торта:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < formOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{formOptions[i]} - {formPrices[i]} рублей");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + formOptions.Length) % formOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % formOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                formPrice = formPrices[currentChoice];
                return formOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                formPrice = 0;
                return "Не выбрано";
            }
        }
    }
    public string CT(out double tastePrice)
    {
        string[] tasteOptions = { "Ванильный", "Шоколадный", "Клубничный" };
        double[] tastePrices = { 100, 100, 150 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите вкус коржей:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < tasteOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{tasteOptions[i]} - {tastePrices[i]} рублей");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + tasteOptions.Length) % tasteOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % tasteOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                tastePrice = tastePrices[currentChoice];
                return tasteOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                tastePrice = 0;
                return "Не выбрано";
            }
        }
    }
    public string Cs(out double sizePrice)
    {
        string[] sizeOptions = { "Маленький ", "Обычный", "Большой " };
        double[] sizePrices = { 1000, 1200, 2000 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите размер торта:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < sizeOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{sizeOptions[i]} - {sizePrices[i]} рублей");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + sizeOptions.Length) % sizeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % sizeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                sizePrice = sizePrices[currentChoice];
                return sizeOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                sizePrice = 0;
                return "Не выбрано";
            }
        }
    }
    public string ChooseCakeQuantity(out double quantityPrice)
    {
        string[] quantityOptions = { "1 корж", "2 коржа", "3 коржа", "4 коржа" };
        double[] quantityPrices = { 150, 300, 450, 600 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите количество коржей:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < quantityOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{quantityOptions[i]} - {quantityPrices[i]} рублей");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + quantityOptions.Length) % quantityOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % quantityOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                quantityPrice = quantityPrices[currentChoice];
                return quantityOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                quantityPrice = 0;
                return "Не выбрано";
            }
        }
    }
    public string CD(out double dPrice)
    {
        string[] dOptions = { "Шоколадная", "Ягодная", "Ванильная" };
        double[] dPrices = { 150, 150, 150 };

        int currentChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите декор:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < dOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{dOptions[i]} - {dPrices[i]} рублей");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + dOptions.Length) % dOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % dOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                dPrice = dPrices[currentChoice];
                return dOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                dPrice = 0;
                return "Не выбрано";
            }
        }
    }
    public string CG(out double glazePrice)
    {
        string[] glazeOptions = { "Шоколад", "Крем", "Ваниль" };
        double[] glazePrices = { 100, 250, 400 };
        int currentChoice = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите глазурь:");
            Console.WriteLine("-----------------------");

            for (int i = 0; i < glazeOptions.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{glazeOptions[i]} - {glazePrices[i]} рублей");
            }
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                currentChoice = (currentChoice - 1 + glazeOptions.Length) % glazeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                currentChoice = (currentChoice + 1) % glazeOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                glazePrice = glazePrices[currentChoice];
                return glazeOptions[currentChoice];
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                glazePrice = 0;
                return "Не выбрано";
            }
        }
    }
    public void COrder()
    {
        Console.WriteLine("Заказ завершен. Цена: " + totalPrice);
        Console.WriteLine("Ваш торт: " + selectedCake);

        DateTime currentTime = DateTime.Now;
        string orderTime = currentTime.ToString("dd.MM.yyyy HH:mm:ss");

        orderInfo = "Время завершения заказа: " + orderTime + Environment.NewLine +
                    "Содержимое торта: " + selectedCake + Environment.NewLine +
                    "Конечная цена: " + totalPrice.ToString("C");

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "Эщкере.txt");
        try
        {
            File.AppendAllText(filePath, orderInfo + Environment.NewLine);
            Console.WriteLine("Информация о заказе сохранена в файле 'Эщкере.txt' на рабочем столе.");
        }
        catch (IOException e)
        {
            Console.WriteLine("Произошла ошибка при сохранении файла: " + e.Message);
        }
    }
    static void Main(string[] args)
    {
        while (true)
        {
            CakeOrder order = new CakeOrder();
            order.POrder();
            Console.WriteLine("Желаете оформить еще один заказ? (Да/Нет)");
            string response = Console.ReadLine();
            if (response.ToUpper() != "ДА")
            {
                break;
            }
        }
    }
}
