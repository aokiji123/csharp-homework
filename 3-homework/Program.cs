class Program
{
    static void Main()
    {
        Address address = new Address
        {
            City = "New York",
            Street = "123 Time Square ST",
            State = "State",
            ZipCode = "12345"
        };

        Student student = new Student("Jonh", "Doe", "Doedovich", new DateTime(2023, 8, 27), address, "123-456-7890");

        student.HomeworkGrades = new int[] { 10, 10, 11, 8 };
        student.ProjectGrades = new int[] { 11, 9, 9, 12 };
        student.ExamGrades = new int[] { 10, 10 };


        student.DisplayStudentInfo();
    }
}