using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exercices.Tests;

    [TestClass]
    public class FibTest
    {
        private Fib _range;

        private void Setup(int r)
        {
            _range = new Fib(r);
        }

        [TestMethod]
        public void WhenGetFibSeries_1_ThenNotEmptyAndEqualsZero()
        {
            Setup(1);

            List<int> results = _range.GetFibSeries();

            // Le résultat n’est pas vide
            Assert.IsNotNull(results);

            //Le résultat correspond à une liste qui contient { 0}
            Assert.AreNotEqual(0, results.Count);
            var expected = new List<int> { 0 };
            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhenGetFibSeries_6_ThenAllConditionsResults()
        {
            Setup(6);

            List<int> results = _range.GetFibSeries();

            // contient 3
            CollectionAssert.Contains(results, 3);

            // Le résultat contient 6 éléments
            Assert.AreEqual(6, results.Count);

            // Le résultat n’a pas le chiffre 4 en son sein 
            CollectionAssert.DoesNotContain(results, 4);

            // Le résultat correspond à une liste qui contient {0, 1, 1, 2, 3, 5}
            var expected = new List<int> { 0, 1, 1, 2, 3, 5 };
            CollectionAssert.AreEqual(expected, results);

            // Le résultat est trié de façon ascendance 
            var sorted = results.OrderBy(x => x).ToList();
            CollectionAssert.AreEqual(sorted, results);
        }
    }


    

