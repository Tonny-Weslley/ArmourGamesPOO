namespace ArmourGames
{
    class Categoria
    {
        //propriedades do objetos
        string nome;
        string descricao;

        //Construtor
        public Categoria(string nome, string descricao)
        {
            this.setNome(nome);
            this.setDescricao(descricao);
        }
        //getters
        public string getNome()
        {
            return this.nome;
        }
        public string getDescricao()
        {
            return this.descricao;
        }
        //setters
        private void setNome(string nome)
        {
            this.nome = nome;
        }
        private void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }
    }
}