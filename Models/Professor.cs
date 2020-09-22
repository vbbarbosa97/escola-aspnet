namespace escola_aspnet.Models
{
    public class Professor
    {
        public Professor() { }
        public Professor(int id, string nome, string disciplina)
        {
            this.Id = id;
            this.Disciplina = disciplina;
            this.Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Disciplina { get; set; }
    }
}