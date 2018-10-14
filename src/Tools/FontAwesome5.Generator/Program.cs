﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontAwesome5.Generator
{
    class Program
    {
        static StringBuilder _content = new StringBuilder();
        static Stack<string> _indent =  new Stack<string>();

        static void Main(string[] args)
        {
            Generate(args[0]);
        }

        static void Generate(string inputDirectory)
        {
            string outputFile = Path.Combine(inputDirectory, @"FontAwesome5\EFontAwesomeIcon.cs");            
            var configFile = Path.Combine(inputDirectory, @"Font-Awesome\advanced-options\metadata\icons.json");

            var fa = new FontAwesomeManager(configFile);

            WriteLine("//------------------------------------------------------------------------------");
            WriteLine("// <auto-generated>");
            WriteLine("//     This code was generated by a tool");
            WriteLine("//");
            WriteLine("//     Changes to this file may cause incorrect behavior and will be lost if");
            WriteLine("//     the code is regenerated.");
            WriteLine("// </auto-generated>");
            WriteLine("//------------------------------------------------------------------------------");

            WriteLine("using System;");
            WriteLine("using System.ComponentModel;");
            WriteLine("namespace FontAwesome5");
            WriteLine("{");
            PushIndent("\t");

            WriteLine("/// <summary>");
            WriteLine("/// FontAwesome by Dave Gandy (@davegandy)");
            WriteLine("///	The iconic SVG, font, and CSS toolkit");
            WriteLine("///	License https://fontawesome.com/license (C#: MIT License)");
            WriteLine("/// </summary>");
            WriteLine("public enum EFontAwesomeStyle");
            WriteLine("{");
            PushIndent("\t");
            WriteSummary("This Style is used as an undefined state.");
            WriteLine("None,");
            WriteLine("");
            foreach (EStyles style in Enum.GetValues(typeof(EStyles)))
            {
                WriteSummary("FontAwesome5 {0} Style", style);
                WriteLine("{0},", style);
                WriteLine("");
            }
            PopIndent();
            WriteLine("}");

            WriteLine("");
            WriteLine("///<summary>FontAwesome5 Icons</summary>");
            WriteLine("public enum EFontAwesomeIcon");
            WriteLine("{");
            PushIndent("\t");
            WriteSummary("Set this value to show no icon.");
            WriteLine("None = 0x0,");
            WriteLine("");

            foreach (EStyles style in Enum.GetValues(typeof(EStyles)))
            {
                foreach (var kvp in fa.Icons.Where(i => i.Value.styles.Contains(style.ToString().ToLower())))
                {
                    WriteSummary(kvp.Value.label);
                    WriteLine("///<see href=\"http://fontawesome.com/icons/{0}?style={1}\" />", kvp.Key, style.ToString().ToLower());
                    WriteLine("[FontAwesomeInformation(\"{0}\", EFontAwesomeStyle.{1}, 0x{2})]", kvp.Value.label, style.ToString(), kvp.Value.unicode);

                    if (kvp.Value.svg.TryGetValue(style.ToString().ToLower(), out var svgInfo))
                    {
                        WriteLine("[FontAwesomeSvgInformation(\"{0}\", {1}, {2})]", svgInfo.path, svgInfo.width, svgInfo.height);
                    }
                    WriteLine("{0}_{1},", style, fa.Convert(kvp.Key));
                    WriteLine("");
                }
            }

            PopIndent();
            WriteLine("}");

            WriteLine("");
            WriteSummary("FontAwesome Information Attribute");
            WriteLine("public class FontAwesomeInformationAttribute : Attribute");
            WriteLine("{");
            PushIndent("\t");
            WriteSummary("FontAwesome Style");
            WriteLine("public EFontAwesomeStyle Style { get; set; }");
            WriteSummary("FontAwesome Label");
            WriteLine("public string Label { get; set; }");
            WriteSummary("FontAwesome Unicode");
            WriteLine("public int Unicode { get; set; }");
            WriteLine("");
            WriteLine("public FontAwesomeInformationAttribute(string label, EFontAwesomeStyle style, int unicode)");
            WriteLine("{");
            WriteLine("    Label = label;");
            WriteLine("    Style = style;");
            WriteLine("    Unicode = unicode;");
            WriteLine("}");
            PopIndent();
            WriteLine("}");


            WriteLine("");
            WriteSummary("FontAwesome SVG Information Attribute");
            WriteLine("public class FontAwesomeSvgInformationAttribute : Attribute");
            WriteLine("{");
            PushIndent("\t");
            WriteSummary("FontAwesome SVG Path");
            WriteLine("public string Path { get; set; }");
            WriteSummary("FontAwesome SVG Width");
            WriteLine("public int Width { get; set; }");
            WriteSummary("FontAwesome SVG Height");
            WriteLine("public int Height { get; set; }");
            WriteLine("");
            WriteLine("public FontAwesomeSvgInformationAttribute(string path, int width, int height)");
            WriteLine("{");
            WriteLine("    Path = path;");
            WriteLine("    Width = width;");
            WriteLine("    Height = height;");
            WriteLine("}");
            PopIndent();
            WriteLine("}");

            PopIndent();
            WriteLine("}");

            File.WriteAllText(outputFile, _content.ToString());
        }

        static void WriteSummary(string text)
        {
            WriteLine("/// <summary>");
            WriteLine("/// {0}", text);
            WriteLine("/// </summary>");
        }

        static void WriteSummary(string format, params object[] parameter)
        {
            WriteLine("/// <summary>");
            WriteLine("/// " + format, parameter);
            WriteLine("/// </summary>");
        }

        static void WriteLine(string text)
        {
            _content.AppendLine(GetIndent() + text);
        }

        static void WriteLine(string text, params object[] parameter)
        {
            _content.AppendLine(GetIndent() + string.Format(text, parameter));
        }

        static void PushIndent(string indent)
        {
            _indent.Push(indent);
        }

        static void PopIndent()
        {
            _indent.Pop();
        }

        static string GetIndent()
        {
            string indent = "";
            foreach (var entry in _indent)
                indent += entry;

            return indent;
        }

    }
}
