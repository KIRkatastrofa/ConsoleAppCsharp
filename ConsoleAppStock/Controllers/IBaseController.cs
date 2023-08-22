using ConsoleAppStock.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.Controllers
{
    public interface IBaseController
    {
        bool Add(string name, int height,int wight,int deep,int weight,DateTime date);
        void Load();
        void Print();
    }
    public interface IPalletController : IBaseController
    {
        bool AddBoxPal(int IdPallet,int IdBox);
        void SortWeight();
        void SortthreePallet();
    }
}
