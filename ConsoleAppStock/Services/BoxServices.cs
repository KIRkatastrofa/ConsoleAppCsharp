using ConsoleAppStock.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.services
{
    public class BoxServices : IBaseServices<Box>
    {
        public bool AddList(Box entity)
        {
            Box.BoxList.Add(entity);
            Console.WriteLine("Коробка была добавлена!");
            return true;
        }
        public void Print()
        {
            for (int i = 0; i < Box.BoxList.Count; i++)
            {
                Console.WriteLine($"ID:({i+1}) Название: ({Box.BoxList[i].Name}) Высота: ({Box.BoxList[i].Height}) Ширина: ({Box.BoxList[i].Wight}) Глубина: ({Box.BoxList[i].Deep}) Срок годности: ({Box.BoxList[i].BBDateEnd.ToShortDateString()}) Вес: ({Box.BoxList[i].Weight}) Объем: ({Box.BoxList[i].Valume})");
            }
        }

        public bool Load()
        {
            //чтобы ручками не вводить
            Box.BoxList.Add(new Box(1, "Коробка 200x200",   10,     200,    200,    100, new DateTime(2012, 7, 20), new DateTime(2012, 7, 20).AddDays(100), (10*200*200)));
            Box.BoxList.Add(new Box(2, "Коробка 30x30",     10,     30,     30,     100, new DateTime(2021, 7, 20), new DateTime(2021, 7, 20).AddDays(100),(10*30*30)));
            Box.BoxList.Add(new Box(3, "Коробка 30x50",     10,     30,     50,     100, new DateTime(2022, 7, 20), new DateTime(2022, 7, 20).AddDays(100),(10*30*50)));
            Box.BoxList.Add(new Box(4, "Коробка 50x50",     10,     50,     50,     100, new DateTime(2020, 7, 20), new DateTime(2020, 7, 20).AddDays(100),(10*50*50)));
            Box.BoxList.Add(new Box(5, "Коробка 60x50",     10,     60,     50,     100, new DateTime(2014, 7, 20), new DateTime(2014, 7, 20).AddDays(100),(10*60*50)));
            Box.BoxList.Add(new Box(6, "Коробка 70x50",     10,     70,     50,     100, new DateTime(2015, 7, 20), new DateTime(2015, 7, 20).AddDays(100),(10*70*50)));
            Box.BoxList.Add(new Box(7, "Коробка 80x50",     10,     80,     50,     100, new DateTime(2010, 7, 20), new DateTime(2010, 7, 20).AddDays(100),(10*80*50)));
            Box.BoxList.Add(new Box(8, "Коробка 90x50",     10,     90,     50,     100, new DateTime(2012, 7, 20), new DateTime(2012, 7, 20).AddDays(100),(10*90*50)));
            Box.BoxList.Add(new Box(9, "Коробка 30x60",     10,     30,     60,     200, new DateTime(2023, 7, 20), new DateTime(2023, 7, 20).AddDays(100), (10 * 30 * 60)));
            Box.BoxList.Add(new Box(10, "Коробка 30x70",    30,     30,     70,     200, new DateTime(2021, 7, 20), new DateTime(2021, 7, 20).AddDays(100),(10*30*70)));
            Box.BoxList.Add(new Box(12, "Коробка 30x80",    30,     30,     80,     200, new DateTime(2004, 7, 20), new DateTime(2004, 7, 20).AddDays(100),(10*30*80)));
            Box.BoxList.Add(new Box(13, "Коробка 30x90",    30,     30,     90,     200, new DateTime(2005, 7, 20), new DateTime(2005, 7, 20).AddDays(100),(10*30*90)));
            Box.BoxList.Add(new Box(14, "Коробка 150x150",  30,     150,    150,    200, new DateTime(2000, 7, 20), new DateTime(2000, 7, 20).AddDays(100),(10*150*150)));
            Box.BoxList.Add(new Box(15, "Коробка 300x300",  30,     300,    300,    200, new DateTime(2013, 7, 20), new DateTime(2013, 7, 20).AddDays(100),(10*300*300)));
            Box.BoxList.Add(new Box(16, "Коробка 100x100",  30,     100,    100,    200, new DateTime(2002, 7, 20), new DateTime(2002, 7, 20).AddDays(100), (10 * 100 * 100)));
            
            Box.BoxList.Add(new Box(17, "Коробка 500x500",  30,     500,    500,    200, new DateTime(2023, 8, 20), new DateTime(2023, 8, 20).AddDays(100), (30*500*500)));
            Box.BoxList.Add(new Box(18, "Коробка 510x500",  30,     510,    500,    200, new DateTime(2023, 8, 20), new DateTime(2023, 8, 20).AddDays(100), (30 * 510 * 500)));
            Box.BoxList.Add(new Box(19, "Коробка 500x510",  30,     500,    510,    200, new DateTime(2023, 8, 20), new DateTime(2023, 8, 20).AddDays(100), (30 * 500 * 510)));
            Box.BoxList.Add(new Box(20, "Коробка 510x510",  30,     500,    510,    200, new DateTime(2023, 8, 20), new DateTime(2023, 8, 20).AddDays(100), (30 * 500 * 510)));
            return true;
        }

        public bool SortWeight(Box entity)
        {
            throw new NotImplementedException();
        }

        public Box EditList(int Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveList(Box entity)
        {
            throw new NotImplementedException();
        }
    }
}
