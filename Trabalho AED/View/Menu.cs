using System.Security.Cryptography.X509Certificates;
using Controller;

namespace Menu
{
    
    public class Menus
    {
        private static bool VerificarEscolha(string entrada, int primeiroNumero, int segundoNumero)
        {
            bool verificado = false;
            bool isInteger = int.TryParse(entrada, out int escolha);
            if (isInteger == true && (escolha >= primeiroNumero && escolha <= segundoNumero))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Menu()
        {
            bool stopExecution = false;
            while (!stopExecution)
            {
                Console.Clear();
                Console.WriteLine("MENU\n" +
                    "1- Consulta\n" +
                    "2- Cadastro\n" +
                    "3- Salvar\n" +
                    "0- Sair");
                string entrada = Console.ReadLine();
                int escolha;
                bool ok = VerificarEscolha(entrada, 0, 3);
                while (!ok)
                {
                    Console.Clear();
                    Console.WriteLine("MENU\n" +
                        "1- Consulta\n" +
                        "2- Cadastro\n" +
                        "3- Salvar\n" +
                        "0- Sair\n" +
                        "INSIRA UM NUMERO VALIDO!");
                    entrada = Console.ReadLine();
                    ok = VerificarEscolha(entrada, 0, 3);
                }
                escolha = int.Parse(entrada);
                switch (escolha)
                {
                    case 0:
                        MainController.Sair();
                        stopExecution = true;
                        break;
                    case 1:
                        Consulta();
                        break;
                    case 2:
                        Cadastro();
                        break;
                    case 3:
                        MainController.Salvar();
                        break;
                }
            }
        }
        private static void Consulta()
        {
            Console.Clear();
            Console.WriteLine("MENU - CONSULTA\n" +
                "1- Listar Alunos\n" +
                "2- Listar Disciplinas\n" +
                "3- Listar Alunos de Uma Disciplina\n" +
                "4- Listar Disciplinas de um Aluno\n" +
                "0- Voltar ao Menu");
            string entrada = Console.ReadLine();
            int escolha;
            bool ok = VerificarEscolha(entrada, 0, 4);
            while (!ok)
            {
                Console.Clear();
                Console.WriteLine("MENU - CONSULTA\n" +
                "1- Listar Alunos\n" +
                "2- Listar Disciplinas\n" +
                "3- Listar Alunos de Uma Disciplina\n" +
                "4- Listar Disciplinas de um Aluno\n" +
                "0- Voltar ao Menu\n" +
                "INSIRA UM VALOR VALIDO!");
                entrada = Console.ReadLine();
                ok = VerificarEscolha(entrada, 0, 4);
            }
            escolha = int.Parse(entrada);
            switch (escolha)
            {
                case 0:
                    MainController.Sair();
                    break;
                case 1:
                    Consultas.ListarAlunos();
                    break;
                case 2:
                    Consultas.ListarDisciplinas();
                    break;
                case 3:
                    Consultas.ListarAlunosdeDisciplina();
                    break;
                case 4:
                    Consultas.ListarDisciplinasdeAluno();
                    break;
            }
        }
        private static void Cadastro()
        {
            Console.Clear();
            Console.WriteLine("MENU - CADASTRO\n" +
                "1- Cadastrar Alunos\n" +
                "2- Cadastrar Disciplinas\n" +
                "3- Cadastrar Matriculas\n" +
                "4- Cadastrar Notas de Alunos\n" +
                "0- Voltar ao Menu");
            string entrada = Console.ReadLine();
            int escolha;
            bool ok = VerificarEscolha(entrada, 0, 4);
            while (!ok)
            {
                Console.Clear();
                Console.WriteLine("MENU - CADASTRO\n" +
                "1- Cadastrar Alunos\n" +
                "2- Cadastrar Disciplinas\n" +
                "3- Cadastrar Matriculas\n" +
                "4- Cadastrar Notas de Alunos\n" +
                "0- Voltar ao Menu\n" +
                "INSIRA UM VALOR VALIDO!");
                entrada = Console.ReadLine();
                ok = VerificarEscolha(entrada, 0, 4);
            }
            escolha = int.Parse(entrada);
            switch (escolha)
            {
                case 0:
                    MainController.Sair();
                    break;
                case 1:
                    Cadastros.CadastrarDisciplinas();
                    break;
                case 2:
                    Cadastros.CadastrarAlunos();
                    break;
                case 3:
                    Cadastros.CadastrarMatriculas();
                    break;
                case 4:
                    Cadastros.CadastrarNotaDeAlunos();
                    break;
            }
        }
    }
}
/*consulta-> alunos,disciplinas,alunos da disciplina, disciplinas do aluno*/
/*cadastro-> disciplinas,alunos,matriculas,nota dos alunos*/
/*salvar-> salva os dados cadastrados nos arquivos*/
/*sair-> verificar se salvou, se nao, perguntar se deseja salvar, e sair*/
/*validação matricula: Soma e divide, tem que sobrar um numero, ou retornar algum numero*/