using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangeulRomaniser.Services
{
    public class RomaniserService
    {
        #region Constructors
        #endregion

        #region Constants
        private const string INITIALS = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        private const string MEDIALS = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        private const string FINALS = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
        private const ushort FIRST_HANGEUL_UNICODE = 0xAC00;
        private const ushort LAST_HANGEUL_UNICODE = 0xD79F;
        #endregion

        #region Properties

        private IList<char> _initials;
        /// <summary>
        /// Gets the list of initials as char data type.
        /// </summary>
        public IList<char> Initials
        {
            get
            {
                if (this._initials == null || !this._initials.Any())
                    this._initials = INITIALS.ToCharArray().ToList();
                return this._initials;
            }
        }
        private IList<char> _medials;
        /// <summary>
        /// Gets the list of medials as char data type.
        /// </summary>
        public IList<char> Medials
        {
            get
            {
                if (this._medials == null || !this._medials.Any())
                    this._medials = MEDIALS.ToCharArray().ToList();
                return this._medials;
            }
        }

        private IList<char> _finals;
        /// <summary>
        /// Gets the list of finals as char data type.
        /// </summary>
        public IList<char> Finals
        {
            get
            {
                if (this._finals == null || !this._finals.Any())
                    this._finals = FINALS.ToCharArray().ToList();
                return this._finals;
            }
        }
        #endregion

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
            var indexInitial = this.Initials.IndexOf(Convert.ToChar(initial));
            var indexMedial = this.Medials.IndexOf(Convert.ToChar(medial));
            var indexFinal = String.IsNullOrWhiteSpace(final)
                                 ? 0
                                 : this.Finals.IndexOf(Convert.ToChar(final));

            var unicode = FIRST_HANGEUL_UNICODE + (indexInitial * 21 + indexMedial) * 28 + indexFinal;

            var result = Convert.ToString(Convert.ToChar(unicode));
            return result;
        }

        /// <summary>
        /// Splits a letter into initial, medial and final.
        /// </summary>
        /// <param name="letter">Letter.</param>
        /// <returns>Returns the initial, medial and final.</returns>
        public IList<string> Split(string letter)
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

            var resultInitial = Convert.ToString(this.Initials[indexInitial]);
            var resultMedial = Convert.ToString(this.Medials[indexMedial]);
            var resultFinal = Convert.ToString(this.Finals[indexFinal]).Trim();

            var result = new List<string>() {resultInitial, resultMedial, resultFinal};
            return result;
        }

        #endregion
    }
}
