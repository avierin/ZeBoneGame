using System.Drawing;
using System.Windows.Media;

namespace ZeBoneGame.MyWpf
{
    public class RedGreenColorToBoolConverter : ToBoolConverter<SolidColorBrush>
    {
     
        public RedGreenColorToBoolConverter() 
            : base(new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.Red))
        {
        }
    }


}
