using HangeulRomaniser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangeulRomaniser.Services
{
    public partial class RomaniserService : IRomaniserService
    {
        #region Constructors

        #endregion Constructors

        #region Constants

        private const ushort FIRST_HANGEUL_UNICODE = 0xAC00;
        private const ushort LAST_HANGEUL_UNICODE = 0xD79F;

        #endregion Constants

        #region Properties

        /// <summary>
        /// Gets the list of initials and their romanised as key/value pair.
        /// </summary>
        public IList<KeyValuePair<char, string>> Initials
        {
            get
            {
                return this._initials;
            }
        }

        /// <summary>
        /// Gets the list of medials and their romanised as key/value pair.
        /// </summary>
        public IList<KeyValuePair<char, string>> Medials
        {
            get
            {
                return this._medials;
            }
        }

        /// <summary>
        /// Gets the list of finals and their romanised as key/value pair.
        /// </summary>
        public IList<KeyValuePair<char, string>> Finals
        {
            get
            {
                return this._finals;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Combines each characters to make a letter.
        /// </summary>
        /// <param name="initial">Initial character.</param>
        /// <param name="medial">Medial character.</param>
        /// <param name="final">Final character.</param>
        /// <returns>Returns a letter combined with initial, medial and final.</returns>
        public string Combine(string initial, string medial, string final = "")
        {
            var indexInitial = this.Initials
                                   .Select(p => p.Key)
                                   .ToList()
                                   .IndexOf(Convert.ToChar(initial));
            var indexMedial = this.Medials
                                  .Select(p => p.Key)
                                  .ToList()
                                  .IndexOf(Convert.ToChar(medial));
            var indexFinal = String.IsNullOrWhiteSpace(final)
                                 ? 0
                                 : this.Finals
                                       .Select(p => p.Key)
                                       .ToList()
                                       .IndexOf(Convert.ToChar(final));

            var unicode = FIRST_HANGEUL_UNICODE + (indexInitial * 21 + indexMedial) * 28 + indexFinal;

            var result = Convert.ToString(Convert.ToChar(unicode));
            return result;
        }

        /// <summary>
        /// Splits the letter into initial, medial and final.
        /// </summary>
        /// <param name="letter">Letter to split.</param>
        /// <returns>Returns the initial, medial and final.</returns>
        public IList<string> Split(char letter)
        {
            var indices = this.GetIndices(letter);
            if (indices == null || !indices.Any())
                return null;

            var resultInitial = Convert.ToString(this.Initials[indices[0]].Key);
            var resultMedial = Convert.ToString(this.Medials[indices[1]].Key);
            var resultFinal = Convert.ToString(this.Finals[indices[2]].Key).Trim();

            var result = new List<string>() { resultInitial, resultMedial, resultFinal };
            return result;
        }

        /// <summary>
        /// Romanises the letter.
        /// </summary>
        /// <param name="letters">Letters to romanise.</param>
        /// <param name="delimiter">Delimiter for letter.</param>
        /// <returns>Returns the letter romanised.</returns>
        public string Romanise(string letters, string delimiter = " ")
        {
            var results = letters.ToCharArray()
                                 .Select(p => this.Romanise(p))
                                 .Where(p => !String.IsNullOrWhiteSpace(p))
                                 .ToList();
            return String.Join(delimiter, results);
        }

        /// <summary>
        /// Romanises the letter.
        /// </summary>
        /// <param name="letter">Letter to romanise.</param>
        /// <returns>Returns the letter romanised.</returns>
        public string Romanise(char letter)
        {
            var indices = this.GetIndices(letter);
            if (indices == null || !indices.Any())
                return null;

            var resultInitial = Convert.ToString(this.Initials[indices[0]].Value);
            var resultMedial = Convert.ToString(this.Medials[indices[1]].Value);
            var resultFinal = Convert.ToString(this.Finals[indices[2]].Value).Trim();

            var result = String.Join("", resultInitial, resultMedial, resultFinal);
            return result;
        }

        /// <summary>
        /// Gets the indices for initial, medial and final.
        /// </summary>
        /// <param name="letter">Letter to get indices.</param>
        /// <returns>Returns the indices.</returns>
        private IList<int> GetIndices(char letter)
        {
            var unicode = Convert.ToUInt16(letter);
            //  Checks whether the given letter belongs to Hangeul unicode range.
            if (unicode < FIRST_HANGEUL_UNICODE || unicode > LAST_HANGEUL_UNICODE)
            {
                //  Checks the given letter only contains initial.
                //  If so, it appends medial of "ㅡ" and return the result.
                if (this.Initials.Select(p => p.Key).Contains(Convert.ToChar(letter)))
                {
                    var initial = Convert.ToString(this.Initials.Single(p => p.Key == Convert.ToChar(letter)).Key);
                    letter = Convert.ToChar(this.Combine(initial, "ㅡ", String.Empty));
                    return this.GetIndices(letter);
                }

                //  Checks the given letter only contains initial.
                //  If so, it prepends initial of "ㅇ" and return the result.
                if (this.Medials.Select(p => p.Key).Contains(Convert.ToChar(letter)))
                {
                    var medial = Convert.ToString(this.Medials.Single(p => p.Key == Convert.ToChar(letter)).Key);
                    letter = Convert.ToChar(this.Combine("ㅇ", medial, String.Empty));
                    return this.GetIndices(letter);
                }

                //  Checks the given letter only contains initial.
                //  If so, it prepends initial of "ㅇ" and medial of "ㅡ" and return the result.
                if (this.Finals.Select(p => p.Key).Contains(Convert.ToChar(letter)))
                {
                    var final = Convert.ToString(this.Finals.Single(p => p.Key == Convert.ToChar(letter)).Key);
                    letter = Convert.ToChar(this.Combine("ㅇ", "ㅡ", final));
                    return this.GetIndices(letter);
                }

                //  Returns NULL, if any of above is applied.
                return null;
            }

            var indexUnicode = unicode - FIRST_HANGEUL_UNICODE;
            var indexInitial = indexUnicode / (21 * 28);
            indexUnicode = indexUnicode % (21 * 28);
            var indexMedial = indexUnicode / 28;
            indexUnicode = indexUnicode % 28;
            var indexFinal = indexUnicode;

            var result = new List<int>() {indexInitial, indexMedial, indexFinal};
            return result;
        }

        #endregion Methods
    }
}