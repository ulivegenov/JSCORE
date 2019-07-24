
namespace Solid.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public interface ICommand
    {
        void AddAppender(string[] args);
        void AddMessage(string[] args);
        void Print();
    }
}
