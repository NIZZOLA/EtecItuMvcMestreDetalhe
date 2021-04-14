using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.AulaEtec.Models
{
    public class DashBoardModel
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }

    public class DashBoardListModel
    {
        public DashBoardListModel()
        {
            this.Valores = new List<DashBoardModel>();
        }
        public ICollection<DashBoardModel> Valores { get; set; }
    }
}
