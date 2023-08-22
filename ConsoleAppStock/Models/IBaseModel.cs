using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStock.models
{
    public interface IBaseModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int Height { get; set; }
        int Wight { get; set; }
        int Deep { get; set; }
        int Weight { get; set; }
        DateTime BBDate { get; set; }
        int Valume { get; set;}
    }
    public interface IPalletModel : IBaseModel
    {
        List<Box> Boxes { get; set; }
    }

    public interface IBoxModel : IBaseModel
    {
        DateTime BBDateEnd { get; set; }
    }
}
