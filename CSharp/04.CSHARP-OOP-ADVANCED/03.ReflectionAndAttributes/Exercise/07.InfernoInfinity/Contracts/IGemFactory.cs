using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(ClarityEnum clarity, string gemName);
    }
}
