using Microsoft.AspNetCore.Identity;
using Midis.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Midis.Domains
{
    public class UserGroup : IEntity
    {
        [Key]
        public long Id { get; set; }
        public virtual UserMidis User { get; set; }
        public virtual NumberGroup Group { get; set; }
    }
}
