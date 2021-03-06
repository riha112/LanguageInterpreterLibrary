﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RihaInterpreterLibrary.Actions
{
    public class PrintLineAction : IAction
    {
        public int ArgumentCount { get; } = 0;
        public string ActionName { get; } = "print_line";
        private const string ValidationPattern = @"print_line";
        public bool IsValid(string action) => action.ToLower() == ValidationPattern;
        public Node Execute(string[] actionInParts, List<Node> variables)
        {
            variables.Reverse();
            var value = variables.Aggregate("", (current, variable) => current + NodeController.NodeAsText(variable));
            var node = new Node(value, ValueType.Text);
            Output.Add(NodeController.NodeAsText(node));
            return node;
        }
    }
}
