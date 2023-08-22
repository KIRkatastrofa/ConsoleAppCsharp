using ConsoleAppStock.models;
using ConsoleAppStock.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.Controllers
{
    public class BoxController : IBaseController
    {
        BoxServices boxservices = new BoxServices();
        Random rnd = new Random();
        public bool Add(string name, int height, int wight, int deep, int weight, DateTime date)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var idcount = rnd.Next(1, 100000);
                //У коробки должен быть указан срок годности или дата производства.(Готово)
                //Если указана дата производства, то срок годности вычисляется(Готово)
                //из даты производства плюс 100 дней.(Готово)
                var dateend = date.AddDays(100);
                //Объем коробки вычисляется как произведение ширины, высоты и глубины.(Готово)
                var valume = wight * height * deep;
                if (valume!=0 && weight!=0)
                {
                    var product = new Box(idcount, name, height, wight, deep, weight, date, dateend, valume);
                    boxservices.AddList(product);
                    return true;
                }
                throw new ArgumentException("Коробка имеет некорректное значение!");
            }
            else
                throw new ArgumentException("Коробка имеет некорректное название!");
        }

        public void Load()
        {
            boxservices.Load();
            boxservices.Print();
        }

        public void Print()
        {
            boxservices.Print();
        }
    }
}
