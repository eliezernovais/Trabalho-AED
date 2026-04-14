using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class Dados
    {
        private static int maximoAlunos = 100; // base 100
        private static int maximoDisciplina = 100; // base 100

        private static Alunos[] alunos = new Alunos[maximoAlunos];
        private static Disciplina[] disciplinas = new Disciplina[maximoDisciplina];
        private static Matricula[] matriculas = new Matricula[maximoAlunos];
        public static void DefinirMaximoAlunos(int quantidade)
        {
            maximoAlunos = quantidade;
        }
        public static void DefinirMaximoDisciplina(int quantidade)
        {
            maximoDisciplina = quantidade;
        }
        public static Alunos[] GetAlunos()
        {
            return alunos;
        }
        public static Disciplina[] GetDisciplina()
        {
            return disciplinas;
        }
        public static Matricula[] GetMatricula()
        {
            return matriculas;
        }
    }
}
