namespace Storages
{
    abstract class Storage
    {
        protected string _name;
        protected string _model;

        public Storage(string name, string model)
        {
            _name = name;
            _model = model;
        }

        public abstract int GetCapacity();
        public abstract void CopyData(int dataSize);
        public abstract int GetFreeSpace();
        public abstract string GetInfo();
    }

    class Flash : Storage
    {
        private int _usbSpeed;
        private int _capacity;
        private int _usedSpace;

        public Flash(string name, string model, int usbSpeed, int capacity)
            : base(name, model)
        {
            _usbSpeed = usbSpeed;
            _capacity = capacity;
            _usedSpace = 0;
        }

        public override int GetCapacity()
        {
            return _capacity;
        }

        public override void CopyData(int dataSize)
        {
            if (dataSize > GetFreeSpace())
                throw new InvalidOperationException("Not enough space on Flash memory.");
            _usedSpace += dataSize;
        }

        public override int GetFreeSpace()
        {
            return _capacity - _usedSpace;
        }

        public override string GetInfo()
        {
            return $"Flash: {_name} {_model}, USB 3.0 Speed: {_usbSpeed} MB/s, Capacity: {_capacity} GB";
        }
    }

    class DVD : Storage
    {
        private int _readWriteSpeed;
        private int _capacity;
        private int _usedSpace;

        public DVD(string name, string model, int readWriteSpeed, string dvdType)
            : base(name, model)
        {
            _readWriteSpeed = readWriteSpeed;
            _capacity = dvdType == "single-sided" ? 5 : 9;
            _usedSpace = 0;
        }

        public override int GetCapacity()
        {
            return _capacity;
        }

        public override void CopyData(int dataSize)
        {
            if (dataSize > GetFreeSpace())
                throw new InvalidOperationException("Not enough space on DVD.");
            _usedSpace += dataSize;
        }

        public override int GetFreeSpace()
        {
            return _capacity - _usedSpace;
        }

        public override string GetInfo()
        {
            return $"DVD: {_name} {_model}, Speed: {_readWriteSpeed} MB/s, Type: {_capacity} GB";
        }
    }

    class HDD : Storage
    {
        private int _usbSpeed;
        private int _capacity;
        private int _usedSpace;
        private int _partitionsCount;

        public HDD(string name, string model, int usbSpeed, List<int> partitions)
            : base(name, model)
        {
            _usbSpeed = usbSpeed;
            _capacity = 0;
            foreach (var partition in partitions)
            {
                _capacity += partition;
            }
            _partitionsCount = partitions.Count();
            _usedSpace = 0;
        }

        public override int GetCapacity()
        {
            return _capacity;
        }

        public override void CopyData(int dataSize)
        {
            if (dataSize > GetFreeSpace())
                throw new InvalidOperationException("Not enough space on HDD.");
            _usedSpace += dataSize;
        }

        public override int GetFreeSpace()
        {
            return _capacity - _usedSpace;
        }

        public override string GetInfo()
        {
            return $"HDD: {_name} {_model}, USB 2.0 Speed: {_usbSpeed} MB/s, Capacity: {_capacity} GB";
        }

        public int GetPartitionsCount()
        {
            return _partitionsCount;
        }
    }
}