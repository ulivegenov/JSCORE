using Solid.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Layouts.Factory.Contracts
{
    public interface IFactoryLayout
    {
        ILayout CretaeLayout(string type);
    }
}
