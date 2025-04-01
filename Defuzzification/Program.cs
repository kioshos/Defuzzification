class Pogram
{
    private static void DisplayMatrix(double[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write(matrix[row][col] + " ");
            }
            Console.WriteLine();
        }
    }
    private static void DisplayArray(double[] array)
    {
        for (int index = 0; index < array.Length; index++)
        {
            Console.Write(array[index] + " ");
        }
    }
    private static double SearchMinElementInRow(double[][] matrix, int row)
    {
        double minElement = matrix[row][0];
        for (int col = 0; col < matrix[row].Length; col++)
        {
            if (minElement > matrix[row][col])
            {
                minElement = matrix[row][col];
            }
        }
        return minElement;
    }
    private static double SearchMaxElementInArray(double[] array,  int leftBound, int rightBound)
    {
        double maxElement = array[leftBound];
        for (int left = leftBound; left < rightBound; left++)
        {
            if (maxElement < array[left])
            {
                maxElement = array[left];
            }
        }
        return maxElement;
    }
    public static void Main(string[] args)
    {

        Dictionary<string, double> fuzzSetA = new Dictionary<string, double>()
        {
            {"T1", 0.67},
            {"T2", 0.03},
            {"T3", 0.0003}
        };
        Dictionary<string, double> fuzzSetB = new Dictionary<string, double>()
        {
            {"T1", 0.312},
            {"T2", 0.06},
            {"T3", 0.0}
        };
        Dictionary<string, double> fuzzSetC = new Dictionary<string, double>()
        {
            {"T1", 1.0},
            {"T2", 0.0},
            {"T3", 0.0029}
        };
        
        // Matrix of knowledges
        string[][] matOfKnowledges =
        {
            new string[] { "T1", "T2", "T3" },
            new string[] { "T1", "T1", "T3" },
            new string[] { "T2", "T2", "T3" },
            new string[] { "T3", "T1", "T1" },
            new string[] { "T1", "T1", "T2" },
            new string[] { "T3", "T3", "T1" }
        };
        string[] resultofKnowledges = {"E", "F"};

        double[][] logicalOutput = new double[6][];
        for (int i = 0; i < logicalOutput.Length; i++)
        {
            logicalOutput[i] = new double[3];            
        }

        for (int row = 0; row < 6 ; row++)
        {
            if (fuzzSetA.TryGetValue(matOfKnowledges[row][0], out double fuzz))
            {
                logicalOutput[row][0] = fuzz;
            }
        }
        for (int row = 0; row < 6 ; row++)
        {
            if (fuzzSetB.TryGetValue(matOfKnowledges[row][1], out double fuzz))
            {
                logicalOutput[row][1] = fuzz;
            }
        }
        for (int row = 0; row < 6 ; row++)
        {
            if (fuzzSetC.TryGetValue(matOfKnowledges[row][2], out double fuzz))
            {
                logicalOutput[row][2] = fuzz;
            }
        }
        Console.WriteLine("Matrix of logical output: ");
        DisplayMatrix(logicalOutput);
        
        double[] conjunction = new double[6];
        for (int row = 0; row < conjunction.Length; row++)
        {
            conjunction[row] = SearchMinElementInRow(logicalOutput, row);
        }
        DisplayArray(conjunction);

        double[] disjunction = new double[2];
        disjunction[0] = SearchMaxElementInArray(conjunction, 0,3);
        disjunction[1] = SearchMaxElementInArray(conjunction, 3,6);
        
        Console.WriteLine("\nDisjunction: ");
        Console.WriteLine($"E: {disjunction[0]} F: {disjunction[1]}");
        
    }
}