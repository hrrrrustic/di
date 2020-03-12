using System;

namespace FractalPainting.App
{
    public class Category
    {
        public string Name { get; set; }
        public int Position { get; set; }

        private Category(String name, Int32 position)
        {
            Name = name;
            Position = position;
        }
        public static Category Settings { get; } = new Category("Настройки", 3);

        public static Category Fractals { get; } = new Category("Фракталы", 2);
        public static Category File { get; } = new Category("Файл", 1);

    }
}