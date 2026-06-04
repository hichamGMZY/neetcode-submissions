public class Solution {
    public int ClimbStairs(int n) {     
         if (n <= 1) {
            return 1;
        }
    // Recursive case: fib(n) = fib(n - 1) + fib(n - 2)
    return ClimbStairs(n - 1) + ClimbStairs(n - 2);
}
    }

