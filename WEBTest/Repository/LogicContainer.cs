using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRepairShop;

namespace WEBTest.Repository
{
    public class LogicContainer : ILogicContainer
    {
        private readonly Logic _logic;

        public LogicContainer()
        {
            _logic = new Logic();
        }

        public Logic GetLogic()
        {
            return _logic;
        }
    }
}
