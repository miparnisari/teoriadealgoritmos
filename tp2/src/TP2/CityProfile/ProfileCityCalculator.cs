namespace TP2.CityProfile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProfileCityCalculator
    {
        /// <summary>
        /// Devuelve el profile de la ciudad.
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public List<int> GetProfile(List<Building> buildings)
        {
            var result = new List<int>();
            //O(NLogN)
            var orderedBuildings = MergeSort(buildings);

            // crea la lista con el profile - O(N)
            foreach (var b in orderedBuildings)
            {
                result.Add(b.X1);
                result.Add(b.H);
            }
            result.Add(orderedBuildings.Last().X2);
            return result;
        }

        /// <summary>
        /// Mergesort
        /// </summary>
        /// <param name="list">Lista a ordenar</param>
        /// <returns>La lista ordenada</returns>
        private List<Building> MergeSort(List<Building> list)
        {
            if (list.Count <= 1)
                return list;

            var middle = list.Count() / 2;
            var h1 = MergeSort(list.GetRange(0, middle));
            var h2 = MergeSort(list.GetRange(middle, list.Count - middle));
            return MergeWithSplit(h1, h2, (a, b) => a.X1 <= b.X1);
        }

        /// <summary>
        /// Devuelve True is b1 y b2 están parcialmente solapados.
        /// </summary>
        /// <param name="b1">Edificio 1</param>
        /// <param name="b2">Edificio 2</param>
        /// <returns>Devuelve True is b1 y b2 están parcialmente solapados. Sino, False</returns>
        private bool Overlap(Building b1, Building b2)
        {
            return !(b1.X2 <= b2.X1 || b2.X2 <= b1.X1);
        }

        /// <summary>
        /// Devuelve True is b2 está completamente solapado a b1.
        /// </summary>
        /// <param name="b1">Edificio 1</param>
        /// <param name="b2">Edificio 2</param>
        /// <returns>Devuelve True si b2 está completamente solapado a b1.</returns>
        private bool CompletelyOverlap(Building b1, Building b2)
        {
            return (b1.X1 <= b2.X1 && b1.X2 >= b2.X2 && b1.H > b2.H);
        }

        /// <summary>
        /// Éste metodo remueve la intersección entre los dos edificios teniendo en cuenta la altura.
        /// </summary>
        /// <param name="b1">Edificio 1</param>
        /// <param name="b2">Edificio 2</param>
        /// <returns>Devuelve el remanente luego del corte si lo hay. Sino null.</returns>
        private Building RemoveOverlapped(Building b1, Building b2)
        {
            var a = b1.H > b2.H ? b1 : b2;
            var b = a == b1 ? b2 : b1;

            if (a.X1 <= b.X1 && a.X2 >= b.X2)
            {
                return null;
            }

            if (a.X1 < b.X2 && b.X2 < a.X2)
            {
                b.X2 = a.X1;
                return null;
            }

            if (a.X1 < b.X1 && b.X1 < a.X2)
            {
                b.X1 = a.X2;
                return null;
            }

            if (b.X1 <= a.X1 && b.X2 >= a.X2)
            {
                var oldX2 = b.X2;
                b.X2 = a.X1;
                return new Building(a.X2, oldX2, b.H);
            }

            return null; // we should never reach this point
        }

        /// <summary>
        /// Verifica si hay solapamiento entre los dos edificios y
        /// lo elimina si es el caso.
        /// </summary>
        /// <param name="b1">Edificio 1</param>
        /// <param name="b2">Edificio 2</param>
        /// <param name="branch">Rama actual del mergesort.</param>
        private void ProcessOverlapping(Building b1, Building b2, List<Building> branch)
        {
            if (Overlap(b1, b2))
            {
                var remaining = RemoveOverlapped(b1, b2);
                if (remaining != null)
                {
                    branch.Add(remaining);
                }
            }
        }

        /// <summary>
        /// Fase de merge del mergesort que también remueve las interseccciones entre los edificios.
        /// </summary>
        /// <param name="left">Rama izquierda</param>
        /// <param name="right">Rama derecha</param>
        /// <param name="comparer">Delegate para la comparación entre los edificios.</param>
        /// <returns>Devuelve la lista ordenada.</returns>
        private List<Building> MergeWithSplit(List<Building> left, List<Building> right, Func<Building, Building, bool> comparer)
        {
            var result = new List<Building>(1000);
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    var l = left.First();
                    var r = right.First();
                    if (comparer(l, r))
                    {
                        // if r is completely overlapped by l, just remove it from the list.
                        if (CompletelyOverlap(l, r))
                        {
                            right = right.GetRange(1, right.Count - 1); // O(N)
                            continue;
                        }
                        // remove overlapped section
                        ProcessOverlapping(l, r, left);
                        // add it the result list
                        result.Add(l);
                        left = left.GetRange(1, left.Count - 1); // O(N)
                    }
                    else
                    {
                        // if l is completely overlapped by r, just remove it from the list.
                        if (CompletelyOverlap(r, l))
                        {
                            left = left.GetRange(1, right.Count - 1); // O(N)
                            continue;
                        }
                        // remove overlapped section
                        ProcessOverlapping(r, l, right);
                        // add it the result list
                        result.Add(r);
                        right = right.GetRange(1, right.Count - 1); // O(N)
                    }
                }
                else if (left.Any())
                {
                    // add the remaining of the list.
                    result.Add(left.First());
                    left = left.GetRange(1, left.Count - 1); // O(N)
                }
                else if (right.Any())
                {
                    // add the remaining of the list.
                    result.Add(right.First());
                    right = right.GetRange(1, right.Count - 1); // O(N)
                }
            }
            return result;
        }
    }
}
