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
    public partial class frm_UpdateBuildingContractor : DevExpress.XtraEditors.XtraForm
    {
        public Int64 buildingContractorId { get; set; }
        BUS.BuildingContractorBus buildingContractorBus = new BUS.BuildingContractorBus( );


        public frm_UpdateBuildingContractor()
        {
            InitializeComponent();
        }

        private void frm_UpdateBuildingContractor_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_Update;
            loadBuildingContractor();
        }


        private void loadBuildingContractor()
        {
            var buildingContractor = buildingContractorBus.loadBuildingContractor(buildingContractorId);
            txt_Address.Text = buildingContractor.GetType().GetProperty("building_contractor_address").GetValue(buildingContractor, null).ToString();
            txt_BankAccountNumber.Text = buildingContractor.GetType().GetProperty("building_contractor_bank_account_number").GetValue(buildingContractor, null).ToString();
            txt_BuildingContractorId.Text = buildingContractor.GetType().GetProperty("building_contractor_id_custom").GetValue(buildingContractor, null).ToString();
            txt_BuildingContractorName.Text = buildingContractor.GetType().GetProperty("building_contractor_name").GetValue(buildingContractor, null).ToString();
            txt_Description.Text = buildingContractor.GetType().GetProperty("building_contractor_description").GetValue(buildingContractor, null).ToString();
            txt_Email.Text = buildingContractor.GetType().GetProperty("building_contractor_email").GetValue(buildingContractor, null).ToString();

            var liabilities = buildingContractor.GetType().GetProperty("building_contractor_liabilities").GetValue(buildingContractor, null);
            if (liabilities != null)
            {
                string price = String.Format("{0:n0}", liabilities);
                txt_Liabilities.Text = price;
            }

            txt_PhoneNumber.Text = buildingContractor.GetType().GetProperty("building_contractor_phone").GetValue(buildingContractor, null).ToString();
            var birthday = buildingContractor.GetType().GetProperty("building_contractor_date_of_birth").GetValue(buildingContractor, null);
            if (birthday != null)
            {
                DateTime day = Convert.ToDateTime(birthday);
                date_BirthDay.Text = day.ToString("dd/MM/yyyy");
            }
            txt_Fax.Text = buildingContractor.GetType().GetProperty("building_contractor_tax_code").GetValue(buildingContractor, null).ToString();
            //load image
            var brimary = buildingContractor.GetType().GetProperty("building_contractor_image").GetValue(buildingContractor, null);
            if (brimary != null)
            {
                byte[] array = (brimary as System.Data.Linq.Binary).ToArray();
                MemoryStream ms = new MemoryStream(array);
                pic_Logo.Image = Image.FromStream(ms);
            }

        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string checkNull()
        {
            if (txt_BuildingContractorName.Text == "")
            {
                txt_BuildingContractorName.Focus();
                return "Vui Lòng Nhập Tên Nhà Thầu";
            }
            else if (txt_Address.Text == "")
            {
                txt_Address.Focus();
                return "Vui Lòng Nhập Địa Chỉ Nhà Thầu";
            }
            else if (txt_PhoneNumber.Text == "")
            {
                txt_PhoneNumber.Focus();
                return "Vui Lòng Nhập Số Điện Thoại Nhà Thầu";
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

        private bool updateBuildingContractor()
        {
            DTO.ST_building_contractor newBuildingContractor = new DTO.ST_building_contractor();
            newBuildingContractor.building_contractor_id = buildingContractorId;
            newBuildingContractor.building_contractor_name = txt_BuildingContractorName.Text;
            newBuildingContractor.building_contractor_address = txt_Address.Text;
            newBuildingContractor.building_contractor_phone = txt_PhoneNumber.Text;
            newBuildingContractor.building_contractor_email = txt_Email.Text;
            newBuildingContractor.building_contractor_bank_account_number = txt_BankAccountNumber.Text;
            newBuildingContractor.building_contractor_tax_code = txt_Fax.Text;
            newBuildingContractor.building_contractor_description = txt_Description.Text;
            if (txt_Liabilities.Text != "")
            {
                newBuildingContractor.building_contractor_liabilities = Convert.ToDecimal(txt_Liabilities.Text);
            }
            if (date_BirthDay.Text != "")
            {
                DateTime date = Convert.ToDateTime(date_BirthDay.Text);
                date.ToString("yyyy/MM/dd");
                newBuildingContractor.building_contractor_date_of_birth = date;
            }

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newBuildingContractor.building_contractor_image = fileBinary;
            }

            return buildingContractorBus.updateBuildingContractor(newBuildingContractor);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string check = checkNull();

            if (check == "true")
            {
                    bool boolUpdateBuildingContractor = updateBuildingContractor();
                    if (boolUpdateBuildingContractor == true)
                    {
                        messeage.success("Chỉnh Sửa Thành Công!");
                    }
                    else
                    {
                        messeage.error("Không Thể Chỉnh Sửa!");
                    }
            }
            else
            {
                messeage.error(check);
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