namespace MatrixComparer
{
    public class Matrix
    {
        private readonly double[,] data;
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public double this[int row, int col]
        {
            get { return data[row, col]; }
            set { data[row, col] = value; }
        }

        public Matrix(int rows, int colomns)
        {
            Rows = rows;
            Columns = colomns;
        }

        public class Comparer : IEqualityComparer<Matrix>
        {
            public static Comparer Instance { get; } = new Comparer();
            private Comparer() { }

            public bool Equals(Matrix x, Matrix y)
            {
                if (x == null || y == null)
                    return false;

                if (x.Rows != y.Rows || x.Columns != y.Columns)
                    return false;

                for (int i = 0; i < x.Rows; i++)
                {
                    for (int j = 0; j < x.Columns; j++)
                    {
                        if (x[i, j] != y[i, j]) 
                            return false;
                    }           
                }
                return true;
            }

            public int GetHashCode(Matrix obj)
            {
                if (obj == null)
                    return 0;

                return HashCode.Combine(obj.Columns, obj.Rows, obj.data);
            }
        }
    }
}