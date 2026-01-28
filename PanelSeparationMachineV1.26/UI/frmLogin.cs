using BLL;
using Common;
using Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanelSeparationMachineV1._26
{
    public partial class frmLogin : UIForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void uiTitlePanel1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrWhiteSpace(txtId.Text))
            {
                errorProvider1.SetError(txtId, "工号不能为空!");
                txtId.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "密码不能为空!");
                txtPassword.Focus();
                return;
            }
            

            DataHandleBLL dataHandleBLL = new DataHandleBLL();
            
            if(dataHandleBLL.ReadUserData(out List<UserEntity> userEntities, out string res))
            {
                bool isOk = userEntities.Any(user => user.EmployeeID == txtId.Text && user.Password == int.Parse(txtPassword.Text));

                UserEntity u1 = frmMain.CurrentUserEntity;  //上一次的用户

                if (isOk) 
                {
                    //Where返回的是集合 FirstOrDefault集合的第一个元素或者null
                    frmMain.CurrentUserEntity = userEntities.Where(user => user.EmployeeID == txtId.Text).FirstOrDefault();

                    //反射
                    Type type = typeof(UserEntity.Level); //获取的UserEntity.Level类型的Type  相当于typeof(UserEntity.Level)

                    FieldInfo fieldInfo= type.GetField(frmMain.CurrentUserEntity.JobLevel.ToString());
                    //
                    if(type.IsDefined(typeof(DescriptionCustomAttribute), false))
                    {
                        DescriptionCustomAttribute descriptionCustomAttribute = (DescriptionCustomAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionCustomAttribute));
                        txtUserName.Text = descriptionCustomAttribute.Description;
                    }

                    
                    string path = Environment.CurrentDirectory + @"\头像\" + frmMain.CurrentUserEntity.AvatarFileName;
                    if(File.Exists(path))
                    {
                        uiAvatarUser.Icon = UIAvatar.UIIcon.Image;
                        uiAvatarUser.Image = Image.FromFile(path);
                    }
                    else
                    {
                        uiAvatarUser.Icon = UIAvatar.UIIcon.Symbol;
                    }
                    txtUserName.Text = frmMain.CurrentUserEntity.Name;
                    txtLevel.Text = frmMain.CurrentUserEntity.JobLevel.ToString();

                        DialogResult dialogResult = MessageBox.Show("验证成功! 是否进入主页面？", "消息提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(dialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        frmMain.CurrentUserEntity = u1;
                    }

                }
                else
                {
                    MessageBox.Show("工号或密码错误！", "错误提示❌", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Clear();
                    txtPassword.Clear();
                    txtUserName.Clear();
                    txtLevel.Clear();
                    txtId.Focus();
                    uiAvatarUser.Icon = UIAvatar.UIIcon.Symbol;
                }



            }
            else
            {
                MessageBox.Show(res, "错误提示❌", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            UITextBox textBox = sender as UITextBox;

            errorProvider1.SetError(textBox, 
                string.IsNullOrWhiteSpace(textBox.Text) ? $"{textBox.Tag}不能为空!" : null);
        }
    }
}
