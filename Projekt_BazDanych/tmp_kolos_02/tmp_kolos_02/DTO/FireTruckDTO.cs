using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmp_kolos_02.DTO
{
    public class FireTruckDTO
    {
        public int IdFireTruck { get; set; }
        public string OperationNumber { get; set; }
        public bool SpecialEquipment { get; set; }
        public DateTime AssigmentDate { get; set; }
    }
}
