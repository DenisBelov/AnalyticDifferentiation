using KursProject1.Context;

namespace KursProject1
{
    class Tree
    {
        public ElementOfTree Head { get; private set; }
        
        public Tree(string s, NodeTypeDeterminator determinator)
        {
            Head = new ElementOfTree();
            Head.S(s);
            determinator.Determinate(Head);
        }

        public void ProcessTree(IContext processContext)
        {
            Head = processContext.Process(Head);
        }
    }
}
