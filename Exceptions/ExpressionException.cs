using System;

namespace KursProject1.Exceptions
{
    class ExpressionException : Exception
    {
        public override string Message { get; }

        public string Node {
            get { return _node; } 
            set {
                if (string.IsNullOrWhiteSpace(_node))
                {
                    _node = value;
                }
            }
        }

        private string _node;

        public ExpressionException()
        {

        }
        public ExpressionException(string message)
        {
            Message = message;
        }
    }
}
