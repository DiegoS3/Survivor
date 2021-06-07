using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogoutButton : MonoBehaviour
{
    public void LogOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        Loader.Instance.LoginSignUp();
    }
}
