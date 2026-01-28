using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entity.UserEntity;

namespace PanelSeparationMachineV1._26
{
    internal static class Program
    {



        // 启用每监视器DPI感知
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        // 在Program.Main()中调用


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            #region 制造用户数据用于测试

            //DataHandleBLL dataHandleBLL = new DataHandleBLL();

            //List<UserEntity> userEntities = new List<UserEntity>()
            //{
            //    new UserEntity() {EmployeeID = "HS001", Name = "张三", Age = 18, Password =111111, JobLevel = Level.Operator, Gender = Sex.Man, AvatarFileName = "操作员.png" },
            //    new UserEntity() {EmployeeID = "HS002", Name = "李四", Age = 19, Password = 222222, JobLevel = Level.Technician, Gender = Sex.Woman, AvatarFileName = "技术员.png" },
            //    new UserEntity() {EmployeeID = "HS003", Name = "王五", Age = 20, Password = 333333, JobLevel = Level.Engineer, Gender = Sex.Man, AvatarFileName = "工程师.png" },
            //    new UserEntity() {EmployeeID = "HS004", Name = "赵六", Age = 21, Password = 444444, JobLevel = Level.Administrator, Gender = Sex.Woman, AvatarFileName = "管理员.png" },
            //    new UserEntity() {EmployeeID = "HS005", Name = "孙七", Age = 22, Password = 555555, JobLevel = Level.Manager, Gender = Sex.Man, AvatarFileName = "经理.png" },
            //};

            //dataHandleBLL.SaveUserData(userEntities, out string res);


            #endregion

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin frmLogin = new frmLogin();
            DialogResult result = frmLogin.ShowDialog();
            if ((result == DialogResult.Cancel)) { return;}
            

            Application.Run(new frmMain());
        }
    }
}
