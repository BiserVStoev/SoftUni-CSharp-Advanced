using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] sequenceThree = { 1, 1, 1 };

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceThree));
    }

    static int GetIndexOfFirstElementLargerThanNeighbours(int [] sequence)
    {
        int index = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (i == 0)
            {
                if (sequence[i] > sequence[i + 1])
                {
                    index = i;
                    break;
                }
            }
            else if (i == sequence.Length - 1)
            {
                if (sequence[i] > sequence[i - 1]) 
                {
                    index = i;
                    break;
                }
            }
            else
            {
                if (sequence[i] > sequence[i - 1] && sequence[i + 1] < sequence[i])
                {
                    index = i;
                    break;
                }
            }
        }

        if (index == 0)
	    {
		    index = -1;
	    }
        return index;
    }
}
