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
        public IList<string> Split(string letter)
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
        /// <param name="letter">Letter to romanise.</param>
        /// <returns>Returns the letter romanised.</returns>
        public string Romanise(string letter)
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
        private IList<int> GetIndices(string letter)
        {
            var unicode = Convert.ToUInt16(Convert.ToChar(letter));
            if (unicode < FIRST_HANGEUL_UNICODE || unicode > LAST_HANGEUL_UNICODE)
                return null;

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