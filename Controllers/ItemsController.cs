using Microsoft.AspNetCore.Mvc;
using CrudApi.Models;
using CrudApi.Data;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Item>> GetAll()
        {
            return ItemDataStore.Items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetById(int id)
        {
            var item = ItemDataStore.Items.FirstOrDefault(i => i.Id == id);
            return item != null ? item : NotFound();
        }

        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            ItemDataStore.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            ItemDataStore.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ItemDataStore.Delete(id);
            return NoContent();
        }
    }
}
