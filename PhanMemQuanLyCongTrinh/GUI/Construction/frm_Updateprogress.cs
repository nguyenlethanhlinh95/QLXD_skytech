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
    public partial class frm_Updateprogress : DevExpress.XtraEditors.XtraForm
    {
        BUS.ConstructionBus constructionBus = new BUS.ConstructionBus( );
        BUS.ConstructionItemBus constructionItemBus = new BUS.ConstructionItemBus( );
        BUS.ProgressBus progressBus = new BUS.ProgressBus( );

        public Int64 progressId { get; set; }
        Int64 contructionId;
        Int64 contructionItemId;
        bool checkChange = true;
        public frm_Updateprogress()
        {
            InitializeComponent();
        }

        public void loadProgress()
        {
            var progress = progressBus.getProgress(progressId);
            lke_Constraction.EditValue = progress.GetType().GetProperty("construction_id").GetValue(progress, null).ToString();
            lke_ConstractionItem.EditValue = progress.GetType().GetProperty("construction_item_id").GetValue(progress, null).ToString();
            txt_description.Text = progress.GetType().GetProperty("progress_construction_item_description").GetValue(progress, null).ToString();
            
            var dateStart = progress.GetType().GetProperty("progress_construction_item_date_start").GetValue(progress, null);
            if (dateStart != null)
            {

                DateTime day = Convert.ToDateTime(dateStart);
                date_Start.Text = day.ToString("dd/MM/yyyy");
            }
            var dateEnd = progress.GetType().GetProperty("progress_construction_item_date_end").GetValue(progress, null);
            if (dateEnd != null)
            {

                DateTime day = Convert.ToDateTime(dateEnd);
                date_End.Text = day.ToString("dd/MM/yyyy");
            }

            var brimary = progress.GetType().GetProperty("progress_construction_item_image").GetValue(progress, null);
            if (brimary != null)
            {
                byte[] array = (brimary as System.Data.Linq.Binary).ToArray();
                MemoryStream ms = new MemoryStream(array);
                pic_Logo.Image = Image.FromStream(ms);
            }
            contructionId = Convert.ToInt64(progress.GetType().GetProperty("construction_id").GetValue(progress, null));
            contructionItemId = Convert.ToInt64(progress.GetType().GetProperty("construction_item_id").GetValue(progress, null));
            
            
            loadConstruction();
            loadConstructionItem(Convert.ToInt64(progress.GetType().GetProperty("construction_id").GetValue(progress, null)));
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


        private void frm_Updateprogress_Load(object sender, EventArgs e)
        {
            try
            {
                loadProgress();


            }
            catch (Exception)
            {
                messeage.err();
            }
            this.AcceptButton = btn_Update;
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        //else if (txt_percent.Text == "" || Convert.ToInt32(txt_percent.Text) <= 0 || Convert.ToInt32(txt_percent.Text) > 100)
        //{
        //    txt_percent.Focus();
        //    return "Vui Lòng Nhập Phần Trăm Chính Xác!";
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

        private bool updateProgress()
        {

            DTO.ST_progress_construction_item newProgress = new DTO.ST_progress_construction_item();

            newProgress.progress_construction_item_id = progressId;
            newProgress.progress_construction_item_date_end = Convert.ToDateTime(date_End.Text);
            newProgress.progress_construction_item_date_start = Convert.ToDateTime(date_Start.Text);
            newProgress.progress_construction_item_description = txt_description.Text;

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newProgress.progress_construction_item_image = fileBinary;
            }
          

            return progressBus.updateProgress(newProgress);

        }

        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string checkNull1 = checkNull();
                if (checkNull1 == "true")
                {
                    


                    
                        bool boolUpdateProgress = updateProgress();
                        if (boolUpdateProgress == true)
                        {
                            messeage.success("Cập Nhật Thành Công!");
                            this.Close();
                        }
                        else
                        {
                            messeage.error("Không Thể Cập Nhật!");
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

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void lke_Constraction_EditValueChanged(object sender, EventArgs e)
        {
            if (checkChange == false)
            {
                loadConstructionItem(Convert.ToInt64(lke_Constraction.EditValue));
            }
            else
            {
                checkChange = false;
            }
        }
    }
}