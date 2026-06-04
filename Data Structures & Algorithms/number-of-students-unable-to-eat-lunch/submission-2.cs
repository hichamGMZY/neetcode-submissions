

public class Solution {
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var sandwichStack = new Stack<int>();
        var studentQueue = new Queue<int>();
        foreach (var student in students)
            studentQueue.Enqueue(student);
        for (int i = sandwiches.Length - 1; i >= 0; i--)
            sandwichStack.Push(sandwiches[i]);
        int nbTry = 0;
        while (sandwichStack.Count > 0)
        {
            var student = studentQueue.Dequeue();
            var sandwich = sandwichStack.Peek();
            if (student == sandwich)
            {
                sandwichStack.Pop();
                nbTry = 0;
            }
            else
            {
                nbTry++;
                if (nbTry > sandwichStack.Count)
                    return sandwichStack.Count;
                studentQueue.Enqueue(student);
            }
        }

        return 0;
    }
}