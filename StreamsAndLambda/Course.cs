namespace StreamsAndLambda
{
    internal class Course
    {
        public string Batch { get; set; }
        public string CourseName { get; set; }

        public Course(string batch, string courseName)
        {
            this.Batch = batch;
            this.CourseName = courseName;
        }
    }
}