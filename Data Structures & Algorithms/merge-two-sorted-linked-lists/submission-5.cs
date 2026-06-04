
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var ptr1 = list1;
        var ptr2 = list2;
        ListNode current;

        if (ptr1 == null)
            return ptr2;
        if (ptr2 == null)
            return ptr1;

        if (ptr1.val < ptr2.val)
        {
            current = ptr1;
            ptr1 = ptr1.next;
        }
        else
        {
            current = ptr2;
            ptr2 = ptr2.next;
        }

        var head = current;
        
        while (ptr1 is not null && ptr2 is not null)
        {
            if (ptr1.val < ptr2.val)
            {
                current.next = ptr1;
                ptr1 = ptr1.next;
            }
            else
            {
                current.next = ptr2;
                ptr2 = ptr2.next;
            }

            current = current.next;
        }

        if (ptr1 is not null)
        {
            current.next = ptr1;
        }
        else
        {
            current.next = ptr2;
        }

        return head;
    }
}