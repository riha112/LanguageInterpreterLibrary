﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RihaInterpreterLibrary.Actions
{
    public class PrintAction : IAction
    {
        public int ArgumentCount { get; } = 0;
        public string ActionName { get; } = "print";
        private const string ValidationPattern = @"print";
        public bool IsValid(string action) => action.ToLower() == ValidationPattern;
        public Node Execute(string[] actionInParts, List<Node> variables)
        {
            if(Output.OutputLines.Count == 0)
                Output.OutputLines.Add("");

            if (variables.Count == 0)
                return null;

            Output.OutputLines[^1] += NodeController.NodeAsText(variables[^1]);
            return variables[^1];
        }
    }
}