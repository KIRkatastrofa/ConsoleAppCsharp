using ConsoleAppStock.Controllers;
using ConsoleAppStock.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.View
{


    public class BaseView
    {
        public void View()
        {
            Console.WriteLine("Все что имеется на складе!");
            var box = new BoxController();
            Console.WriteLine("=======Коробки=======");
            box.Load();
            var pallet = new PalletController();
            Console.WriteLine("=======Паллета=======");
            pallet.Load();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nВведите номер задания:\n0-выход, \n1-Вывод всего, \n2-Добавление паллеты,\n3-добавление коробки,\n4-добавление коробки на паллеты\n5-Вывод1\n6-Вывод2");
                    var Num = Convert.ToInt32(Console.ReadLine());
                    switch (Num)
                    {
                        case 0:
                            return;
                        case 1:
                            Console.WriteLine("Вывел все");
                            Console.WriteLine("==========Коробки==========");
                            box.Print();
                            Console.WriteLine("==========Паллеты==========");
                            pallet.Print();
                            break;
                        case 2:
                            Console.WriteLine("Добавляем паллеты");
                            InputData(pallet);
                            break;
                        case 3:
                            Console.WriteLine("Добавляем коробки");
                            InputData(box);
                            break;
                        case 4:
                            Console.WriteLine("(выберите номер паллета, а за тем номер коробки)Добавляем коробки на паллета"); //(и выбрать паллету, куда хотим сложить)
                            Console.WriteLine("==========Паллеты==========");
                            pallet.Print();
                            Console.WriteLine("==========Коробки==========");
                            box.Print();
                            AddBoxOnPaller(pallet);
                            break;
                        case 5:
                            Console.WriteLine("Сгруппировать все паллеты по сроку годности,\nотсортировать по возрастанию срока годности,\nв каждой группе отсортировать паллеты по весу.");
                            pallet.SortWeight();
                            break;
                        case 6:
                            Console.WriteLine("3 паллеты, которые содержат коробки с наибольшим \nсроком годности, отсортированные по возрастанию \nобъема.");
                            pallet.SortthreePallet();
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void InputData(IBaseController uconttroler)
        {
            
            //var height = 0;
            //var wight = 0;
            var weight = 0;
            //*var deep = 0;
            var date = DateTime.Now;
          
            Console.WriteLine("Введите название");
            var name = Console.ReadLine();
            Console.WriteLine("Введите высоту");
            var height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ширину");
            var wight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите глубину");
            var deep = Convert.ToInt32(Console.ReadLine());
            var box=new BoxController();
            if (box.GetType() == uconttroler.GetType())
            {
                Console.WriteLine("Введите вес");
                weight = Convert.ToInt32(Console.ReadLine());
            }
            if(name!=null)
                uconttroler.Add(name,height,wight,deep, weight, date);
            
        }
        public void AddBoxOnPaller(IPalletController uconttroler)
        {
            var numberPallet = Convert.ToInt32(Console.ReadLine())-1;
            var numberBox = Convert.ToInt32(Console.ReadLine())-1;
            uconttroler.AddBoxPal(numberPallet, numberBox);
        }
    }
}
