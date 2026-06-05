public class UnionFind
{

    private int[] _parents;
    private int[] _ranks;
    public UnionFind(int n)
    {
        _parents = new int[n];
        _ranks = new int[n];
        for (int i = 0; i < n; i++)
        {
            _parents[i] = i;
            _ranks[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (_parents[x] != x)
            _parents[x] = Find(_parents[x]);
        return _parents[x];
    }

    public bool Union(int x, int y)
    {
        var p1 = Find(x);
        var p2 = Find(y);
        if (p1 == p2)
            return false;

        var rank1 = _ranks[p1];
        var rank2 = _ranks[p2];
        if (rank1 > rank2)
        {
            _parents[p2] = p1;
        } else if (rank2 > rank1)
        {
            _parents[p1] = p2;
        }
        else
        {
            _parents[p1] = p2;
            _ranks[p2]++;
        }

        return true;
    }

    public bool IsSameComponent(int x, int y) {
        var p1 =  Find(x);
        var p2 =  Find(y);
        return p1 == p2;
    }

    public int GetNumComponents()
    {
        return _parents.Select(Find).ToHashSet().Count;
    }
}