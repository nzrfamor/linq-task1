using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Objects;

namespace Linq
{
    public static class Tasks
    {

        public static IEnumerable<YearSchoolStat> Task1(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            return yearList.GroupJoin(yearList.SelectMany(x => nameList.Where(n => n.Year == x)
            .GroupBy(x => x.Year, x => x.SchoolNumber, (y, s) => s.Distinct().Count()), (year, number) => new
            {
                Year = year,
                CountOfSchool = number
            }), y => y, n => n.Year, (year, number) => new YearSchoolStat
            {
                Year = year,
                NumberOfSchools = number.Select(x => x.CountOfSchool).SingleOrDefault()
            }).OrderBy(x => x.NumberOfSchools).ThenBy(x => x.Year);
        }

    }
}
