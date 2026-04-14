using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Matricula
    {

        public int MatriculaAluno { get; set; }
        public int CodDisciplina { get; set; }
        public float Nota1 { get; set; }
        public float Nota2 { get; set; }
        public Matricula(int matriculaAluno, int codDisciplina, float nota1, float nota2)
        {
            MatriculaAluno = matriculaAluno;
            CodDisciplina = codDisciplina;
            Nota1 = nota1;
            Nota2 = nota2;
        }
    }
    class Disciplina
    {
        public int CodDisciplina { get; set; }
        public string Nome { get; set; }
        public int NotaMinima { get; set; }
        public Disciplina(int codDisciplina,string nome,int notaMinima)
        {
            CodDisciplina = codDisciplina;
            Nome = nome;
            NotaMinima = notaMinima;
        }

    }
    class Alunos
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Alunos(int matricula, string nome, int idade)
        {
            Matricula = matricula;
            Nome = nome;
            Idade = idade;
        }
    }
}
