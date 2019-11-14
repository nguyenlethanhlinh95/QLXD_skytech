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
    public partial class frm_UpdateContruction : DevExpress.XtraEditors.XtraForm
    {

        public byte[] file;
        string fileName;
        bool isChooseFile = false;
        public Int64 counstructionId { get; set; }
        BUS.ConstructionBus constructionBus = new BUS.ConstructionBus( );
        BUS.CustomerBus customerBus = new BUS.CustomerBus( );


        public frm_UpdateContruction()
        {
            InitializeComponent();
        }

        private void loadConstruction()
        {
            var construction = constructionBus.getContruction(counstructionId);
            txt_ConstructionId.Text = construction.GetType().GetProperty("construction_id_custom").GetValue(construction, null).ToString();
            txt_Address.Text = construction.GetType().GetProperty("construction_addresss").GetValue(construction, null).ToString();
            txt_ConstructionName.Text = construction.GetType().GetProperty("construction_name").GetValue(construction, null).ToString();
            txt_ContractNumber.Text = construction.GetType().GetProperty("construction_contract_number").GetValue(construction, null).ToString();
            
         

            decimal money = Convert.ToDecimal(construction.GetType().GetProperty("construction_total_price").GetValue(construction, null).ToString());
            txt_Price.Text = money.ToString();

            var brimary = construction.GetType().GetProperty("construction_image").GetValue(construction, null);
            if (brimary != null)
            {
                byte[] array = (brimary as System.Data.Linq.Binary).ToArray();
                MemoryStream ms = new MemoryStream(array);
                pic_Logo.Image = Image.FromStream(ms);
            }
            lke_Customer.EditValue = construction.GetType().GetProperty("customer_id").GetValue(construction, null).ToString();



            var startDay =  construction.GetType().GetProperty("construction_date_start").GetValue(construction, null);
            
            if (startDay != null)
            {
                DateTime date = Convert.ToDateTime(startDay);

                date_Start.Text = date.ToShortDateString();
            }


            var endDay = construction.GetType().GetProperty("construction_date_end").GetValue(construction, null);
            if (endDay != null)
            {

                DateTime date = Convert.ToDateTime(endDay);

                date_End.Text = date.ToShortDateString();
            }


            var guaranteeStar = construction.GetType().GetProperty("construction_date_start_guarantee").GetValue(construction, null);
            if (guaranteeStar != null)
            {

                DateTime date = Convert.ToDateTime(guaranteeStar);

                date_GuaranteeStart.Text = date.ToShortDateString();
            }

            var guaranteeEnd = construction.GetType().GetProperty("construction_date_end_guarantee").GetValue(construction, null);
            if (guaranteeEnd != null)
            {

                DateTime date = Convert.ToDateTime(guaranteeEnd);

                date_GuaranteeEnd.Text = date.ToShortDateString();
            }





            var  fileNull = construction.GetType().GetProperty("construction_file").GetValue(construction, null);

            if (fileNull != null)
            {
                byte[] arr = (fileNull as System.Data.Linq.Binary).ToArray();
                file = arr;
                fileName = construction.GetType().GetProperty("construction_file_name").GetValue(construction, null).ToString();

                txt_file.Text = construction.GetType().GetProperty("construction_file_name").GetValue(construction, null).ToString();
            }
          



        }

        private void frm_UpdateContruction_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.autoLookUpEdit(lke_Customer);
            StyleDevxpressGridControl.styleTextBoxVND(txt_Price);
            try
            {

                loadConstruction();

                loadCustomer();
            }
            catch (Exception)
            {
                messeage.err();
                this.Close();
            }
            this.AcceptButton = btn_Update;
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            string path = @"D:\" + fileName;
            File.WriteAllBytes(path, file);
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        public string checkNull()
        {
            if (txt_ConstructionName.Text == "")
            {
                txt_ConstructionName.Focus();
                return "Vui Lòng Nhập Tên Công Trình!";
            }
            else if (lke_Customer.Text == lke_Customer.Properties.NullText)
            {
                lke_Customer.Focus();
                return "Vui Lòng Nhập Khách Hàng!";
            }
            else if (txt_Address.Text == "")
            {
                txt_Address.Focus();
                return "Vui Lòng Nhập Địa Chỉ Khách Hàng!";
            }
            else if (txt_ContractNumber.Text == "")
            {
                txt_ContractNumber.Focus();
                return "Vui Lòng Nhập Số Hợp Đồng!";
            }
            else if (txt_Price.Text == "")
            {
                txt_Price.Focus();
                return "Vui Lòng Nhập Tiền Công Trình!";
            }
            else if (date_Start.Text == "")
            {
                date_Start.Focus();
                return "Vui Lòng Nhập Ngày Bắt Đầu!";
            }
            else if (date_End.Text == "")
            {
                txt_Price.Focus();
                return "Vui Lòng Nhập Ngày Kết Thúc!";
            }
           
            else
            {
                return "true";
            }
        }

        byte[] converImageToBirany(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private bool updateConstruction()
        {
            DTO.ST_construction update = new DTO.ST_construction();

            update.construction_id = counstructionId;
            update.construction_name = txt_ConstructionName.Text;
            update.customer_id = Convert.ToInt64(lke_Customer.EditValue);
            update.construction_addresss = txt_Address.Text;
            update.construction_contract_number = txt_ContractNumber.Text;
            update.construction_total_price = Convert.ToDecimal(txt_Price.Text);

            if (date_Start.Text != "")
            {
                DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                dateStart.ToString("yyyy/MM/dd");
                update.construction_date_start = dateStart;
            }
            if (date_End.Text != "")
            {
                DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                dateEnd.ToString("yyyy/MM/dd");
                update.construction_date_end = dateEnd;
            }
            if (date_GuaranteeStart.Text != "")
            {
                DateTime dateGuarantee = Convert.ToDateTime(date_GuaranteeStart.Text);
                dateGuarantee.ToString("yyyy/MM/dd");
                update.construction_date_start_guarantee = dateGuarantee;
            }
            if (date_GuaranteeEnd.Text != "")
            {
                DateTime dateGuarantee = Convert.ToDateTime(date_GuaranteeEnd.Text);
                dateGuarantee.ToString("yyyy/MM/dd");
                update.construction_date_end_guarantee = dateGuarantee;
            }

                    if (file != null)
                    {
                        update.construction_file = file;
                        update.construction_file_name = fileName;
                    }

               

                if (pic_Logo.Image != null)
                {
                    byte[] fileByte = converImageToBirany(pic_Logo.Image);
                    System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                    update.construction_image = fileBinary;
                }



                return constructionBus.updateContstruction(update);
        }



        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string checkNull1 = checkNull();
                if (checkNull1 == "true")
                {
                    bool boolUpdateConstruction = updateConstruction();
                    if (boolUpdateConstruction == true)
                    {
                        messeage.success("Cập Nhật Thành Công!");

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
        public void loadCustomer()
        {
            lke_Customer.Properties.DisplayMember = "customer_name";
            lke_Customer.Properties.ValueMember = "customer_id";
            lke_Customer.Properties.DataSource = customerBus.getAllCustomer();
        }
        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            frm_NewCustomer frm = new frm_NewCustomer();
            frm.FormClosed += new FormClosedEventHandler(dongform);
           
            frm.ShowDialog();
        }

        private void dongform(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "WORD files (*.docx)|*.docx";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName1 in openFileDialog.FileNames)
                {
                    txt_file.Text = fileName1;
                    isChooseFile = true;
                }
            }


            string filepath = txt_file.Text;
            if (isChooseFile == true)
            {
                fileName = Path.GetFileName(filepath);
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                file = br.ReadBytes((Int32)fs.Length);
                isChooseFile = false;
                br.Close();
                fs.Close();
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
    }
}