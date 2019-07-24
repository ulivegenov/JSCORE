using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Lake : IEnumerable<int>
{
    private readonly IList<int> stones;

    public Lake(int[] stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i += 2)
        {
            yield return this.stones[i];
        }
        if ((this.stones.Count % 2) == 0)
        {
            for (int i = this.stones.Count - 1; i > 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }
        else
        {
            for (int i = this.stones.Count - 2; i > 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.stones.GetEnumerator();
    }
}

