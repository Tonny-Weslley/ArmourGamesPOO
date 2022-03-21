namespace ArmourGames
{
    public class Categoria
    {
        //propriedades do objetos
        public string Nome { get; set; }
        public string Descricao { get; set; }  

        //Construtor
        public Categoria(string nome, string descricao)
        {
            this.setNome(nome);
            this.setDescricao(descricao);
        }
        public Categoria()
        {

        }
        //getters
        public string getNome()
        {
            return this.Nome;
        }
        public string getDescricao()
        {
            return this.Descricao;
        }
        //setters
        private void setNome(string nome)
        {
            this.Nome = nome;
        }
        private void setDescricao(string descricao)
        {
            this.Descricao = descricao;
        }
        public override string ToString()
        {
            return "A categoria " + this.getNome() + "é atribuida aos titulos que se enquadram na seguinte descriçao" + this.getDescricao();
        }
    }
}