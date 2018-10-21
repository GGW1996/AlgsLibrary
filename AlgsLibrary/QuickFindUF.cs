using System;

namespace AlgsLibrary
{
    public class QuickFindUF
    {
        private int[] id;
        private int count;

        public QuickFindUF(int n)
        {
            count = n;
            id = new int[n];
            for (int i = 0; i < n; i++)
                id[i] = i;
        }

        public int getCount()
        {
            return count;
        }

        public int find(int p)
        {
            validate(p);
            return id[p];
        }

        private void validate(int p)
        {
              if (p < 0 || p >= id.Length)
                throw new ArgumentOutOfRangeException("index " + p + " is not between 0 and " + (id.Length - 1));
        }

        public bool connected(int p, int q)
        {
            validate(p);
            validate(q);
            return id[p] == id[q];
        }

        public void union(int p, int q)
        {
            validate(p);
            validate(q);
            int pID = id[p];
            int qID = id[q];

            if (pID == qID) return;

            for (int i = 0; i < id.Length; i++)
                if (id[i] == pID) id[i] = qID;
            count--;
        }
    }
}