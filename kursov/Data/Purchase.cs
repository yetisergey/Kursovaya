using System.ComponentModel.DataAnnotations;

namespace Data
{
    class Purchase
    {
        [Key]
        public int Id { get; set; }
        public string Fio { get; set; }
        public string PasportId { get; set; }
        public string Telephone { get; set; }
        public int Price { get; set; }
        public string Idtovar { get; set; }
        public string Idyslugi { get; set; }
        
    }
}
