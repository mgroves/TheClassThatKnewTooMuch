using System;
using System.Linq;
using C = System.Console;

namespace WhatDoesThisDo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = System.Text.RegularExpressions.Regex.Split(C.In.ReadToEnd()
                .ToLower(), @"(?:\b(?:the|and|of|to|a|i[tns]?|or)\b|\W)+")
                .GroupBy(x => x).OrderBy(x => -x.Count()).Take(22);
            var b = a.Select(x => new
            {
                p = new string('_',
                    (int)(x.Count() / a.Max(y => y.Count() / (76d - y.Key.Length)))
                ),
                t = x.Key
            }).ToList();
            C.WriteLine(" " + b[0].p);
            b.ForEach(x => C.WriteLine("|" + x.p + "| " + x.t));
        }
    }
}
