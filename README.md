# Trabalho Padrão State

## Projeto Status de Tarefas
### Aplicação Web API em C# para o gerenciamento de tarefas em relação aos seus estados: Criada, Em Progresso, Concluída e Cancelada.

## Estrutura 🧩
- Classe Model com os atributos da tarefa (id, nome e descrição)
- Classe Enum com os Estados: Criado, Em Progresso, Concluído, Cancelado.
- Classe Controller para gerenciar os estados das tarefas.

## Endpoints RESTful
- POST /Tarefa (Cria a tarefa)
- Estados:
<br> PUT /Tarefa/{id}/iniciar (Inicia a tarefa)
<br> PUT /Tarefa/{id}/concluida (Conclui a tarefa)
<br> PUT /Tarefa/{id}/cancelada (Cancela a tarefa)
<br> GET /Tarefa/{id} (Pesquisa)

