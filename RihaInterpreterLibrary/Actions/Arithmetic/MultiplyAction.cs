﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RihaInterpreterLibrary.Actions.Arithmetic
{
    /// <summary>
    /// Implements multiplication action into interpreter.
    /// </summary>
    public class MultiplyAction : IAction
    {
        public int ArgumentCount { get; } = 2;
        public string ActionName { get; } = "arithmetic.multiply";
        private const string ValidationPattern = @"arithmetic.multiply";
        public bool IsValid(string action) => action.ToLower() == ValidationPattern;
        public Node Execute(string[] actionInParts, List<Node> variables)
        {
            var output = new Node
            {
                Type = ValueType.Number,
                Value = NodeController.NodeAsNumber(variables[^1]) * NodeController.NodeAsNumber(variables[^2])
            };
            return output;
        }
    }
}
