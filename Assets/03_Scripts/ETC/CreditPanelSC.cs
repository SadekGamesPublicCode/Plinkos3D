using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanelSC : MonoBehaviour
{
    [HideInInspector] private string fbLink = "https://www.facebook.com/profile.php?id=100083454556637";
    [HideInInspector] private string twitterLink = "https://www.youtube.com/watch?v=v6kZLiS6raI";
    [HideInInspector] private string linkedinLink = "https://www.linkedin.com/in/huynh-bao-276278268";
    [HideInInspector] private string igLink = "https://www.youtube.com/watch?v=v6kZLiS6raI";
    [HideInInspector] private string patreonLink = "https://www.patreon.com/user?u=104249744&fromConcierge=true";
    [HideInInspector] private string ytbLink = "https://www.youtube.com/channel/UCIzq6IKOnDm6a1_azxVYlFQ";
    [HideInInspector] private string webLinked = "https://sadekgamestu.wordpress.com/";
    public void GoToFacebook() => Application.OpenURL(fbLink);
    public void GoToTwitter() => Application.OpenURL(twitterLink);
    public void GoToLinked() => Application.OpenURL(linkedinLink);
    public void GoToIG() => Application.OpenURL(igLink);
    public void GoToPatreon() => Application.OpenURL(patreonLink);
    public void GoToYoutube() => Application.OpenURL(ytbLink);
    public void GoToWeb() => Application.OpenURL(webLinked);
}
