# Sistema de Gestão Universitária

Este projeto é uma aplicação de console em C# que simula um sistema de gestão universitária, permitindo o cadastro e gerenciamento de cursos, professores, alunos e matrículas em uma universidade fictícia.

## Funcionalidades

O sistema oferece, através de um menu interativo, as seguintes operações:

1. **Cadastrar Curso**: Adiciona um novo curso com código, nome e descrição.
2. **Cadastrar Professor**: Adiciona um novo professor com nome, título e departamento.
3. **Cadastrar Aluno**: Adiciona um novo aluno, exigindo que um curso já esteja cadastrado.
4. **Matricular Aluno em Curso**: Matricula um aluno já cadastrado em um curso existente.
5. **Listar Cursos**: Exibe todos os cursos cadastrados.
6. **Listar Professores**: Exibe todos os professores cadastrados.
7. **Listar Alunos**: Exibe todos os alunos cadastrados.
8. **Listar Matrículas**: Mostra todas as matrículas realizadas.
0. **Sair**: Encerra o programa.

## Estrutura do Código

O código está organizado em várias classes principais:

- **Curso**: Representa um curso da universidade.
- **Professor**: Representa um professor da universidade.
- **Aluno**: Representa um aluno, vinculado a um curso.
- **Matricula**: Relaciona um aluno a um curso em que ele foi matriculado.
- **Universidade**: Gerencia as listas de cursos, professores, alunos e matrículas, além de fornecer métodos de cadastro, busca e listagem.
- **Menu**: Responsável pela interface de menu no console, controlando o fluxo da aplicação.
- **Program**: Classe principal que inicia o sistema.

## Como Usar

1. Compile e execute o programa.
2. O menu será exibido no console.
3. Selecione a operação desejada digitando o número correspondente.
4. Siga as instruções do sistema para inserir as informações necessárias.
5. Para cadastrar um aluno ou realizar matrícula, é necessário que existam cursos previamente cadastrados.

## Exemplo de Uso

```
=== SISTEMA DE GESTÃO UNIVERSITÁRIA ===
1. Cadastrar Curso
2. Cadastrar Professor
3. Cadastrar Aluno
4. Matricular Aluno em Curso
...
Escolha uma opção: 1

--- Cadastro de Curso ---
Código: 101
Nome: Engenharia
Descrição: Curso de Engenharia
Curso cadastrado com sucesso!
```

## Observações

- O sistema é executado inteiramente no console e não utiliza banco de dados; os dados são armazenados em listas na memória durante a execução.
- Não é possível salvar os dados após encerrar o programa.
- O código serve como exemplo didático de manipulação de listas, classes e interação via console em C#.

## Estrutura de Pastas

```
ProjetoPOO/
└── ConsoleApp1/
    └── Program.cs       # Código-fonte principal do sistema
```

---
