using System.Collections.Generic;

namespace KursProject1.Context
{
    class SimplifyContext : IContext
    {
        public bool ToTheSimpliestForm { get; set; }

        public bool IsChanged { get; set; } = true;
        private readonly IDictionary<NodeType, List<IStrategy>> _strategies;

        public SimplifyContext(IStrategiesSetter setter, bool toTheSimpliestForm)
        {
            _strategies = setter.GetStrategies();
            ToTheSimpliestForm = toTheSimpliestForm;
        }

        public ElementOfTree Process(ElementOfTree element)
        {
            if (element.Right != null)
            {
                element.Right = Process(element.Right);
            }
            if (element.Left != null)
            {
                element.Left = Process(element.Left);
            }
            if (ToTheSimpliestForm)
            {
                while (IsChanged)
                {
                    element = ProcessElement(element);
                }
            }
            else
            {
                element = ProcessElement(element);
            }
            return element;
        }
        private ElementOfTree ProcessElement(ElementOfTree element)
        {
            if (_strategies.Keys.Contains(element.Type))
            {
                foreach (var strategy in _strategies[element.Type])
                {
                    element = strategy.Process(element, this);
                }
            }
            return element;
        }
    }
}
