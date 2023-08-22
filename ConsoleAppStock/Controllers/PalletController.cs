using ConsoleAppStock.models;
using ConsoleAppStock.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.Controllers
{
    public class PalletController : IPalletController
    {
        PalletServices palletservices = new PalletServices();
        Random rnd=new Random();
        public bool Add(string name, int height, int wight, int deep, int weight, DateTime date)
        {
            if (!string.IsNullOrEmpty(name))
            {
                //Вес паллеты вычисляется ~(из суммы веса вложенных коробок)~ + 30кг.(Готово)
                //Объем паллеты вычисляется как ~(сумма объема всех находящихся на ней коробок
                //и)~ произведения ширины, высоты и глубины паллеты.(Готово)
                var idcount = rnd.Next(1, 100000);
                var valume = wight * height * deep;
                var box = new List<Box>();
                weight = 30;
                if (valume != 0)
                {
                    Pallet product = new Pallet(idcount, name, height, wight, deep, weight, box, date, valume);
                    palletservices.AddList(product);
                    return true;
                }
                throw new ArgumentException("Паллето имеет некорректное значение!");
            }
            else 
                throw new ArgumentException("Паллето имеет некорректное название!");

        }
        public void Load()
        {
            palletservices.Load();
            palletservices.Print();
        }
        public bool AddBoxPal(int IdPallet, int IdBox)
        {
            if (Box.BoxList[IdBox].Wight > Pallet.PalletList[IdPallet].Wight || Box.BoxList[IdBox].Deep> Pallet.PalletList[IdPallet].Deep)
            {
                //Каждая коробка не должна превышать по размерам паллету (по ширине и глубине).(Готово)
                throw new ArgumentException("Коробка превышает размеры паллеты по ширине или высоте!");
            }
            if (IdBox >=0 && IdBox < Box.BoxList.Count && IdPallet >=0 && IdPallet < Pallet.PalletList.Count)
            {
                var key=palletservices.AddBoxonPallet(IdPallet, Box.BoxList[IdBox]);
                if (key == true)
                {
                    palletservices.CorPallet(IdPallet);
                    palletservices.PrintBoxOnPallet(IdPallet);
                    return true;
                }
                return false;
            }
            else 
                return false; 

        }
        public void Print()
        {
            palletservices.Print();
        }
        public void SortWeight()
        {
            palletservices.SortWeight();
        }

        public void SortthreePallet()
        {
            palletservices.SortthreePallet();
        }
    }
}
