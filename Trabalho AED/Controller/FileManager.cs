using Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Controller
{
    public static class FileManager
    {
        private static string caminhoAluno = "Alunos.dat";
        private static string caminhoDisciplinas = "Disciplinas.dat";
        private static string caminhoMatriculas = "Matriculas.dat";
        public static void LerArquivos()
        {
            string[] linhaAluno = new string[3];
            string[] linhaDisciplina = new string[3];
            string[] linhaMatricula = new string[4];
            Alunos[] alunosLidos = new Alunos[Dados.GetMaximoAlunos()];
            Disciplina[] disciplinasLidas = new Disciplina[Dados.GetMaximoDisciplina()];
            Matricula[] matriculasLidas = new Matricula[Dados.GetMaximoAlunos()];
            int contador = 0;
            if (File.Exists(caminhoAluno))
            {
                foreach (string linha in File.ReadLines(caminhoAluno))
                {
                    linhaAluno = linha.Split(";");
                    try
                    {
                        alunosLidos[contador] = new Alunos(int.Parse(linhaAluno[0]), linhaAluno[1], int.Parse(linhaAluno[2]));
                        contador++;
                    }
                    catch { }
                }
            }
            contador = 0;
            if (File.Exists(caminhoDisciplinas))
            {
                foreach (string linha in File.ReadLines(caminhoDisciplinas))
                {
                    linhaDisciplina = linha.Split(";");
                    try
                    {
                        disciplinasLidas[contador] = new Disciplina(int.Parse(linhaDisciplina[0]), linhaDisciplina[1], float.Parse(linhaDisciplina[2]));
                        contador++;
                    }
                    catch { }
                }
            }
            contador = 0;
            if (File.Exists(caminhoMatriculas))
            {
                foreach (string linha in File.ReadLines(caminhoMatriculas))
                {
                    linhaMatricula = linha.Split(";");
                    try
                    {
                        matriculasLidas[contador] = new Matricula(int.Parse(linhaMatricula[0]), int.Parse(linhaMatricula[1]), float.Parse(linhaMatricula[2]), float.Parse(linhaMatricula[3]));
                        contador++;
                    }
                    catch { }
                }
            }
            contador = 0;
            Dados.DataBase.SetAlunos(alunosLidos);
            Dados.DataBase.SetDisciplinas(disciplinasLidas);
            Dados.DataBase.SetMatriculas(matriculasLidas);
            //alunos[0] = new Alunos { Matricula = 0, Nome = "exemplo", Idade = 0 };
        }
        public static void SalvarArquivos()
        {
            string[] linhasAlunos = new string[Dados.GetMaximoAlunos()];
            string[] linhasDisciplinas = new string[Dados.GetMaximoDisciplina()];
            string[] linhasMatriculas = new string[Dados.GetMaximoAlunos()];
            int contador = 0;
            foreach (Alunos aluno in Dados.DataBase.GetAlunos())
            {
                if (aluno != null)
                {
                    linhasAlunos[contador] = $"{aluno.Matricula};{aluno.Nome};{aluno.Idade}";
                    contador++;
                }
            }
            contador = 0;
            foreach (Disciplina disciplina in Dados.DataBase.GetDisciplinas())
            {
                if (disciplina != null)
                {
                    linhasDisciplinas[contador] = $"{disciplina.CodDisciplina};{disciplina.Nome};{disciplina.NotaMinima}";
                    contador++;
                }
            }
            contador = 0;
            foreach (Matricula matricula in Dados.DataBase.GetMatriculas())
            {
                if (matricula != null)
                {
                    linhasMatriculas[contador] = $"{matricula.MatriculaAluno};{matricula.CodDisciplina};{matricula.Nota1};{matricula.Nota2}";
                    contador++;
                }
            }
            contador = 0;
            File.WriteAllLines(caminhoAluno, linhasAlunos);
            File.WriteAllLines(caminhoDisciplinas, linhasDisciplinas);
            File.WriteAllLines(caminhoMatriculas, linhasMatriculas);

        }
        public static void ConvertDataToString() 
        { 

        }
    }
}
