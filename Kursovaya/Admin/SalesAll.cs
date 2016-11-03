using Data;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Admin
{
    public partial class SalesAll : Form
    {
        public SalesAll()
        {
            InitializeComponent();
            using (BaseContext db = new BaseContext())
            {
                dataGridView1.DataSource = db.Purchases.Select(u => new {
                    //Id = u.Id.ToString(),
                    FIO = u.Fio.ToString(),
                    PasportId = u.PasportId.ToString(),
                    Telephone = u.Telephone.ToString(),
                    Price = u.Price.ToString(),
                    CountTovar = u.Counttovar.ToString(),
                    Date = u.Date,
                    //.ToString("dd.MM.yyyy"),
                    Prod = u.prod.Name.ToString()
                }).ToList();
            }
        }
    }
}
