using System.Collections.Generic;

namespace HangeulRomaniser.Services
{
    /// <summary>
    /// This represents romaniser service entity.
    /// </summary>
    public partial class RomaniserService
    {
        #region Properties

        private IList<KeyValuePair<char, string>> _initials = new List<KeyValuePair<char, string>>()
                                                              {
                                                                  new KeyValuePair<char, string>('ㄱ', "g"),
                                                                  new KeyValuePair<char, string>('ㄲ', "kk"),
                                                                  new KeyValuePair<char, string>('ㄴ', "n"),
                                                                  new KeyValuePair<char, string>('ㄷ', "d"),
                                                                  new KeyValuePair<char, string>('ㄸ', "tt"),
                                                                  new KeyValuePair<char, string>('ㄹ', "r"),
                                                                  new KeyValuePair<char, string>('ㅁ', "m"),
                                                                  new KeyValuePair<char, string>('ㅂ', "b"),
                                                                  new KeyValuePair<char, string>('ㅃ', "pp"),
                                                                  new KeyValuePair<char, string>('ㅅ', "s"),
                                                                  new KeyValuePair<char, string>('ㅆ', "ss"),
                                                                  new KeyValuePair<char, string>('ㅇ', ""),
                                                                  new KeyValuePair<char, string>('ㅈ', "j"),
                                                                  new KeyValuePair<char, string>('ㅉ', "jj"),
                                                                  new KeyValuePair<char, string>('ㅊ', "ch"),
                                                                  new KeyValuePair<char, string>('ㅋ', "k"),
                                                                  new KeyValuePair<char, string>('ㅌ', "t"),
                                                                  new KeyValuePair<char, string>('ㅍ', "p"),
                                                                  new KeyValuePair<char, string>('ㅎ', "h")
                                                              };

        private IList<KeyValuePair<char, string>> _medials = new List<KeyValuePair<char, string>>()
                                                             {
                                                                 new KeyValuePair<char, string>('ㅏ', "a"),
                                                                 new KeyValuePair<char, string>('ㅐ', "ae"),
                                                                 new KeyValuePair<char, string>('ㅑ', "ya"),
                                                                 new KeyValuePair<char, string>('ㅒ', "yae"),
                                                                 new KeyValuePair<char, string>('ㅓ', "eo"),
                                                                 new KeyValuePair<char, string>('ㅔ', "e"),
                                                                 new KeyValuePair<char, string>('ㅕ', "yeo"),
                                                                 new KeyValuePair<char, string>('ㅖ', "ye"),
                                                                 new KeyValuePair<char, string>('ㅗ', "o"),
                                                                 new KeyValuePair<char, string>('ㅘ', "wa"),
                                                                 new KeyValuePair<char, string>('ㅙ', "wae"),
                                                                 new KeyValuePair<char, string>('ㅚ', "oe"),
                                                                 new KeyValuePair<char, string>('ㅛ', "yo"),
                                                                 new KeyValuePair<char, string>('ㅜ', "u"),
                                                                 new KeyValuePair<char, string>('ㅝ', "wo"),
                                                                 new KeyValuePair<char, string>('ㅞ', "we"),
                                                                 new KeyValuePair<char, string>('ㅟ', "wi"),
                                                                 new KeyValuePair<char, string>('ㅠ', "yu"),
                                                                 new KeyValuePair<char, string>('ㅡ', "eu"),
                                                                 new KeyValuePair<char, string>('ㅢ', "ui"),
                                                                 new KeyValuePair<char, string>('ㅣ', "i")
                                                             };

        private IList<KeyValuePair<char, string>> _finals = new List<KeyValuePair<char, string>>()
                                                            {
                                                                new KeyValuePair<char, string>(' ', ""),
                                                                new KeyValuePair<char, string>('ㄱ', "k"),
                                                                new KeyValuePair<char, string>('ㄲ', "k"),
                                                                new KeyValuePair<char, string>('ㄳ', "k"),
                                                                new KeyValuePair<char, string>('ㄴ', "n"),
                                                                new KeyValuePair<char, string>('ㄵ', "n"),
                                                                new KeyValuePair<char, string>('ㄶ', "n"),
                                                                new KeyValuePair<char, string>('ㄷ', "t"),
                                                                new KeyValuePair<char, string>('ㄹ', "l"),
                                                                new KeyValuePair<char, string>('ㄺ', "k"),
                                                                new KeyValuePair<char, string>('ㄻ', "m"),
                                                                new KeyValuePair<char, string>('ㄼ', "p"),
                                                                new KeyValuePair<char, string>('ㄽ', "l"),
                                                                new KeyValuePair<char, string>('ㄾ', "l"),
                                                                new KeyValuePair<char, string>('ㄿ', "l"),
                                                                new KeyValuePair<char, string>('ㅀ', "l"),
                                                                new KeyValuePair<char, string>('ㅁ', "m"),
                                                                new KeyValuePair<char, string>('ㅂ', "p"),
                                                                new KeyValuePair<char, string>('ㅄ', "p"),
                                                                new KeyValuePair<char, string>('ㅅ', "t"),
                                                                new KeyValuePair<char, string>('ㅆ', "t"),
                                                                new KeyValuePair<char, string>('ㅇ', "ng"),
                                                                new KeyValuePair<char, string>('ㅈ', "t"),
                                                                new KeyValuePair<char, string>('ㅊ', "t"),
                                                                new KeyValuePair<char, string>('ㅋ', "k"),
                                                                new KeyValuePair<char, string>('ㅌ', "t"),
                                                                new KeyValuePair<char, string>('ㅍ', "p"),
                                                                new KeyValuePair<char, string>('ㅎ', "h")
                                                            };

        #endregion Properties
    }
}