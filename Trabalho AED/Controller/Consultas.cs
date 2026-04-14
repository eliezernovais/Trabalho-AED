using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public static class Consultas
    {
        // Lista todos os alunos cadastrados
        public static void ListarAlunos()
        {
            Console.Clear();
            int contador = 0;
            foreach (Alunos aluno in Dados.DataBase.GetAlunos())
            {
                if (aluno != null)
                {
                    Console.WriteLine($"{contador + 1} - {aluno.Nome}");
                    contador++;
                }
            }
            Console.WriteLine("Aperte 'Enter' para retornar ao menu Anterior");
            Console.ReadLine();
        }

        // Lista todas as disciplinas cadastradas
        public static void ListarDisciplinas()
        {
            Console.Clear();
            int contador = 0;

            // percorre o array ignorando posições nulas
            foreach (Disciplina disciplina in Dados.DataBase.GetDisciplinas())
            {
                if (disciplina != null)
                {
                    Console.WriteLine($"{contador + 1} - {disciplina.Nome} | Código: {disciplina.CodDisciplina} | Nota Mínima: {disciplina.NotaMinima}");
                    contador++;
                }
            }

            if (contador == 0)
                Console.WriteLine("Nenhuma disciplina cadastrada.");

            Console.WriteLine("Aperte 'Enter' para retornar ao menu Anterior");
            Console.ReadLine();
        }

        // Lista alunos de uma disciplina
        // Aceita nome OU código — fica em loop até achar disciplina válida
        public static void ListarAlunosdeDisciplina()
        {
            Console.Clear();
            Disciplina disciplinaEncontrada = null;

            // repete até o usuário digitar uma disciplina válida
            while (disciplinaEncontrada == null)
            {
                Console.Write("Digite o nome ou código da disciplina: ");
                string entrada = Console.ReadLine();

                foreach (Disciplina d in Dados.DataBase.GetDisciplinas())
                {
                    if (d != null)
                    {
                        // verifica se o usuário digitou o código ou o nome
                        if (int.TryParse(entrada, out int cod) && d.CodDisciplina == cod)
                            disciplinaEncontrada = d;
                        else if (d.Nome.ToLower() == entrada.ToLower())
                            disciplinaEncontrada = d;
                    }
                }

                // se não encontrou, avisa e repete
                if (disciplinaEncontrada == null)
                    Console.WriteLine("Disciplina não encontrada. Tente novamente.\n");
            }

            Console.Clear();
            Console.WriteLine($"Disciplina: {disciplinaEncontrada.Nome} | Nota Mínima: {disciplinaEncontrada.NotaMinima}\n");

            bool temAluno = false;

            // percorre as matrículas buscando alunos dessa disciplina
            foreach (Matricula m in Dados.DataBase.GetMatriculas())
            {
                if (m != null && m.CodDisciplina == disciplinaEncontrada.CodDisciplina)
                {
                    // busca o aluno correspondente
                    Alunos alunoEncontrado = null;
                    foreach (Alunos a in Dados.DataBase.GetAlunos())
                        if (a != null && a.Matricula == m.MatriculaAluno)
                            alunoEncontrado = a;

                    // calcula média e situação
                    float media = (m.Nota1 + m.Nota2) / 2;
                    string situacao = media >= disciplinaEncontrada.NotaMinima ? "APROVADO" : "REPROVADO";

                    Console.WriteLine($"Nome: {alunoEncontrado?.Nome} | Nota1: {m.Nota1} | Nota2: {m.Nota2} | Média: {media:F1} | {situacao}");
                    temAluno = true;
                }
            }

            if (!temAluno)
                Console.WriteLine("Nenhum aluno matriculado nessa disciplina.");

            Console.WriteLine("\nAperte 'Enter' para retornar ao menu Anterior");
            Console.ReadLine();
        }

        // Lista disciplinas de um aluno
        // Aceita nome OU matrícula — fica em loop até achar aluno válido
        public static void ListarDisciplinasdeAluno()
        {
            Console.Clear();
            Alunos alunoEncontrado = null;

            // repete até o usuário digitar um aluno válido
            while (alunoEncontrado == null)
            {
                Console.Write("Digite o nome ou matrícula do aluno: ");
                string entrada = Console.ReadLine();

                foreach (Alunos a in Dados.DataBase.GetAlunos())
                {
                    if (a != null)
                    {
                        // verifica se o usuário digitou a matrícula ou o nome
                        if (int.TryParse(entrada, out int mat) && a.Matricula == mat)
                            alunoEncontrado = a;
                        else if (a.Nome.ToLower() == entrada.ToLower())
                            alunoEncontrado = a;
                    }
                }

                // se não encontrou, avisa e repete
                if (alunoEncontrado == null)
                    Console.WriteLine("Aluno não encontrado. Tente novamente.\n");
            }

            Console.Clear();
            Console.WriteLine($"Aluno: {alunoEncontrado.Nome} | Matrícula: {alunoEncontrado.Matricula}\n");

            bool temDisciplina = false;

            // percorre as matrículas buscando disciplinas desse aluno
            foreach (Matricula m in Dados.DataBase.GetMatriculas())
            {
                if (m != null && m.MatriculaAluno == alunoEncontrado.Matricula)
                {
                    // busca a disciplina correspondente
                    Disciplina disciplina = null;
                    foreach (Disciplina d in Dados.DataBase.GetDisciplinas())
                        if (d != null && d.CodDisciplina == m.CodDisciplina)
                            disciplina = d;

                    // calcula média e situação
                    float media = (m.Nota1 + m.Nota2) / 2;
                    string situacao = media >= disciplina?.NotaMinima ? "APROVADO" : "REPROVADO";

                    Console.WriteLine($"Disciplina: {disciplina?.Nome} | Nota1: {m.Nota1} | Nota2: {m.Nota2} | Média: {media:F1} | {situacao}");
                    temDisciplina = true;
                }
            }

            if (!temDisciplina)
                Console.WriteLine("Aluno não está matriculado em nenhuma disciplina.");

            Console.WriteLine("\nAperte 'Enter' para retornar ao menu Anterior");
            Console.ReadLine();
        }
    }
}
