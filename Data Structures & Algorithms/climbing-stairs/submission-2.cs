
public class Solution {
    public int ClimbStairs(int n) {     
        if (n <= 1) {
            return 1;
        }

        var fibo0 = 1;
        var fibo1 = 1;
        
        for (int i = 2; i <= n; i++)
        {
            var tmp = fibo0 + fibo1;
            fibo0 = fibo1;
            fibo1 = tmp;
        }
        // Recursive case: fib(n) = fib(n - 1) + fib(n - 2)
        return fibo1;
    }
}