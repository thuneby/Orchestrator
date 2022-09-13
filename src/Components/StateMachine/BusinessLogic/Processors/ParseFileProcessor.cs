using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    internal class ParseFileProcessor: IProcessor
    {
        public Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
