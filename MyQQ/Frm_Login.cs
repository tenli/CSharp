using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQ
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
        //验证用户输入
        private bool ValidateInput()
        {
            if(txtID.Text.Trim() == "") //登录账号为空判断
            {
                MessageBox.Show("请输入登录账号", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();//是登录账号文本框获得鼠标焦点
                return false;
            }
            else if(int.Parse(txtID.Text.Trim())>65535)
            {
                MessageBox.Show("请输入正确的登录账号","登录提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtID.Focus();
                return false;
            }
            else if(txtID.Text.Length>5 && txtPwd.Text.Trim() == "")//密码为空校验
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPwd.Focus();
                return false;
            }
            return true;
        }
        DataOperator dataOper = new DataOperator(); //创建数据操作类的对象
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PboxLogin_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                //定义查询语句
                string sql = "select count(*) from tb_User where ID=" + int.Parse(txtID.Text.Trim()) + "and Pwd=" + txtPwd.Text.Trim() + "";
                int num = dataOper.ExecSql(sql);
                if(num ==1)
                {
                    PublicClass.loginID = int.Parse(txtID.Text.Trim());//设置登录的用户号码
                    if(cboxRemember.Checked)//记住密码选中
                    {
                        dataOper.ExecSQLResult("update tb_User set Remember=1 where ID=" + int.Parse(txtID.Text.Trim()));
                    }
                    if(cboxAutoLogin.Checked)//自动登录选中
                    {
                        dataOper.ExecSQLResult("update tb_User set AutoLogin=1 where id=" + int.Parse(txtID.Text.Trim()));
                    }
                    else
                    {
                        dataOper.ExecSQLResult("update tb_User set Remember=0 where ID=" + int.Parse(txtID.Text.Trim()));
                        dataOper.ExecSQLResult("update tb_User set AutoLogin=0 where id=" + int.Parse(txtID.Text.Trim()));
                        dataOper.ExecSQLResult("update tb_User set Flage=1 where id=" + int.Parse(txtID.Text.Trim()));
                        Frm_Main frmMain = new Frm_Main();//创建主窗体对象
                        frmMain.Show();//启动
                        this.Visible = false;//隐藏当前登录窗体
                    }
                }
                else
                {
                    MessageBox.Show("输入的用户名或密码有误！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断是否为数字
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == '\r') || (e.KeyChar == '\b'))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
