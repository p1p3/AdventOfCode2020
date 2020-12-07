using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day1
{
    public class Solution
    {
        private readonly Dictionary<string, Dictionary<string, int>> rules;

        public Solution(IEnumerable<LuggageRule> data)
        {
            this.rules = data.ToDictionary(d => d.Code, d => d.Content.ToDictionary(c => c.Code, c => c.Quantity));
        }

        public IEnumerable<string> WhereCanItFit(string code)
        {
            var whoContainsIt = this.rules
                                     .Where(x => x.Value.ContainsKey(code))
                                     .Aggregate(new List<string>(), (acc, curr) =>
                                        {
                                            var containsThis = this.WhereCanItFit(curr.Key);
                                            acc.Add(curr.Key);
                                            acc.AddRange(containsThis);

                                            return acc;
                                        });

            return whoContainsIt.Distinct();
        }

        public int HowManyBagsMustFit(string code)
        {
            var mustFit = this.rules[code]
                              .Aggregate(0, (acc, curr) =>
                              {
                                  var howMany = this.HowManyBagsMustFit(curr.Key);
                                  acc += howMany * curr.Value + curr.Value;
                                  return acc;
                              });

            return mustFit;
        }
    }

    public class LuggageRule
    {
        public string Code { get; set; }

        public IEnumerable<LuggageContentRule> Content { get; set; }

    }

    public class LuggageContentRule
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
}
