using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public static class Cadastros
    {
        public static void CadastrarDisciplinas()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE DISCIPLINA\n");

            // Solicita o nome da disciplina e impede entrada vazia
            Console.Write("Digite o nome da disciplina: ");
            string nome = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.Write("Nome inválido. Digite o nome da disciplina: ");
                nome = Console.ReadLine();
            }

            // Solicita a nota mínima e valida se está entre 0 e 10
            float notaMinima;
            Console.Write("Digite a nota mínima da disciplina: ");
            while (!float.TryParse(Console.ReadLine(), out notaMinima) || notaMinima < 0 || notaMinima > 10)
            {
                Console.Write("Nota inválida. Digite uma nota entre 0 e 10: ");
            }

            // Gera automaticamente um código único para a nova disciplina
            int novoCodigo = 1;

            foreach (Disciplina d in Dados.DataBase.GetDisciplinas())
            {
                if (d != null && d.CodDisciplina >= novoCodigo)
                    novoCodigo = d.CodDisciplina + 1;
            }

            // Adiciona a disciplina ao vetor em memória
            Dados.DataBase.AdicionarDisciplina(novoCodigo, nome, notaMinima);

            Console.WriteLine($"\nDisciplina cadastrada com sucesso!");
            Console.WriteLine($"Código: {novoCodigo} | Nome: {nome} | Nota mínima: {notaMinima}");
            Console.WriteLine("\nAperte 'Enter' para retornar ao menu anterior");
            Console.ReadLine();
        }

        public static void CadastrarAlunos()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE ALUNO\n");

            // Solicita o nome do aluno e impede valores vazios
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.Write("Nome inválido. Digite o nome do aluno: ");
                nome = Console.ReadLine();
            }

            // Solicita a idade e valida se é um número inteiro maior que zero
            int idade;
            Console.Write("Digite a idade do aluno: ");
            while (!int.TryParse(Console.ReadLine(), out idade) || idade <= 0)
            {
                Console.Write("Idade inválida. Digite uma idade válida: ");
            }

            // Gera automaticamente uma matrícula única para o novo aluno
            int novaMatricula = 1;

            foreach (Alunos a in Dados.DataBase.GetAlunos())
            {
                if (a != null && a.Matricula >= novaMatricula)
                    novaMatricula = a.Matricula + 1;
            }

            // Adiciona o aluno ao vetor em memória
            Dados.DataBase.AdicionarAluno(novaMatricula, nome, idade);

            Console.WriteLine($"\nAluno cadastrado com sucesso!");
            Console.WriteLine($"Matrícula: {novaMatricula} | Nome: {nome} | Idade: {idade}");
            Console.WriteLine("\nAperte 'Enter' para retornar ao menu anterior");
            Console.ReadLine();
        }

        public static void CadastrarMatriculas()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE MATRÍCULA\n");

            Alunos alunoEncontrado = null;
            Disciplina disciplinaEncontrada = null;

            // Procura o aluno pelo nome ou matrícula até encontrar um válido
            while (alunoEncontrado == null)
            {
                Console.Write("Digite o nome ou matrícula do aluno: ");
                string entradaAluno = Console.ReadLine();

                foreach (Alunos a in Dados.DataBase.GetAlunos())
                {
                    if (a != null)
                    {
                        if (int.TryParse(entradaAluno, out int mat) && a.Matricula == mat)
                            alunoEncontrado = a;
                        else if (a.Nome.ToLower() == entradaAluno.ToLower())
                            alunoEncontrado = a;
                    }
                }

                if (alunoEncontrado == null)
                    Console.WriteLine("✘ Aluno não encontrado. Tente novamente.\n");
            }

            // Procura a disciplina pelo nome ou código até encontrar uma válida
            while (disciplinaEncontrada == null)
            {
                Console.Write("Digite o nome ou código da disciplina: ");
                string entradaDisciplina = Console.ReadLine();

                foreach (Disciplina d in Dados.DataBase.GetDisciplinas())
                {
                    if (d != null)
                    {
                        if (int.TryParse(entradaDisciplina, out int cod) && d.CodDisciplina == cod)
                            disciplinaEncontrada = d;
                        else if (d.Nome.ToLower() == entradaDisciplina.ToLower())
                            disciplinaEncontrada = d;
                    }
                }

                if (disciplinaEncontrada == null)
                    Console.WriteLine("✘ Disciplina não encontrada. Tente novamente.\n");
            }

            // Verifica se o aluno já está matriculado nessa disciplina
            foreach (Matricula m in Dados.DataBase.GetMatriculas())
            {
                if (m != null &&
                    m.MatriculaAluno == alunoEncontrado.Matricula &&
                    m.CodDisciplina == disciplinaEncontrada.CodDisciplina)
                {
                    Console.WriteLine("\n✘ Esse aluno já está matriculado nessa disciplina.");
                    Console.WriteLine("\nAperte 'Enter' para retornar ao menu anterior");
                    Console.ReadLine();
                    return;
                }
            }

            // Cria a matrícula com notas zeradas, pois ainda não foram lançadas
            Dados.DataBase.AdicionarMatricula(alunoEncontrado.Matricula, disciplinaEncontrada.CodDisciplina, 0, 0);

            Console.WriteLine("\nMatrícula cadastrada com sucesso!");
            Console.WriteLine($"Aluno: {alunoEncontrado.Nome} | Disciplina: {disciplinaEncontrada.Nome}");
            Console.WriteLine("\nAperte 'Enter' para retornar ao menu anterior");
            Console.ReadLine();
        }

        public static void CadastrarNotaDeAlunos()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE NOTAS\n");

            Alunos alunoEncontrado = null;
            Disciplina disciplinaEncontrada = null;
            Matricula matriculaEncontrada = null;

            // Procura o aluno até encontrar um válido
            while (alunoEncontrado == null)
            {
                Console.Write("Digite o nome ou matrícula do aluno: ");
                string entradaAluno = Console.ReadLine();

                foreach (Alunos a in Dados.DataBase.GetAlunos())
                {
                    if (a != null)
                    {
                        if (int.TryParse(entradaAluno, out int mat) && a.Matricula == mat)
                            alunoEncontrado = a;
                        else if (a.Nome.ToLower() == entradaAluno.ToLower())
                            alunoEncontrado = a;
                    }
                }

                if (alunoEncontrado == null)
                    Console.WriteLine("✘ Aluno não encontrado. Tente novamente.\n");
            }

            // Procura a disciplina até encontrar uma válida
            while (disciplinaEncontrada == null)
            {
                Console.Write("Digite o nome ou código da disciplina: ");
                string entradaDisciplina = Console.ReadLine();

                foreach (Disciplina d in Dados.DataBase.GetDisciplinas())
                {
                    if (d != null)
                    {
                        if (int.TryParse(entradaDisciplina, out int cod) && d.CodDisciplina == cod)
                            disciplinaEncontrada = d;
                        else if (d.Nome.ToLower() == entradaDisciplina.ToLower())
                            disciplinaEncontrada = d;
                    }
                }

                if (disciplinaEncontrada == null)
                    Console.WriteLine("✘ Disciplina não encontrada. Tente novamente.\n");
            }

            // Busca a matrícula correspondente ao aluno e à disciplina
            foreach (Matricula m in Dados.DataBase.GetMatriculas())
            {
                if (m != null &&
                    m.MatriculaAluno == alunoEncontrado.Matricula &&
                    m.CodDisciplina == disciplinaEncontrada.CodDisciplina)
                {
                    matriculaEncontrada = m;
                }
            }

            // Se não houver matrícula, não é possível lançar nota
            if (matriculaEncontrada == null)
            {
                Console.WriteLine("\n✘ O aluno não está matriculado nessa disciplina.");
                Console.WriteLine("\nAperte 'Enter' para retornar ao menu anterior");
                Console.ReadLine();
                return;
            }

            // Solicita as notas e valida se estão entre 0 e 10
            float nota1, nota2;

            Console.Write("Digite a Nota 1: ");
            while (!float.TryParse(Console.ReadLine(), out nota1) || nota1 < 0 || nota1 > 10)
            {
                Console.Write("Nota inválida. Digite uma nota entre 0 e 10: ");
            }

            Console.Write("Digite a Nota 2: ");
            while (!float.TryParse(Console.ReadLine(), out nota2) || nota2 < 0 || nota2 > 10)
            {
                Console.Write("Nota inválida. Digite uma nota entre 0 e 10: ");
            }

            // Atualiza a matrícula com as notas informadas
            matriculaEncontrada.Nota1 = nota1;
            matriculaEncontrada.Nota2 = nota2;

            Console.WriteLine("\nNotas cadastradas com sucesso!");
            Console.WriteLine($"Aluno: {alunoEncontrado.Nome} | Disciplina: {disciplinaEncontrada.Nome} | Nota1: {nota1} | Nota2: {nota2}");
            Console.WriteLine("\nAperte 'Enter' para retornar ao menu anterior");
            Console.ReadLine();
        }
    }
}