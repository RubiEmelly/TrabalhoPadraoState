# Trabalho Padrão State 🚦

## Projeto Status de Tarefas
### Aplicação Web API em C# para o gerenciamento de tarefas em relação aos seus estados: Criada, Em Progresso, Concluída e Cancelada.

## Estrutura 🧩
- Classe Model com os atributos da tarefa (id, nome e descrição).
- Classe Enum com os Estados: Criado, Em Progresso, Concluído, Cancelado.
- Classe Controller para gerenciar os estados das tarefas.

## Endpoints RESTful
- POST /Tarefa (Cria a tarefa).
- Estados:
<br> PUT /Tarefa/{id}/iniciar (Inicia a tarefa);
<br> PUT /Tarefa/{id}/concluida (Conclui a tarefa);
<br> PUT /Tarefa/{id}/cancelada (Cancela a tarefa);
<br> GET /Tarefa/{id} (Pesquisa).

## Explicação do Código
⚠ Atenção: Tarefa sempre ter que ser CRIADA para passar para os outros Estados.
- Tarefa Criada pode passar para os Estados Em Progresso e depois Concluída. (Tarefa Concluída, não pode ser Cancelada).
- Tarefa Criada não pode passar direto para o Estado Concluída, tem que primeiro passar para o Estado Em Progresso. 
- Tarefa Criada pode ir direto para o Estado Cancelada.
- Tarefa Criada pode passar para o Estado Em Progresso e depois ser Cancelada.

## Configuração do Projeto ⚙️
- Baixe ou Clone o projeto.
- Acesse o código com a IDE Visual Studio.
- No terminal digite o comando para criar o banco de dados:
  ```
  update-database
  ```
- ⚠ Atenção: Se o Projeto não tiver Migration (conexão com o banco de dados), digite os comandos no terminal para a criação da conexão:
    ```
  add-migration CriarBanco
    --
  update-database
    ```
