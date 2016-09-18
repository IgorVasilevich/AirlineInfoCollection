using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public enum FlyC
    {
        Business,
        Ecocnomy
    }

    public class FlyClass
    {
        public float Price { get; set; }
        public FlyC Flyclass { get; set; }

        public FlyClass(FlyC flyC)
        {
            //Price = price;
            Flyclass = flyC;
        }

    }
}
