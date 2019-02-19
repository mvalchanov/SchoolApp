namespace SchoolApp.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + MidName + " " + LastName;
            }
        }

    }
}
