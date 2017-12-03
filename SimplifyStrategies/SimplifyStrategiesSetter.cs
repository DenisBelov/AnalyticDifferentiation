using System.Collections.Generic;
using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class SimplifyStrategiesSetter : IStrategiesSetter
    {
        public IDictionary<NodeType, List<IStrategy>> GetStrategies()
        {
            return new Dictionary<NodeType, List<IStrategy>>
            {
                {NodeType.Multiply,  new List<IStrategy>{new MultiplySimplifyStrategy(), new NodeOrderSimplifyStrategy()}},
                {NodeType.PlusMinus,  new List<IStrategy>{new PlusMinusSimplifyStrategy()}},
                {NodeType.Degree, new List<IStrategy>{new DegreeSimplifyStrategy()} },
                {NodeType.Divide, new List<IStrategy>{new DivideSimplifyStrategy()} },
            };
        }
    }
}
