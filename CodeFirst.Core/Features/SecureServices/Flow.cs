using CodeFirst.Core.Interfaces.Services;
using System;

namespace CodeFirst.Core.Features.SecureServices
{
    public class Flow
    {
        private ISecure _ticket;
        public Flow()
        {

        }

        public Flow(ISecure ticket)
        {
            this._ticket = ticket;
        }

        public void SetStrategyFlujo(ISecure strategy)
        {
            this._ticket = strategy;
        }

        public void FlowLogic()
        {
            Console.WriteLine("initialize the business logic ");
            this._ticket.CreateSecure();

        }
    }
}
