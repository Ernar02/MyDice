using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDice.Models
{
    public class Dice
    {
        public IReadOnlyList<int> Sides { get; }

        public Dice(List<int> sides)
        {
            if (sides == null)
                throw new ArgumentNullException(nameof(sides));

            if (sides.Count != 6)
                throw new ArgumentException("Dice must have exactly 6 sides.", nameof(sides));

            if (sides.Any(side => side < 1))
                throw new ArgumentException("All dice sides must be positive numbers.", nameof(sides));

            Sides = new List<int>(sides).AsReadOnly();
        }

        public int Roll(int sideIndex)
        {
            if (sideIndex < 0 || sideIndex >= Sides.Count)
                throw new ArgumentOutOfRangeException(nameof(sideIndex),
                    $"Side index must be between 0 and {Sides.Count - 1}.");

            return Sides[sideIndex];
        }

        public override string ToString() => string.Join(",", Sides);
    }

}