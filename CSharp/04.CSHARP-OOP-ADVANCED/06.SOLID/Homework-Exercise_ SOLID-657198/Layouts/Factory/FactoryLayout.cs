using Solid.Logger.Layouts.Contracts;
using Solid.Logger.Layouts.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Layouts.Factory
{
    public class FactoryLayout : IFactoryLayout
    {
        public ILayout CretaeLayout(string type)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout tyupe!");
            }
        }
    }
}
