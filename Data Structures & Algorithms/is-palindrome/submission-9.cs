public class Solution {

    public static void Test()
    {
        var solution = new Solution();
        var s = ".,";
        var res = solution.IsPalindrome(s);
        ;
    }
    public bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            while (left < s.Length - 1 && !char.IsLetterOrDigit(s[left]))
                left++;
            while (right > 0 && !char.IsLetterOrDigit(s[right]))
                right--;
            if (left >= right)
                return true;
            
            if (! char.ToUpperInvariant(s[left]).Equals(char.ToUpperInvariant(s[right])))
                return false;
            left++;
            right--;
        }

        return true;
    }
    
    
}