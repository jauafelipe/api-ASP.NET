namespace src.Models
{
    public class Contract
    {

        public Contract()
        {
            this.created_at = DateTime.Now;
            this.valor = 0;
            this.tokenId = "0";

        }
        public Contract(double valor, string tokenId)
        {
            this.created_at = DateTime.Now;
            this.tokenId = tokenId;
            this.valor = valor;
            this.pago = false;
        }
        public int id { get; set; }

        public DateTime created_at { get; set; }
        public string tokenId { get; set; }
        public double valor { get; set; }
        public bool pago { get; set; }
        public int pessoaId { get; set; }

    }
}