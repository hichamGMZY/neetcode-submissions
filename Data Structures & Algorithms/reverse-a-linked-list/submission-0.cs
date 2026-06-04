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
    public ListNode ReverseList(ListNode head) {
        
        ListNode ptr = head;
        ListNode? previous = null;
        while(ptr != null){
            var next = ptr.next;
            ptr.next = previous;
            previous = ptr;
            ptr = next;
        } 
        return previous;
    }
}
