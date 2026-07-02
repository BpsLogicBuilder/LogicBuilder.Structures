using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.Strutures
{
    public class SortCollection(ICollection<SortDescription> sortDescriptions, int? skip = null, int? take = null)
    {
        public ICollection<SortDescription> SortDescriptions { get; } = sortDescriptions;
        public int Skip { get; } = skip ?? 0;
        public int Take { get; } = take ?? int.MaxValue;
    }
}
