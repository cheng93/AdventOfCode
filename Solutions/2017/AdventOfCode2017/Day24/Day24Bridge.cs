namespace AdventOfCode2017.Day24
{
    using System.Collections.Generic;

    public class Day24Bridge
    {
        public int Pin { get; }

        public HashSet<string> Components { get; }

        private Day24Bridge(int pin, HashSet<string> components = null)
        {
            this.Pin = pin;
            this.Components = components ?? new HashSet<string>();
        }

        public Day24Bridge Add(Day24Component component)
        {
            var pin = component.PinA == this.Pin
                ? component.PinB
                : component.PinA;

            var components = new HashSet<string>(this.Components);
            components.Add(component.Id);
            return new Day24Bridge(pin, components);
        }

        public static Day24Bridge Initial = new Day24Bridge(0);
    }
}