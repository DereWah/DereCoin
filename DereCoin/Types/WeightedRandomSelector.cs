using System;
using System.Collections.Generic;
using System.Linq;

namespace DereCoin.Types { 
    public class WeightedRandomSelector<T>
    {
        private readonly Random random;
        private readonly List<T> elements;

        public WeightedRandomSelector(List<T> elements)
        {
            this.elements = elements;
            this.random = new Random();
        }

        public T GetRandomElement()
        {
            int totalWeight = elements.Sum(element => GetWeight(element));
            int randomValue = random.Next() * totalWeight;

            foreach (var element in elements)
            {
                int elementWeight = GetWeight(element);
                if (randomValue < elementWeight)
                    return element;
                randomValue -= elementWeight;
            }

            // In case of a rare rounding error, return the last element
            return elements[elements.Count - 1];
        }

        private int GetWeight(T element)
        {
            // Assumes that the element has a property named "Chance" of type double
            // Modify this logic if the property name or type is different
            return ((CoinChanceBase)(object)element).Chance;
        }
    }
}