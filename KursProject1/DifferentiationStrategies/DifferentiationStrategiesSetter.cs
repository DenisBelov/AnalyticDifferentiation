using System.Collections.Generic;
using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class DifferentiationStrategiesSetter : IStrategiesSetter
    {
        public IDictionary<NodeType, IStrategy> GetStrategies()
        {
            return new Dictionary<NodeType, IStrategy>
            {
                {NodeType.Const, new ConstProcessStrategy()},
                {NodeType.Cos, new CosProcessStrategy()},
                {NodeType.Degree, new DegreeProcessStrategy()},
                {NodeType.Sin, new SinProcessStrategy()},
                {NodeType.Ln, new LogarifmProcessStrategy()},
                {NodeType.Multiply, new MultiplyProcessStrategy()},
                {NodeType.PlusMinus, new PlusMinusProcessStrategy()},
                {NodeType.Divide, new DivideProcessStrategy()},
                {NodeType.X, new XProcessStrategy()},
                {NodeType.Exp, new ExponentProcessStrategy()}
            };
        }
    }
}
