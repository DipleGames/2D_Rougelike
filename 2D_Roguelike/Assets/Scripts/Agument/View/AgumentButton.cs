using UnityEngine;
using UnityEngine.EventSystems;

public class AgumentButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (anim != null)
            anim.SetBool("Hover", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (anim != null)
            anim.SetBool("Hover", false);
    }
}
