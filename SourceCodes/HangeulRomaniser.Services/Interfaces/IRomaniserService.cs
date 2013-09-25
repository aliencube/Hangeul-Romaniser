using System.Collections.Generic;

namespace HangeulRomaniser.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the RomaniserService class.
    /// </summary>
    public interface IRomaniserService
    {
        #region Properties

        /// <summary>
        /// Gets the list of initials and their romanised as key/value pair.
        /// </summary>
        IList<KeyValuePair<char, string>> Initials { get; }

        /// <summary>
        /// Gets the list of medials and their romanised as key/value pair.
        /// </summary>
        IList<KeyValuePair<char, string>> Medials { get; }

        /// <summary>
        /// Gets the list of finals and their romanised as key/value pair.
        /// </summary>
        IList<KeyValuePair<char, string>> Finals { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Combines each characters to make a letter.
        /// </summary>
        /// <param name="initial">Initial character.</param>
        /// <param name="medial">Medial character.</param>
        /// <param name="final">Final character.</param>
        /// <returns>Returns a letter combined with initial, medial and final.</returns>
        string Combine(string initial, string medial, string final = "");

        /// <summary>
        /// Splits the letter into initial, medial and final.
        /// </summary>
        /// <param name="letter">Letter to split.</param>
        /// <returns>Returns the initial, medial and final.</returns>
        IList<string> Split(string letter);

        /// <summary>
        /// Romanises the letter.
        /// </summary>
        /// <param name="letter">Letter to romanise.</param>
        /// <returns>Returns the letter romanised.</returns>
        string Romanise(string letter);

        #endregion Methods
    }
}