namespace KursProject1.Context
{
    interface IStrategy
    {
        ElementOfTree Process(ElementOfTree element, IContext context);
    }
}
