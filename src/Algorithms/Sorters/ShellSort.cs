using System.Collections.Generic;


namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            var gaps = new int[] {3, 1 };


            //8, 1, 7, 3, 0, 6, 6, 2
            //8, 3, 6
            //3, 1, 7, 3, 0, 6, 6, 2

            foreach (var gap in gaps)
            {
                for (int i = gap; i < list.Count; i++)
                {
                    var temp = list[i];


                    int j = i;

                    while (j >= gap && list[j - gap] > temp)
                    {
                        list[j] = list[j - gap];
                        j -= gap;
                    }

                    list[j] = temp;
                }
            }
        }

    }
}
