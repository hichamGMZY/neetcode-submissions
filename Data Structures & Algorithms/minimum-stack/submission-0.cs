

public class MinStack {

    public class StackNode
    {
        public int Value { get; set; }
        public StackNode? Previous { get; set; }
        public int Min { get; set; }
    }

    private StackNode? head = null;
    
    public MinStack() {
        
    }
    
    public void Push(int val)
    {
        var node = new StackNode()
        {
            Value = val,
            Previous = head,
            Min = head == null ? val : Math.Min(head.Min, val)
        };
        head = node;
    }
    
    public void Pop() {
        if (head != null)
        {
            head = head.Previous;
        }
    }
    
    public int Top()
    {
        return head.Value;
    }
    
    public int GetMin()
    {
        return head.Min;
    }
}