
public class Solution : GuessGame {


    public static void Run()
    {
        int[][] matrix = [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 50]];
        var solution = new Solution();
        ;
    }
    public int GuessNumber(int n) {
        int begin = 0;
        int end = n;
        if (guess(begin) == 0)
            return begin;

        if (guess(end) == 0)
            return end;

        while (end - begin > 1)
        {
            var middle =(int) (((long)begin + (long)end) / 2);
            var middleGuess = guess(middle);
            if (middleGuess == 0)
                return middle;
            if (middleGuess == -1)
                end = middle;
            else
                begin = middle;
        }

        return begin;
    }

}