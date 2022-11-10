using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class MainUIElement : UIScript
{
    [SerializeField] private Button shootBtn;
    public override void Initialize()
    {
        base.Initialize();
        shootBtn.onClick.AddListener(Shoot);
    }
    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    private void Shoot()
    {
        InputHandler.Instance.ShootButton = true;
    }

}
