using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyCongTrinh.BUS;
using DevExpress.XtraCharts;
using PhanMemQuanLyCongTrinh.DTO;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_TienDoCongTrinh : DevExpress.XtraEditors.XtraForm
    {
        public frm_TienDoCongTrinh( )
        {
            InitializeComponent( );
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
        ConstructionBus _contruct = new ConstructionBus();
        ConstructionItemBus _contruct_item = new ConstructionItemBus();

        private Int64 idContruct = 0;

        #region Load
        private void frm_TienDoCongTrinh_Load(object sender, EventArgs e)
        {
            try
            {
                StyleDevxpressGridControl.autoLookUpEdit(lue_Contruct);
                var dataSource = _contruct.getAllContruction( );
                lue_Contruct.Properties.DataSource = dataSource;
                lue_Contruct.Properties.ValueMember = "construction_id";
                lue_Contruct.Properties.DisplayMember = "construction_name";
            }
            catch ( Exception )
            {
                messeage.err( );
            }
        }

        #endregion EndLoad


        #region Event
        private void lue_GroupSuplies_EditValueChanged(object sender, EventArgs e)
        {
            idContruct = (Int64) lue_Contruct.EditValue;
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            try
            {
                if (idContruct == 0)
                {
                    messeage.error("Bạn chưa chọn Công Trình !");
                }
                else
                {
                    XuLyBieuDo();
                }
            }
            catch(Exception)
            {
                chartControl1.Visible = false;
                messeage.err();
            }
        }

        void XuLyBieuDo()
        {
            chartControl1.DataSource = null;
            chartControl1.Series.Clear( );

            chartControl1.Visible = true;

            Series series1 = new Series("Kế hoạch", ViewType.Gantt);
            Series series2 = new Series("Hoàn thành", ViewType.Gantt);

            series1.ValueScaleType = ScaleType.DateTime;
            series2.ValueScaleType = ScaleType.DateTime;

            // duyet qua hang muc cua cong trinh de hien thi
            if (_contruct_item.isContructionIdtemGroup(idContruct))
            {
                var dataContructItems = from b in db.ST_construction_items
                                        where b.construction_id == idContruct
                                        select b;

                foreach (var item in dataContructItems)
                {
                    series1.Points.Add(new SeriesPoint(item.construction_item_name, new DateTime[] { DateTime.Parse (item.construction_item_date_start.ToString()), DateTime.Parse (item.construction_item_date_end.ToString()) }));

                    series2.Points.Add(new SeriesPoint(item.construction_item_name, new DateTime[] { DateTime.Parse(item.construction_item_date_start_real.ToString( )), DateTime.Parse(item.construction_item_date_end_real.ToString( )) }));
                }

                chartControl1.Series.AddRange(new Series[] { series1, series2 });
                GanttDiagram myDiagram = (GanttDiagram) chartControl1.Diagram;
                myDiagram.AxisY.Interlaced = true;
                //myDiagram.AxisY.Label.Angle = -30;

                for ( int i = 1; i <= series1.Points.Count - 1; i++ )
                    series1.Points[i].Relations.Add(series1.Points[i - 1]);
                chartControl1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                chartControl1.Titles.Add(new ChartTitle( ));

                 var contruct_name = (from b in db.ST_constructions
                                     where b.construction_id == idContruct
                                     select b.construction_name).Single();

                 chartControl1.Titles[0].Text = "BIỂU ĐỒ GANTT DỰ ÁN " + contruct_name.ToString();

                this.Controls.Add(chartControl1);
            }
            else
            {
                messeage.info("Bạn chưa có hạng mục trong Công Trình", "Thông báo");
            }
        }
        #endregion EndEvent

        

        

    }
}