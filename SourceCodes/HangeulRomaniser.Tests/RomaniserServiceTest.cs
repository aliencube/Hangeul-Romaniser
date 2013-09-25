using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HangeulRomaniser.Tests
{
    [TestFixture]
    public class RomaniserServiceTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        [TestCase("ㄱ", "ㅏ", "ㅁ", "감")]
        [TestCase("ㄴ", "ㅏ", "", "나")]
        [TestCase("ㄱ", "ㅜ", "ㄻ", "굶")]
        [TestCase("ㄸ", "ㅜ", "ㄱ", "뚝")]
        [TestCase("ㅃ", "ㅞ", "ㅀ", "쀓")]
        [TestCase("ㄱ", "ㅙ", "ㄴ", "괜")]
        [TestCase("ㅇ", "ㅗ", "", "오")]
        public void CombineCharacters_GetInitialMedialFinal_LetterCombined(string initial, string medial, string final, string expected)
        {
            var initials = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
            var medials = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
            var finals = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

            ushort hangeulStart = 0xAC00;
            ushort hangeulEnd = 0xD79F;

            var indexInitial = initials.IndexOf(initial, StringComparison.Ordinal);
            var indexMedial = medials.IndexOf(medial, StringComparison.Ordinal);
            var indexFinal = String.IsNullOrWhiteSpace(final) ? 0 : finals.IndexOf(final, StringComparison.Ordinal);

            var indexUnicode = hangeulStart + (indexInitial*21 + indexMedial)*28 + indexFinal;
            var result = Convert.ToString(Convert.ToChar(indexUnicode));

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("ㄱ", "ㅏ", "ㅁ", "감")]
        [TestCase("ㄴ", "ㅏ", "", "나")]
        [TestCase("ㄱ", "ㅜ", "ㄻ", "굶")]
        [TestCase("ㄸ", "ㅜ", "ㄱ", "뚝")]
        [TestCase("ㅃ", "ㅞ", "ㅀ", "쀓")]
        [TestCase("ㄱ", "ㅙ", "ㄴ", "괜")]
        [TestCase("ㅇ", "ㅗ", "", "오")]
        //[TestCase("ㅇ", "ㅗ", "", "g")]
        public void SplitLetter_GetLetter_CharactersSplitted(string initial, string medial, string final, string letter)
        {
            var initials = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
            var medials = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
            var finals = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

            ushort hangeulStart = 0xAC00;
            ushort hangeulEnd = 0xD79F;

            var unicode = Convert.ToUInt16(Convert.ToChar(letter));
            if (unicode < hangeulStart || unicode > hangeulEnd)
                Assert.Fail("No Korean Letter");

            var indexUnicode = unicode - hangeulStart;
            var indexInitial = indexUnicode/(21*28);
            indexUnicode = indexUnicode%(21*28);
            var indexMedial = indexUnicode/28;
            indexUnicode = indexUnicode%28;
            var indexFinal = indexUnicode;

            var resultInitial = Convert.ToString(initials[indexInitial]);
            var resultMedial = Convert.ToString(medials[indexMedial]);
            var resultFinal = Convert.ToString(finals[indexFinal]).Trim();

            Assert.AreEqual(initial, resultInitial);
            Assert.AreEqual(medial, resultMedial);
            Assert.AreEqual(final, resultFinal);

        }

        #endregion
    }
}
