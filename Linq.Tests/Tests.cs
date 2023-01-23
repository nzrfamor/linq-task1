using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Objects;
using NUnit.Framework;
using Linq.Tests.Comparers;

namespace Linq.Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly YearSchoolComparer _yearSchoolComparer = new YearSchoolComparer();
        private readonly NumberPairComparer _numberPairComparer = new NumberPairComparer();
        private readonly MaxDiscountOwnerComparer _discountOwnerComparer = new MaxDiscountOwnerComparer();
        private readonly CountryStatComparer _countryStatComparer = new CountryStatComparer();


        [Test]
        public void Task13Test()
        {
            foreach (var (nameList, yearList, expected) in Task1Data())
            {
                var actualResult = Tasks.Task1(nameList, yearList);
                AssertIsLinq(actualResult);
                AssertIsAsExpected(expected, actualResult, _yearSchoolComparer);
            }
        }
        
        private IEnumerable<(IEnumerable<Entrant> nameList, IEnumerable<int> yearList, IEnumerable<YearSchoolStat> expected)> Task1Data()
        {
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 14, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 15, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                yearList: new[] {2019, 2018},
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2018},
                    new YearSchoolStat {NumberOfSchools = 4, Year = 2019}
                });
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 14, Year = 2016},
                    new Entrant {LastName = "Name", SchoolNumber = 15, Year = 2016},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 13, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                yearList: new[] { 2020, 2017, 2018 },
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 0, Year = 2020}, 
                    new YearSchoolStat {NumberOfSchools = 1, Year = 2017},
                    new YearSchoolStat {NumberOfSchools = 2, Year = 2018}
                });
            yield return (
                nameList: new[]
                {
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2019},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2018},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017},
                    new Entrant {LastName = "Name", SchoolNumber = 12, Year = 2017}
                },
                yearList: new[] {2020, 2013},
                expected: new[]
                {
                    new YearSchoolStat {NumberOfSchools = 0, Year = 2013},
                    new YearSchoolStat {NumberOfSchools = 0, Year = 2020}
                });
        }

        #region Utility

        private void AssertIsLinq<T>(IEnumerable<T> result)
        {
            Assert.AreEqual("System.Linq", result.GetType().Namespace, "Result is not linq");
        }

        private void AssertIsAsExpected<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.AreEqual(expected, actual);
        }

        private void AssertIsAsExpected<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer)
        {
            Assert.True(expected.SequenceEqual(actual, comparer), "Result is not as expected");
        }

        #endregion
    }
}