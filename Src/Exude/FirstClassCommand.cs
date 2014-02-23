﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Sdk;

namespace Grean.Exude
{
    public class FirstClassCommand : TestCommand
    {
        private readonly Action<object> action;

        public FirstClassCommand(Action<object> action)
            : base(Reflector.Wrap(((Action)(() => { })).Method), "", 0)
        {
            this.action = action;
        }

        public override MethodResult Execute(object testClass)
        {
            this.action(testClass);
            return new PassedResult(
                Reflector.Wrap(((Action)(() => { })).Method),
                null);
        }

        public Action<object> Action
        {
            get { return this.action; }
        }
    }
}
