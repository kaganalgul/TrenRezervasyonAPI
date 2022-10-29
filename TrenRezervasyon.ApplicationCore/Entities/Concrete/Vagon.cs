using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenRezervasyon.ApplicationCore.Entities.Abstract;

namespace TrenRezervasyon.ApplicationCore.Entities.Concrete
{
    public class Vagon : BaseEntity, IVagon
    {
        public int TrenId { get; set; }
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; } = 0;
        public Tren? Tren { get; set; }
    }
}
