namespace Solid.Layouts.Factory.Contracts
{
    using Solid.Layouts.Contracts;
    
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
