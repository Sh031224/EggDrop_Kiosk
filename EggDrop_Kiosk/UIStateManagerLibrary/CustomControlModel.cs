using System.Windows.Controls;

namespace UIStateManagerLibrary
{
    // [HOW TO USE]
    // UserControl을 만든 후, UserControl.xaml.cs에서 UserControl을 상속받는 게 아니라, CustomControlModel로 상속받아 사용한다.
    // ex) [위치] : ExampleControl.xaml.cs, 변경 전 => ExampleControl : UserControl
    // ex) [위치] : ExampleControl.xaml.cs, 변경 후 => ExampleControl : CustomControlModel

    // UI의 상태를 관리하기 위해 Custom 한 클래스이다.
    public partial class CustomControlModel : UserControl
    {
        // CustomControlModel은 UserControl을 상속받으면서, CustomControlType이라는 Property를 가진다.
        public CustomControlType userCtrlType = new CustomControlType();

        public CustomControlModel() : base()
        {

        }
    }
}
