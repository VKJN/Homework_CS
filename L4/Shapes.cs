namespace Shapes
{
    public class DrawShapes
    {
        public void DrawTriangle()
        {
            Console.WriteLine("Enter the height of triangle: ");
            int heightTr = int.Parse(Console.ReadLine());

            for (int i = 1; i < heightTr + 1; i++)
            {
                Console.WriteLine(new string(' ', heightTr - i) + new string('*', i * 2 - 1));
            }
            Console.WriteLine();
        }

        public void DrawSquare()
        {
            Console.WriteLine("Enter the side of square: ");
            int heightSq = int.Parse(Console.ReadLine());

            for (int i = 0; i < heightSq; i++)
            {
                for (int j = 0; j < heightSq; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void DrawRectangle()
        {
            Console.WriteLine("Enter the height of rectangle: ");
            int heightRec = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the width of rectangle: ");
            int widthRec = int.Parse(Console.ReadLine());

            for (int i = 0; i < heightRec; i++)
            {
                for (int j = 0; j < widthRec; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}