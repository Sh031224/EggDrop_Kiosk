using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace UIStateManagerLibrary
{
    // UI의 상태를 관리하는 Class
    public class UIStateManager
    {
        // UserControl 저장을 위한 CustomControlModel을 Type으로 가지는 List 정의.
        private List<CustomControlModel> customCtrlItems;

        // UserControl Visibility를 관리하기 위한 CustomControlModel을 Type으로 가지는 Stack 정의.
        public Stack<CustomControlModel> customCtrlStack;

        // Constructor
        public UIStateManager()
        {
            InitVariables();
        }

        // Member Init
        #region InitVariables
        private void InitVariables()
        {
            customCtrlItems = new List<CustomControlModel>();
            customCtrlStack = new Stack<CustomControlModel>();
        }
        #endregion

        /// <summary>
        /// 초기에 UserControl들을 설정해주기 위한 메서드.
        /// 관리하고자 하는 UserControl과 UserControl의 Type에 대한 정보를 인자로 넘겨 설정.
        /// 
        /// [HOW TO USE] : MainWindow.xaml에 만든 UserControl들을 부른 후, MainWindow.xaml.cs에서 설정해 줄 것.
        /// </summary>
        /// <param name="userCtrl", 설정하고자 하는 UserControl></param>
        /// <param name="customCtrlType", 설정하고자 하는 UserControl의 Type></param>
        public void SetCustomCtrl(CustomControlModel userCtrl, CustomControlType customCtrlType)
        {
            userCtrl.userCtrlType = customCtrlType;
            customCtrlItems.Add(userCtrl);
            userCtrl.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// UserControl을 미리 정의해둔 Stack에 Push 한 후, Visibility를 Visible로 설정.
        /// </summary>
        /// <param name="customCtrl"></param>
        public void PushCustomCtrl(CustomControlModel customCtrl)
        {
            customCtrlStack.Push(customCtrl);
            SetCustomCtrlVisible(customCtrl, Visibility.Visible);
        }

        /// <summary>
        /// Stack에 현재 올라가있는 UserControl의 Visibility를 Collapsed 시키고, Stack에 담긴 UserControl을 Pop 시킨다.
        /// </summary>
        public void PopCustomCtrl()
        {
            CustomControlModel userCtrl = customCtrlStack.Peek();

            if (userCtrl != null)
            {
                SetCustomCtrlVisible(userCtrl, Visibility.Collapsed);
                customCtrlStack.Pop();
                return;
            }
        }

        // 미리 정의해둔 Type을 통해, UserControl을 반환한다.
        public CustomControlModel GetCustomCtrl(CustomControlType customCtrlType)
        {
            return customCtrlItems.Where(x => x.userCtrlType == customCtrlType).FirstOrDefault();
        }

        /// <summary>
        /// 현재 나타내고자 하는 UserControl로 바꾸어준다.
        /// 즉, 현재 보이고 있는 UserControl은 사라지게 하고, 바꾸고자 하는 UserControl로 변경.
        /// </summary>
        /// <param name="switchCtrlTarget"></param>
        public void SwitchCustomControl(CustomControlType switchCtrlTarget)
        {
            PopCustomCtrl();
            PushCustomCtrl(GetCustomCtrl(switchCtrlTarget));
        }

        // UserControl의 Visibility를 설정.
        private void SetCustomCtrlVisible(CustomControlModel customCtrlModel, Visibility visibility)
        {
            customCtrlModel.Visibility = visibility;
        }
    }
}