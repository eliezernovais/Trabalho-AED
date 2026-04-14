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
    }
    class Disciplina
    {
        public int CodDisciplina { get; set; }
        public string Nome { get; set; }
        public int NotaMinima { get; set; }

    }
    class Alunos
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

    }
}
