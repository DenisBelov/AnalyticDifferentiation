using System.Collections.Generic;
using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class SimplifyStrategiesSetter : IStrategiesSetter
    {
        public IDictionary<NodeType, IStrategy> GetStrategies()
        {
            return new Dictionary<NodeType, IStrategy>
            {
                {NodeType.Multiply, new MultiplySimplifyStrategy()},
                {NodeType.PlusMinus, new PlusMinusSimplifyStrategy()}
            };
        }
    }
}
