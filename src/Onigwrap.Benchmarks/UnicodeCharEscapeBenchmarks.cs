using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace Onigwrap.Benchmarks
{
    [MemoryDiagnoser]
    public class UnicodeCharEscapeBenchmarks
    {
        [Benchmark]
        public string Unicode_Patterns_Of_Len_2_Without_Branches()
        {
            return UnicodeCharEscape.AddBracesToUnicodePatterns("[\\xa0-\\xF7]");
        }

        [Benchmark]
        public string Unicode_Patterns_Of_Len_3_Without_Branches()
        {
            return UnicodeCharEscape.AddBracesToUnicodePatterns("[\\xABC-\\xF77]");
        }

        [Benchmark]
        public string Unicode_Patterns_Of_Len_4_Without_Branches()
        {

            return UnicodeCharEscape.AddBracesToUnicodePatterns("[\\xABCD-\\xF777]");
        }

        [Benchmark]
        public string Several_Unicode_Patterns_Without_Branches()
        {
            return UnicodeCharEscape.AddBracesToUnicodePatterns("\\A(?:\\xEF\\xBB\\xBF) ? (? i : (?=\\s* @charset\\b))");
        }

        [Benchmark]
        public string Unicode_Patterns_Of_Len_7_Without_Branches()
        {
            return UnicodeCharEscape.AddBracesToUnicodePatterns("(?i)^\\s*(interface)\\s+([a-z_\\x7f-\\x7ffffff][a-z0-9_\\x7f-\\x7ffffff]*)\\s*(extends)?\\s*");
        }

        [Benchmark]
        public string Unicode_Patterns_Of_Len_8_Without_Branches()
        {
            return UnicodeCharEscape.AddBracesToUnicodePatterns("(?i)^\\s*(interface)\\s+([a-z_\\x7f-\\x7fffffff][a-z0-9_\\x7f-\\x7fffffff]*)\\s*(extends)?\\s*");
        }

        [Benchmark]
        public string Already_Escaped_Unicode_Chars_Should_Not_Be_Escaped_Again()
        {
            return UnicodeCharEscape.AddBracesToUnicodePatterns("(?i)^\\s*(interface)\\s+([a-z_\\x{7f}-\\x{7fffffff}][a-z0-9_\\x{7f}-\\x{7fffffff}]*)\\s*(extends)?\\s*");
        }
    }
}
