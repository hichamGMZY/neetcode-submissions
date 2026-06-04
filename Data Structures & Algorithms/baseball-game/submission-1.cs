

public class Solution {
    public int CalPoints(string[] operations)
    {
        var record = new LinkedList<int>();
        foreach( var operation in operations)
        {
            if (int.TryParse(operation, out int result))
            {
                record.AddLast(result);
            }
            else
            {
                switch (operation)
                {
                    case "+" :
                        var last = record.Last.Value;
                        var prevLast = record.Last.Previous.Value;
                        record.AddLast(last + prevLast);
                        break;
                    case "C" :
                        record.RemoveLast();
                        break;
                    case "D" :
                        record.AddLast(record.Last.Value * 2);
                        break;
                    default :
                        break;
                }
            }
        }

        return record.Sum();

    }
}