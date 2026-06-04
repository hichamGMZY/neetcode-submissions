public class Solution {
    public bool IsValid(string s)
    {
        Dictionary<char, char> close = new Dictionary<char, char>(){ { ')', '(' }, { '}', '{' }, { ']', '[' } };
        Stack<char> openBrackets = new Stack<char>();
        foreach (var bracket in s)
        {
            if (close.ContainsKey(bracket))
            {
                if (openBrackets.TryPop(out var openBracket))
                {
                    if (openBracket != close[bracket])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                openBrackets.Push(bracket);
            }
        }
        return openBrackets.Count == 0;
    }
}