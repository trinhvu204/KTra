using De02.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De02
{
    public partial class Form1 : Form
    {
        SanPhamContextDB db;
        public Form1()
        {
            InitializeComponent();
            db = new SanPhamContextDB();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SanPhamContextDB context = new SanPhamContextDB();
                List<LoaiSP> loais = context.LoaiSPs.ToList();
                List<Sanpham> sanphams = context.Sanphams.ToList();
                Bindgrid(sanphams);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void FillLoaiSPCombox(List<LoaiSP> loais)
        {
            try
            {
                this.dgvSanPham.DataSource = loais;
                //this.dgvSanPham.DisplayMenber = "Tenloai";
               // this.dgvSanPham.ValueMenber = "Maloai";
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Loi khi tai du lieu:{ex.Message}","Thong bao",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
            
        }
        private void Bindgrid(List<Sanpham> sanphams)
        {
            dgvSanPham.Rows.Clear();

            foreach (var item in sanphams)
            {
                int index = dgvSanPham.Rows.Add();
                dgvSanPham.Rows[index].Cells[0].Value = item.MaSP;
                dgvSanPham.Rows[index].Cells[1].Value = item.TenSP;
                dgvSanPham.Rows[index].Cells[2].Value = item.Ngayphap;
                LoaiSP loai = db.LoaiSPs.Find(item.MaLoai);
                dgvSanPham.Rows[index].Cells[3].Value = loai?.TenLoai;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow select = dgvSanPham.Rows[e.RowIndex];
                txtMA.Text = select.Cells[0].Value.ToString();
                txtTen.Text = select.Cells[1].Value.ToString();
                //dateTimePicker1 = DateTime(select.Cells[2].Value.ToString());
                


            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban chac chan thoat khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

           if(result == DialogResult.Yes)
                Close();

            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Sanpham> sanphams = db.Sanphams.ToList();
                if(sanphams.Any(s => s.MaSP == txtMA.Text))
                {
                    MessageBox.Show("Ma so da ton tai","Thong bao",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                var newsanpham = new Sanpham
                {
                    MaSP = txtMA.Text,
                    TenSP = txtTen.Text,
                   Ngayphap = dateTimePicker1.Value,
                  // MaLoai = int.Parse(cmbLoai.SelectedValue),
                };
                db.SaveChanges();
                Bindgrid(db.Sanphams.ToList());
                //Bill
            }
            catch (Exception ex) { 

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                List<Sanpham> sanphams = db.Sanphams.ToList();
                
                var sampham = sanphams.FirstOrDefault(s => s.MaSP == txtMA.Text);
                

                
            }
            catch (Exception ex) { 

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
