namespace WebLessonDocker.Models
{
 
    public class Role
    {
        public string Name { get; set; }
        public RoleId RoleId { get; set;}
        public virtual List<User> User { get; set; }

    }
}
