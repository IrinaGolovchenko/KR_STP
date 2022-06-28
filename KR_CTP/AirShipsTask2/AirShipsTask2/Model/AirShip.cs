using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirShipsTask2.Model
{
    // Модель данных из таблицы
    // air_ship
    // id name type
    // 1  boeing heavy
    // 2 sukhoi medium
    // ...
    public class AirShip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
