namespace Exercise7.Models
{
    public class Developer
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual Team Team { get; set; } = null!;
    }
}
