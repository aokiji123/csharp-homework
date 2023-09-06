public class Group
{
    private List<Student> students;
    private string groupName;
    private string type;
    private int courseNumber;

    private static string[] mockedTypes = { "Computer Science", "AI", "Software Programming", "Web Developing", "Data Science" };
    private static string[] mockedNames =
    {
            "Bohdan", "Nikita", "Slavik", "Artem", "Alexandr", "Michail", "Dmitriy", "Alexey", "Maxim", "Eduard"
    };
    private static string[] mockedSecondnames =
    {
            "Bohdanov", "Nikitin", "Slavikov", "Artemov", "Alexandrov", "Michailov", "Dmitriyev", "Alexeyev", "Maximov", "Eduardov"
    };
    private static string[] mockedThirdnames =
    {
            "Bohdanovich", "Nikitich", "Slavikich", "Artemich", "Alexandrovich", "Michailovich", "Dmitriyevich", "Alexeyevich", "Maximovich", "Eduardovich"
    };
    private static string[] mockedCities = { "Odesa", "Kyiv", "Prague", "London", "Paris" };
    private static string[] mockedStreets = { "Street One", "Street Two", "Street Three" };
    private static string[] mockedStates = { "State One", "State Two", "State Three" };
    private static string[] mockedZipCodes = { "73000", "53855", "12456", "98734", "00012" };

    public Group()
    {
        Random random = new Random();

        groupName = random.Next(1, 20) + "IT class";
        type = mockedTypes[random.Next(mockedTypes.Length)];
        courseNumber = random.Next(0, 300);

        students = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            string fakeName = mockedNames[random.Next(mockedNames.Length)];
            string fakeLastname = mockedSecondnames[random.Next(mockedSecondnames.Length)];
            string fakeThirdname = mockedThirdnames[random.Next(mockedThirdnames.Length)];

            DateTime fakeBirthday = new DateTime(
                random.Next(2004, 2006),
                random.Next(1, 12),
                random.Next(1, 28)
            );

            string fakeCity = mockedCities[random.Next(mockedCities.Length)];

            string fakeStreet = mockedStreets[random.Next(mockedStreets.Length)];

            string fakeState = mockedStreets[random.Next(mockedStates.Length)];

            string fakeZipCode = mockedZipCodes[random.Next(mockedZipCodes.Length)];

            Address fakeAddress = new Address(fakeCity, fakeStreet, fakeState, fakeZipCode);

            string fakePhoneNumber = "+" + random.Next(100, 999) + random.Next(100, 999) + random.Next(1000, 9999);

            int[] fakeHomeworkGrades = new int[] { random.Next(1, 12), random.Next(1, 12), random.Next(1, 12) };
            int[] fakeProjectGrades = new int[] { random.Next(1, 12), random.Next(1, 12), random.Next(1, 12), random.Next(1, 12) };
            int[] fakeExamGrades = new int[] { random.Next(1, 12), random.Next(1, 12) };

            students.Add(new Student(
                fakeName,
                fakeLastname,
                fakeThirdname,
                fakeBirthday,
                fakeAddress,
                fakePhoneNumber,
                fakeHomeworkGrades,
                fakeProjectGrades,
                fakeExamGrades
            ));
        }
    }

    public Group(List<Student> students)
    {
        Random random = new Random();

        groupName = random.Next(1, 20) + "IT class";
        type = mockedTypes[random.Next(mockedTypes.Length)];
        courseNumber = random.Next(0, 300);

        this.students = students;
    }

    public Group(Group group)
    {
        students = new List<Student>(group.Students);
        groupName = group.GroupName;
        type = group.Type;
        courseNumber = group.CourseNumber;
    }

    public List<Student> Students
    {
        get { return students; }
        set
        {
            if (value == null || value.Count == 0)
                throw new InvalidGroup("The list of students can't be empty.");
            students = value;
        }
    }

    public string GroupName
    {
        get { return groupName; }
        set
        {
            groupName = value;
        }
    }

    public string Type
    {
        get { return type; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidGroupType("Group type can't be empty");
            type = value;
        }
    }

    public int CourseNumber
    {
        get { return courseNumber; }
        set
        {
            courseNumber = value;
        }
    }

    public void ShowAllStudents()
    {
        Console.WriteLine($"Group: {groupName}\nCourse type: {type}\nCourse number: {courseNumber}\nStudents list:\n");

        foreach (var student in students)
            Console.WriteLine(student + "\n");
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void InsertStudent(int index, Student student)
    {
        students.Insert(index, student);
    }

    public void ReplaceStudent(Student oldStudent, Student newStudent)
    {
        int index = students.IndexOf(oldStudent);
        if (index == -1)
            throw new InvalidGroupForReplace("Student was not found.");
        students[index] = newStudent;
    }

    public void EditGroup(string groupName, string type, int courseNumber)
    {
        this.groupName = groupName;
        this.type = type;
        this.courseNumber = courseNumber;
    }

    public void TransferStudent(Student student, Group newGroup)
    {
        if (!students.Remove(student))
            throw new InvalidGroupForTransfer("The student isn't in this group.");
        newGroup.AddStudent(student);
    }

    public void ShowAllFailingStudents()
    {
        students.ForEach(student =>
        {
            if (student.HomeworkGrades.Length < 1)
            {
                student.DisplayStudentInfo();
            }
        });
    }

    public void ShowLowestPerformingStudent()
    {
        Student lowestPerformingStudent =
            students.OrderBy(student => student.GetAverageGrade()).First();
        lowestPerformingStudent.DisplayStudentInfo();
    }

    public void DropOutAllFailingStudents()
    {
        students.RemoveAll(student => student.HomeworkGrades.Length < 1);
    }

    public void DropOutLowestPerformingStudent()
    {
        Student lowestPerformingStudent =
            students.OrderBy(student => student.GetAverageGrade()).First();
        students.Remove(lowestPerformingStudent);
    }
}