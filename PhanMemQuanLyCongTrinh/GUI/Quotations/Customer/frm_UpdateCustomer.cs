﻿using System;
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
    public partial class frm_UpdateCustomer : DevExpress.XtraEditors.XtraForm
    {
        public frm_UpdateCustomer()
        {
            InitializeComponent();
        }
        BUS.CustomerBus customerBus = new BUS.CustomerBus( );

        BUS.CustomerGroupBus customerGroupBus = new BUS.CustomerGroupBus( );
        public Int64 customerId
        {
            get;
            set;
        }

        Image convertBiranyToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {

                Image image = Image.FromStream(ms);
                return image;
            }
        }
        #region Load Customer
        public void loadDetailCustomer()
        {
            try
            {
                var customer = customerBus.getCustomer(customerId);
                txt_CustomerId.Text = customer.GetType( ).GetProperty("customer_id_custom").GetValue(customer, null).ToString( );
                txt_CustomerName.Text = customer.GetType( ).GetProperty("customer_name").GetValue(customer, null).ToString( );
                txt_BankAccountNumber.Text = customer.GetType( ).GetProperty("custome_bank_account_number").GetValue(customer, null).ToString( );
                txt_Address.Text = customer.GetType( ).GetProperty("customer_address").GetValue(customer, null).ToString( );
                txt_Description.Text = customer.GetType( ).GetProperty("customer_description").GetValue(customer, null).ToString( );
                txt_Fax.Text = customer.GetType( ).GetProperty("custome_tax_code").GetValue(customer, null).ToString( );
                txt_Liabilities.Text = customer.GetType( ).GetProperty("customer_liabilities").GetValue(customer, null).ToString( );
                txt_PhoneNumber.Text = customer.GetType( ).GetProperty("custome_phone").GetValue(customer, null).ToString( );
                txt_Email.Text = customer.GetType( ).GetProperty("customer_email").GetValue(customer, null).ToString( );
                var boolGender = customer.GetType( ).GetProperty("custome_gender").GetValue(customer, null).ToString( );
                var birthday = customer.GetType( ).GetProperty("custome_date_of_birth").GetValue(customer, null);
                if ( birthday != null )
                {
                    DateTime day = Convert.ToDateTime(birthday);

                    date_BirthDay.Text = day.ToString("dd/MM/yyyy");
                }
                lke_CustomerGroup.EditValue = customer.GetType( ).GetProperty("customer_group_id").GetValue(customer, null).ToString( );

                //load image

                var brimary = customer.GetType( ).GetProperty("customer_image").GetValue(customer, null);
                if ( brimary != null )
                {
                    byte[] array = (brimary as System.Data.Linq.Binary).ToArray( );
                    MemoryStream ms = new MemoryStream(array);
                    pic_Logo.Image = Image.FromStream(ms);
                }




                if ( boolGender == "true" )
                {
                    cbb_Gender.SelectedItem = "Nam";
                }
                else
                {
                    cbb_Gender.SelectedItem = "Nữ";
                }

            }
            catch(Exception)
            {
                messeage.error("Lỗi !");
            }
        }
        #endregion 
        #region Load Customer Group
        public void loadComboboxCustomerGroup()
        {
            lke_CustomerGroup.Properties.ValueMember = "customer_group_id";
            lke_CustomerGroup.Properties.DisplayMember = "customer_group_name";
            lke_CustomerGroup.Properties.DataSource = customerGroupBus.getAllCustomerGroup();
        }
        #endregion
        private void frm_UpdateCustomer_Load(object sender, EventArgs e)
        {

            StyleDevxpressGridControl.autoLookUpEdit(lke_CustomerGroup);
            try
            {
                loadComboboxCustomerGroup();
                loadDetailCustomer();
            }
            catch (Exception)
            {
                messeage.err();
            }

            StyleDevxpressGridControl.styleTextBoxVND(txt_Liabilities);
            this.AcceptButton = btn_Update;
        }

        private void dongformGroup(object sender, EventArgs e)
        {
            loadComboboxCustomerGroup();
        }

        private void btn_AddCustomerGroup_Click(object sender, EventArgs e)
        {
            frm_NewCustomerGroup frm = new frm_NewCustomerGroup();
            frm.FormClosed += new FormClosedEventHandler(dongformGroup);
           
            frm.ShowDialog();
            loadDetailCustomer();
        }
        #region update Customer Group
        public void updateCustomer()
        {
            DTO.ST_customer updateCustomer = new DTO.ST_customer();
            updateCustomer.customer_id = customerId;
            updateCustomer.customer_name = txt_CustomerName.Text;
            updateCustomer.custome_bank_account_number = txt_BankAccountNumber.Text;
            if (date_BirthDay.Text != "")
            {
                DateTime date = Convert.ToDateTime(date_BirthDay.Text);
                date.ToString("yy/MM/dd");
                updateCustomer.custome_date_of_birth = date;
            }
            var gender = cbb_Gender.SelectedItem;
            if (gender == "Nam")
            {
                updateCustomer.custome_gender = true;
            }
            else
            {
                updateCustomer.custome_gender = false;
            }

            updateCustomer.custome_phone = txt_PhoneNumber.Text;
            updateCustomer.custome_tax_code = txt_Fax.Text;
            updateCustomer.customer_address = txt_Address.Text;
            updateCustomer.customer_created_date = DateTime.Now;
            updateCustomer.customer_description = txt_Description.Text;
            updateCustomer.customer_email = txt_Email.Text;
            updateCustomer.customer_liabilities = txt_Liabilities.Text;
            updateCustomer.employee_created = 1;


            // get value lookup edit customer group

            updateCustomer.customer_group_id = Convert.ToInt64(lke_CustomerGroup.EditValue);

            //get value picter customer pricter
            if (pic_Logo.Image != null)
            {
                byte[] fileByte = converImageToBirany(pic_Logo.Image);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                updateCustomer.customer_image = fileBinary;

            }

            bool boolUpdateCustomer = customerBus.updateCustomer(updateCustomer);
            if (boolUpdateCustomer == true)
            {
                messeage.success("Chĩnh Sửa Thành Công!");

            }
            else
            {
                messeage.error("Không Thể Chĩnh Sửa!");
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string check = checkNull();
                if (check == "true")
                {
                    updateCustomer();
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