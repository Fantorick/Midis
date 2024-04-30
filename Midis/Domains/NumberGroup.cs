using Midis.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Midis.Domains
{
    public class NumberGroup : IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
