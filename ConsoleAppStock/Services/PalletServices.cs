using ConsoleAppStock.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppStock.services
{
    public class PalletServices : IPallerServices
    {
        public void SortWeight()
        {
            //Сгруппировать все паллеты по сроку годности,
            //отсортировать по возрастанию срока годности,
            //в каждой группе отсортировать паллеты по весу.
            var groupweightDesk = Pallet.PalletList.OrderBy(p => p.BBDate);
            var groupweight = groupweightDesk.GroupBy(p => p.BBDate);
            foreach (var pallet in groupweight)
            {
                Console.WriteLine($"========Срок годности: {pallet.Key.ToShortDateString()}========");
                var ascweight= pallet.OrderBy(p => p.Weight); 
                foreach (var name in ascweight)
                {
                    Console.WriteLine($"Название: ({name.Name}) Вес: ({name.Weight})");
                }
            }
        }
        public void SortthreePallet()
        {
            //3 паллеты, которые содержат коробки с наибольшим сроком годности,
            //отсортированные по возрастанию объема.(Готово)
            var boxonpallet = Pallet.PalletList.Where(p => p.Boxes.Count!=0);
            var sortthreepallet = boxonpallet.OrderByDescending(p => p.Boxes.Max(p => p.BBDateEnd)).Take(3);
            var sortpallet = sortthreepallet.OrderBy(p => p.Weight);
            foreach (var sort in sortpallet)
            {
                 Console.WriteLine($"Название: ({sort.Name}) Вес: ({sort.Weight})");
                 var boxes =sort.Boxes.OrderByDescending(p => p.BBDate);
                 foreach (var box in boxes)
                 {
 
                     Console.WriteLine($"Название Коробки: ({box.Name}) Дата: ({box.BBDateEnd.ToShortDateString()})");
                 }
            }
        }
        public bool AddList(Pallet entity)
        {
            Pallet.PalletList.Add(entity);
            Console.WriteLine("Паллето было добавлено!");
            return true;
        }
        public void Print()
        {
            for (int i = 0; i < Pallet.PalletList.Count; i++)
            {
                Console.WriteLine($"ID:({i + 1}) Название: ({Pallet.PalletList[i].Name}) Высота: ({Pallet.PalletList[i].Height}) Ширина: ({Pallet.PalletList[i].Wight}) Глубина: ({Pallet.PalletList[i].Deep}) Вес: ({Pallet.PalletList[i].Weight}) Объем: ({Pallet.PalletList[i].Valume}) Срок годности: ({Pallet.PalletList[i].BBDate.ToShortDateString()})");
            }
        }

        public bool Load()
        {
            //чтобы ручками не вводить
            Pallet.PalletList.Add(new Pallet(1, "Паллето 300x300", 50, 300, 300, Box.BoxList[0].Weight + Box.BoxList[1].Weight + Box.BoxList[2].Weight + 30, new List<Box>(), new DateTime(2022,7,20),(500*500*500)+Box.BoxList[0].Valume + Box.BoxList[1].Valume + Box.BoxList[2].Valume));
            Pallet.PalletList[0].Boxes.Add(Box.BoxList[0]);
            Pallet.PalletList[0].Boxes.Add(Box.BoxList[1]);
            Pallet.PalletList[0].Boxes.Add(Box.BoxList[2]);
            Pallet.PalletList.Add(new Pallet(2, "Паллето 300x400", 50, 300, 400, Box.BoxList[3].Weight + Box.BoxList[4].Weight + Box.BoxList[5].Weight + 30, new List<Box>(), new DateTime(2023, 7, 20), (50 * 300 * 400) + Box.BoxList[3].Valume + Box.BoxList[4].Valume + Box.BoxList[5].Valume));
            Pallet.PalletList[1].Boxes.Add(Box.BoxList[3]);
            Pallet.PalletList[1].Boxes.Add(Box.BoxList[4]);
            Pallet.PalletList[1].Boxes.Add(Box.BoxList[5]);
            Pallet.PalletList.Add(new Pallet(3, "Паллето 400x400", 80, 400, 400, Box.BoxList[6].Weight + Box.BoxList[7].Weight + Box.BoxList[8].Weight + 30, new List<Box>(), new DateTime(2021, 7, 20), (80 * 400 * 400) + Box.BoxList[6].Valume + Box.BoxList[5].Valume + Box.BoxList[8].Valume));
            Pallet.PalletList[2].Boxes.Add(Box.BoxList[6]);
            Pallet.PalletList[2].Boxes.Add(Box.BoxList[7]);
            Pallet.PalletList[2].Boxes.Add(Box.BoxList[8]);
            Pallet.PalletList.Add(new Pallet(1, "Паллето 500x800", 60, 500, 800, Box.BoxList[9].Weight + Box.BoxList[10].Weight + Box.BoxList[11].Weight + 30, new List<Box>(), new DateTime(2022, 7, 20), (60 * 500 * 800) + Box.BoxList[9].Valume + Box.BoxList[10].Valume + Box.BoxList[11].Valume));
            Pallet.PalletList[3].Boxes.Add(Box.BoxList[9]);
            Pallet.PalletList[3].Boxes.Add(Box.BoxList[10]);
            Pallet.PalletList[3].Boxes.Add(Box.BoxList[11]);
            Pallet.PalletList.Add(new Pallet(2, "Паллето 800x800", 50, 800, 800, Box.BoxList[12].Weight + Box.BoxList[13].Weight + 30, new List<Box>(), new DateTime(2022, 7, 20),(50 * 800 * 800) + Box.BoxList[12].Valume + Box.BoxList[13].Valume));
            Pallet.PalletList[4].Boxes.Add(Box.BoxList[12]);
            Pallet.PalletList[4].Boxes.Add(Box.BoxList[13]);
            Pallet.PalletList.Add(new Pallet(3, "Паллето 800x500", 50, 800, 500, Box.BoxList[14].Weight + 30, new List<Box>(), new DateTime(2021, 7, 20), (50 * 800 * 500) + Box.BoxList[14].Valume));
            Pallet.PalletList[5].Boxes.Add(Box.BoxList[14]);
            Pallet.PalletList.Add(new Pallet(3, "Паллето 500x500", 10, 500, 500, 30, new List<Box>(), new DateTime(2023, 8, 21), (10 * 500 * 500)));
            return true;
        }
        public bool AddBoxonPallet(int IdPallet, Box box)
        {
            for (int i = 0; i < Pallet.PalletList[IdPallet].Boxes.Count; i++)
            {
                if (Pallet.PalletList[IdPallet].Boxes[i] == box)
                {
                    Console.WriteLine("Эта коробка уже находится на паллете!");
                    return false;
                }
            }
            Pallet.PalletList[IdPallet].Boxes.Add(box);
            return true;
        }
        public bool CorPallet(int IdPallet)
        {
            //Срок годности паллеты вычисляется из наименьшего срока годности коробки,вложенной в паллету.
            var bbdateend = Pallet.PalletList[IdPallet].Boxes.Min(p => p.BBDateEnd);
            //Вес паллеты вычисляется из суммы веса вложенных коробок ~(+ 30кг)~.(Готово)
            Pallet.PalletList[IdPallet].Weight += Pallet.PalletList[IdPallet].Boxes.Last().Weight;
            //Объем паллеты вычисляется как сумма объема всех находящихся на ней коробок ~(и произведения ширины, высоты и глубины паллеты)~.(Готово)
            Pallet.PalletList[IdPallet].Valume += Pallet.PalletList[IdPallet].Boxes.Last().Valume;
            Pallet.PalletList[IdPallet].BBDate = bbdateend;
            return true;
        }
        public void PrintBoxOnPallet(int IdPallet)
        {

            Console.WriteLine($"\nНомер:({IdPallet + 1}) Название: ({Pallet.PalletList[IdPallet].Name}) Вес:({Pallet.PalletList[IdPallet].Weight}) Объем:({Pallet.PalletList[IdPallet].Valume}) Срок годности: ({Pallet.PalletList[IdPallet].BBDate.ToShortDateString()}) Коробка:");
            for (int i = 0; i < Pallet.PalletList[IdPallet].Boxes.Count; i++)
            {
                Console.WriteLine($"Номер коробки на паллете:({1+i}) Название коробки:({Pallet.PalletList[IdPallet].Boxes[i].Name}) Срок годности:({Pallet.PalletList[IdPallet].Boxes[i].BBDateEnd.ToShortDateString()}) Вес:({Pallet.PalletList[IdPallet].Boxes[i].Weight}) Объем:({Pallet.PalletList[IdPallet].Boxes[i].Valume})");
            }
        }

        public Pallet EditList(int Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveList(Pallet entity)
        {
            throw new NotImplementedException();
        }
    }
}
