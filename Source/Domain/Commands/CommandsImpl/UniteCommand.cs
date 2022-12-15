﻿using RandomDomainGenerator.Domain.Loggers;

namespace RandomDomainGenerator.Domain.Commands.CommandsImpl
{
    internal class UniteCommand : CommandBase
    {
        public UniteCommand(IClientLogger logger) : base(logger)
        {
        }

        protected override void Execute(Parameter[] parameters)
        {
            Console.WriteLine(ToString());
        }
    }
}