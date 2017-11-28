using System.Collections.Generic;

namespace KursProject1.Context
{
    interface IStrategiesSetter
    {
        IDictionary<NodeType, List<IStrategy>> GetStrategies();
    }
}
