using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2024
{
    abstract class Car
    {
        protected string car1 = "Первая машина", car2 = "Вторая машина", car3 = "Третяя машина";
        protected int speed { get; set; }
        public abstract void Drive();
    }

    class Car1 : Car
    {
        public override void Drive()
        {
            speed = 5;
            Console.WriteLine ( $"{car1} поехала!\nСкорость: {speed}" );            
        }
    }

    class Car2 : Car
    {
        public override void Drive()
        {
            speed = 10;
            Console.WriteLine($"{car2} поехала!\nСкорость: {speed}");
        }
    }

    class Car3 : Car
    {
        public override void Drive()
        {
            speed = 0;
            Console.WriteLine($"{car3} вообще не завелась!\nСкорость: {speed}");
        }
    }
}
