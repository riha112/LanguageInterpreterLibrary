﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RihaInterpreterLibrary.Actions.Compare
{
    public class EqualTypeAction : IAction
    {
        public int ArgumentCount { get; } = 2;
        public string ActionName { get; } = "compare.equal_type";
        private const string ValidationPattern = @"compare.equal_type";
        public bool IsValid(string action) => action.ToLower() == ValidationPattern;

        public Node Execute(string[] actionInParts, List<Node> variables) =>
            new Node(variables[^1].Type == variables[^2].Type, ValueType.Boolean);
    }
}
