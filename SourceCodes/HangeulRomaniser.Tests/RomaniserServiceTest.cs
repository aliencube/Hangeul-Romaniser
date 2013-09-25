using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var result = this._service.Combine(initial, medial, final);

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
        public void SplitLetter_GetLetter_CharactersSplitted(string initial, string medial, string final, string letter)
        {
            var result = this._service.Split(letter);

            Assert.AreEqual(initial, result[0]);
            Assert.AreEqual(medial, result[1]);
            Assert.AreEqual(final, result[2]);
        }

        [Test]
        [TestCase("g", null)]
        public void SplitLetter_GetLetter_NullReturned(string letter, string expected)
        {
            var result = this._service.Split(letter);

            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}
