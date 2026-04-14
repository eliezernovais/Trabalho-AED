using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Model
{
    public static class Dados
    {
        private static int MaximoAlunos = 100; // base 100
        private static int MaximoDisciplina = 100; // base 100
        private static int UltimoAlunoRegistrado = 0;
        private static int UltimaDisciplinaRegistrada = 0;
        private static int UltimaMatriculaRegistrada = 0;
        public static void SetUltimoAlunoRegistrado(int ultimoAlunoRegistrado)
        {
            UltimoAlunoRegistrado = ultimoAlunoRegistrado;
        }
        public static void SetUltimaDisciplinaRegistrada(int ultimaDisciplinaRegistrada)
        {
            UltimaDisciplinaRegistrada = ultimaDisciplinaRegistrada;
        }
        public static void SetUltimaMatriculaRegistrada(int ultimaMatriculaRegistrada)
        {
            UltimaMatriculaRegistrada = ultimaMatriculaRegistrada;
        }
        public static void SetMaximoAlunos(int maximoAlunos)
        {
            MaximoAlunos = maximoAlunos;
        }
        public static void SetMaximoDisciplina(int maximoDisciplina)
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
            public static void AdicionarAluno(int matricula,string nome, int idade)
            {
                try 
                { 
                Alunos[UltimoAlunoRegistrado + 1] = new Alunos(matricula, nome, idade);
                UltimoAlunoRegistrado++;
                }
                catch { }
            }
            public static Disciplina[] GetDisciplinas()
            {
                return Disciplinas;
            }
            public static void AdicionarDisciplina(int codDisciplina, string nome, float notaMinima)
            {
                try
                {
                    Disciplinas[UltimaDisciplinaRegistrada + 1] = new Disciplina(codDisciplina, nome, notaMinima);
                    UltimaDisciplinaRegistrada++;
                }
                catch { }
            }
            public static Matricula[] GetMatriculas()
            {
                return Matriculas;
            }
            public static void AdicionarMatricula(int matriculaAluno, int codDisciplina, float nota1, float nota2)
            {
                try
                {
                    Matriculas[UltimaMatriculaRegistrada + 1] = new Matricula(matriculaAluno, codDisciplina, nota1, nota2);
                    UltimaMatriculaRegistrada++;
                }
                catch { }
            }
        }
    }

}
