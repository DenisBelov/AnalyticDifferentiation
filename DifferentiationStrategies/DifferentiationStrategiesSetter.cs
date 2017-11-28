using System.Collections.Generic;
using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class DifferentiationStrategiesSetter : IStrategiesSetter
    {
        public IDictionary<NodeType, List<IStrategy>> GetStrategies()
        {
            return new Dictionary<NodeType, List<IStrategy>>
            {
                {NodeType.Const, new List<IStrategy>{ new ConstProcessStrategy()}},
                {NodeType.Cos,  new List<IStrategy>{new CosProcessStrategy()}},
                {NodeType.Degree,  new List<IStrategy>{new DegreeProcessStrategy()}},
                {NodeType.Sin,  new List<IStrategy>{new SinProcessStrategy()}},
                {NodeType.Ln,  new List<IStrategy>{new LogarifmProcessStrategy()}},
                {NodeType.Multiply,  new List<IStrategy>{new MultiplyProcessStrategy()}},
                {NodeType.PlusMinus,  new List<IStrategy>{new PlusMinusProcessStrategy()}},
                {NodeType.Divide,  new List<IStrategy>{new DivideProcessStrategy()}},
                {NodeType.X,  new List<IStrategy>{new XProcessStrategy()}},
                {NodeType.Exp,  new List<IStrategy>{new ExponentProcessStrategy()}},
                {NodeType.Tan, new List<IStrategy> {new TanProcessStrategy() } },
                {NodeType.MinusU, new List<IStrategy> {new MinusUProcessStrategy() } },
                {NodeType.Sqrt, new List<IStrategy> {new SqrtProcessStrategy() } }
            };
        }
    }
}
