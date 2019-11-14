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

namespace PhanMemQuanLyCongTrinh.GUI.FileMau
{
    public partial class frm_AddNewFileMau : DevExpress.XtraEditors.XtraForm
    {
        public frm_AddNewFileMau( )
        {
            InitializeComponent( );
        }

        byte[] bytes = null;
        string fileName;
        FileMauBus _file = new FileMauBus();

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog( );
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "WORD files (*.xlsx)|*.xls";

            if ( openFileDialog.ShowDialog( ) == System.Windows.Forms.DialogResult.OK )
            {
                foreach ( string fileName1 in openFileDialog.FileNames )
                {
                    txt_file.Text = fileName1;
                    string filepath = txt_file.Text;
                    string filename = Path.GetFileName(filepath);
                    FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32) fs.Length);
                    br.Close( );
                    fs.Close( );
                    fileName = filename;
                }
            }
        }

        private byte[] getFile( )
        {
            string filepath = txt_file.Text;
            string filename = Path.GetFileName(filepath);
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32) fs.Length);
            br.Close( );
            fs.Close( );
            return bytes;
        }

        public string checkNull()
        {
            if ( txt_ten.Text == "" )
            {
                txt_ten.Focus( );
                return "Vui Lòng Nhập Tên File Mẫu!";
            } else if (txt_file.Text == "")
            {
                txt_ten.Focus( );
                return "Vui Lòng Chọn File Mẫu!";
            }
            else
            {
                return "true";
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            try
            {
                string checkNull1 = checkNull( );
                if ( checkNull1 == "true" )
                {
                    bool boolInsert = insert( );
                    if (boolInsert)
                    {
                        messeage.success("Thêm Mới Thành Công!");
                        this.Close( );
                    }
                    else
                    {
                        messeage.error("Không Thể Thêm Mới!");
                    }
                }
            }
            catch(Exception)
            {
                messeage.err();
            }
            
        }

        private bool insert( )
        {
            DTO.ST_FileMau file = new DTO.ST_FileMau( );
            file.fileMau_TenDanhMuc = txt_ten.Text;

            if (bytes != null)
            {
                file.fileMau_File = bytes;
            }

            return _file.insert(file);
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}