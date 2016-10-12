// Chronological backtracking algorithm from
// "Foundations of Constraint Satisfaction"
// by Edward Tsang page 37

using System;
using System.Collections.Generic;
using System.Linq;

namespace ChronoBacktrackCS
{
	class ChronoBacktrack
	{
		int constraintsViolated(int[] Q)
		{
			int a, b, c = 0, i, j, n;

			n = Q.Length;
			for (i = 0; i < n; i++)
			{
				a = Q[i];
				for (j = 0; j < n; j++)
				{
					b = Q[j];
					if (i != j && a != -1 && b != -1)
					{
						if (a == b) c++;
						if (i - j == a - b || i - j == b - a) c++;
					}
				}
			}
			return c;
		}

		public bool Backtrack(List<int> unlabelled, ref int[] compoundLabel,
			ref List<int> solution, ref Random rand)
		{
            bool result;
            int i, j, v, x;
            List<int> Dx = new List<int>();
            
            if (unlabelled.Count == 0)
            {
                for (i = 0; i < compoundLabel.Length; i++)
                    solution.Add(compoundLabel.ElementAt<int>(i));
                return true;
            }
            for (i = 0; i < compoundLabel.Length; i++)
                Dx.Insert(i, i);
            // pick a random variable from unlabelled array
            i = rand.Next(unlabelled.Count);
            x = unlabelled.ElementAt<int>(i);
            do 
            {
                // pick a random value from domain of x
                j = rand.Next(Dx.Count);
                v = Dx.ElementAt<int>(j);
                Dx.RemoveAt(j);
                compoundLabel[x] = v;
                if (constraintsViolated(compoundLabel) == 0)
                {
                    int index;

                    for (index = 0; index < unlabelled.Count; )
                    {
                        if (unlabelled.ElementAt<int>(index) == x)
                            break;
                        else
                            index++;
                    }
                    unlabelled.RemoveAt(index);
                    result = Backtrack(unlabelled, ref compoundLabel, ref solution, ref rand);
                    if (result)
                        return result;
                    unlabelled.Add(x);
                }
                else
                    compoundLabel[x] = -1;
            } while (Dx.Count != 0);
            return false;
        }
	}
}