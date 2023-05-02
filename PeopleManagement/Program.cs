using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;

namespace PeopleManagement
{
    // #1 Code
    class Person
    {
        static int count = 0;
        public int order;
        public string name;
        public string phoneNumber;
        public string email;
        public int year; 

        public Person(string _name, string _phoneNumber, string _email)
        {
            order = count++;
            name = _name;
            phoneNumber = _phoneNumber;
            email = _email;
        }

        public virtual void personal_info()
        {
            Console.WriteLine($"순번 : {order}, 이름 : {name}, 전화번호 : {phoneNumber}, 이메일 : {email}, 생년 : {year}");
        }
    }

    // #4 Code
    class Professor : Person
    {
        string pos;
        string officeNumber;
        public int year;

        public Professor(string _name, string _phoneNumber, string _email, 
            string _pos, string _officeNumber, int _year) : base(_name, _phoneNumber, _email)
        {
            pos = _pos;
            officeNumber = _officeNumber;
            year = _year;
        }

        public new void personal_info()
        {
            Console.WriteLine($"직급: {pos}, 사무실: {officeNumber}, 근무년수: {year}");
        }
    }

    // #2 Code
    class Student : Person
    {
        string studentNumber;
        string major;
        int scholarShip;
        public int year;

        // #3 Code
        public int ScholarShip { 
            get { return scholarShip; }
            set
            {
                if(500 < value)
                {
                    Console.WriteLine("최대 수혜장학금은 500을 넘지 말아야 함");
                    return;
                }
                scholarShip = value;
            }
        }
        public Student(string _name, string _phoneNumber, string _email, string _studentNumber, 
            string _major, int _year) : base(_name, _phoneNumber, _email)
        {
            studentNumber = _studentNumber;
            major = _major;
            year = _year;
        }

        public override void personal_info()
        {
            base.personal_info();
            Console.WriteLine($"학번: {studentNumber}, 학과: {major}, 학년: {year}, 장학금: {scholarShip}");
        }
    }

    class Program
    {
        // #5 Code
        static List<Person> persons = new List<Person>();
        static void PrintTestLine()
        {
            Console.WriteLine($"-----------------------------------------------");
            Console.WriteLine($"----------------- Test ------------------------");
            Console.WriteLine($"-----------------------------------------------");
        }
        
        // UI 실행(#6 ~)
        static void RunUI()
        {
            while (true)
            {
                Console.WriteLine("1. 추가, 2. 현황출력, 3. 종료");
                int evtNumber = Convert.ToInt32(Console.ReadLine());
                // MenuEventHandler가 종료신호(true)를 반환하면 종료
                if (MenuEventHandler(evtNumber) == true)
                    return;
            }
        }

        static bool MenuEventHandler(int evtNumber)
        {
            switch (evtNumber)
            {
                case 1: // 추가 이벤트
                    HandleAddEvent();
                    break;
                case 2: // 프린트 이벤트
                    HandlePrintEvent();
                    break;
                case 3: // 종료 이벤트
                    return true;
                default:
                    Console.WriteLine("유효한 값을 입력해주세요. (1 ~ 3)");
                    break;
            }
            return false;
        }

        // List에 데이터 추가하는 Event
        // #6 Code
        static void HandleAddEvent()
        {
            int evtNumber = 0;
            while (evtNumber != 1 && evtNumber != 2)
            {
                Console.WriteLine("1. 학생, 2. 교직원");
                evtNumber = Convert.ToInt32(Console.ReadLine());
                switch(evtNumber)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddProfessor();
                        break;
                    default:
                        Console.WriteLine("유효한 값을 입력해주세요. (1 ~ 2)");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("이름: ");
            string name = Console.ReadLine();
            Console.Write("전화번호: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("이메일: ");
            string email = Console.ReadLine();
            Console.Write("생년: ");
            int year1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("학번: ");
            string studentNumber = Console.ReadLine();
            Console.Write("학과: ");
            string major = Console.ReadLine();
            Console.Write("학년: ");
            int year2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("장학금: ");
            int scholarShip = Convert.ToInt32(Console.ReadLine());

            Student student = new Student(name, phoneNumber, email, studentNumber, major, year2);
            student.ScholarShip = scholarShip;
            ((Person)student).year = year1;
            persons.Add(student);
        }
        static void AddProfessor()
        {
            Console.Write("이름: ");
            string name = Console.ReadLine();
            Console.Write("전화번호: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("이메일: ");
            string email = Console.ReadLine();
            Console.Write("생년: ");
            int year1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("직급: ");
            string pos = Console.ReadLine();
            Console.Write("사무실: ");
            string officeNum = Console.ReadLine();
            Console.Write("근무년수: ");
            int year2 = Convert.ToInt32(Console.ReadLine());

            Professor professor = new Professor(name, phoneNumber, email, pos, officeNum, year2);
            ((Person)professor).year = year1;
            persons.Add(professor);
        }

        // #7 Code
        static void HandlePrintEvent()
        {
            foreach (Person person in persons)
            {
                if (person is Student)
                {
                    person.personal_info();
                }
                else if (person is Professor)
                {
                    person.personal_info();
                    ((Professor)person).personal_info();
                }
                else
                {
                    person.personal_info();
                }
            }
        }

        static void Main(string[] args)
        {
            PrintTestLine();
            RunUI();
        }
    }
}
