using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class Dados
    {
        private static int MaximoAlunos = 100; // base 100
        private static int MaximoDisciplina = 100; // base 100
        public static void DefinirMaximoAlunos(int maximoAlunos)
        {
            MaximoAlunos = maximoAlunos;
        }
        public static void DefinirMaximoDisciplina(int maximoDisciplina)
        {
            MaximoDisciplina = maximoDisciplina;
        }
        public static int GetMaximoAlunos()
        {
            return MaximoAlunos;
        }
        public static int GetMaximoDisciplina()
        {
            return MaximoDisciplina;
        }
        public static class DataBase
        {
            private static Alunos[] Alunos = new Alunos[MaximoAlunos];
            private static Disciplina[] Disciplinas = new Disciplina[MaximoDisciplina];
            private static Matricula[] Matriculas = new Matricula[MaximoAlunos];
            public static Alunos[] GetAlunos()
            {
                return Alunos;
            }
            public static void SetAlunos(Alunos[] alunos)
            {
                Alunos = alunos;
            }
            public static Disciplina[] GetDisciplinas()
            {
                return Disciplinas;
            }
            public static void SetDisciplinas(Disciplina[] disciplinas)
            {
                Disciplinas = disciplinas;
            }
            public static Matricula[] GetMatriculas()
            {
                return Matriculas;
            }
            public static void SetMatriculas(Matricula[] matriculas)
            {
                Matriculas = matriculas;
            }
        }
    }

}
