using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppStock.models
{
    //Помимо общего набора стандартных свойств (ID, ширина, высота, глубина, вес),(Готово)
    //паллета может содержать в себе коробки.(Готово)

    // Срок годности паллеты вычисляется из наименьшего срока годности коробки,вложенной в паллету.(Готово)
    //Вес паллеты вычисляется из суммы веса вложенных коробок + 30кг.(Готово)

    //Объем паллеты вычисляется как сумма объема всех находящихся на ней коробок(Готово)
    //и произведения ширины, высоты и глубины паллеты.(Готово)
    public class Pallet : IPalletModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Wight { get; set; }
        public int Deep { get; set; }
        public int Weight { get; set; }
        public List<Box> Boxes { get; set; }
        public DateTime BBDate { get; set; }
        public int Valume { get; set; }
        public Pallet(int id, string name, int height, int wight, int deep, int weight,List<Box> box, DateTime bBDate, int valume)
        {
            Id = id;
            Name = name;
            Height = height;
            Wight = wight;
            Deep = deep;
            Weight = weight;
            Boxes = box;
            BBDate = bBDate;
            Valume = valume;
        }
        public static List<Pallet> PalletList = new List<Pallet>();
    }
}
