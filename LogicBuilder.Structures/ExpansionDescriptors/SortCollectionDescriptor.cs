using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SortCollectionDescriptor(ICollection<SortDescriptionDescriptor> sortDescriptions, int? skip = null, int? take = null)
    {
        public ICollection<SortDescriptionDescriptor> SortDescriptions { get; } = sortDescriptions;
        public int? Skip { get; } = skip;
        public int? Take { get; } = take;
    }
}
