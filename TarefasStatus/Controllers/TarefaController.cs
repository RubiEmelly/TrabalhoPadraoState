using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasStatus.Data;
using TarefasStatus.Model;
using TarefasStatus.Model.Enum;

namespace TarefasStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {
        private readonly StatusDBContext _context;
        public TarefaController(StatusDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TarefasModel>> PostTask(TarefasModel tarefasmodel)
        {
            tarefasmodel.Status = TarefaStatus.Criado;
            _context.TarefasModel.Add(tarefasmodel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = tarefasmodel.Id }, tarefasmodel);

            //método que cria a tarefa no banco de dados.
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefasModel>> GetTask(int id)
        {
            var tarefas = await _context.TarefasModel.FindAsync(id);

            if (tarefas == null)
            {
                return NotFound();
            }

            return tarefas;

            //método que busca a tarefa pelo seu ID
        }

        [HttpPut("{id}/iniciar")]
        public async Task<IActionResult> IniciarTarefa(int id)
        {
            var tarefa = await _context.TarefasModel.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            // só altera se a tarefa estiver criada
            if (tarefa.Status == TarefaStatus.Criado)
            {
                tarefa.Status = TarefaStatus.EmProgresso;
                _context.Entry(tarefa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser iniciada!");
            }

            return NoContent();

            //método que altera uma tarefa com status Criado para o status Em Progresso. (retorna codigo 204 se foi bem sucedido)
            //Se tarefa não tiver sido criada, ela não pode passar para o status Em progresso (retorna codigo 400 se não foi bem sucedido)
        }

        [HttpPut("{id}/completada")]
        public async Task<IActionResult> TarefaCompleta(int id)
        {
            var tarefa = await _context.TarefasModel.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            // só altera se a tarefa estiver em progresso
            if (tarefa.Status == TarefaStatus.EmProgresso)
            {
                tarefa.Status = TarefaStatus.Concluido;
                _context.Entry(tarefa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser completada!");
            }

            return NoContent();

            //método que altera uma tarefa com status Em Progresso para o status Concluido. (retorna codigo 204 se foi bem sucedido)
            //Se tarefa não tiver em progresso, ela não pode passar para o status concluido. (retorna codigo 400 se não foi bem sucedido)
        }

        [HttpPut("{id}/cancelada")]
        public async Task<IActionResult> TarefaCancelada(int id)
        {
            var tarefa = await _context.TarefasModel.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            // Cancela a tarefa criada ou em progresso
            if (tarefa.Status == TarefaStatus.Criado || tarefa.Status == TarefaStatus.EmProgresso)
            {
                tarefa.Status = TarefaStatus.Cancelado;
                _context.Entry(tarefa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser cancelada!");
            }

            return NoContent();

            //método que altera uma tarefa com status Criado ou Em Progresso para Cancelada. (retorna codigo 204 se foi bem sucedido)
            //Se tarefa já tiver sido concluida, ela não pode ser Cancelada. (retorna codigo 400 se não foi bem sucedido)
        }
    }
}