using CrudApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudApi.Data
{
    public class ItemDataStore
    {
        public static List<Item> Items { get; } = new List<Item>
        {
            new Item { Id = 1, Name = "Item1", Description = "Description1" },
            new Item { Id = 2, Name = "Item2", Description = "Description2" }
        };

        public static void Add(Item item)
        {
            item.Id = Items.Max(i => i.Id) + 1;
            Items.Add(item);
        }

        public static void Update(Item item)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
            }
        }

        public static void Delete(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }
}
