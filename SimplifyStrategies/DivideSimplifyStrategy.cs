using KursProject1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject1.SimplifyStrategies {
    class DivideSimplifyStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            if(element.Right.Type == NodeType.Divide && element.Left.Type == NodeType.Const && element.Left.Node == "1")
            {
                element.Left = element.Right.Right;
                element.Right = element.Right.Left;
                return element;
            }
            if(element.Right.Type == NodeType.Const && element.Right.Node == "0")
            {
                element = element.Right;
                return element;
            }
            return element;
        }
    }
}
