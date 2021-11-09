using Photon.Realtime;

namespace Main.Scripts.PUN
{
    public class PlayerElement : BaseElement<Player>
    {
        public override void SetElementInfo(Player elementInfo)
        {
            Element = elementInfo;
            elementName.text = elementInfo.NickName;
        }

    }
}