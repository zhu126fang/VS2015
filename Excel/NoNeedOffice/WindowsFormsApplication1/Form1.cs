using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AppLibrary.WriteExcel.XlsDocument doc = new AppLibrary.WriteExcel.XlsDocument();
                doc.FileName = "Report.xls";
                string SheetName = string.Empty;
                //记录条数
                int mCount = 1;
                //每个SHEET的数量
                int inv = 1;
                //计算当前多少个SHEET
                int k = 1;//Convert.ToInt32(Math.Round(Convert.ToDouble(mCount / inv))) + 1;

                for (int i = 0; i < k; i++)
                {
                    SheetName = "当前是SHEET" + i.ToString();
                    AppLibrary.WriteExcel.Worksheet sheet = doc.Workbook.Worksheets.Add(SheetName);
                    AppLibrary.WriteExcel.Cells cells = sheet.Cells;
                    //第一行表头
                    cells.Add(1, 1, "序号");                    
                    int f = 1;
                    for (int m = i * inv; m < mCount && m < (i + 1) * inv; m++)
                    {
                        f++;
                        cells.Add(f, 1,"<npc=3571>：“韩赵之争自新朝以来愈演愈烈，如今终于得以收场，实在是件幸事。为防韩侂胄倒戈相向，我和你秋姨斟酌再三之后决定为你寻一同伴，行走江湖也好有个照应，只是这人选还需要你自行去寻访。”<end>"+
"<playername>：“怎么个寻访法？”<end>"+
"<npc=3571>：“目前在<color=yellow>野外地图<color>和<color=yellow>逍遥谷<color>内寻访即可，以后会陆续开放更多。你要留意<color=yellow>人物选择界面<color>名字右边是否有一个<color=yellow>“心形标记”<color>，如果有，表示他可以被说服。不过，说服的规矩也各有不同。”<end>"+
"<playername>：“有什么不同？”<end>"+
"<npc=3571>：“说服之前需要先备<color=yellow>“名帖”<color>，名帖上写着姓字名谁，师承何处，哪里人士，所循何道等等。有如人之衣裳，名帖依贵贱分为<color=yellow>镶边帛帖、穿珠银帖、鎏金玉帖<color>三种，用以说服不同人士。<color=yellow>镶边帛帖<color>可用来说服15-55级野外地图的人形怪，<color=yellow>穿珠银帖<color>可用来说服逍遥谷的人形怪，至于<color=yellow>鎏金玉帖<color>目前尚未开放。”<end>"+
"<playername>：“原来如此，那这<color=yellow>“名帖”<color>又是怎么用的？”<end>"+
"<npc=3571>：“首先找到可被说服的人形怪，在他附近<color=yellow>“选中他”<color>，切忌不要动手打他。选中之后<color=yellow>“鼠标右键单击名帖”<color>，便会有一个<color=yellow>“进度条提示”<color>你正在说服。此时不要做任何操作，耐心等着就是。一旦说服成功，会有提示告知你。若是不成功，你的名帖就会消失。”<end>"+
"<playername>：“这样就可以了吗？”<end>"+
"<npc=3571>：“是的！你按照我所说的去说服一名同伴带回来吧！不过你需要答对我提的问题，我才可以将名帖交给你。”<end>");
                       
                    }
                }

                doc.Save(ofd.SelectedPath,true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AppLibrary.ReadExcel.Workbook wb= AppLibrary.ReadExcel.Workbook.getWorkbook(ofd.FileName);
                AppLibrary.ReadExcel.Sheet[] ss = wb.Sheets;
            }
        }
    }
}
