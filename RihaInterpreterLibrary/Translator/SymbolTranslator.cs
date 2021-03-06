﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RihaInterpreterLibrary.Translator
{
    public class SymbolTranslator: ITranslator
    {
        public int PriorityId { get; set; } = 30;

        private static readonly Dictionary<string, (string splitter, string replacer)> Library = new Dictionary<string, (string, string)>()
        {
            { @"\=\=\=",   ("===","compare.equal") },
            { @"\=\=",   ("==","compare.equal_value") },
            { @"\@\=", ("@=","set")},
            { @"\+\=", ("+=","add") },
            { @"\-\=", ("-=","remove") },
            { @"\=",   ("=","update") },
            { @"\+",   ("+","arithmetic.sum") },
            { @"\>",   (">","compare.larger") },
            { @"\<",   ("<","compare.smaller") },
            { @"\*",   ("*","arithmetic.multiply") },
            { @"\%",   ("%","arithmetic.module") },
        };

        public string Translate(string code)
        {
            foreach (var entire in Library)
            {
                code = Regex.Replace(code, @"\s*-?[\w\d\[\]\,]+\s*" + entire.Key+ @"\s*-?[\w\d\[\]\,]+\s*", m =>
                {
                    // Gets value without quotes
                    var value = m.ToString().Replace(" ", "");

                    var prefix = value[0] == '\n' ? "\n" : "";
                    var suffix = value[^1] == '\n' ? "\n" : "";

                    var parts = value.Replace("\n", "").Split(entire.Value.splitter);

                    return entire.Value.replacer.Equals("set") ? 
                        $"{prefix}set {parts[0]} as auto:{parts[1]}{suffix}" : 
                        $"{prefix}{entire.Value.replacer}:{parts[0]}:{parts[1]}{suffix}";
                });
            }
            return code;
        }
    }
}
