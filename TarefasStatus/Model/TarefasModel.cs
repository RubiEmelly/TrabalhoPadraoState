using TarefasStatus.Model.Enum;

namespace TarefasStatus.Model
{
    public class TarefasModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TarefaStatus Status { get; set; }
    }

    //classe model (principal) que posssui os atributos das tarefas que vão ser criadas.
}
