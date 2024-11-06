using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingGrid
{
    public partial class Form1 : Form
    {
        private List<StudentModel> _listSiswa;
        public Form1()
        {
            InitializeComponent();
            _listSiswa = new List<StudentModel>(SampleData());
            dataGridView1.DataSource = _listSiswa;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0: 
                    _listSiswa = _listSiswa.OrderBy(x => x.StudentId).ToList();
                    break;
                case 1:
                    _listSiswa = _listSiswa.OrderBy(x => x.StudentName).ToList();
                    break;
                case 2:
                    _listSiswa = _listSiswa.OrderBy(x => x.BirthDate).ToList();
                    break;
                case 3:
                    _listSiswa = _listSiswa.OrderBy(x => x.Jurusan).ToList();
                    break;
            }
            dataGridView1.DataSource = _listSiswa;
        }

        public List<StudentModel> SampleData()
        {
            return new List<StudentModel>
            {
                new StudentModel(Guid.NewGuid(), "Agus Budiman", new DateTime(2000, 5, 15),"RPL"),
                new StudentModel(Guid.NewGuid(), "Budi Cahyadi", new DateTime(1999, 8, 22), "TKJ"),
                new StudentModel(Guid.NewGuid(), "Candra Darusman", new DateTime(2001, 3, 12), "Akuntansi"),
                new StudentModel(Guid.NewGuid(), "Desi Ekawati", new DateTime(2000, 10, 30), "RPL"),
                new StudentModel(Guid.NewGuid(), "Endang Fatimah",new DateTime(1998, 12, 5), "TKJ")
            };
        }
    }
    public class StudentModel
    {
        public Guid StudentId { get; set; }
        public StudentModel()
        {
        }
        public StudentModel(Guid studentId, string studentName, DateTime birthDate, string jurusan)
        {
            StudentId = studentId;
            StudentName = studentName;
            BirthDate = birthDate;
            Jurusan = jurusan;
        }

        public string StudentName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Jurusan { get; set; }
    }
}