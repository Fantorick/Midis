using Midis.Domains;
using System.Text.RegularExpressions;

namespace Midis.Models
{
    public class ItemAndGroupModel
    {
        public virtual Item item { get; set; }
        public virtual NumberGroup group { get; set; }
        public IEnumerable<Item> items { get; set; }
        public IEnumerable<NumberGroup> groups { get; set; }
        public ItemAndGroupModel() { }

        public ItemAndGroupModel(IEnumerable<Item> item, IEnumerable<NumberGroup> group)
        {
            items = item;
            groups = group;
        }

        public ItemAndGroupModel(Item item, NumberGroup group) 
        {
            this.item = item;
            this.group = group;

        }
    }
}
