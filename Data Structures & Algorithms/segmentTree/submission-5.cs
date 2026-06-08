class SegmentTree {

    public static void Test()
    {
        int[] nums = [1, 2, 3, 4, 5];
        var tree = new SegmentTree(nums);
        var res = tree.query(0, 2);
        Console.WriteLine(res);
    }
    
    
    private int L;
    private int R;
    private SegmentTree left;
    private SegmentTree right;
    private int sum;

    private SegmentTree(int total, int l, int r)
    {
        this.sum = total;
        this.L = l;
        this.R = r;
    }

    private static SegmentTree Build(int[] nums, int l, int r)
    {
        if (l == r)
            return new SegmentTree(nums[l], l, r);

        var root = new SegmentTree(0, l, r);
        var m = (l + r) / 2;
        root.left = SegmentTree.Build(nums, l, m);
        root.right = SegmentTree.Build(nums, m + 1, r);
        root.sum = root.left.sum + root.right.sum;
        return root;
    }
    
    public SegmentTree(int[] nums) {
        if (nums.Length == 1)
        {
            L = 0;
            R = 0;
            sum = nums[0];
            return;
        }

        L = 0;
        R = nums.Length - 1;
        int m = (L + R) / 2;
        left = Build(nums, L, m);
        right = Build(nums, m+1, R);
        sum = left.sum + right.sum;
    }
    
    public void update(int index, int val)
    {
        if (L == R && L == index)
        {
            sum = val;
            return;
        }

        var m =  (L + R) / 2;
        if (index <= m)
            left.update(index, val);
        else
            right.update(index, val);
        sum = left.sum + right.sum;
    }

    public int query(int l, int r) {
        if (L == l && r == R )
        {
            return sum;
        }

        var m = (L + R) / 2;
        if (l > m)
            return right.query(l, r);
        else if (r <= m)
            return left.query(l, r);
        else
            return left.query(l, m) + right.query(m + 1, r);
    }
}