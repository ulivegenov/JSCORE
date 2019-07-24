using _07InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Commands
{
    public abstract class Command : IExecutable
    {
        public Command(string data, IRepository repository)
        {
            this.Data = data;
            this.Repository = repository;
        }

        public string Data { get; private set; }

        public IRepository Repository { get; private set; }

        public abstract void Execute();
    }
}
