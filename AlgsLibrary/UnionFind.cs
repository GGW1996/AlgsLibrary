using System;

namespace AlgsLibrary
{
    public class UnionFind
    {

        private int[] parent;
        private byte[] rank;
        private int count;

        public UnionFind(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("Value n must be positive");
            count = n;
            parent = new int[n];
            rank = new byte[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int find(int p)
        {
            validate(p);
            while (p != parent[p])
            {
                parent[p] = parent[parent[p]];
                p = parent[p];
            }
            return p;
        }

        public int getCount()
        {
            return count;
        }

        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }

        public void union(int p, int q)
        {
            int rootP = find(p);
            int rootQ = find(q);
            if (rootP == rootQ) return;

            if (rank[rootP] < rank[rootQ])
                parent[rootP] = rootQ;
            else if 
                (rank[rootP] > rank[rootQ]) parent[rootQ] = rootP;
            else
            {
                parent[rootQ] = rootP;
                rank[rootP]++;
            }
            count--;
        }

        private void validate(int p)
        {
            int n = parent.Length;
            if (p < 0 || p >= n)
                throw new ArgumentOutOfRangeException("index " + p + " is not between 0 and " + (n - 1));
        }
    }
}