    public class Solution {

        public static void Run()
        {
            var res = new Solution().IsPalindrome(".,");
            Console.WriteLine(res);
        }
        
        public bool IsPalindrome(string s)
        {

            var left = 0;
            var right = s.Length - 1;
            
            while (left <= s.Length / 2 && left < right)
            {
                while (!char.IsLetterOrDigit(s[left]) && left < right)
                {
                    left++;
                }

                while (!char.IsLetterOrDigit(s[right]) && right > left)
                {
                    right--;
                }

                if (left >= right)
                    return true;
                
                if(!s[left].ToString().Equals(s[right].ToString(), StringComparison.InvariantCultureIgnoreCase))
                    return false;

                left++;
                right--;
            }

            return true;
        }
        

    }