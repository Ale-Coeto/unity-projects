using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Funciones para seleccionar libro y cambiar escenas
public class SelectBook : MonoBehaviour
{
    public void ChooseBook1()
    {
        BookController.Instance.Select(1);
    }
    public void ChooseBook2()
    {
        BookController.Instance.Select(2);
    }
    public void ChooseBook3()
    {
        BookController.Instance.Select(3);
    }
    public void ChooseBook4()
    {
        BookController.Instance.Select(4);
    }
    public void ChooseBook5()
    {
        BookController.Instance.Select(5);
    }
    public void ChooseBook6()
    {
        BookController.Instance.Select(6);
    }
    public void ChooseBook7()
    {
        BookController.Instance.Select(7);
    }
    public void ChooseBook8()
    {
        BookController.Instance.Select(8);
    }

    public void Select()
    {
        SceneManager.LoadScene("BookPreview");
    }

    public void Library()
    {
        SceneManager.LoadScene("SampleScene");
    }
}