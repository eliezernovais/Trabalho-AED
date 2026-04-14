using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public static class Consultas
    {
        public static void ListarAlunos()
        {
            Console.Clear();
            int contador = 0;
            foreach(Alunos aluno in Dados.DataBase.GetAlunos())
            {
                if(aluno != null)
                {
                    Console.WriteLine($"{contador + 1} - {aluno.Nome}");
                    contador++;
                }
            }
            Console.WriteLine("Aperte 'Enter' para retornar ao menu Anterior");
            Console.ReadLine();
        }
        public static void ListarDisciplinas()
        {
        }
        public static void ListarAlunosdeDisciplina()
        {
        }
        public static void ListarDisciplinasdeAluno()
        {
        }
    }
}
