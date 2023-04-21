using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmp_kolos_02.Entities;

namespace tmp_kolos_02.DTO
{
    public class ActionDTO
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }
        public IList<FireTruckDTO> FireTrucks { get; set; }
    }
}
