using Classes_Part_9;

namespace classes
{
    class classes
    {
        public static void Main(string[] args)
        {

            List<Student> students = new List<Student>();
            students.Add(new Student("George", "Washington"));
            students.Add(new Student("John", "Adams"));
            students.Add(new Student("Thomas", "Jefferson"));
            students.Add(new Student("James", "Madison"));
            students.Add(new Student("James", "Monroe"));

            int removeStudent = 0;
            bool firstBoot = true;
            bool inputFlag = true;
            string menuSelect = "";
            string[] asciiMenu =    
                {
                " __   __  _______  __    _  __   __ ",
                "|  |_|  ||       ||  |  | ||  | |  |",
                "|       ||    ___||   |_| ||  | |  |",
                "|       ||   |___ |       ||  |_|  |",
                "|       ||    ___||  _    ||       |",
                "| ||_|| ||   |___ | | |   ||       |",
                "|_|   |_||_______||_|  |__||_______|"};

            while (inputFlag)
            {
                if (!firstBoot)
                {
                    Thread.Sleep(2000);

                }
                firstBoot = false;
                for (int i = 0; i < asciiMenu.Length; i++)
                {
                    Console.WriteLine(asciiMenu[i]);
                }
                Console.WriteLine("Please select a program, or press X to quit");
                Console.WriteLine("1. List of Students\n2. View Student Info\n3. Add Student\n4. Remove Student\n" +
                    "5. Search for Student\n6. Edit Student\n 7. X. QUIT");
                menuSelect = Console.ReadLine();
                if (menuSelect == "1")
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine(students[i].ToString());    
                    }
                }
                else if (menuSelect == "2")
                {
                    displayStudent(students);

                }

