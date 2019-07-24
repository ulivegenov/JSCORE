namespace Solid.Layouts.Factory
{
    using Solid.Layouts.Contracts;
    using Solid.Layouts.Factory.Contracts;

    using System;
   
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeLowerCase = type.ToLower();
            switch (typeLowerCase)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
