using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using hint;
using System;
using Data;
using System.Linq;
using System.Collections.Generic;

namespace Admin
{
    public partial class HintForm : Form
    {
        public HintForm()
        {
            InitializeComponent();
            
            ProgressForm.selfRef.SetProgress(10);
            MLHint res = new MLHint();
            ProgressForm.selfRef.SetProgress(30);
            List<HelperTable> table = new List<HelperTable>();
            using (BaseContext db = new BaseContext())
            {
                var tempprod = db.Products;
                int incofprogr = 60/tempprod.Count();
                foreach (var io in tempprod)
                {
                    var list = db.Purchases.Where(p => p.IdProduct == io.IdProduct).ToList();
                    var temparr = from i in list
                                  group i by new { i.Date.Month, i.Date.Year } into grp
                                  select new
                                  {
                                      Month = grp.Key,
                                      Count = grp.Sum(i => i.Counttovar)
                                  };

                    int[] reslinq = temparr
                        .ToList()
                        .OrderBy(u => u.Month.Month)
                        .OrderBy(u => u.Month.Year)
                        .Select(u => u.Count)
                        .ToArray();
                    int[] tt1 = new int[reslinq.Count()];
                    for (var it = 0; it < reslinq.Count(); it++)
                    {
                        tt1[it] = it;
                    }
                    MWArray mas = null;
                    MWNumericArray arr1 = tt1;
                    mas = arr1;

                    MWArray mas2 = null;
                    MWNumericArray arr2 = reslinq;
                    mas2 = arr2;

                    try
                    {
                        var tempres = res.hint(mas, mas2).ToString();
                        if (tempres.Contains('-') == true)
                        {
                            table.Add(new HelperTable(io.Name, "Спрос будет падать."));
                        }
                        else {
                            table.Add(new HelperTable(io.Name, tempres));
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    ProgressForm.selfRef.SetProgress(incofprogr);
                }
            }
            dataGridView1.DataSource = table;
            ProgressForm.selfRef.SetAll();
            ProgressForm.selfRef.ShowHideProgress();
        }
        private class HelperTable
        {
            public HelperTable(string nm, string hnt)
            {
                Name = nm;
                Hint = hnt;
            }
            public string Name { get; set; }
            public string Hint { get; set; }
        }
    }

}