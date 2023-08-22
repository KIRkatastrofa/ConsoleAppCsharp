using ConsoleAppStock.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.services
{
    public interface IBaseServices<T>
    {
        bool AddList(T entity);
        T EditList(int Id);
        bool RemoveList(T entity);
        bool Load();
        void Print();
    }
    public interface IPallerServices : IBaseServices<Pallet>
    {
        void SortWeight();
        void SortthreePallet();
        bool AddBoxonPallet(int IdPallet,Box box);
        bool CorPallet(int IdPallet);
        void PrintBoxOnPallet(int IdPallet);

    }
}
