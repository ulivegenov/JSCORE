

namespace Solid.Layouts.Factory.Contracts
{
    using Solid.Layouts.Contracts;

    public interface ILayOutFactory
    {
        ILayout CreateLayOut(string type);
    }
}
