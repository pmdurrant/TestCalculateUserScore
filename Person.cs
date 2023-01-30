// ***********************************************************************
// Assembly         : ConsoleApp1
// Author           : pdurr
// Created          : 01-30-2023
//
// Last Modified By : pdurr
// Last Modified On : 01-30-2023
// ***********************************************************************
// <copyright file="Person.cs" company="ConsoleApp1">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace ConsoleApp1
{
    /// <summary>
    /// Class Person.
    /// Implements the <see cref="System.Collections.Generic.IComparer{ConsoleApp1.Person}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{ConsoleApp1.Person}" />
    internal class Person : IComparer<Person>
    {
        /// <summary>
        /// The score
        /// </summary>
        private int score;
        /// <summary>
        /// The person name
        /// </summary>
        private string personName;
        /// <summary>
        /// The index position
        /// </summary>
        private int indexPosition;
        /// <summary>
        /// The internal charscore
        /// </summary>
        private int internalCharscore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
        }
        /// <summary>
        /// Gets or sets the index position.
        /// </summary>
        /// <value>The index position.</value>
        public int IndexPosition { get => indexPosition; set => indexPosition = value; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>The name of the person.</value>
        public string PersonName { get => personName; set => personName = value; }
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        public int Score { get => score; set => score = value; }

        /// <summary>
        /// Gets or sets the internal charscore.
        /// </summary>
        /// <value>The internal charscore.</value>
        public int InternalCharscore { get => internalCharscore; set => internalCharscore = value; }
        /// <summary>
        /// Calculates the score.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int calculateScore()
        {
            var intscore = 0;
            foreach (var itemchr in personName)
            {
                var charpos = Convert.ToInt16(itemchr - 64);


                intscore += charpos;

            }
            internalCharscore=intscore;
            return intscore * indexPosition;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return PersonName.GetHashCode();
        }


        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>System.Int32.</returns>
        public int CompareTo(Person other)
        {

            if (this.PersonName == other.PersonName)
            {
                return 1;
            }
            else if (this.PersonName != other.PersonName)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.
        /// <list type="table"><listheader><term> Value</term><description> Meaning</description></listheader><item><term> Less than zero</term><description><paramref name="x" /> is less than <paramref name="y" />.</description></item><item><term> Zero</term><description><paramref name="x" /> equals <paramref name="y" />.</description></item><item><term> Greater than zero</term><description><paramref name="x" /> is greater than <paramref name="y" />.</description></item></list></returns>
        public int Compare(Person? x, Person? y)
        {

            if (this.PersonName == y.PersonName)
            {
                return 1;
            }
            else if (this.PersonName != y.PersonName)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
