using Microsoft.AspNetCore.Mvc;
using src.Persistence;
using src.Models;
using Microsoft.EntityFrameworkCore;

namespace src.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private DataBaseContext _repository { get; set; }
        public PersonController(DataBaseContext context)
        {
            this._repository = context;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetPerson() {
            var result = this._repository.Pessoas.Include(p => p.contrato).ToList();
            if(!result.Any()) return NoContent();
            return this.Ok(result);
        }
        [HttpPost]
        public Person PostPerson([FromBody] Person person)
        {
            this._repository.Pessoas.Add(person);
            this._repository.SaveChanges();
            return person;
        }
        [HttpPut("{id}")]
        public string Update([FromRoute] int id, [FromBody] Person pessoa)
        {
            this._repository.Pessoas.Update(pessoa);
            this._repository.SaveChanges();
            return $"dados do ID:{id} atualizados";
        }
        [HttpDelete("{id}")]
        public ActionResult<Object> Delete([FromRoute] int id)
        {
            var result = this._repository.Pessoas.SingleOrDefault(e => e.id == id);
            if(result is null){
                return BadRequest();
            }
            this._repository.Pessoas.Remove(result);
            this._repository.SaveChanges();
            return this.Ok($"id:{id} deletado com sucesso");
        }
    }
}

