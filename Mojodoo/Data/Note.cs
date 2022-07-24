namespace Mojodoo.Data
{
    public class Note
    {
        public int Id { get; set; }
        public string? Todo { get; set; }
        public DateTime CreatedDate = DateTime.Now;
        public bool IsActive { get; set; }

    }
}
