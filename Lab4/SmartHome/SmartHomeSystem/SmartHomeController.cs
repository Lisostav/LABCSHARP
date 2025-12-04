using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private  List<ISwitchable> allDevices = new List<ISwitchable>();
        private  List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();
        public void AddDevice(ISwitchable device)
        {
            allDevices.Add(device);
        }
        public void AddEnergyDevice(IEnergyConsumer device)
        {
            energyDevices.Add(device);
        }
        public void TurnAllOn()
        {
            foreach (var device in allDevices)
                device.TurnOn();
        }
        public void TurnAllOff()
        {
            foreach (var device in allDevices)
                device.TurnOff();
        }
        public void ShowEnergyReport(int hours)
        {
            CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double total = 0;

            foreach (var device in energyDevices)
            {
                double used = device.GetEnergyUsage(hours);
                total += used;
            }
            Console.WriteLine($"Загальне споживання: {total:F2} кВт·год");
            Console.WriteLine();
            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");
            Console.WriteLine();
            foreach (var device in energyDevices)
            {
                double used = device.GetEnergyUsage(hours);
                Console.WriteLine($"{device.DeviceName}: {used:F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
                Console.WriteLine();
            }
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {total * 4:F2} грн");
        }
    }
}
