using HangeulRomaniser.Services;
using NUnit.Framework;

namespace HangeulRomaniser.Tests
{
    [TestFixture]
    public class RomaniserServiceTest
    {
        private RomaniserService _service;

        #region SetUp / TearDown

        [TestFixtureSetUp]
        public void Init()
        {
            this._service = new RomaniserService();
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
        }

        #endregion SetUp / TearDown

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
            var result = this._service.Combine(initial, medial, final);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase('감', "ㄱ", "ㅏ", "ㅁ")]
        [TestCase('나', "ㄴ", "ㅏ", "")]
        [TestCase('굶',"ㄱ", "ㅜ", "ㄻ")]
        [TestCase('뚝', "ㄸ", "ㅜ", "ㄱ")]
        [TestCase('쀓', "ㅃ", "ㅞ", "ㅀ")]
        [TestCase('괜', "ㄱ", "ㅙ", "ㄴ")]
        [TestCase('오', "ㅇ", "ㅗ", "")]
        [TestCase('그', "ㄱ", "ㅡ", "")]
        [TestCase('으', "ㅇ", "ㅡ", "")]
        [TestCase('ㄱ', "ㄱ", "ㅡ", "")]
        [TestCase('ㅏ', "ㅇ", "ㅏ", "")]
        [TestCase('ㅄ', "ㅇ", "ㅡ", "ㅄ")]
        public void SplitLetter_GetLetter_CharactersSplitted(char letter, string initial, string medial, string final)
        {
            var result = this._service.Split(letter);

            Assert.AreEqual(initial, result[0]);
            Assert.AreEqual(medial, result[1]);
            Assert.AreEqual(final, result[2]);
        }

        [Test]
        [TestCase('g', null)]
        public void SplitLetter_GetLetter_NullReturned(char letter, string expected)
        {
            var result = this._service.Split(letter);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("감", "gam")]
        [TestCase("나", "na")]
        [TestCase("굶", "gum")]
        [TestCase("뚝", "ttuk")]
        [TestCase("쀓", "ppwel")]
        [TestCase("괜", "gwaen")]
        [TestCase("오", "o")]
        [TestCase("그", "geu")]
        [TestCase("으", "eu")]
        [TestCase("ㄱ", "geu")]
        [TestCase("ㅏ", "a")]
        [TestCase("ㅄ", "eup")]
        [TestCase("가격", "ga gyeok")]
        public void RomaniseLetter_GetLetter_LetterRomanised(string letter, string romanised)
        {
            var result = this._service.Romanise(letter);

            Assert.AreEqual(romanised, result);
        }

        [Test]
        [TestCase("g", "")]
        public void RomaniseLetter_GetLetter_EmptyReturned(string letter, string expected)
        {
            var result = this._service.Romanise(letter);

            Assert.AreEqual(expected, result);
        }

        #endregion Tests
    }
}