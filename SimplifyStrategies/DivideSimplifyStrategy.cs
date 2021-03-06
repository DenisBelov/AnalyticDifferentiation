﻿using KursProject1.Context;

namespace KursProject1.SimplifyStrategies {
    class DivideSimplifyStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            if(element.Right.Type == NodeType.Divide && element.Left.Type == NodeType.Const && element.Left.Value == "1")
            {
                element.Left = element.Right.Right;
                element.Right = element.Right.Left;
                return element;
            }
            if(element.Left.Type == NodeType.Const && element.Left.Value == "0")
            {
                element = element.Right;
                return element;
            }
            if (element.Left.Type == NodeType.MinusU && element.Left.Left.Value == "0")
            {
                element = element.Right;
                return element;
            }
            if (element.Right.Type == NodeType.Const && element.Right.Value == "1")
            {
                element = element.Left;
                return element;
            }
            ((SimplifyContext) context).IsChanged = false;
            return element;
        }
    }
}
