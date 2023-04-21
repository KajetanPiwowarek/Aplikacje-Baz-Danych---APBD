using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmp_kolos_02.Entities
{
    public class FireTruckAction
    {
        public int IdFireTruck { get; set; }
        public int IdAction { get; set; }
        public DateTime AssigmentDate { get; set; }

        public virtual FireTruck IdFireTruckNavigation { get; set; }
        public virtual Action IdActionNavigation { get; set; }
    }
}
