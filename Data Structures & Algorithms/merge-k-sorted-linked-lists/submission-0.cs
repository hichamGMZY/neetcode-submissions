public class Solution {    
    public ListNode? MergeKLists(ListNode?[] lists)
    {
        ListNode? head = null;
        ListNode? current = null;

        while (true)
        {
            ListNode? minNode = null;
            int minIndex = -1;
            
            for (int i = 0; i < lists.Length; i++)
            {
                var node = lists[i];
                if (node is null)
                {
                    continue;
                }

                if (minNode is null)
                {
                    minNode = node;
                    minIndex = i;
                    continue;
                }

                if (node.val < minNode.val)
                {
                    minNode = node;
                    minIndex = i;
                }
            }
            
            if (minNode is null)
            {
                return head;
            }

            if (head is null)
                head = minNode;

            if (current is not null)
                current.next = minNode;
            current = minNode;
            lists[minIndex] = minNode.next;
        }
    }
}