using System.Collections.Generic;


namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            if(list.Count <= 1)
            {
                return;
            }
        }

    }
}
