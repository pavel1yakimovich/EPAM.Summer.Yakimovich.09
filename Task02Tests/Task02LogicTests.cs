using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task02Logic.BinarySearch;

namespace Task02Tests
{
    public class Task02LogicTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 5, 6 }, 5).Returns(3);
                yield return new TestCaseData(new int[] { 1, 2, 3, 5, 6 }, 1).Returns(0);
                yield return new TestCaseData(new int[] { 1, 2, 3, 5, 6 }, 6).Returns(4);
                yield return new TestCaseData(new int[] { 1, 2, 3, 5, 6 }, 4).Returns(-1);
                yield return new TestCaseData(new int[] { }, 4).Returns(-1);
                yield return new TestCaseData(new string[] { "1", "2", "3", "5", "6" }, "5").Returns(3);
                yield return new TestCaseData(new string[] { "1", "2", "3", "5", "6" }, "1").Returns(0);
                yield return new TestCaseData(new string[] { "1", "2", "3", "5", "6" }, "6").Returns(4);
                yield return new TestCaseData(new string[] { "1", "2", "3", "5", "6" }, "4").Returns(-1);
                yield return new TestCaseData(new string[] { }, "4").Returns(-1);
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public int SearchtTest<T> (T[] array, T value)
        {
            return Search(array, value);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public int SearchtWithComparisonTest<T>(T[] array, T value)
        {
            Comparison<T> comparison = Comparer<T>.Default.Compare;
            return Search(array, value, comparison);
        }

        [Test]
        public void SearchTest_ExceptionExpected()
        {
            Assert.Throws(typeof(ArgumentNullException), delegate {int k = Search(null, 4); });
        }

        [Test]
        public void SearchWithComparisonTest_ExceptionExpected()
        {
            Assert.Throws(typeof(ArgumentNullException), delegate { int k = Search(new int[] {1, 2}, 1, null); });
        }
    }
}
