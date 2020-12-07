using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using AdventOfCode2020.Utilities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2020.Day1
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void Example_1()
        {
            var data = LoadInput.LoadInputData(@"./Day1/Input1.txt",
                                               ParseFunction);

            var solution = new Solution(data);
            var answer = solution.WhereCanItFit("shiny gold");

            Assert.AreEqual(4, answer.Count());
        }

        [TestMethod]
        public void Real_1()
        {
            var data = LoadInput.LoadInputData(@"./Day1/Input2.txt",
                                               ParseFunction);

            var solution = new Solution(data);
            var answer = solution.WhereCanItFit("shiny gold");

            Assert.AreEqual(119, answer.Count());
        }

        [TestMethod]
        public void Example_2_1()
        {
            var data = LoadInput.LoadInputData(@"./Day1/Input1.txt",
                                               ParseFunction);

            var solution = new Solution(data);
            var answer = solution.HowManyBagsMustFit("shiny gold");

            Assert.AreEqual(32, answer);
        }

        [TestMethod]
        public void Example_2_2()
        {
            var data = LoadInput.LoadInputData(@"./Day1/Input3.txt",
                                               ParseFunction);

            var solution = new Solution(data);
            var answer = solution.HowManyBagsMustFit("shiny gold");

            Assert.AreEqual(126, answer);
        }

        [TestMethod]
        public void Real_2()
        {
            var data = LoadInput.LoadInputData(@"./Day1/Input2.txt",
                                               ParseFunction);

            var solution = new Solution(data);
            var answer = solution.HowManyBagsMustFit("shiny gold");

            Assert.AreEqual(155802, answer);
        }

        private LuggageRule ParseFunction(string line)
        {
            var lineText = line.Split("contain");
            var lineData = new
            {
                colorSide = lineText[0].Trim(),
                contentSide = lineText[1].Trim()
            };
            var serializedLuggageContent = lineData.contentSide.Split(",");
            var luggageRuleContent = serializedLuggageContent
                                     .Where(c => !c.Contains("no other bags"))
                                     .Select(c =>
                                     {
                                         var ruleText = c.Split("bag")[0].Trim();

                                         return new LuggageContentRule()
                                         {
                                             Quantity = Convert.ToInt32(ruleText.Split(" ")[0]),
                                             Code = ruleText.Remove(0, 1).Trim()
                                         };
                                     });

            return new LuggageRule
            {
                Code = lineData.colorSide.Split("bags")[0].Trim(),
                Content = luggageRuleContent


            };
        }
    }


}

