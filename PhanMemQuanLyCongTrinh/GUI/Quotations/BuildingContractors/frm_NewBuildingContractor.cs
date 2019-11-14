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
    public partial class frm_NewBuildingContractor : DevExpress.XtraEditors.XtraForm
    {


        BUS.BuildingContractorBus buildingContractorBus = new BUS.BuildingContractorBus( );

        public frm_NewBuildingContractor()
        {
            InitializeComponent();
           
        }

        
        private void frm_NewBuildingContractor_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_Add;
            StyleDevxpressGridControl.styleTextBoxVND(txt_Liabilities);
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
            else if(txt_Address.Text=="")
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
        private bool insertBuildingContractor()
        {
            DTO.ST_building_contractor newBuildingContractor = new DTO.ST_building_contractor();
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

            DateTime now = DateTime.Now;
            now.ToString("yyyy/MM/dd");
            newBuildingContractor.building_contractor_created_date = now;

            newBuildingContractor.building_contractor_status = true;

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newBuildingContractor.building_contractor_image = fileBinary;
            }

            newBuildingContractor.employee_created = frm_Main.Vitual_id;

            return buildingContractorBus.insertBuildingContractor(newBuildingContractor);
         }
       


        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string check = checkNull();

                if (check == "true")
                {

                    bool boolInsertBuildingContractor = insertBuildingContractor();
                    if (boolInsertBuildingContractor == true)
                    {
                        messeage.success("Thêm Mới Thành Công!");
                        this.Close();
                    }
                    else
                    {
                        messeage.error("Không Thể Thêm Mới!");
                    }



                }
                else
                {
                    messeage.error(check);
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

        private void txt_Liabilities_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}