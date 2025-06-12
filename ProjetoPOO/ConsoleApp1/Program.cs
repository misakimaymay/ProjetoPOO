using System;
using System.Collections.Generic;

namespace SistemaUniversidade
{
    public class Curso
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Curso(int codigo, string nome, string descricao)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Nome: {Nome}, Descrição: {Descricao}";
        }
    }

    public class Professor
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Departamento { get; set; }

        public Professor(string nome, string titulo, string departamento)
        {
            Nome = nome;
            Titulo = titulo;
            Departamento = departamento;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Título: {Titulo}, Departamento: {Departamento}";
        }
    }

    public class Aluno
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public Curso Curso { get; set; }

        public Aluno(string nome, int matricula, Curso curso)
        {
            Nome = nome;
            Matricula = matricula;
            Curso = curso;
        }

        public override string ToString()
        {
            return $"Matrícula: {Matricula}, Nome: {Nome}, Curso: {Curso.Nome}";
        }
    }

    public class Matricula
    {
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }

        public Matricula(Aluno aluno, Curso curso)
        {
            Aluno = aluno;
            Curso = curso;
        }
    }

    public class Universidade
    {
        private List<Curso> cursos = new List<Curso>();
        private List<Professor> professores = new List<Professor>();
        private List<Aluno> alunos = new List<Aluno>();
        private List<Matricula> matriculas = new List<Matricula>();

        public bool ExistemCursos() => cursos.Count > 0;
        public bool ExistemAlunos() => alunos.Count > 0;
        public bool ExistemProfessores() => professores.Count > 0;

        public void AddCurso(Curso curso) => cursos.Add(curso);
        public void AddProfessor(Professor professor) => professores.Add(professor);
        public void AddAluno(Aluno aluno) => alunos.Add(aluno);

        public void Matricular(Aluno aluno, Curso curso)
        {
            matriculas.Add(new Matricula(aluno, curso));
            Console.WriteLine($"Aluno {aluno.Nome} matriculado no curso {curso.Nome}");
        }

        public void ListarCursos()
        {
            Console.WriteLine("\n--- Cursos Cadastrados ---");
            if (!ExistemCursos())
            {
                Console.WriteLine("Nenhum curso cadastrado.");
                return;
            }
            foreach (var curso in cursos) Console.WriteLine(curso);
        }

        public void ListarProfessores()
        {
            Console.WriteLine("\n--- Professores Cadastrados ---");
            if (!ExistemProfessores())
            {
                Console.WriteLine("Nenhum professor cadastrado.");
                return;
            }
            foreach (var professor in professores) Console.WriteLine(professor);
        }

        public void ListarAlunos()
        {
            Console.WriteLine("\n--- Alunos Cadastrados ---");
            if (!ExistemAlunos())
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
                return;
            }
            foreach (var aluno in alunos) Console.WriteLine(aluno);
        }

        public void ListarMatriculas()
        {
            Console.WriteLine("\n--- Matrículas Realizadas ---");
            if (matriculas.Count == 0)
            {
                Console.WriteLine("Nenhuma matrícula realizada.");
                return;
            }
            foreach (var matricula in matriculas)
                Console.WriteLine($"Aluno: {matricula.Aluno.Nome}, Curso: {matricula.Curso.Nome}");
        }

        public Curso BuscarCursoPorCodigo(int codigo) => cursos.Find(c => c.Codigo == codigo);
        public Aluno BuscarAlunoPorMatricula(int matricula) => alunos.Find(a => a.Matricula == matricula);
    }

    public class Menu
    {
        private Universidade universidade;

        public Menu(Universidade universidade)
        {
            this.universidade = universidade;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== SISTEMA DE GESTÃO UNIVERSITÁRIA ===");
                Console.WriteLine("1. Cadastrar Curso");
                Console.WriteLine("2. Cadastrar Professor");
                Console.WriteLine("3. Cadastrar Aluno");
                Console.WriteLine("4. Matricular Aluno em Curso");
                Console.WriteLine("5. Listar Cursos");
                Console.WriteLine("6. Listar Professores");
                Console.WriteLine("7. Listar Alunos");
                Console.WriteLine("8. Listar Matrículas");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1": CadastrarCurso(); break;
                    case "2": CadastrarProfessor(); break;
                    case "3": CadastrarAluno(); break;
                    case "4": MatricularAluno(); break;
                    case "5": universidade.ListarCursos(); break;
                    case "6": universidade.ListarProfessores(); break;
                    case "7": universidade.ListarAlunos(); break;
                    case "8": universidade.ListarMatriculas(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
        }

        private void CadastrarCurso()
        {
            Console.WriteLine("\n--- Cadastro de Curso ---");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Descrição: ");
            universidade.AddCurso(new Curso(codigo, nome, Console.ReadLine()));
            Console.WriteLine("Curso cadastrado com sucesso!");
        }

        private void CadastrarProfessor()
        {
            Console.WriteLine("\n--- Cadastro de Professor ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Departamento: ");
            universidade.AddProfessor(new Professor(nome, titulo, Console.ReadLine()));
            Console.WriteLine("Professor cadastrado com sucesso!");
        }

        private void CadastrarAluno()
        {
            Console.WriteLine("\n--- Cadastro de Aluno ---");
            universidade.ListarCursos();
            if (!universidade.ExistemCursos())
            {
                Console.WriteLine("É necessário cadastrar pelo menos um curso antes de cadastrar alunos.");
                return;
            }

            Console.Write("Matrícula: ");
            int matricula = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Código do Curso: ");
            Curso curso = universidade.BuscarCursoPorCodigo(int.Parse(Console.ReadLine()));

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado!");
                return;
            }

            universidade.AddAluno(new Aluno(nome, matricula, curso));
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        private void MatricularAluno()
        {
            Console.WriteLine("\n--- Matricular Aluno ---");
            universidade.ListarAlunos();
            if (!universidade.ExistemAlunos())
            {
                Console.WriteLine("É necessário cadastrar pelo menos um aluno antes de matricular.");
                return;
            }

            universidade.ListarCursos();
            if (!universidade.ExistemCursos())
            {
                Console.WriteLine("É necessário cadastrar pelo menos um curso antes de matricular.");
                return;
            }

            Console.Write("Matrícula do Aluno: ");
            Aluno aluno = universidade.BuscarAlunoPorMatricula(int.Parse(Console.ReadLine()));
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado!");
                return;
            }

            Console.Write("Código do Curso: ");
            Curso curso = universidade.BuscarCursoPorCodigo(int.Parse(Console.ReadLine()));
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado!");
                return;
            }

            universidade.Matricular(aluno, curso);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Menu(new Universidade()).ExibirMenu();
        }
    }
}