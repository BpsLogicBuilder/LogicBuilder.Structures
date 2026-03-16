using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SortCollectionDescriptor(ICollection<SortDescriptionDescriptor> sortDescriptions, int skip = 0, int take = int.MaxValue)
    {
        public ICollection<SortDescriptionDescriptor> SortDescriptions { get; set; } = sortDescriptions;
        public int Skip { get; set; } = skip;
        public int Take { get; set; } = take;
    }
}