                else if (menuSelect == "3")
                {
                    students.Add(addStudent()); 
                }
                else if (menuSelect == "4")
                {
                    removeStudent = removeStudentByID(students);
                    if (removeStudent != Int32.MaxValue) {
                        students.RemoveAt(removeStudent);
                    }
                    
                }
                else if (menuSelect == "5")
                {
                    searchStudent(students);    

                }
                else if (menuSelect == "6")
                {
                    EditStudent(students);

                }
                else if (menuSelect == "7")
                {
                    students.Sort();
                }
                else if (menuSelect.ToUpper() == "X")
                {
                    Console.WriteLine("Thank you for using the program.");
                    Environment.Exit(0);
                }

            }

        

    }
        static void displayStudent(List<Student> students)
        {
            bool inputFlag = true;
            string student = "";
            int multiSelection = 0;
            List<Student> returnList = new List<Student>();
            while (inputFlag)
            {
                Console.WriteLine("Please Enter a students' first name and last initial, seperated by a space.");
                student = Console.ReadLine();
                if (student.Replace(" ","").Split(",").Length < 2)
                {
                    Console.WriteLine("Invalid Input!");

                }
                else
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].firstName.ToUpper() == student.Replace(" ","").Split(",")[0].ToUpper() && students[i].lastName[0].ToString().ToUpper() == student.Replace(" ","").Split(",")[1].ToUpper())
                        {
                            returnList.Add(students[i]);
                        }
                    }
                    inputFlag = false;
                }
            }
                inputFlag = true;
                while (inputFlag) {
                if (returnList.Count > 1)
                {
                    Console.WriteLine("Multiple matching entries found. Please select: ");
                    for (int i = 0; i < returnList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {returnList[i].ToString()}");
                    }

                    if (!int.TryParse(Console.ReadLine(), out multiSelection) || multiSelection < 1 || multiSelection > returnList.Count)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    else
                    {
                        multiSelection--;
                        Console.WriteLine($"{returnList[multiSelection].lastName},{returnList[multiSelection].firstName}");
                        Console.WriteLine($"{returnList[multiSelection].studentID}");
                        Console.WriteLine($"{returnList[multiSelection].email}");
                        inputFlag = false;
                    }


                }
                else if (returnList.Count == 1)
                {
                    multiSelection--;
                    Console.WriteLine($"{returnList[0].lastName},{returnList[0].firstName}");
                    Console.WriteLine($"{returnList[0].studentID}");
                    Console.WriteLine($"{returnList[0].email}");
                    inputFlag = false;

                }
                else
                {
                    Console.WriteLine("Student Not Found!");
                    inputFlag = false;
                }

                }

            
        }

        static Student addStudent()
        {
            string firstName;
            string lastName;
            Console.WriteLine("Please enter the student's first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Now enter the student's last name: ");
            lastName = Console.ReadLine();
            Student ret =  new Student(firstName, lastName);
            Console.WriteLine($"Student {firstName} {lastName} added. ID: {ret.studentID} EMAIL: {ret.email}");
            return ret;
            

        }

        static int removeStudentByID(List<Student> students)
        {
            int id = 0;
            bool inputFlag = true;
            while (inputFlag)
            {
                Console.WriteLine("Please Enter the ID of the student you wish to remove.");
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input, please enter a student ID.");
                }
                else
                {
                    inputFlag = false;
                }

            }

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].studentID == id)
                {
                    return i;
                }
            }
            return Int32.MaxValue;

        }


        static void searchStudent(List<Student> students)
        {

            bool inputFlag = true;
            int selection = 0;
            string searchTermString = "NULLVOID";
            int searchTermInt = 5550001; 
            List<Student> returnList = new List<Student>();
            while (inputFlag)
            {
                Console.WriteLine("Select your search parameter:\n1. Last Name\n2. Student ID");
                if (!int.TryParse(Console.ReadLine(),out selection) || selection < 1 || selection > 2)
                {
                    Console.WriteLine("Invalid input, enter a number between 1 and 2");
                }
                else
                {
                    inputFlag = false;
                }
            }

            if (selection == 1)
            {
                Console.WriteLine("Enter the last name you wish to search for: ");
                searchTermString = Console.ReadLine();
            }
            else
            {
                inputFlag = true;
                while (inputFlag)
                {
                    Console.WriteLine("Enter the studentID you wish to search for (Format: 555***): ");
                    if (!int.TryParse(Console.ReadLine(), out searchTermInt))
                    {
                        Console.WriteLine("Invalid input, please enter a valid student ID (6 digits)");
                    }
                    else
                    {
                        inputFlag = false;
                    }
                }
            }

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].lastName == searchTermString || students[i].studentID == searchTermInt)
                {
                    returnList.Add(students[i]);
                }
            }
            Console.WriteLine($"There is {returnList.Count} matching entries: ");
            for (int i = 0; i < returnList.Count; i++)
            {
                Console.WriteLine($"{returnList[i].ToString()} - ID: {returnList[i].studentID} Email: {returnList[i].email}");
            }


        }

        static List<Student> EditStudent(List<Student> students)
        {
            List<Student> returnList = students;
            bool inputFlag = true;
            int studentID = 5550001;
            int idInd = 0;
            int selection = 0; /// TODO - RUN IT AGAIN THERE'S AN INDEX OUT OF RANGE BUG.
            string newFirstName = "";
            string newLastName = "";
            while (inputFlag)
            {
                Console.WriteLine("Please Enter the ID of the student you wish to edit.");
                if (!int.TryParse(Console.ReadLine(), out studentID))
                {
                    Console.WriteLine("Invalid input, please enter a valid student ID (6 digits).");
                }
                else
                {
                    inputFlag = false;
                }
            }
            for (int i = 0; i < students.Count; i++)
            {
                if (studentID == students[i].studentID)
                {
                    idInd = i;
                }
            }
            Console.WriteLine("Please Select a value to change: \n1. First Name\n2. Last Name\n3. Both");
            inputFlag = true;
            if (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Invalid input, please enter a number between 1 and 3.");
            }
            else
            {
                inputFlag = false;
            }
            switch (selection)
            {
                case 1:
                    Console.WriteLine("Please enter a new first name: ");
                    newFirstName = Console.ReadLine();
                    returnList[idInd] =  new Student(newFirstName, students[idInd].lastName);
                    return returnList; 
                case 2:
                    Console.WriteLine("Please enter a new last name: ");
                    newLastName = Console.ReadLine();
                    returnList[idInd] = new Student(students[idInd].firstName,newLastName);
                    return returnList;
                case 3:
                    Console.WriteLine("Please enter a new first name: ");
                    newFirstName = Console.ReadLine();
                    Console.WriteLine("Please enter a new last name: ");
                    newLastName = Console.ReadLine();
                    returnList[idInd] = new Student(newFirstName, newLastName);
                    return returnList;
                default:
                    break;
            }
            return returnList;
        }


    }
}