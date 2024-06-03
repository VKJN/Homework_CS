using Storages;
namespace L5
{
    class Program
    {
        static void Main()
        {
            List<Storage> devices = new List<Storage>
            {
                new Flash("Kingston", "DT100G3", 100, 64),
                new DVD("Sony", "DRU-880S", 10, "single-sided"),
                new HDD("Seagate", "Expansion", 60, new List<int> { 500 })
            };

            int totalCapacity = CalculateTotalCapacity(devices);
            int dataSize = 565; // Гб
            try
            {
                CopyDataToDevices(devices, dataSize);
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

         
            Console.WriteLine($"Total memory of all devices: {totalCapacity} GB");
        }

        static int CalculateTotalCapacity(List<Storage> devices)
        {
            int total = 0;
            foreach (var device in devices)
            {
                total += device.GetCapacity();
            }
            return total;
        }

        static void CopyDataToDevices(List<Storage> devices, int dataSize)
        {
            foreach (var device in devices)
            {
                int freeSpace = device.GetFreeSpace();
                if (dataSize == 0) break;
                
                if (freeSpace >= dataSize)
                {
                    device.CopyData(dataSize);
                    dataSize = 0;
                }

                else
                {
                    device.CopyData(freeSpace);
                    dataSize -= freeSpace;
                }
            }

            if (dataSize > 0)
            {
                throw new InvalidOperationException("Not enough space on all devices combined.");
            }
        }

        // Не сделано:
        // расчет времени необходимого для копирования;
        // расчет необходимого количества носителей информации представленных типов для переноса информации.
    }
}