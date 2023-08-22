using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.models
{
    //Помимо общего набора стандартных свойств (ID, ширина, высота, глубина, вес),(Готово)

    //У коробки должен быть указан срок годности или дата производства.(Готово)
    //Если указана дата производства, то срок годности вычисляется(Готово)
    //из даты производства плюс 100 дней.(Готово)
    // Срок годности и дата производства - это конкретная дата без времени(например, 01.01.2023).(Готово)

    //Объем коробки вычисляется как произведение ширины, высоты и глубины.(Готово)

    //Каждая коробка не должна превышать по размерам паллету (по ширине и глубине).(Готово)
    public class Box : IBoxModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Wight { get; set; }
        public int Deep { get; set; }
        public int Weight { get; set; }
        public DateTime BBDate { get; set; }
        public DateTime BBDateEnd { get; set; }
        public int Valume { get; set; }
        public Box(int id, string name, int height, int wight, int deep, int weight, DateTime bBDate, DateTime dBDateEnd, int valume)
        {
            Id = id;
            Name = name;
            Height = height;
            Wight = wight;
            Deep = deep;
            Weight = weight;
            BBDate = bBDate;
            BBDateEnd = dBDateEnd;
            Valume = valume;
        }

        public static List<Box> BoxList = new List<Box>();
    }
}
