using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SmartHomeSystem
{
    internal class Program
    {
        static void Main()
        {
            var controller = new SmartHomeController();
            var light = new Light { Name = "Лампа у вітальні" };
            var conditioner = new AirConditioner { Name = "Кондиціонер у спальні" };
            var coffeeMachine = new CoffeeMachine { Name = "Кавомашина на кухні" };
            var motionSensor = new MotionSensor { Name = "Датчик руху у коридорі" };

            controller.AddDevice(light);
            controller.AddDevice(conditioner);
            controller.AddDevice(coffeeMachine);
            controller.AddDevice(motionSensor);

            controller.AddEnergyDevice(light);
            controller.AddEnergyDevice(conditioner);
            controller.AddEnergyDevice(coffeeMachine);

            controller.TurnAllOn();

            light.PrintStatus();
            conditioner.PrintStatus();
            coffeeMachine.PrintStatus();
            motionSensor.PrintStatus();

            controller.ShowEnergyReport(5);

            controller.TurnAllOff();
        }
    }
}
