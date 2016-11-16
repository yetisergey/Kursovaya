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
                dataGridView1.DataSource = db.Purchases.Select(u => new
                {
                    FIO = u.Fio.ToString(),
                    Price = u.Price.ToString(),
                    CountTovar = u.Counttovar.ToString(),
                    Date = u.Date,
                    Prod = u.prod.Name.ToString()
                })
                .OrderBy(u => u.Date)
                .ToList();
            }
        }
    }
}
