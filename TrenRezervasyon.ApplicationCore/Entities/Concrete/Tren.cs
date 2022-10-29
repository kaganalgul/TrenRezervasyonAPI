using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenRezervasyon.ApplicationCore.Entities.Abstract;

namespace TrenRezervasyon.ApplicationCore.Entities.Concrete
{
    public class Tren : BaseEntity, ITren
    {
        public string Ad { get; set; }
        public ICollection<Vagon> Vagonlar { get; set; } = new HashSet<Vagon>();
    }
}
