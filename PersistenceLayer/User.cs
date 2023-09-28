using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceLayer
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public User(string name, string surname, string phoneNumber)
        {
            Name = name ?? throw new NullReferenceException(nameof(Name));
            Surname = surname ?? throw new NullReferenceException(nameof(Surname));
            PhoneNumber = phoneNumber ?? throw new NullReferenceException(nameof(PhoneNumber));
        }
    }
}