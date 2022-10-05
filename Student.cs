using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Part_9
{
    internal class Student : IComparable<Student>
    {
        private static Random random = new Random();
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _studentID;

        public Student(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _studentID = 555000 + random.Next(1000);
            GenerateEmail();
        }

        public override string ToString()
        {
            return ($"{_firstName} {_lastName}");
        }

        public void ResetStudentNumber()
        {
            _studentID = 555000 + random.Next(1000);
            GenerateEmail();
        }

        private void GenerateEmail()
        {
            _email = (_firstName[0].ToString() + _firstName[1].ToString() + _firstName[2].ToString() + _lastName[0].ToString()
                + _lastName[1].ToString() + _lastName[2].ToString() + (_studentID - 555000).ToString() + "@ICS4U.com");
        }

        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value;}
        }

        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int studentID { get { return _studentID; } }

        public string email { get { return _email; } }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }
            if (firstName == student.firstName && lastName == student.lastName)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Student that)
        {
            if (this.lastName.CompareTo(that.lastName) == 0)
            {
                return this.firstName.CompareTo(that.firstName);
            }
            else
            {
                return this.lastName.CompareTo(that.lastName);
            }
        }
    }
}
