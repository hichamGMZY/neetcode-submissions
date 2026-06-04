public class MyStack
{
    private Queue<int> pushqQueue = new Queue<int>();
    private Queue<int> popqQueue = new Queue<int>();
    public MyStack() {
        
    }
    
    public void Push(int x) {
        pushqQueue.Enqueue(x);
    }
    
    public int Pop() {
        while (pushqQueue.Count > 1)
        {
            popqQueue.Enqueue(pushqQueue.Dequeue());
        }
        
        var ptr = pushqQueue.Dequeue();
        (popqQueue, pushqQueue) = (pushqQueue, popqQueue);
        return ptr;
    }
    
    public int Top() {
        while (pushqQueue.Count > 1)
        {
            popqQueue.Enqueue(pushqQueue.Dequeue());
        }

        return pushqQueue.Peek();
    }
    
    public bool Empty() {
        return pushqQueue.Count + popqQueue.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */