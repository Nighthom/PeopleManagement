using Microsoft.VisualBasic;
using System;

namespace PeopleManagement
{
    class Person
    {
        static int _count = 0;
        public int _order;
        public string _name;
        public string _phoneNumber;
        public string _email;
        public int _year; 

        public Person(string name, string phoneNumber, string email, int year)
        {
            _order = _count++;
            _name = name;
            _phoneNumber = phoneNumber;
            _email = email;
            _year = year;
        }

        public Person() { }

        public virtual void personal_info()
        {
            Console.WriteLine($"순번 : {_order}, 이름 : {_name}, 전화번호 : {_phoneNumber}, 이메일 : {_email}, 생년 : {_year}");
        }
    }

    class Professor : Person
    {

    }

    class Student : Person
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // #1 Test
            Person person = new Person("승준", "01022170710", "qqq991124@naver.com", 2001);
            person.personal_info();

            // #2 Test
        }
    }
}
