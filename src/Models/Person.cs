namespace src.Models
{
    public class Person
    {

        public Person(string name, int age, string cpf)
        {
            this.name = name;
            this.age = age;
            this.cpf = cpf;
            this.contrato = new List<Contract>();
            this.ativo = true;
        }
        //nome , idade , cpf , ativa? (sim | não)
        public int id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? cpf { get; set; }
        public bool ativo { get; set; }

        public List<Contract> contrato { get; set; }
    }
}