class Program
{
    static void Main()
    {
        Student student = new Student(
            "Bohdan", "Bohdanov", "Bohdanovich",
            new DateTime(2006, 2, 5),
            new Address("Ostrava",
                "Dukelska", "Moravskoslezsky kraj", "65300"),
            "723765170",
            new int[] { 10, 8, 9, 12, 10, 10 },
            new int[] { 11, 11 },
            new int[] { 12, 12, 11, 11 }
        );

        try
        {
            student.Address.ZipCode = "160";
        }
        catch (Exception e)
        {
            Console.WriteLine("\n" + e + "\n");
        }

        Console.WriteLine("Created student:" +
            "\n----------------\n");
        student.DisplayStudentInfo();
        Console.WriteLine();

        Group group = new Group();
        Console.WriteLine("All the students:" +
            "\n-----------------\n");
        group.ShowAllStudents();

        group.AddStudent(student);

        Console.WriteLine("All failing students:" +
            "\n---------------------\n");

        group.ShowAllFailingStudents();

        Console.WriteLine("The lowest performing student:" +
            "\n-----------------------\n");

        group.ShowLowestPerformingStudent();

        Console.WriteLine("\nDrop out the lowest performing student:" +
            "\n------------------------------------\n");
        group.DropOutLowestPerformingStudent();

        group.ShowAllStudents();

        try
        {
            group.GroupName = "abcadkad";
        }
        catch (Exception e)
        {
            Console.WriteLine(e + "\n");
        }

        try
        {
            group.CourseNumber = 9999;
        }
        catch (Exception e)
        {
            Console.WriteLine(e + "\n");
        }

        try
        {
            group.Students.First().FirstName = "Boris";
        }
        catch (Exception e)
        {
            Console.WriteLine(e + "\n");
        }
    }
}