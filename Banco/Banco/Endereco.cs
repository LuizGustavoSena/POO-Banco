namespace Banco
{
    public class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }

        // CONTRUTORES
        public Endereco()
        {
            Rua = "0";
            Numero = 0;
            Cidade = "0";
        }

        public Endereco(string rua, int numero, string cidade)
        {
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
        }

        //IMPRESSAO
        public override string ToString()
        {
            return ("Rua: " + Rua + " Número: " + Numero + " Cidade: " + Cidade);
        }
    }
}