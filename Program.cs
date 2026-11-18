using System;

namespace MultipleInterfacesPractice
{
    // =========================================================================
    // ІНТЕРФЕЙСИ (Контракти поведінки)
    // =========================================================================

    // Інтерфейс для малювання об'єктів
    interface IDrawable
    {
        void Draw();
    }

    // Інтерфейс для масштабування фігур
    interface IScalable
    {
        void Scale(double factor);
    }

    // Домашнє завдання: інтерфейс для збереження унікального текстового коду об'єкта
    interface IIdentifiable
    {
        string Id { get; set; }
    }

    // =========================================================================
    // КЛАС З МНОЖИННОЮ РЕАЛІЗАЦІЄЮ ІНТЕРФЕЙСІВ
    // =========================================================================

    // Клас Rectangle одночасно реалізує три інтерфейси через кому
    class Rectangle : IDrawable, IScalable, IIdentifiable
    {
        public string Id { get; set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(string id, double width, double height)
        {
            Id = id;
            Width = width;
            Height = height;
        }

        // Реалізація методу інтерфейсу IDrawable
        public void Draw()
        {
            Console.WriteLine("Малюємо прямокутник [Код: " + Id + "] зі сторонами " + Width + " x " + Height + ".");
        }

        // Реалізація методу інтерфейсу IScalable
        public void Scale(double factor)
        {
            if (factor > 0)
            {
                Width = Width * factor;
                Height = Height * factor;
                Console.WriteLine("   -> Прямокутник [" + Id + "] масштабовано у " + factor + " раз(и). Нові розміри: " + Width + " x " + Height + ".");
            }
            else
            {
                Console.WriteLine("   -> Помилка: коефіцієнт масштабування має бути більшим за 0.");
            }
        }
    }

    // =========================================================================
    // ГОЛОВНИЙ КЛАС ПРОГРАМИ
    // =========================================================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо об'єкт прямокутника з унікальним кодом
            Rectangle rect = new Rectangle("RECT-001", 4.0, 6.0);

            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ: Робота через інтерфейсні посилання ===");

            // 1. Зберігаємо посилання на об'єкт у змінній типу IDrawable
            IDrawable drawableRef = rect;
            drawableRef.Draw();
            // Примітка: через drawableRef неможливо викликати Scale(), бо його немає в IDrawable

            // 2. Зберігаємо посилання на той самий об'єкт у змінній типу IScalable
            IScalable scalableRef = rect;
            scalableRef.Scale(1.5);

            // Перевіряємо результат після масштабування через IDrawable
            drawableRef.Draw();

            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ: Робота через інтерфейс IIdentifiable ===");

            // 3. Зберігаємо посилання у змінній типу IIdentifiable
            IIdentifiable identifiableRef = rect;
            Console.WriteLine("Поточний унікальний код об'єкта: " + identifiableRef.Id);

            // Змінюємо унікальний код через інтерфейсне посилання
            identifiableRef.Id = "RECT-999-UPDATED";
            Console.WriteLine("Оновлений код об'єкта: " + identifiableRef.Id);

            // Фінальний вивід стану об'єкта
            rect.Draw();
        }
    }
}
