using UnityEngine;

public class OpenLinkComponent : MonoBehaviour
{
    [SerializeField] private string _url;
    
    public void OpenLinkWithURL(string url)
    {
        _url = url;
        OpenLink();
    }

    public void OpenLink()
    {
        Application.OpenURL(_url);
    }
}
