using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmp_kolos_02.Entities
{
    public class FireTruck
    {
        public int IdFireTruck { get; set; }
        public string OperationNumber { get; set; }
        public bool SpecialEquipment { get; set; }
        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }

        public FireTruck()
        {
            FireTruckActions = new HashSet<FireTruckAction>();
        }
    }
}
