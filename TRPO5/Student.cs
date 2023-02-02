using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO5
{
    internal class Student
    {
        public string Surname { get; private set; }
        public string groupStudent { get; private set; }
        public string selectDiscipline { get; private set; }
        public double averageScore { get; private set; }

        public Student ( string surname, string groupStudent, string selectDiscipline, double averageScore)
        {
            Surname = surname;
            this.groupStudent = groupStudent;
            this.selectDiscipline = selectDiscipline;
            this.averageScore = averageScore;
        }
    }
}
