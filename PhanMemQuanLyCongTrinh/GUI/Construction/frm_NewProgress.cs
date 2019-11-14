using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using PhanMemQuanLyCongTrinh.BUS;
namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_NewProgress : DevExpress.XtraEditors.XtraForm
    {

        BUS.ConstructionBus constructionBus = new BUS.ConstructionBus( );
        BUS.ConstructionItemBus constructionItemBus = new BUS.ConstructionItemBus( );
        BUS.ProgressBus progressBus = new BUS.ProgressBus( );

        public frm_NewProgress()
        {
            InitializeComponent();
        }
        public void loadConstruction()
        {
            lke_Constraction.Properties.DisplayMember = "construction_name";
            lke_Constraction.Properties.ValueMember = "construction_id";
            lke_Constraction.Properties.DataSource = constructionBus.getAllContruction();
        }
        public void loadConstructionItem(Int64 id)
        {
            lke_ConstractionItem.Properties.DisplayMember = "construction_item_name";
            lke_ConstractionItem.Properties.ValueMember = "construction_item_id";
            lke_ConstractionItem.Properties.DataSource = constructionItemBus.getAllIdNameContructionItem(id);
        }

        private void frm_NewProgress_Load(object sender, EventArgs e)
        {
            loadConstruction();
            this.AcceptButton = btn_Add;
        }

        private void lke_Constraction_EditValueChanged(object sender, EventArgs e)
        {
            loadConstructionItem(Convert.ToInt64( lke_Constraction.EditValue));
        }

        public string checkNull()
        {
            if (lke_Constraction.Text == lke_Constraction.Properties.NullText)
            {
                lke_Constraction.Focus();
                return "Vui Lòng Nhập Công Trình!";
            }
            else if (lke_ConstractionItem.Text == lke_ConstractionItem.Properties.NullText)
            {
                lke_ConstractionItem.Focus();
                return "Vui Lòng Nhập Hạng Mục!";
            }
            else if (date_Start.Text == "")
            {
                date_Start.Focus();
                return "Vui Lòng Nhập Ngày Bắt Đầu!";
            }
            //else if (txt_percent.Text == "" || Convert.ToInt32(txt_percent.Text) <= 0 || Convert.ToInt32(txt_percent.Text) >100)
            //{
            //    txt_percent.Focus();
            //    return "Vui Lòng Nhập Phần Trăm Chính Xác!";
            //}
            //else if ( cmb_status == null)
            //{
            //    return "Vui Lòng Chọn Tình Trạng!";
            //}
            //else if (pic_Logo.Image == null)
            //{
            //    btn_Img.Focus();
            //    return "Vui Lòng Nhập Hình Ảnh Tiến Độ Công Trình!";
            //}
            else
            {
                return "true";
            }
        }
        private bool insertProgress()
        {


            DTO.ST_progress_construction_item newProgress = new DTO.ST_progress_construction_item();
            newProgress.construction_item_id = Convert.ToInt64(lke_ConstractionItem.EditValue);
            //newProgress.progress_construction_item_percent = Convert.ToInt32( txt_percent.Text);

           

            newProgress.progress_construction_item_date_start = Convert.ToDateTime(date_Start.Text);
            newProgress.progress_construction_item_date_end = Convert.ToDateTime(date_End.Text);
            newProgress.progress_construction_item_description = txt_description.Text;
          

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newProgress.progress_construction_item_image = fileBinary;
            }
            newProgress.employee_created = frm_Main.Vitual_id;
            


            return progressBus.insertProgress(newProgress);

        }

        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string checkNull1 = checkNull();
                if (checkNull1 == "true")
                {
                    //bool isConstructionItem = progressBus.isConstructionItem(Convert.ToInt64(lke_ConstractionItem.EditValue));
                    Int64 idContructItemss = Int64.Parse(lke_ConstractionItem.EditValue.ToString());
                    var startDate = Convert.ToDateTime(date_Start.Text);
                    var endDate = Convert.ToDateTime(date_End.Text) ;
                    bool isConstructionItem = constructionItemBus.updateContstructionItemProcess(idContructItemss, startDate, endDate);
                    if (isConstructionItem == true)
                    {
                        messeage.success("Thêm Mới Thành Công!");
                        this.Close( );
                    }
                    else
                    {
                        messeage.error("Không Thể Thêm Mới!");
                    }

                }
                else
                {
                    messeage.error(checkNull1);
                }

            }
            catch (Exception)
            {
                messeage.err();
            }


            
        }

        private void btn_Img_Click(object sender, EventArgs e)
        {
            string filename;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    pic_Logo.Image = Image.FromFile(filename);
                }
            }
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_AddConstruction_Click(object sender, EventArgs e)
        {
            frm_NewConstructions frm = new frm_NewConstructions();
            frm.FormClosed += new FormClosedEventHandler(dongformGroup);

            frm.ShowDialog();
        }



        private void dongformGroup(object sender, EventArgs e)
        {
            loadConstruction();
        }

        private void btn_AddBuildingContractor_Click(object sender, EventArgs e)
        {
            frm_NewConstructionItem frm = new frm_NewConstructionItem();
            frm.FormClosed += new FormClosedEventHandler(dongform);

            frm.ShowDialog();
        }



        private void dongform(object sender, EventArgs e)
        {
            loadConstruction();
        }

    }
}