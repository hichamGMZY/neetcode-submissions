public class Solution {

    public static void Run()
    {
        var solution = new Solution();
        int[] piles = [];
        var h = 4;
        var res = solution.MinEatingSpeed(piles, h);
        ;
    }
    
    public int MinEatingSpeed(int[] piles, int h)
    {
        var begin = 1l;
        if (GetTimeToEat(piles, begin) <= h)
            return 1;
        var end = piles.Select(x=> (long) x).Sum();

        while (end - begin > 1)
        {
            var middle = (begin + end) / 2;
            var timeToEat = GetTimeToEat(piles, middle);
            if (timeToEat > h)
            {
                begin = middle;
            }
            else
            {
                end = middle;
            }
        }

        return (int) end;

    }

    public long GetTimeToEat(int[] piles, long rate)
    {
        var total = 0l;
        foreach (var pile in piles)
        {
            var div = pile / rate;
            var mod = pile % rate;
            total += mod == 0 ? div : div + 1;
        }

        return total;
    }
}
