using Core.Persistence.Repositories;

namespace KodlamaIoDevs.Domain.Entities
{
    public class ProgrammingLanguage: Entity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }

        public ProgrammingLanguage()
        {
        }

        public ProgrammingLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}

