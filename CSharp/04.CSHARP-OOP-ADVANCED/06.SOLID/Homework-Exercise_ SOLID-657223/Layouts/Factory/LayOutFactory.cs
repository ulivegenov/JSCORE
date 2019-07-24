

namespace Solid.Layouts.Factory
{
    using Solid.Layouts.Contracts;
    using Solid.Layouts.Factory.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LayOutFactory : ILayOutFactory
    {
        public ILayout CreateLayOut(string type)
        {
            string typeLower = type.ToLower();
            switch (typeLower)
            {
                case "simplelayout":
                    return new SimpleLayOut();
                case "xmllayout":
                    return new XmlLayOut();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
