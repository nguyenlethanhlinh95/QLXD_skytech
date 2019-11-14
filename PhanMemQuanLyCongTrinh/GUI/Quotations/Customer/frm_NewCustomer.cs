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
    public partial class frm_NewCustomer : DevExpress.XtraEditors.XtraForm
    {
        BUS.CustomerBus customerBus = new BUS.CustomerBus( );

        BUS.CustomerGroupBus customerGroupBus = new BUS.CustomerGroupBus( );
        

        public frm_NewCustomer()
        {
            InitializeComponent();
           
           
        }

        
        Image convertBiranyToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {

                Image image = Image.FromStream(ms);
                return image;
            }
        }

       

        #region Load Customer Group
        public void loadComboboxCustomerGroup()
        {
            lke_CustomerGroup.Properties.ValueMember = "customer_group_id";
            lke_CustomerGroup.Properties.DisplayMember = "customer_group_name";
            lke_CustomerGroup.Properties.DataSource = customerGroupBus.getAllCustomerGroup();
        }
        #endregion

        private void frm_NewCustomer_Load(object sender, EventArgs e)
        {

            StyleDevxpressGridControl.styleTextBoxVND(txt_Liabilities);
            StyleDevxpressGridControl.autoLookUpEdit(lke_CustomerGroup);
            loadComboboxCustomerGroup();
            this.AcceptButton = btn_Update;
        }



        private void btn_AddCustomerGroup_Click(object sender, EventArgs e)
        {
            frm_NewCustomerGroup frm = new frm_NewCustomerGroup();
            frm.FormClosed += new FormClosedEventHandler(dongformGroup);
           
            frm.ShowDialog();
        }



        private void dongformGroup(object sender, EventArgs e)
        {
            loadComboboxCustomerGroup();
        }


        #region insert Customer 
        private void insertCustomer()
        {
            DTO.ST_customer newCustomer = new DTO.ST_customer();
            newCustomer.customer_name = txt_CustomerName.Text;
            newCustomer.custome_bank_account_number = txt_BankAccountNumber.Text;
            if (date_BirthDay.Text != "")
            {
                DateTime date = Convert.ToDateTime(date_BirthDay.Text);
                date.ToString("yy/MM/dd");
                newCustomer.custome_date_of_birth = date;
            }
           
            
            var gender = cbb_Gender.SelectedItem;
            if (gender == "Nam")
            {
                newCustomer.custome_gender = true;
            }
            else
            {
                newCustomer.custome_gender = false;
            }

            newCustomer.custome_phone = txt_PhoneNumber.Text;
            newCustomer.custome_tax_code = txt_Fax.Text;
            newCustomer.customer_address = txt_Address.Text;
            newCustomer.customer_created_date = DateTime.Now;
            newCustomer.customer_description = txt_Description.Text;
            newCustomer.customer_email = txt_Email.Text;
            newCustomer.customer_liabilities = txt_Liabilities.Text;
            newCustomer.employee_created = frm_Main.Vitual_id;


            // get value lookup edit customer group
            
            newCustomer.customer_group_id = Convert.ToInt64( lke_CustomerGroup.EditValue);
           
            //get value picter customer pricter

            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                newCustomer.customer_image = fileBinary;
            }
           







           bool boolInsertCustomer = customerBus.insertCustomer(newCustomer);
           if (boolInsertCustomer == true)
           {
               messeage.success("Thêm Mới Thành Công!");

               this.Close();
           }
           else
           {
               messeage.error("Không Thể Thêm Mới!");

           }   
        }
        #endregion

        


        public string checkNull()
        {
            if (txt_CustomerName.Text == "")
            {
                txt_CustomerName.Focus();
                return "Vui Lòng Nhập Tên Khách Hàng!";
            }
            else if (lke_CustomerGroup.Text == lke_CustomerGroup.Properties.NullText)
            {
                lke_CustomerGroup.Focus();
                return "Vui Lòng Nhập Nhóm Khách Hàng!";
            }
            else if (txt_Address.Text == "")
            {
                txt_Address.Focus();
                return "Vui Lòng Nhập Địa Chỉ Khách Hàng!";
            }
            else if (txt_PhoneNumber.Text == "")
            {
                txt_PhoneNumber.Focus();
                return "Vui Lòng Nhập Số Điện Thoại Khách Hàng!";
            }
            else {
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


        private void but_hinhanh_Click(object sender, EventArgs e)
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



        private void but_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string check = checkNull();

                if (check == "true")
                {
                    insertCustomer();
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

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        
    }
}